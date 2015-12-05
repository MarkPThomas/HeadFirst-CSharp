using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ComicCollections
{
    /// <summary>
    /// Interaction logic for QueryZoomDetail.xaml
    /// </summary>
    public partial class QueryDetailZoom : Window
    {
        private ComicQueryManager comicQueryManager;

        public QueryDetailZoom(ComicQuery comicQuery)
        {
            InitializeComponent();

            comicQueryManager = FindResource("comicQueryManager") as ComicQueryManager;

            if (comicQuery != null)
            {
                comicQueryManager.UpdateQueryResults(comicQuery);
                Title = comicQueryManager.Title;
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                detailListView.ScrollIntoView(e.AddedItems[0]);
            }
        }
    }
}
