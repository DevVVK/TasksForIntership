namespace CheckArcanoidLibrary.Forms
{
    partial class StatisticForm
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
            this.dgvStatisticGame = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatisticGame)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStatisticGame
            // 
            this.dgvStatisticGame.AllowUserToAddRows = false;
            this.dgvStatisticGame.AllowUserToDeleteRows = false;
            this.dgvStatisticGame.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatisticGame.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatisticGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatisticGame.Location = new System.Drawing.Point(0, 0);
            this.dgvStatisticGame.Name = "dgvStatisticGame";
            this.dgvStatisticGame.ReadOnly = true;
            this.dgvStatisticGame.Size = new System.Drawing.Size(533, 309);
            this.dgvStatisticGame.TabIndex = 0;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 309);
            this.Controls.Add(this.dgvStatisticGame);
            this.Name = "StatisticForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatisticGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStatisticGame;
    }
}