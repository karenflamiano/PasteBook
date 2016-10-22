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

namespace PasteBookFinalProject.Controllers
{
    public class PasteBookController : Controller
    {

        BLCountryManager countryManager = new BLCountryManager();
        BLUserManager userManager = new BLUserManager();
        BLPostManager postManager = new BLPostManager();
        BLCommentManager commentManager = new BLCommentManager();

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
        public ActionResult Index(LoginViewModel model)
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
                userManager.AddUserAccount(model.user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Home()
        {
            USER model = new USER();
            model = userManager.GetAccountDetailsUsingEmail(Session["User"].ToString());
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

                    USER userModel = userManager.GetAccountDetailsUsingEmail(Session["User"].ToString());
                    return RedirectToAction("Home", "PasteBook");
                }
                else
                {
                    ModelState.AddModelError("PasswordOrUsernameError", "Invalid Username or Password");
                    //return View();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Home");
                //return View();
            }
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }

        public JsonResult AddPost(string postContent)
        {
            USER model = userManager.GetAccountDetailsUsingEmail(Session["User"].ToString());
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
            USER model = userManager.GetAccountDetailsUsingEmail(Session["User"].ToString());
            COMMENT commentModel = new COMMENT();
            commentModel.CONTENT = commentContent;
            commentModel.POST_ID = postID;
            commentModel.POSTER_ID = model.ID;
            commentModel.DATE_CREATED = DateTime.Now;

            int result = commentManager.AddComment(commentModel);
            return Json(new { result = result });
        }



        public PartialViewResult PostList()
        {
            Mapper mapper = new Mapper();
            int ID = (int)Session["ID"];
            List<POST> PostList = new List<POST>();
            PostList = postManager.NewsFeedPosts(ID);
            return PartialView("PostList", mapper.PostMapToModel(PostList, null, null, null));

        }

      

        [HttpGet]
        public ActionResult Profile(HttpPostedFileBase file)
        {
            //Adding image 
            //stackoverflow.com/questions/17952514/mvc-how-to-display-a-byte-array-image-from-model
            //stackoverflow.com/questions/16255882/uploading-displaying-images-in-mvc-4

            //AddImage
            USER userModel = userManager.GetAccountDetailsUsingEmail(Session["User"].ToString());

            if (file != null)
            {
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    userModel.PROFILE_PIC = ms.GetBuffer();
                    
                }
            }

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