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
    public partial class Form3 : Form
    {

        string connectionStr = "Data Source=(local)" + "\\" + "SQLEXPRESS;Initial Catalog=Grushevskaya_L6_;Integrated Security=SSPI;";
        // объявление соединения с БД
        SqlConnection conn;
        string currentIndexPRS;
        string currentIndexEmail;

        public Form3(string indexPRS = "-1", string indexEmail = "-1")
        {            
            InitializeComponent();
            currentIndexPRS = indexPRS;
            currentIndexEmail = indexEmail;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Переключение на русский язык
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));
            // создание объекта подключения
            conn = new SqlConnection(connectionStr);
            // открыть соединение
            conn.Open();
            // Email
            int indexPRS = Int32.Parse(currentIndexPRS);
            if (indexPRS > 0 && !currentIndexEmail.Equals("-1"))
            {
                DataTable tablePerson = new DataTable();
                SqlCommand sqlComPerson = new SqlCommand("SELECT * FROM Email WHERE Email = '" + currentIndexEmail + "' AND PRS_ID = '" + currentIndexPRS + "';", conn);
                SqlDataReader dr = sqlComPerson.ExecuteReader();
                tablePerson.Load(dr);
                textBoxEmail.Text = tablePerson.Rows[0][0].ToString();
                textBoxType.Text = tablePerson.Rows[0][1].ToString(); 
            }
            // закрыть соединение
            conn.Close();

        }

        private void buttonSaveEmail_Click(object sender, EventArgs e)
        {
            int indexPRS = Int32.Parse(currentIndexPRS);
            string email = textBoxEmail.Text;
            string type = textBoxType.Text;


            if (indexPRS > 0 && !currentIndexEmail.Equals("-1"))
            {
                string sqlQuery = "UPDATE Email SET Email = '"+ email+"', Type = '" + type + "'  WHERE Email = '" + currentIndexEmail + "' AND PRS_ID = '" + currentIndexPRS + "';";
                // открыть соединение
                conn.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    try{
                    //Отправляем команду
                    command.ExecuteNonQuery();
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Такой Email уже закреплен за абонентом");
                    }
                }
                conn.Close();
                currentIndexEmail = email;
                // сохрание прошло успешно
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                // открыть соединение
                conn.Open();
                //Создание обьекта команды SQL            
                string sqlQuery = "INSERT INTO Email (Email, Type, PRS_ID) VALUES ('" + email + "','" + type + "','" + indexPRS + "');";
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    try{
                        //Отправляем команду
                        command.ExecuteNonQuery();
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Такой Email уже закреплен за абонентом");
                    }
                }
                // текущий индекс
                DataTable table = new DataTable();
                SqlCommand sqlComPerson = new SqlCommand("SELECT * FROM Email", conn);
                SqlDataReader dr1 = sqlComPerson.ExecuteReader();
                table.Load(dr1);
                int count = table.Rows.Count;
                currentIndexEmail = table.Rows[count - 1][0].ToString();
                conn.Close();
                // сохрание прошло успешно
                this.DialogResult = DialogResult.OK;
                return;
            }

        }
    }
}
