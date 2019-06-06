namespace VacationRental.Contact.DataRepository.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rental")]
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
