using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Guardllet_Desarrollo.Backend.Data.Customers;

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

                    Dictionary<string, string> datos = ObtenerDatos.Generales(id_datos);
                    Dictionary<string, string> datos_escolares = ObtenerDatos.Escolares(id_datos_escolares);

                    LbNombre.Text = datos["Nombre"] + " " + datos["Apellido_p"] + " " + datos["Apellido_m"];
                    LbBoleta.Text = datos_escolares["Boleta"];
                    LbEscuela.Text = "Cecyt 13 'Ricardo Flores Magon'";



                    for (int i = 0; i < 5; i++)
                    {
                        HtmlGenericControl item = new HtmlGenericControl("div");
                        item.Attributes.Add("class", "ticket");
                        item.ID = "compra";

                        HtmlGenericControl item2 = new HtmlGenericControl("div");
                        item2.Attributes.Add("class", "Decoracion");

                        HtmlGenericControl item3 = new HtmlGenericControl("div");
                        item3.Attributes.Add("class", "contenido");

                        Label nombre = new Label();
                        nombre.ID = "NombreProducto";
                        nombre.Text = "Pago de examen";

                        Label fecha = new Label();
                        fecha.ID = "FechaCompra";
                        fecha.Text = "Fecha de compra";

                        item3.Controls.Add(nombre);
                        item3.Controls.Add(fecha);

                        HtmlGenericControl item4 = new HtmlGenericControl("div");
                        item4.Attributes.Add("class", "descarga");

                        Label icono = new Label();
                        icono.Attributes.Add("class", "icon-download");
                        icono.Visible = false;

                        item4.Controls.Add(icono);

                        Button descargar = new Button();
                        descargar.ID = "descargar";
                        descargar.Text = icono.Text;
                       
                        item4.Controls.Add(descargar);

                        item.Controls.Add(item2);
                        item.Controls.Add(item3);
                        item.Controls.Add(item4);


                        ContenedorTickets.Controls.Add(item);
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