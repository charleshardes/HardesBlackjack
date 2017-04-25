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
using System.Globalization;
using HelloDLL;


namespace CardDisplay
{

    public partial class DisplayHand : Form
    {

        public DisplayHand(int NO_OF_PLAYERS, int NO_OF_COMPS, string[] players)
        {

            InitializeComponent();
            this.BJgame = new Game(NO_OF_PLAYERS, NO_OF_COMPS, players);
            
            CardPositions.Add(new CardPosition() { Location = new Point { X = 200, Y = 235 }, Rotation = 0, Translation = 0 });
            CardPositions.Add(new CardPosition() { Location = new Point { X = 620, Y = 310 }, Rotation = 0, Translation = 0 });
            CardPositions.Add(new CardPosition() { Location = new Point { X = 450, Y = 345 }, Rotation = 0, Translation = 0 });
            CardPositions.Add(new CardPosition() { Location = new Point { X = 260, Y = 310 }, Rotation = 0, Translation = 0 });
            CardPositions.Add(new CardPosition() { Location = new Point { X = 600, Y = 235 }, Rotation = 0, Translation = 0 });
            
            switch (NO_OF_PLAYERS)
            {
                case 1:
                    this.panelChair3.Visible = true;
                    //PlayerChairs.Add(new Chair() { Hit = this.btnHit3, Stay = this.btnStay3, Bet = this.txtBet3, Chips = this.lblChips3, Count = this.lblCount3, BetInc = this.btnBetInc3, BetDec = this.btnBetDec3, Player = this.BJgame.gameTable.players[0], CardPosition = CardPositions[2]});
                    lblPlayer3.Text = BJgame.gameTable.players[0].name;
                    Chair3 = new Chair() { Hit= this.btnHit3, Stay = this.btnStay3, Bet = this.txtBet3, Chips = this.lblChips3, Count = this.lblCount3, BetInc = this.btnBetInc3, BetDec = this.btnBetDec3, Player = this.BJgame.gameTable.players[0], CardPosition = CardPositions[2] };
                    PlayerChairs.Add(Chair3);
                    break;  
                case 2:
                    this.panelChair3.Visible = true;
                    this.panelChair4.Visible = true;
                    Chair3 = new Chair() { Hit = this.btnHit3, Stay = this.btnStay3, Bet = this.txtBet3, Chips = this.lblChips3, Count = this.lblCount3, BetInc = this.btnBetInc3, BetDec = this.btnBetDec3, Player = this.BJgame.gameTable.players[0], CardPosition = CardPositions[2] };
                    lblPlayer3.Text = BJgame.gameTable.players[0].name;
                    PlayerChairs.Add(Chair3);
                    Chair4 = new Chair() { Hit = this.btnHit4, Stay = this.btnStay4, Bet = this.txtBet4, Chips = this.lblChips4, Count = this.lblCount4, BetInc = this.btnBetInc4, BetDec = this.btnBetDec4, Player = this.BJgame.gameTable.players[1], CardPosition = CardPositions[3] };
                    lblPlayer4.Text = BJgame.gameTable.players[1].name;
                    PlayerChairs.Add(Chair4);
                    break;
                case 3:
                    this.panelChair2.Visible = true;
                    this.panelChair3.Visible = true;
                    this.panelChair4.Visible = true;
                    Chair2 = new Chair() { Hit = this.btnHit2, Stay = this.btnStay2, Bet = this.txtBet2, Chips = this.lblChips2, Count = this.lblCount2, BetInc = this.btnBetInc2, BetDec = this.btnBetDec2, Player = this.BJgame.gameTable.players[0], CardPosition = CardPositions[1] };
                    lblPlayer2.Text = BJgame.gameTable.players[0].name;
                    PlayerChairs.Add(Chair2);
                    Chair3 = new Chair() { Hit = this.btnHit3, Stay = this.btnStay3, Bet = this.txtBet3, Chips = this.lblChips3, Count = this.lblCount3, BetInc = this.btnBetInc3, BetDec = this.btnBetDec3, Player = this.BJgame.gameTable.players[0], CardPosition = CardPositions[2] };
                    lblPlayer3.Text = BJgame.gameTable.players[1].name;
                    PlayerChairs.Add(Chair3);
                    Chair4 = new Chair() { Hit = this.btnHit4, Stay = this.btnStay4, Bet = this.txtBet4, Chips = this.lblChips4, Count = this.lblCount4, BetInc = this.btnBetInc4, BetDec = this.btnBetDec4, Player = this.BJgame.gameTable.players[1], CardPosition = CardPositions[3] };
                    lblPlayer4.Text = BJgame.gameTable.players[2].name;
                    PlayerChairs.Add(Chair4);
                    break;
            }
        }

