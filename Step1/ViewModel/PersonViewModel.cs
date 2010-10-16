using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hands_On_MVVM.Model;

namespace Hands_On_MVVM.ViewModel
{
    public class PersonViewModel
    {
        private Person _person;

        public PersonViewModel(Person person)
        {
            _person = person;
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

        public IEnumerable<string> DisplayAsOptions
        {
            get
            {
                return
                    from value in Enum.GetValues(typeof(DisplayStrategy))
                        .OfType<DisplayStrategy>()
                    select _person.DisplayUsingStrategy(value);
            }
        }

        public string DisplayAs
        {
            get { return _person.DisplayUsingStrategy(_person.DisplayStrategy); }
            set
            {
                foreach (DisplayStrategy strategy in Enum.GetValues(typeof(DisplayStrategy)))
                    if (_person.DisplayUsingStrategy(strategy) == value)
                        _person.DisplayStrategy = strategy;
            }
        }
    }
}
