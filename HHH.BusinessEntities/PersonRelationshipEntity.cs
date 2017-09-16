using System;
using System.Collections.Generic;
using System.Text;

namespace HHH.BusinessEntities
{

    public class PersonRelationshipEntity
    {
        public string RelatioshipType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

    }

    public class StudentPersonRelationshipEntity
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentMiddleName { get; set; }
        public List<PersonRelationshipEntity> RelationShipEntities { get; set; }
    }
}
