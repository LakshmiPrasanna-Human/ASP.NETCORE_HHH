using System;
using System.Collections.Generic;

namespace HHH.DataModel.DBModels
{
    public partial class Address
    {
        public Address()
        {
            Household = new HashSet<Household>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Household> Household { get; set; }
    }
}
