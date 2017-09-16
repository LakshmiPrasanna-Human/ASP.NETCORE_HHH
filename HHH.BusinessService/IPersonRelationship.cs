using System;
using System.Collections.Generic;
using System.Text;
using HHH.BusinessEntities;

namespace HHH.BusinessService
{
    public interface  IPersonRelationship
    {
        bool CreatePersonRelationship(StudentPersonRelationshipEntity personRelationshipentity);
        bool UpdatePersonRelationship(StudentPersonRelationshipEntity personRelationshipentity);
        bool DeletePersonRelationship(StudentPersonRelationshipEntity personRelationshipentity);
        

    }
}
