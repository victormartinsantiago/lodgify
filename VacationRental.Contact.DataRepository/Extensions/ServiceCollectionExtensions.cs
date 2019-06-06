namespace VacationRental.Contact.DataRepository.Extensions
{
    using System;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;

    public static class ServiceCollectionExtensions
    {
        private const string DatabaseName = "database";
        private const string ConnectionStringEnvironmentVariable = "CONNECTION_STRING";

        private static string ConnectionString => Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariable);

        public static IServiceCollection AddInMemoryDataRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<RentalRepository>(options =>
                options.UseInMemoryDatabase(DatabaseName));

            return serviceCollection.AddSingleton<IRentalRepository, RentalRepository>();
        }

        public static IServiceCollection AddSqlServerDataRepository(this IServiceCollection serviceCollection)
        {
            var connectionString = ConnectionString;

            if (connectionString == null)
            {
                throw new ArgumentException($"A valid connection string must be passed via the environment variable '{ConnectionStringEnvironmentVariable}'");
            }

            serviceCollection.AddDbContext<RentalRepository>(options =>
                options.UseSqlServer(DatabaseName));

            return serviceCollection.AddTransient<IRentalRepository, RentalRepository>();
        }
    }
}
