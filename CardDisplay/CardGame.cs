using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard2;
using System.Windows.Forms;

namespace CardDisplay
{
    public partial class CardGame : Form
    {
        public CardGame()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(this.txtNumPlayers.Text, out i))
            {
                if (int.Parse(txtNumPlayers.Text)> 2)
                {
                    lblErrorMessage.Text = "Maximum of two players allowed.";
                }
                else
                {
                    DisplayHand frm = new DisplayHand();
                    frm.NumPlayers = Int32.Parse(txtNumPlayers.Text);
                    frm.txtPlayer1Name.Text = this.txtPlayer1Name.Text;
                    frm.txtPlayer2Name.Text = this.txtPlayer2Name.Text;
                    frm.Show();
                    this.Hide();
                }
            }else
            {
                lblErrorMessage.Text = "Enter the number of players.";
            }
        }

        private void txtNumPlayers_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            bool r = int.TryParse(txtNumPlayers.Text, out i);
            if (r)
            {
                if (int.Parse(txtNumPlayers.Text) > 1)
                {
                    panelPlayer2.Visible = true;
                }else
                {
                    panelPlayer2.Visible = false;
                }
            }          
        }

        private void CardGame_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
