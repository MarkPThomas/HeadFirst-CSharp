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
    /// Interaction logic for QueryDetail.xaml
    /// </summary>
    public partial class QueryDetail : Window
    {
        private ComicQueryManager comicQueryManager = new ComicQueryManager();

        public QueryDetail(ComicQuery comicQuery)
        {
            if (comicQuery != null)
            {
                comicQueryManager.UpdateQueryResults(comicQuery);
                Title = comicQueryManager.Title;
            }

            InitializeComponent();
        }
    }
}
