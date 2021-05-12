using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcMariaDB.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Base_Atk { get; set; }
        public string Sub_Stat_Name { get; set; }
        public string Sub_Stat_Value { get; set; }
        public string Weapon_Effect { get; set; }
        public string Image { get; set; }
        public int Rarity { get; set; }
        public string Weapon_Type { get; set; }
        public List<Characters> Wielders_List { get; set; }

        public static List<Weapon> Weapons_List { get; set; }

        public static List<Weapon> GetWeapons()
        {
            List<Characters> characters = Characters.GetCharacters();

            List<Weapon> weaponList = new List<Weapon>();
            DataSet dsWeapon = new DataSet();
            SqlDataAdapter daWeapon = new SqlDataAdapter();
            SqlCommand oSql = new SqlCommand();
            oSql.CommandText = "SELECT * FROM Weapons ORDER BY Rarity DESC";

            oSql.Connection = Connection.conn;
            daWeapon.SelectCommand = oSql;
            daWeapon.Fill(dsWeapon);

            foreach (DataRow lerro in dsWeapon.Tables[0].Rows)
            {
                Weapon weapon = new Weapon();
                weapon.Id = int.Parse(lerro["weapon_id"].ToString());
                weapon.Name = lerro["weapon_name"].ToString();
                weapon.Base_Atk = int.Parse(lerro["base_atk"].ToString());
                weapon.Sub_Stat_Name = lerro["sub_stat_name"].ToString();
                weapon.Sub_Stat_Value = lerro["sub_stat_value"].ToString();
                weapon.Weapon_Effect = lerro["weapon_effect"].ToString();
                weapon.Name = lerro["weapon_name"].ToString();
                weapon.Image = lerro["weapon_image"].ToString();
                weapon.Rarity = int.Parse(lerro["rarity"].ToString());
                weapon.Weapon_Type = lerro["weapon_type"].ToString();
                weapon.Wielders_List = characters.Where(p => p.Weapon == weapon.Weapon_Type).ToList();
                weaponList.Add(weapon);
            }
            Weapons_List = weaponList;
            return weaponList;
        }
    }
}