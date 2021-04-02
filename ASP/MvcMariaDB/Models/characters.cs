using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcMariaDB.Models
{
    public class Characters
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Weapon { get; set; }
        public string Element { get; set; }
        public int Rarity { get; set; }
        public string Birthday { get; set; }
        public string Seiyuu { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public string Image_Small { get; set; }
        public string Image { get; set; }

        public static List<Characters> GetCharacters()
        {
            List<Characters> characterList = new List<Characters>();
            DataSet dsCharacter = new DataSet();
            SqlDataAdapter daCharacter = new SqlDataAdapter();
            SqlCommand oSql = new SqlCommand();
            oSql.CommandText = "SELECT [character_id],[character_name],[weapon],[element],[rarity],[birthday],[seiyuu],[region],[character_description],[image_small] FROM Characters";

            oSql.Connection = konexioa.conn;
            daCharacter.SelectCommand = oSql;
            daCharacter.Fill(dsCharacter);


            foreach (DataRow lerro in dsCharacter.Tables[0].Rows)
            {
                Characters charac = new Characters();
                charac.Id = lerro["character_id"].ToString();
                charac.Name = lerro["character_name"].ToString();
                charac.Weapon = lerro["weapon"].ToString();
                charac.Element = lerro["element"].ToString();
                charac.Rarity = int.Parse(lerro["rarity"].ToString());
                charac.Birthday = lerro["birthday"].ToString();
                charac.Seiyuu = lerro["seiyuu"].ToString();
                charac.Region = lerro["region"].ToString();
                charac.Description = lerro["character_description"].ToString();
                charac.Image_Small = lerro["image_small"].ToString();
                characterList.Add(charac);
            }
            return characterList;
        }
    }
    class konexioa
    {
        public static string connString = ConfigurationManager.ConnectionStrings["GenshinConnectionString"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(connString);
        public static string Connect()
        {
            string connection_error = "";
            try { conn.Open(); }
            catch (Exception ex)
            { connection_error = ex.Message; }
            return connection_error;
        }
        public static string Disconnect()
        {
            string connection_error = "";
            try { conn.Close(); }
            catch (Exception ex)
            { connection_error = ex.Message; }
            return connection_error;
        }

    }
}