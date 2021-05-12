using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcMariaDB.Models
{
    public class Users
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Ign { get; set; }
        public int Adventure_Rank { get; set; }
        public int World_Level { get; set; }
        public int Profile_Character { get; set; }
        public string Password { get; set; }
        public string Profile_Picture { get; set; }


        public static Users GetUser(string username, string password)
        {
            try
            {
                DataSet dsUser = new DataSet();
                SqlDataAdapter daUser = new SqlDataAdapter();
                SqlCommand oSql = new SqlCommand();
                oSql.CommandText = "SELECT * FROM Users Where username ='" + username + "' and password = '" + password + "'";

                oSql.Connection = Connection.conn;
                daUser.SelectCommand = oSql;
                daUser.Fill(dsUser);

                DataRow lerro = dsUser.Tables[0].Rows[0];
                Users user = new Users();
                user.Id = lerro["user_id"].ToString();
                user.Username = lerro["username"].ToString();
                user.Ign = lerro["ign"].ToString();
                user.Adventure_Rank = int.Parse(lerro["adventure_rank"].ToString());
                user.World_Level = int.Parse(lerro["world_level"].ToString());
                user.Profile_Character = int.Parse(lerro["profile_character"].ToString());
                user.Profile_Picture = Characters.GetCharacters().Where(p => p.Id == user.Profile_Character).FirstOrDefault().Name;

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool SaveUser(Users user)
        {
            try
            {
                String query = "insert into Users(user_id, username, password, ign, adventure_rank, world_level, profile_character) " +
                    "values ('" + user.Id + "','" + user.Username + "','" + user.Password + "','" + user.Ign + "','" + user.Adventure_Rank + "','" + user.World_Level + "','" + user.Profile_Character + "'); ";
                Connection.Connect();
                SqlCommand command = new SqlCommand(query, Connection.conn);
                command.ExecuteNonQuery();

                return true;
            }
            catch (SqlException exception)
            {
                SqlError err = exception.Errors[0];
                switch (err.Number)
                {
                    case 2627:
                        Console.WriteLine("Primary Key");
                        break;
                }
                return false;
            }
        }

        public static bool UpdateUser(Users user, string newId)
        {
            try
            {
                String query = "delete from users where user_id='" + user.Id + "'";
                Connection.Connect();
                SqlCommand command = new SqlCommand(query, Connection.conn);
                command.ExecuteNonQuery();

                user.Id = newId;
                query = "insert into Users(user_id, username, password, ign, adventure_rank, world_level, profile_character) " +
                    "values ('" + user.Id + "','" + user.Username + "','" + user.Password + "','" + user.Ign + "','" + user.Adventure_Rank + "','" + user.World_Level + "','" + user.Profile_Character + "'); ";
                Connection.Connect();
                SqlCommand command2 = new SqlCommand(query, Connection.conn);
                command2.ExecuteNonQuery();
                return true;
            }
            catch (SqlException exception)
            {
                SqlError err = exception.Errors[0];
                switch (err.Number)
                {
                    case 2627:
                        Console.WriteLine("Primary Key");
                        break;
                }
                return false;
            }
        }

        public static bool DeleteUser(Users user)
        {
            try
            {
                String query = "delete from users where user_id='" + user.Id + "'";
                Connection.Connect();
                SqlCommand command = new SqlCommand(query, Connection.conn);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
