namespace VacationRental.Contact.Domain.Mappers
{
    using AutoMapper;
    using DomainModel = Common.Model;
    using RepositoryModel = DataRepository.Model;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AddMappings();
        }

        private void AddMappings()
        {
            CreateMap<RepositoryModel.Contact, DomainModel.Contact>();
            CreateMap<DomainModel.Contact, RepositoryModel.Contact>();
        }
    }
}
