using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step5.Model
{
    public class ContactList
    {
        private List<Person> _people = new List<Person>();

        public IEnumerable<Person> People
        {
            get { return _people; }
        }

        public void AddPerson(Person person)
        {
            _people.Add(person);
        }
    }
}
