﻿using System;
using Step4.Model;

namespace Step4.DataAccess
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
    }
}
