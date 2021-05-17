using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcMariaDB.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        [StringLength(9, ErrorMessage = "UID must be 9 numbers long", MinimumLength = 9)]
        public string UId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Ign { get; set; }
        public int Adventure_Rank { get; set; }
        public int World_Level { get; set; }
        public int Profile_Character { get; set; }
        public List<Comment> Comments { get; set; }

        public string Profile_Picture { get; set; }


        public static Users GetUser(string username, string password)
        {
            try
            {
                DataSet dsUser = new DataSet();
                SqlDataAdapter daUser = new SqlDataAdapter();
                SqlCommand oSql = new SqlCommand();
                oSql.CommandText = $"SELECT username, user_id, uid, ign, profile_character, adventure_rank, world_level FROM Users Where username ='{username}' and password = '{password}'";

                oSql.Connection = Connection.conn;
                daUser.SelectCommand = oSql;
                daUser.Fill(dsUser);

                DataRow lerro = dsUser.Tables[0].Rows[0];
                Users user = new Users
                {
                    Id = int.Parse(lerro["user_id"].ToString()),
                    Username = (lerro["username"] as string),
                    UId = (lerro["uid"] as string),
                    Ign = (lerro["ign"] as string),
                    Adventure_Rank = string.IsNullOrEmpty(lerro["adventure_rank"].ToString()) ? 0 : int.Parse(lerro["adventure_rank"].ToString()),
                    World_Level = string.IsNullOrEmpty(lerro["world_level"].ToString()) ? 0 : int.Parse(lerro["world_level"].ToString()),
                    Profile_Character = string.IsNullOrEmpty(lerro["profile_character"].ToString()) ? 0 : int.Parse(lerro["profile_character"].ToString())
                };
                if (user.Profile_Character != 0)
                {
                    user.Profile_Picture = Characters.GetCharactersName().Where(p => p.Id == user.Profile_Character).FirstOrDefault().Name;
                }
                user.Comments = Comment.GetCommentListById(user);

                return user;
            }
            catch
            {
                return null;
            }
        }

        public static Users GetUserById(string id)
        {
            try
            {
                DataSet dsUser = new DataSet();
                SqlDataAdapter daUser = new SqlDataAdapter();
                SqlCommand oSql = new SqlCommand();
                oSql.CommandText = $"SELECT username, user_id, uid, ign, profile_character, adventure_rank, world_level FROM Users Where user_id ='{id}'";

                oSql.Connection = Connection.conn;
                daUser.SelectCommand = oSql;
                daUser.Fill(dsUser);

                DataRow lerro = dsUser.Tables[0].Rows[0];
                Users user = new Users
                {
                    Id = int.Parse(lerro["user_id"].ToString()),
                    Username = (lerro["username"] as string),
                    UId = (lerro["uid"] as string),
                    Ign = (lerro["ign"] as string),
                    Adventure_Rank = string.IsNullOrEmpty(lerro["adventure_rank"].ToString()) ? 0 : int.Parse(lerro["adventure_rank"].ToString()),
                    World_Level = string.IsNullOrEmpty(lerro["world_level"].ToString()) ? 0 : int.Parse(lerro["world_level"].ToString()),
                    Profile_Character = string.IsNullOrEmpty(lerro["profile_character"].ToString()) ? 0 : int.Parse(lerro["profile_character"].ToString())
                };
                if (user.Profile_Character != 0)
                {
                    user.Profile_Picture = Characters.GetCharactersName().Where(p => p.Id == user.Profile_Character).FirstOrDefault().Name;
                }
                user.Comments = Comment.GetCommentListById(user);

                return user;
            }
            catch
            {
                return null;
            }
        }

        public static int SaveUser(Users user)
        {
            try
            {
                String query = $"insert into Users(username, password) values ('{user.Username}','{user.Password}')";
                Connection.Connect();
                SqlCommand command = new SqlCommand(query, Connection.conn);
                command.ExecuteNonQuery();

                return 1;
            }
            catch (SqlException exception)
            {
                SqlError err = exception.Errors[0];
                switch (err.Number)
                {
                    case 2627:
                        return -1;
                }
                return 0;
            }
        }

        public static Users UpdateUser(Users user)
        {
            try
            {
                string query = $"update users set uid = '{user.UId}', ign = '{user.Ign}', adventure_rank = '{user.Adventure_Rank}', world_level='{user.World_Level}',profile_character = '{user.Profile_Character}' where user_id = '{user.Id}';";
                Connection.Connect();
                SqlCommand command2 = new SqlCommand(query, Connection.conn);
                command2.ExecuteNonQuery();

                Users updatedUser = GetUserById(user.Id.ToString());
                return updatedUser;
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteUser(Users user)
        {
            try
            {
                String query = $"delete from users where user_id='{user.Id}'";
                Connection.Connect();
                SqlCommand command = new SqlCommand(query, Connection.conn);
                command.ExecuteNonQuery();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
