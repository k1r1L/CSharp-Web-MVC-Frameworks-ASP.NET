namespace CameraBazaar.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models.ViewModels.Camera;
    using Services;

    [Authorize]
    public class CameraController : Controller
    {
        private CameraService service;

        public CameraController()
        {
            this.service = new CameraService();
        }

        // GET: Camera
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddCameraVm bindingModel)
        {
            if (ModelState.IsValid)
            {
                string username = this.HttpContext.User.Identity.Name;
                this.service.AddCamera(bindingModel, username);
                return this.RedirectToAction("All");
            }

            return this.View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<AllCameraVm> allCameraVms = this.service.RetrieveAllCameras();

            return View(allCameraVms);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Details(int id)
        {
            DetailsCameraVm detailsCameraVm = this.service.RetrieveCamera(id);

            return this.View(detailsCameraVm);
        }
    }
}