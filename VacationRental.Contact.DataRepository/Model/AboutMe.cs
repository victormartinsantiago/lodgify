namespace VacationRental.Contact.DataRepository.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AboutMe")]
    public class AboutMe
    {
        [Key]
        [Column(Order = 0)]
        public int ContactId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Language { get; set; }

        public string Text { get; set; }
    }
}
