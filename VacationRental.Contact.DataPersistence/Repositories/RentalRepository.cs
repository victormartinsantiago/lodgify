namespace VacationRental.Contact.DataRepository.Repositories
{
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class RentalRepository : DbContext, IRentalRepository
    {
        public RentalRepository(DbContextOptions<RentalRepository> options)
            : base(options)
        {
        }

        public DbSet<Model.Rental> Rentals { get; set; }

        public DbSet<Model.Contact> Contacts { get; set; }

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
            modelBuilder.Entity<Model.Rental>()
                .HasMany(c => c.Contacts)
                .WithOne(e => e.Rental);

            modelBuilder.Entity<Model.Contact>()
                .Property<string>("OtherSpokenLanguagesCollection")
                .HasField("_otherSpokenLanguages");
        }
    }
}
