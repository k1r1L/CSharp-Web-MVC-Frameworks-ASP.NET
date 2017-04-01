using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CameraBazaar.App.Controllers
{
    using Models.ViewModels.User;
    using Services;

    [Authorize]
    public class UserController : Controller
    {
        private UserService service;

        public UserController()
        {
            this.service = new UserService();
        }

        // GET: User
        public ActionResult Profile(string name)
        {
            ProfileVm profileVm = this.service.RetrieveProfileVm(name);

            return View(profileVm);
        }
    }
}