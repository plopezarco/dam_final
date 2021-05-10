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

        public ActionResult CharacterList(string searchString, FormCollection collection)
        {
            var characters = Models.Characters.GetCharacters();
            if (!String.IsNullOrEmpty(searchString))
            {
                characters = characters.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            string weapon = collection["weapon"];
            string element = collection["element"];
            string rarity = collection["rarity"];


            if (!String.IsNullOrEmpty(weapon) && weapon != "All")
            {
                characters = characters.Where(p => p.Weapon.ToUpper().Equals(weapon.ToUpper())).ToList();
                ViewBag.Filter_Weapon = weapon;
            }
            else
            {
                ViewBag.Filter_Weapon = "All";
            }

            if (!String.IsNullOrEmpty(element) && element != "All")
            {
                characters = characters.Where(p => p.Element.ToUpper().Equals(element.ToUpper())).ToList();
                ViewBag.Filter_Element = element;
            }
            else
            {
                ViewBag.Filter_Element = "All";
            }

            if (!String.IsNullOrEmpty(rarity) && rarity != "All")
            {
                characters = characters.Where(p => p.Rarity.ToString().Equals(rarity.ToString())).ToList();
                ViewBag.Filter_Rarity = rarity.ToString();
            }
            else
            {
                ViewBag.Filter_Rarity = "All";
            }

            return View(characters);
        }

        public ActionResult Character(int char_id)
        {
            return View(Models.Characters.Characters_List.Where(p => p.Id == char_id).FirstOrDefault());
        }

        public ActionResult WeaponList(string weapon)
        {
            var weapons = Models.Weapon.GetWeapons();
            if (!String.IsNullOrEmpty(weapon))
            {
                if (weapon != "ALL")
                {
                    weapons = weapons.Where(p => p.Weapon_Type.ToUpper() == weapon).ToList();

                }
                ViewBag.Weapon = weapon.ToString().ToUpper();
            }
            else
            {
                ViewBag.Weapon = "ALL";
            }

            return View(weapons);
        }

        public ActionResult Weapon(int weapon_id)
        {
            return View(Models.Weapon.Weapons_List.Where(p => p.Id == weapon_id).FirstOrDefault());
        }

        public ActionResult Faq()
        {
            return View();
        }
    }
}