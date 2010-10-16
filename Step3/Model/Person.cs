using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace Step3.Model
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private DisplayStrategy _displayAs = DisplayStrategy.LastFirst;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                FirePropertyChanged("Title");
                FirePropertyChanged("DisplayAs");
                FirePropertyChanged("DisplayAsOptions");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                FirePropertyChanged("Title");
                FirePropertyChanged("DisplayAs");
                FirePropertyChanged("DisplayAsOptions");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                FirePropertyChanged("Title");
                FirePropertyChanged("DisplayAs");
                FirePropertyChanged("DisplayAsOptions");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string DisplayAs
        {
            get { return DisplayUsingStrategy(_displayAs); }
            set
            {
                _displayAs = (DisplayStrategy)DisplayAsOptions.ToList().FindIndex(option => option == value);
                FirePropertyChanged("Title");
            }
        }

        public IEnumerable<string> DisplayAsOptions
        {
            get
            {
                return Enum.GetValues(typeof(DisplayStrategy))
                    .OfType<DisplayStrategy>()
                    .Select(displayStrategy => DisplayUsingStrategy(displayStrategy));
            }
        }

        public string Title
        {
            get
            {
                return "Person - " + DisplayUsingStrategy(_displayAs);
            }
        }

        public string DisplayUsingStrategy(DisplayStrategy displayStrategy)
        {
            if (displayStrategy == DisplayStrategy.LastFirst)
                return string.Format("{0}, {1}", _lastName, _firstName);
            else if (displayStrategy == DisplayStrategy.FirstLast)
                return string.Format("{0} {1}", _firstName, _lastName);
            else
                return _email;
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
