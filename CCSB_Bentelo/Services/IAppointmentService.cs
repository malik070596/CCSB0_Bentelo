using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCSB_Bentelo.Models.ViewModels;
using CCSB_Bentelo.Utility;

namespace CCSB_Bentelo.Services
{
    public interface IAppointmentService
    {
        public List<KlantViewModel> GetKlantLijst();

        public List<AdminViewModel> GetAdminLijst();

    }
}
