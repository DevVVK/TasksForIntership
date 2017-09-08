namespace CheckArcanoidLibrary.Forms
{
    partial class AddUserForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCansel = new System.Windows.Forms.Button();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.lblEnterName = new System.Windows.Forms.Label();
            this.erpInvalidName = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpInvalidName)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 78);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(147, 34);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCansel
            // 
            this.btnCansel.Location = new System.Drawing.Point(165, 78);
            this.btnCansel.Name = "btnCansel";
            this.btnCansel.Size = new System.Drawing.Size(149, 34);
            this.btnCansel.TabIndex = 1;
            this.btnCansel.Text = "Отмена";
            this.btnCansel.UseVisualStyleBackColor = true;
            this.btnCansel.Click += new System.EventHandler(this.btnCansel_Click);
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(90, 35);
            this.tbxUserName.MaxLength = 20;
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(224, 20);
            this.tbxUserName.TabIndex = 2;
            // 
            // lblEnterName
            // 
            this.lblEnterName.AutoSize = true;
            this.lblEnterName.Location = new System.Drawing.Point(12, 38);
            this.lblEnterName.Name = "lblEnterName";
            this.lblEnterName.Size = new System.Drawing.Size(72, 13);
            this.lblEnterName.TabIndex = 3;
            this.lblEnterName.Text = "Введите имя";
            // 
            // erpInvalidName
            // 
            this.erpInvalidName.ContainerControl = this;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 129);
            this.Controls.Add(this.lblEnterName);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.btnCansel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заменить игрока";
            ((System.ComponentModel.ISupportInitialize)(this.erpInvalidName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCansel;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label lblEnterName;
        private System.Windows.Forms.ErrorProvider erpInvalidName;
    }
}