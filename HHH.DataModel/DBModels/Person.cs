using System;
using System.Collections.Generic;

namespace HHH.DataModel.DBModels
{
    public partial class Person
    {
        public Person()
        {
          //  Household = new HashSet<Household>();
            Household = new HashSet<Household>();
        }

        public int PersonId { get; set; }
        public int AddressId { get; set; }
        public int? HouseholdId { get; set; }
        public int? StudentId { get; set; }
        public string StateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }

        public ICollection<Household> Household { get; set; }
    }
}
