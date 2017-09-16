using System;
using System.Collections.Generic;

namespace HHH.DataModel.DBModels
{
    public partial class RelationshipType
    {
        public int RelationshipType1 { get; set; }
        public string RelationshipTypeCode { get; set; }
        public string RelatioshipTypeDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
