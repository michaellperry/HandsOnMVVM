using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Step5.Model;

namespace Step5.ViewModel
{
    public class PersonItemViewModel
    {
        private Person _person;

        public PersonItemViewModel(Person person)
        {
            _person = person;
        }

        public Person Person
        {
            get { return _person; }
        }

        public string Display
        {
            get { return _person.DisplayUsingStrategy(_person.DisplayAs); }
        }
    }
}
