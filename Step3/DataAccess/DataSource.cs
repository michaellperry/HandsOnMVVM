using System;
using Step3.Model;

namespace Step3.DataAccess
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
