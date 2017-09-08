namespace CheckArcanoidLibrary.Forms
{
    partial class PausePanel
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPause = new System.Windows.Forms.Panel();
            this.btnReturnMainForm = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnReplay = new System.Windows.Forms.Button();
            this.pnlPause.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPause
            // 
            this.pnlPause.BackColor = System.Drawing.Color.Gray;
            this.pnlPause.Controls.Add(this.btnReturnMainForm);
            this.pnlPause.Controls.Add(this.btnContinue);
            this.pnlPause.Controls.Add(this.btnReplay);
            this.pnlPause.Location = new System.Drawing.Point(0, 0);
            this.pnlPause.Name = "pnlPause";
            this.pnlPause.Size = new System.Drawing.Size(870, 612);
            this.pnlPause.TabIndex = 5;
            // 
            // btnReturnMainForm
            // 
            this.btnReturnMainForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnReturnMainForm.Location = new System.Drawing.Point(276, 350);
            this.btnReturnMainForm.Name = "btnReturnMainForm";
            this.btnReturnMainForm.Size = new System.Drawing.Size(311, 57);
            this.btnReturnMainForm.TabIndex = 2;
            this.btnReturnMainForm.Text = "Главное меню";
            this.btnReturnMainForm.UseVisualStyleBackColor = true;
            this.btnReturnMainForm.Click += new System.EventHandler(this.ClickButton);
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnContinue.Location = new System.Drawing.Point(276, 287);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(311, 57);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "Продолжить";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.ClickButton);
            // 
            // btnReplay
            // 
            this.btnReplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btnReplay.Location = new System.Drawing.Point(276, 224);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(311, 57);
            this.btnReplay.TabIndex = 0;
            this.btnReplay.Text = "Переиграть";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.ClickButton);
            // 
            // PausePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPause);
            this.Name = "PausePanel";
            this.Size = new System.Drawing.Size(870, 612);
            this.pnlPause.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPause;
        private System.Windows.Forms.Button btnReturnMainForm;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnReplay;
    }
}
