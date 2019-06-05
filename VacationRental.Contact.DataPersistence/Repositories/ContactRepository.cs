using Microsoft.EntityFrameworkCore;
using VacationRental.Contact.DataRepository.Abstractions;

namespace VacationRental.Contact.DataRepository.Repositories
{
    public class ContactRepository : DbContext, IContactRepository
    {
        public ContactRepository(DbContextOptions<ContactRepository> options)
            : base(options)
        { }

        public DbSet<Domain.Common.Model.Contact> Contacts { get; set; }
    }
}
