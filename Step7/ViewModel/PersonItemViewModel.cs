using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Step7.Model;

namespace Step7.ViewModel
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

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            PersonItemViewModel that = obj as PersonItemViewModel;
            if (that == null)
                return false;
            return this._person.Equals(that._person);
        }

        public override int GetHashCode()
        {
            return _person.GetHashCode();
        }
    }
}
