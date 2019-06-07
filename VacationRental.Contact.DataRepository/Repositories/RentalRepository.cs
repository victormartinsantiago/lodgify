namespace VacationRental.Contact.DataRepository.Repositories
{
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Model;

    public class RentalRepository : DbContext, IRentalRepository
    {
        public RentalRepository(DbContextOptions<RentalRepository> options)
            : base(options)
        {
        }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>()
                .HasMany(c => c.Contacts)
                .WithOne(e => e.Rental);

            // string[] cannot be saved directly to the DB.
            // We need to map it to a backing field of type string
            // were tokens are split by a delimiter
            modelBuilder.Entity<Contact>()
                .Property<string>("OtherSpokenLanguagesCollection")
                .HasField("_otherSpokenLanguages");
        }
    }
}
