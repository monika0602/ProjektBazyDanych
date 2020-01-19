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
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataReader rdr = null;
                SqlCommand com2 = new SqlCommand("GetCustomers", con);
                string stringToDel = "<select class='form-control' name='del' id='del'>";
                com2.CommandType = CommandType.StoredProcedure;
                rdr = com2.ExecuteReader();
                while (rdr.Read())
                {
                    stringToDel += "<option value='" + rdr["id_klienta"] + "'>" + rdr["imie"] + " " + rdr["nazwisko"] + "</option>";
                }
                stringToDel += "</select>";
                customers.InnerHtml = stringToDel;
                con.Close();

            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {

            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("DeleteCustomer", con);
                SqlDataReader rdr = null;
                var id = Request.Form["del"];
                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.Add(new SqlParameter("@id_klienta", id));
                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                rdr.Close();
                con.Close();
            }
            Response.Redirect("AddCustomer.aspx");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("AddCustomer", con);
                SqlDataReader rdr = null;
                string user_name = Request.Form["user_name"];
                string user_surrname = Request.Form["user_surrname"];
                
                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.Add(new SqlParameter("@imie", user_name));
                com1.Parameters.Add(new SqlParameter("@nazwisko", user_surrname));

                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                rdr.Close();
                con.Close();
            }

            Response.Redirect("AddCustomer.aspx");
        }

        protected void GetUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("GetUsers.aspx");
        }
    }
}