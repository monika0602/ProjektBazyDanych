using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektMonika
{
    public partial class AddFarm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataReader rdr = null;
                SqlCommand com2 = new SqlCommand("GetFarm", con);
                string stringToDel = "<select class='form-control' name='del' id='del'>";
                com2.CommandType = CommandType.StoredProcedure;
                rdr = com2.ExecuteReader();
                while (rdr.Read())
                {
                    stringToDel += "<option value='" + rdr["id_apteki"] + "'>" + rdr["nazwa"] + ", " +  rdr["ulica"] + " " + rdr["miasto"] + ", " + rdr["kod_pocztowy"] + "</option>";
                }
                stringToDel += "</select>";
                farms.InnerHtml = stringToDel;
                con.Close();
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {

            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("DeleteFarm", con);
                SqlDataReader rdr = null;
                var id = Request.Form["del"];
                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.Add(new SqlParameter("@id_apteki", id));
                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                rdr.Close();
                con.Close();
            }
            Response.Redirect("AddFarm.aspx");

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("AddFarm", con);
                SqlDataReader rdr = null;
                string farm_name = Request.Form["farm_name"];
                string street_name = Request.Form["street_name"];
                string city = Request.Form["city"];
                string postcode = Request.Form["postcode"];

                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.Add(new SqlParameter("@nazwa", farm_name));
                com1.Parameters.Add(new SqlParameter("@ulica", street_name));
                com1.Parameters.Add(new SqlParameter("@miasto", city));
                com1.Parameters.Add(new SqlParameter("@kod_pocztowy", postcode));

                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                rdr.Close();
                con.Close();

            }

            Response.Redirect("AddFarm.aspx");
        }

        protected void GetFarm_Click(object sender, EventArgs e)
        {
            Response.Redirect("GetFarm.aspx");
        }
        
    }
}