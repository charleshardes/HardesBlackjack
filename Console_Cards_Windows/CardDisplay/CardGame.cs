using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelloDLL;
using System.Runtime.InteropServices;

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
        private void DrawCard(Graphics g, string Card, int x, int y)
        {

            //not used

            string FileName = System.Windows.Forms.Application.StartupPath + "\\cards_gif\\" + Card + ".gif";
            Image Card_image1 = Image.FromFile(FileName);

            //g.TranslateTransform(100.0F, 0.0F);
            //g.RotateTransform(-30.0F);
            g.DrawImage(Card_image1, x, y, 46, 64);

        }    
        private void button1_Click(object sender, EventArgs e) {
            int i;
            int no_of_players, no_of_comps;

            if (int.TryParse(this.txtNumPlayers.Text, out i)) {

                //get number of players for DLLstruct initialization
                no_of_players = int.Parse(txtNumPlayers.Text);
                no_of_comps = 0; //default until we get this worked into the GUI

                if (no_of_players > 4) {
                    lblErrorMessage.Text = "Maximum of four players allowed.";
                }
                else {

                    string[] playerNames = new string[no_of_players];
                    playerNames[0] = this.txtPlayer1Name.Text;

                    //dynamically get player names; for every no_of_players
                    if (no_of_players >= 2) { playerNames[1] = this.txtPlayer2Name.Text; }

                    // 2 or more players not possible yet...but this is for when it is.
                    if (no_of_players >= 3) { playerNames[2] = this.txtPlayer3Name.Text; }
                    if (no_of_players == 4) { playerNames[3] = this.txtPlayer4Name.Text; }

                    DisplayHand frm = new DisplayHand(no_of_players, no_of_comps, playerNames);
                    //frm.NumPlayers = no_of_players + no_of_comps;

                    
                    for (i = 0; i < no_of_players + no_of_comps; i++) {
                        switch (i) {
                            case 0:

                                frm.lblPlayer1.Text = frm.BJgame.gameTable.players[0].name;
                                continue;
                            case 1:
                                frm.lblPlayer1.Text = frm.BJgame.gameTable.players[1].name;
                                continue;
                            
                            case 2:
                                //frm.txtPlayer3Name.Text = frm.BJgame.gameTable.players[2].name;
                                continue;
                            case 3:
                                //frm.txtPlayer4Name.Text = frm.BJgame.gameTable.players[3].name;
                                continue;

                        }//END SWITCH
                    }//END FOR
                    frm.Show();
                    this.Hide();
                }
            }
            else {
                lblErrorMessage.Text = "Enter the number of players.";
            }
        }

        private void txtNumPlayers_TextChanged(object sender, EventArgs e) {
            int i = 0;
            bool r = int.TryParse(txtNumPlayers.Text, out i);
            if (r) {
                if (int.Parse(txtNumPlayers.Text) > 1) {
                    panelPlayer2.Visible = true;
                }
                else { panelPlayer2.Visible = false;}

                if (int.Parse(txtNumPlayers.Text) > 2) {
                    panelPlayer3.Visible = true;
                }
                else { panelPlayer3.Visible = false; }

                if (int.Parse(txtNumPlayers.Text) > 3) {
                    panelPlayer4.Visible = true;
                }
                else { panelPlayer4.Visible = false; }

            }          
        }

        private void CardGame_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void panelPlayer1_Paint(object sender, PaintEventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
     
        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void CardGame_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
