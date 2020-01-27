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
    public partial class GetOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionStringDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string finalString = null;
                SqlCommand com1 = new SqlCommand("GetOrders", con);
                SqlDataReader rdr = null;
                com1.CommandType = CommandType.StoredProcedure;
                rdr = com1.ExecuteReader();
                while (rdr.Read())
                {
                    finalString += "<div><hr/><h3 class='text-danger mt-4'>Zamówienie numer " + rdr["id_zamowienia"] + "</h3>";

                    finalString += "<h4 class='text-left'> <b>Imię i nazwisko: </b> " + rdr["imie"] + " " + rdr["nazwisko"] + "</h4>";
                    finalString += "<h4 class='text-left'> <b>Nazwa apteki: </b> " + rdr["apteka"]  + "</h4>";
                    finalString += "<h4 class='text-left'> <b>Nazwa leku: </b> " + rdr["lek"] + "</h4>";

                   finalString += "<h4 class='text-left'> <b>Łączna cena: </b> " + rdr["cena"] + " zł</h4>";


                    finalString += "</div>";
                }

                orders.InnerHtml = finalString;

                rdr.Close();
                con.Close();
            }
        }
    }
}