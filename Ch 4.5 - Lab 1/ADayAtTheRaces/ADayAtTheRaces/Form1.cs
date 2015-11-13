using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public partial class Form1 : Form
    {
        Random MyRandomizer;
        Greyhound[] GreyhoundArray;
        Guy[] GuyArray;
        Guy CurrentGuy;

        public Form1()
        {
            InitializeComponent();

            MyRandomizer = new Random();

            GreyhoundArray = new Greyhound[4];
          
            GreyhoundArray[0] = new Greyhound() 
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RaceTrackLength = raceTrackPictureBox.Width - pictureBox1.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RaceTrackLength = raceTrackPictureBox.Width - pictureBox2.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RaceTrackLength = raceTrackPictureBox.Width - pictureBox3.Width,
                Randomizer = MyRandomizer
            };

            
            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RaceTrackLength = raceTrackPictureBox.Width - pictureBox4.Width,
                Randomizer = MyRandomizer
            };

            GuyArray = new Guy[3];

            GuyArray[0] = new Guy()
                {
                    Name ="Joe",
                    MyRadioButton = joeRadioButton, 
                    MyLabel = joeBetLabel,
                    Cash = 50
                };

            GuyArray[1] = new Guy()
                {
                    Name = "Bob", 
                    MyRadioButton = bobRadioButton, 
                    MyLabel = bobBetLabel,
                    Cash = 75
                };

            GuyArray[2] = new Guy()
                {
                    Name = "Al", 
                    MyRadioButton = alRadioButton, 
                    MyLabel = alBetLabel,
                    Cash = 45
                };

            for (int i = 0; i < GuyArray.Length; i++)
            {
                GuyArray[i].ClearBet();
                GuyArray[i].UpdateLabels();    
            }

            CurrentGuy = GuyArray[0];
            joeRadioButton.Checked = true;
            
            int minBet = 5;
            betAmount.Minimum = minBet;
            minimumBetLabel.Text = "Minimum bet: " + minBet + " bucks";

            dogNumber.Minimum = 1;
            dogNumber.Maximum = GreyhoundArray.Length;
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                CurrentGuy = GuyArray[0];
                UpdateControls();
            } 
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bobRadioButton.Checked)
            {
                CurrentGuy = GuyArray[1];
                UpdateControls();
            } 
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (alRadioButton.Checked)
            {
                CurrentGuy = GuyArray[2];
                UpdateControls();
            } 
        }

        private void bets_Click(object sender, EventArgs e)
        {
            CurrentGuy.PlaceBet((int)betAmount.Value, (int)dogNumber.Value);
        }

        private void race_Click(object sender, EventArgs e)
        {
            EnableControls(false);

            raceTime.Start();

            EnableControls(true);
        }

        private void UpdateControls()
        {
            name.Text = CurrentGuy.Name;
            betAmount.Value = Math.Max(betAmount.Minimum, CurrentGuy.MyBet.Amount);
            dogNumber.Value = Math.Max(1,CurrentGuy.MyBet.Dog);
        }

        private void EnableControls(bool isEnabled)
        {
            joeRadioButton.Enabled = isEnabled;
            bobRadioButton.Enabled = isEnabled;
            alRadioButton.Enabled = isEnabled;

            betAmount.Enabled = isEnabled;
            dogNumber.Enabled = isEnabled;
            race.Enabled = isEnabled;
        }

        private void raceTime_Tick(object sender, EventArgs e)
        {
            for (int dogNumber = 0; dogNumber < GreyhoundArray.Length; dogNumber++)
            {
                if (GreyhoundArray[dogNumber].Run())
                {
                    raceTime.Stop();
                    
                    int winningDog = dogNumber + 1;
                    for (int j = 0; j < GuyArray.Length; j++)
                    {
                        GuyArray[j].Collect(winningDog);
                    }

                    MessageBox.Show("Dog #" + winningDog + " won the race!");

                    for (int i = 0; i < GreyhoundArray.Length; i++)
                    {
                        GreyhoundArray[i].TakeStartingPosition();
                    }
                }
            }
        }
    }
}
