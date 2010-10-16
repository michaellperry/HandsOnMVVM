using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Step6.Model;
using Step6.NavigationModel;
using System.ComponentModel;

namespace Step6.ViewModel
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private ContactList _contactList;
        private ContactsNavigationModel _contactsNavigationModel;

        public ContactsViewModel(ContactList contactList, ContactsNavigationModel contactsNavigationModel)
        {
            _contactsNavigationModel = contactsNavigationModel;
            _contactList = contactList;

            _contactsNavigationModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ContactsNavigationModel_PropertyChanged);
        }

        void ContactsNavigationModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            FirePropertyChanged("SelectedPersonItem");
            FirePropertyChanged("SelectedPerson");
        }

        public IEnumerable<PersonItemViewModel> People
        {
            get { return _contactList.People.Select(p => new PersonItemViewModel(p)); }
        }

        public PersonItemViewModel SelectedPersonItem
        {
            get
            {
                return _contactsNavigationModel.SelectedPerson == null ? null :
                    new PersonItemViewModel(_contactsNavigationModel.SelectedPerson);
            }
            set
            {
                _contactsNavigationModel.SelectedPerson = value.Person;
            }
        }

        public PersonViewModel SelectedPerson
        {
            get
            {
                return _contactsNavigationModel.SelectedPerson == null ? null :
                    new PersonViewModel(_contactsNavigationModel.SelectedPerson);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
