using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HHH.BusinessService;
using HHH.BusinessEntities;

namespace HHH.WebAPI.Controllers
{
    public class PersonRelationController : Controller
    {
        private readonly IPersonRelationship _personRelationServices;

        public PersonRelationController(IPersonRelationship personRelationship)
        {
            _personRelationServices = personRelationship;
        }

        [HttpPost]
        [Route("api/PersonRelation/CreatePersonRelation")]
        public async Task<IActionResult> CreatePersonRelation([FromBody]StudentPersonRelationshipEntity personRelationEntity)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _personRelationServices.CreatePersonRelationship(personRelationEntity);
            return Ok();
        }

      
        [HttpPut]
        [Route("api/PersonRelation/UpdatePersonRelation")]
        public async Task<IActionResult> UpdatePersonRelation([FromBody]StudentPersonRelationshipEntity personRelationEntity)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _personRelationServices.UpdatePersonRelationship(personRelationEntity);
            return Ok();
        }
       

        [HttpDelete]
        [Route("api/PersonRelation/DeletePersonRelation")]
        public async Task<IActionResult> DeletePersonRelation([FromBody]StudentPersonRelationshipEntity personRelationEntity)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _personRelationServices.DeletePersonRelationship(personRelationEntity);
            return Ok();
        }
    }
}