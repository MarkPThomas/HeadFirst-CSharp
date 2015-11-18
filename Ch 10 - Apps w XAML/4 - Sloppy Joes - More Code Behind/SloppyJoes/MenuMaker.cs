using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloppyJoes
{
    public class MenuMaker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<string> meats = new List<string> () { "Roast Beef", "Salami", "Turkey", "Ham", "Pastrami" };
        private List<string> condiments = new List<string> () { "Yellow Mustard", "Brown Mustard", "Honey Mustard", "Mayo", "Relish", "French Dressing" };
        private List<string> breads = new List<string> () { "Rye", "White", "Wheat", "Pumpernickle", "Italian Bread", "A Roll" };

        private Random random =  new Random();

        private int _numberofItems;
        public int NumberOfItems
        {
            get {return _numberofItems; }
            set
            {
                if (value > 0 && _numberofItems != value)
                {
                    _numberofItems = value;
                    OnPropertyChanged("NumberOfItems");
                }
            }
        }

        private ObservableCollection<MenuItem> _menu;
        public ObservableCollection<MenuItem> Menu
        {
            get { return _menu; }
            private set
            {
                _menu = value;
                OnPropertyChanged("Menu");
            }
        }

        private DateTime _generatedDate;
        public DateTime GeneratedDate
        {
            get { return _generatedDate; }
            set
            {
                _generatedDate = value;
                OnPropertyChanged("GeneratedDate");
            }
        }

        public MenuMaker()
        {
            Menu = new ObservableCollection<MenuItem>();
            NumberOfItems = 12;
            UpdateMenu();
        }

        public void UpdateMenu()
        {
            Menu.Clear();

            for (int i = 0; i < NumberOfItems; i++)
            { 
                Menu.Add(CreateMenuItem());
            }

        GeneratedDate = DateTime.Now;
        }

        private MenuItem CreateMenuItem()
        {
            string randomMeat = meats[random.Next(meats.Count)];
            string randomCondiment = condiments[random.Next(condiments.Count)];
            string randomBread = breads[random.Next(breads.Count)];

            return new MenuItem(randomMeat, randomCondiment, randomBread); ;
        }
    }
}
