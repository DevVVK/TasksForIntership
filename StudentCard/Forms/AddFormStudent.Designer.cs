namespace StudentCard.Forms
{
    partial class AddFormStudent
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
            this.components = new System.ComponentModel.Container();
            this.StudentGroupBox = new System.Windows.Forms.GroupBox();
            this.PatronimycNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.PatronymicNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.CurriculumGroupBox = new System.Windows.Forms.GroupBox();
            this.CourseComboBox = new System.Windows.Forms.ComboBox();
            this.GroupTextBox = new System.Windows.Forms.TextBox();
            this.SpecialityTextBox = new System.Windows.Forms.TextBox();
            this.FacultyTextBox = new System.Windows.Forms.TextBox();
            this.GroupLabel = new System.Windows.Forms.Label();
            this.CourseLabel = new System.Windows.Forms.Label();
            this.SpecialityLabel = new System.Windows.Forms.Label();
            this.FacultyLabel = new System.Windows.Forms.Label();
            this.AdresTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DeleteRowAdressButton = new System.Windows.Forms.Button();
            this.AddRowAdressButton = new System.Windows.Forms.Button();
            this.UpdateRowAdressButton = new System.Windows.Forms.Button();
            this.AdressAdvancedDataGridView = new ADGV.AdvancedDataGridView();
            this.ContactPage = new System.Windows.Forms.TabPage();
            this.ActionsContactsGroupBox = new System.Windows.Forms.GroupBox();
            this.DeleteRowContactButton = new System.Windows.Forms.Button();
            this.AddRowContactButton = new System.Windows.Forms.Button();
            this.UpdateRowContactButton = new System.Windows.Forms.Button();
            this.ContactsDataAdvancedDataGridView = new ADGV.AdvancedDataGridView();
            this.DataStudentTabControl = new System.Windows.Forms.TabControl();
            this.ContactbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AdressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ValidatingToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StudentGroupBox.SuspendLayout();
            this.CurriculumGroupBox.SuspendLayout();
            this.AdresTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdressAdvancedDataGridView)).BeginInit();
            this.ContactPage.SuspendLayout();
            this.ActionsContactsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContactsDataAdvancedDataGridView)).BeginInit();
            this.DataStudentTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContactbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdressBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentGroupBox
            // 
            this.StudentGroupBox.Controls.Add(this.PatronimycNameLabel);
            this.StudentGroupBox.Controls.Add(this.LastNameLabel);
            this.StudentGroupBox.Controls.Add(this.FirstNameLabel);
            this.StudentGroupBox.Controls.Add(this.LastNameTextBox);
            this.StudentGroupBox.Controls.Add(this.PatronymicNameTextBox);
            this.StudentGroupBox.Controls.Add(this.FirstNameTextBox);
            this.StudentGroupBox.Location = new System.Drawing.Point(3, 10);
            this.StudentGroupBox.Name = "StudentGroupBox";
            this.StudentGroupBox.Size = new System.Drawing.Size(254, 97);
            this.StudentGroupBox.TabIndex = 20;
            this.StudentGroupBox.TabStop = false;
            this.StudentGroupBox.Text = "ФИО";
            // 
            // PatronimycNameLabel
            // 
            this.PatronimycNameLabel.AutoSize = true;
            this.PatronimycNameLabel.Location = new System.Drawing.Point(11, 69);
            this.PatronimycNameLabel.Name = "PatronimycNameLabel";
            this.PatronimycNameLabel.Size = new System.Drawing.Size(54, 13);
            this.PatronimycNameLabel.TabIndex = 5;
            this.PatronimycNameLabel.Text = "Отчество";
            this.ValidatingToolTip.SetToolTip(this.PatronimycNameLabel, "Это поле должно быть заполнено");
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(9, 17);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(56, 13);
            this.LastNameLabel.TabIndex = 4;
            this.LastNameLabel.Text = "Фамилия";
            this.ValidatingToolTip.SetToolTip(this.LastNameLabel, "Это поле должно быть заполнено");
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(36, 43);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(29, 13);
            this.FirstNameLabel.TabIndex = 3;
            this.FirstNameLabel.Text = "Имя";
            this.ValidatingToolTip.SetToolTip(this.FirstNameLabel, "Это поле должно быть заполнено");
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(71, 14);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(177, 20);
            this.LastNameTextBox.TabIndex = 2;
            this.LastNameTextBox.TextChanged += new System.EventHandler(this.LastNameTextBox_TextChanged);
            this.LastNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LastNameTextBox_KeyPress);
            this.LastNameTextBox.Leave += new System.EventHandler(this.LastNameTextBox_Leave);
            // 
            // PatronymicNameTextBox
            // 
            this.PatronymicNameTextBox.Location = new System.Drawing.Point(71, 66);
            this.PatronymicNameTextBox.Name = "PatronymicNameTextBox";
            this.PatronymicNameTextBox.Size = new System.Drawing.Size(177, 20);
            this.PatronymicNameTextBox.TabIndex = 1;
            this.PatronymicNameTextBox.TextChanged += new System.EventHandler(this.PatronymicNameTextBox_TextChanged);
            this.PatronymicNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatronymicNameTextBox_KeyPress);
            this.PatronymicNameTextBox.Leave += new System.EventHandler(this.PatronymicNameTextBox_Leave);
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(71, 40);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(177, 20);
            this.FirstNameTextBox.TabIndex = 0;
            this.FirstNameTextBox.TextChanged += new System.EventHandler(this.FirstNameTextBox_TextChanged);
            this.FirstNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FirstNameTextBox_KeyPress);
            this.FirstNameTextBox.Leave += new System.EventHandler(this.FirstNameTextBox_Leave);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(604, 421);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Отмена";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(523, 421);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Сохранить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CurriculumGroupBox
            // 
            this.CurriculumGroupBox.Controls.Add(this.CourseComboBox);
            this.CurriculumGroupBox.Controls.Add(this.GroupTextBox);
            this.CurriculumGroupBox.Controls.Add(this.SpecialityTextBox);
            this.CurriculumGroupBox.Controls.Add(this.FacultyTextBox);
            this.CurriculumGroupBox.Controls.Add(this.GroupLabel);
            this.CurriculumGroupBox.Controls.Add(this.CourseLabel);
            this.CurriculumGroupBox.Controls.Add(this.SpecialityLabel);
            this.CurriculumGroupBox.Controls.Add(this.FacultyLabel);
            this.CurriculumGroupBox.Location = new System.Drawing.Point(269, 10);
            this.CurriculumGroupBox.Name = "CurriculumGroupBox";
            this.CurriculumGroupBox.Size = new System.Drawing.Size(401, 126);
            this.CurriculumGroupBox.TabIndex = 22;
            this.CurriculumGroupBox.TabStop = false;
            this.CurriculumGroupBox.Text = "Учебное заведение";
            // 
            // CourseComboBox
            // 
            this.CourseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CourseComboBox.FormattingEnabled = true;
            this.CourseComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.CourseComboBox.Location = new System.Drawing.Point(101, 92);
            this.CourseComboBox.Name = "CourseComboBox";
            this.CourseComboBox.Size = new System.Drawing.Size(51, 21);
            this.CourseComboBox.TabIndex = 8;
            this.CourseComboBox.TextChanged += new System.EventHandler(this.CourseComboBox_TextChanged);
            // 
            // GroupTextBox
            // 
            this.GroupTextBox.Location = new System.Drawing.Point(101, 66);
            this.GroupTextBox.Name = "GroupTextBox";
            this.GroupTextBox.Size = new System.Drawing.Size(51, 20);
            this.GroupTextBox.TabIndex = 7;
            this.GroupTextBox.TextChanged += new System.EventHandler(this.GroupTextBox_TextChanged);
            this.GroupTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GroupTextBox_KeyPress);
            // 
            // SpecialityTextBox
            // 
            this.SpecialityTextBox.Location = new System.Drawing.Point(101, 40);
            this.SpecialityTextBox.Name = "SpecialityTextBox";
            this.SpecialityTextBox.Size = new System.Drawing.Size(278, 20);
            this.SpecialityTextBox.TabIndex = 5;
            this.SpecialityTextBox.TextChanged += new System.EventHandler(this.SpecialityTextBox_TextChanged);
            this.SpecialityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpecialityTextBox_KeyPress);
            this.SpecialityTextBox.Leave += new System.EventHandler(this.SpecialityTextBox_Leave);
            // 
            // FacultyTextBox
            // 
            this.FacultyTextBox.Location = new System.Drawing.Point(101, 14);
            this.FacultyTextBox.Name = "FacultyTextBox";
            this.FacultyTextBox.Size = new System.Drawing.Size(278, 20);
            this.FacultyTextBox.TabIndex = 4;
            this.FacultyTextBox.TextChanged += new System.EventHandler(this.FacultyTextBox_TextChanged);
            this.FacultyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FacultyTextBox_KeyPress);
            this.FacultyTextBox.Leave += new System.EventHandler(this.FacultyTextBox_Leave);
            // 
            // GroupLabel
            // 
            this.GroupLabel.AutoSize = true;
            this.GroupLabel.Location = new System.Drawing.Point(53, 69);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(42, 13);
            this.GroupLabel.TabIndex = 3;
            this.GroupLabel.Text = "Группа";
            this.ValidatingToolTip.SetToolTip(this.GroupLabel, "Это поле должно быть заполнено");
            // 
            // CourseLabel
            // 
            this.CourseLabel.AutoSize = true;
            this.CourseLabel.Location = new System.Drawing.Point(64, 95);
            this.CourseLabel.Name = "CourseLabel";
            this.CourseLabel.Size = new System.Drawing.Size(31, 13);
            this.CourseLabel.TabIndex = 2;
            this.CourseLabel.Text = "Курс";
            // 
            // SpecialityLabel
            // 
            this.SpecialityLabel.AutoSize = true;
            this.SpecialityLabel.Location = new System.Drawing.Point(10, 43);
            this.SpecialityLabel.Name = "SpecialityLabel";
            this.SpecialityLabel.Size = new System.Drawing.Size(85, 13);
            this.SpecialityLabel.TabIndex = 1;
            this.SpecialityLabel.Text = "Специальность";
            this.ValidatingToolTip.SetToolTip(this.SpecialityLabel, "Это поле должно быть заполнено");
            // 
            // FacultyLabel
            // 
            this.FacultyLabel.AutoSize = true;
            this.FacultyLabel.Location = new System.Drawing.Point(32, 17);
            this.FacultyLabel.Name = "FacultyLabel";
            this.FacultyLabel.Size = new System.Drawing.Size(63, 13);
            this.FacultyLabel.TabIndex = 0;
            this.FacultyLabel.Text = "Факультет";
            this.ValidatingToolTip.SetToolTip(this.FacultyLabel, "Это поле должно быть заполнено");
            // 
            // AdresTabPage
            // 
            this.AdresTabPage.Controls.Add(this.groupBox3);
            this.AdresTabPage.Controls.Add(this.AdressAdvancedDataGridView);
            this.AdresTabPage.Location = new System.Drawing.Point(4, 22);
            this.AdresTabPage.Name = "AdresTabPage";
            this.AdresTabPage.Size = new System.Drawing.Size(670, 247);
            this.AdresTabPage.TabIndex = 3;
            this.AdresTabPage.Text = "Адреса";
            this.AdresTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DeleteRowAdressButton);
            this.groupBox3.Controls.Add(this.AddRowAdressButton);
            this.groupBox3.Controls.Add(this.UpdateRowAdressButton);
            this.groupBox3.Location = new System.Drawing.Point(6, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 54);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Действия";
            // 
            // DeleteRowAdressButton
            // 
            this.DeleteRowAdressButton.Location = new System.Drawing.Point(221, 21);
            this.DeleteRowAdressButton.Name = "DeleteRowAdressButton";
            this.DeleteRowAdressButton.Size = new System.Drawing.Size(100, 21);
            this.DeleteRowAdressButton.TabIndex = 14;
            this.DeleteRowAdressButton.Text = "Удалить";
            this.DeleteRowAdressButton.UseVisualStyleBackColor = true;
            this.DeleteRowAdressButton.Click += new System.EventHandler(this.DeleteRowAdressButton_Click);
            // 
            // AddRowAdressButton
            // 
            this.AddRowAdressButton.Location = new System.Drawing.Point(8, 21);
            this.AddRowAdressButton.Name = "AddRowAdressButton";
            this.AddRowAdressButton.Size = new System.Drawing.Size(100, 21);
            this.AddRowAdressButton.TabIndex = 13;
            this.AddRowAdressButton.Text = "Добавить";
            this.AddRowAdressButton.UseVisualStyleBackColor = true;
            this.AddRowAdressButton.Click += new System.EventHandler(this.AddRowAdressButton_Click);
            // 
            // UpdateRowAdressButton
            // 
            this.UpdateRowAdressButton.Location = new System.Drawing.Point(115, 21);
            this.UpdateRowAdressButton.Name = "UpdateRowAdressButton";
            this.UpdateRowAdressButton.Size = new System.Drawing.Size(100, 21);
            this.UpdateRowAdressButton.TabIndex = 3;
            this.UpdateRowAdressButton.Text = "Редактировать";
            this.UpdateRowAdressButton.UseVisualStyleBackColor = true;
            this.UpdateRowAdressButton.Click += new System.EventHandler(this.UpdateRowAdressButton_Click);
            // 
            // AdressAdvancedDataGridView
            // 
            this.AdressAdvancedDataGridView.AllowUserToAddRows = false;
            this.AdressAdvancedDataGridView.AllowUserToDeleteRows = false;
            this.AdressAdvancedDataGridView.AllowUserToOrderColumns = true;
            this.AdressAdvancedDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AdressAdvancedDataGridView.AutoGenerateContextFilters = true;
            this.AdressAdvancedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AdressAdvancedDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AdressAdvancedDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AdressAdvancedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdressAdvancedDataGridView.DateWithTime = false;
            this.AdressAdvancedDataGridView.Location = new System.Drawing.Point(6, 60);
            this.AdressAdvancedDataGridView.Name = "AdressAdvancedDataGridView";
            this.AdressAdvancedDataGridView.ReadOnly = true;
            this.AdressAdvancedDataGridView.Size = new System.Drawing.Size(657, 184);
            this.AdressAdvancedDataGridView.TabIndex = 20;
            this.AdressAdvancedDataGridView.TimeFilter = false;
            this.AdressAdvancedDataGridView.DoubleClick += new System.EventHandler(this.AdressAdvancedDataGridView_DoubleClick);
            this.AdressAdvancedDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AdressAdvancedDataGridView_KeyDown);
            // 
            // ContactPage
            // 
            this.ContactPage.Controls.Add(this.ActionsContactsGroupBox);
            this.ContactPage.Controls.Add(this.ContactsDataAdvancedDataGridView);
            this.ContactPage.Location = new System.Drawing.Point(4, 22);
            this.ContactPage.Name = "ContactPage";
            this.ContactPage.Padding = new System.Windows.Forms.Padding(3);
            this.ContactPage.Size = new System.Drawing.Size(670, 247);
            this.ContactPage.TabIndex = 0;
            this.ContactPage.Text = "Контактные данные";
            this.ContactPage.UseVisualStyleBackColor = true;
            // 
            // ActionsContactsGroupBox
            // 
            this.ActionsContactsGroupBox.Controls.Add(this.DeleteRowContactButton);
            this.ActionsContactsGroupBox.Controls.Add(this.AddRowContactButton);
            this.ActionsContactsGroupBox.Controls.Add(this.UpdateRowContactButton);
            this.ActionsContactsGroupBox.Location = new System.Drawing.Point(6, 0);
            this.ActionsContactsGroupBox.Name = "ActionsContactsGroupBox";
            this.ActionsContactsGroupBox.Size = new System.Drawing.Size(327, 54);
            this.ActionsContactsGroupBox.TabIndex = 17;
            this.ActionsContactsGroupBox.TabStop = false;
            this.ActionsContactsGroupBox.Text = "Действия";
            // 
            // DeleteRowContactButton
            // 
            this.DeleteRowContactButton.Location = new System.Drawing.Point(221, 21);
            this.DeleteRowContactButton.Name = "DeleteRowContactButton";
            this.DeleteRowContactButton.Size = new System.Drawing.Size(100, 21);
            this.DeleteRowContactButton.TabIndex = 14;
            this.DeleteRowContactButton.Text = "Удалить";
            this.DeleteRowContactButton.UseVisualStyleBackColor = true;
            this.DeleteRowContactButton.Click += new System.EventHandler(this.DeleteRowContactButton_Click);
            // 
            // AddRowContactButton
            // 
            this.AddRowContactButton.Location = new System.Drawing.Point(8, 21);
            this.AddRowContactButton.Name = "AddRowContactButton";
            this.AddRowContactButton.Size = new System.Drawing.Size(100, 21);
            this.AddRowContactButton.TabIndex = 13;
            this.AddRowContactButton.Text = "Добавить";
            this.AddRowContactButton.UseVisualStyleBackColor = true;
            this.AddRowContactButton.Click += new System.EventHandler(this.AddRowContactButton_Click);
            // 
            // UpdateRowContactButton
            // 
            this.UpdateRowContactButton.Location = new System.Drawing.Point(115, 21);
            this.UpdateRowContactButton.Name = "UpdateRowContactButton";
            this.UpdateRowContactButton.Size = new System.Drawing.Size(100, 21);
            this.UpdateRowContactButton.TabIndex = 3;
            this.UpdateRowContactButton.Text = "Редактировать";
            this.UpdateRowContactButton.UseVisualStyleBackColor = true;
            this.UpdateRowContactButton.Click += new System.EventHandler(this.UpdateRowContactButton_Click);
            // 
            // ContactsDataAdvancedDataGridView
            // 
            this.ContactsDataAdvancedDataGridView.AllowUserToAddRows = false;
            this.ContactsDataAdvancedDataGridView.AllowUserToDeleteRows = false;
            this.ContactsDataAdvancedDataGridView.AllowUserToOrderColumns = true;
            this.ContactsDataAdvancedDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactsDataAdvancedDataGridView.AutoGenerateContextFilters = true;
            this.ContactsDataAdvancedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ContactsDataAdvancedDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ContactsDataAdvancedDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ContactsDataAdvancedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContactsDataAdvancedDataGridView.DateWithTime = false;
            this.ContactsDataAdvancedDataGridView.Location = new System.Drawing.Point(6, 60);
            this.ContactsDataAdvancedDataGridView.Name = "ContactsDataAdvancedDataGridView";
            this.ContactsDataAdvancedDataGridView.ReadOnly = true;
            this.ContactsDataAdvancedDataGridView.Size = new System.Drawing.Size(657, 184);
            this.ContactsDataAdvancedDataGridView.TabIndex = 16;
            this.ContactsDataAdvancedDataGridView.TimeFilter = false;
            this.ContactsDataAdvancedDataGridView.DoubleClick += new System.EventHandler(this.ContactsDataAdvancedDataGridView_DoubleClick);
            this.ContactsDataAdvancedDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContactsDataAdvancedDataGridView_KeyDown);
            // 
            // DataStudentTabControl
            // 
            this.DataStudentTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataStudentTabControl.Controls.Add(this.ContactPage);
            this.DataStudentTabControl.Controls.Add(this.AdresTabPage);
            this.DataStudentTabControl.Location = new System.Drawing.Point(3, 142);
            this.DataStudentTabControl.Name = "DataStudentTabControl";
            this.DataStudentTabControl.SelectedIndex = 0;
            this.DataStudentTabControl.Size = new System.Drawing.Size(678, 273);
            this.DataStudentTabControl.TabIndex = 16;
            // 
            // ValidatingToolTip
            // 
            this.ValidatingToolTip.ToolTipTitle = "Подсказка";
            // 
            // AddFormStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 446);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CurriculumGroupBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.StudentGroupBox);
            this.Controls.Add(this.DataStudentTabControl);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "AddFormStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление данных о студенте";
            this.StudentGroupBox.ResumeLayout(false);
            this.StudentGroupBox.PerformLayout();
            this.CurriculumGroupBox.ResumeLayout(false);
            this.CurriculumGroupBox.PerformLayout();
            this.AdresTabPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdressAdvancedDataGridView)).EndInit();
            this.ContactPage.ResumeLayout(false);
            this.ActionsContactsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContactsDataAdvancedDataGridView)).EndInit();
            this.DataStudentTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContactbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AdressBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox StudentGroupBox;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox PatronymicNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label PatronimycNameLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.GroupBox CurriculumGroupBox;
        private System.Windows.Forms.TextBox GroupTextBox;
        private System.Windows.Forms.TextBox SpecialityTextBox;
        private System.Windows.Forms.TextBox FacultyTextBox;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.Label CourseLabel;
        private System.Windows.Forms.Label SpecialityLabel;
        private System.Windows.Forms.Label FacultyLabel;
        private System.Windows.Forms.TabPage AdresTabPage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button DeleteRowAdressButton;
        private System.Windows.Forms.Button AddRowAdressButton;
        private System.Windows.Forms.Button UpdateRowAdressButton;
        private ADGV.AdvancedDataGridView AdressAdvancedDataGridView;
        private System.Windows.Forms.TabPage ContactPage;
        private System.Windows.Forms.GroupBox ActionsContactsGroupBox;
        private System.Windows.Forms.Button DeleteRowContactButton;
        private System.Windows.Forms.Button AddRowContactButton;
        private System.Windows.Forms.Button UpdateRowContactButton;
        private System.Windows.Forms.TabControl DataStudentTabControl;
        private System.Windows.Forms.BindingSource ContactbindingSource;
        private System.Windows.Forms.BindingSource AdressBindingSource;
        private ADGV.AdvancedDataGridView ContactsDataAdvancedDataGridView;
        private System.Windows.Forms.ComboBox CourseComboBox;
        private System.Windows.Forms.ToolTip ValidatingToolTip;
    }
}