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
    public class PostsRepository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDatabase"].ConnectionString);

        public List<Posts> ListPosts()
        {
            SqlCommand command = new SqlCommand("postList", con);
            command.CommandType = CommandType.StoredProcedure;
            List<Posts> posts = new List<Posts>();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                posts.Add(

                    new Posts
                    {
                        PostId = Convert.ToInt32(dr["PostId"]),
                        PostTitle = Convert.ToString(dr["PostTitle"]),
                        PostContent = Convert.ToString(dr["PostContent"]),
                        PostImage = Convert.ToString(dr["PostImage"]),

                    }


                    );


            }
            return posts;
        }
        public Posts FindPosts(int id)
        {
            SqlCommand command = new SqlCommand("postFind", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PostId", id);
            Posts post = new Posts();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                post.PostId = Convert.ToInt32(dr["PostId"]);
                post.PostTitle = Convert.ToString(dr["PostTitle"]);
                post.PostContent = Convert.ToString(dr["PostContent"]);
                post.PostImage = Convert.ToString(dr["PostImage"]);

            }
            return post;
        }
    }
}