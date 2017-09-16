using System;
using System.Collections.Generic;
using System.Text;

namespace HHH.BusinessEntities
{
    public class HouseHoldEntity
    {
        public int PersonId { get; set; }
        public AddressEntity AddressObj { get; set; }
    }
}
