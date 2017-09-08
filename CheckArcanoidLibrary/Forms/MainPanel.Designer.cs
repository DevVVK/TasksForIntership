namespace CheckArcanoidLibrary.Forms
{
    partial class MainPanel
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblArcanoid = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.GrayText;
            this.pnlMenu.Controls.Add(this.btnUpdateUser);
            this.pnlMenu.Controls.Add(this.lblUser);
            this.pnlMenu.Controls.Add(this.lblArcanoid);
            this.pnlMenu.Controls.Add(this.btnStartGame);
            this.pnlMenu.Controls.Add(this.btnClose);
            this.pnlMenu.Controls.Add(this.btnStatistic);
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(870, 612);
            this.pnlMenu.TabIndex = 5;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Location = new System.Drawing.Point(14, 16);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateUser.TabIndex = 5;
            this.btnUpdateUser.Text = "Заменить";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.SystemColors.Info;
            this.lblUser.Location = new System.Drawing.Point(95, 21);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 13);
            this.lblUser.TabIndex = 4;
            // 
            // lblArcanoid
            // 
            this.lblArcanoid.AutoSize = true;
            this.lblArcanoid.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblArcanoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblArcanoid.ForeColor = System.Drawing.SystemColors.Info;
            this.lblArcanoid.Location = new System.Drawing.Point(279, 111);
            this.lblArcanoid.Name = "lblArcanoid";
            this.lblArcanoid.Size = new System.Drawing.Size(324, 73);
            this.lblArcanoid.TabIndex = 3;
            this.lblArcanoid.Text = "Арканоид";
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartGame.Location = new System.Drawing.Point(243, 305);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(396, 57);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "Новая игра";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.ClickButton);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Location = new System.Drawing.Point(243, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(396, 57);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStatistic
            // 
            this.btnStatistic.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnStatistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStatistic.Location = new System.Drawing.Point(243, 367);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(396, 57);
            this.btnStatistic.TabIndex = 1;
            this.btnStatistic.Text = "Статистика";
            this.btnStatistic.UseVisualStyleBackColor = false;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMenu);
            this.Name = "MainPanel";
            this.Size = new System.Drawing.Size(870, 612);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblArcanoid;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.Button btnUpdateUser;
        public System.Windows.Forms.Label lblUser;
    }
}
