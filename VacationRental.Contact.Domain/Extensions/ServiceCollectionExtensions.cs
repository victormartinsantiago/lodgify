namespace VacationRental.Contact.Domain.Extensions
{
    using System;
    using Abstractions;
    using AutoMapper;
    using DataRepository.Extensions;
    using DataRepository.Repositories;
    using Mappers;
    using Microsoft.Extensions.DependencyInjection;
    using Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRentalServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapperProfiles();
            serviceCollection.AddInMemoryDataRepository();

            // Uncomment this line to use a full SqlServer database and comment out the line above
            // Make sure to uncomment the call to EnsureDatabaseCreated in Startup.cs so that
            // the sql schema is generated the first time on the target database
            // serviceCollection.AddSqlServerDataRepository();
            return serviceCollection.AddTransient<IContactService, ContactService>();
        }

        public static void EnsureDatabaseCreated(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                serviceScope.ServiceProvider.GetService<RentalRepository>()
                    .Database.EnsureCreated();
            }
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
