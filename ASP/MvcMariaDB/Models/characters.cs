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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weapon { get; set; }
        public string Element { get; set; }
        public int Rarity { get; set; }
        public string Title { get; set; }
        public string Organization { get; set; }
        public string Constellation { get; set; }
        public string Primary_Attribute { get; set; }
        public string Gender { get; set; }
        public string Bodytype { get; set; }
        public string Birthday { get; set; }
        public string Seiyuu { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public string Image_Small { get; set; }
        public string Image { get; set; }
        public static List<Characters> Characters_List { get; set; }

        public static List<Characters> GetCharacters()
        {
            List<Characters> characterList = new List<Characters>();
            DataSet dsCharacter = new DataSet();
            SqlDataAdapter daCharacter = new SqlDataAdapter();
            SqlCommand oSql = new SqlCommand();
            oSql.CommandText = "SELECT * FROM Characters ORDER BY Character_Name";

            oSql.Connection = Connection.conn;
            daCharacter.SelectCommand = oSql;
            daCharacter.Fill(dsCharacter);


            foreach (DataRow lerro in dsCharacter.Tables[0].Rows)
            {
                Characters charac = new Characters();
                charac.Id = int.Parse(lerro["character_id"].ToString());
                charac.Name = lerro["character_name"].ToString();
                charac.Weapon = lerro["weapon"].ToString();
                charac.Element = lerro["element"].ToString();
                charac.Rarity = int.Parse(lerro["rarity"].ToString());
                charac.Title = lerro["title"].ToString();
                charac.Organization = lerro["organization"].ToString();
                charac.Constellation = lerro["constellation"].ToString();
                charac.Primary_Attribute = lerro["primary_attribute"].ToString();
                charac.Gender = lerro["gender"].ToString();
                charac.Bodytype = lerro["bodytype"].ToString();
                charac.Birthday = lerro["birthday"].ToString();
                charac.Seiyuu = lerro["seiyuu"].ToString();
                charac.Region = lerro["region"].ToString();
                charac.Description = lerro["character_description"].ToString();
                charac.Image_Small = lerro["image_small"].ToString();
                charac.Image = lerro["image_big"].ToString();
                characterList.Add(charac);
            }
            Characters_List = characterList;
            return characterList;
        }

        public static List<Characters> GetCharactersName()
        {
            List<Characters> characterList = new List<Characters>();
            DataSet dsCharacter = new DataSet();
            SqlDataAdapter daCharacter = new SqlDataAdapter();
            SqlCommand oSql = new SqlCommand();
            oSql.CommandText = "SELECT character_id, character_name FROM Characters ORDER BY Character_Name";

            oSql.Connection = Connection.conn;
            daCharacter.SelectCommand = oSql;
            daCharacter.Fill(dsCharacter);


            foreach (DataRow lerro in dsCharacter.Tables[0].Rows)
            {
                Characters charac = new Characters
                {
                    Id = int.Parse(lerro["character_id"].ToString()),
                    Name = lerro["character_name"].ToString()
                };
                characterList.Add(charac);
            }
            return characterList;
        }
    }
}