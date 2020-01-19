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
    public partial class GetDrugs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string finalString = null;
                SqlCommand com1 = new SqlCommand("GetDrugs", con);
                SqlDataReader rdr = null;
                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                while (rdr.Read())
                {
                    finalString += "<hr/><h3 class='text-danger mt-4'>" + rdr["nazwa"] + "</h3>";
                    finalString += "<h4>" + rdr["cena"] + "</h4>";
                    if(rdr["recepta"] is 0)
                    {
                        finalString += "<h4>Bez recepty</h4>";
                    }
                    else
                    {
                        finalString += "<h4>Na recepte</h4>";
                    }
              
                    
                }
                drugs.InnerHtml = finalString;

                rdr.Close();
                con.Close();
            }

        }
    }
}