namespace VacationRental.Contact.DataRepository.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Contact")]
    public class Contact
    {
        private const string Delimiter = ";";

        private string _otherSpokenLanguages = string.Empty;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Forename { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string NativeLanguage { get; set; }

        ////[NotMapped]
        ////[Required]
        ////public string[] OtherSpokenLanguages
        ////{
        ////    get => _otherSpokenLanguages.Split(Delimiter);

        ////    set => _otherSpokenLanguages = string.Join($"{Delimiter}", value);
        ////}

        ////[Required]
        ////public string AboutMe { get; set; }

        public ICollection<AboutMe> AboutMe { get; set; } = new List<AboutMe>();

        public Rental Rental { get; set; }

        public void Update(Contact contact)
        {
            Forename = contact.Forename;
            Surname = contact.Surname;
            Phone = contact.Phone;
            NativeLanguage = contact.NativeLanguage;
            AboutMe = contact.AboutMe;
        }
    }
}
