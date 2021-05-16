using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcMariaDB.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int User_Id { get; set; }
        public Users User { get; set; }
        public string Content { get; set; }

        public static List<Comment> Comment_List { get; set; }

        public static List<Comment> GetCommentList()
        {
            try
            {
                List<Comment> commentList = new List<Comment>();
                DataSet dsComment = new DataSet();
                SqlDataAdapter daComment = new SqlDataAdapter();
                SqlCommand oSql = new SqlCommand();
                oSql.CommandText = "SELECT * FROM Comments order by datetime desc";

                oSql.Connection = Connection.conn;
                daComment.SelectCommand = oSql;
                daComment.Fill(dsComment);


                foreach (DataRow lerro in dsComment.Tables[0].Rows)
                {
                    Comment comment = new Comment
                    {
                        Id = int.Parse(lerro["comment_id"].ToString()),
                        DateTime = DateTime.Parse(lerro["datetime"].ToString()),
                        Content = lerro["content"].ToString(),
                        User_Id = int.Parse(lerro["user_id"].ToString())
                    };
                    comment.User = Users.GetUserById(comment.User_Id.ToString());
                    commentList.Add(comment);
                }
                Comment_List = commentList;
                return commentList;
            }
            catch
            {
                return null;
            }
        }

        public static bool SaveComment(Comment comment)
        {
            try
            {
                String query = $"insert into comments(datetime, content, user_id) values ('{comment.DateTime}','{comment.Content}','{comment.User_Id}')";
                Connection.Connect();
                SqlCommand command = new SqlCommand(query, Connection.conn);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}