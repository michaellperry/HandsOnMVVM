using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Step7.Model;
using Step7.NavigationModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Step7.ViewModel
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private ContactList _contactList;
        private ContactsNavigationModel _contactsNavigationModel;
        private ObservableCollection<PersonItemViewModel> _personItemViewModels = new ObservableCollection<PersonItemViewModel>();

        public ContactsViewModel(ContactList contactList, ContactsNavigationModel contactsNavigationModel)
        {
            _contactsNavigationModel = contactsNavigationModel;
            _contactList = contactList;

            _contactsNavigationModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ContactsNavigationModel_PropertyChanged);
            PopulatePersonItemViewModels();

            // See if the collection is observable.
            INotifyCollectionChanged notifyPeopleChanged = _contactList.People as INotifyCollectionChanged;
            if (notifyPeopleChanged != null)
                notifyPeopleChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(People_CollectionChanged);
        }

        void ContactsNavigationModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            FirePropertyChanged("SelectedPersonItem");
            FirePropertyChanged("SelectedPerson");
        }

        void People_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // Add the corresponding view models.
                int index = e.NewStartingIndex;
                foreach (Person person in e.NewItems)
                {
                    _personItemViewModels.Insert(index, new PersonItemViewModel(person));
                    ++index;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                // Delete the corresponding view models.
                for (int i = 0; i < e.OldItems.Count; i++)
                {
                    _personItemViewModels.RemoveAt(i + e.OldStartingIndex);
                }
            }
            else
            {
                // Just give up and start over.
                _personItemViewModels.Clear();
                PopulatePersonItemViewModels();
            }
        }

        private void PopulatePersonItemViewModels()
        {
            foreach (Person person in _contactList.People)
                _personItemViewModels.Add(new PersonItemViewModel(person));
        }

        public IEnumerable<PersonItemViewModel> People
        {
            get { return _personItemViewModels; }
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

        public ICommand NewPerson
        {
            get
            {
                return new CommandObject(() =>
                {
                    Person newPerson = new Person();
                    _contactList.AddPerson(newPerson);
                    _contactsNavigationModel.SelectedPerson = newPerson;
                });
            }
        }

        public ICommand DeletePerson
        {
            get
            {
                return new CommandObject(() =>
                {
                    if (_contactsNavigationModel.SelectedPerson != null)
                    {
                        _contactList.DeletePerson(_contactsNavigationModel.SelectedPerson);
                        _contactsNavigationModel.SelectedPerson = null;
                    }
                });
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
