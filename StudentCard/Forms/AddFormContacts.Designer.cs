namespace StudentCard.Forms
{
    partial class AddFormContacts
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
            this.TypeContactLabel = new System.Windows.Forms.Label();
            this.TypeContactComboBox = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.stringMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ValueToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // TypeContactLabel
            // 
            this.TypeContactLabel.AutoSize = true;
            this.TypeContactLabel.Location = new System.Drawing.Point(12, 9);
            this.TypeContactLabel.Name = "TypeContactLabel";
            this.TypeContactLabel.Size = new System.Drawing.Size(75, 13);
            this.TypeContactLabel.TabIndex = 0;
            this.TypeContactLabel.Text = "Тип контакта";
            // 
            // TypeContactComboBox
            // 
            this.TypeContactComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeContactComboBox.FormattingEnabled = true;
            this.TypeContactComboBox.Location = new System.Drawing.Point(93, 6);
            this.TypeContactComboBox.Name = "TypeContactComboBox";
            this.TypeContactComboBox.Size = new System.Drawing.Size(216, 21);
            this.TypeContactComboBox.TabIndex = 1;
            this.TypeContactComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeContactComboBox_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.AccessibleDescription = "";
            this.AddButton.Location = new System.Drawing.Point(93, 62);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Ок";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(234, 62);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Отмена";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(32, 39);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(55, 13);
            this.ValueLabel.TabIndex = 5;
            this.ValueLabel.Text = "Значение";
            // 
            // stringMaskedTextBox
            // 
            this.stringMaskedTextBox.Location = new System.Drawing.Point(93, 36);
            this.stringMaskedTextBox.Name = "stringMaskedTextBox";
            this.stringMaskedTextBox.Size = new System.Drawing.Size(216, 20);
            this.stringMaskedTextBox.TabIndex = 6;
            this.ValueToolTip.SetToolTip(this.stringMaskedTextBox, "Поле обязательно для заполнения");
            this.stringMaskedTextBox.TextChanged += new System.EventHandler(this.stringMaskedTextBox_TextChanged);
            // 
            // AddFormContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 92);
            this.Controls.Add(this.stringMaskedTextBox);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.TypeContactComboBox);
            this.Controls.Add(this.TypeContactLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddFormContacts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление контактов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TypeContactLabel;
        private System.Windows.Forms.ComboBox TypeContactComboBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.MaskedTextBox stringMaskedTextBox;
        private System.Windows.Forms.ToolTip ValueToolTip;
    }
}