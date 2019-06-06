namespace VacationRental.Contact.Domain.Extensions
{
    using AutoMapper;
    using DomainModel = Common.Model;
    using RepositoryModel = DataRepository.Model;

    public static class ContactExtensions
    {
        public static DomainModel.Contact Map(
            this RepositoryModel.Contact contact,
            IMapper mapper)
        {
            if (contact == null || mapper == null)
            {
                return null;
            }

            return mapper.Map<RepositoryModel.Contact, DomainModel.Contact>(contact);
        }

        public static RepositoryModel.Contact Map(
            this DomainModel.Contact contact,
            IMapper mapper)
        {
            if (contact == null || mapper == null)
            {
                return null;
            }

            return mapper.Map<DomainModel.Contact, RepositoryModel.Contact>(contact);
        }
    }
}
