using System;
using System.Collections.Generic;

namespace HHH.DataModel.DBModels
{
    public partial class PersonRelationship
    {
        public int PersonRelationshipId { get; set; }
        public int PersonId { get; set; }
        public int StudentPersonId { get; set; }
        public int RelationshipTypeId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
