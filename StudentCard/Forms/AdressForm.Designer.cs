namespace StudentCard.Forms
{
    partial class AdressForm
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
            this.CityLabel = new System.Windows.Forms.Label();
            this.PostIndexLabel = new System.Windows.Forms.Label();
            this.StreetLabel = new System.Windows.Forms.Label();
            this.CityTextBox = new System.Windows.Forms.TextBox();
            this.StreetTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TypeAdressLabel = new System.Windows.Forms.Label();
            this.TypeAdressComboBox = new System.Windows.Forms.ComboBox();
            this.PostIndexMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(62, 37);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(37, 13);
            this.CityLabel.TabIndex = 0;
            this.CityLabel.Text = "Город";
            // 
            // PostIndexLabel
            // 
            this.PostIndexLabel.AutoSize = true;
            this.PostIndexLabel.Location = new System.Drawing.Point(3, 89);
            this.PostIndexLabel.Name = "PostIndexLabel";
            this.PostIndexLabel.Size = new System.Drawing.Size(96, 13);
            this.PostIndexLabel.TabIndex = 1;
            this.PostIndexLabel.Text = "Почтоный индекс";
            // 
            // StreetLabel
            // 
            this.StreetLabel.AutoSize = true;
            this.StreetLabel.Location = new System.Drawing.Point(60, 63);
            this.StreetLabel.Name = "StreetLabel";
            this.StreetLabel.Size = new System.Drawing.Size(39, 13);
            this.StreetLabel.TabIndex = 2;
            this.StreetLabel.Text = "Улица";
            // 
            // CityTextBox
            // 
            this.CityTextBox.Location = new System.Drawing.Point(105, 34);
            this.CityTextBox.Name = "CityTextBox";
            this.CityTextBox.Size = new System.Drawing.Size(207, 20);
            this.CityTextBox.TabIndex = 3;
            this.CityTextBox.TextChanged += new System.EventHandler(this.CityTextBox_TextChanged);
            this.CityTextBox.Leave += new System.EventHandler(this.CityTextBox_Leave);
            // 
            // StreetTextBox
            // 
            this.StreetTextBox.Location = new System.Drawing.Point(105, 60);
            this.StreetTextBox.Name = "StreetTextBox";
            this.StreetTextBox.Size = new System.Drawing.Size(207, 20);
            this.StreetTextBox.TabIndex = 5;
            this.StreetTextBox.TextChanged += new System.EventHandler(this.StreetTextBox_TextChanged);
            this.StreetTextBox.Leave += new System.EventHandler(this.StreetTextBox_Leave);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(105, 112);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "Ок";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(237, 112);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Отмена";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TypeAdressLabel
            // 
            this.TypeAdressLabel.AutoSize = true;
            this.TypeAdressLabel.Location = new System.Drawing.Point(34, 11);
            this.TypeAdressLabel.Name = "TypeAdressLabel";
            this.TypeAdressLabel.Size = new System.Drawing.Size(65, 13);
            this.TypeAdressLabel.TabIndex = 8;
            this.TypeAdressLabel.Text = "Тип адреса";
            // 
            // TypeAdressComboBox
            // 
            this.TypeAdressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeAdressComboBox.FormattingEnabled = true;
            this.TypeAdressComboBox.Location = new System.Drawing.Point(105, 7);
            this.TypeAdressComboBox.Name = "TypeAdressComboBox";
            this.TypeAdressComboBox.Size = new System.Drawing.Size(207, 21);
            this.TypeAdressComboBox.TabIndex = 10;
            this.TypeAdressComboBox.TextChanged += new System.EventHandler(this.TypeAdressComboBox_TextChanged);
            // 
            // PostIndexMaskedTextBox
            // 
            this.PostIndexMaskedTextBox.Location = new System.Drawing.Point(105, 86);
            this.PostIndexMaskedTextBox.Mask = "000000";
            this.PostIndexMaskedTextBox.Name = "PostIndexMaskedTextBox";
            this.PostIndexMaskedTextBox.Size = new System.Drawing.Size(75, 20);
            this.PostIndexMaskedTextBox.TabIndex = 11;
            this.PostIndexMaskedTextBox.TextChanged += new System.EventHandler(this.PostIndexMaskedTextBox_TextChanged);
            // 
            // AdressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 145);
            this.Controls.Add(this.PostIndexMaskedTextBox);
            this.Controls.Add(this.TypeAdressComboBox);
            this.Controls.Add(this.TypeAdressLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.StreetTextBox);
            this.Controls.Add(this.CityTextBox);
            this.Controls.Add(this.StreetLabel);
            this.Controls.Add(this.PostIndexLabel);
            this.Controls.Add(this.CityLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление адреса";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Label PostIndexLabel;
        private System.Windows.Forms.Label StreetLabel;
        private System.Windows.Forms.TextBox CityTextBox;
        private System.Windows.Forms.TextBox StreetTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label TypeAdressLabel;
        private System.Windows.Forms.ComboBox TypeAdressComboBox;
        private System.Windows.Forms.MaskedTextBox PostIndexMaskedTextBox;
    }
}