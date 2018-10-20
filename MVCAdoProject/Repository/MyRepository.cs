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
    }
}