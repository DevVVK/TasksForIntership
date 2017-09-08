namespace StudentCard
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EditButton = new System.Windows.Forms.Button();
            this.DataFromXmlFilesAdvanxedDataGrid = new ADGV.AdvancedDataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SearchGroupBox = new System.Windows.Forms.GroupBox();
            this.ColumnsComboBox = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.bindingsourcestudent = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataFromXmlFilesAdvanxedDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SearchGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourcestudent)).BeginInit();
            this.SuspendLayout();
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(115, 21);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(100, 21);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Редактировать";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DataFromXmlFilesAdvanxedDataGrid
            // 
            this.DataFromXmlFilesAdvanxedDataGrid.AllowUserToAddRows = false;
            this.DataFromXmlFilesAdvanxedDataGrid.AllowUserToDeleteRows = false;
            this.DataFromXmlFilesAdvanxedDataGrid.AllowUserToOrderColumns = true;
            this.DataFromXmlFilesAdvanxedDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataFromXmlFilesAdvanxedDataGrid.AutoGenerateContextFilters = true;
            this.DataFromXmlFilesAdvanxedDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataFromXmlFilesAdvanxedDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataFromXmlFilesAdvanxedDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataFromXmlFilesAdvanxedDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataFromXmlFilesAdvanxedDataGrid.DateWithTime = false;
            this.DataFromXmlFilesAdvanxedDataGrid.Location = new System.Drawing.Point(4, 72);
            this.DataFromXmlFilesAdvanxedDataGrid.Name = "DataFromXmlFilesAdvanxedDataGrid";
            this.DataFromXmlFilesAdvanxedDataGrid.ReadOnly = true;
            this.DataFromXmlFilesAdvanxedDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataFromXmlFilesAdvanxedDataGrid.Size = new System.Drawing.Size(952, 494);
            this.DataFromXmlFilesAdvanxedDataGrid.TabIndex = 12;
            this.DataFromXmlFilesAdvanxedDataGrid.TimeFilter = false;
            this.DataFromXmlFilesAdvanxedDataGrid.SortStringChanged += new System.EventHandler(this.DataFromXmlFilesAdvanxedDataGrid_SortStringChanged);
            this.DataFromXmlFilesAdvanxedDataGrid.FilterStringChanged += new System.EventHandler(this.DataFromXmlFilesAdvanxedDataGrid_FilterStringChanged);
            this.DataFromXmlFilesAdvanxedDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataFromXmlFilesAdvanxedDataGrid_CellDoubleClick);
            this.DataFromXmlFilesAdvanxedDataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataFromXmlFilesAdvanxedDataGrid_ColumnHeaderMouseClick);
            this.DataFromXmlFilesAdvanxedDataGrid.SelectionChanged += new System.EventHandler(this.DataFromXmlFiles_SelectionChanged);
            this.DataFromXmlFilesAdvanxedDataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataFromXmlFilesAdvanxedDataGrid_KeyDown);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(8, 21);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 21);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(221, 21);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 21);
            this.DeleteButton.TabIndex = 14;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteButton);
            this.groupBox1.Controls.Add(this.AddButton);
            this.groupBox1.Controls.Add(this.EditButton);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 54);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // SearchGroupBox
            // 
            this.SearchGroupBox.Controls.Add(this.ColumnsComboBox);
            this.SearchGroupBox.Controls.Add(this.SearchButton);
            this.SearchGroupBox.Controls.Add(this.SearchTextBox);
            this.SearchGroupBox.Location = new System.Drawing.Point(333, 12);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(399, 54);
            this.SearchGroupBox.TabIndex = 14;
            this.SearchGroupBox.TabStop = false;
            this.SearchGroupBox.Text = "Поиск";
            // 
            // ColumnsComboBox
            // 
            this.ColumnsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColumnsComboBox.FormattingEnabled = true;
            this.ColumnsComboBox.Location = new System.Drawing.Point(6, 22);
            this.ColumnsComboBox.Name = "ColumnsComboBox";
            this.ColumnsComboBox.Size = new System.Drawing.Size(121, 21);
            this.ColumnsComboBox.TabIndex = 17;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(317, 21);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 21);
            this.SearchButton.TabIndex = 16;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(135, 22);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(176, 20);
            this.SearchTextBox.TabIndex = 15;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 569);
            this.Controls.Add(this.SearchGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DataFromXmlFilesAdvanxedDataGrid);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карточка студента";
            ((System.ComponentModel.ISupportInitialize)(this.DataFromXmlFilesAdvanxedDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.SearchGroupBox.ResumeLayout(false);
            this.SearchGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourcestudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button EditButton;
        private ADGV.AdvancedDataGridView DataFromXmlFilesAdvanxedDataGrid;
        private System.Windows.Forms.BindingSource bindingsourcestudent;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox SearchGroupBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.ComboBox ColumnsComboBox;
    }
}

