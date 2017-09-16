using System;
using System.Collections.Generic;
using System.Text;
using HHH.BusinessEntities;

namespace HHH.BusinessService
{
    public interface IHouseHoldService
    {

        int CreateHouseHold(HouseHoldEntity obj, string ClientidClaim);

        int UpdateHouseHold(HouseHoldEntity obj, string ClientidClaim);

        bool DeleteHouseHold(int householdid, string ClientidClaim);

        bool UpdatePrimaryGuardian(int HouseHoldId, string newGurdianPerson, string ClientidClaim);

        IEnumerable<HouseHoldEntity> GetAllHouseHold();

        HouseHoldEntity GetHouseHoldByPersonID(int personid, string ClientidClaim);

        HouseHoldEntity GetHouseHoldByID(int householdId, string ClientidClaim);

        string GetHouseHoldPrimaryGuardian(int householdid);


    }
}
