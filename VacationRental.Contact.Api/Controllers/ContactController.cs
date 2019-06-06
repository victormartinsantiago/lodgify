namespace VacationRental.Contact.Api.Controllers
{
    using System.Threading.Tasks;
    using Domain.Abstractions;
    using Domain.Common.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/v1/vacationrental/{rentalId:int}/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(
            ILoggerFactory loggerFactory,
            IContactService contactService)
        {
            _contactService = contactService;
            _logger = loggerFactory.CreateLogger<ContactController>();
        }

        [HttpGet]
        public async Task<Contact> Get([FromRoute] int rentalId)
        {
            _logger.LogInformation($"Fetching contact for rental with ID '{rentalId}'");

            return await _contactService.GetDefaultContactByRentalIdAsync(rentalId);
        }

        [HttpPut]
        public async Task Put([FromRoute] int rentalId, [FromBody] Contact model)
        {
            _logger.LogInformation($"Updating contact for rental with ID '{rentalId}'");

            await _contactService.AddOrUpdateDefaultContactAsync(rentalId, model);
        }
    }
}
