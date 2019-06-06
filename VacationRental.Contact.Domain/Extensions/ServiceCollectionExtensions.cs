namespace VacationRental.Contact.Domain.Extensions
{
    using Abstractions;
    using AutoMapper;
    using Mappers;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using VacationRental.Contact.DataRepository.Extensions;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRentalServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapperProfiles();
            serviceCollection.AddDataRepository();
            return serviceCollection.AddTransient<IContactService, ContactService>();
        }

        private static void AddAutoMapperProfiles(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            serviceCollection.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
