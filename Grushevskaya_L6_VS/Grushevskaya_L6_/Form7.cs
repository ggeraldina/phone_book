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
    public partial class Form7 : Form
    {
        string connectionStr = "Data Source=(local)" + "\\" + "SQLEXPRESS;Initial Catalog=Grushevskaya_L6_;Integrated Security=SSPI;";
        // объявление соединения с БД
        SqlConnection conn;
        string currentIndexPRS;
        string currentIndexPN;
        string startDate;
        public Form7(string indexPRS = "-1", string indexPN = "-1", string stDate = "NULL")
        {            
            InitializeComponent();
            currentIndexPRS = indexPRS;
            currentIndexPN = indexPN;
            startDate = stDate;
        }


        private void Form7_Load(object sender, EventArgs e)
        {
            // Переключение на русский язык
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));
            // создание объекта подключения
            conn = new SqlConnection(connectionStr);
            // открыть соединение
            conn.Open();
            // Email
            int indexPRS = Int32.Parse(currentIndexPRS);
            if (!currentIndexPN.Equals("-1"))
            {
                DataTable tablePN = new DataTable();
                SqlCommand sqlComPerson = new SqlCommand("SELECT hpn.Start_date, hpn.End_date, hpn.PN_Number, pn.Type FROM History_phone_number hpn JOIN Phone_number pn ON (hpn.PN_number = pn.Number)   WHERE hpn.PN_Number = '" + currentIndexPN + "' AND hpn.PRS_ID = '" + currentIndexPRS + "' AND hpn.Start_date = " + startDate + ";", conn);
                SqlDataReader dr = sqlComPerson.ExecuteReader();
                tablePN.Load(dr);
                dateTimePickerStart.Value = (DateTime) tablePN.Rows[0][0];
                if (tablePN.Rows[0][1].ToString().Equals("NULL"))
                {
                    dateTimePickerEnd.Checked = true;
                    dateTimePickerEnd.Value = (DateTime)tablePN.Rows[0][1];
                }
                else
                {
                    dateTimePickerEnd.Checked = false;
                }
                textBoxPN.Text = tablePN.Rows[0][2].ToString();
                textBoxType.Text = tablePN.Rows[0][3].ToString();
            }
            // закрыть соединение
            conn.Close();
        }

        private void buttonSavePN_Click(object sender, EventArgs e)
        {
            int indexPRS = Int32.Parse(currentIndexPRS);
            string number = textBoxPN.Text;
            string type = textBoxType.Text;
            if (type.Equals(""))
            {
                type = "NULL";
            }
            else
            {
                type = "'" + type + "'";
            }
            bool flagStart = dateTimePickerStart.Checked;
            if (!flagStart)
            {
                MessageBox.Show("Нет даты начала использования. Это обязательное поле!");
                return;
            }
            DateTime dateS = dateTimePickerStart.Value;
            string dateStart = dateS.ToString("yyyyMMdd");
            int dS = Int32.Parse(dateStart);
            dateStart = "'" + dateStart + "'";
            bool flagEnd = dateTimePickerEnd.Checked;
            string dateEnd = "";
            DateTime dateE = new DateTime();
            if (flagEnd)
            {
                dateE = dateTimePickerEnd.Value;
                dateEnd = dateE.ToString("yyyyMMdd");
                int dE = Int32.Parse(dateEnd);
                dateEnd = "'" + dateEnd + "'";
                if (dE < dS)
                {
                    MessageBox.Show("Дата начала использования \nне может быть больше \nдаты окончания использования");
                    return;
                }                
            }
            else
            {
                dateEnd = "NULL";
            }

            if (!currentIndexPN.Equals("-1") && currentIndexPN.Equals(number))
            {
                // открыть соединение
                conn.Open();
                string sqlQuery = "UPDATE History_phone_number SET Start_date = " + dateStart + ", End_date = " + dateEnd + " WHERE  PN_Number = " + currentIndexPN + " AND PRS_ID = " + currentIndexPRS + ";";
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }                
                string sqlQuery1 = "UPDATE Phone_number SET Type = " + type + " WHERE Number = " + currentIndexPN + ";";
                using (SqlCommand command = new SqlCommand(sqlQuery1, conn))
                {
                    //Отправляем команду
                    command.ExecuteNonQuery();
                }
                conn.Close();
                // сохрание прошло успешно
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                // открыть соединение
                conn.Open();
                DataTable tableTemp;
                SqlCommand sqlComTemp;
                SqlDataReader dr;
                tableTemp = new DataTable();
                sqlComTemp = new SqlCommand("SELECT * FROM Phone_number WHERE Number = '" + number + "';", conn);
                dr = sqlComTemp.ExecuteReader();
                try
                {
                    tableTemp.Load(dr);
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Номер может состоять только из цифр");
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                if (tableTemp.Rows.Count == 0)
                {
                    //Создание обьекта команды SQL            
                    string sqlQuery = "INSERT INTO Phone_number (Number, Type) VALUES ('" + number + "'," + type + ");";
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        //Отправляем команду
                        command.ExecuteNonQuery();
                    }
                }
                //Создание обьекта команды SQL            
                string sqlQuery2 = "INSERT INTO History_phone_number (Start_date, End_date, PRS_ID, PN_Number) VALUES (" + dateStart + "," + dateEnd + ",'" + currentIndexPRS + "','" + number + "');";
                using (SqlCommand command = new SqlCommand(sqlQuery2, conn))
                {
                    //Отправляем команду
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Такой номер уже закреплен за абонентом");
                    }
                }
                if (!currentIndexPN.Equals("-1"))
                {
                    string dateTime = DateTime.Now.ToString("yyyyMMdd");
                    dateTime = "'" + dateTime + "'";
                    string sqlQuery = "UPDATE History_phone_number SET Start_date = " + dateStart + ", End_date = " + dateTime + " PN_Number = '" + currentIndexPN + "' PRS_ID = '" + currentIndexPRS + "';";
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        //Отправляем команду
                        command.ExecuteNonQuery();
                    }
                }
                conn.Close();
                // сохрание прошло успешно
                this.DialogResult = DialogResult.OK;
                return;
            }
        }
    }
}
