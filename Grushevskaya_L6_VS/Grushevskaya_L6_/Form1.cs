using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// sql
using System.Data.SqlClient;
// ru language
using System.Globalization;

namespace Grushevskaya_L6_
{
    public partial class Form1 : Form
    {
        // Data Source определяет имя машины: сервер разработчика CSVKRP748, 
        // (local) позволяет указать текущую локальную машину 
        // (независимо от конкретного имени этой машины)
        // элемент \SQLEXPRESS сообщает поставщику SQL Server, 
        // что вы подключаетесь к стандартной инсталляции SQL Server Express
        // //  (если создали БД с помощью полной версии SQL Server 2005 или более ранней, 
        // //   нужно указать Data Source=(local)
        // Initial Catalog относится к базе данных, с которой нужно установить сеанс
        // можно указать любое количество элементов, 
        // которые задают полномочия безопасности. 
        // Если имени Integrated Security 
        // присвоено значение SSPI (что эквивалентно true), 
        // то используются для аутентификации пользователя 
        // текущие полномочия учетной записи Windows
        string connectionStr = "Data Source=(local)" + "\\" + "SQLEXPRESS;Initial Catalog=Grushevskaya_L6_;Integrated Security=SSPI;";
        // объявление соединения с БД, таблицы Person с данными в памяти и адаптера, связывающего таблицу БД с таблицей в памяти
        SqlConnection conn;
        DataTable tablePerson;
        SqlDataAdapter adapterPerson;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Переключение на русский язык
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));
                
            // Если БД не существует, она будет создана
            conn = new SqlConnection(connectionStr);
            conn.Open();

            // Загрузка данных из таблицы Person в элемент DataTable
            adapterPerson = new SqlDataAdapter("SELECT ID, Last_name As 'Фамилия', First_name AS 'Имя', Patronymic AS 'Отчество' FROM PERSON", conn);
            tablePerson = new DataTable();
            adapterPerson.Fill(tablePerson);

            // Автоматическое создание требуемых для обновления таблицы БД
            // команд INSERT, UPDATE, DELETE
            new SqlCommandBuilder(adapterPerson);

            // Привязка элемента DataTable к элементу DataGridView
            dataGridViewPerson.DataSource = tablePerson;
            dataGridViewPerson.Columns[0].Visible = false;
            dataGridViewPerson.Columns[1].MinimumWidth = 217;
            dataGridViewPerson.Columns[2].MinimumWidth = 217;
            dataGridViewPerson.Columns[3].MinimumWidth = 217;
            conn.Close();
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                tablePerson.Clear();
                adapterPerson.Fill(tablePerson);
            }
        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
             try
            {
                string id = dataGridViewPerson.CurrentRow.Cells[0].Value.ToString();
                conn.Open();
                DataTable tableOldPerson = new DataTable();
                SqlCommand sqlComPerson = new SqlCommand("SELECT * FROM Person WHERE ID = " + id + ";", conn);
                SqlDataReader dr = sqlComPerson.ExecuteReader();
                tableOldPerson.Load(dr);
                string oldApartment = tableOldPerson.Rows[0][6].ToString();
                string oldNH = tableOldPerson.Rows[0][7].ToString();
                string oldStreet = tableOldPerson.Rows[0][8].ToString();
                string oldCity = tableOldPerson.Rows[0][9].ToString();
                string oldCountry = tableOldPerson.Rows[0][10].ToString();

                string sqlQuery = "DELETE FROM PERSON WHERE ID='" + id + "'";                
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                    tablePerson.Clear();
                    adapterPerson.Fill(tablePerson);
                }
                conn.Close();
                DeleteAllAddress(oldApartment, oldNH, oldStreet, oldCity, oldCountry);
                DeleteOldPhoneNumber();           
            }
             catch (NullReferenceException)
            {
                MessageBox.Show("Нет выбранного абонента");
            }
        }
        private void DeleteOldPhoneNumber()
        {
            // открыть соединение
            conn.Open();
            DataTable tableOldPhoneNumber = new DataTable();
            SqlCommand sqlComPerson = new SqlCommand("SELECT Number FROM Phone_number;", conn);
            SqlDataReader dr = sqlComPerson.ExecuteReader();
            tableOldPhoneNumber.Load(dr);
            foreach (DataRow elem in tableOldPhoneNumber.Rows)
            {
                string number = elem[0].ToString();
                DataTable tableTemp;
                SqlCommand sqlComTemp;
                SqlDataReader dr1;
                tableTemp = new DataTable();
                sqlComTemp = new SqlCommand("SELECT * FROM History_phone_number WHERE PN_Number = " + number + ";", conn);
                dr1 = sqlComTemp.ExecuteReader();
                tableTemp.Load(dr1);
                if (tableTemp.Rows.Count == 0)
                {
                    //Создание обьекта команды SQL            
                    string sqlQuery = "DELETE FROM Phone_number WHERE Number = '" + number +  "';";
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        //Отправляем команду
                        command.ExecuteNonQuery();
                    }
                }
            }
            // закрыть соединение
            conn.Close();
        }
        private void DeleteAllAddress(string oldApartment, string oldNH, string oldStreet, string oldCity, string oldCountry)
        {
            DeleteApartment(oldCountry, oldCity, oldStreet, oldNH, oldApartment);
            DeleteNH(oldCountry, oldCity, oldStreet, oldNH);
            DeleteStreet(oldCountry, oldCity, oldStreet);
            DeleteCity(oldCountry, oldCity);
            DeleteCountry(oldCountry);
        }
        private void DeleteApartment(string country, string city, string street, string house, string apartment)
        {
            // открыть соединение
            conn.Open();
            DataTable tableTemp;
            SqlCommand sqlComTemp;
            SqlDataReader dr;
            tableTemp = new DataTable();
            // APARTMENT
            sqlComTemp = new SqlCommand("SELECT * FROM Person WHERE APR_Number = '" + apartment + "' AND APR_NH_Number = '" + house + "' AND APR_NH_STREET_Name = '" + street + "' AND APR_NH_STREET_CITY_Name = '" + city + "' AND APR_NH_STREET_CITY_CNT_Name = '" + country + "';", conn);
            dr = sqlComTemp.ExecuteReader();
            tableTemp.Load(dr);
            if (tableTemp.Rows.Count == 0)
            {
                //Создание обьекта команды SQL            
                string sqlQuery = "DELETE FROM Apartment WHERE Number = '" + apartment + "' AND NH_Number = '" + house + "' AND NH_STREET_Name = '" + street + "' AND NH_STREET_CITY_Name = '" + city + "' AND NH_STREET_CITY_CNT_Name = '" + country + "';";
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }
            }
            // закрыть соединение
            conn.Close();
        }
        private void DeleteNH(string country, string city, string street, string house)
        {
            // открыть соединение
            conn.Open();
            DataTable tableTemp = new DataTable();
            SqlCommand sqlComTemp;
            SqlDataReader dr;
            tableTemp = new DataTable();
            // NUMBER_HOUSE
            sqlComTemp = new SqlCommand("SELECT * FROM Person WHERE APR_NH_Number = '" + house + "' AND APR_NH_STREET_Name = '" + street + "' AND APR_NH_STREET_CITY_Name = '" + city + "' AND APR_NH_STREET_CITY_CNT_Name = '" + country + "';", conn);
            dr = sqlComTemp.ExecuteReader();
            tableTemp.Load(dr);
            if (tableTemp.Rows.Count == 0)
            {
                //Создание обьекта команды SQL            
                string sqlQuery = "DELETE FROM Number_house WHERE Number = '" + house + "' AND STREET_Name = '" + street + "' AND STREET_CITY_Name = '" + city + "' AND STREET_CITY_CNT_Name = '" + country + "';";
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }
            }
            // закрыть соединение
            conn.Close();
        }
        private void DeleteStreet(string country, string city, string street)
        {
            // открыть соединение
            conn.Open();
            DataTable tableTemp = new DataTable();
            SqlCommand sqlComTemp;
            SqlDataReader dr;
            tableTemp = new DataTable();
            // STREET
            sqlComTemp = new SqlCommand("SELECT * FROM Person WHERE APR_NH_STREET_Name = '" + street + "' AND APR_NH_STREET_CITY_Name = '" + city + "' AND APR_NH_STREET_CITY_CNT_Name = '" + country + "';", conn);
            dr = sqlComTemp.ExecuteReader();
            tableTemp.Load(dr);
            if (tableTemp.Rows.Count == 0)
            {
                //Создание обьекта команды SQL            
                string sqlQuery = "DELETE FROM Street WHERE Name = '" + street + "' AND CITY_Name = '" + city + "' AND CITY_CNT_Name = '" + country + "';";
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }
            }
            // закрыть соединение
            conn.Close();
        }
        private void DeleteCity(string country, string city)
        {
            // открыть соединение
            conn.Open();
            DataTable tableTemp = new DataTable();
            SqlCommand sqlComTemp;
            SqlDataReader dr;
            tableTemp = new DataTable();
            // CITY
            sqlComTemp = new SqlCommand("SELECT * FROM Person WHERE APR_NH_STREET_CITY_Name = '" + city + "' AND APR_NH_STREET_CITY_CNT_Name = '" + country + "';", conn);
            dr = sqlComTemp.ExecuteReader();
            tableTemp.Load(dr);
            if (tableTemp.Rows.Count == 0)
            {
                //Создание обьекта команды SQL            
                string sqlQuery = "DELETE FROM City WHERE Name = '" + city + "' AND CNT_Name = '" + country + "';";
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }
            }
            // закрыть соединение
            conn.Close();
        }
        private void DeleteCountry(string country)
        {
            try
            {
                // открыть соединение
                conn.Open();
                DataTable tableTemp;
                SqlCommand sqlComTemp;
                SqlDataReader dr;
                tableTemp = new DataTable();
                // COUNTRY
                sqlComTemp = new SqlCommand("SELECT * FROM Person WHERE APR_NH_STREET_CITY_CNT_Name = '" + country + "';", conn);
                dr = sqlComTemp.ExecuteReader();
                tableTemp.Load(dr);
                if (tableTemp.Rows.Count == 0)
                {
                    //Создание обьекта команды SQL            
                    string sqlQuery = "DELETE FROM Country WHERE Name = '" + country + "';";
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        //Отправляем команду
                        command.ExecuteNonQuery();
                    }
                }
                // закрыть соединение
                conn.Close();
            }
            catch 
            {
                // закрыть соединение
                conn.Close();
            }
        }


        private void buttonEditPerson_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridViewPerson.CurrentRow.Cells[0].Value.ToString();
                Form2 form2 = new Form2(id);
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    tablePerson.Clear();
                    adapterPerson.Fill(tablePerson);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Нет выбранного абонента");
            }
        }

        private void buttonCategory_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            if (form4.ShowDialog() == DialogResult.OK)
            {
                tablePerson.Clear();
                adapterPerson.Fill(tablePerson);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            // таблица Person
            String findText = " ";
            bool flagFirst = true;
            string country = textBoxCountry.Text;
            if (!country.Equals(""))
            {
                country = " p.APR_NH_STREET_CITY_CNT_Name  LIKE '%" + country + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    country = " AND " + country;
                }
                findText += country;
            }
            string city = textBoxCity.Text;
            if (!city.Equals(""))
            {
                city = " p.APR_NH_STREET_CITY_Name  LIKE '%" + city + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    city = " AND " + city;
                }
                findText += city;
            }
            string street = textBoxStreet.Text;
            if (!street.Equals(""))
            {
                street = " p.APR_NH_STREET_Name  LIKE '%" + street + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    street = " AND " + street;
                }
                findText += street;
            }
            string house = textBoxNH.Text;
            if (!house.Equals(""))
            {
                house = " p.APR_NH_Name  LIKE '%" + house + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    house = " AND " + house;
                }
                findText += house;
            }
            string apartment = textBoxApartment.Text;
            if (!apartment.Equals(""))
            {
                apartment = " p.APR_Name  LIKE '%" + apartment + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    apartment = " AND " + apartment;
                }
                findText += apartment;
            }
            string lastName = textBoxLastName.Text;
            if (!lastName.Equals(""))
            {
                lastName = " p.Last_Name  LIKE '%" + lastName + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    lastName = " AND " + lastName;
                }
                findText += lastName;
            }
            string firstName = textBoxFirstName.Text;
            if (!firstName.Equals(""))
            {
                firstName = " p.First_Name  LIKE '%" + firstName + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    firstName = " AND " + firstName;
                }
                findText += firstName;
            }
            string patronymic = textBoxPatronymic.Text;
            if (!patronymic.Equals(""))
            {
                patronymic = " p.Patronymic  LIKE '%" + patronymic + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    patronymic = " AND " + patronymic;
                }
                findText += patronymic;
            }
            string isq = textBoxIsq.Text;
            if (!isq.Equals(""))
            {
                isq = " p.ISQ  LIKE '%" + isq + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    isq = " AND " + isq;
                }
                findText += isq;
            }
            string vk = textBoxVk.Text;
            if (!vk.Equals(""))
            {
                vk = " p.VK  LIKE '%" + vk + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    vk = " AND " + vk;
                }
                findText += vk;
            }
            string email = textBoxEmail.Text;
            if (!email.Equals(""))
            {
                email = " e.Email  LIKE '%" + email + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    email = " AND " + email;
                }
                findText += email;
            }
            string phoneNumber = textBoxPN.Text;
            if (!phoneNumber.Equals(""))
            {
                phoneNumber = " hpn.PN_Number  LIKE '%" + phoneNumber + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    phoneNumber = " AND " + phoneNumber;
                }
                findText += phoneNumber;
            }
            string category = textBoxCategory.Text;
            if (!category.Equals(""))
            {
                category = " cp.CTG_Name  LIKE '%" + category + "%' ";
                if (flagFirst)
                {
                    flagFirst = false;
                }
                else
                {
                    category = " AND " + category;
                }
                findText += category;
            }
            if (!flagFirst)
            {
                conn.Open();
                string query = "SELECT DISTINCT p.ID, p.Last_name As 'Фамилия', p.First_name AS 'Имя', p.Patronymic AS 'Отчество' FROM Person p LEFT OUTER JOIN History_phone_number hpn ON(p.ID = hpn.PRS_ID) LEFT OUTER JOIN Phone_number pn ON (pn.Number = hpn.PN_Number) LEFT OUTER JOIN Email e ON (e.PRS_ID = p.ID) LEFT OUTER JOIN Category_person cp ON (cp.PRS_ID = p.ID) WHERE " + findText + ";";
                adapterPerson = new SqlDataAdapter(query, conn);
                tablePerson = new DataTable();
                adapterPerson.Fill(tablePerson);
                // Автоматическое создание требуемых для обновления таблицы БД
                // команд INSERT, UPDATE, DELETE
                new SqlCommandBuilder(adapterPerson);
                // Привязка элемента DataTable к элементу DataGridView
                dataGridViewPerson.DataSource = tablePerson;
                dataGridViewPerson.Columns[0].Visible = false;
                conn.Close();
            }
            MessageBox.Show("Поиск окончен");
        }

        private void buttonFindClear_Click(object sender, EventArgs e)
        {
            textBoxCountry.Text ="";
            textBoxCity.Text = "";
            textBoxStreet.Text = "";
            textBoxNH.Text = "";
            textBoxApartment.Text = "";
            textBoxLastName.Text = "";
            textBoxFirstName.Text = "";
            textBoxPatronymic.Text = "";
            textBoxIsq.Text = "";
            textBoxVk.Text = "";
            textBoxEmail.Text = "";
            textBoxPN.Text = "";
            textBoxCategory.Text = "";            
            conn.Open();
            // Загрузка данных из таблицы Person в элемент DataTable
            adapterPerson = new SqlDataAdapter("SELECT ID, Last_name As 'Фамилия', First_name AS 'Имя', Patronymic AS 'Отчество' FROM PERSON", conn);
            tablePerson = new DataTable();
            adapterPerson.Fill(tablePerson);
            // Автоматическое создание требуемых для обновления таблицы БД
            // команд INSERT, UPDATE, DELETE
            new SqlCommandBuilder(adapterPerson);
            // Привязка элемента DataTable к элементу DataGridView
            dataGridViewPerson.DataSource = tablePerson;
            dataGridViewPerson.Columns[0].Visible = false;
            conn.Close();
        }
    }
}
