using VacationRental.Contact.DataRepository.Abstractions;
using VacationRental.Contact.Domain.Abstractions;

namespace VacationRental.Contact.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
    }
}
