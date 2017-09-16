using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HHH.BusinessService;
using HHH.BusinessEntities;

namespace HHH.WebAPI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personServices;

        public PersonController(IPersonService personService)
        {
            _personServices = personService;
        }

        [HttpPost]
        [Route("api/Person/CreatePerson")]
        public async Task<IActionResult> CreatePerson([FromBody]PersonEntity personEntity)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _personServices.CreatePerson(personEntity, "MiSiS");
            return Ok();
        }

        [HttpGet]
        [Route("api/Person/GetAll")]
        public IEnumerable<PersonEntity> GetAll()
        {
            return _personServices.GetAllPerson();
        }

        [HttpPut]
        [Route("api/Person/UpdatePersonInfo")]
        public async Task<IActionResult> UpdatePersonInfo([FromBody]PersonInfo personEntity)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _personServices.UpdatePersonInfo(personEntity, "MiSiS");
            return Ok();
        }
        [HttpPut]
        [Route("api/Person/UpdatePersonAddress")]
        public async Task<IActionResult> UpdatePersonAddress([FromBody]PersonAddress pAddress)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _personServices.UpdatePersonAddress(pAddress, "MiSiS");
            return Ok();
        }

        [HttpDelete]
        [Route("api/Person/DeletePerson")]
        public async Task<IActionResult> DeletePerson(string FirstName, string MiddleName, String LastName)
        {

            // var claimPrinciple = (ClaimsPrincipal)ActionContext.RequestContext.Principal;
            // Clientid = claimPrinciple.FindFirst(x => x.Type == "client_name").ToString();
            _personServices.DeletePerson(FirstName, MiddleName, LastName, "MiSiS");
            return Ok();
        }

       
    }
}