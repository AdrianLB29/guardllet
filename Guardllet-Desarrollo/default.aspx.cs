using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guardllet_Desarrollo
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entra.aspx");
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrate.aspx");
        }

    }
}