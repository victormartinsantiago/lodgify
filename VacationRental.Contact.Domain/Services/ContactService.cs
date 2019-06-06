namespace VacationRental.Contact.Domain.Services
{
    using Abstractions;
    using VacationRental.Contact.DataRepository.Abstractions;

    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
    }
}
