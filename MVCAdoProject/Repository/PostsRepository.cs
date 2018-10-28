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
        public PostViewModel ListPostViewModel(int PostId)
        {
            SqlCommand command = new SqlCommand("postCategoriesListDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PostId", PostId);
            PostViewModel postViewModel = new PostViewModel();
            var checkboxlist = new List<CheckBoxViewCategoryModel>();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                postViewModel.PostId = Convert.ToInt32(dr["PostId"]);
                postViewModel.PostTitle=Convert.ToString(dr["PostTitle"]);
                postViewModel.PostContent = Convert.ToString(dr["PostContent"]);
                checkboxlist.Add(new CheckBoxViewCategoryModel
                {
                    Id= Convert.ToInt32(dr["CategoryId"]),
                    Name= Convert.ToString(dr["CategoryName"]),
                    Checked=true
                });
            


            }
            postViewModel.Category = checkboxlist;
            return postViewModel;
            
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
        public void AddPost(PostViewModel postViewModel)
        {
            SqlCommand command = new SqlCommand("postAdd", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PostTitle", postViewModel.PostTitle);
            command.Parameters.AddWithValue("@PostContent", postViewModel.PostContent);
            command.Parameters.AddWithValue("@PostImage", "adsdas");
            var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            con.Open();
            command.ExecuteNonQuery();
            var result = returnParameter.Value;
            con.Close();
            AddPostCategory(Convert.ToInt32(result), postViewModel.Category);
           

        }
        public void AddPostCategory(int PostId,List<CheckBoxViewCategoryModel> checkBoxViewCategoryModels)
        {
            
            foreach (var item in checkBoxViewCategoryModels)
            {
                if (item.Checked == true)
                {
                    SqlCommand command = new SqlCommand("postcategoryAdd", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PostId",PostId);
                    command.Parameters.AddWithValue("@CategoryId",item.Id );
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();

                }
                }
        }
        public bool IsCheck(int postId,int categoryId)
        {
            SqlCommand command = new SqlCommand("isCheckCategory", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PostId", postId);
            command.Parameters.AddWithValue("@CategoryId", categoryId);
            var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            con.Open();
            command.ExecuteNonQuery();

            var result = returnParameter.Value;
            con.Close();
            if(Convert.ToInt32(result)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void UpdatePostRecord(PostViewModel postViewModel)
        {
            SqlCommand command = new SqlCommand("updatePost", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PostId", postViewModel.PostId);
            command.Parameters.AddWithValue("@PostTitle", postViewModel.PostTitle);
            command.Parameters.AddWithValue("@PostContent", postViewModel.PostContent);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            deletePostCategory(postViewModel.PostId);
            AddPostCategory(postViewModel.PostId, postViewModel.Category);
        
        }
        public void deletePostCategory(int postId)
        {
            
            SqlCommand command = new SqlCommand("deletePostCategory", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PostId",postId);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
   
        public void deletePost(int postId)
        {
            deletePostCategory(postId);
            SqlCommand command = new SqlCommand("deletePost", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PostId", postId);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
           
        }


    }
}