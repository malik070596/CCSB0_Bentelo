using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using CCSB_Bentelo.Models;
using CCSB_Bentelo.Models.ViewModels;
using CCSB_Bentelo.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CCSB_Bentelo.Services
{
    public class AppointmentService : IAppointmentService
    {
        #region Fields
        private readonly ApplicationDbContext _db;
        #endregion

        #region Constructors
        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        public List<AdminViewModel> GetAdminLijst()
        {
            var admins = (from user in _db.Users
                          join userRole in _db.UserRoles on user.Id equals userRole.UserId
                          join role in _db.Roles.Where(x => x.Name == Helper.Admin) on userRole.RoleId equals role.Id
                          select new AdminViewModel
                          {
                              Id = user.Id,
                              Name = string.IsNullOrEmpty(user.MiddleName) ?
                           user.FirstName + "" + user.LastName :
                           user.FirstName + "" + user.MiddleName + "" + user.LastName
                          }
                              ).OrderBy(u => u.Name).ToList();
            return admins;
        }

        public List<KlantViewModel> GetKlantLijst()
        {
            var klant = (from user in _db.Users
                         join userRole in _db.UserRoles on user.Id equals userRole.UserId
                         join role in _db.Roles.Where(x => x.Name == Helper.Admin) on userRole.RoleId equals role.Id
                         select new KlantViewModel
                         {
                             Id = user.Id,
                             Name = string.IsNullOrEmpty(user.MiddleName) ?
                             user.FirstName + " " + user.LastName :
                             user.FirstName + " " + user.MiddleName + " " + user.LastName
                         }
                         ).OrderBy(u => u.Name).ToList();
            return klant;
        }
    }
}