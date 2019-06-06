namespace VacationRental.Contact.Domain.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Abstractions;
    using AutoMapper;
    using Common.Exceptions;
    using Common.Model;
    using Extensions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using VacationRental.Contact.DataRepository.Abstractions;

    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ContactService> _logger;
        private readonly IRentalRepository _rentalRepository;

        public ContactService(
            IMapper mapper,
            ILoggerFactory loggerFactory,
            IRentalRepository rentalRepository)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _logger = loggerFactory.CreateLogger<ContactService>();
        }

        public async Task<Contact> GetDefaultContactByRentalIdAsync(int rentalId)
        {
            _logger.LogInformation($"Fetching default contact for rental with ID '{rentalId}'");

            var rental = await _rentalRepository
                .Rentals
                .SingleOrDefaultAsync(r => r.Id == rentalId);

            if (rental == null)
            {
                throw new NotFoundException($"Rental with ID '{rentalId}' could not be found.");
            }

            return rental
                .Contacts
                .SingleOrDefault()
                .Map(_mapper);
        }

        public async Task AddOrUpdateDefaultContactAsync(int rentalId, Contact contact)
        {
            _logger.LogInformation($"Updating contact for rental with ID '{rentalId}'");

            var rental = await _rentalRepository
                .Rentals
                .SingleOrDefaultAsync(r => r.Id == rentalId);

            if (rental == null)
            {
                // Dummy rental so that contacts can be appended. This won't happen in a real scenario.
                // We would be throwing a NotFoundException
                _logger.LogInformation($"Adding new rental '{rentalId}'");

                var trackingEntity = await _rentalRepository
                    .Rentals
                    .AddAsync(new DataRepository.Model.Rental { Id = rentalId });

                rental = trackingEntity.Entity;
            }

            var existingContact = rental.Contacts.FirstOrDefault();
            var repoContract = contact.Map(_mapper);

            if (existingContact == null)
            {
                rental.Contacts.Add(repoContract);
            }
            else
            {
                existingContact.Update(repoContract);
            }

            await _rentalRepository.SaveChangesAsync();
        }
    }
}
