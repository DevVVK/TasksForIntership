namespace Calculator.View
{
    partial class MainFormCalculator
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
            this.btnOne = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnSix = new System.Windows.Forms.Button();
            this.btnSeven = new System.Windows.Forms.Button();
            this.btnEight = new System.Windows.Forms.Button();
            this.btnNine = new System.Windows.Forms.Button();
            this.btnClearLast = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnClearSymbol = new System.Windows.Forms.Button();
            this.btnVirgule = new System.Windows.Forms.Button();
            this.btnAddAndSub = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnMult = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.btnArctg = new System.Windows.Forms.Button();
            this.btnTan = new System.Windows.Forms.Button();
            this.btnCos = new System.Windows.Forms.Button();
            this.btnSin = new System.Windows.Forms.Button();
            this.btnLn = new System.Windows.Forms.Button();
            this.btnXPowerY = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnFact = new System.Windows.Forms.Button();
            this.btnExp = new System.Windows.Forms.Button();
            this.btnXPower2 = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.btnDivOneOnX = new System.Windows.Forms.Button();
            this.btnPercent = new System.Windows.Forms.Button();
            this.btnRoot = new System.Windows.Forms.Button();
            this.btnSubMemValue = new System.Windows.Forms.Button();
            this.btnAddMemValue = new System.Windows.Forms.Button();
            this.btnMemClear = new System.Windows.Forms.Button();
            this.btnMemRet = new System.Windows.Forms.Button();
            this.tbxDigit = new System.Windows.Forms.TextBox();
            this.DegreesRadioButton = new System.Windows.Forms.RadioButton();
            this.RadiansRadioButton = new System.Windows.Forms.RadioButton();
            this.HailstonesRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxExpression = new System.Windows.Forms.TextBox();
            this.lblMemoryValue = new System.Windows.Forms.Label();
            this.btnRightBracket = new System.Windows.Forms.Button();
            this.btnLeftBracket = new System.Windows.Forms.Button();
            this.pnlMemoryValue = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCountBrackets = new System.Windows.Forms.Label();
            this.tmrHandlerTwoKeys = new System.Windows.Forms.Timer(this.components);
            this.btnSaveMem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlMemoryValue.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOne
            // 
            this.btnOne.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOne.Location = new System.Drawing.Point(101, 284);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(44, 38);
            this.btnOne.TabIndex = 0;
            this.btnOne.Text = "1";
            this.btnOne.UseVisualStyleBackColor = false;
            this.btnOne.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnTwo
            // 
            this.btnTwo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTwo.Location = new System.Drawing.Point(151, 284);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(44, 38);
            this.btnTwo.TabIndex = 1;
            this.btnTwo.Text = "2";
            this.btnTwo.UseVisualStyleBackColor = false;
            this.btnTwo.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnThree
            // 
            this.btnThree.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnThree.Location = new System.Drawing.Point(201, 284);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(44, 38);
            this.btnThree.TabIndex = 2;
            this.btnThree.Text = "3";
            this.btnThree.UseVisualStyleBackColor = false;
            this.btnThree.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnFour
            // 
            this.btnFour.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFour.Location = new System.Drawing.Point(101, 241);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(44, 38);
            this.btnFour.TabIndex = 3;
            this.btnFour.Text = "4";
            this.btnFour.UseVisualStyleBackColor = false;
            this.btnFour.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnFive
            // 
            this.btnFive.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFive.Location = new System.Drawing.Point(151, 241);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(44, 38);
            this.btnFive.TabIndex = 4;
            this.btnFive.Text = "5";
            this.btnFive.UseVisualStyleBackColor = false;
            this.btnFive.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnSix
            // 
            this.btnSix.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSix.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSix.Location = new System.Drawing.Point(201, 241);
            this.btnSix.Name = "btnSix";
            this.btnSix.Size = new System.Drawing.Size(44, 38);
            this.btnSix.TabIndex = 5;
            this.btnSix.Text = "6";
            this.btnSix.UseVisualStyleBackColor = false;
            this.btnSix.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnSeven
            // 
            this.btnSeven.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSeven.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSeven.Location = new System.Drawing.Point(101, 199);
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Size = new System.Drawing.Size(44, 37);
            this.btnSeven.TabIndex = 6;
            this.btnSeven.Text = "7";
            this.btnSeven.UseVisualStyleBackColor = false;
            this.btnSeven.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnEight
            // 
            this.btnEight.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEight.Location = new System.Drawing.Point(151, 198);
            this.btnEight.Name = "btnEight";
            this.btnEight.Size = new System.Drawing.Size(44, 38);
            this.btnEight.TabIndex = 7;
            this.btnEight.Text = "8";
            this.btnEight.UseVisualStyleBackColor = false;
            this.btnEight.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnNine
            // 
            this.btnNine.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNine.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNine.Location = new System.Drawing.Point(201, 198);
            this.btnNine.Name = "btnNine";
            this.btnNine.Size = new System.Drawing.Size(44, 38);
            this.btnNine.TabIndex = 8;
            this.btnNine.Text = "9";
            this.btnNine.UseVisualStyleBackColor = false;
            this.btnNine.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnClearLast
            // 
            this.btnClearLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClearLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClearLast.Location = new System.Drawing.Point(151, 155);
            this.btnClearLast.Name = "btnClearLast";
            this.btnClearLast.Size = new System.Drawing.Size(44, 38);
            this.btnClearLast.TabIndex = 9;
            this.btnClearLast.Text = "CE";
            this.btnClearLast.UseVisualStyleBackColor = false;
            this.btnClearLast.Click += new System.EventHandler(this.ClearLastButton_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(201, 155);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 38);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // btnZero
            // 
            this.btnZero.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZero.Location = new System.Drawing.Point(101, 327);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(94, 38);
            this.btnZero.TabIndex = 11;
            this.btnZero.Text = "0";
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.PressDigitClick);
            // 
            // btnClearSymbol
            // 
            this.btnClearSymbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClearSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClearSymbol.Location = new System.Drawing.Point(101, 155);
            this.btnClearSymbol.Name = "btnClearSymbol";
            this.btnClearSymbol.Size = new System.Drawing.Size(44, 38);
            this.btnClearSymbol.TabIndex = 12;
            this.btnClearSymbol.Text = "<-";
            this.btnClearSymbol.UseVisualStyleBackColor = false;
            this.btnClearSymbol.Click += new System.EventHandler(this.ClearSymbolButton_Click);
            // 
            // btnVirgule
            // 
            this.btnVirgule.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnVirgule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVirgule.Location = new System.Drawing.Point(201, 327);
            this.btnVirgule.Name = "btnVirgule";
            this.btnVirgule.Size = new System.Drawing.Size(44, 38);
            this.btnVirgule.TabIndex = 13;
            this.btnVirgule.Text = ",";
            this.btnVirgule.UseVisualStyleBackColor = false;
            this.btnVirgule.Click += new System.EventHandler(this.VirguleButton_Click);
            // 
            // btnAddAndSub
            // 
            this.btnAddAndSub.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddAndSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddAndSub.Location = new System.Drawing.Point(251, 155);
            this.btnAddAndSub.Name = "btnAddAndSub";
            this.btnAddAndSub.Size = new System.Drawing.Size(44, 38);
            this.btnAddAndSub.TabIndex = 14;
            this.btnAddAndSub.Text = "+ -";
            this.btnAddAndSub.UseVisualStyleBackColor = false;
            this.btnAddAndSub.Click += new System.EventHandler(this.btnAddAndSub_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDiv.Location = new System.Drawing.Point(251, 198);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(44, 38);
            this.btnDiv.TabIndex = 15;
            this.btnDiv.Text = "/";
            this.btnDiv.UseVisualStyleBackColor = false;
            this.btnDiv.Click += new System.EventHandler(this.DivButton_Click);
            // 
            // btnMult
            // 
            this.btnMult.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMult.Location = new System.Drawing.Point(251, 241);
            this.btnMult.Name = "btnMult";
            this.btnMult.Size = new System.Drawing.Size(44, 38);
            this.btnMult.TabIndex = 16;
            this.btnMult.Text = "*";
            this.btnMult.UseVisualStyleBackColor = false;
            this.btnMult.Click += new System.EventHandler(this.MultButton_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(251, 327);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 38);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // btnSub
            // 
            this.btnSub.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSub.Location = new System.Drawing.Point(251, 284);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(44, 38);
            this.btnSub.TabIndex = 18;
            this.btnSub.Text = "-";
            this.btnSub.UseVisualStyleBackColor = false;
            this.btnSub.Click += new System.EventHandler(this.SubButton_Click);
            // 
            // btnArctg
            // 
            this.btnArctg.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnArctg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnArctg.Location = new System.Drawing.Point(53, 327);
            this.btnArctg.Name = "btnArctg";
            this.btnArctg.Size = new System.Drawing.Size(44, 38);
            this.btnArctg.TabIndex = 28;
            this.btnArctg.Text = "arctg";
            this.btnArctg.UseVisualStyleBackColor = false;
            this.btnArctg.Click += new System.EventHandler(this.ArctgButton_Click);
            // 
            // btnTan
            // 
            this.btnTan.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnTan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTan.Location = new System.Drawing.Point(53, 284);
            this.btnTan.Name = "btnTan";
            this.btnTan.Size = new System.Drawing.Size(44, 38);
            this.btnTan.TabIndex = 27;
            this.btnTan.Text = "tan";
            this.btnTan.UseVisualStyleBackColor = false;
            this.btnTan.Click += new System.EventHandler(this.TanButton_Click);
            // 
            // btnCos
            // 
            this.btnCos.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCos.Location = new System.Drawing.Point(53, 241);
            this.btnCos.Name = "btnCos";
            this.btnCos.Size = new System.Drawing.Size(44, 38);
            this.btnCos.TabIndex = 26;
            this.btnCos.Text = "cos";
            this.btnCos.UseVisualStyleBackColor = false;
            this.btnCos.Click += new System.EventHandler(this.CosButton_Click);
            // 
            // btnSin
            // 
            this.btnSin.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnSin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSin.Location = new System.Drawing.Point(53, 198);
            this.btnSin.Name = "btnSin";
            this.btnSin.Size = new System.Drawing.Size(44, 38);
            this.btnSin.TabIndex = 25;
            this.btnSin.Text = "sin";
            this.btnSin.UseVisualStyleBackColor = false;
            this.btnSin.Click += new System.EventHandler(this.SinButton_Click);
            // 
            // btnLn
            // 
            this.btnLn.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnLn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLn.Location = new System.Drawing.Point(53, 155);
            this.btnLn.Name = "btnLn";
            this.btnLn.Size = new System.Drawing.Size(44, 38);
            this.btnLn.TabIndex = 24;
            this.btnLn.Text = "Ln";
            this.btnLn.UseVisualStyleBackColor = false;
            this.btnLn.Click += new System.EventHandler(this.LnButton_Click);
            // 
            // btnXPowerY
            // 
            this.btnXPowerY.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnXPowerY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnXPowerY.Location = new System.Drawing.Point(3, 327);
            this.btnXPowerY.Name = "btnXPowerY";
            this.btnXPowerY.Size = new System.Drawing.Size(44, 38);
            this.btnXPowerY.TabIndex = 23;
            this.btnXPowerY.Text = "x^y";
            this.btnXPowerY.UseVisualStyleBackColor = false;
            this.btnXPowerY.Click += new System.EventHandler(this.XPowerYButton_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLog.Location = new System.Drawing.Point(4, 155);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(44, 38);
            this.btnLog.TabIndex = 22;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // btnFact
            // 
            this.btnFact.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFact.Location = new System.Drawing.Point(3, 198);
            this.btnFact.Name = "btnFact";
            this.btnFact.Size = new System.Drawing.Size(44, 38);
            this.btnFact.TabIndex = 21;
            this.btnFact.Text = "!n";
            this.btnFact.UseVisualStyleBackColor = false;
            this.btnFact.Click += new System.EventHandler(this.FactButton_Click);
            // 
            // btnExp
            // 
            this.btnExp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExp.Location = new System.Drawing.Point(3, 241);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(44, 38);
            this.btnExp.TabIndex = 20;
            this.btnExp.Text = "Exp";
            this.btnExp.UseVisualStyleBackColor = false;
            this.btnExp.Click += new System.EventHandler(this.ExpButton_Click);
            // 
            // btnXPower2
            // 
            this.btnXPower2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnXPower2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnXPower2.Location = new System.Drawing.Point(3, 284);
            this.btnXPower2.Name = "btnXPower2";
            this.btnXPower2.Size = new System.Drawing.Size(44, 38);
            this.btnXPower2.TabIndex = 19;
            this.btnXPower2.Text = "x^2";
            this.btnXPower2.UseVisualStyleBackColor = false;
            this.btnXPower2.Click += new System.EventHandler(this.XPower2Button_Click);
            // 
            // btnResult
            // 
            this.btnResult.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResult.Location = new System.Drawing.Point(301, 284);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(44, 81);
            this.btnResult.TabIndex = 33;
            this.btnResult.Text = "=";
            this.btnResult.UseVisualStyleBackColor = false;
            this.btnResult.Click += new System.EventHandler(this.ResultButton_Click);
            // 
            // btnDivOneOnX
            // 
            this.btnDivOneOnX.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDivOneOnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDivOneOnX.Location = new System.Drawing.Point(301, 241);
            this.btnDivOneOnX.Name = "btnDivOneOnX";
            this.btnDivOneOnX.Size = new System.Drawing.Size(44, 38);
            this.btnDivOneOnX.TabIndex = 32;
            this.btnDivOneOnX.Text = "1/x";
            this.btnDivOneOnX.UseVisualStyleBackColor = false;
            this.btnDivOneOnX.Click += new System.EventHandler(this.DivOneOnXButton_Click);
            // 
            // btnPercent
            // 
            this.btnPercent.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnPercent.Enabled = false;
            this.btnPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPercent.Location = new System.Drawing.Point(301, 198);
            this.btnPercent.Name = "btnPercent";
            this.btnPercent.Size = new System.Drawing.Size(44, 38);
            this.btnPercent.TabIndex = 31;
            this.btnPercent.Text = "%";
            this.btnPercent.UseVisualStyleBackColor = false;
            // 
            // btnRoot
            // 
            this.btnRoot.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRoot.Location = new System.Drawing.Point(301, 155);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(44, 38);
            this.btnRoot.TabIndex = 30;
            this.btnRoot.Text = "√";
            this.btnRoot.UseVisualStyleBackColor = false;
            this.btnRoot.Click += new System.EventHandler(this.btnRoot_Click);
            // 
            // btnSubMemValue
            // 
            this.btnSubMemValue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubMemValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubMemValue.Location = new System.Drawing.Point(301, 69);
            this.btnSubMemValue.Name = "btnSubMemValue";
            this.btnSubMemValue.Size = new System.Drawing.Size(44, 37);
            this.btnSubMemValue.TabIndex = 29;
            this.btnSubMemValue.Text = "M-";
            this.btnSubMemValue.UseVisualStyleBackColor = false;
            this.btnSubMemValue.Click += new System.EventHandler(this.btnSubMemValue_Click);
            // 
            // btnAddMemValue
            // 
            this.btnAddMemValue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddMemValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddMemValue.Location = new System.Drawing.Point(251, 69);
            this.btnAddMemValue.Name = "btnAddMemValue";
            this.btnAddMemValue.Size = new System.Drawing.Size(44, 37);
            this.btnAddMemValue.TabIndex = 34;
            this.btnAddMemValue.Text = "M+";
            this.btnAddMemValue.UseVisualStyleBackColor = false;
            this.btnAddMemValue.Click += new System.EventHandler(this.btnAddMemValue_Click);
            // 
            // btnMemClear
            // 
            this.btnMemClear.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMemClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMemClear.Location = new System.Drawing.Point(201, 69);
            this.btnMemClear.Name = "btnMemClear";
            this.btnMemClear.Size = new System.Drawing.Size(44, 37);
            this.btnMemClear.TabIndex = 35;
            this.btnMemClear.Text = "MC";
            this.btnMemClear.UseVisualStyleBackColor = false;
            this.btnMemClear.Click += new System.EventHandler(this.btnMemClear_Click);
            // 
            // btnMemRet
            // 
            this.btnMemRet.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMemRet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMemRet.Location = new System.Drawing.Point(151, 69);
            this.btnMemRet.Name = "btnMemRet";
            this.btnMemRet.Size = new System.Drawing.Size(44, 37);
            this.btnMemRet.TabIndex = 36;
            this.btnMemRet.Text = "MR";
            this.btnMemRet.UseVisualStyleBackColor = false;
            this.btnMemRet.Click += new System.EventHandler(this.btnMemRet_Click);
            // 
            // tbxDigit
            // 
            this.tbxDigit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxDigit.Enabled = false;
            this.tbxDigit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxDigit.Location = new System.Drawing.Point(3, 31);
            this.tbxDigit.MaxLength = 15;
            this.tbxDigit.Name = "tbxDigit";
            this.tbxDigit.Size = new System.Drawing.Size(342, 31);
            this.tbxDigit.TabIndex = 37;
            this.tbxDigit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DegreesRadioButton
            // 
            this.DegreesRadioButton.AutoSize = true;
            this.DegreesRadioButton.Checked = true;
            this.DegreesRadioButton.Location = new System.Drawing.Point(3, 11);
            this.DegreesRadioButton.Name = "DegreesRadioButton";
            this.DegreesRadioButton.Size = new System.Drawing.Size(68, 17);
            this.DegreesRadioButton.TabIndex = 38;
            this.DegreesRadioButton.TabStop = true;
            this.DegreesRadioButton.Text = "Градусы";
            this.DegreesRadioButton.UseVisualStyleBackColor = true;
            // 
            // RadiansRadioButton
            // 
            this.RadiansRadioButton.AutoSize = true;
            this.RadiansRadioButton.Location = new System.Drawing.Point(77, 11);
            this.RadiansRadioButton.Name = "RadiansRadioButton";
            this.RadiansRadioButton.Size = new System.Drawing.Size(70, 17);
            this.RadiansRadioButton.TabIndex = 39;
            this.RadiansRadioButton.TabStop = true;
            this.RadiansRadioButton.Text = "Радианы";
            this.RadiansRadioButton.UseVisualStyleBackColor = true;
            // 
            // HailstonesRadioButton
            // 
            this.HailstonesRadioButton.AutoSize = true;
            this.HailstonesRadioButton.Location = new System.Drawing.Point(153, 11);
            this.HailstonesRadioButton.Name = "HailstonesRadioButton";
            this.HailstonesRadioButton.Size = new System.Drawing.Size(57, 17);
            this.HailstonesRadioButton.TabIndex = 40;
            this.HailstonesRadioButton.TabStop = true;
            this.HailstonesRadioButton.Text = "Грады";
            this.HailstonesRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DegreesRadioButton);
            this.panel1.Controls.Add(this.HailstonesRadioButton);
            this.panel1.Controls.Add(this.RadiansRadioButton);
            this.panel1.Location = new System.Drawing.Point(133, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 37);
            this.panel1.TabIndex = 41;
            // 
            // tbxExpression
            // 
            this.tbxExpression.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxExpression.Enabled = false;
            this.tbxExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxExpression.Location = new System.Drawing.Point(3, 5);
            this.tbxExpression.MaxLength = 15;
            this.tbxExpression.Name = "tbxExpression";
            this.tbxExpression.Size = new System.Drawing.Size(342, 20);
            this.tbxExpression.TabIndex = 42;
            this.tbxExpression.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMemoryValue
            // 
            this.lblMemoryValue.AutoSize = true;
            this.lblMemoryValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMemoryValue.Location = new System.Drawing.Point(22, 13);
            this.lblMemoryValue.Name = "lblMemoryValue";
            this.lblMemoryValue.Size = new System.Drawing.Size(13, 13);
            this.lblMemoryValue.TabIndex = 43;
            this.lblMemoryValue.Text = "0";
            this.lblMemoryValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRightBracket
            // 
            this.btnRightBracket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRightBracket.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRightBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRightBracket.Location = new System.Drawing.Point(101, 111);
            this.btnRightBracket.Name = "btnRightBracket";
            this.btnRightBracket.Size = new System.Drawing.Size(28, 38);
            this.btnRightBracket.TabIndex = 45;
            this.btnRightBracket.Text = ")";
            this.btnRightBracket.UseVisualStyleBackColor = false;
            this.btnRightBracket.Click += new System.EventHandler(this.btnRightBracket_Click);
            // 
            // btnLeftBracket
            // 
            this.btnLeftBracket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLeftBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLeftBracket.Location = new System.Drawing.Point(67, 111);
            this.btnLeftBracket.Name = "btnLeftBracket";
            this.btnLeftBracket.Size = new System.Drawing.Size(30, 38);
            this.btnLeftBracket.TabIndex = 44;
            this.btnLeftBracket.Text = "(";
            this.btnLeftBracket.UseVisualStyleBackColor = false;
            this.btnLeftBracket.Click += new System.EventHandler(this.btnLeftBracket_Click);
            // 
            // pnlMemoryValue
            // 
            this.pnlMemoryValue.Controls.Add(this.lblMemoryValue);
            this.pnlMemoryValue.Location = new System.Drawing.Point(3, 69);
            this.pnlMemoryValue.Name = "pnlMemoryValue";
            this.pnlMemoryValue.Size = new System.Drawing.Size(94, 37);
            this.pnlMemoryValue.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblCountBrackets);
            this.panel2.Location = new System.Drawing.Point(3, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(58, 37);
            this.panel2.TabIndex = 47;
            // 
            // lblCountBrackets
            // 
            this.lblCountBrackets.AutoSize = true;
            this.lblCountBrackets.Location = new System.Drawing.Point(22, 13);
            this.lblCountBrackets.Name = "lblCountBrackets";
            this.lblCountBrackets.Size = new System.Drawing.Size(13, 13);
            this.lblCountBrackets.TabIndex = 0;
            this.lblCountBrackets.Text = "0";
            this.lblCountBrackets.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSaveMem
            // 
            this.btnSaveMem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveMem.Location = new System.Drawing.Point(103, 69);
            this.btnSaveMem.Name = "btnSaveMem";
            this.btnSaveMem.Size = new System.Drawing.Size(44, 37);
            this.btnSaveMem.TabIndex = 48;
            this.btnSaveMem.Text = "MS";
            this.btnSaveMem.UseVisualStyleBackColor = false;
            this.btnSaveMem.Click += new System.EventHandler(this.btnSaveMem_Click);
            // 
            // MainFormCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 367);
            this.Controls.Add(this.btnSaveMem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlMemoryValue);
            this.Controls.Add(this.btnRightBracket);
            this.Controls.Add(this.btnLeftBracket);
            this.Controls.Add(this.tbxExpression);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbxDigit);
            this.Controls.Add(this.btnMemRet);
            this.Controls.Add(this.btnMemClear);
            this.Controls.Add(this.btnAddMemValue);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnDivOneOnX);
            this.Controls.Add(this.btnPercent);
            this.Controls.Add(this.btnRoot);
            this.Controls.Add(this.btnSubMemValue);
            this.Controls.Add(this.btnArctg);
            this.Controls.Add(this.btnTan);
            this.Controls.Add(this.btnCos);
            this.Controls.Add(this.btnSin);
            this.Controls.Add(this.btnLn);
            this.Controls.Add(this.btnXPowerY);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnFact);
            this.Controls.Add(this.btnExp);
            this.Controls.Add(this.btnXPower2);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnMult);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnAddAndSub);
            this.Controls.Add(this.btnVirgule);
            this.Controls.Add(this.btnClearSymbol);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClearLast);
            this.Controls.Add(this.btnNine);
            this.Controls.Add(this.btnEight);
            this.Controls.Add(this.btnSeven);
            this.Controls.Add(this.btnSix);
            this.Controls.Add(this.btnFive);
            this.Controls.Add(this.btnFour);
            this.Controls.Add(this.btnThree);
            this.Controls.Add(this.btnTwo);
            this.Controls.Add(this.btnOne);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "MainFormCalculator";
            this.Text = "Инженерный калькулятор";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormCalculator_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormCalculator_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMemoryValue.ResumeLayout(false);
            this.pnlMemoryValue.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnFour;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnSix;
        private System.Windows.Forms.Button btnSeven;
        private System.Windows.Forms.Button btnEight;
        private System.Windows.Forms.Button btnNine;
        private System.Windows.Forms.Button btnClearLast;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnClearSymbol;
        private System.Windows.Forms.Button btnVirgule;
        private System.Windows.Forms.Button btnAddAndSub;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnMult;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.Button btnArctg;
        private System.Windows.Forms.Button btnTan;
        private System.Windows.Forms.Button btnCos;
        private System.Windows.Forms.Button btnSin;
        private System.Windows.Forms.Button btnLn;
        private System.Windows.Forms.Button btnXPowerY;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnFact;
        private System.Windows.Forms.Button btnExp;
        private System.Windows.Forms.Button btnXPower2;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnDivOneOnX;
        private System.Windows.Forms.Button btnPercent;
        private System.Windows.Forms.Button btnRoot;
        private System.Windows.Forms.Button btnSubMemValue;
        private System.Windows.Forms.Button btnAddMemValue;
        private System.Windows.Forms.Button btnMemClear;
        private System.Windows.Forms.Button btnMemRet;
        private System.Windows.Forms.TextBox tbxDigit;
        private System.Windows.Forms.RadioButton DegreesRadioButton;
        private System.Windows.Forms.RadioButton RadiansRadioButton;
        private System.Windows.Forms.RadioButton HailstonesRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxExpression;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCountBrackets;
        private System.Windows.Forms.Panel pnlMemoryValue;
        private System.Windows.Forms.Label lblMemoryValue;
        private System.Windows.Forms.Button btnRightBracket;
        private System.Windows.Forms.Button btnLeftBracket;
        private System.Windows.Forms.Timer tmrHandlerTwoKeys;
        private System.Windows.Forms.Button btnSaveMem;
    }
}

