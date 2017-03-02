namespace CardDisplay
{
    partial class DisplayHand
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
            this.btnDeal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.txtPlayer2Name = new System.Windows.Forms.TextBox();
            this.txtP1Chips = new System.Windows.Forms.TextBox();
            this.btnBetP2Dec = new System.Windows.Forms.Button();
            this.btnBetP1Inc = new System.Windows.Forms.Button();
            this.lblChips = new System.Windows.Forms.Label();
            this.txtP1Bet = new System.Windows.Forms.TextBox();
            this.lblBet = new System.Windows.Forms.Label();
            this.txtP2Bet = new System.Windows.Forms.TextBox();
            this.btnBetP2Inc = new System.Windows.Forms.Button();
            this.txtP2Chips = new System.Windows.Forms.TextBox();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.txtPlayer1Name = new System.Windows.Forms.TextBox();
            this.lblP1Count = new System.Windows.Forms.Label();
            this.btnBetP1Dec = new System.Windows.Forms.Button();
            this.panelP1Cards = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStay = new System.Windows.Forms.Button();
            this.btnP1Hit = new System.Windows.Forms.Button();
            this.lblP2Count = new System.Windows.Forms.Label();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.panelP2Cards = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnP2Stay = new System.Windows.Forms.Button();
            this.btnP2Hit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblDealerCount = new System.Windows.Forms.Label();
            this.panelDlrCards = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCardCount = new System.Windows.Forms.Label();
            this.panelPlayer1.SuspendLayout();
            this.panelP1Cards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelPlayer2.SuspendLayout();
            this.panelDlrCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeal
            // 
            this.btnDeal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDeal.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnDeal.FlatAppearance.BorderSize = 0;
            this.btnDeal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeal.Location = new System.Drawing.Point(5, 25);
            this.btnDeal.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(50, 20);
            this.btnDeal.TabIndex = 0;
            this.btnDeal.Text = "Deal";
            this.btnDeal.UseVisualStyleBackColor = false;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dealer";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.ForeColor = System.Drawing.Color.White;
            this.lblPlayer.Location = new System.Drawing.Point(6, 109);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(42, 13);
            this.lblPlayer.TabIndex = 2;
            this.lblPlayer.Text = "Player";
            // 
            // txtPlayer2Name
            // 
            this.txtPlayer2Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPlayer2Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlayer2Name.Location = new System.Drawing.Point(3, 4);
            this.txtPlayer2Name.Name = "txtPlayer2Name";
            this.txtPlayer2Name.Size = new System.Drawing.Size(56, 20);
            this.txtPlayer2Name.TabIndex = 5;
            // 
            // txtP1Chips
            // 
            this.txtP1Chips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtP1Chips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtP1Chips.Enabled = false;
            this.txtP1Chips.Location = new System.Drawing.Point(64, 3);
            this.txtP1Chips.Name = "txtP1Chips";
            this.txtP1Chips.Size = new System.Drawing.Size(42, 20);
            this.txtP1Chips.TabIndex = 6;
            this.txtP1Chips.Text = "1000";
            // 
            // btnBetP2Dec
            // 
            this.btnBetP2Dec.BackColor = System.Drawing.Color.Green;
            this.btnBetP2Dec.FlatAppearance.BorderSize = 0;
            this.btnBetP2Dec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBetP2Dec.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBetP2Dec.ForeColor = System.Drawing.Color.White;
            this.btnBetP2Dec.Location = new System.Drawing.Point(170, -1);
            this.btnBetP2Dec.Name = "btnBetP2Dec";
            this.btnBetP2Dec.Size = new System.Drawing.Size(20, 25);
            this.btnBetP2Dec.TabIndex = 16;
            this.btnBetP2Dec.Text = "-";
            this.btnBetP2Dec.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBetP2Dec.UseVisualStyleBackColor = false;
            this.btnBetP2Dec.Click += new System.EventHandler(this.btnP2Dec_Click);
            // 
            // btnBetP1Inc
            // 
            this.btnBetP1Inc.BackColor = System.Drawing.Color.Green;
            this.btnBetP1Inc.FlatAppearance.BorderSize = 0;
            this.btnBetP1Inc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBetP1Inc.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBetP1Inc.ForeColor = System.Drawing.Color.White;
            this.btnBetP1Inc.Location = new System.Drawing.Point(146, 6);
            this.btnBetP1Inc.Name = "btnBetP1Inc";
            this.btnBetP1Inc.Size = new System.Drawing.Size(20, 16);
            this.btnBetP1Inc.TabIndex = 9;
            this.btnBetP1Inc.Text = "+";
            this.btnBetP1Inc.UseCompatibleTextRendering = true;
            this.btnBetP1Inc.UseVisualStyleBackColor = false;
            this.btnBetP1Inc.Click += new System.EventHandler(this.btnBetP1Inc_Click);
            // 
            // lblChips
            // 
            this.lblChips.AutoSize = true;
            this.lblChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChips.ForeColor = System.Drawing.Color.White;
            this.lblChips.Location = new System.Drawing.Point(68, 109);
            this.lblChips.Name = "lblChips";
            this.lblChips.Size = new System.Drawing.Size(38, 13);
            this.lblChips.TabIndex = 11;
            this.lblChips.Text = "Chips";
            // 
            // txtP1Bet
            // 
            this.txtP1Bet.Location = new System.Drawing.Point(111, 3);
            this.txtP1Bet.Name = "txtP1Bet";
            this.txtP1Bet.Size = new System.Drawing.Size(36, 20);
            this.txtP1Bet.TabIndex = 12;
            this.txtP1Bet.Text = "5";
            // 
            // lblBet
            // 
            this.lblBet.AutoSize = true;
            this.lblBet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBet.ForeColor = System.Drawing.Color.White;
            this.lblBet.Location = new System.Drawing.Point(114, 109);
            this.lblBet.Name = "lblBet";
            this.lblBet.Size = new System.Drawing.Size(26, 13);
            this.lblBet.TabIndex = 13;
            this.lblBet.Text = "Bet";
            // 
            // txtP2Bet
            // 
            this.txtP2Bet.Location = new System.Drawing.Point(113, 4);
            this.txtP2Bet.Name = "txtP2Bet";
            this.txtP2Bet.Size = new System.Drawing.Size(36, 20);
            this.txtP2Bet.TabIndex = 19;
            this.txtP2Bet.Text = "5";
            // 
            // btnBetP2Inc
            // 
            this.btnBetP2Inc.BackColor = System.Drawing.Color.Green;
            this.btnBetP2Inc.FlatAppearance.BorderSize = 0;
            this.btnBetP2Inc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBetP2Inc.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBetP2Inc.ForeColor = System.Drawing.Color.White;
            this.btnBetP2Inc.Location = new System.Drawing.Point(149, 7);
            this.btnBetP2Inc.Name = "btnBetP2Inc";
            this.btnBetP2Inc.Size = new System.Drawing.Size(20, 16);
            this.btnBetP2Inc.TabIndex = 17;
            this.btnBetP2Inc.Text = "+";
            this.btnBetP2Inc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBetP2Inc.UseCompatibleTextRendering = true;
            this.btnBetP2Inc.UseVisualStyleBackColor = false;
            this.btnBetP2Inc.Click += new System.EventHandler(this.btnP2Inc_Click);
            // 
            // txtP2Chips
            // 
            this.txtP2Chips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtP2Chips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtP2Chips.Enabled = false;
            this.txtP2Chips.Location = new System.Drawing.Point(66, 4);
            this.txtP2Chips.Name = "txtP2Chips";
            this.txtP2Chips.Size = new System.Drawing.Size(42, 20);
            this.txtP2Chips.TabIndex = 15;
            this.txtP2Chips.Text = "1000";
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Controls.Add(this.txtPlayer1Name);
            this.panelPlayer1.Controls.Add(this.lblP1Count);
            this.panelPlayer1.Controls.Add(this.btnBetP1Dec);
            this.panelPlayer1.Controls.Add(this.panelP1Cards);
            this.panelPlayer1.Controls.Add(this.button1);
            this.panelPlayer1.Controls.Add(this.btnStay);
            this.panelPlayer1.Controls.Add(this.btnP1Hit);
            this.panelPlayer1.Controls.Add(this.btnBetP1Inc);
            this.panelPlayer1.Controls.Add(this.txtP1Chips);
            this.panelPlayer1.Controls.Add(this.txtP1Bet);
            this.panelPlayer1.Location = new System.Drawing.Point(5, 124);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(281, 97);
            this.panelPlayer1.TabIndex = 23;
            this.panelPlayer1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtPlayer1Name
            // 
            this.txtPlayer1Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPlayer1Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlayer1Name.Location = new System.Drawing.Point(4, 2);
            this.txtPlayer1Name.Name = "txtPlayer1Name";
            this.txtPlayer1Name.Size = new System.Drawing.Size(56, 20);
            this.txtPlayer1Name.TabIndex = 42;
            // 
            // lblP1Count
            // 
            this.lblP1Count.AutoSize = true;
            this.lblP1Count.ForeColor = System.Drawing.Color.White;
            this.lblP1Count.Location = new System.Drawing.Point(75, 83);
            this.lblP1Count.Name = "lblP1Count";
            this.lblP1Count.Size = new System.Drawing.Size(24, 13);
            this.lblP1Count.TabIndex = 41;
            this.lblP1Count.Text = "text";
            // 
            // btnBetP1Dec
            // 
            this.btnBetP1Dec.BackColor = System.Drawing.Color.Green;
            this.btnBetP1Dec.FlatAppearance.BorderSize = 0;
            this.btnBetP1Dec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBetP1Dec.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBetP1Dec.ForeColor = System.Drawing.Color.White;
            this.btnBetP1Dec.Location = new System.Drawing.Point(170, -1);
            this.btnBetP1Dec.Name = "btnBetP1Dec";
            this.btnBetP1Dec.Size = new System.Drawing.Size(20, 25);
            this.btnBetP1Dec.TabIndex = 17;
            this.btnBetP1Dec.Text = "-";
            this.btnBetP1Dec.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBetP1Dec.UseVisualStyleBackColor = false;
            this.btnBetP1Dec.Click += new System.EventHandler(this.btnBetP1Dec_Click);
            // 
            // panelP1Cards
            // 
            this.panelP1Cards.Controls.Add(this.pictureBox4);
            this.panelP1Cards.Controls.Add(this.pictureBox3);
            this.panelP1Cards.Location = new System.Drawing.Point(60, 29);
            this.panelP1Cards.Name = "panelP1Cards";
            this.panelP1Cards.Size = new System.Drawing.Size(218, 54);
            this.panelP1Cards.TabIndex = 38;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(20, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 47);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(5, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 47);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(5, 70);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 20);
            this.button1.TabIndex = 35;
            this.button1.Text = "Dbl Dn";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnP1Stay_Click);
            // 
            // btnStay
            // 
            this.btnStay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStay.Enabled = false;
            this.btnStay.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnStay.FlatAppearance.BorderSize = 0;
            this.btnStay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStay.Location = new System.Drawing.Point(5, 50);
            this.btnStay.Margin = new System.Windows.Forms.Padding(2);
            this.btnStay.Name = "btnStay";
            this.btnStay.Size = new System.Drawing.Size(50, 20);
            this.btnStay.TabIndex = 34;
            this.btnStay.Text = "Stay";
            this.btnStay.UseVisualStyleBackColor = false;
            this.btnStay.Click += new System.EventHandler(this.btnP1Stay_Click);
            // 
            // btnP1Hit
            // 
            this.btnP1Hit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnP1Hit.Enabled = false;
            this.btnP1Hit.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnP1Hit.FlatAppearance.BorderSize = 0;
            this.btnP1Hit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnP1Hit.Location = new System.Drawing.Point(5, 30);
            this.btnP1Hit.Margin = new System.Windows.Forms.Padding(2);
            this.btnP1Hit.Name = "btnP1Hit";
            this.btnP1Hit.Size = new System.Drawing.Size(50, 20);
            this.btnP1Hit.TabIndex = 33;
            this.btnP1Hit.Text = "Hit";
            this.btnP1Hit.UseVisualStyleBackColor = false;
            this.btnP1Hit.Click += new System.EventHandler(this.btnP1Hit_Click);
            // 
            // lblP2Count
            // 
            this.lblP2Count.AutoSize = true;
            this.lblP2Count.ForeColor = System.Drawing.Color.White;
            this.lblP2Count.Location = new System.Drawing.Point(75, 83);
            this.lblP2Count.Name = "lblP2Count";
            this.lblP2Count.Size = new System.Drawing.Size(24, 13);
            this.lblP2Count.TabIndex = 37;
            this.lblP2Count.Text = "text";
            this.lblP2Count.Click += new System.EventHandler(this.lblP2Count_Click);
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.Controls.Add(this.panelP2Cards);
            this.panelPlayer2.Controls.Add(this.button2);
            this.panelPlayer2.Controls.Add(this.btnP2Stay);
            this.panelPlayer2.Controls.Add(this.lblP2Count);
            this.panelPlayer2.Controls.Add(this.btnP2Hit);
            this.panelPlayer2.Controls.Add(this.txtPlayer2Name);
            this.panelPlayer2.Controls.Add(this.btnBetP2Dec);
            this.panelPlayer2.Controls.Add(this.btnBetP2Inc);
            this.panelPlayer2.Controls.Add(this.txtP2Bet);
            this.panelPlayer2.Controls.Add(this.txtP2Chips);
            this.panelPlayer2.Location = new System.Drawing.Point(5, 227);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(281, 100);
            this.panelPlayer2.TabIndex = 28;
            this.panelPlayer2.Visible = false;
            // 
            // panelP2Cards
            // 
            this.panelP2Cards.Location = new System.Drawing.Point(60, 29);
            this.panelP2Cards.Name = "panelP2Cards";
            this.panelP2Cards.Size = new System.Drawing.Size(218, 54);
            this.panelP2Cards.TabIndex = 41;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(5, 70);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 20);
            this.button2.TabIndex = 40;
            this.button2.Text = "Dbl Dn";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnP2Stay
            // 
            this.btnP2Stay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnP2Stay.Enabled = false;
            this.btnP2Stay.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnP2Stay.FlatAppearance.BorderSize = 0;
            this.btnP2Stay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnP2Stay.Location = new System.Drawing.Point(5, 50);
            this.btnP2Stay.Margin = new System.Windows.Forms.Padding(2);
            this.btnP2Stay.Name = "btnP2Stay";
            this.btnP2Stay.Size = new System.Drawing.Size(51, 20);
            this.btnP2Stay.TabIndex = 39;
            this.btnP2Stay.Text = "Stay";
            this.btnP2Stay.UseVisualStyleBackColor = false;
            this.btnP2Stay.Click += new System.EventHandler(this.btnP2Stay_Click);
            // 
            // btnP2Hit
            // 
            this.btnP2Hit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnP2Hit.Enabled = false;
            this.btnP2Hit.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnP2Hit.FlatAppearance.BorderSize = 0;
            this.btnP2Hit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnP2Hit.Location = new System.Drawing.Point(5, 30);
            this.btnP2Hit.Margin = new System.Windows.Forms.Padding(2);
            this.btnP2Hit.Name = "btnP2Hit";
            this.btnP2Hit.Size = new System.Drawing.Size(51, 20);
            this.btnP2Hit.TabIndex = 38;
            this.btnP2Hit.Text = "Hit";
            this.btnP2Hit.UseVisualStyleBackColor = false;
            this.btnP2Hit.Click += new System.EventHandler(this.btnP2Hit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClear.Enabled = false;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(5, 45);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 20);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblDealerCount
            // 
            this.lblDealerCount.AutoSize = true;
            this.lblDealerCount.ForeColor = System.Drawing.Color.White;
            this.lblDealerCount.Location = new System.Drawing.Point(75, 83);
            this.lblDealerCount.Name = "lblDealerCount";
            this.lblDealerCount.Size = new System.Drawing.Size(24, 13);
            this.lblDealerCount.TabIndex = 30;
            this.lblDealerCount.Text = "text";
            // 
            // panelDlrCards
            // 
            this.panelDlrCards.BackColor = System.Drawing.Color.Green;
            this.panelDlrCards.Controls.Add(this.pictureBox2);
            this.panelDlrCards.Controls.Add(this.pictureBox1);
            this.panelDlrCards.Location = new System.Drawing.Point(60, 23);
            this.panelDlrCards.Name = "panelDlrCards";
            this.panelDlrCards.Size = new System.Drawing.Size(218, 54);
            this.panelDlrCards.TabIndex = 31;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(20, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 47);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 47);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblCardCount);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lblDealerCount);
            this.panel4.Controls.Add(this.btnDeal);
            this.panel4.Controls.Add(this.panelDlrCards);
            this.panel4.Controls.Add(this.btnClear);
            this.panel4.Location = new System.Drawing.Point(5, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(281, 100);
            this.panel4.TabIndex = 32;
            // 
            // lblCardCount
            // 
            this.lblCardCount.AutoSize = true;
            this.lblCardCount.ForeColor = System.Drawing.Color.White;
            this.lblCardCount.Location = new System.Drawing.Point(191, 84);
            this.lblCardCount.Name = "lblCardCount";
            this.lblCardCount.Size = new System.Drawing.Size(24, 13);
            this.lblCardCount.TabIndex = 32;
            this.lblCardCount.Text = "text";
            // 
            // DisplayHand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(290, 379);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelPlayer2);
            this.Controls.Add(this.panelPlayer1);
            this.Controls.Add(this.lblBet);
            this.Controls.Add(this.lblChips);
            this.Controls.Add(this.lblPlayer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DisplayHand";
            this.Text = "BlackJack";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DisplayHand_FormClosed);
            this.Load += new System.EventHandler(this.DisplayHand_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayHand_Paint);
            this.panelPlayer1.ResumeLayout(false);
            this.panelPlayer1.PerformLayout();
            this.panelP1Cards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelPlayer2.ResumeLayout(false);
            this.panelPlayer2.PerformLayout();
            this.panelDlrCards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlayer;
        public System.Windows.Forms.TextBox txtPlayer2Name;
        private System.Windows.Forms.TextBox txtP1Chips;
        private System.Windows.Forms.Button btnBetP2Dec;
        private System.Windows.Forms.Button btnBetP1Inc;
        private System.Windows.Forms.Label lblChips;
        private System.Windows.Forms.TextBox txtP1Bet;
        private System.Windows.Forms.Label lblBet;
        private System.Windows.Forms.TextBox txtP2Bet;
        private System.Windows.Forms.Button btnBetP2Inc;
        //private System.Windows.Forms.Button btnBetP2Dec;
        private System.Windows.Forms.TextBox txtP2Chips;
        private System.Windows.Forms.Panel panelPlayer1;
        private System.Windows.Forms.Panel panelPlayer2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStay;
        private System.Windows.Forms.Button btnP1Hit;
        private System.Windows.Forms.Button btnP2Stay;
        private System.Windows.Forms.Button btnP2Hit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblP2Count;
        private System.Windows.Forms.Label lblDealerCount;
        private System.Windows.Forms.Panel panelDlrCards;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelP1Cards;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnBetP1Dec;
        private System.Windows.Forms.Label lblP1Count;
        private System.Windows.Forms.Label lblCardCount;
        private System.Windows.Forms.Panel panelP2Cards;
        public System.Windows.Forms.TextBox txtPlayer1Name;
    }
}

