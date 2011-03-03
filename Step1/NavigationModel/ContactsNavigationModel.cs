using System.ComponentModel;
using Hands_On_MVVM.Model;

namespace Hands_On_MVVM.NavigationModel
{
    public class ContactsNavigationModel : INotifyPropertyChanged
    {
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                FirePropertyChanged("SelectedPerson");
            }
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
