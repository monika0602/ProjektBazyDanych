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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataReader rdr = null;
                SqlCommand com2 = new SqlCommand("GetCustomers", con);
                string stringToDel = "<select class='form-control' name='customer' id='customer'>";
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

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataReader rdr = null;
                SqlCommand com2 = new SqlCommand("GetFarm", con);
                string stringToDel = "<select class='form-control' name='farm' id='farm'>";
                com2.CommandType = CommandType.StoredProcedure;
                rdr = com2.ExecuteReader();
                while (rdr.Read())
                {
                    stringToDel += "<option value='" + rdr["id_apteki"] + "'>" + rdr["nazwa"] + ", " + rdr["ulica"] + " " + rdr["miasto"] + ", " + rdr["kod_pocztowy"] + "</option>";
                }
                stringToDel += "</select>";
                farms.InnerHtml = stringToDel;
                con.Close();
            }

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataReader rdr = null;
                SqlCommand com2 = new SqlCommand("GetDrugs", con);
                string stringToDel = "<select class='form-control' name='drug' id='drug'>";
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

        protected void Add_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;

            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com1 = new SqlCommand("AddOrder", con); //klient, apteka, data, lek, ilosc
                SqlDataReader rdr = null;
                var id_customer = Request.Form["customer"];
                var id_farm = Request.Form["farm"];
                var id_drug = Request.Form["drug"];
                var amount = Request.Form["amount"];

                com1.CommandType = CommandType.StoredProcedure;
                com1.Parameters.Add(new SqlParameter("@id_apteki", id_farm));
                com1.Parameters.Add(new SqlParameter("@id_leku", id_drug));
                com1.Parameters.Add(new SqlParameter("@id_klienta", id_customer));
                com1.Parameters.Add(new SqlParameter("@ilosc", amount));
                com1.Parameters.Add(new SqlParameter("@data_zamowienia", localDate));

                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                rdr.Close();
                con.Close();
            }

            Response.Redirect("CreateOrder.aspx");

        }
    }
}