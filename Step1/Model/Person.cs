using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace Hands_On_MVVM.Model
{
    public class Person : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private DisplayStrategy _displayStrategy;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                FirePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                FirePropertyChanged("LastName");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                FirePropertyChanged("Email");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                FirePropertyChanged("Phone");
            }
        }

        public DisplayStrategy DisplayStrategy
        {
            get { return _displayStrategy; }
            set
            {
                if (_displayStrategy != value)
                {
                    _displayStrategy = value;
                    FirePropertyChanged("DisplayStrategy");
                }
            }
        }

        public string DisplayUsingStrategy(DisplayStrategy displayStrategy)
        {
            if (displayStrategy == DisplayStrategy.LastFirst)
                return string.Format("{0}, {1}", LastName, FirstName);
            else if (displayStrategy == DisplayStrategy.FirstLast)
                return string.Format("{0} {1}", FirstName, LastName);
            else if (displayStrategy == DisplayStrategy.Email)
                return Email;
            else
                return string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
