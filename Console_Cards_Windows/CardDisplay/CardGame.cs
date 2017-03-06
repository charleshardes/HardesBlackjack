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

        private void button1_Click(object sender, EventArgs e) {
            int i;
            int no_of_players, no_of_comps;
            IntPtr BJtablePtr;
            table BJtable;
            

            if (int.TryParse(this.txtNumPlayers.Text, out i)) {

                //get number of players for DLLstruct initialization
                no_of_players = int.Parse(txtNumPlayers.Text);
                no_of_comps = 0; //default until we get this worked into the GUI

                if (no_of_players > 2) {
                    lblErrorMessage.Text = "Maximum of two players allowed.";
                }
                else {

                    string[] playerNames = new string[no_of_players];
                    playerNames[0] = this.txtPlayer1Name.Text;

                    //dynamically get player names; for every no_of_players
                    if (no_of_players >= 2) { playerNames[1] = this.txtPlayer2Name.Text; }

                    // 2 or more players not possible yet...but this is for when it is.
                    //if (no_of_players >= 3) { playerNames[1] = this.txtPlayer3Name.Text; }
                    //if (no_of_players == 4) { playerNames[1] = this.txtPlayer4Name.Text; }

                    DisplayHand frm = new DisplayHand(no_of_players, no_of_comps, playerNames);
                    frm.NumPlayers = no_of_players + no_of_comps;

                    //HelloDLL.player Playa;
                    for (i = 0; i < no_of_players + no_of_comps; i++) {
                        switch (i) {
                            case 0:

                                frm.txtPlayer1Name.Text = frm.BJgame.gameTable.players[0].name;
                                continue;
                            case 1:
                                frm.txtPlayer2Name.Text = frm.BJgame.gameTable.players[1].name;
                                continue;
                            /************************ FOR WHEN UP TO 4 PLAYERS IMPLEMENTED*******
                            case 2:
                                Playa = (player)Marshal.PtrToStructure(frm.Game.Table.players[2], typeof(player));
                                frm.txtPlayer3Name.Text = Playa.name.ToString();
                                break;
                            case 3:
                                Playa = (player)Marshal.PtrToStructure(frm.Game.Table.players[3], typeof(player));
                                frm.txtPlayer4Name.Text = Playa.name.ToString();
                                break;
                            */
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
