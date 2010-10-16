using System;
using System.ComponentModel;

namespace Step2.Model
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; FirePropertyChanged("Title"); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; FirePropertyChanged("Title"); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Title
        {
            get
            {
                return string.Format("Person - {0}, {1}", _lastName, _firstName);
            }
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
