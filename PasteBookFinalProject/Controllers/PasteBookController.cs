
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
        public ActionResult HomeView()
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
            if (manager.CheckEmailAddress(model.UserLoginModel.EmailAddress))
            {
                ModelState.AddModelError("EmailAddress", "Email Address already exists.");
            }

            if (manager.CheckUsername(model.UserLoginModel.Username))
            {
                ModelState.AddModelError("Username", "Username already exists.");
            }

            if (ModelState.IsValid)
            {
                manager.AddUser(model.UserLoginModel);
            }
            return View("HomeView");

        }

        [HttpGet]
        public ActionResult AccountView()
        {
            return View((UserModel)Session["modelSession"]);
        }

        
        public JsonResult AddPost(string postContent)
        {
            UserModel model = manager.GetUserDetails(Session["User"].ToString());
            PostModel postModel = new PostModel();

            postModel.PostPosterID = model.ID;
            postModel.PostProfileOwnerID = model.ID;
            postModel.PostContent = postContent;
            postModel.PostCreatedDate = DateTime.Now;
            
            int result =  manager.AddPost(postModel);
            return Json(new { result = result } ); 
        }

        [HttpPost]
        public ActionResult AccountView([Bind(Include = "LoginModel")] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (manager.CheckUserCredentials(model))
                {
                    Session["User"] = model.LoginModel.LoginEmail;
                    Session["ID"] = manager.GetUserID(Session["User"].ToString());

                    UserModel userModel = manager.GetUserDetails(Session["User"].ToString());
                    Session["Username"] = userModel.Username;
                    Session["Firstname"] = userModel.FirstName;
                    Session["Lastname"] = userModel.LastName;

                    return RedirectToAction("AccountView", "PasteBook");
                   
                }
                else
                {
                    ModelState.AddModelError("LoginModel.LoginPassword", "Invalid Username or Password");
                    return View("HomeView");
                }
            }
            else
            {
                return View("HomeView");
            }
           
        }


        public PartialViewResult PostList()
        {
            int ID = Convert.ToInt32(Session["ID"]);
            List<PostModel> post = new List<PostModel>();
            post = manager.GetPosts(ID);
            return PartialView("PostList", post);
        }

        public ActionResult TimelineView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProfileView()
        {
            UserModel userModel = manager.GetUserDetails(Session["User"].ToString());
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