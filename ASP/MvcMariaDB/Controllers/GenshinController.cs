using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMariaDB.Controllers
{
    public class GenshinController : Controller
    {
        // GET: Genshin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Characters()
        {
            return View();
        }

        public ActionResult CharacterList() 
        {
            return View(Models.Characters.GetCharacters());
        }
    }
}