using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hands_On_MVVM.Model;

namespace Hands_On_MVVM.ViewModel
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
