namespace VacationRental.Contact.Domain.Abstractions
{
    using System.Threading.Tasks;
    using Common.Model;

    public interface IContactService
    {
        Task<Contact> GetDefaultContactByRentalIdAsync(int rentalId);

        Task AddOrUpdateDefaultContactAsync(int rentalId, Contact contact);
    }
}
