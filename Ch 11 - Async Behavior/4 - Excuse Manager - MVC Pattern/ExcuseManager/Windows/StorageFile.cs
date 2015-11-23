using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseManagerApp
{
    /// <summary>
    /// Represents a file. Provides information about the file and its content, and ways to manipulate them.
    /// </summary>
    class StorageFile
    {
        #region Properties

        /// <summary>
        /// The attributes of the current folder.
        /// </summary>
        public FileAttributes Attributes { get; private set; }

        ///// <summary>
        ///// The MIME type of the file contents.         
        ///// For example, a music file might have the "audio/mpeg" MIME type.
        ///// </summary>
        //public string ContentType { get; }

        /// <summary>
        /// The date and time that the current file was created.
        /// </summary>
        public DateTimeOffset DateCreated { get; private set; }

        ///// <summary>
        ///// The user-friendly name of the current file.
        ///// </summary>
        //public string DisplayName { get; }

        ///// <summary>
        ///// The user-friendly description of the type of the file; for example, JPEG image.
        ///// </summary>
        //public string DisplayType { get; }

        /// <summary>
        /// The file name extension of the file.
        /// </summary>
        public string FileType { get; private set; }

        ///// <summary>
        ///// The identifier for the current folder. 
        ///// This ID is unique for the query result or StorageFolder that contains the current folder or file group, and can be used to distinguish between items that have the same name.
        ///// </summary>
        //public string FolderRelativeId { get; }

        ///// <summary>
        ///// Indicates if the file is local, is cached locally, or can be downloaded.
        ///// </summary>
        //public bool IsAvailable { get; }

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

        public StorageFile() { }

        public StorageFile(string path)
        {
            SetStorageFile(path);
        }

        private void SetStorageFile(string path)
        {
            FileInfo newFile = new FileInfo(path);
            Attributes = newFile.Attributes;
            DateCreated = newFile.CreationTimeUtc;
            FileType = newFile.Extension;
            Name = newFile.Name;
            Path = newFile.FullName;
        }

        #endregion

        #region Methods

        async internal Task<BasicProperties> GetBasicPropertiesAsync()
        {
            return await Task.Run(()=> GetBasicProperties());
        }
        internal BasicProperties GetBasicProperties()
        {
            FileInfo newPath = new FileInfo(Path);

            return new BasicProperties(newPath.LastWriteTime, newPath.Length);         
        }

        #endregion
    }
}
