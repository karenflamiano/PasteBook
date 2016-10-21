//using PasteBookFinalProject.Managers;
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
            //Adding image 
            //stackoverflow.com/questions/17952514/mvc-how-to-display-a-byte-array-image-from-model

            //AddImage
            if (userManager.CheckIfEmailAddressExists(model.user))
            {
                ModelState.AddModelError("EMAIL_ADDRESS", "Email Address already exists.");
            }

            if (userManager.CheckIfUsernameExists(model.user.USER_NAME))
            {
                ModelState.AddModelError("USER_NAME", "Username already exists.");
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
                    ModelState.AddModelError("LoginModel.LoginPassword", "Invalid Username or Password");
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Home");
            }
        }

        public JsonResult AddPost(string postContent)
        {
            USER model = userManager.GetAccountDetailsUsingEmail(Session["User"].ToString());
            POST postModel = new POST();

            postModel.POSTER_ID = model.ID;
            postModel.PROFILE_OWNER_ID = model.ID;
            postModel.CONTENT = postContent;
            postModel.CREATED_DATE = DateTime.Now;
            
            int result =  postManager.AddPost(postModel);
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



        public PartialViewResult PostList(int ID)
        {
            //VMPostWithLikeAndComment postView = new VMPostWithLikeAndComment();
            //USER user = new USER();
            VMPostUser vm = new VMPostUser();
            //vm.CommentList = 
            //user = userManager.GetAccountDetailsUsingEmail(Session["User"].ToString());
            //postView.postList
            //int ID = Convert.ToInt32(Session["ID"]);
            List<POST> postList = postManager.NewsFeedPosts(ID);
            
            List<COMMENT> commentList = new List<COMMENT>();
            List<LIKE> likeList = new List<LIKE>();


            foreach (var item in postList)
            {
               
                commentList = commentManager.ListOfComments(item.ID);      
            }

            return PartialView("PostList", postList);
        }

      

        public ActionResult Timeline()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProfileView()
        {
            USER userModel = userManager.GetAccountDetailsUsingEmail(Session["User"].ToString());
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