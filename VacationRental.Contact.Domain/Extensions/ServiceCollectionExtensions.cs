using Microsoft.Extensions.DependencyInjection;
using VacationRental.Contact.DataRepository.Extensions;
using VacationRental.Contact.Domain.Abstractions;
using VacationRental.Contact.Domain.Services;

namespace VacationRental.Contact.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContactService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDataRepository();
            return serviceCollection.AddTransient<IContactService, ContactService>();
        }
    }
}
