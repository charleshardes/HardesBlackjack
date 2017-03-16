using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameState;
using System.Windows.Forms;
using HelloDLL;


namespace CardDisplay {
    
    public partial class DisplayHand : Form {

        public DisplayHand(int NO_OF_PLAYERS, int NO_OF_COMPS, string[] players) {

            InitializeComponent();
            this.BJgame = new Game(NO_OF_PLAYERS, NO_OF_COMPS, players);
        }

        public Game BJgame;

        private IList<PictureBox> DealerBoxes = new List<PictureBox>();
        //The following picture box objects are used to display the first two cards of a new game
        PictureBox pbDC1 = new PictureBox();
        PictureBox pbDC2 = new PictureBox();
        PictureBox pbPL1C1 = new PictureBox();
        PictureBox pbPL1C2 = new PictureBox();
        PictureBox pbPL2C1 = new PictureBox();
        PictureBox pbPL2C2 = new PictureBox();
        

        private void DisplayHand_Paint(object sender, PaintEventArgs e) {

            // Declares the Graphics object and sets it to the Graphics object
            // Currently not used, this could be used instead of picture boxes
            Graphics g = e.Graphics;
        }

        private void DrawCard(Graphics g, string Card,int x, int y) {

            //not used
            string FileName = System.Windows.Forms.Application.StartupPath + "\\cards_gif\\" + Card + ".gif";
            Image Card_image1 = Image.FromFile(FileName);
            g.DrawImage(Card_image1, x, y, 46, 64);
        }

        private void ShowCard(string Card, PictureBox myPictureBox) {

            //called everytime is card is displayed
            string FileName = System.Windows.Forms.Application.StartupPath + "\\cards_gif\\" + Card + ".gif";
            Image Card_image1 = Image.FromFile(FileName);
            myPictureBox.Image = Card_image1;
            myPictureBox.Visible = true;
            myPictureBox.BringToFront();
            myPictureBox.Invalidate();
        }

