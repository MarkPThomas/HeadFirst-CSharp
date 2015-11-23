using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseManagerApp
{
    /// <summary>
    /// Provides access to the basic properties, like the size of the item or the date the item was last modified, of the item (like a file or folder).
    /// </summary>
    class BasicProperties 
    {
        #region Properties

        /// <summary>
        /// The timestamp of the last time the file was modified.
        /// </summary>
        public DateTimeOffset DateModified { get; private set; }
        ///// <summary>
        ///// The item's date.
        /////The system determines the most relevant date based on the type of the item. 
        ///// For example, if the item is a photo the date in System.Photo.DateTaken is returned. 
        ///// Or if the item is a song the date in System.Media.DateReleased is returned.
        ///// </summary>
        //public DateTimeOffset ItemDate { get; private set; }
        /// <summary>
        /// The size of the file.
        /// </summary>
        public long Size { get; private set; }

        #endregion

        #region Initialization
        public BasicProperties() { }

        public BasicProperties(DateTimeOffset dateModified, long size)
        {
            DateModified = dateModified;
            Size = size;
        }

        #endregion

        #region Methods

        ///// <summary>
        ///// Retrieves the specified properties associated with the item.
        ///// </summary>
        ///// <param name="propertiesToRetrieve">A collection that contains the names of the properties to retrieve.</param>
        ///// <returns>When this method completes successfully, it returns a collection (type IMap) that contains the specified properties and values as key-value pairs.</returns>
        //public IAsyncOperation<IDictionary> RetrievePropertiesAsync(IEnumerable<string> propertiesToRetrieve)
        //{ }

        ///// <summary>
        ///// Saves all properties associated with the item.
        ///// </summary>
        ///// <returns></returns>
        //public IAsyncAction SavePropertiesAsync() { }

        ///// <summary>
        ///// Saves the specified properties and values associated with the item.
        ///// </summary>
        ///// <param name="propertiesToSave">A collection that contains the names and values of the properties to save as key-value pairs (type IKeyValuePair).</param>
        ///// <returns></returns>
        //public IAsyncAction SavePropertiesAsync(IEnumerable<KeyValuePair<TKey, TValue>> propertiesToSave) { }

        #endregion

    }
}
