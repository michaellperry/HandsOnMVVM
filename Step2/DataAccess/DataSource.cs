using System;
using Step2.Model;

namespace Step2.DataAccess
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
