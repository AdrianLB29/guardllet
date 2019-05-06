using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Guardllet_Desarrollo.Backend.Data.Customers;
using Guardllet_Desarrollo.Backend.Data.Wallet;
using Guardllet_Desarrollo.Backend.Data.Movements;

namespace Guardllet_Desarrollo
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    string id = Session["usuario"].ToString();

                    int id_datos = ObtenerDatos.id_datos(Convert.ToInt16(id));
                    int id_datos_escolares = ObtenerDatos.id_datos_escolares(id_datos);
                    int id_monedero = ObtenerMonedero.id_monedero(Convert.ToInt16(id));

                    Dictionary<string, string> datos = ObtenerDatos.Generales(id_datos);
                    Dictionary<string, string> datos_escolares = ObtenerDatos.Escolares(id_datos_escolares);

                    LbNombre.Text = datos["Nombre"] + " " + datos["Apellido_p"] + " " + datos["Apellido_m"];
                    LbBoleta.Text = datos_escolares["Boleta"];
                    LbEscuela.Text = "Cecyt 13 'Ricardo Flores Magon'";

                    LbDNombre.Text = datos["Nombre"];
                    LbDApellidoP.Text = datos["Apellido_p"];
                    LbDApellidoM.Text = datos["Apellido_m"];
                    LbDCelular.Text = datos["Celular"];
                    LbDEdad.Text = datos_escolares["Edad"] + " " + "años";

                    Dictionary<string, Dictionary<string, string>> tickets = Comprobante.Obtener(id_monedero);

                    int numero_tickets = tickets.Count();

                    for (int i = numero_tickets-1; i < numero_tickets & i != -1; i--)
                    {
                        Dictionary<string, string> ticket = tickets[string.Format("{0} Ticket",i)];

                        HtmlGenericControl item = new HtmlGenericControl("div");
                        item.Attributes.Add("class", "ticket");
                        item.ID = "compra";

                        HtmlGenericControl item2 = new HtmlGenericControl("div");
                        item2.Attributes.Add("class", "Decoracion");

                        HtmlGenericControl item3 = new HtmlGenericControl("div");
                        item3.Attributes.Add("class", "contenido");

                        HtmlGenericControl item31 = new HtmlGenericControl("div");
                        item31.Attributes.Add("class", "definicion");

                        HtmlGenericControl item32 = new HtmlGenericControl("div");
                        item32.Attributes.Add("class", "fecha");

                        Label nombre = new Label();
                        nombre.ID = "NombreProducto";
                        nombre.Text = ticket["Nombre"];

                        Label fecha = new Label();
                        fecha.ID = "FechaCompra";
                        fecha.Text = ticket["Fecha"];

                        item31.Controls.Add(nombre);
                        item32.Controls.Add(fecha);
                        item3.Controls.Add(item31);
                        item3.Controls.Add(item32);

                        HtmlGenericControl item4 = new HtmlGenericControl("div");
                        item4.Attributes.Add("class", "descarga");

                        HtmlButton descargar = new HtmlButton();
                        descargar.ID = "descargar";
                        descargar.Attributes.Add("onclick", string.Format("DescargarPDF('TKT{0}', 'TICKET0{1}')", i,i));
                        descargar.Attributes.Add("type", "button");
                        descargar.Attributes.Add("class", "icon-download");

                        item4.Controls.Add(descargar);

                        item.Controls.Add(item2);
                        item.Controls.Add(item3);
                        item.Controls.Add(item4);

                        HtmlGenericControl item5 = new HtmlGenericControl("div");
                        item5.Attributes.Add("class", "plantilla");
                        item5.ID = string.Format("TKT{0}",i);

                        Label Guardllet = new Label();
                        Guardllet.Text = "Guardllet";

                        item5.Controls.Add(Guardllet);

                        ContenedorTickets.Controls.Add(item);
                        ContenedorTickets.Controls.Add(item5);
                    }
                }
                else
                {
                    Response.AppendHeader("Cache-Control", "no-store");
                    Response.Redirect("default.aspx");
                }

            } 
        }

        protected void BotonSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Redirect("default.aspx");
        }

        protected void BotonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiDinero.aspx");
        }

        protected void BotonServicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Servicios.aspx");
        }

        protected void BotonPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }
    }
}