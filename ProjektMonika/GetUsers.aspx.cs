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
    public partial class GetUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string finalString = null;
                SqlCommand com1 = new SqlCommand("GetCustomers", con);
                SqlDataReader rdr = null;
                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                while (rdr.Read())
                {
                    finalString += "<hr/><h4 class='text-left'> Imię: " + rdr["imie"] + "</h4>";
                    finalString += "<h4 class='text-left'> Nazwisko: " + rdr["nazwisko"] + "</h4>";

                }
                customers.InnerHtml = finalString;

                rdr.Close();
                con.Close();
            }
        }
    }
}