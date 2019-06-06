namespace VacationRental.Contact.DataRepository.Abstractions
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public interface IRentalRepository
    {
        DbSet<Model.Rental> Rentals { get; set; }

        DbSet<Model.Contact> Contacts { get; set; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
