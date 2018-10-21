using MVCAdoProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCAdoProject.Repository
{
    public class CommentRepository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDatabase"].ConnectionString);
        
        public void deleteComments(int commentId)
        {
            SqlCommand command = new SqlCommand("commentDelete", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CommentId", commentId);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public List<PostComments> getComments()
        {
            SqlCommand command = new SqlCommand("getComments", con);
            command.CommandType = CommandType.StoredProcedure;
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
                        PostId = Convert.ToInt32(dr["PostId"])
                    }


                    );


            }
            return postComments;
        }
    }
}