using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HHH.BusinessService;
using HHH.BusinessEntities;

namespace HHH.WebAPI.Controllers
{
    public class HouseholdController : Controller
    {
        private readonly IHouseHoldService _householdServices;

        public HouseholdController(IHouseHoldService householdService)
        {
            _householdServices = householdService;
        }

      
        [HttpPost]
        [Route("api/Household/CreateHousehold")]
        public async Task<IActionResult> CreateHousehold([FromBody]HouseHoldEntity houseHoldEntity)
        {

           // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
           // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _householdServices.CreateHouseHold(houseHoldEntity, "MiSiS");
            return Ok();
        }

        [HttpGet]
        [Route("api/Household/GetAllHouseHold")]
        public IEnumerable<HouseHoldEntity> GetAllHouseHold()
        {
            return _householdServices.GetAllHouseHold();
        }

        [HttpPut]
        [Route("api/Household/UpdateHousehold")]
        public async Task<IActionResult> UpdateHousehold([FromBody]HouseHoldEntity houseHoldEntity)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _householdServices.UpdateHouseHold(houseHoldEntity, "MiSiS");
            return Ok();
        }
        [HttpDelete]
        [Route("api/Household/DeleteHousehold")]
        public async Task<IActionResult> DeleteHousehold(int householdid)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _householdServices.DeleteHouseHold(householdid, "MiSiS");
            return Ok();
        }

        [HttpGet]
        [Route("api/Household/GetHouseholdPrimaryGuardian")]
        public async Task<IActionResult> GetHouseholdPrimaryGuardian(int householdid)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _householdServices.GetHouseHoldPrimaryGuardian(householdid);
            return Ok();
        }

        [HttpPut]
        [Route("api/Household/UpdateHouseholdPrimaryGuardian")]
        public async Task<IActionResult> UpdateHouseholdPrimaryGuardian([FromBody]int householdid, [FromBody]string PrimaryGuardianName)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _householdServices.UpdatePrimaryGuardian(householdid, PrimaryGuardianName, "MiSiS");
            return Ok();
        }

    }
}