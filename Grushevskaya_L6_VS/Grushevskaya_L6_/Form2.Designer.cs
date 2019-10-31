namespace Grushevskaya_L6_
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label last_nameLabel;
            System.Windows.Forms.Label first_nameLabel;
            System.Windows.Forms.Label patronymicLabel;
            System.Windows.Forms.Label iSQLabel;
            System.Windows.Forms.Label vKLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label12;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewCategory = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewPN = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewEmail = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSavePerson = new System.Windows.Forms.Button();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.textBoxIsq = new System.Windows.Forms.TextBox();
            this.textBoxVk = new System.Windows.Forms.TextBox();
            this.buttonDeletePN = new System.Windows.Forms.Button();
            this.buttonAddPN = new System.Windows.Forms.Button();
            this.buttonEditPN = new System.Windows.Forms.Button();
            this.buttonDeleteCategory = new System.Windows.Forms.Button();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.buttonDeleteEmail = new System.Windows.Forms.Button();
            this.buttonAddEmail = new System.Windows.Forms.Button();
            this.buttonEditEmail = new System.Windows.Forms.Button();
            this.textBoxNH = new System.Windows.Forms.TextBox();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.textBoxApartment = new System.Windows.Forms.TextBox();
            this.checkBoxOld = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            last_nameLabel = new System.Windows.Forms.Label();
            first_nameLabel = new System.Windows.Forms.Label();
            patronymicLabel = new System.Windows.Forms.Label();
            iSQLabel = new System.Windows.Forms.Label();
            vKLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // last_nameLabel
            // 
            last_nameLabel.AutoSize = true;
            last_nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            last_nameLabel.Location = new System.Drawing.Point(63, 60);
            last_nameLabel.Name = "last_nameLabel";
            last_nameLabel.Size = new System.Drawing.Size(77, 18);
            last_nameLabel.TabIndex = 3;
            last_nameLabel.Text = "Фамилия:";
            // 
            // first_nameLabel
            // 
            first_nameLabel.AutoSize = true;
            first_nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            first_nameLabel.Location = new System.Drawing.Point(63, 88);
            first_nameLabel.Name = "first_nameLabel";
            first_nameLabel.Size = new System.Drawing.Size(42, 18);
            first_nameLabel.TabIndex = 5;
            first_nameLabel.Text = "Имя:";
            // 
            // patronymicLabel
            // 
            patronymicLabel.AutoSize = true;
            patronymicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            patronymicLabel.Location = new System.Drawing.Point(63, 116);
            patronymicLabel.Name = "patronymicLabel";
            patronymicLabel.Size = new System.Drawing.Size(79, 18);
            patronymicLabel.TabIndex = 7;
            patronymicLabel.Text = "Отчество:";
            // 
            // iSQLabel
            // 
            iSQLabel.AutoSize = true;
            iSQLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            iSQLabel.Location = new System.Drawing.Point(468, 329);
            iSQLabel.Name = "iSQLabel";
            iSQLabel.Size = new System.Drawing.Size(37, 18);
            iSQLabel.TabIndex = 9;
            iSQLabel.Text = "ISQ:";
            // 
            // vKLabel
            // 
            vKLabel.AutoSize = true;
            vKLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            vKLabel.Location = new System.Drawing.Point(468, 357);
            vKLabel.Name = "vKLabel";
            vKLabel.Size = new System.Drawing.Size(31, 18);
            vKLabel.TabIndex = 11;
            vKLabel.Text = "VK:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            label1.Location = new System.Drawing.Point(63, 229);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 18);
            label1.TabIndex = 13;
            label1.Text = "Город:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            label2.Location = new System.Drawing.Point(63, 199);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 18);
            label2.TabIndex = 15;
            label2.Text = "Страна:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            label9.Location = new System.Drawing.Point(63, 258);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(55, 18);
            label9.TabIndex = 47;
            label9.Text = "Улица:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            label10.Location = new System.Drawing.Point(63, 286);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(44, 18);
            label10.TabIndex = 48;
            label10.Text = "Дом:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            label12.Location = new System.Drawing.Point(63, 316);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(77, 18);
            label12.TabIndex = 52;
            label12.Text = "Квартира:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(66, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Абонент";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(149, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Адрес";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(468, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Контактные данные";
            // 
            // dataGridViewCategory
            // 
            this.dataGridViewCategory.AllowUserToAddRows = false;
            this.dataGridViewCategory.AllowUserToDeleteRows = false;
            this.dataGridViewCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategory.Location = new System.Drawing.Point(69, 415);
            this.dataGridViewCategory.Name = "dataGridViewCategory";
            this.dataGridViewCategory.ReadOnly = true;
            this.dataGridViewCategory.RowTemplate.Height = 24;
            this.dataGridViewCategory.Size = new System.Drawing.Size(363, 150);
            this.dataGridViewCategory.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(149, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Группы абонента";
            // 
            // dataGridViewPN
            // 
            this.dataGridViewPN.AllowUserToAddRows = false;
            this.dataGridViewPN.AllowUserToDeleteRows = false;
            this.dataGridViewPN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPN.Location = new System.Drawing.Point(472, 112);
            this.dataGridViewPN.Name = "dataGridViewPN";
            this.dataGridViewPN.ReadOnly = true;
            this.dataGridViewPN.RowTemplate.Height = 24;
            this.dataGridViewPN.Size = new System.Drawing.Size(356, 150);
            this.dataGridViewPN.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(552, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Номера телефонов";
            // 
            // dataGridViewEmail
            // 
            this.dataGridViewEmail.AllowUserToAddRows = false;
            this.dataGridViewEmail.AllowUserToDeleteRows = false;
            this.dataGridViewEmail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmail.Location = new System.Drawing.Point(472, 415);
            this.dataGridViewEmail.Name = "dataGridViewEmail";
            this.dataGridViewEmail.ReadOnly = true;
            this.dataGridViewEmail.RowTemplate.Height = 24;
            this.dataGridViewEmail.Size = new System.Drawing.Size(356, 150);
            this.dataGridViewEmail.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(555, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "Email";
            // 
            // buttonSavePerson
            // 
            this.buttonSavePerson.Location = new System.Drawing.Point(544, 644);
            this.buttonSavePerson.Name = "buttonSavePerson";
            this.buttonSavePerson.Size = new System.Drawing.Size(137, 35);
            this.buttonSavePerson.TabIndex = 10;
            this.buttonSavePerson.Text = "Сохранить";
            this.buttonSavePerson.UseVisualStyleBackColor = true;
            this.buttonSavePerson.Click += new System.EventHandler(this.buttonSavePerson_Click);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxLastName.Location = new System.Drawing.Point(161, 57);
            this.textBoxLastName.MaxLength = 50;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(271, 23);
            this.textBoxLastName.TabIndex = 0;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxFirstName.Location = new System.Drawing.Point(161, 87);
            this.textBoxFirstName.MaxLength = 50;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(271, 23);
            this.textBoxFirstName.TabIndex = 1;
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxPatronymic.Location = new System.Drawing.Point(161, 117);
            this.textBoxPatronymic.MaxLength = 50;
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(271, 23);
            this.textBoxPatronymic.TabIndex = 2;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxCity.Location = new System.Drawing.Point(161, 225);
            this.textBoxCity.MaxLength = 100;
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(271, 23);
            this.textBoxCity.TabIndex = 4;
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxCountry.Location = new System.Drawing.Point(161, 196);
            this.textBoxCountry.MaxLength = 50;
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(271, 23);
            this.textBoxCountry.TabIndex = 3;
            // 
            // textBoxIsq
            // 
            this.textBoxIsq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxIsq.Location = new System.Drawing.Point(558, 324);
            this.textBoxIsq.MaxLength = 50;
            this.textBoxIsq.Name = "textBoxIsq";
            this.textBoxIsq.Size = new System.Drawing.Size(271, 23);
            this.textBoxIsq.TabIndex = 8;
            // 
            // textBoxVk
            // 
            this.textBoxVk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxVk.Location = new System.Drawing.Point(558, 355);
            this.textBoxVk.MaxLength = 100;
            this.textBoxVk.Name = "textBoxVk";
            this.textBoxVk.Size = new System.Drawing.Size(271, 23);
            this.textBoxVk.TabIndex = 9;
            // 
            // buttonDeletePN
            // 
            this.buttonDeletePN.Location = new System.Drawing.Point(551, 273);
            this.buttonDeletePN.Name = "buttonDeletePN";
            this.buttonDeletePN.Size = new System.Drawing.Size(73, 35);
            this.buttonDeletePN.TabIndex = 16;
            this.buttonDeletePN.Text = "Удалить";
            this.buttonDeletePN.UseVisualStyleBackColor = true;
            this.buttonDeletePN.Click += new System.EventHandler(this.buttonDeletePN_Click);
            // 
            // buttonAddPN
            // 
            this.buttonAddPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.buttonAddPN.Location = new System.Drawing.Point(749, 273);
            this.buttonAddPN.Name = "buttonAddPN";
            this.buttonAddPN.Size = new System.Drawing.Size(79, 35);
            this.buttonAddPN.TabIndex = 18;
            this.buttonAddPN.Text = "Добавить";
            this.buttonAddPN.UseVisualStyleBackColor = true;
            this.buttonAddPN.Click += new System.EventHandler(this.buttonAddPN_Click);
            // 
            // buttonEditPN
            // 
            this.buttonEditPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.buttonEditPN.Location = new System.Drawing.Point(628, 273);
            this.buttonEditPN.Name = "buttonEditPN";
            this.buttonEditPN.Size = new System.Drawing.Size(117, 35);
            this.buttonEditPN.TabIndex = 17;
            this.buttonEditPN.Text = "Редактировать";
            this.buttonEditPN.UseVisualStyleBackColor = true;
            this.buttonEditPN.Click += new System.EventHandler(this.buttonEditPN_Click);
            // 
            // buttonDeleteCategory
            // 
            this.buttonDeleteCategory.Location = new System.Drawing.Point(275, 577);
            this.buttonDeleteCategory.Name = "buttonDeleteCategory";
            this.buttonDeleteCategory.Size = new System.Drawing.Size(73, 35);
            this.buttonDeleteCategory.TabIndex = 12;
            this.buttonDeleteCategory.Text = "Удалить";
            this.buttonDeleteCategory.UseVisualStyleBackColor = true;
            this.buttonDeleteCategory.Click += new System.EventHandler(this.buttonDeleteCategory_Click);
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.buttonAddCategory.Location = new System.Drawing.Point(353, 577);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(79, 35);
            this.buttonAddCategory.TabIndex = 13;
            this.buttonAddCategory.Text = "Добавить";
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
            // 
            // buttonDeleteEmail
            // 
            this.buttonDeleteEmail.Location = new System.Drawing.Point(552, 576);
            this.buttonDeleteEmail.Name = "buttonDeleteEmail";
            this.buttonDeleteEmail.Size = new System.Drawing.Size(73, 35);
            this.buttonDeleteEmail.TabIndex = 20;
            this.buttonDeleteEmail.Text = "Удалить";
            this.buttonDeleteEmail.UseVisualStyleBackColor = true;
            this.buttonDeleteEmail.Click += new System.EventHandler(this.buttonDeleteEmail_Click);
            // 
            // buttonAddEmail
            // 
            this.buttonAddEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.buttonAddEmail.Location = new System.Drawing.Point(750, 576);
            this.buttonAddEmail.Name = "buttonAddEmail";
            this.buttonAddEmail.Size = new System.Drawing.Size(79, 35);
            this.buttonAddEmail.TabIndex = 22;
            this.buttonAddEmail.Text = "Добавить";
            this.buttonAddEmail.UseVisualStyleBackColor = true;
            this.buttonAddEmail.Click += new System.EventHandler(this.buttonAddEmail_Click);
            // 
            // buttonEditEmail
            // 
            this.buttonEditEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.buttonEditEmail.Location = new System.Drawing.Point(629, 576);
            this.buttonEditEmail.Name = "buttonEditEmail";
            this.buttonEditEmail.Size = new System.Drawing.Size(117, 35);
            this.buttonEditEmail.TabIndex = 21;
            this.buttonEditEmail.Text = "Редактировать";
            this.buttonEditEmail.UseVisualStyleBackColor = true;
            this.buttonEditEmail.Click += new System.EventHandler(this.buttonEditEmail_Click);
            // 
            // textBoxNH
            // 
            this.textBoxNH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxNH.Location = new System.Drawing.Point(161, 283);
            this.textBoxNH.MaxLength = 10;
            this.textBoxNH.Name = "textBoxNH";
            this.textBoxNH.Size = new System.Drawing.Size(271, 23);
            this.textBoxNH.TabIndex = 6;
            // 
            // textBoxStreet
            // 
            this.textBoxStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxStreet.Location = new System.Drawing.Point(161, 254);
            this.textBoxStreet.MaxLength = 100;
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.Size = new System.Drawing.Size(271, 23);
            this.textBoxStreet.TabIndex = 5;
            // 
            // textBoxApartment
            // 
            this.textBoxApartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBoxApartment.Location = new System.Drawing.Point(161, 313);
            this.textBoxApartment.MaxLength = 10;
            this.textBoxApartment.Name = "textBoxApartment";
            this.textBoxApartment.Size = new System.Drawing.Size(271, 23);
            this.textBoxApartment.TabIndex = 7;
            // 
            // checkBoxOld
            // 
            this.checkBoxOld.AutoSize = true;
            this.checkBoxOld.Location = new System.Drawing.Point(471, 84);
            this.checkBoxOld.Name = "checkBoxOld";
            this.checkBoxOld.Size = new System.Drawing.Size(170, 21);
            this.checkBoxOld.TabIndex = 14;
            this.checkBoxOld.Text = "показать со старыми";
            this.checkBoxOld.UseVisualStyleBackColor = true;
            this.checkBoxOld.CheckedChanged += new System.EventHandler(this.checkBoxOld_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 644);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 35);
            this.button1.TabIndex = 23;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 703);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxOld);
            this.Controls.Add(this.textBoxApartment);
            this.Controls.Add(label12);
            this.Controls.Add(this.textBoxNH);
            this.Controls.Add(this.textBoxStreet);
            this.Controls.Add(label9);
            this.Controls.Add(label10);
            this.Controls.Add(this.buttonDeleteEmail);
            this.Controls.Add(this.buttonAddEmail);
            this.Controls.Add(this.buttonEditEmail);
            this.Controls.Add(this.buttonDeleteCategory);
            this.Controls.Add(this.buttonAddCategory);
            this.Controls.Add(this.buttonDeletePN);
            this.Controls.Add(this.buttonAddPN);
            this.Controls.Add(this.buttonEditPN);
            this.Controls.Add(this.textBoxVk);
            this.Controls.Add(this.textBoxIsq);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.buttonSavePerson);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridViewEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridViewPN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridViewCategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(last_nameLabel);
            this.Controls.Add(first_nameLabel);
            this.Controls.Add(patronymicLabel);
            this.Controls.Add(iSQLabel);
            this.Controls.Add(vKLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(886, 748);
            this.MinimumSize = new System.Drawing.Size(886, 748);
            this.Name = "Form2";
            this.Text = "Карточка абонента";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewPN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSavePerson;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.TextBox textBoxIsq;
        private System.Windows.Forms.TextBox textBoxVk;
        private System.Windows.Forms.Button buttonDeletePN;
        private System.Windows.Forms.Button buttonAddPN;
        private System.Windows.Forms.Button buttonEditPN;
        private System.Windows.Forms.Button buttonDeleteCategory;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.Button buttonDeleteEmail;
        private System.Windows.Forms.Button buttonAddEmail;
        private System.Windows.Forms.Button buttonEditEmail;
        private System.Windows.Forms.TextBox textBoxNH;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.TextBox textBoxApartment;
        private System.Windows.Forms.CheckBox checkBoxOld;
        private System.Windows.Forms.Button button1;
    }
}