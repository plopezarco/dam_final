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

        public ActionResult Character(int char_id)
        {
            return View(Models.Characters.Characters_List.Where(p => p.Id == char_id).FirstOrDefault());
        }

        public ActionResult WeaponList()
        {
            return View(Models.Weapon.GetWeapons());
        }

        public ActionResult Weapon(int weapon_id)
        {
            return View(Models.Weapon.Weapons_List.Where(p => p.Id == weapon_id).FirstOrDefault());
        }

        public ActionResult FilterWeapon(string weapon_type)
        {
            return View(Models.Weapon.Weapons_List.Where(p => p.Weapon_Type == weapon_type).ToList());
        }
    }
}