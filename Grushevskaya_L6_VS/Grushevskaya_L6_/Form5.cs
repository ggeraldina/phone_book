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
    public partial class Form5 : Form
    {
        string connectionStr = "Data Source=(local)" + "\\" + "SQLEXPRESS;Initial Catalog=Grushevskaya_L6_;Integrated Security=SSPI;";
        // объявление соединения с БД
        SqlConnection conn;
        string currentIndex;
        public Form5(string index = "-1")
        {
           InitializeComponent();
           currentIndex = index;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Переключение на русский язык
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));
            // создание объекта подключения
            conn = new SqlConnection(connectionStr);
            // открыть соединение
            conn.Open();
            // Email
            if (!currentIndex.Equals("-1"))
            {
                DataTable tablePerson = new DataTable();
                SqlCommand sqlComPerson = new SqlCommand("SELECT * FROM Category WHERE Name =  '" + currentIndex + "';", conn);
                SqlDataReader dr = sqlComPerson.ExecuteReader();
                tablePerson.Load(dr);
                textBoxCategory.Text = tablePerson.Rows[0][0].ToString();
            }
            // закрыть соединение
            conn.Close();
        }

        private void buttonSaveCategory_Click(object sender, EventArgs e)
        {
            string category = textBoxCategory.Text;
            if (!currentIndex.Equals("-1"))
            {
                string sqlQuery = "UPDATE Category SET Name = '" + category + "'  WHERE  Name =  '" + currentIndex + "';";
                // открыть соединение
                conn.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }
                conn.Close();
                currentIndex = category;
                // сохрание прошло успешно
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                // открыть соединение
                conn.Open();
                //Создание обьекта команды SQL            
                string sqlQuery = "INSERT INTO Category (Name) VALUES ('" +category + "');";
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }
                // текущий индекс
                currentIndex = category;
                conn.Close();
                // сохрание прошло успешно
                this.DialogResult = DialogResult.OK;
                return;
            }
        }
    }
}
