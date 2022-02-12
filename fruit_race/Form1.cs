using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fruit_race
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int money;

        private void Form1_Load(object sender, EventArgs e)
        {
            money = 1000;
            label5.Text = money.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color[] remainingColors = { //All colors have a certain number of uses
            Color.Yellow,//0
            Color.Yellow,//1st index
            Color.Yellow,
            Color.Red,
            Color.Red,
            Color.Red,
            Color.Purple,
            Color.Purple,
            Color.Purple,//8
            Color.Orange,//9
        };
            Color[] referanceColors = {
            Color.Yellow,//0
            Color.Yellow,//1st index
            Color.Yellow,
            Color.Red,
            Color.Red,
            Color.Red,
            Color.Purple,
            Color.Purple,
            Color.Purple,//8
            Color.Orange,//9
        };

            int bet = Decimal.ToInt32(numericUpDown1.Value);

            if (bet <= money)
            {
                money -= bet;
                label5.Text = money.ToString();

                Random number = new Random(); //Creates a random function
                int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    int numberRand = number.Next(0, remainingColors.Length); //Makes a choice from the remaining colors
                    Panel pnl = this.Controls.Find("panel" + ((i + 1).ToString()), true).FirstOrDefault() as Panel; //Get each panel in turn
                    if (remainingColors[numberRand] == referanceColors[i])
                    {
                        count++;
                    }
                    pnl.BackColor = remainingColors[numberRand]; //Apply the color
                    remainingColors = remainingColors.Where((source, index) => index != numberRand).ToArray(); //Delete the applied color from array
                }
                label2.Text = count.ToString();

                if (count > 3 || panel10.BackColor == Color.Orange)
                {
                    money += bet * 2;
                    label5.Text = money.ToString();
                }
                else if (count == 3)
                {
                    money += bet;
                    label5.Text = money.ToString();
                }
            }
            else
            {
                MessageBox.Show("The budget cannot be less than the bet!");
            }
        }
    }
}