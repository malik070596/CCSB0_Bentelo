using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Bentelo.Models.ViewModels
{
    public class VehicleViewModel
    {
        [DisplayName("Merk")]
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        public string VehicleBrand { get; set; }
        [Required(ErrorMessage = "{0} dit veld is verplicht.")]
        [DisplayName("Type voertuig")]
        public string VehicleType { get; set; }
        [DisplayName("Lengte Voertuig")]
        public decimal Length { get; set; }
        [DisplayName("Soort Voertuig")]
        public string VehicleKind { get; set; }
        [DisplayName("Kenteken")]
        public string LicensePlate { get; set; }
        [DisplayName("Klant")]

        public string CustomerName { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

}
