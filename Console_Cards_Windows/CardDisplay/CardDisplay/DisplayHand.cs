using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardDisplay {

    public partial class DisplayHand : Form {

        public DisplayHand() {
            InitializeComponent();
            //this.Invalidate();
        }

        private int X1 = 60;
        private int X2 = 70; 
        private int Y1 = 20;
        private int Y2 = 90;
        private int Y3 = 160;
        private string DCard1;
        private string DCard2; 
        private string P1Card1;
        private string P1Card2;
        private string P2Card1;
        private string P2Card2;

        private void DisplayHand_Paint(object sender, PaintEventArgs e) {
            // Declares the Graphics object and sets it to the Graphics object
            Graphics g = e.Graphics;
            //x = 30;
            //y = 40;
            if (DCard1 != null) {
                DrawCard(g, DCard1, X1, Y1);
                DrawCard(g, DCard2, X2, Y1);
                DrawCard(g, P1Card1, X1, Y2);
                DrawCard(g, P1Card2, X2, Y2);
                DrawCard(g, P2Card1, X1, Y3);
                DrawCard(g, P2Card2, X2, Y3);
            }
            //x = 40;
            //DrawCard(g, Card2, x, y);
        }

        private void DrawCard(Graphics g, string Card,int x, int y) {
            string FileName = System.Windows.Forms.Application.StartupPath + "\\cards_gif\\" + Card + ".gif";
            Image Card_image1 = Image.FromFile(FileName);
            g.DrawImage(Card_image1, x, y, 46, 64);
        }

        private void button1_Click_1(object sender, EventArgs e) {
            DCard1 = "b2fv";
            DCard2= "dj";
            P1Card1= "sq";
            P1Card2 = "h4";
            P2Card1 = "dA";
            P2Card2 = "ct";
            this.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}
