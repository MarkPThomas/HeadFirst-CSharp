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
using System.Windows.Navigation;
using System.Runtime.Serialization;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace GuyXMLSerializer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GuyManager guyManager;
        private const string FILTER = "XML File (*.xml)|*.xml";
        private string initialDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

        public MainWindow()
        {
            InitializeComponent();
            guyManager = FindResource("guyManager") as GuyManager;
        }

        private void WriteJoe_Click(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuy(guyManager.Joe);
        }

        private void WriteBob_Click(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuy(guyManager.Bob);
        }

        private void WriteEd_Click(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuy(guyManager.Ed);
        }

        private void ReadNewGuy_Click(object sender, RoutedEventArgs e)
        {
            string directory;
            string fileName;

            if (string.IsNullOrEmpty(guyManager.GuyFile))
            {
                directory = initialDirectory;
                fileName = "";
            }
            else
            {
                directory = Path.GetDirectoryName(guyManager.GuyFile);
                fileName = Path.GetFileName(guyManager.GuyFile);
            }

            OpenFileDialog openDialog = new OpenFileDialog()
            {
                Title = "Open File",
                Filter = FILTER,
                FileName = fileName,
                InitialDirectory = directory,
                CheckPathExists = true,
                CheckFileExists = false
            };


            if (openDialog.ShowDialog() == true)
            {
                guyManager.GuyFile = openDialog.FileName;
                guyManager.ReadGuy();
            }
        }
    }
}
