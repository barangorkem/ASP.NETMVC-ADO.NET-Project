using MVCAdoProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
namespace MVCAdoProject.Repository
{
    public class MyRepository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDatabase"].ConnectionString);

        public Users isUserData(string UserName,string Password)
        {
            SqlCommand command = new SqlCommand("isUser", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            Users user = new Users();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                user.UserId = Convert.ToInt32(dr["UserId"]);
                user.UserName = Convert.ToString(dr["UserName"]);
              

            }
            return user;

        }
        public string userAuth(string UserName)
        {
            string Auth=null;
            SqlCommand command = new SqlCommand("userAuth", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach(DataRow dr in dt.Rows)
            {
                Auth = Convert.ToString(dr["Auth"]);
            }
            return Auth;
        }
        public int userId(string UserName)
        {
            int id = 0;
            SqlCommand command = new SqlCommand("userId", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                id = Convert.ToInt32(dr["UserId"]);
            }
            return id;
        }
        public void doComments(Comments comments,string UserName)
        {
            
            SqlCommand command = new SqlCommand("commentAdd", con);
            comments.UserId = userId(UserName);
            comments.CommentDate = DateTime.Now;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CommentContent", comments.CommentContent);
            command.Parameters.AddWithValue("@CommentDate", comments.CommentDate);
            command.Parameters.AddWithValue("@UserId", comments.UserId);
            command.Parameters.AddWithValue("@PostId", comments.PostId);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

        }
        public List<PostComments> getComments(int id)
        {
            SqlCommand command = new SqlCommand("postComment", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PostId",id);
            List<PostComments> postComments = new List<PostComments>();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                postComments.Add(

                    new PostComments
                    {
                        CommentId = Convert.ToInt32(dr["CommentId"]),
                        CommentContent = Convert.ToString(dr["CommentContent"]),
                        CommentDate = Convert.ToDateTime(dr["CommentDate"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        PostId= Convert.ToInt32(dr["PostId"])
                    }


                    );


            }
            return postComments;
        }
    }
}