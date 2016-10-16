
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

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CountryList = manager.GetCountry();
            return View();
        }

        //public JsonResult AddUser(string username, string password)
        //{
        //    UserModel userModel = new UserModel();

        //    int result = MVCUserManager.AddUser(userModel);

        //    return Json(new { result = result });
        //}


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}