        public Game BJgame;
        //public PlayerTablePosition PlrTablePos;
        public List<Chair> PlayerChairs = new List<Chair>();
        public Chair Chair1 = new Chair();
        public Chair Chair2 = new Chair();
        public Chair Chair3 = new Chair();
        public Chair Chair4 = new Chair();
        public Chair Chair5 = new Chair();

        public const int MAX_NUM_PLAYERS = 5;
        public List<CardPosition> CardPositions = new List<CardPosition>();

        public class Chair
        {
            public Button Hit { get; set; }
            public Button Stay { get; set; }
            public TextBox Bet { get; set; }
            public Label Chips { get; set; }
            public Label Count { get; set; }
            public Button BetInc { get; set; }
            public Button BetDec { get; set; }
            public Game.Table.Player Player { get; set; }
            public CardPosition CardPosition { get; set; }
        }
        public class CardPosition
        {
            public Point Location { get; set; }
            public float Rotation { get; set; }
            public float Translation { get; set; }
        }
        private void DisplayHand_Paint(object sender, PaintEventArgs e)
        {

            // Declares the Graphics object and sets it to the Graphics object
            
            Graphics g = e.Graphics;
            if (BJgame.gameTable.handsAreDealt)
            {
                Deal_Hand(g);
            }
            g.Dispose();
        }

        private void DrawCard(Graphics g, string Card, int x, int y, float Rotate, float Translate)
        {
            string FileName = System.Windows.Forms.Application.StartupPath + "\\cards_gif\\" + Card + ".gif";
            Image Card_image1 = Image.FromFile(FileName);
            g.TranslateTransform(Translate, 0.0F);
            g.RotateTransform(Rotate);
            g.DrawImage(Card_image1, x, y, 59, 80);  //71,96
        }
        
        private void Deal_Hand(Graphics g)
        {
            if (this.BJgame.gameTable.dealer.playerHand.cards[0].shown)
            {
                DrawCard(g, this.BJgame.gameTable.dealer.playerHand.cards[0].abbr, 460, 30, 0, 0);
            }
            else
            {
                DrawCard(g, "b2fv", 460, 30, 0, 0); //First card face down
            }
                DrawCard(g, this.BJgame.gameTable.dealer.playerHand.cards[1].abbr, 473, 30, 0, 0);
            for (int r = 2; r < this.BJgame.gameTable.dealer.playerHand.cardCount; r++)
            {
                DrawCard(g, this.BJgame.gameTable.dealer.playerHand.cards[r].abbr, 473 + (((r + 1) - 2) * 13), 30, 0, 0);
            }

            for (int i = 0; i < this.BJgame.gameTable.NO_OF_PLAYERS; i++)
            {
                //Display the cards for all players 
                
                int X_Spaces = 13;
                DrawCard(g, this.BJgame.gameTable.players[i].playerHand.cards[0].abbr, this.PlayerChairs[i].CardPosition.Location.X, this.PlayerChairs[i].CardPosition.Location.Y, this.PlayerChairs[i].CardPosition.Rotation, this.PlayerChairs[i].CardPosition.Translation); //100,230,25,100                                                                                                                                                                                                                                                                        //DrawCard(g, this.BJgame.gameTable.players[i].playerHand.cards[1].abbr, this.PlrTablePos.Locations[i].CardLocation.X, this.PlrTablePos.Locations[i].CardLocation.Y, 0, 0); //100,230,25,100
                for (int r = 1; r < this.BJgame.gameTable.players[i].playerHand.cardCount; r++)
                {
                    DrawCard(g, this.BJgame.gameTable.players[i].playerHand.cards[r].abbr, this.PlayerChairs[i].CardPosition.Location.X + (r * X_Spaces), this.PlayerChairs[i].CardPosition.Location.Y, 0, 0); //100,230,25,100
                }
            }
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


            lblDealerCount.Text = "";
            for (int i = 0; i < this.BJgame.gameTable.NO_OF_PLAYERS; i++)
            {

                //Display the cards for all players 
                switch (i)
                {
                    case 0:
                        PlayerChairs[i].Count.Text = this.BJgame.gameTable.players[i].playerHand.score.ToString();
                        PlayerChairs[i].Hit.Enabled = true;
                        PlayerChairs[i].Stay.Enabled = true;
                        PlayerChairs[i].BetInc.Enabled = false;
                        PlayerChairs[i].BetDec.Enabled = false;
                        break;
                    case 1:
                        PlayerChairs[i].Count.Text = this.BJgame.gameTable.players[i].playerHand.score.ToString();
                        //PlayerChairs[i].Hit.Enabled = true;
                        //PlayerChairs[i].Stay.Enabled = true;
                        PlayerChairs[i].BetInc.Enabled = false;
                        PlayerChairs[i].BetDec.Enabled = false;
                        break;
                    case 2:
                        PlayerChairs[i].Count.Text = this.BJgame.gameTable.players[i].playerHand.score.ToString();
                        //PlayerChairs[i].Hit.Enabled = true;
                        //PlayerChairs[i].Stay.Enabled = true;
                        PlayerChairs[i].BetInc.Enabled = false;
                        PlayerChairs[i].BetDec.Enabled = false;
                        break;
                }
            }
            btnDeal.Enabled = false;
            lblCardCount.Text = this.BJgame.gameDeck.cards_left.ToString();
            this.Invalidate();
        }//End btnDeal_Click

