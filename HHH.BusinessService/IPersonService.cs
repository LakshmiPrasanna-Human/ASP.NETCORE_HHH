using System;
using System.Collections.Generic;
using System.Text;
using HHH.BusinessEntities;

namespace HHH.BusinessService
{
    public interface IPersonService
    {
        bool CreatePerson(PersonEntity obj, string ClientidClaim);

        bool DeletePerson(string FirstName, string MiddleName, String LastName, string ClientidClaim);

        IEnumerable<PersonEntity> GetAllPerson();

        PersonEntity GetPersonByPersonID(int personid, string ClientidClaim);

        bool UpdatePersonInfo(PersonInfo obj, string ClientidClaim);

        bool UpdatePersonAddress(PersonAddress pAddress, string ClientidClaim);

       
    }
}
