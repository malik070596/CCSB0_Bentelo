using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CCSB_Bentelo.Models
{
    public class Factuur
    {
        [Key]
        public string FactuurId { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }


        public string LastName { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }

        public string PostalCode { get; set; }
        public DateTime TijdStip { get; set; }



        public string CreditCard { get; set; }

        public decimal Bedrag { get; set; }
        public int BedragTotaal { get; set; }
        public int Btw { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