            private void label1_Click(object sender, EventArgs e) { }

            private void DisplayHand_Load(object sender, EventArgs e)
            {
               // GetBetsALL(false);
            }
            private void GetBetsALL(bool dealing)
            {

                for (int i = 0; i < this.BJgame.gameTable.NO_OF_PLAYERS; i++)
                {
                    //Initialize the total chip count and the default bet for each player

                    //Players.Add(new DealCards2.player());
                    //Players[i].Position = i;
                    switch (i)
                    {
                        case 0:
                            GetBet(PlayerChairs[0].Chips,PlayerChairs[0].Bet, this.BJgame.gameTable.players[i], dealing);
                            continue;
                        case 1:
                            //panelChair4.Visible = true;
                            GetBet(PlayerChairs[1].Chips, PlayerChairs[1].Bet, this.BJgame.gameTable.players[i], dealing);
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

            private void GetBet(Label txtChips, TextBox txtBet, GameState.Game.Table.Player Player, bool dealing)
            {

                int bet = int.Parse(txtBet.Text);
                int chips = Player.chips;
                chips -= bet;
                txtChips.Text = chips.ToString();

                if (dealing)
                {
                    Player.playerHand.bet = bet;
                    Player.chips = chips;
                }
            }

            private void label2_Click(object sender, EventArgs e) { }

            private void btnBetInc3_Click(object sender, EventArgs e)
            {
            //increase the bet
            
                
                int ChipValue = int.Parse(lblChips3.Text, NumberStyles.Currency);
                int Bet = int.Parse(txtBet3.Text);
                if (ChipValue - 5 > 0)
                {
                    txtBet3.Text = (Bet + 5).ToString();
                    lblChips3.Text = (ChipValue - 5).ToString("C0");
                }
            }

            private void btnBetDec3_Click(object sender, EventArgs e)
            {
                //decrease the bet
                int ChipValue = int.Parse(lblChips3.Text, NumberStyles.Currency);
                int Bet = int.Parse(txtBet3.Text);
                if (Bet - 5 > 0)
                {
                    txtBet3.Text = (Bet - 5).ToString();
                    lblChips3.Text = (ChipValue + 5).ToString("C0");
                    
                }
            }

            private void grpPlayer2_Enter(object sender, EventArgs e) { }

            private void btnHit1_Click(object sender, EventArgs e)
            {
                //Called from Hit button for the first player

                Hit(Chair1.Player, Chair1.Count, Chair1.Hit, Chair1.Stay);

                if (Chair1.Player.playerHand.hasEnded)
                {
                    if (Chair1.Player.pos == (this.BJgame.gameTable.NO_OF_PLAYERS))
                    {
                        this.DealerHand();
                    }
                    else
                    {
                        Chair2.Hit.Enabled = true;
                        Chair2.Stay.Enabled = true;
                    }
                }
                this.Invalidate();
            }

            private void btnHit2_Click(object sender, EventArgs e)
            {
                //Called from Hit button for the first player

                //Game.Table.Player Player = this.BJgame.gameTable.players[0];

                //Hit(Player, lblCount2, btnHit2, btnStay2);
                Hit(Chair2.Player, Chair2.Count, Chair2.Hit, Chair2.Stay);

                if (Chair2.Player.playerHand.hasEnded)
                {
                    if (Chair2.Player.pos == (this.BJgame.gameTable.NO_OF_PLAYERS))
                    {   
                        this.DealerHand();
                    }
                    else
                    {
                        Chair3.Hit.Enabled = true;
                        Chair3.Stay.Enabled = true;
                    }
                }
                this.Invalidate();
            }

            private void Hit(Game.Table.Player Player, Label lblCount, Button btnHit, Button btnStay)
            {

                //Called for the player hit buttons to draw a card
                //int X = 20;
                Game.Table.Player.Hand h;
                byte hit = (byte)'h';

                BJinterface.DLLplayerTurn(ref Game.TableStruct, ref Game.DeckStruct, hit);

                h = this.BJgame.gameTable.players[Player.pos - 1].playerHand;


                lblCount.Text = h.score.ToString();
                if (h.bust)
                {
                    lblCount.Text += " Busted";
                }
                if (h.hasEnded)
                {
                    btnHit.Enabled = false;
                    btnStay.Enabled = false;
                }
                lblCardCount.Text = this.BJgame.gameDeck.cards_left.ToString();
                this.Invalidate();
            }
            


            private void DealerHand()
            {

                //After the last player's hand is done, DealerHand is called to show and complete the dealers hand
                //int X = 20;
                Game.Table.Player Dealer = this.BJgame.gameTable.dealer;

                BJinterface.DLLdealerTurn(ref Game.TableStruct, ref Game.DeckStruct);
                Dealer = this.BJgame.gameTable.dealer;


                lblDealerCount.Text = Dealer.playerHand.score.ToString();
                btnClear.Enabled = true;

                BJinterface.DLLtakeScores(ref Game.TableStruct);

                for (int i = 0; i < this.BJgame.gameTable.NO_OF_PLAYERS; i++)
                {

                    //reset buttons and text
                    switch (i)
                    {
                        case 0:
                            lblChips3.Text = this.BJgame.gameTable.players[i].chips.ToString();
                            btnBetInc3.Enabled = false;
                            btnBetDec3.Enabled = false;
                            break;
                        case 1:
                            lblChips4.Text = this.BJgame.gameTable.players[i].chips.ToString();
                            btnBetInc4.Enabled = false;
                            btnBetDec4.Enabled = false;
                            break;
                    }
                }

                lblCardCount.Text = this.BJgame.gameDeck.cards_left.ToString();
            }
            private void btnBetInc2_Click(object sender, EventArgs e)
            {
                //Increases bet for the second player
                int ChipValue = int.Parse(lblChips2.Text);
                int Bet = int.Parse(txtBet2.Text);
                if (ChipValue - 5 > 0)
                {
                    txtBet2.Text = (Bet + 5).ToString();
                    lblChips2.Text = (ChipValue - 5).ToString();
                }
            }
            private void btnBetDec2_Click(object sender, EventArgs e)
            {

                //Decreases bet for the second player
                int ChipValue = int.Parse(lblChips2.Text);
                int Bet = int.Parse(txtBet2.Text);
                if (Bet - 5 > 0)
                {
                    txtBet2.Text = (Bet - 5).ToString();
                    lblChips2.Text = (ChipValue + 5).ToString();
                }
            }
        private void btnStay1_Click(object sender, EventArgs e)
        {

            BJinterface.DLLplayerTurn(ref Game.TableStruct, ref Game.DeckStruct, (byte)'s');

            Chair1.Hit.Enabled = false;
            Chair1.Stay.Enabled = false;

            if (Chair1.Player.pos < (this.BJgame.gameTable.NO_OF_PLAYERS))
            {
                btnHit2.Enabled = true;
                btnStay2.Enabled = true;
            }
            else
            {
                //If there is not another player go to DealerHand
                DealerHand();
            }
            this.Invalidate();
        }

        private void btnStay2_Click(object sender, EventArgs e)
        {

            BJinterface.DLLplayerTurn(ref Game.TableStruct, ref Game.DeckStruct, (byte)'s');

            Chair2.Hit.Enabled = false;
            Chair2.Stay.Enabled = false;

            if (Chair2.Player.pos < (this.BJgame.gameTable.NO_OF_PLAYERS)) 
            {
                btnHit3.Enabled = true;
                btnStay3.Enabled = true;
            }
            else
            {
                //If there is not another player go to DealerHand
                DealerHand();
            }
            this.Invalidate();
        }

        private void btnStay4_Click(object sender, EventArgs e)
        {

            BJinterface.DLLplayerTurn(ref Game.TableStruct, ref Game.DeckStruct, (byte)'s');

            Chair4.Hit.Enabled = false;
            Chair4.Stay.Enabled = false;    
             
            if (Chair4.Player.pos < (this.BJgame.gameTable.NO_OF_PLAYERS)) 
            {
                btnHit5.Enabled = true;
                btnStay5.Enabled = true;
            }
            else
            {
                //If there is not another player go to DealerHand
                DealerHand();
            }
            this.Invalidate();
        }
        private void btnClear_Click(object sender, EventArgs e)
            {

                //Clears the table and allows players to set bets for next hand

                lblDealerCount.Text = "";
                //lblCount3.Text = "";

                BJinterface.DLLclearTable(ref Game.TableStruct);

                GetBetsALL(false);

                btnDeal.Enabled = true;
                btnClear.Enabled = false;
                for (int i =0; i< PlayerChairs.Count; i++)
                {
                    PlayerChairs[i].BetInc.Enabled = true;
                    PlayerChairs[i].BetDec.Enabled = true;
                    PlayerChairs[i].Count.Text = "";
                }
                
                this.Invalidate();
            }

            private void DisplayHand_FormClosed(object sender, FormClosedEventArgs e)
            {

                BJinterface.DLLcleanUp(ref Game.TableStruct, ref Game.DeckStruct);
                Application.Exit();
            }

            private void panelP1Cards_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                if (BJgame.gameTable.handsAreDealt)
                {
                    //DrawCard(g, this.BJgame.gameTable.players[0].playerHand.cards[0].abbr, panelP1Cards.Location.X, panelP1Cards.Location.X);
                };

            }
             private void panelP1Cards2_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                if (BJgame.gameTable.handsAreDealt)
                {
                    //DrawCard(this.BJgame.gameTable.players[0].playerHand.cards[0].abbr, panelP1Cards2.Location.X, panelP1Cards.Location.X,0);
                };
            }

            private void btnHit3_Click(object sender, EventArgs e)
            {
                //Called from Hit button for the first player

                Hit(Chair3.Player, Chair3.Count, Chair3.Hit, Chair3.Stay);

                if (Chair3.Player.playerHand.hasEnded)
                {
                    if (Chair3.Player.pos == (this.BJgame.gameTable.NO_OF_PLAYERS))
                    {
                        this.DealerHand();
                    }
                    else
                    {
                        Chair4.Hit.Enabled = true;
                        Chair4.Stay.Enabled = true;
                    }
                }
                this.Invalidate();
            }

        private void btnStay3_Click(object sender, EventArgs e)
        {
            BJinterface.DLLplayerTurn(ref Game.TableStruct, ref Game.DeckStruct, (byte)'s');

            Chair3.Hit.Enabled = false;
            Chair3.Stay.Enabled = false;

            if (Chair3.Player.pos < (this.BJgame.gameTable.NO_OF_PLAYERS))
            {
                btnHit4.Enabled = true;
                btnStay4.Enabled = true;
            }
            else
            {
                //If there is not another player go to DealerHand
                DealerHand();
            }
            this.Invalidate();
        }

        private void btnHit4_Click(object sender, EventArgs e)
        {
            //Called from Hit button for the first player

            Hit(Chair4.Player, Chair4.Count, Chair4.Hit, Chair4.Stay);

            if (Chair4.Player.playerHand.hasEnded)
            {
                if (Chair4.Player.pos == (this.BJgame.gameTable.NO_OF_PLAYERS))
                {
                    this.DealerHand();
                }
                else
                {
                    Chair5.Hit.Enabled = true;
                    Chair5.Stay.Enabled = true;
                }
            }
            this.Invalidate();
        }

    }
}
    

