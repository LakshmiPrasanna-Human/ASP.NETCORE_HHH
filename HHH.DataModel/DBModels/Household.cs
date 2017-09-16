using System;
using System.Collections.Generic;

namespace HHH.DataModel.DBModels
{
    public partial class Household
    {
        public int HouseHoldId { get; set; }
        public int PersonId { get; set; }
        public int AddressId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Address Address { get; set; }
        public Person Person { get; set; }
    }
}
