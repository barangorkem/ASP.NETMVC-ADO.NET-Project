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
    public class CategoriesRepository
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDatabase"].ConnectionString);

        public List<Categories> ListCategories()
        {
            SqlCommand command = new SqlCommand("categoriesList", con);
            command.CommandType = CommandType.StoredProcedure;
            List<Categories> categories = new List<Categories>();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                categories.Add(

                    new Categories
                    {
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        CategoryName = Convert.ToString(dr["CategoryName"]),
                    }


                    );


            }
            return categories;
        }

    }
}