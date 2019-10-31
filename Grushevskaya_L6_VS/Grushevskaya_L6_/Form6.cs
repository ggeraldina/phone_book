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
    public partial class Form6 : Form
    {
        string connectionStr = "Data Source=(local)" + "\\" + "SQLEXPRESS;Initial Catalog=Grushevskaya_L6_;Integrated Security=SSPI;";
        // объявление соединения с БД
        SqlConnection conn;
        string currentIndexPRS;
        public Form6(string indexPRS ="-1")
        {
            InitializeComponent();
            currentIndexPRS = indexPRS;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Переключение на русский язык
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));
            // создание объекта подключения
            conn = new SqlConnection(connectionStr);
            // открыть соединение
            conn.Open();
            // 
            
            DataTable tableCategory = new DataTable();
            SqlCommand sqlComPerson = new SqlCommand("SELECT * FROM Category;", conn);
            SqlDataReader dr = sqlComPerson.ExecuteReader();
            tableCategory.Load(dr);
            comboBoxCategory.DataSource = tableCategory;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Name";
            comboBoxCategory.SelectedItem = -1;
           
            // закрыть соединение
            conn.Close();
        }

        private void buttonSaveCategory_Click(object sender, EventArgs e)
        {
            string category = "";
            try
            {
                category = comboBoxCategory.SelectedValue.ToString();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Список пуст. Ничего не выбрано");
                this.DialogResult = DialogResult.OK;
                return;
            }         
            // открыть соединение
            conn.Open();
            //Создание обьекта команды SQL            
            string sqlQuery = "INSERT INTO Category_Person (PRS_ID, CTG_Name) VALUES ('" + currentIndexPRS +"','"+ category + "');";
            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                try{
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Такая группа уже закреплена за абонентом");
                }
            }
            conn.Close();
            // сохрание прошло успешно
            this.DialogResult = DialogResult.OK;
            return;
            
        }
    }
}
