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
        public ActionResult Index([Bind(Include = "user")]LoginViewModel model)
        {
            string email = model.user.EMAIL_ADDRESS;
            if (userManager.CheckIfEmailExists(email))
            {
                model.CountryList = countryManager.GetCountry();
                ModelState.AddModelError("user.EMAIL_ADDRESS", "Email Address already exists.");
                return View(model);
            }

            if (userManager.CheckIfUsernameExists(model.user.USER_NAME))
            {
                model.CountryList = countryManager.GetCountry();
                ModelState.AddModelError("user.USER_NAME", "Username already exists.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                Session["User"] = model.user.EMAIL_ADDRESS;
                Session["ID"] = userManager.GetAccountIDUsingEmail(Session["User"].ToString());
                Session["FirstName"] = model.user.FIRST_NAME;
                Session["LastName"] = model.user.LAST_NAME;
                Session["ProfilePic"] = model.user.PROFILE_PIC;
                userManager.AddUserAccount(model.user);
                return RedirectToAction("Home", "PasteBook");
            }
         
            return View("Index", model);
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
            string email = model.LoginModel.LoginEmail;
            string password = model.LoginModel.LoginPassword;
            

            if (userManager.CheckIfEmailExists(email))
            {
                int ID = userManager.GetAccountIDUsingEmail(email);
                model.user= userManager.GetUserDetailsUsingID(ID);

                if (userManager.IsPasswordMatch(password,model.user.SALT,model.user.PASSWORD))
                {
                    Session["User"] = model.LoginModel.LoginEmail;
                    Session["ID"] = userManager.GetAccountIDUsingEmail(Session["User"].ToString());

                    USER userModel = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
                    Session["FirstName"] = userModel.FIRST_NAME;
                    Session["LastName"] = userModel.LAST_NAME;
                    Session["ProfilePic"] = userModel.PROFILE_PIC;
                    return RedirectToAction("Home", "PasteBook");
                }
            }
            else
            {
                ViewBag.Error = "Invalid Username or Password";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["ID"] = null;
            Session["Name"] = null;
            Session["LastName"] = null;
            Session["ProfilePic"] = null;
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
            return Json(new { result = result });
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

        public PartialViewResult CommentList(int postID)
        {
            List<COMMENT> CommentList = new List<COMMENT>();
            CommentList = commentManager.ListOfComments(postID);
            return PartialView(CommentList);
        }

        [HttpGet]
        public ActionResult Profile(string username)
        {
            int session = (Int32)Session["ID"];
            Session["accountID"] = userManager.GetAccountIDUsingUsername(username);
            

            if ((Int32)Session["accountID"] == session)
            {
               
                ViewData["FriendshipStatus"] = friendManager.FriendRequest((Int32)Session["accountID"], session);
                USER model = userManager.GetUserDetailsUsingID((Int32)Session["accountID"]);
                Session["ProfilePic"] = model.PROFILE_PIC;
                return View(model);
            }
            else
            {
                ViewData["FriendshipStatus"] = friendManager.FriendRequest((Int32)Session["accountID"], session);
                USER model = userManager.GetUserDetailsUsingID((Int32)Session["accountID"]);
                Session["ProfilePic"] = model.PROFILE_PIC;
                return View(model);
            }
        }

        public ActionResult PostList(string username)
        {
            int ID = (Int32)Session["ID"];
           Session["accountID"] = userManager.GetAccountIDUsingUsername(username);

            if (string.IsNullOrEmpty(username))
            {
                List<FRIEND> friends = friendManager.UserFriends(ID);
                return PartialView("PostListView", postManager.NewsFeedPosts(friends, ID, ID));
            }
          
            else
            {
                List<FRIEND> friends = friendManager.UserFriends((Int32)Session["accountID"]);
                return PartialView("PostListView", postManager.NewsFeedPosts(friends, (Int32)Session["accountID"], (Int32)Session["accountID"]));
            }
        }

        public ActionResult TimeLinePostList(string username)
        {
            return View();
        }
        
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            //forums.asp.net/t/2006227.aspx?Adding+validation+on+upload+a+image+in+MVC+4+0
            if (ModelState.IsValid)
            {
                USER model = userManager.GetUserDetailsUsingID((Int32)Session["ID"]);
                userManager.UploadImage(model, file);
                return RedirectToAction("Profile","PasteBook",model.USER_NAME);
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
            model = userManager.GetUserDetailsUsingID(ID);
            return View(model);
        }

        public ActionResult Security(SecurityModel securityModel)
        {
            int ID = (int)Session["ID"];
            USER model = userManager.GetUserDetailsUsingID(ID);

            bool passwordMatch = userManager.IsPasswordMatch(securityModel.NewPassword, model.SALT, model.PASSWORD);
            if (passwordMatch && securityModel.EmailAddress != null && securityModel.NewPassword != null)
            {
                //string salt = null;
                //string hash =

            }

            else if (passwordMatch && securityModel.EmailAddress != null && securityModel.NewPassword == null)
            {
                //userManager.UpdateUserEmail(email,ID)
            }

            else if (passwordMatch && securityModel.EmailAddress == null && securityModel.NewPassword != null)
            {
                //userManager.UpdateUserPassword(password,ID)
            }
            else
            {
                //userManager.UpdateUserEmailAndPassword(email,password,ID)
            }

            return View(model);

        }

        public ActionResult Friend(string username)
        {
            int UserID = (int)Session["ID"];
            int ID = (Int32)Session["ID"];
            var accountID = userManager.GetAccountIDUsingUsername(username);
            ViewData["FriendshipStatus"] = friendManager.FriendRequest((Int32)Session["ID"], accountID);

            List<USER> friendDetails = new List<USER>();
            friendDetails = friendManager.UserFriendsInformation(UserID);
            return View(friendDetails);
        }
        public ActionResult NotificationsView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchView(string keyword)
        {
            List<USER> listOfSearchedUser = new List<USER>();
            listOfSearchedUser = userManager.SearchUser(keyword);
            return View(listOfSearchedUser);
        }

        public JsonResult AddFriend(int visitedProfileID)
        {
            int UserID = (int)Session["ID"];
            FRIEND model = new FRIEND();
            model.BLOCKED = "N";
            model.CREATED_DATE = DateTime.Now;
            model.FRIEND_ID = visitedProfileID;
            model.USER_ID = UserID;
            model.REQUEST = "Y";
            
            int result = friendManager.AddFriend(model);
            return Json(new { result = result });
        }

        public JsonResult ConfirmRequest(int visitedProfileID)
        {
            int UserID = (int)Session["ID"];
            //FRIEND model = new FRIEND();
            //model.BLOCKED = "N";
            //model.CREATED_DATE = DateTime.Now;
            //model.FRIEND_ID = visitedProfileID;
            //model.USER_ID = UserID;
            //model.REQUEST = "Y";
            int result = friendManager.ConfirmFriend(UserID, visitedProfileID);
            return Json(new { result = result });
        }
        
    }
}