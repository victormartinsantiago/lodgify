namespace VacationRental.Contact.DataRepository.Abstractions
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Model;

    public interface IRentalRepository
    {
        DbSet<Rental> Rentals { get; set; }

        DbSet<Contact> Contacts { get; set; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
