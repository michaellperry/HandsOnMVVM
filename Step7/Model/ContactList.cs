using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Step7.Model
{
    public class ContactList
    {
        private ObservableCollection<Person> _people = new ObservableCollection<Person>();

        public IEnumerable<Person> People
        {
            get { return _people; }
        }

        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        public void DeletePerson(Person person)
        {
            _people.Remove(person);
        }
    }
}
