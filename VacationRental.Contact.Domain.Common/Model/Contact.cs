namespace VacationRental.Contact.Domain.Common.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Contact
    {
        public int Id { get; set; }

        public int RentalId { get; set; }

        [Required]
        public string Forename { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string NativeLanguage { get; set; }

        [NotMapped]
        [Required]
        public string[] OtherSpokenLanguages { get; set; }

        [Required]
        public string AboutMe { get; set; }
    }
}
