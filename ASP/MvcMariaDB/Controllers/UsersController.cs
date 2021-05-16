using MvcMariaDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                Session["CurrentUser"] = newUser;
                return RedirectToAction("Index", "Genshin");
            }
            else
            {
                return View("Error");
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
                return RedirectToAction("UserProfile", "Users", new { id = deletedUser.Id });
            }
        }
    }
}