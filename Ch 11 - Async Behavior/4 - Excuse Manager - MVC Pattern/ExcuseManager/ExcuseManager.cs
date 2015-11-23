using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.Win32;
using WinForms = System.Windows.Forms;
using System.Diagnostics;

namespace ExcuseManagerApp
{
    class ExcuseManager : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Fields & Constants Private

        private const string FILTER = "XML File (*.xml)|*.xml";
        private string initialDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

        private Random random = new Random();
        private StorageFolder excuseFolder = new StorageFolder();
        private StorageFile excuseFile = new StorageFile();

        #endregion

        #region Properties

        public Excuse CurrentExcuse { get; set; }
        public string FileDate { get; set; }

        #endregion

        #region Initialization
        public ExcuseManager()
        {
            NewExcuseAysnc();
        }
        #endregion

        #region Methods: Public - Main

        async public void NewExcuseAysnc()
        {
            CurrentExcuse = new Excuse();
            excuseFile = null;
            OnPropertyChanged("CurrentExcuse");
            await UpdateFileDateAsync();
        }

        public bool ChooseNewFolder()
        {
            StorageFolder chosenFolder = FolderPicker(excuseFolder);

            if (chosenFolder != null)
            {
                excuseFolder = chosenFolder;
                return true;
            }

            WinForms.MessageBox.Show("No excuse folder chosen!");
            return false;
        }

        public async void OpenExcuseAsync()
        {
            StorageFile chosenFile = FileOpenPicker(storageFile: excuseFile);

            if (chosenFile != null)
            {
                excuseFile = chosenFile;
                await ReadExcuseAsync();
            }
            OnPropertyChanged("CurrentExcuse");
        }

        public async void OpenRandomExcuseAsync()
        {
            IReadOnlyList<StorageFile> files = await excuseFolder.GetFilesAsync();
            if (files.Count() > 0)
            {
                excuseFile = files[random.Next(0, files.Count())];
                await ReadExcuseAsync();
                OnPropertyChanged("CurrentExcuse");
            }
        }

        public async Task UpdateFileDateAsync()
        {
            if (excuseFile != null)
            {
                BasicProperties basicProperties = await excuseFile.GetBasicPropertiesAsync();
                FileDate = basicProperties.DateModified.ToString();
            }
            else
            {
                FileDate = "(no file loaded)";
            }
            OnPropertyChanged("FileDate");
        }

        public async void SaveCurrentExcuseAsync()
        {
            if (CurrentExcuse == null)
            {
                WinForms.MessageBox.Show("No excuse loaded.");
                return;
            }
            if (string.IsNullOrEmpty(CurrentExcuse.Description))
            {
                if (excuseFile != null)
                {
                    WinForms.MessageBox.Show(string.Format("Current excuse {0} does not have a description.", excuseFile.Name));
                }
                else
                {
                    WinForms.MessageBox.Show("Current excuse does not have any data entered.");
                }
                
                return;
            }
            // Check was in example, but prevents saving over an existing file
            //if (excuseFile == null)
            //{
                excuseFile = await excuseFolder.CreateFileAsync(CurrentExcuse.Description + ".xml",
                                                                CreateCollisionOption.ReplaceExisting);
            //}

            if (excuseFile != null)
            {
                await WriteExcuseAsync();
            }    
        }

        #endregion


        #region Methods: Public - Exercise

        public async Task ReadExcuseAsync()
        {
            await Task.Run(() => ReadExcuse());
            await UpdateFileDateAsync();
        }
        internal void ReadExcuse()
        {
            if (string.IsNullOrEmpty(excuseFile.Path))
            {
                return;
            }

            // If file does not exist, an IO exception occurs here.
            using (Stream inputStream = File.OpenRead(excuseFile.Path))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Excuse));

                // If invalid XML, such as a string in a field expected to be an integer, or an invalid enum, a serializer exception occurs here noting that.
                CurrentExcuse = serializer.ReadObject(inputStream) as Excuse;
            }
            OnPropertyChanged("CurrentExcuse");
        }

        public async Task WriteExcuseAsync()
        {
            await Task.Run(()=> WriteExcuse());
            await UpdateFileDateAsync();

            WinForms.MessageBox.Show(string.Format("Excuse was saved to file {0}", excuseFile.Path));
        }
        internal void WriteExcuse()
        {
            using (Stream outputStream = File.Create(excuseFile.Path))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Excuse));
                serializer.WriteObject(outputStream, CurrentExcuse);
            }
        }


        public async void SaveCurrentExcuseAsAsync()
        {
            StorageFile chosenFile = FileSavePicker(storageFile: excuseFile);

            if (chosenFile != null)
            {
                excuseFile = chosenFile;
                await WriteExcuseAsync();
            }       
        }

        #endregion

        #region Methods: Private
        private StorageFolder FolderPicker(StorageFolder storageFolder = null)
        {
            string directory = SetCurrentDirectory(storageFolder);

            WinForms.FolderBrowserDialog openFolder = new WinForms.FolderBrowserDialog()
            {
                Description = "Select Folder",
                ShowNewFolderButton = true,
                SelectedPath = directory,
            };

            if (openFolder.ShowDialog() == WinForms.DialogResult.OK)
            {
                storageFolder = new StorageFolder(openFolder.SelectedPath);
                return storageFolder;
            }
            return null;
        }

        private StorageFile FileOpenPicker(StorageFolder storageFolder = null, StorageFile storageFile = null)
        {
            string directory = SetCurrentDirectory(storageFolder, storageFile);
            string fileName = SetCurrentFileName(storageFile);

            OpenFileDialog openDialog = new OpenFileDialog()
            {
                Title = "Open File",
                Filter = FILTER,
                FileName = fileName,
                InitialDirectory = directory,
                Multiselect = false,
                CheckPathExists = true,
                CheckFileExists = true
            };

            if (openDialog.ShowDialog() == true)
            {
                storageFile = new StorageFile(openDialog.FileName);
                return storageFile;
            }
            return null;
        }

        private StorageFile FileSavePicker(StorageFolder storageFolder = null, StorageFile storageFile = null)
        {
            string directory = SetCurrentDirectory(storageFolder, storageFile);
            string fileName = SetCurrentFileName(storageFile);

            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Title = "Save File",
                Filter = FILTER,
                FileName = fileName,
                InitialDirectory = directory,
                CheckPathExists = true,
                CheckFileExists = false
            };

            if (saveDialog.ShowDialog() == true)
            {
                storageFile = new StorageFile(saveDialog.FileName);
                return storageFile;
            }
            return null;
        }



        private string SetCurrentDirectory(StorageFolder storageFolder = null, StorageFile storageFile = null)
        {
            if (storageFile == null || string.IsNullOrEmpty(storageFile.Path))
            {
                if (storageFolder == null || string.IsNullOrEmpty(storageFolder.Path))
                {
                    return initialDirectory;
                }
                else
                {
                    return storageFolder.Path;
                }
            }
            else
            {
                return Path.GetDirectoryName(storageFile.Path);
            }
        }

        private string SetCurrentFileName(StorageFile storageFile = null)
        {
            if (storageFile == null || string.IsNullOrEmpty(storageFile.Path))
            {
                if (!string.IsNullOrWhiteSpace(CurrentExcuse.Description))
                {
                    return CurrentExcuse.Description + ".xml";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return Path.GetFileName(storageFile.Path);
            }
        }
        #endregion
    }
}
