using Microsoft.EntityFrameworkCore;

namespace VacationRental.Contact.DataRepository.Abstractions
{
    public interface IContactRepository
    {
        DbSet<Domain.Common.Model.Contact> Contacts { get; set; }
    }
}
