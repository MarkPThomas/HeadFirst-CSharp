using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = Name + " has " + Cash + " bucks.";
        }

        public void ClearBet()
        {
            MyBet = new Bet()
            {
                Bettor = this
            };
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (BetAmount <= Cash)
            {
                MyBet = new Bet() {Bettor = this, Amount = BetAmount, Dog = DogToWin};
                UpdateLabels();
                return true;
            }
            else
            {
                UpdateLabels();
                return false;
            }   
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            ClearBet();
            UpdateLabels();
        }

    }
}
