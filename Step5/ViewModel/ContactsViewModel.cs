using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Step5.Model;

namespace Step5.ViewModel
{
    public class ContactsViewModel
    {
        private ContactList _contactList;

        public ContactsViewModel(ContactList contactList)
        {
            _contactList = contactList;
        }

        public IEnumerable<PersonItemViewModel> People
        {
            get { return _contactList.People.Select(p => new PersonItemViewModel(p)); }
        }
    }
}
