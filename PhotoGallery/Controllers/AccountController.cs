﻿using Common.DTO;
using Infrastructure.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using static PhotoGallery.Models.AccountViewModel;

namespace PhotoGallery.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _userService.GetAllUsers().ToList();
            return View(users);
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var users = _userService.GetAllUsers();

                var userExists = users.Any(x => x.Username == model.Username && x.Password == model.Password);

                if (userExists)
                {
                    return RedirectToAction("GetUsers", "Account");
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.InsertUser(new UserDTO
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                });
                return RedirectToAction("Login", "Account");
            }
            
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            // TO DO
            // destroy cookies!

            return RedirectToAction("Index", "Home");
        }
    }
}