namespace VacationRental.Contact.DataRepository.Repositories
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ContactRepository : DbContext, IContactRepository
    {
        public ContactRepository(DbContextOptions<ContactRepository> options)
            : base(options)
        {
        }

        public DbSet<Domain.Common.Model.Contact> Contacts { get; set; }
    }
}
