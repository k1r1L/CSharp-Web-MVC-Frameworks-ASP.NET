namespace CarDealerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CarDealer.BindingModels;
    using CarDealer.Models;
    using CarDealer.Services;

    [RoutePrefix("account")]
    public class AccountController : Controller
    {
        private AccountService service;

        public AccountController()
        {
            this.service = new AccountService();
            ViewBag.IsLogged = this.service.IsLogged();
        }

        [Route("register")]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        public ActionResult Register([Bind(Include = ("Email,Username,Password"))] RegisterUserBindingModel rubm)
        {
            if (ModelState.IsValid)
            {
                this.service.RegisterUser(rubm);
                return RedirectToAction("Login");
            }

            return View();
        }

        [Route("login")]
        [HttpGet]
        public ActionResult Login()
        {
            if (this.service.IsLogged())
            {
                return Redirect("/home/index");
            }

            return View();
        }

        [Route("login")]
        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] LoginUserBindingModel lubm)
        {
            if (this.service.IsLogged())
            {
                return Redirect("/home/index");
            }

            if (ModelState.IsValid && this.service.UserExists(lubm))
            {
                this.service.LoginUser(lubm, Session.SessionID);
                return Redirect("/home/index");
            }

            return View();
        }

        [Route("logout")]
        [HttpGet]
        public ActionResult Logout()
        {
            if (this.service.IsLogged())
            {
                this.service.LogoutUser();
            }

            return Redirect("/home/index");
        }

        [Route("getcurrentusername")]
        public string GetCurrentUsername()
        {
            if (this.service.IsLogged())
            {
                User currentUser = this.service.GetCurrentUser();

                return currentUser.Username;
            }
            else
            {
                throw new ArgumentNullException($"No currently logged user!");
            }
        }
    }
}