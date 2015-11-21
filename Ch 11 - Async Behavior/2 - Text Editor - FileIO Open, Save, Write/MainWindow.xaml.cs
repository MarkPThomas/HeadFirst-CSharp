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
using System.IO;
using System.Runtime.Serialization;
using System.ComponentModel;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace LessSimpleTextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool textChanged = false;
        private bool loading = true;
        private string fileNameText = "Untitled.txt";

        private IAsyncResult asyncResult;
        private const string FILTER = "Text File (*.txt)|*.txt|XML File (*.xml)|*.xml|XML File (*.xaml)|*.xaml";
        private string initialDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        private string lastDirectory;

        private LoadMethod loadMethod;
        double currentCount;
        DispatcherTimer stopwatch = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            filename.Text = fileNameText;
            status.Text = "";
            menu.Height = 10;
            fileAtOnce.IsChecked = true;

            ResetDirectory();
        }

        private void ResetDirectory()
        {
            lastDirectory = initialDirectory;
        }

        private void SetFileName(string filePath)
        {
            fileNameText = System.IO.Path.GetFileName(filePath);
            filename.Text = fileNameText;
        }

        #region Methods: Async
        private MessageBoxResult msgBxResultGlobal;

        private delegate void ShowMessageBoxDelegate(string strMessage, string strCaption, MessageBoxButton enmButton, MessageBoxImage enmImage);

        // Method invoked on a separate thread that shows the message box.
        private  void ShowMessageBox(string strMessage, string strCaption, MessageBoxButton enmButton, MessageBoxImage enmImage)
        {
            msgBxResultGlobal = MessageBox.Show(strMessage, strCaption, enmButton, enmImage);
        }

        // Shows a message box from a separate worker thread.
        public void ShowMessageBoxAsync(string strMessage, string strCaption, MessageBoxButton enmButton, MessageBoxImage enmImage)
        {
            ShowMessageBoxDelegate caller = new ShowMessageBoxDelegate(ShowMessageBox);
            caller.BeginInvoke(strMessage, strCaption, enmButton, enmImage, null, null);
        }
        // Shows a message box from a separate worker thread. The specified asynchronous 
        // result object allows the caller to monitor whether the message box has been 
        // closed. This is useful for showing only one message box at a time. 
        public void ShowMessageBoxAsync(string strMessage, string strCaption, MessageBoxButton enmButton, MessageBoxImage enmImage, ref IAsyncResult asyncResult)
        {
            if ((asyncResult == null) || asyncResult.IsCompleted)
            {
                ShowMessageBoxDelegate caller = new ShowMessageBoxDelegate(ShowMessageBox);
                asyncResult = caller.BeginInvoke(strMessage, strCaption, enmButton, enmImage, null, null);
            }
        }


        private MessageBoxResult ShowMessageBoxAsyncResult(string strMessage, string strCaption, MessageBoxButton enmButton, MessageBoxImage enmImage)
        {
            MessageBoxResult currentResult;

            ShowMessageBoxAsync(strMessage, strCaption, enmButton, enmImage);

            currentResult = msgBxResultGlobal;
            msgBxResultGlobal = MessageBoxResult.None;

            return currentResult;
        }

        private MessageBoxResult ShowMessageBoxAsyncResult(string strMessage, string strCaption, MessageBoxButton enmButton, MessageBoxImage enmImage, ref IAsyncResult asyncResult)
        {
            MessageBoxResult currentResult;

            ShowMessageBoxAsync(strMessage, strCaption, enmButton, enmImage, ref asyncResult);

            currentResult = msgBxResultGlobal;
            msgBxResultGlobal = MessageBoxResult.None;

            return currentResult;
        }
        #endregion

        private async Task openButton_Click()
        {
            openButton.Background = Brushes.Yellow;

            if (textChanged)
            {
                MessageBoxResult current = MessageBox.Show("You have unsaved changes. Are you sure you want to load a new file?", "File Changed",
                                                                            MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (current == MessageBoxResult.No)
                {
                    return;
                }
            }
            await OpenFile();
        }

        private async Task OpenFile()
        {
            OpenFileDialog openDialog = new OpenFileDialog()
            {
                Title = "Open File",
                Filter = FILTER,
                FileName = "",
                InitialDirectory = lastDirectory,
                CheckPathExists = true,
                CheckFileExists = true
            };


            if (openDialog.ShowDialog() == true)
            {
                loading = true;
                lastDirectory = System.IO.Path.GetDirectoryName(openDialog.FileName);

                // Load text into reader line-by-line
                await ReadTextAsync(openDialog.FileName);
                SetFileName(openDialog.FileName);
            }
        }

        private async Task ReadTextAsync(string path)
        {
            text.Text = "";

            using (StreamReader file = new StreamReader(path))
            {
                status.Text = "";
                status.Foreground = Brushes.Red;
          
                currentCount = 0;

                switch (loadMethod)
                {
                    case LoadMethod.LineByLine:
                        // ==== Loading the file one line at a time ==== 
                        // Too much updating of the form, so it is essentially frozen.
                        // Takes the longest to load, by far.
                        string line;
                        while ((line = await file.ReadLineAsync()) != null)
                        {
                            text.AppendText(line + Environment.NewLine);
                            currentCount++;
                            status.Text = currentCount.ToString() + " lines";
                        }
                        break;
                    case LoadMethod.Block:
                        // ==== Loading the file in blocks ==== 
                        // Note: The main freeze in load time is in the final refreshing of the WPF form.
                        //        The size of the buffer, set by 'count', is critical in how noticeable this is.
                        //      At   2,000 (3:00 min load!, 270 MB memory), the forms starts out smooth but it is harder to interact with the frequency of loading.
                        //        Changing the form causes a long freeze before it can resume upating the layout.
                        //      At  20,000 (1:00 min load, 325 MB memory), the form is reasonably responsive and does not freeze up bad when text is typed.
                        //        It seems this is the buffer sweet spot for size.
                        //        Second loading causes big jump in memory, which is dropped near the end to be back near the original state.
                        //      At 200,000 (1:00 min load, 450 MB memory), the blocks appended are large enough to freeze the form.
                        int index = 0;
                        int count = 2000;
                        int bufferCount = 0;
                        int bufferInterval = 10;
                        char[] buffer = new char[count];
                        StringBuilder blockTextComplete = new StringBuilder();
                        while ( await file.ReadBlockAsync(buffer, index, count) >= count)
                        {
                            blockTextComplete.Append(new string(buffer));
                            // Load first block to let user work with it while the rest loads
                            // After, load at buffer intervals
                            if (currentCount == 0 || bufferCount == bufferInterval * count)
                            {
                                text.AppendText(await AppendBlock(blockTextComplete));
                                blockTextComplete.Clear();
                                bufferCount = 0;
                            }
                            bufferCount += count;
                            currentCount += count;
                            status.Text = currentCount.ToString() + " characters";
                        }
                        text.AppendText(await AppendBlock(blockTextComplete));
                        blockTextComplete.Clear();
                        break;
                    case LoadMethod.File:
                        // ==== Loading the entire file at once ==== 
                        // 5-10 sec, 350 MB memory. Second load is much longer and takes double the memory.
                        // Loading in WPF is very fast. It seems that it is much faster to load the data all at once than in many increments, including total frozen time on the form.
                        stopwatch.Tick += stopwatch_Tick;
                        stopwatch.Start();

                        text.Text = await file.ReadToEndAsync();
                        if (text.Text != null && stopwatch.IsEnabled)
                        {
                            stopwatch.Stop();
                        }
                        break;
                    default:
                        break;
                }
                status.Foreground = Brushes.Green;
                status.Text = "Loaded!";
            }
            textChanged = false;
        }

        private void stopwatch_Tick(object sender, object e)
        {
            status.Text = currentCount++.ToString();
        }

        private async Task<string> AppendBlock(StringBuilder blockTextComplete)
        {
            return await Task.Run(() =>
            {
                return blockTextComplete.ToString();
            });
        }

        private async Task SaveFile()
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Title = "Save File",
                Filter = FILTER,
                FileName = fileNameText,
                InitialDirectory = lastDirectory,
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() != true)
            {
                return;
            }

            lastDirectory = System.IO.Path.GetDirectoryName(saveDialog.FileName);
            SetFileName(saveDialog.FileName);

            // Load text into reader line-by-line
            await WriteTextAsync(saveDialog.FileName, text.Text);
            ShowMessageBoxAsync("Wrote " + fileNameText, "File Saved",
                                MessageBoxButton.OK, MessageBoxImage.Question, ref asyncResult);

            textChanged = false;
            SetFileName(saveDialog.FileName);
        }

        private async Task WriteTextAsync(string path, string fileText)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                await file.WriteLineAsync(fileText);
            }
        }

        private void AnimateStackPanel(StackPanel myStackPanel)
        {
            int maxHeight = 60;
            int minHeight = 10;
            int duration = 200;

            if (myStackPanel.Height != minHeight && myStackPanel.Height != maxHeight) { return; }

            Duration myDuration = new Duration(TimeSpan.FromMilliseconds(duration));
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();

            if (myStackPanel.Height == minHeight)
            {
                myDoubleAnimation = new DoubleAnimation()
                {
                    From = minHeight,
                    To = maxHeight,
                    Duration = myDuration
                };
            }
            else if (myStackPanel.Height == maxHeight)
            {
                myDoubleAnimation = new DoubleAnimation()
                {
                    From = maxHeight,
                    To = minHeight,
                    Duration = myDuration
                };
            }
            Storyboard myStoryBoard = new Storyboard()
            {
                Duration = myDuration,
            };
            myStoryBoard.Children.Add(myDoubleAnimation);
            Storyboard.SetTarget(myDoubleAnimation, myStackPanel);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath("(Height)"));
            myStoryBoard.Begin();
        }


        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (loading)
            {
                loading = false;
                return;
            }
            if (!textChanged)
            {
                filename.Text += "*";
                saveButton.IsEnabled = true;
                textChanged = true;
            }
        }


        private void openButton_MouseEnter(object sender, MouseEventArgs e)
        {
            openButton.Background = Brushes.YellowGreen;
        }
        private void openButton_MouseLeave(object sender, MouseEventArgs e)
        {
            openButton.Background = Brushes.Azure;
        }
        private async void openButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
           await openButton_Click();
        }
        private void openButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            openButton.Background = Brushes.YellowGreen;
        }


        private void saveButton_MouseEnter(object sender, MouseEventArgs e)
        {
            saveButton.Background = Brushes.YellowGreen;
        }
        private void saveButton_MouseLeave(object sender, MouseEventArgs e)
        {
            saveButton.Background = Brushes.Azure;
        }
        private async void saveButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            saveButton.Background = Brushes.Yellow;
            await SaveFile();
        }
        private void saveButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            saveButton.Background = Brushes.YellowGreen;
        }

        private void menu_MouseEnter(object sender, MouseEventArgs e)
        {
            AnimateStackPanel(menu);
        }
        private void menu_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimateStackPanel(menu);

        }

        private void lineByLine_Checked(object sender, RoutedEventArgs e)
        {
            loadMethod = LoadMethod.LineByLine;
        }
        private void blockByBlock_Checked(object sender, RoutedEventArgs e)
        {
            loadMethod = LoadMethod.Block;
        }
        private void fileAtOnce_Checked(object sender, RoutedEventArgs e)
        {
            loadMethod = LoadMethod.File;
        }

       
    }
}
