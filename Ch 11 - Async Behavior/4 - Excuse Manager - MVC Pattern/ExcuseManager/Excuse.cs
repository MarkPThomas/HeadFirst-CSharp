using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace ExcuseManagerApp
{
    [DataContract(Namespace = "http://www.headfirstlabs.com/ExcuseManager")]
    class Excuse : INotifyPropertyChanged
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

        #region Properties
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Results { get; set; }
        [DataMember]
        public DateTime LastUsedDate { get; set; }
        #endregion

        #region Initialization

        public Excuse()
        {
            LastUsedDate = DateTime.Now;
        }

        public Excuse(string description, string results)
        {
            Description = description;
            Results = results;
            LastUsedDate = DateTime.Now;
        }

        #endregion


    }
}
