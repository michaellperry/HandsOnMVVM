using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hands_On_MVVM.Model;
using System.ComponentModel;

namespace Hands_On_MVVM.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;

        public PersonViewModel(Person person)
        {
            _person = person;

            _person.PropertyChanged += Person_PropertyChanged;
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

        public string Title
        {
            get { return String.Format("Person - {0}", _person.DisplayUsingStrategy(_person.DisplayStrategy)); }
        }

        public IEnumerable<DisplayStrategyVewModel> DisplayAsOptions
        {
            get
            {
                return
                    from value in Enum.GetValues(typeof(DisplayStrategy))
                        .OfType<DisplayStrategy>()
                    select new DisplayStrategyVewModel(_person, value);
            }
        }

        public DisplayStrategyVewModel DisplayAs
        {
            get { return new DisplayStrategyVewModel(_person, _person.DisplayStrategy); }
            set
            {
                if (value != null)
                    _person.DisplayStrategy = value.DisplayStrategy;
            }
        }

        void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FirePropertyChanged("Title");
            FirePropertyChanged("DisplayAsOptions");
            FirePropertyChanged("DisplayAs");
        }
 
        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
