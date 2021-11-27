using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Bentelo.Models
{
    public class AppointmentModel
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime TijdStip { get; set; }
        [Display(Name = "Ophalen of Wegbrengen")]
        public string Action { get; set; }
        [Display(Name = "Klant")]
        public string ApplicationUserId { get; set; }


        public ApplicationUser ApplicationUser { get; set; }


    }
}