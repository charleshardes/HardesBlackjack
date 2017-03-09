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
            //this.Invalidate();

            this.BJgame = new Game(NO_OF_PLAYERS, NO_OF_COMPS, players);
        }

        /****************** REDUNDANT *************************************/
        public int NumPlayers {
            get { return iplayers; }
            set { iplayers = value; }
        }
        //I don't like this. Why make the Deck class a member of DisplayHand directly? I want the Game class
        //to be the member defined and instantiated here, which in itself will instantiate the Deck and Table
        //Structs from DLL. This will happen in GameState.cs in the Game class definition
        //private Game.Deck Deck = new Game.Deck(); //Game.Deck is class of TestCard2

        public Game BJgame;

        /******* REDUNDANT **********************************/
        //Deck of cards used until no cards left, 
        //when nuber of cards left in the deck is 1, a new instance will be created 
        private int iplayers; //number of players 
        IList<DealCards2.player> Players = new List<DealCards2.player>(); //list of players.  DealCards2.player is class of TestCard2
        private string NextCard;
        private DealCards2.dealer Dealer = new DealCards2.dealer();  //DealCards2.dealer is class of TestCard2


        private IList<PictureBox> DealerBoxes = new List<PictureBox>();
        //The following picture box objects are used to display the first two cards of a new game
        PictureBox pbDC1 = new PictureBox();
        PictureBox pbDC2 = new PictureBox();
        PictureBox pbPL1C1 = new PictureBox();
        PictureBox pbPL1C2 = new PictureBox();
        PictureBox pbPL2C1 = new PictureBox();
        PictureBox pbPL2C2 = new PictureBox();
        

        private void DisplayHand_Paint(object sender, PaintEventArgs e)
        {
            // Declares the Graphics object and sets it to the Graphics object
            // Currently not used, this could be used instead of picture boxes
            Graphics g = e.Graphics;
            //x = 30;
            //y = 40;
            //if (DCard1 != null)
            {
                //DrawCard(g, DCard1, X1, Y1);
                //DrawCard(g, DCard2, X2, Y1);
                //DrawCard(g, P1Card1, X1, Y2);
                //DrawCard(g, P1Card2, X2, Y2);
                //if (iplayers > 1)
                //{ 
                //    DrawCard(g, P2Card1, X1, Y3);
                //    DrawCard(g, P2Card2, X2, Y3);
                //} 
            }
            //x = 40;
            //DrawCard(g, Card2, x, y);
        }

        private void DrawCard(Graphics g, string Card,int x, int y)
        {
            //not used
            string FileName = System.Windows.Forms.Application.StartupPath + "\\cards_gif\\" + Card + ".gif";
            Image Card_image1 = Image.FromFile(FileName);
            g.DrawImage(Card_image1, x, y, 46, 64);
        }

        private void ShowCard(string Card, PictureBox myPictureBox)
        {
            //called everytime is card is displayed

            if (Card.Length <= 2) {

                //modify the string to match the GIF file
                char[] charArray = Card.ToCharArray();
                Array.Reverse(charArray);
                if (charArray[0] == 't' || charArray[0] == 'j' || charArray[0] == 'q' || charArray[0] == 'k' || charArray[0] == 'a') {
                    charArray[0] = Char.ToUpper(charArray[0]);
                }
                Card = new string(charArray);
            }

            string FileName = System.Windows.Forms.Application.StartupPath + "\\cards_gif\\" + Card + ".gif";
            Image Card_image1 = Image.FromFile(FileName);
            myPictureBox.Image = Card_image1;
            myPictureBox.Visible = true;
            myPictureBox.BringToFront();
            myPictureBox.Invalidate();
        }

