using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace VacationRental.Contact.Api.Controllers
{
    [Route("api/v1/vacationrental/{rentalId:int}/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IDictionary<int, Domain.Common.Model.Contact> _state;

        public ContactController(IDictionary<int, Domain.Common.Model.Contact> state)
        {
            _state = state;
        }

        [HttpGet]
        public Domain.Common.Model.Contact Get([FromRoute] int rentalId)
        {
            return _state[rentalId];
        }

        [HttpPut]
        public void Put([FromRoute] int rentalId, [FromBody] Domain.Common.Model.Contact model)
        {
            _state[rentalId] = model;
        }
    }
}
