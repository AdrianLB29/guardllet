using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guardllet_Desarrollo.Frontend.Administrators
{
    public partial class Administrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProducto_Click(object sender, EventArgs e)
        {
            lId.Visible = true;
            txtID.Visible = true;
            lNombre.Visible = true;
            txtNombre.Visible = true;
            lCodigo.Visible = true;
            txtCodigo.Visible = true;
            Image1.Visible = true;
            btnProducto.Enabled = false;

        }
    }
}