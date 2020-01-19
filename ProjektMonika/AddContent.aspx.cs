using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektMonika
{
    public partial class AddContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddFarm_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFarm.aspx");
        }

        protected void AddDrug_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDrug.aspx");
        }

        protected void AddCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCustomer.aspx");
        }
    }

}