/*
        private void Deal_A_Card(DealCards2.player Player)
        {
            //As cards are being added cards are being added to the players' cards (hand)
            if (Game.Deck.cards_left < 2)
            {
                Game.Deck = new HelloDLL.deck();
            }
            Player.Cards.Add(Game.Deck.top);
        }
        private void Deal_A_Card(DealCards2.dealer Dealer)
        {
            //As cards are being added cards are being added to the dealers' cards (hand)
            if (Deck.CardsInDeck < 2)
            {
                Deck = new Game.Deck();
            }
            Dealer.Cards.Add(Deck.NextCard());
        }
*/
        private void FormatCard(PictureBox PictureBox, int X, int Y)
        {
            //Formats the picture box to the desired location on the form and the dimensions
            PictureBox.Location = new Point(X, Y);
            PictureBox.Width = 36;
            PictureBox.Height = 47;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            //This resets all player hands to their starting (not dealt a hand yet) state
            BJinterface.DLLsetAllHands(ref Game.TableStruct);

            //this gets the bet amount from the GUI, makes the applicable update to the player's hand class
            //moved this here from DisplayHand_Load(), it's more appropriate here.
            GetBetsALL();

            //This deals out the starting hands to all players and dealer
            BJinterface.DLLdealStartingHands(ref Game.TableStruct, ref Game.DeckStruct);

            /*
            for (int i = 0; i < iplayers; i++)
            {
                Players[i].Cards.Clear();
            }
            Dealer.Cards.Clear();
            for (int i = 0; i < iplayers; i++)
            //Deal first card
            {
                //Deal_A_Card(Players[i]);
            }
            //Deal_A_Card( Dealer);
            for (int i = 0; i < iplayers; i++)
            //Deal second card
            {
                //Deal_A_Card( Players[i]);
            }
            //Deal_A_Card( Dealer);
            */

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
            ShowCard(this.BJgame.gameTable.dealer.playerHand.cards[0].name, pbDC2);
            lblDealerCount.Text = "";
            for (int i = 0; i < this.BJgame.gameTable.NO_OF_PLAYERS; i++)
            //Display the cards for all players 
            {
                switch (i)
                {
                    case 0:
                        ShowCard(Players[i].Cards[0], pbPL1C1);
                        ShowCard(Players[i].Cards[1], pbPL1C2);
                        lblP1Count.Text = Players[0].Count.ToString();
                        btnP1Hit.Enabled = true;
                        btnStay.Enabled = true;
                        btnBetP1Inc.Enabled = false;
                        btnBetP1Dec.Enabled = false;
                        break;
                    case 1:
                        this.panelPlayer2.Visible = true;
                        ShowCard(Players[i].Cards[0], pbPL2C1);
                        ShowCard(Players[i].Cards[1], pbPL2C2);
                        lblP2Count.Text = Players[i].Count.ToString();
                        //btnP2Hit.Enabled = true;
                        //btnP2Stay.Enabled = true;
                        btnBetP2Inc.Enabled = false;
                        btnBetP2Dec.Enabled = false;
                        break;                  
                }
            }
            btnDeal.Enabled = false;
            lblCardCount.Text = Game.Deck.cards_left.ToString();
        }//End btnDeal_Click
     
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void DisplayHand_Load(object sender, EventArgs e) {
            GetBetsALL();
        }

        private void GetBetsALL() {

            for (int i = 0; i < this.BJgame.gameTable.NO_OF_PLAYERS; i++) { 
            //Initialize the total chip count and the default bet for each player

                //Players.Add(new DealCards2.player());
                //Players[i].Position = i;
                switch (i) {
                    case 0:
                        GetBet(txtP1Chips, txtP1Bet, this.BJgame.gameTable.players[i]);
                        continue;
                    case 1:
                        panelPlayer2.Visible = true;
                        GetBet(txtP2Chips, txtP2Bet, this.BJgame.gameTable.players[i]);
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

        private void GetBet(TextBox txtChips, TextBox txtBet, GameState.Game.Table.Player Player) {

            int bet = int.Parse(txtBet.Text);
            int chips = Player.chips;
            chips -= bet;
            Player.playerHand.bet = bet;
            Player.chips = chips;
            txtChips.Text = chips.ToString();
        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void btnBetP1Inc_Click(object sender, EventArgs e)
        {
            //increase the bet
            int ChipValue = int.Parse(txtP1Chips.Text);
            int Bet = int.Parse(txtP1Bet.Text);
            if (ChipValue -5 > 0)
            {
                txtP1Bet.Text = (Bet + 5).ToString();
                txtP1Chips.Text = (ChipValue - 5).ToString();
            }
        }

        private void btnBetP1Dec_Click(object sender, EventArgs e)
        {   
            //decrease the bet
            int ChipValue = int.Parse(txtP1Chips.Text);
            int Bet = int.Parse(txtP1Bet.Text);
            if (Bet - 5 > 0)
            {
                txtP1Bet.Text = (Bet - 5).ToString();
                txtP1Chips.Text = (ChipValue + 5).ToString();
            }
        }

        private void grpPlayer2_Enter(object sender, EventArgs e)
        {

        }

        private void btnP1Hit_Click(object sender, EventArgs e)
        {
            //Called from Hit button for the first player
            Hit(Players[0], panelP1Cards, lblP1Count, btnP1Hit, btnStay);
            if (Players[0].Count >= 21)
            {
                if (Players[0].Position == (iplayers - 1))
                {
                    this.DealerHand();
                }else
                {
                    btnP2Hit.Enabled = true;
                    btnP2Stay.Enabled = true;
                }
            }
            lblCardCount.Text = Game.Deck.cards_left.ToString();
        }

        private void Hit(DealCards2.player Player, Panel PlayerCards, Label lblCount, Button btnHit, Button btnStay)
        {
            //Called for the player hit buttons to draw a card
            int X = 20;
            int NumCards = Player.Cards.Count();

            PictureBox CardBox = new PictureBox();
            //picture box for the new card
            CardBox.Width = 36;
            CardBox.Height = 47;
            CardBox.SizeMode = PictureBoxSizeMode.StretchImage;
            CardBox.Location = new Point(X + ((NumCards - 1) * 15), 3);
            PlayerCards.Controls.Add(CardBox);
            //NextCard = Deck.NextCard();
            //calls the NextCard method of the Deck object to get the new card
            ShowCard(NextCard, CardBox);
            Player.Cards.Add(NextCard);
            int count = Player.Count;
            lblCount.Text = Player.Count.ToString();
            if (count > 21)
            {
                lblCount.Text += " Busted";
                btnHit.Enabled = false;
                btnStay.Enabled = false;
            }
            if (count >= 21)
            {
                btnHit.Enabled = false;
                btnStay.Enabled = false;
                if (Player.Position == (iplayers -1))
                {
                    this.DealerHand();
                }
            }
            lblCardCount.Text = Game.Deck.cards_left.ToString();
        }
        private void DealerHand()
        {
            //After the last player's hand is done, DealerHand is called to show and complete the dealers hand
            int X = 20;
            ShowCard(Dealer.Cards[0], pbDC1);
            ShowCard(Dealer.Cards[1], pbDC2);
            for  (int i = 0; (Dealer.Count < 17); i++)
            {
                PictureBox DealerBox = new PictureBox();
                DealerBox.Width = 36;
                DealerBox.Height = 47;
                DealerBox.SizeMode = PictureBoxSizeMode.StretchImage;
                DealerBox.Location = new Point(X + ((i+1) * 15), 3);
                panelDlrCards.Controls.Add(DealerBox);
                //NextCard = Deck.NextCard();
                ShowCard(NextCard, DealerBox);
                Dealer.Cards.Add(NextCard);
            }
            lblDealerCount.Text = Dealer.Count.ToString();
            btnClear.Enabled = true;
            for (int i = 0; i < iplayers; i++)
            {
                //Calculate the results for each player
                switch (i)
                {   case 0:
                        Players[i].Bet = int.Parse(txtP1Bet.Text);
                        txtP1Chips.Text = Players[i].CalcResult(Dealer.Count).ToString();
                        btnBetP1Inc.Enabled = false;
                        btnBetP1Dec.Enabled = false;
                        break;
                    case 1:     
                        Players[i].Bet = int.Parse(txtP2Bet.Text);
                        txtP2Chips.Text = Players[i].CalcResult(Dealer.Count).ToString();
                        btnBetP2Inc.Enabled = false;
                        btnBetP2Dec.Enabled = false;
                        break;
                }
            }
            
            lblCardCount.Text = Game.Deck.cards_left.ToString();
        }

        private void ShowCard(string v, Control control)
        {
            
        }

        private void btnP2Hit_Click(object sender, EventArgs e)
        {
            //Called from Hit button for the second player
            Hit(Players[1], panelP2Cards, lblP2Count, btnP2Hit, btnP2Stay);
            if (Players[0].Count >= 21)
            {
                if (Players[0].Position == (iplayers - 1))
                {
                    this.DealerHand();
                }
            }
            lblCardCount.Text = Game.Deck.cards_left.ToString();
        }

        private void btnP2Inc_Click(object sender, EventArgs e)
        {
            //Increases bet for the second player
            int ChipValue = int.Parse(txtP2Chips.Text);
            int Bet = int.Parse(txtP2Bet.Text);
            if (ChipValue - 5 > 0)
            {
                txtP2Bet.Text = (Bet + 5).ToString();
                txtP2Chips.Text = (ChipValue - 5).ToString();
            }
        }

        private void btnP2Dec_Click(object sender, EventArgs e)
        {
            //Decreases bet for the second player
            int ChipValue = int.Parse(txtP2Chips.Text);
            int Bet = int.Parse(txtP2Bet.Text);
            if (Bet - 5 > 0)
            {
                txtP2Bet.Text = (Bet - 5).ToString();
                txtP2Chips.Text = (ChipValue + 5).ToString();
            }
        }

        private void btnP1Stay_Click(object sender, EventArgs e)
        {
            //Called from Stay button for first player
            btnP1Hit.Enabled = false;
            btnStay.Enabled = false;
            if (Players.Count > 1)
            {
                btnP2Hit.Enabled = true;
                btnP2Stay.Enabled = true;
            }
            else
            {
                //If there is not second player go to DealerHand
                DealerHand();
            }
        }

        private void btnP2Stay_Click(object sender, EventArgs e)
        {
            //Called from Stay button for second player
            btnP2Hit.Enabled = false;
            btnP2Stay.Enabled = false;
            DealerHand();
        } 

        private void pbDC3_Click(object sender, EventArgs e) { }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clears the table and allows players to set bets for next hand
            Dealer.Cards.Clear();
            panelDlrCards.Controls.Clear();
            panelP1Cards.Controls.Clear();
            panelP2Cards.Controls.Clear();
            lblDealerCount.Text = "";
            lblP1Count.Text = "";

            int ChipValue = int.Parse(txtP1Chips.Text);
            Players[0].ChipBalance = ChipValue;
            int Bet = int.Parse(txtP1Bet.Text);
            ChipValue -= Bet;
            txtP1Chips.Text = ChipValue.ToString();
            if (iplayers > 1)
            {
                ChipValue = int.Parse(txtP2Chips.Text);
                Players[1].ChipBalance = ChipValue;
                Bet = int.Parse(txtP2Bet.Text);
                ChipValue -= Bet;
                txtP2Chips.Text = ChipValue.ToString();
                this.panelPlayer2.Visible = true;          
            }
            btnDeal.Enabled = true;
            btnBetP1Inc.Enabled = true;
            btnBetP1Dec.Enabled = true;
            btnBetP2Inc.Enabled = true;
            btnBetP2Dec.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        

        private void lblP2Count_Click(object sender, EventArgs e) { }

        private void txtPlayer1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayHand_FormClosed(object sender, FormClosedEventArgs e)
        {
            CardGame frm = new CardGame();
            frm.Show();
        }



        //this.Invalidate();
    }

    
        

        }
    

