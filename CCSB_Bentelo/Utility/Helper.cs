using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CCSB_Bentelo.Utility
{
    public static class Helper
    {
        public static readonly string Admin = "Beheerder";
        public static readonly string Klant = "Klant";

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
            {
            var items = new List<SelectListItem>
            {
                new SelectListItem{Value = Helper.Admin , Text = Helper.Admin},
                new SelectListItem{Value = Helper.Klant , Text = Helper.Klant}
            };
            return items.OrderBy(s => s.Text).ToList();
            }

    }
}
