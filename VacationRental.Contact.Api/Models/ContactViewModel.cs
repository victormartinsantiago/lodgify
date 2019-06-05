﻿namespace VacationRental.Contact.Api.Models
{
    public class ContactViewModel
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string NativeLanguage { get; set; }
        public string[] OtherSpokenLanguages { get; set; }
        public string AboutMe { get; set; }
    }
}