using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Bentelo.Models
{
    [Keyless]
    public class RegisterViewModel
    {

        [DisplayName("Voorletters*")]
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        public string Initials { get; set; }
        [DisplayName("Voornaam*")]
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        public string FirstName { get; set; }
        [DisplayName("Tussenvoegsel")]
        public string MiddleName { get; set; }
        [DisplayName("Achternaam*")]
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        public string LastName { get; set; }
        [DisplayName("Adres*")]
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        [DataType(DataType.PostalCode)]
        [DisplayName("Postcode*")]
        public string PostalCode { get; set; }
        [DisplayName("Woonplaats*")]
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        public string City { get; set; }
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        [DataType(DataType.Date)]
        [DisplayName("Geboortedatum*")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        [DataType(DataType.CreditCard)]
        [DisplayName("Bankrekening*")]
        public string CreditCard { get; set; }
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telefoonnmmr*")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail*")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        [DataType(DataType.Password)]
        [DisplayName("Wachtwoord*")]
        [StringLength(100, ErrorMessage = "Het {0} moet minstens {2} tekens bevatten.",
            MinimumLength = 6)]
        public string Password { get; set; }
        [DisplayName("Bevestig wachtwoord*")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen")]
        public string PasswordConfirm { get; set; }
        [DisplayName("Rol*")]
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        public string RoleName { get; set; }

    }
}
