using System;
using System.Collections.Generic;
using System.Text;

namespace HHH.BusinessEntities
{
    public class PersonAddress
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public AddressEntity addressEntity { get; set; }
    }
}
