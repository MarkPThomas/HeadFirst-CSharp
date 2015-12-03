using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace ComicCollections
{
    public class ComicQueryManager
    {
        public ObservableCollection<ComicQuery> AvailableQueries { get; private set; }
        public ObservableCollection<object> CurrentQueryResults { get; private set; }
        public string Title { get; set; }

        public ComicQueryManager()
        {
            UpdateAvailableQueries();
            CurrentQueryResults = new ObservableCollection<object>();
        }

        private void UpdateAvailableQueries()
        {
            AvailableQueries = new ObservableCollection<ComicQuery>
            {
                new ComicQuery("LINQ makes queries easy", "A sample query",
                                "Let's show Jimmy how flexible LINQ is.",
                                "Assets/purple_250x250.jpg"), 

                new ComicQuery("Expensive Comics", "Comics over $500",
                                "Comics whose value is over 500 bucks. "
                                + "Jimmy can use this to figure out which comics are most coveted.",
                                "Assets/captain_amazing_250x250.jpg"),

                new ComicQuery("LINQ is versatile 1", "Modify every item returned from the query",
                                "This code will add a string onto the end of each string in an array.",
                                "Assets/bluegray_250x250.jpg"),

                new ComicQuery("LINQ is versatile 2", "Perform calculations on collections",
                                "LINQ provides extension methods for your collections (and anything else"
                                + " that implements IEnumerable<T>.",
                                "Assets/purple_250x250.jpg"),

                new ComicQuery("LINQ is versatile 3", "Store all or part of your results in a new sequence",
                                "Sometimes you'll want to keep your results from a LINQ query around.",
                                "Assets/bluegray_250x250.jpg"),

            };
        }

        public void UpdateQueryResults(ComicQuery query)
        {
            Title = query.Title;

            switch (query.Title)
            {
                case "LINQ makes queries easy":
                    LinqMakesQueriesEasy();
                    break;
                case "Expensive Comics":
                    ExpensiveComics();
                    break;
                case "LINQ is versatile 1":
                    LinqIsVersatile1();
                    break;
                case "LINQ is versatile 2":
                    LinqIsVersatile2();
                    break;
                case "LINQ is versatile 3":
                    LinqIsVersatile3();
                    break;
            }

        }

        public static IEnumerable<Comic> BuildCatalog()
        {
            return new List<Comic>
            {
                new Comic {Name = "Johnny America vs. the Pinko", Issue = 6 },
                new Comic {Name = "Rock and Roll (Limited Edition)", Issue = 19 },
                new Comic {Name = "Woman's Work", Issue = 36 },
                new Comic {Name = "Hippie Madness (misprinted)", Issue = 57 },
                new Comic {Name = "Revenge of the New Wave Freak (damaged)", Issue = 68 },
                new Comic {Name = "Black Monday", Issue = 74 },
                new Comic {Name = "Tribal Tattoo Madness", Issue = 83 },
                new Comic {Name = "The Death of an Object", Issue = 97 },
            };
        }

        private static Dictionary<int, decimal> GetPrices()
        {
            return new Dictionary<int, decimal>
            {
                {6, 300M },
                {19, 500M },
                {36, 650M },
                {57, 13525M },
                {68, 250M },
                {74, 75M },
                {83, 25.75M },
                {97, 35.25M },
            };
        }

        private static BitmapImage CreateImageFromAssets(string imageFileName)
        {
            try
            {
                Uri uri = new Uri(imageFileName, UriKind.RelativeOrAbsolute);
                return new BitmapImage(uri);
            }
            catch (System.IO.IOException)
            {
                return new BitmapImage();
            }
        }

        private void LinqMakesQueriesEasy()
        {
            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            var result = from v in values
                         where v < 37
                         orderby v
                         select v;

            foreach (int i in result)
            {
                CurrentQueryResults.Add(
                    new {
                            Title = i.ToString(),
                            ImagePath = "Assets/purple_250x250.jpg"
                        }
                    );

            }

        }

        private void ExpensiveComics()
        {
            IEnumerable<Comic> comics = BuildCatalog();
            Dictionary<int, decimal> values = GetPrices();

            var mostExpensive = from comic in comics
                                where values[comic.Issue] > 500
                                orderby values[comic.Issue] descending
                                select comic;

            foreach (Comic comic in mostExpensive)
            {
                CurrentQueryResults.Add(
                    new {
                            Title = string.Format("{0} is worth {1:c}", comic.Name, values[comic.Issue]),
                            ImagePath = "Assets/captain_amazing_250x250.jpg"
                        }
                    );
            }
        }

        private void LinqIsVersatile1()
        {
            string[] sandwiches = { "ham and cheese", "salami with mayo", "turkey and swiss", "chicken cutlet" };

            var sandwichesOnRye =
                from sandwich in sandwiches
                select sandwich + " on rye";

            foreach (var sandwich in sandwichesOnRye)
            {
                CurrentQueryResults.Add(CreateAnonymousListViewItem(sandwich, "bluegray_250x250.jpg"));
            }
        }


        private void LinqIsVersatile2()
        {
            Random random = new Random();
            List<int> listOfNumbers = new List<int>();
            int length = random.Next(50, 150);
            for (int i = 0; i < length; i++)
            {
                listOfNumbers.Add(random.Next(100));
            }

            CurrentQueryResults.Add(CreateAnonymousListViewItem(
                string.Format("There are {0} numbers", listOfNumbers.Count())));
            CurrentQueryResults.Add(CreateAnonymousListViewItem(
                string.Format("The smallest is {0}", listOfNumbers.Min())));
            CurrentQueryResults.Add(CreateAnonymousListViewItem(
                string.Format("The largest is {0}", listOfNumbers.Max())));
            CurrentQueryResults.Add(CreateAnonymousListViewItem(
                string.Format("The sum is {0}", listOfNumbers.Sum())));
            CurrentQueryResults.Add(CreateAnonymousListViewItem(
                string.Format("The average is {0:F2}", listOfNumbers.Average())));
        }

        private void LinqIsVersatile3()
        {
            List<int> listOfNumbers = new List<int>();
            for (int i = 0; i <= 10000; i++)
            {
                listOfNumbers.Add(i);
                var under50Sorted =
                    from number in listOfNumbers
                    where number < 50
                    orderby number descending
                    select number;

                var firstFive = under50Sorted.Take(6);

                List<int> shortList = firstFive.ToList();
                foreach (int n in shortList)
                {
                    CurrentQueryResults.Add(CreateAnonymousListViewItem(
                        n.ToString(), "bluegray_250x250.jpg"));
                }
            }
        }

        private object CreateAnonymousListViewItem(string title, 
                                                    string imageFilename = "purple_250x250.jpg")
        {
            return new
                    {
                        Title = title,
                        ImagePath = "Assets/" + imageFilename
                     };
        }
    }
}
