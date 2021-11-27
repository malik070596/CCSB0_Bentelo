using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Bentelo.Utility
{
    public static class Helper
    {
        public static readonly string Admin = "Beheerder";
        public static readonly string Customer = "Klant";

        public static readonly string Caravan = "Caravan";
        public static readonly string Camper = "Camper";

        public static readonly string AppointmentAdded = "Afspraak succesvol opgeslagen";
        public static readonly string AppointmentConfirmed = "Afspraak bevestigd";
        public static readonly string AppointmentUpdated = "Afspraak succesvol gewijzigd";
        public static readonly string AppointmentDeleted = "Afspraak succesvol verwijderd";

        public static readonly string AppointmentAddError = "Er ging iets mis. Afspraak niet toegevoegd";
        public static readonly string AppointmentConfirmError = "Er ging iets mis. Afspraak niet bevestigd";
        public static readonly string SomethingWentWrong = "Er ging iets mis. Afspraak niet gewijzigd.";
        public static readonly string AppointmentUpdateError = "Er ging iets mis. Afspraak niet gwijzigd.";

        public static int Succes_code = 1;
        public static int Failure_code = 0;

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem{ Value=Helper.Admin , Text=Helper.Admin},
                new SelectListItem{ Value=Helper.Customer, Text=Helper.Customer}
            };
            return items.OrderBy(s => s.Text).ToList();
        }
        public static List<SelectListItem> GetVehicleForDropDown(bool isAdmin)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem{ Value=Helper.Caravan , Text=Helper.Caravan},
                new SelectListItem{ Value=Helper.Camper, Text=Helper.Camper}
            };
            return items.OrderBy(s => s.Text).ToList();
        }

    }
}