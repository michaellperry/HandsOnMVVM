using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Step6.Model;
using System.ComponentModel;

namespace Step6.NavigationModel
{
    public class ContactsNavigationModel : INotifyPropertyChanged
    {
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; FirePropertyChanged("SelectedPerson"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
