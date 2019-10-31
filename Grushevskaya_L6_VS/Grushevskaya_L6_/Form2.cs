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
    public partial class Form2 : Form
    {
        string connectionStr = "Data Source=(local)" + "\\" + "SQLEXPRESS;Initial Catalog=Grushevskaya_L6_;Integrated Security=SSPI;";
        // объявление соединения с БД
        SqlConnection conn;
        string currentIndex;
        SqlDataAdapter adapterCategory;
        SqlDataAdapter adapterPN;
        SqlDataAdapter adapterEmail;
        DataTable tableCategory;
        DataTable tablePN;
        DataTable tableEmail;
        public Form2(string index = "-1")
        {
            InitializeComponent();
            currentIndex = index;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Переключение на русский язык
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

            // создание объекта подключения
            conn = new SqlConnection(connectionStr);

            // открыть соединение
            conn.Open();

            DownloadCategory();
            DownloadPN();
            DownloadEmail();
            DownloadPerson();

            // закрыть соединение
            conn.Close();
        }

        private void DownloadPerson()
        {
            // PERSON
            int index = Int32.Parse(currentIndex);
            if (index > 0)
            {
                DataTable tablePerson = new DataTable();
                SqlCommand sqlComPerson = new SqlCommand("SELECT * FROM Person WHERE ID = '" + currentIndex + "';", conn);
                SqlDataReader dr = sqlComPerson.ExecuteReader();
                tablePerson.Load(dr);
                textBoxLastName.Text = tablePerson.Rows[0][1].ToString();
                textBoxFirstName.Text = tablePerson.Rows[0][2].ToString();
                textBoxPatronymic.Text = tablePerson.Rows[0][3].ToString();
                textBoxIsq.Text = tablePerson.Rows[0][4].ToString();
                textBoxVk.Text = tablePerson.Rows[0][5].ToString();
                textBoxApartment.Text = tablePerson.Rows[0][6].ToString();
                textBoxNH.Text = tablePerson.Rows[0][7].ToString();
                textBoxStreet.Text = tablePerson.Rows[0][8].ToString();
                textBoxCity.Text = tablePerson.Rows[0][9].ToString();
                textBoxCountry.Text = tablePerson.Rows[0][10].ToString();
            }
        }

        private void DownloadEmail()
        {
            // EMAIL
            // Загрузка данных из таблицы
            adapterEmail = new SqlDataAdapter("SELECT Email, Type AS 'Тип' FROM Email WHERE PRS_ID = '" + currentIndex + "';", conn);
            tableEmail = new DataTable();
            adapterEmail.Fill(tableEmail);
            // Автоматическое создание требуемых для обновления таблицы БД
            // команд INSERT, UPDATE, DELETE
            new SqlCommandBuilder(adapterEmail);
            dataGridViewEmail.DataSource = tableEmail;
            dataGridViewEmail.Columns[0].MinimumWidth = 140;
            dataGridViewEmail.Columns[1].MinimumWidth = 140;
        }

        private void DownloadPN()
        {
            // PHONE_NUMBER
            // Загрузка данных из таблицы
            switch (checkBoxOld.Checked)
            {
                case false:
                    adapterPN = new SqlDataAdapter("SELECT hpn.PN_Number AS 'Номер', pn.Type AS 'Тип', hpn.Start_date AS 'c' FROM History_phone_number hpn JOIN Phone_number pn ON (hpn.PN_number = pn.Number) WHERE PRS_ID = '" + currentIndex + "' AND End_date IS NULL", conn);
                    break;
                case true:
                    adapterPN = new SqlDataAdapter("SELECT hpn.PN_Number AS 'Номер', pn.Type AS 'Тип', hpn.Start_date AS 'c', hpn.End_date AS 'по' FROM History_phone_number hpn JOIN Phone_number pn ON (hpn.PN_number = pn.Number) WHERE PRS_ID = '" + currentIndex + "'", conn);
                    break;
            }
            tablePN = new DataTable();
            adapterPN.Fill(tablePN);
            // Автоматическое создание требуемых для обновления таблицы БД
            // команд INSERT, UPDATE, DELETE
            new SqlCommandBuilder(adapterPN);
            dataGridViewPN.DataSource = tablePN;
        }
        private void DownloadCategory()
        {
            // CATEGORY
            // Загрузка данных из таблицы
            adapterCategory = new SqlDataAdapter("SELECT CTG_Name AS 'Группа' FROM Category_person WHERE PRS_ID = '" + currentIndex + "';", conn);
            tableCategory = new DataTable();
            adapterCategory.Fill(tableCategory);
            // Автоматическое создание требуемых для обновления таблицы БД
            // команд INSERT, UPDATE, DELETE
            new SqlCommandBuilder(adapterCategory);
            dataGridViewCategory.DataSource = tableCategory;
            dataGridViewCategory.Columns[0].MinimumWidth = 283;
        }


        private void buttonSavePerson_Click(object sender, EventArgs e)
        {

            string country = textBoxCountry.Text;
            string city = textBoxCity.Text;
            string street = textBoxStreet.Text;
            string house = textBoxNH.Text;
            string apartment = textBoxApartment.Text;
            string lastName = textBoxLastName.Text;
            string firstName = textBoxFirstName.Text;
            string patronymic = textBoxPatronymic.Text;
            string isq = textBoxIsq.Text;
            string vk = textBoxVk.Text;

            
            int index = Int32.Parse(currentIndex);
            if (index <= 0)
            {
                AddNewPerson(country, city, street, house, apartment, lastName, firstName, patronymic, isq, vk);
            }
            else
            {
                // открыть соединение
                conn.Open(); 
                // для удаления старого адреса запомнить
                DataTable tableOldPerson = new DataTable();
                SqlCommand sqlComPerson = new SqlCommand("SELECT * FROM Person WHERE ID = '" + currentIndex + "';", conn);
                SqlDataReader dr = sqlComPerson.ExecuteReader();                
                tableOldPerson.Load(dr);
                string oldApartment = tableOldPerson.Rows[0][6].ToString();
                string oldNH = tableOldPerson.Rows[0][7].ToString();
                string oldStreet = tableOldPerson.Rows[0][8].ToString();
                string oldCity = tableOldPerson.Rows[0][9].ToString();
                string oldCountry = tableOldPerson.Rows[0][10].ToString();
                // закрыть соединение
                conn.Close();
                // добавить недостающие части нового адреса
                AddAddress(country, city, street, house, apartment);
                // обновить данные персоны
                UpdatePerson(country, city, street, house, apartment, lastName, firstName, patronymic, isq, vk);
                // удаление старого адреса
                DeleteAddress(country, city, street, house, apartment, oldApartment, oldNH, oldStreet, oldCity, oldCountry);
            }
            // сохрание прошло успешно
            MessageBox.Show("Успешно сохранено");
        }

        private void DeleteAddress(string country, string city, string street, string house, string apartment, string oldApartment, string oldNH, string oldStreet, string oldCity, string oldCountry)
        {
            if (apartment.Equals(oldApartment))
            {
                if (house.Equals(oldNH))
                {
                    if (street.Equals(oldStreet))
                    {
                        if (city.Equals(oldCity))
                        {
                            if (!country.Equals(oldCountry))
                            {
                                DeleteAllAddress(oldApartment, oldNH, oldStreet, oldCity, oldCountry);
                            }
                        }
                        else
                        {
                            DeleteApartment(oldCountry, oldCity, oldStreet, oldNH, oldApartment);
                            DeleteNH(oldCountry, oldCity, oldStreet, oldNH);
                            DeleteStreet(oldCountry, oldCity, oldStreet);
                            DeleteCity(oldCountry, oldCity);
                        }
                    }
                    else
                    {
                        DeleteApartment(oldCountry, oldCity, oldStreet, oldNH, oldApartment);
                        DeleteNH(oldCountry, oldCity, oldStreet, oldNH);
                        DeleteStreet(oldCountry, oldCity, oldStreet);
                    }
                }
                else
                {
                    DeleteApartment(oldCountry, oldCity, oldStreet, oldNH, oldApartment);
                    DeleteNH(oldCountry, oldCity, oldStreet, oldNH);
                }
            }
            else
            {
                DeleteApartment(oldCountry, oldCity, oldStreet, oldNH, oldApartment);
            }
        }

        private void DeleteAllAddress(string oldApartment, string oldNH, string oldStreet, string oldCity, string oldCountry)
        {
            DeleteApartment(oldCountry, oldCity, oldStreet, oldNH, oldApartment);
            DeleteNH(oldCountry, oldCity, oldStreet, oldNH);
            DeleteStreet(oldCountry, oldCity, oldStreet);
            DeleteCity(oldCountry, oldCity);
            DeleteCountry(oldCountry);
        }

        private void AddNewPerson(string country, string city, string street, string house, string apartment, string lastName, string firstName, string patronymic, string isq, string vk)
        {
            AddAddress(country, city, street, house, apartment);
            AddPerson(country, city, street, house, apartment, lastName, firstName, patronymic, isq, vk);
        }

        private void AddAddress(string country, string city, string street, string house, string apartment)
        {
            AddCountry(country);
            AddCity(country, city);
            AddStreet(country, city, street);
            AddNH(country, city, street, house);
            AddApartment(country, city, street, house, apartment);
        }

        private void AddPerson(string country, string city, string street, string house, string apartment, string lastName, string firstName, string patronymic, string isq, string vk)
        {
            // PERSON    
            // открыть соединение
            conn.Open();
            //Создание обьекта команды SQL            
            string sqlQuery1 = "INSERT INTO PERSON (Last_name, First_name, Patronymic, ISQ, VK, APR_Number, APR_NH_Number, APR_NH_STREET_Name, APR_NH_STREET_CITY_Name, APR_NH_STREET_CITY_CNT_Name) VALUES ('" +
                lastName + "','" + firstName + "','" + patronymic + "','" + isq + "','" + vk + "','" + apartment + "','" + house + "','" + street + "','" + city + "','" + country + "');";
            using (SqlCommand command = new SqlCommand(sqlQuery1, conn))
            {
                //Отправляем команду
                command.ExecuteNonQuery();
            }
            // текущий индекс
            DataTable tablePerson = new DataTable();
            SqlCommand sqlComPerson = new SqlCommand("SELECT * FROM Person", conn);
            SqlDataReader dr1 = sqlComPerson.ExecuteReader();
            tablePerson.Load(dr1);
            int count = tablePerson.Rows.Count;
            currentIndex = tablePerson.Rows[count - 1][0].ToString();
            // закрыть соединение
            conn.Close();
        }

        private void AddApartment(string country, string city, string street, string house, string apartment)
        {
            // открыть соединение
            conn.Open();
            DataTable tableTemp;
            SqlCommand sqlComTemp;
            SqlDataReader dr;
            tableTemp = new DataTable();
            // APARTMENT
            sqlComTemp = new SqlCommand("SELECT * FROM Apartment WHERE Number = '" + apartment + "' AND NH_Number = '" + house + "' AND NH_STREET_Name = '" + street + "' AND NH_STREET_CITY_Name = '" + city + "' AND NH_STREET_CITY_CNT_Name = '" + country + "';", conn);
            dr = sqlComTemp.ExecuteReader();
            tableTemp.Load(dr);
            if (tableTemp.Rows.Count == 0)
            {
                //Создание обьекта команды SQL            
                string sqlQuery = "INSERT INTO Apartment (Number, NH_Number, NH_STREET_Name, NH_STREET_CITY_Name, NH_STREET_CITY_CNT_Name) VALUES ('" + apartment + "','" + house + "','" + street + "','" + city + "','" + country + "');";
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }
            }
            // закрыть соединение
            conn.Close();
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
        private void AddNH(string country, string city, string street, string house)
        {
            // открыть соединение
            conn.Open();
            DataTable tableTemp = new DataTable();
            SqlCommand sqlComTemp;
            SqlDataReader dr;
            tableTemp = new DataTable();
            // NUMBER_HOUSE
            sqlComTemp = new SqlCommand("SELECT * FROM Number_house WHERE Number = '" + house + "' AND STREET_Name = '" + street + "' AND STREET_CITY_Name = '" + city + "' AND STREET_CITY_CNT_Name = '" + country + "';", conn);
            dr = sqlComTemp.ExecuteReader();
            tableTemp.Load(dr);
            if (tableTemp.Rows.Count == 0)
            {
                //Создание обьекта команды SQL            
                string sqlQuery = "INSERT INTO Number_house (Number, STREET_Name, STREET_CITY_Name, STREET_CITY_CNT_Name) VALUES ('" + house + "','" + street + "','" + city + "','" + country + "');";
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

        private void AddStreet(string country, string city, string street)
        {
            // открыть соединение
            conn.Open();
            DataTable tableTemp = new DataTable();
            SqlCommand sqlComTemp;
            SqlDataReader dr;
            tableTemp = new DataTable();
            // STREET
            sqlComTemp = new SqlCommand("SELECT * FROM Street WHERE Name = '" + street + "' AND CITY_Name = '" + city + "' AND CITY_CNT_Name = '" + country + "';", conn);
            dr = sqlComTemp.ExecuteReader();
            tableTemp.Load(dr);
            if (tableTemp.Rows.Count == 0)
            {
                //Создание обьекта команды SQL            
                string sqlQuery = "INSERT INTO Street (Name, CITY_Name, CITY_CNT_Name) VALUES ('" + street + "','" + city + "','" + country + "');";
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

        private void AddCity(string country, string city)
        {
            // открыть соединение
            conn.Open();
            DataTable tableTemp = new DataTable();
            SqlCommand sqlComTemp;
            SqlDataReader dr;
            tableTemp = new DataTable();
            // CITY
            sqlComTemp = new SqlCommand("SELECT * FROM City WHERE Name = '" + city + "' AND CNT_Name = '" + country + "';", conn);
            dr = sqlComTemp.ExecuteReader();
            tableTemp.Load(dr);
            if (tableTemp.Rows.Count == 0)
            {
                //Создание обьекта команды SQL            
                string sqlQuery = "INSERT INTO City (Name, CNT_Name) VALUES ('" + city + "','" + country + "');";
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

        private void AddCountry(string country)
        {
            // открыть соединение
            conn.Open();
            DataTable tableTemp;
            SqlCommand sqlComTemp;
            SqlDataReader dr;
            tableTemp = new DataTable();
            // COUNTRY
            sqlComTemp = new SqlCommand("SELECT * FROM Country WHERE Name = '" + country + "';", conn);
            dr = sqlComTemp.ExecuteReader();
            tableTemp.Load(dr);
            if (tableTemp.Rows.Count == 0)
            {
                //Создание обьекта команды SQL            
                string sqlQuery = "INSERT INTO Country (Name) VALUES ('" + country + "');";
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
                    try { 
                        //Отправляем команду
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        // закрыть соединение
                        conn.Close();
                    }
                }
            }
            // закрыть соединение
            conn.Close();
        }

        private void UpdatePerson(string country, string city, string street, string house, string apartment, string lastName, string firstName, string patronymic, string isq, string vk)
        {
            // PERSON    
            // открыть соединение
            conn.Open();
            //Создание обьекта команды SQL            
            string sqlQuery1 = "UPDATE PERSON SET Last_name ='" + lastName + "', First_name ='" + firstName
                + "', Patronymic = '" + patronymic + "', ISQ = ' " + isq + "', VK = '" + vk
                + "', APR_Number = '" + apartment + "', APR_NH_Number ='" + house
                + "', APR_NH_STREET_Name ='" + street + "', APR_NH_STREET_CITY_Name = '" + city
                + "', APR_NH_STREET_CITY_CNT_Name ='" + country + "' WHERE ID = '" + currentIndex + "';";
            using (SqlCommand command = new SqlCommand(sqlQuery1, conn))
            {
                //Отправляем команду
                command.ExecuteNonQuery();
            }
            // закрыть соединение
            conn.Close();
        }

        private void buttonDeletePN_Click(object sender, EventArgs e)
        {
            try
            {
                string dateTime = DateTime.Now.ToString("yyyyMMdd");
                dateTime = "'" + dateTime + "'";
                string id = dataGridViewPN.CurrentRow.Cells[0].Value.ToString();
                string sqlQuery = "UPDATE History_phone_number SET End_date = " + dateTime + " WHERE PN_Number = " + id + " AND PRS_ID = " + currentIndex + ";";
                // открыть соединение
                conn.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                    tablePN.Clear();
                    adapterPN.Fill(tablePN);
                }
                conn.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Нет выбранного номера телефона");
            }
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridViewCategory.CurrentRow.Cells[0].Value.ToString();
                string sqlQuery = "DELETE FROM Category_person WHERE CTG_Name='" + id + "' AND PRS_ID = '" + currentIndex + "';";
                conn.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                    tableCategory.Clear();
                    adapterCategory.Fill(tableCategory);
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Нет выбранной категории");
            }
        }

        private void buttonDeleteEmail_Click(object sender, EventArgs e)
        {

            try
            {
                string id = dataGridViewEmail.CurrentRow.Cells[0].Value.ToString();
                string sqlQuery = "DELETE FROM Email WHERE Email ='" + id + "' AND PRS_ID = '" + currentIndex + "';";
                conn.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                    tableEmail.Clear();
                    adapterEmail.Fill(tableEmail);
                }
                conn.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Нет выбранного email");
            }
        }

        private void buttonEditEmail_Click(object sender, EventArgs e)
        {
            if (!currentIndex.Equals("-1"))
            {
                try
                {
                    string id = dataGridViewEmail.CurrentRow.Cells[0].Value.ToString();
                    Form3 form3 = new Form3(currentIndex, id);
                    if (form3.ShowDialog() == DialogResult.OK)
                    {
                        tableEmail.Clear();
                        adapterEmail.Fill(tableEmail);
                    }
                }
                catch
                {
                    MessageBox.Show("Нет выбранного Email");
                }
            }
            else
            {
                MessageBox.Show("Сначала сохраните данные о новом Абоненте");
            }
        }

        private void buttonAddEmail_Click(object sender, EventArgs e)
        {
            if (!currentIndex.Equals("-1"))
            {
                Form3 form3 = new Form3(currentIndex);
                if (form3.ShowDialog() == DialogResult.OK)
                {
                    tableEmail.Clear();
                    adapterEmail.Fill(tableEmail);
                }
            }
            else
            {
                MessageBox.Show("Сначала сохраните данные о новом Абоненте");
            }
        }
                

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            if (!currentIndex.Equals("-1"))
            {
                Form6 form6 = new Form6(currentIndex);
                if (form6.ShowDialog() == DialogResult.OK)
                {
                    tableCategory.Clear();
                    adapterCategory.Fill(tableCategory);
                }
            }
            else
            {
                MessageBox.Show("Сначала сохраните данные о новом Абоненте");
            }
        }

        private void buttonEditPN_Click(object sender, EventArgs e)
        {
            if (!currentIndex.Equals("-1"))
            {
                try
                {
                string startDate = "";
                startDate = ((DateTime)dataGridViewPN.CurrentRow.Cells[2].Value).ToString("yyyyMMdd");
                startDate = " '" + startDate + "' ";                
                string id = dataGridViewPN.CurrentRow.Cells[0].Value.ToString();
                Form7 form7 = new Form7(currentIndex, id, startDate);
                if (form7.ShowDialog() == DialogResult.OK)
                {
                    tablePN.Clear();
                    adapterPN.Fill(tablePN);
                }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Нет выбранного телефона");
                }
            }
            else
            {
                MessageBox.Show("Сначала сохраните данные о новом Абоненте");
            }
        }

        private void buttonAddPN_Click(object sender, EventArgs e)
        {
            if (!currentIndex.Equals("-1"))
            {
                Form7 form7 = new Form7(currentIndex);
                if (form7.ShowDialog() == DialogResult.OK)
                {
                    tablePN.Clear();
                    adapterPN.Fill(tablePN);
                }
            }
            else
            {
                MessageBox.Show("Сначала сохраните данные о новом Абоненте");
            }
        }

        private void checkBoxOld_CheckedChanged(object sender, EventArgs e)
        {
            DownloadPN();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
