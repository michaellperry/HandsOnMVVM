﻿using System;
using Hands_On_MVVM.Model;

namespace Hands_On_MVVM.DataAccess
{
    public class DataSource
    {
        public Person GetPerson()
        {
            return new Person()
            {
                FirstName = "Mark",
                LastName = "Benford",
                Email = "mark.benford@fbi.gov",
                Phone = "876 432-8765"
            };
        }

        public ContactList LoadContacts()
        {
            ContactList contactList = new ContactList();
            contactList.AddPerson(new Person()
            {
                FirstName = "Mark",
                LastName = "Benford",
                Email = "mark.benford@fbi.gov",
                Phone = "876 432-8765"
            });
            contactList.AddPerson(new Person()
            {
                FirstName = "Demitri",
                LastName = "Noh",
                Email = "demitri.noh@fbi.gov",
                Phone = "876 432-8765"
            });
            contactList.AddPerson(new Person()
            {
                FirstName = "Janis",
                LastName = "Hawk",
                Email = "janis.hawk@fbi.gov",
                Phone = "876 432-8765"
            });
            return contactList;
        }
    }
}
