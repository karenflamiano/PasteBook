using PasteBookFinalProject.Managers;
using PasteBookFinalProject.Models;
using PasteBookBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasteBookEntityFramework;

namespace PasteBookFinalProject.Controllers
{
    public class PasteBookController : Controller
    {
        MVCManager manager = new MVCManager();
        //PasteBookBusinessLogic manager = new PasteBookBusinessLogic();
       
        static LoginViewModel mainModel = new LoginViewModel();
        
        [HttpGet]
        public ActionResult Index()
        {
            LoginViewModel model = new LoginViewModel();
            model.CountryList = manager.GetCountry();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "UserLoginModel")]LoginViewModel model)
        {
            if (manager.CheckEmailAddress(model.user.EMAIL_ADDRESS))
            {
                ModelState.AddModelError("EmailAddress", "Email Address already exists.");
            }

            if (manager.CheckUsername(model.user.USER_NAME))
            {
                ModelState.AddModelError("Username", "Username already exists.");
            }

            if (ModelState.IsValid)
            {
                manager.AddUser(model.user);
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Home()
        {
            VMPostUser model = new VMPostUser();
            model.UserModelDetails = manager.GetUserDetails(Session["User"].ToString());
            return View(model);
        }

        
        public JsonResult AddPost(string postContent)
        {
            USER model = manager.GetUserDetails(Session["User"].ToString());
            POST postModel = new POST();

            postModel.POSTER_ID = model.ID;
            postModel.PROFILE_OWNER_ID = model.ID;
            postModel.CONTENT = postContent;
            postModel.CREATED_DATE = DateTime.Now;
            
            int result =  manager.AddPost(postModel);
            return Json(new { result = result } ); 
        }

        [HttpPost]
        public ActionResult Home([Bind(Include = "LoginModel")] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (manager.CheckUserCredentials(model))
                {
                    Session["User"] = model.LoginModel.LoginEmail;
                    Session["ID"] = manager.GetUserID(Session["User"].ToString());

                    USER userModel = manager.GetUserDetails(Session["User"].ToString());
                    return RedirectToAction("Home", "PasteBook");
                }
                else
                {
                    ModelState.AddModelError("LoginModel.LoginPassword", "Invalid Username or Password");
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public PartialViewResult PostList()
        {
            VMPostUser postView = new VMPostUser();
            postView.UserModelDetails = manager.GetUserDetails(Session["User"].ToString());
            int ID = Convert.ToInt32(Session["ID"]);
            postView.ListOfPost = manager.GetPosts(ID);
            return PartialView("PostList", postView);
        }

        public ActionResult Timeline()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProfileView()
        {
            USER userModel = manager.GetUserDetails(Session["User"].ToString());
            return View(userModel);
        }

        public ActionResult FriendsView()
        {
            return View();
        }
        public ActionResult NotificationsView()
        {
            return View();
        }
    }
}