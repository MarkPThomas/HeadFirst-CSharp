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
                                "Let's show Jimmy how flexible LINQ is",
                                "Assets/purple_250x250.jpg"), 

                new ComicQuery("Expensive Comics", "Comics over $500",
                                "Comics whose value is over 500 bucks. "
                                + "Jimmy can use this to figure out which comics are most coveted.",
                                "Assets/captain_amazing_250x250.jpg"),
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


    }
}
