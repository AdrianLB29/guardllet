using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Guardllet_Desarrollo.Backend.Data.Customers;
using Guardllet_Desarrollo.Backend.Data.Wallet;
using Guardllet_Desarrollo.Backend.Data.Movements;

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
            int precio = 10; 

            string materia = TxtMateria.Text;

            int id_usuario = Convert.ToInt16(Session["usuario"]);
            int id_monedero = ObtenerMonedero.id_monedero(id_usuario);

            int saldo = ObtenerMonedero.Saldo(id_monedero);

            int nuevo_saldo = saldo - precio;
            if (nuevo_saldo > 0) 
            {
                bool actualizar_saldo = Monedero.ActualizarSaldo(id_monedero, nuevo_saldo);

                int registro = MovimientoCV.Registrar(1, id_monedero, 1, 12342);
            }
            else
            {

            }
        }

        protected void BtnPagarCrd_Click(object sender, EventArgs e)
        {
            int precio = 58;

            string materia = TxtMateria.Text;

            int id_usuario = Convert.ToInt16(Session["usuario"]);

            int id_monedero = ObtenerMonedero.id_monedero(id_usuario);

            int saldo = ObtenerMonedero.Saldo(id_monedero);

            int nuevo_saldo = saldo - precio;

            if (nuevo_saldo > 0)
            {

            }
            else
            {

            }
        }

        protected void BtnPagarDeu_Click(object sender, EventArgs e)
        {
            int precio = Convert.ToInt16(TxtMonto.Text.Trim());

            string materia = TxtMateria.Text;

            int id_usuario = Convert.ToInt16(Session["usuario"]);

            int id_monedero = ObtenerMonedero.id_monedero(id_usuario);

            int saldo = ObtenerMonedero.Saldo(id_monedero);

            int proceso = saldo - precio;

            if (proceso > 0)
            {

            }
            else
            {

            }
        }

        protected void BtnPagarCop_Click(object sender, EventArgs e)
        {
            int precio = Convert.ToInt16(TxtCopias.Text.Trim());

            string materia = TxtMateria.Text;

            int id_usuario = Convert.ToInt16(Session["usuario"]);

            int id_monedero = ObtenerMonedero.id_monedero(id_usuario);

            int saldo = ObtenerMonedero.Saldo(id_monedero);

            int proceso = saldo - precio;

            if (proceso > 0)
            {

            }
            else
            {

            }
        }
    }
}