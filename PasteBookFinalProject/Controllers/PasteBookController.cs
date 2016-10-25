//using PasteBookFinalProject.Managers;
using PasteBookFinalProject.Models;
using PasteBookBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PasteBookEntityFramework;
using System.IO;
using System.Drawing;

namespace PasteBookFinalProject.Controllers
{
    public class PasteBookController : Controller
    {

        BLCountryManager countryManager = new BLCountryManager();
        BLUserManager userManager = new BLUserManager();
        BLPostManager postManager = new BLPostManager();
        BLCommentManager commentManager = new BLCommentManager();
        BLFriendManager friendManager = new BLFriendManager();
        BLLikeManager likeManager = new BLLikeManager();

        static LoginViewModel mainModel = new LoginViewModel();
        
        [HttpGet]
        public ActionResult Index()
        {
            LoginViewModel model = new LoginViewModel();
            List<REF_COUNTRY> listOfCountries = countryManager.GetCountry();

            model.CountryList = listOfCountries;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "USER")]LoginViewModel model)
        {
           
            if (userManager.CheckIfEmailAddressExists(model.user))
            {
                ModelState.AddModelError("emailAddressError", "Email Address already exists.");
                return View();
            }

            if (userManager.CheckIfUsernameExists(model.user.USER_NAME))
            {
                ModelState.AddModelError("userNameError", "Username already exists.");
                return View();
            }

            if (ModelState.IsValid)
            {
                Session["User"] = model.user.EMAIL_ADDRESS;
                Session["ID"] = userManager.GetAccountIDUsingEmail(Session["User"].ToString());
                USER userModel = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
                userManager.AddUserAccount(model.user);
                return RedirectToAction("Home", "PasteBook");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Home()
        {
            USER model = new USER();
            Session["ID"] = userManager.GetAccountIDUsingEmail(Session["User"].ToString());
            model = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
            return View(model);
        }

        [HttpPost]
        public ActionResult Home([Bind(Include = "LoginModel")] LoginViewModel model)
        {
            USER entityUser = new USER();
            entityUser.EMAIL_ADDRESS = model.LoginModel.LoginEmail;
            entityUser.PASSWORD = model.LoginModel.LoginPassword;

            if (ModelState.IsValid)
            {
                if (userManager.CheckIfEmailAddressExists(entityUser))
                {
                    Session["User"] = model.LoginModel.LoginEmail;
                    Session["ID"] = userManager.GetAccountIDUsingEmail(Session["User"].ToString());

                    USER userModel = userManager.GetUserDetailsUsingID((Int32)Session["ID"]); ;
                    return RedirectToAction("Home", "PasteBook");
                }
                else
                {
                    ModelState.AddModelError("PasswordOrUsernameError", "Invalid Username or Password");
                    return View("Home");
                }
            }
            else
            {
                return RedirectToAction("Home");
            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["ID"] = null;
            return RedirectToAction("Index");
        }

        public JsonResult AddPost(string postContent)
        {
            USER model = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
            POST postModel = new POST();
            postModel.POSTER_ID = model.ID;
            postModel.PROFILE_OWNER_ID = model.ID;
            postModel.CONTENT = postContent;
            postModel.CREATED_DATE = DateTime.Now;
            int result = postManager.AddPost(postModel);
            return Json(new { result = result } ); 
        }

        public JsonResult AddComment(string commentContent, int postID)
        {
            USER model = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
            COMMENT commentModel = new COMMENT();
            commentModel.CONTENT = commentContent;
            commentModel.POST_ID = postID;
            commentModel.POSTER_ID = model.ID;
            commentModel.DATE_CREATED = DateTime.Now;

            int result = commentManager.AddComment(commentModel);
            return Json(new { result = result });
        }

        public JsonResult AddLike(int postID)
        {
            USER model = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
            LIKE likeModel = new LIKE();
            likeModel.POST_ID = postID;
            likeModel.LIKED_BY = model.ID;
            int result = likeManager.AddLike(likeModel);
            return Json(new { result = result });
        }

        [HttpGet]
        public ActionResult Profile()
        {
            USER model = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
            return View(model);
        }

        public ActionResult PostList()
        {
            int ID = (int)Session["ID"];
            List<FRIEND> friends = friendManager.UserFriends(ID);
            return PartialView("PostListView",postManager.NewsFeedPosts(friends,ID,ID));
        }
        

        public PartialViewResult CommentList(int postID)
        {
            List<COMMENT> CommentList = new List<COMMENT>();
            CommentList = commentManager.ListOfComments(postID);
            return PartialView(CommentList);
        }


        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            //forums.asp.net/t/2006227.aspx?Adding+validation+on+upload+a+image+in+MVC+4+0
            if (ModelState.IsValid)
            {
                USER model = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
                userManager.UploadImage(model, file);
                return RedirectToAction("Profile");
            }
            return View();
        }

        public ActionResult EditAboutMe(string aboutMe)
        {
            if (ModelState.IsValid)
            {
                USER model = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
                userManager.EditAboutMe(model, aboutMe);
                return RedirectToAction("Profile");
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Settings(USER model)
        {
            int ID = (int)Session["ID"];

            if (ModelState.IsValid)
            {
                model = userManager.GetUserDetailsUsingID(ID);
            }
            return View(model);
        }

        public ActionResult Security(SecurityModel securityModel)
        {
            int ID = (int)Session["ID"];
            USER model = userManager.GetUserDetailsUsingID(ID);

            bool passwordMatch = userManager.IsPasswordMatch(securityModel.NewPassword, model.SALT, model.PASSWORD);
            if (passwordMatch && securityModel.EmailAddress == null && securityModel.NewPassword == null)
            {

            }

            else if (passwordMatch && securityModel.EmailAddress != null && securityModel.NewPassword == null)
            {

            }

            else if (passwordMatch && securityModel.EmailAddress == null && securityModel.NewPassword != null)
            {

            }
            else
            {

            }

            return View(model);

        }
        
        public ActionResult Friend()
        {
            int UserID = (int)Session["ID"];
            List<USER> friendDetails = new List<USER>();
            friendDetails = friendManager.UserFriendsInformation(UserID);
            return View(friendDetails);
        }
        public ActionResult NotificationsView()
        {
            return View();
        }
    }
}