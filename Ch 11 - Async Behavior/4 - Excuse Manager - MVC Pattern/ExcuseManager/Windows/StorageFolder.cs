using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseManagerApp
{
    /// <summary>
    /// Manages folders and their contents and provides information about them.
    /// </summary>
    class StorageFolder
    {

        #region Properties

        /// <summary>
        /// The attributes of the current folder.
        /// </summary>
        public FileAttributes Attributes { get; private set; }

        /// <summary>
        /// The date and time that the current folder was created.
        /// </summary>
        public DateTimeOffset DateCreated { get; private set; }

        ///// <summary>
        ///// The user-friendly name of the current folder.
        ///// </summary>
        //public string DisplayName { get; private set; }

        ///// <summary>
        ///// The user-friendly description of the type of the folder; for example, JPEG image.
        ///// </summary>
        //public string DisplayType { get; private set; }

        ///// <summary>
        ///// The identifier for the current folder. 
        ///// This ID is unique for the query result or StorageFolder that contains the current folder or file group, and can be used to distinguish between items that have the same name.
        ///// </summary>
        //public string FolderRelativeId { get; private set; }

        /// <summary>
        /// The name of the current folder.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The full path of the current folder in the file system, if the path is available.
        /// </summary>
        public string Path { get; private set; }

        ///// <summary>
        ///// The object that provides access to the content-related properties of the folder.
        ///// </summary>
        //public StorageItemContentProperties Properties { get; }

        ///// <summary>
        ///// The StorageProvider object that contains info about the service that stores the current folder. 
        ///// The folder may be stored by the local file system or by a remote service like OneDrive.
        ///// </summary>
        //public StorageProvider Provider { get; }

        #endregion

        #region Initialization

        public StorageFolder() { }

        public StorageFolder(string path)
        {
            SetPath(path);
        }

        private void SetPath(string path)
        {
            DirectoryInfo newDirectory = new DirectoryInfo(path);
            DateCreated = newDirectory.CreationTimeUtc;
            Attributes = newDirectory.Attributes;
            if (newDirectory.Attributes == FileAttributes.Directory)
            {
                Path = newDirectory.FullName;
                Name = newDirectory.Name;
            }
            else
            {
                Path = newDirectory.Parent.FullName;
                Name = newDirectory.Parent.Name;
            }
        }
        #endregion

        #region Methods: Internal
        internal async Task<IReadOnlyList<StorageFile>> GetFilesAsync()
        {
            return await Task.Run(() => GetFiles());
        }
        internal IReadOnlyList<StorageFile> GetFiles()
        {
            string[] fileNames = Directory.GetFiles(Path);

            List<StorageFile> storagefiles = new List<StorageFile>();
            for (int i = 0; i < fileNames.Length; i++)
            {
                if (System.IO.Path.GetExtension(fileNames[i]).ToUpper() == ".XML")
                {
                    storagefiles.Add(new StorageFile(fileNames[i]));
                }
            }

            return storagefiles.AsReadOnly();
        }

        internal async Task<StorageFile> CreateFileAsync(string fileNameWithExtension, CreateCollisionOption collisionOption)
        {
            return await Task.Run(() => CreateFile(fileNameWithExtension, collisionOption));
        }
        internal StorageFile CreateFile(string fileNameWithExtension, CreateCollisionOption collisionOption)
        {
            string fileNamePath = CreateNewFile(fileNameWithExtension, collisionOption);

            return NewStorageFile(fileNamePath);
        }

        #endregion

        #region Methods: Private

        private string CreateNewFile(string fileNameWithExtension, CreateCollisionOption collisionOption)
        {
            string fileNamePath = Path + System.IO.Path.DirectorySeparatorChar + fileNameWithExtension;

            if (File.Exists(fileNamePath))
            {
                switch (collisionOption)
                {
                    case CreateCollisionOption.GenerateUniqueName:
                        int i = 1;
                        while (File.Exists(fileNamePath))
                        {
                            fileNamePath = System.IO.Path.GetFileNameWithoutExtension(fileNameWithExtension);
                            fileNamePath += "(" + i + ")";
                            fileNamePath += System.IO.Path.GetExtension(fileNameWithExtension);

                            fileNamePath = Path + System.IO.Path.PathSeparator + fileNamePath;

                            i++;
                        }
                       // File.Create(fileNamePath);
                        break;
                    case CreateCollisionOption.ReplaceExisting:
                       // File.Create(fileNamePath);
                        break;
                    case CreateCollisionOption.FailIfExists:
                        fileNamePath = null;
                        break;
                    case CreateCollisionOption.OpenIfExists:
                        break;
                    default:
                        break;
                }
            }
            else
            {
               // File.Create(fileNamePath);
            }

            return fileNamePath;
        }

        private StorageFile NewStorageFile(string fileNamePath)
        {
            StorageFile newStorageFile;
            if (!string.IsNullOrEmpty(fileNamePath))
            {
                newStorageFile = new StorageFile(fileNamePath);
                SetPath(fileNamePath);
            }
            else
            {
                newStorageFile = null;
            }

            return newStorageFile;
        }
        #endregion
    }
}
