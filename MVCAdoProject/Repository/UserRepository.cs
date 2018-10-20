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
    public class UserRepository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDatabase"].ConnectionString);

        public bool AddUser(Users user)
        {
         
            SqlCommand command = new SqlCommand("userAdd", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.Parameters.AddWithValue("@Auth", user.Auth);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            return true;
        }
        public List<Users> ListUsers()
        {
            SqlCommand command = new SqlCommand("userList", con);
            command.CommandType = CommandType.StoredProcedure;
            List<Users> users = new List<Users>();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                users.Add(

                    new Users
                    {
                        UserId = Convert.ToInt32(dr["UserId"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        Password = Convert.ToString(dr["Password"]),
                        Email = Convert.ToString(dr["Email"]),
                        Auth = Convert.ToString(dr["Auth"]),
                        Gender= Convert.ToString(dr["Gender"])
                        
                    }


                    );


            }

            return users;
        }
        public void DeleteUser(int id)
        {
            SqlCommand command = new SqlCommand("userDelete", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId",id);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public Users FindUser(int id)
        {
            SqlCommand command = new SqlCommand("userFind", con);
            command.CommandType = CommandType.StoredProcedure;
             command.Parameters.AddWithValue("@UserId",id);
            Users users = new Users();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach(DataRow dr in dt.Rows)
            {
                users.UserId = Convert.ToInt32(dr["UserId"]);
                users.UserName = dr["UserName"].ToString();
                users.Password = dr["Password"].ToString();
                users.Email = Convert.ToString(dr["Email"]);
                users.Auth = Convert.ToString(dr["Auth"]);
                users.Gender = Convert.ToString(dr["Gender"]);
            }
            return users;
        }
        public void UpdateUser(int id,Users user)
        {
            SqlCommand command = new SqlCommand("userUpdate", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", id);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.Parameters.AddWithValue("@Auth", user.Auth);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}