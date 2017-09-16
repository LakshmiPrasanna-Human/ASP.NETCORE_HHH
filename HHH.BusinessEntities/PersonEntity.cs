using System;
using System.Collections.Generic;
using System.Text;

namespace HHH.BusinessEntities
{
    public class PersonEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string StateId { get; set; }
        public IEnumerable<HouseHoldEntity> HouseHoldData { get; set; }
        public bool IsStudent { get; set; }
        public bool IsPrimaryGurdian { get; set; }

    }
}
