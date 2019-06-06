namespace VacationRental.Contact.DataRepository.Abstractions
{
    using Microsoft.EntityFrameworkCore;

    public interface IContactRepository
    {
        DbSet<Domain.Common.Model.Contact> Contacts { get; set; }
    }
}
