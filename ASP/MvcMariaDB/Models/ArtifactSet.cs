using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcMariaDB.Models
{
    public class ArtifactSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxRarity { get; set; }
        public string TwoPieceBonus { get; set; }
        public string FourPieceBonus { get; set; }
        public string Image { get; set; }

        public static List<ArtifactSet> ArtifactSet_List { get; set; }

        public static List<ArtifactSet> GetArtifactSets()
        {
            List<ArtifactSet> setList = new List<ArtifactSet>();
            DataSet dsSet = new DataSet();
            SqlDataAdapter daSets = new SqlDataAdapter();
            SqlCommand oSql = new SqlCommand();
            oSql.CommandText = "SELECT * FROM Artifact_Sets ORDER BY set_name";

            oSql.Connection = konexioa.conn;
            daSets.SelectCommand = oSql;
            daSets.Fill(dsSet);


            foreach (DataRow lerro in dsSet.Tables[0].Rows)
            {
                ArtifactSet set = new ArtifactSet();
                set.Id = int.Parse(lerro["id"].ToString());
                set.Name = lerro["set_name"].ToString();
                set.MaxRarity = int.Parse(lerro["max_rarity"].ToString());
                set.TwoPieceBonus = lerro["two_piece_bonus"].ToString();
                set.FourPieceBonus = lerro["four_piece_bonus"].ToString();
                set.Image = lerro["image"].ToString();
                setList.Add(set);
            }
            ArtifactSet_List = setList;
            return setList;
        }
    }
}