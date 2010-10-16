using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Step6.Model;
using System.ComponentModel;

namespace Step6.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Person _person;

        public PersonViewModel(Person person)
        {
            _person = person;

            _person.PropertyChanged += PersonPropertyChanged;
        }

        public string FirstName
        {
            get { return _person.FirstName; }
            set { _person.FirstName = value; }
        }

        public string LastName
        {
            get { return _person.LastName; }
            set { _person.LastName = value; }
        }

        public string Email
        {
            get { return _person.Email; }
            set { _person.Email = value; }
        }

        public string Phone
        {
            get { return _person.Phone; }
            set { _person.Phone = value; }
        }

        public DisplayStrategyViewModel DisplayAs
        {
            get { return new DisplayStrategyViewModel(_person, _person.DisplayAs); }
            set { _person.DisplayAs = value.DisplayStrategy; }
        }

        public IEnumerable<DisplayStrategyViewModel> DisplayAsOptions
        {
            get
            {
                return Enum.GetValues(typeof(DisplayStrategy))
                    .OfType<DisplayStrategy>()
                    .Select(displayStrategy => new DisplayStrategyViewModel(_person, displayStrategy));
            }
        }

        public string Title
        {
            get
            {
                return "Person - " + _person.DisplayUsingStrategy(_person.DisplayAs);
            }
        }

        void PersonPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FirePropertyChanged(e.PropertyName);
            FirePropertyChanged("Title");
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
