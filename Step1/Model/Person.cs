using System;

namespace Hands_On_MVVM.Model
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
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
    }
}
