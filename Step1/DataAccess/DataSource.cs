using System;
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
    }
}
