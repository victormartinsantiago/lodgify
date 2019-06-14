namespace VacationRental.Contact.Domain.Mappers
{
    using System.Linq;
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
            CreateMap<RepositoryModel.Contact, DomainModel.Contact>()
                .ForMember(
                    dest => dest.AboutMe,
                    opt => opt.MapFrom(src => src.AboutMe.ToDictionary(d => d.Language, v => v.Text)));

            CreateMap<DomainModel.Contact, RepositoryModel.Contact>()
                 .ForMember(
                    dest => dest.AboutMe,
                    opt => opt.MapFrom(src => src.AboutMe.Select(d => new RepositoryModel.AboutMe { ContactId = src.Id, Language = d.Key, Text = d.Value })));
        }
    }
}
