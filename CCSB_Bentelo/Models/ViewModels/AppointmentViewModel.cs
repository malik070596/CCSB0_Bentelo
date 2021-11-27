using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Bentelo.Models.ViewModels

{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        [Display(Name = "Wachtwoord")]
        public DateTime TijdStip { get; set; }
        public string Action { get; set; }
        [Display(Name = "Klant2")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}