
using PasteBookFinalProject.Managers;
using PasteBookFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasteBookFinalProject.Controllers
{
    public class PasteBookController : Controller
    {
        MVCManager manager = new MVCManager();
        static LoginViewModel mainModel = new LoginViewModel();
        [HttpGet]
        public ActionResult Home()
        {
            if (Session["CountryList"] == null)
            {
                Session["CountryList"] = new SelectList(manager.GetCountry(), "CountryID", "CountryName");
            }
            
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "UserModel")]LoginViewModel model)
        {
            if (manager.CheckEmailAddress(model.userModel.EmailAddress))
            {
                ModelState.AddModelError("EmailAddress", "Email Address already exists.");
            }

            if (manager.CheckUsername(model.userModel.Username))
            {
                ModelState.AddModelError("Username", "Username already exists.");
            }

            if (ModelState.IsValid)
            {
                manager.AddUser(model.userModel);
            }
            return View("Home");

        }

        public ActionResult Login([Bind(Include ="UserLoginModel")] LoginViewModel model)
        {
            //if (manager.LoginUser(model.LoginUser))
            //{
            //    Session["User"] = model.LoginUser.EmailAddress;
            //    return View();
            //}
            //else
            //{
            //    ModelState.AddModelError("LoginUser.Password", "Invalid Username or Password");
            //    return View("Index", modelForCountry);
            //}

            return View();

        }

    }
}