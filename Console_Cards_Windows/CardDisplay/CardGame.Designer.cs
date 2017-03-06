namespace CardDisplay
{
    partial class CardGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumPlayers = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.txtPlayer1Name = new System.Windows.Forms.TextBox();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.txtPlayer2Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.panelPlayer1.SuspendLayout();
            this.panelPlayer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of players:";
            // 
            // txtNumPlayers
            // 
            this.txtNumPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtNumPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumPlayers.Location = new System.Drawing.Point(130, 60);
            this.txtNumPlayers.Name = "txtNumPlayers";
            this.txtNumPlayers.Size = new System.Drawing.Size(31, 20);
            this.txtNumPlayers.TabIndex = 3;
            this.txtNumPlayers.Text = "1";
            this.txtNumPlayers.TextChanged += new System.EventHandler(this.txtNumPlayers_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(131, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "BlackJack";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Player 1";
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Controls.Add(this.txtPlayer1Name);
            this.panelPlayer1.Controls.Add(this.label2);
            this.panelPlayer1.Location = new System.Drawing.Point(10, 88);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(234, 35);
            this.panelPlayer1.TabIndex = 6;
            // 
            // txtPlayer1Name
            // 
            this.txtPlayer1Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPlayer1Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlayer1Name.Location = new System.Drawing.Point(120, 1);
            this.txtPlayer1Name.Name = "txtPlayer1Name";
            this.txtPlayer1Name.Size = new System.Drawing.Size(100, 20);
            this.txtPlayer1Name.TabIndex = 6;
            this.txtPlayer1Name.Text = "Gerry";
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.Controls.Add(this.txtPlayer2Name);
            this.panelPlayer2.Controls.Add(this.label4);
            this.panelPlayer2.Location = new System.Drawing.Point(10, 123);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(234, 35);
            this.panelPlayer2.TabIndex = 7;
            this.panelPlayer2.Visible = false;
            // 
            // txtPlayer2Name
            // 
            this.txtPlayer2Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtPlayer2Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlayer2Name.Location = new System.Drawing.Point(120, 1);
            this.txtPlayer2Name.Name = "txtPlayer2Name";
            this.txtPlayer2Name.Size = new System.Drawing.Size(100, 20);
            this.txtPlayer2Name.TabIndex = 6;
            this.txtPlayer2Name.Text = "Charles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Player 2 ";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.White;
            this.lblErrorMessage.Location = new System.Drawing.Point(61, 183);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMessage.TabIndex = 8;
            // 
            // CardGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.panelPlayer2);
            this.Controls.Add(this.panelPlayer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNumPlayers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "CardGame";
            this.Text = "Card Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CardGame_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelPlayer1.ResumeLayout(false);
            this.panelPlayer1.PerformLayout();
            this.panelPlayer2.ResumeLayout(false);
            this.panelPlayer2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumPlayers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelPlayer1;
        private System.Windows.Forms.TextBox txtPlayer1Name;
        private System.Windows.Forms.Panel panelPlayer2;
        private System.Windows.Forms.TextBox txtPlayer2Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblErrorMessage;
    }
}