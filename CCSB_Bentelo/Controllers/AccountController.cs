using CCSB_Bentelo.Models;
using CCSB_Bentelo.Utility;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCSB_Bentelo.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountController(ApplicationDbContext db,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Inloggen mislukt");
            }
            return View(model);
        }
        public async Task<IActionResult> Register()
        {

            // Create all roler if role admin not exists
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.Customer));
            }
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,

                    MiddleName = model.MiddleName,
                    LastName = model.LastName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Assign role to user and log the user in and redirect to the homepage
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Registratie", "ccsbBentelo@info.com"));
                    message.To.Add(new MailboxAddress(model.FirstName, model.Email));
                    message.Subject = "Bedankt voor het registreren";
                    message.Body = new TextPart("plain")
                    {
                        Text = "Beste " + model.FirstName + ",\n" + "Er is zojuist een account geregistreerd bij camper-en carvan stalling Bentelo. " +
                        "U kunt inloggen met de volgende gegevens:" + "\n" + "\n" + "Email: " + model.Email + "\n" + "Wachtwoord: " + model.Password + "\n" +
                        "\n" + "Als deze gegevens niet kloppen of als deze email niet voor u bestemd is, kan je altijd bellen naar: 0687654321" + "\n" +
                        "Met vriendelijke groet," + "\n" + "CCBS"
                    };
                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("ccsbBentelo@gmail.com", "CCSB@123");

                        client.Send(message);

                        client.Disconnect(true);
                    }
                    return RedirectToAction("Index", "Home");


                }
                // Add all errors to the modelstate
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
