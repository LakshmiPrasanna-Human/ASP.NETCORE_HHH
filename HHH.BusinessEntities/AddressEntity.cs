using System;
using System.Collections.Generic;
using System.Text;

namespace HHH.BusinessEntities
{
    public class AddressEntity
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
