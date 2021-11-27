using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Bentelo.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(MiddleName))
                {
                    return FirstName + " " + LastName;
                }
                else
                {
                    return FirstName + " " + MiddleName + " " + LastName;
                }

            }

        }

        public string Address { get; set; }


    }
}
