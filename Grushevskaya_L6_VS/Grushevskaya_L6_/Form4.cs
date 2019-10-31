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
    public partial class Form4 : Form
    {
        string connectionStr = "Data Source=(local)" + "\\" + "SQLEXPRESS;Initial Catalog=Grushevskaya_L6_;Integrated Security=SSPI;";
        // объявление соединения с БД, таблицы Person с данными в памяти и адаптера, связывающего таблицу БД с таблицей в памяти
        SqlConnection conn;
        DataTable tableCategory;
        SqlDataAdapter adapterCategory;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Переключение на русский язык
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

            // Если БД не существует, она будет создана
            conn = new SqlConnection(connectionStr);
            conn.Open();
            // Загрузка данных из таблицы Person в элемент DataTable
            adapterCategory = new SqlDataAdapter("SELECT Name As 'Группа' FROM Category", conn);
            tableCategory = new DataTable();
            adapterCategory.Fill(tableCategory);

            // Автоматическое создание требуемых для обновления таблицы БД
            // команд INSERT, UPDATE, DELETE
            new SqlCommandBuilder(adapterCategory);

            // Привязка элемента DataTable к элементу DataGridView
            dataGridViewCategory.DataSource = tableCategory;
            dataGridViewCategory.Columns[0].MinimumWidth = 290;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridViewCategory.CurrentRow.Cells[0].Value.ToString();
                string sqlQuery = "DELETE FROM Category WHERE Name ='" + id + "'";
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
            catch (NullReferenceException)
            {
                MessageBox.Show("Нет выбранной группы");
            }
        }

        private void buttonEditCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridViewCategory.CurrentRow.Cells[0].Value.ToString();
                Form5 form5 = new Form5(id);
                if (form5.ShowDialog() == DialogResult.OK)
                {
                    tableCategory.Clear();
                    adapterCategory.Fill(tableCategory);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Нет выбранной группы");
            }
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            if (form5.ShowDialog() == DialogResult.OK)
            {
                tableCategory.Clear();
                adapterCategory.Fill(tableCategory);
            }
        }
    }
}
