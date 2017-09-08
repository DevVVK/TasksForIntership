namespace Arcanoid.Views
{
    partial class MainFormArcanoid
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
            this.pbxCanvasArcanoid = new System.Windows.Forms.PictureBox();
            this.tmrForMoveWithoutDelay = new System.Windows.Forms.Timer(this.components);
            this.tmrForMoveBall = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCanvasArcanoid)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxCanvasArcanoid
            // 
            this.pbxCanvasArcanoid.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbxCanvasArcanoid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxCanvasArcanoid.Location = new System.Drawing.Point(0, 0);
            this.pbxCanvasArcanoid.Name = "pbxCanvasArcanoid";
            this.pbxCanvasArcanoid.Size = new System.Drawing.Size(1186, 591);
            this.pbxCanvasArcanoid.TabIndex = 7;
            this.pbxCanvasArcanoid.TabStop = false;
            // 
            // tmrForMoveWithoutDelay
            // 
            this.tmrForMoveWithoutDelay.Interval = 1;
            this.tmrForMoveWithoutDelay.Tick += new System.EventHandler(this.timerForMoveWithoutDelay_Tick);
            // 
            // tmrForMoveBall
            // 
            this.tmrForMoveBall.Interval = 1;
            this.tmrForMoveBall.Tick += new System.EventHandler(this.tmrForMoveBall_Tick);
            // 
            // MainFormArcanoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 591);
            this.Controls.Add(this.pbxCanvasArcanoid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "MainFormArcanoid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arcanoid";
            this.Load += new System.EventHandler(this.MainFormArcanoid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormArcanoid_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormArcanoid_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCanvasArcanoid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxCanvasArcanoid;
        private System.Windows.Forms.Timer tmrForMoveWithoutDelay;
        private System.Windows.Forms.Timer tmrForMoveBall;
    }
}

