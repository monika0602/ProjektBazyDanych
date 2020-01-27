using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProjektMonika
{
    public partial class AddDrug : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataReader rdr = null;
                SqlCommand com2 = new SqlCommand("GetDrugs", con);
                string stringToDel = "<select class='form-control' name='del' id='del'>";
                com2.CommandType = CommandType.StoredProcedure;
                rdr = com2.ExecuteReader();
                while (rdr.Read())
                {
                    stringToDel += "<option value='" + rdr["id_leku"] + "'>" + rdr["nazwa"] + "</option>";
                }
                stringToDel += "</select>";
                drugs.InnerHtml = stringToDel;
                con.Close();

            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {

            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("DeleteDrug", con);
                SqlDataReader rdr = null;
                var id = Request.Form["del"];
                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.Add(new SqlParameter("@id_leku", id));
                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                rdr.Close();
                con.Close();
            }
            Response.Redirect("AddDrug.aspx");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("AddDrug", con);
                SqlDataReader rdr = null;
                string drug_name = Request.Form["drug_name"];
                var drug_priceStr = Request.Form["drug_price"];
             
                var prescriptionStr = Request.Form["prescription"];
                int prescription = 0;

                decimal drug_price = decimal.Parse(drug_priceStr);
                drug_price = Math.Round(drug_price, 4);
                

                if (prescriptionStr == "on")
                {
                    prescription = 1;
                }

                

                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.Add(new SqlParameter("@nazwa", drug_name));
                com1.Parameters.Add(new SqlParameter("@cena", drug_price));
                com1.Parameters.Add(new SqlParameter("@recepta", prescription));

                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                rdr.Close();
                con.Close();
            }

            Response.Redirect("AddDrug.aspx");
        }

        protected void GetDrugs_Click(object sender, EventArgs e)
        {
            Response.Redirect("GetDrugs.aspx");
        }
    }
}