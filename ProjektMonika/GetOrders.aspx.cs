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
                    var idZamowienia = rdr["id_zamowienia"];
                    finalString += "<hr/><h3 class='text-danger mt-4'> Zamówienie numer" + rdr["id_zamowienia"] + "</h3>";
                    finalString += "<h3>Data zamowienia: " + rdr["data_zamowienia"] + "</h3>";
                    finalString += "<h3>Klient: " + rdr["imie"] + " " + rdr["nazwisko"] + "</h3>";
                    finalString += "<h3>Apteka: " + rdr["nazwa"] + "</h3>";
                    SqlCommand com2 = new SqlCommand("GetAllDetils", con);
                    SqlDataReader rdr2 = null;
                    com2.CommandType = CommandType.StoredProcedure;
                    com1.Parameters.Add(new SqlParameter("@idZamowienia", idZamowienia));
                    rdr2 = com2.ExecuteReader();
                    string innerString = null;
                    while (rdr2.Read())
                    {
                        

                        innerString += "<h4> Lek:" + rdr2["nazwa"] + ", Cena: " + rdr2["cena"] + " zł Ilość: " + rdr2["ilosc"] + "</h4>";

                    }

                    finalString += innerString;

                }

                orders.InnerHtml = finalString;

                rdr.Close();
                con.Close();
            }
        }
    }
}