        private void FormatCard(PictureBox PictureBox, int X, int Y) 
            {
            //Formats the picture box to the desired location on the form and the dimensions
            PictureBox.Location = new Point(X, Y);
            PictureBox.Width = 72;
            PictureBox.Height = 94;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnDeal_Click(object sender, EventArgs e) 
            {
            //This resets all player hands to their starting (not dealt a hand yet) state
            BJinterface.DLLsetAllHands(ref Game.TableStruct);

            //this gets the bet amount from the GUI, makes the applicable update to the player's hand class
            //moved this here from DisplayHand_Load(), it's more appropriate here.
            GetBetsALL(true);

            //This deals out the starting hands to all players and dealer
            BJinterface.DLLdealStartingHands(ref Game.TableStruct, ref Game.DeckStruct);

            //Format the pictureboxes to diplay the cards
            FormatCard(pbDC1, 5, 3);
            FormatCard(pbDC2, 20, 3);
            FormatCard(pbPL1C1, 5, 3);
            FormatCard(pbPL1C2, 20, 3);
            FormatCard(pbPL2C1, 5, 3);
            FormatCard(pbPL2C2, 20, 3);
            
            //Adds the picturebox controls tot he panel controls
            panelDlrCards.Controls.Add(pbDC1);
            panelDlrCards.Controls.Add(pbDC2);
            panelP1Cards.Controls.Add(pbPL1C1);
            panelP1Cards.Controls.Add(pbPL1C2);
            panelP2Cards.Controls.Add(pbPL2C1);
            panelP2Cards.Controls.Add(pbPL2C2);

            //Display dealer cards - first card is face down
            ShowCard("b2fv", pbDC1);
            ShowCard(this.BJgame.gameTable.dealer.playerHand.cards[1].abbr, pbDC2);
            lblDealerCount.Text = "";
            for (int i = 0; i < this.BJgame.gameTable.NO_OF_PLAYERS; i++) { 

            //Display the cards for all players 
                switch (i) {
                    case 0:
                        ShowCard(this.BJgame.gameTable.players[i].playerHand.cards[0].abbr, pbPL1C1);
                        ShowCard(this.BJgame.gameTable.players[i].playerHand.cards[1].abbr, pbPL1C2);
                        lblP1Count.Text = this.BJgame.gameTable.players[i].playerHand.score.ToString();
                        btnP1Hit.Enabled = true;
                        btnP1Stay.Enabled = true;
                        btnBetP1Inc.Enabled = false;
                        btnBetP1Dec.Enabled = false;
                        break;
                    case 1:
                        this.panelPlayer2.Visible = true;
                        ShowCard(this.BJgame.gameTable.players[i].playerHand.cards[0].abbr, pbPL2C1);
                        ShowCard(this.BJgame.gameTable.players[i].playerHand.cards[1].abbr, pbPL2C2);
                        lblP2Count.Text = this.BJgame.gameTable.players[i].playerHand.score.ToString();
                        //btnP2Hit.Enabled = true;
                        //btnP2Stay.Enabled = true;
                        btnBetP2Inc.Enabled = false;
                        btnBetP2Dec.Enabled = false;
                        break;                  
                }
            }
            
            btnDeal.Enabled = false;
            lblCardCount.Text = this.BJgame.gameDeck.cards_left.ToString();
        }//End btnDeal_Click
     
        private void label1_Click(object sender, EventArgs e) { }
        private void DisplayHand_Load(object sender, EventArgs e) {
            GetBetsALL(false);
        }

        private void GetBetsALL(bool dealing) {

            for (int i = 0; i < this.BJgame.gameTable.NO_OF_PLAYERS; i++) { 
            //Initialize the total chip count and the default bet for each player

                //Players.Add(new DealCards2.player());
                //Players[i].Position = i;
                switch (i) {
                    case 0:
                        GetBet(txtP1Chips, txtP1Bet, this.BJgame.gameTable.players[i], dealing);
                        continue;
                    case 1:
                        panelPlayer2.Visible = true;
                        GetBet(txtP2Chips, txtP2Bet, this.BJgame.gameTable.players[i], dealing);
                        continue;
                        /***************for when 4 players implemented***************
                        case 2:
                            panelPlayer3.Visible = true;
                            GetBet(txtP3Chips, txtP3Bet, this.BJgame.gameTable.players[i]);
                            continue;
                        case 3:
                            panelPlayer4.Visible = true;
                            GetBet(txtP4Chips, txtP4Bet, this.BJgame.gameTable.players[i]);
                            continue;
                        */
                }//end switch
            }//end for loop
        }

        private void GetBet(Label txtChips, TextBox txtBet, GameState.Game.Table.Player Player, bool dealing) {

            int bet = int.Parse(txtBet.Text);
            int chips = Player.chips;
            chips -= bet;
            txtChips.Text = chips.ToString();

            if (dealing) {
                Player.playerHand.bet = bet;
                Player.chips = chips;
            }
        }

        private void label2_Click(object sender, EventArgs e) {}

        private void btnBetP1Inc_Click(object sender, EventArgs e) {
            //increase the bet
            int ChipValue = int.Parse(txtP1Chips.Text);
            int Bet = int.Parse(txtP1Bet.Text);
            if (ChipValue -5 > 0) {
                txtP1Bet.Text = (Bet + 5).ToString();
                txtP1Chips.Text = (ChipValue - 5).ToString();
            }
        }

        private void btnBetP1Dec_Click(object sender, EventArgs e) {   
            //decrease the bet
            int ChipValue = int.Parse(txtP1Chips.Text);
            int Bet = int.Parse(txtP1Bet.Text);
            if (Bet - 5 > 0) {
                txtP1Bet.Text = (Bet - 5).ToString();
                txtP1Chips.Text = (ChipValue + 5).ToString();
            }
        }

        private void grpPlayer2_Enter(object sender, EventArgs e){}

        private void btnP1Hit_Click(object sender, EventArgs e) {
            //Called from Hit button for the first player

            Game.Table.Player Player = this.BJgame.gameTable.players[0];

            Hit(Player, panelP1Cards, lblP1Count, btnP1Hit, btnP1Stay);

            if (Player.playerHand.hasEnded) {

                //if there's a player 2 left to play
                if (Player.pos == (this.BJgame.gameTable.NO_OF_PLAYERS)) {
                    this.DealerHand();
                }
                else {
                    btnP2Hit.Enabled = true;
                    btnP2Stay.Enabled = true;
                }
            }
        }

        private void btnP2Hit_Click(object sender, EventArgs e) {
            //Called from Hit button for the first player

            Game.Table.Player Player = this.BJgame.gameTable.players[1];

            Hit(Player, panelP2Cards, lblP2Count, btnP2Hit, btnP1Stay);

            if (Player.playerHand.hasEnded) {
                if (Player.pos == (this.BJgame.gameTable.NO_OF_PLAYERS)) {
                    this.DealerHand();
                }
            }
        }

        private void Hit(Game.Table.Player Player, Panel PlayerCards, Label lblCount, Button btnHit, Button btnStay) {

            //Called for the player hit buttons to draw a card
            int X = 20;
            Game.Table.Player.Hand h;
            byte hit = (byte)'h';

            BJinterface.DLLplayerTurn(ref Game.TableStruct, ref Game.DeckStruct, hit);

            h = this.BJgame.gameTable.players[Player.pos - 1].playerHand;

            PictureBox CardBox = new PictureBox();

            //format picture box for the new card
            CardBox.Width = 72;
            CardBox.Height = 94;
            CardBox.SizeMode = PictureBoxSizeMode.StretchImage;
            CardBox.Location = new Point(X + ((h.cardCount - 2) * 15), 3);
            PlayerCards.Controls.Add(CardBox);

            ShowCard(h.cards[h.cardCount - 1].abbr, CardBox);

            lblCount.Text = h.score.ToString();
            if (h.bust) {
                lblCount.Text += " Busted";
            }
            if (h.hasEnded) {
                btnHit.Enabled = false;
                btnStay.Enabled = false;
            }
            lblCardCount.Text = this.BJgame.gameDeck.cards_left.ToString();
        }
        private void DealerHand() {

            //After the last player's hand is done, DealerHand is called to show and complete the dealers hand
            int X = 20;
            Game.Table.Player Dealer = this.BJgame.gameTable.dealer;

            BJinterface.DLLdealerTurn(ref Game.TableStruct, ref Game.DeckStruct);
            Dealer = this.BJgame.gameTable.dealer;

            //show the dealer's starting cards
            ShowCard(Dealer.playerHand.cards[0].abbr, pbDC1);
            ShowCard(Dealer.playerHand.cards[1].abbr, pbDC2);

            for  (int i = 2; i < Dealer.playerHand.cardCount; i++) {

                PictureBox DealerBox = new PictureBox();
                DealerBox.Width = 72;
                DealerBox.Height = 94;
                DealerBox.SizeMode = PictureBoxSizeMode.StretchImage;
                DealerBox.Location = new Point(X + ((i - 1) * 15), 3);
                panelDlrCards.Controls.Add(DealerBox);

                ShowCard(Dealer.playerHand.cards[i].abbr, DealerBox);

            }
            lblDealerCount.Text = Dealer.playerHand.score.ToString();
            btnClear.Enabled = true;

            BJinterface.DLLtakeScores(ref Game.TableStruct);

            for (int i = 0; i < this.BJgame.gameTable.NO_OF_PLAYERS; i++) {

                //reset buttons and text
                switch (i) {
                    case 0:
                        txtP1Chips.Text = this.BJgame.gameTable.players[i].chips.ToString();
                        btnBetP1Inc.Enabled = false;
                        btnBetP1Dec.Enabled = false;
                        break;
                    case 1:     
                        txtP2Chips.Text = this.BJgame.gameTable.players[i].chips.ToString();
                        btnBetP2Inc.Enabled = false;
                        btnBetP2Dec.Enabled = false;
                        break;
                }
            }
            
            lblCardCount.Text = this.BJgame.gameDeck.cards_left.ToString();
        }

        private void ShowCard(string v, Control control) { }

        private void btnP2Inc_Click(object sender, EventArgs e) {
            //Increases bet for the second player
            int ChipValue = int.Parse(txtP2Chips.Text);
            int Bet = int.Parse(txtP2Bet.Text);
            if (ChipValue - 5 > 0) {
                txtP2Bet.Text = (Bet + 5).ToString();
                txtP2Chips.Text = (ChipValue - 5).ToString();
            }
        }

        private void btnP2Dec_Click(object sender, EventArgs e) {

            //Decreases bet for the second player
            int ChipValue = int.Parse(txtP2Chips.Text);
            int Bet = int.Parse(txtP2Bet.Text);
            if (Bet - 5 > 0) {
                txtP2Bet.Text = (Bet - 5).ToString();
                txtP2Chips.Text = (ChipValue + 5).ToString();
            }
        }

        private void btnP1Stay_Click(object sender, EventArgs e) {

            BJinterface.DLLplayerTurn(ref Game.TableStruct, ref Game.DeckStruct, (byte)'s');

            //Called from Stay button for first player
            btnP1Hit.Enabled = false;
            btnP1Stay.Enabled = false;

            if (this.BJgame.gameTable.NO_OF_PLAYERS > 1) {
                btnP2Hit.Enabled = true;
                btnP2Stay.Enabled = true;
            }
            else {
                //If there is not second player go to DealerHand
                DealerHand();
            }
        }

        private void btnP2Stay_Click(object sender, EventArgs e) {

            BJinterface.DLLplayerTurn(ref Game.TableStruct, ref Game.DeckStruct, (byte)'s');

            //Called from Stay button for second player
            btnP2Hit.Enabled = false;
            btnP2Stay.Enabled = false;
            DealerHand();
        } 

        private void pbDC3_Click(object sender, EventArgs e) { }
        
        private void btnClear_Click(object sender, EventArgs e) {

            //Clears the table and allows players to set bets for next hand

            panelDlrCards.Controls.Clear();
            panelP1Cards.Controls.Clear();
            panelP2Cards.Controls.Clear();
            lblDealerCount.Text = "";
            lblP1Count.Text = "";

            BJinterface.DLLclearTable(ref Game.TableStruct);

            GetBetsALL(false);

            btnDeal.Enabled = true;
            btnBetP1Inc.Enabled = true;
            btnBetP1Dec.Enabled = true;
            btnBetP2Inc.Enabled = true;
            btnBetP2Dec.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        
        private void lblP2Count_Click(object sender, EventArgs e) { }

        private void txtPlayer1_TextChanged(object sender, EventArgs e) {}

        private void DisplayHand_FormClosed(object sender, FormClosedEventArgs e) {

            BJinterface.DLLcleanUp(ref Game.TableStruct, ref Game.DeckStruct);
            Application.Exit();
        }

        private void lblPlayer_Click(object sender, EventArgs e) {

        }

        private void panelP1Cards_Paint(object sender, PaintEventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void lblPlayer1_Click(object sender, EventArgs e) {

        }

        private void panelPlayer2_Paint(object sender, PaintEventArgs e) {

        }

        private void lblDealerCount_Click(object sender, EventArgs e) {

        }

        private void lblCardCount_Click(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void panel4_Paint(object sender, PaintEventArgs e) {

        }

        private void panel6_Paint(object sender, PaintEventArgs e) {

        }

        private void txtP1Chips_Click(object sender, EventArgs e) {

        }

        private void panel11_Paint(object sender, PaintEventArgs e) {

        }

        private void label3_Click_1(object sender, EventArgs e) {

        }
    }
}
    

