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
        // GET: Users
        public ActionResult UsersList()
        {
            Users user = new Users();
            user.Id = "523325";
            user.Username = "Pablo2";
            user.Ign = "Pablo2";
            user.World_Level = 4;
            user.Password = null;
            user.Profile_Character = 6;
            Users.UpdateUser(user);
            return View(Models.Users.GetUser("Pablo", "1234"));
        }

        public ActionResult CheckLogin(FormCollection collection)
        {
            string user = collection["user"];
            string pass = collection["pass"];
            Users currentUser = Users.GetUser(user, pass);
            if (currentUser != null)
            {
                return RedirectToAction("Index", "Genshin");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult Profile()
        {
            return View();
        }
    }
}