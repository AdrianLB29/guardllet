using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guardllet_Desarrollo
{
    public partial class carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    if (Session["articulo"] == "Examen") 
                    {
                        LbExamen.Visible = true;
                        TxtMateria.Visible = true;
                        BtnPagarEts.Visible = true;
                    }
                    else if (Session["articulo"] == "Credencial")
                    {
                        LbCredencial.Visible = true;
                        BtnPagarCrd.Visible = true;
                    }
                    else if (Session["articulo"] == "Deuda")
                    {
                        LbDeuda.Visible = true;
                        TxtMonto.Visible = true;
                        BtnPagarDeu.Visible = true;
                    }
                    else if (Session["articulo"] == "Papeleria")
                    {
                        LbCopias.Visible = true;
                        TxtCopias.Visible = true;
                        BtnPagarCop.Visible = true;
                    }
                }
                else
                {
                    Response.AppendHeader("Cache-Control", "no-store");
                    Response.Redirect("default.aspx");
                }

            } 
        }

        protected void BtnPagarEts_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPagarCrd_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPagarDeu_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPagarCop_Click(object sender, EventArgs e)
        {

        }
    }
}