using MvcMariaDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcMariaDB.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Logout()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("Index", "Genshin");
        }
        public ActionResult CheckLogin(FormCollection collection)
        {
            string user = collection["user"];
            string pass = collection["pass"];
            Users currentUser = Users.GetUser(user, pass);
            if (currentUser != null)
            {
                Session["LoginSuccess"] = true;
                Session["CurrentUser"] = currentUser;
                return RedirectToAction("Index", "Genshin");
            }
            else
            {
                Session["LoginSuccess"] = false;
                return RedirectToAction("Login", "Users");
            }
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult RegisterUser(FormCollection collection)
        {
            Users newUser = new Users
            {
                Username = collection["Username"].ToString(),
                Password = collection["Password"].ToString(),
            };
            int result = Users.SaveUser(newUser);
            if (result == 1)
            {
                newUser = Users.GetUser(newUser.Username, newUser.Password);
                Session["CurrentUser"] = newUser;
                Session["RegisterSuccess"] = true;
                Session["LoginSuccess"] = true;
                return RedirectToAction("Index", "Genshin");
            }
            else
            {
                Session["RegisterSuccess"] = false;
                Session["LoginSuccess"] = false;
                return RedirectToAction("Register", "Users");
            }
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult UserProfile(string id)
        {
            if (Session["CurrentUser"] != null)
            {
                return View(Users.GetUserById(id));
            }
            ViewBag.ErrorMessage = "You need to log in first";
            return View("Error");
        }
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult MyProfile()
        {
            if (Session["CurrentUser"] != null)
            {
                return View(Session["CurrentUser"]);
            }
            ViewBag.ErrorMessage = "You need to log in first";
            return View("Error");
        }
        public ActionResult UpdateProfile(FormCollection collection, int user_id)
        {
            string fav_char = collection["char"].ToString();
            int prof_char = Characters.GetCharacters().Where(p => p.Name == fav_char).First().Id;
            Users updatedUser = new Users
            {
                Id = user_id,
                UId = collection["UId"].ToString(),
                Ign = collection["Ign"].ToString(),
                Adventure_Rank = int.Parse(collection["Adventure_Rank"].ToString()),
                World_Level = int.Parse(collection["World_Level"].ToString()),
                Profile_Character = prof_char
            };

            updatedUser = Users.UpdateUser(updatedUser);
            Session["CurrentUser"] = updatedUser;
            return RedirectToAction("UserProfile", "Users", new { id = updatedUser.Id });
        }
        public ActionResult DeleteUser()
        {
            Users deletedUser = (Users)Session["CurrentUser"];
            bool success = Users.DeleteUser(deletedUser);
            if (success)
            {
                Session["CurrentUser"] = null;
                Session["DeleteSuccess"] = true;
                return RedirectToAction("Index", "Genshin");
            }
            else
            {
                Session["DeleteSuccess"] = false;
                ViewBag.ErrorMessage = "An error has ocurred while deleting the account";
                return View("Error");
            }
        }

        public ActionResult CommentList(int? page)
        {
            if (Session["CurrentUser"] != null)
            {
                List<Comment> comments = Comment.GetCommentList();
                if (comments != null)
                {
                    int pageSize = 5;
                    int pageNumber = (page ?? 1);
                    return View(comments.ToPagedList(pageNumber, pageSize));
                }
            }
            ViewBag.ErrorMessage = "You need to log in first";
            return View("Error");
        }

        public ActionResult SendComment(FormCollection collection)
        {
            string commentString = collection["Content"].ToString();
            if (Session["CurrentUser"] != null)
            {
                if (string.IsNullOrEmpty(commentString))
                {
                    Session["Validation"] = false;
                    return RedirectToAction("CommentList", "Users");
                }
                Users currentUser = (Users)Session["CurrentUser"];
                Comment comment = new Comment
                {
                    DateTime = DateTime.Now,
                    User_Id = currentUser.Id,
                    Content = commentString,
                };
                bool success = Comment.SaveComment(comment);
                if (success)
                {
                    return RedirectToAction("CommentList", "Users");
                }
            }
            ViewBag.ErrorMessage = "Your comment can't be saved";
            return View("Error");
        }
    }
}