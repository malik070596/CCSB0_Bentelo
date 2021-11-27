using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Bentelo.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleType { get; set; }
        public decimal Length { get; set; }
        public string VehicleKind { get; set; }
        public string LicensePlate { get; set; }
        public string ApplicationUserId { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string PostalCode { get; set; }

        public DateTime DatumGemaakt { get { return DateTime.Now; } }
        public string City { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Beds { get; set; }
        public bool Bicycle { get; set; }
        public bool Airco { get; set; }
        public int Km { get; set; }
        public int Power { get; set; }

        public string Type { get; set; }

        public bool Tow { get; set; }

        public int Weight { get; set; }
        public bool Water { get; set; }



    }
}