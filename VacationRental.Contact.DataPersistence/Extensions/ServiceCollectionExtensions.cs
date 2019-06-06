﻿namespace VacationRental.Contact.DataRepository.Extensions
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;

    public static class ServiceCollectionExtensions
    {
        private const string DatabaseEnvironmentVariable = "database";

        private static string DatabaseName => System.Environment.GetEnvironmentVariable(DatabaseEnvironmentVariable) ?? "test";

        public static IServiceCollection AddDataRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ContactRepository>(options =>
                options.UseInMemoryDatabase(DatabaseName));

            return serviceCollection.AddTransient<IContactRepository, ContactRepository>();
        }
    }
}
