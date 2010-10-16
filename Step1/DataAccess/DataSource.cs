using System;
using Step1.Model;

namespace Step1.DataAccess
{
    public class DataSource
    {
        public Person GetPerson()
        {
            return new Person()
            {
                FirstName = "Mark",
                LastName = "Benford",
                Email = "mark.benford@cia.gov",
                Phone = "876 432-8765"
            };
        }
    }
}
