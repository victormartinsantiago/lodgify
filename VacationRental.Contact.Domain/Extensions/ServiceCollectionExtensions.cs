namespace VacationRental.Contact.Domain.Extensions
{
    using Abstractions;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using VacationRental.Contact.DataRepository.Extensions;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContactService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDataRepository();
            return serviceCollection.AddTransient<IContactService, ContactService>();
        }
    }
}
