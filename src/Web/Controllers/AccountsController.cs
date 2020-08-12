using Core.Interfaces;
using Core.Models;
using Core.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using Web.Converters;

namespace Web.Controllers
{
    public class AccountsController : Controller
    {
        private IUserService _userService;
        private IRoleManager _roleManager;

        public AccountsController(
            IUserService userService,
            IRoleManager roleManager
            )
        {
            _userService = userService;

            _roleManager = roleManager;
        }

        #region Public methods

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Profile", "Accounts");
            }

            return View();
        }

        /// <summary>
        /// Sign in method.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(SignInViewModel model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "Model was null.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                User user = _userService.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    Authenticate(user);

                    return RedirectToAction("Profile", "Accounts");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Profile", "Accounts");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "Model was null.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                User user = _userService.Users.FirstOrDefault(u => u.Email == model.Email);

                if (user == null)
                {
                    user = new User(model.Email, model.Password, _roleManager.GetDefaultUserRole());

                    _userService.Add(user);

                    Authenticate(user);

                    return RedirectToAction("Profile", "Accounts");
                }
                else
                {
                    ModelState.AddModelError("", $"User with email {model.Email} is already exists.");
                }
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            var model = UserConverter.Convert(GetUser(User));

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AdminDashboard()
        {
            var users = UserConverter.Convert(_userService.Users);

            ViewBag.Users = users;

            var model = UserConverter.Convert(GetUser(User));

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Accounts");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult ModifyRole()
        {
            if (User.Identity.IsAuthenticated)
            {
                _userService.SetRole(ViewBag.UserId, ViewBag.RoleName);

                return RedirectToAction("AdminDashboard", "Accounts");
            }

            return RedirectToAction("Profile", "Accounts");
        }

        #endregion

        #region Private methods

        private void Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private User GetUser(ClaimsPrincipal userClaims)
        {
            var user = _userService.Users.FirstOrDefault(u => u.Email == userClaims.Identity.Name);

            if (user != null)
            {
                return user;
            }

            throw new Exception();
        }

        #endregion
    }
}
