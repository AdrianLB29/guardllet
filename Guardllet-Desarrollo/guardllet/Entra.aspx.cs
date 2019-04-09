using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

using Guardllet_Desarrollo.Backend.Data.Accounts;

namespace Guardllet_Desarrollo.Frontend.Accounts
{
    public partial class Iniciar_Sesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void BtnResgitrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrate.aspx");
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            if(TxtCorreo.Text != "" & TxtContraseña.Text != "")

            {
                bool login = SesionUsuario.IniciarSesion(TxtCorreo.Text.Trim(), TxtContraseña.Text.Trim());
                if (login)
                {
                    int id = Datos.ObtenerID(TxtCorreo.Text.Trim());

                    int tipo_usuario = Datos.ObtenerTipoUsuario(Convert.ToInt16(id));

                    if (tipo_usuario == 1)
                    {
                        int estado_usuario = Datos.ObtenerEstadoUsuario(Convert.ToInt16(id));

                        if (estado_usuario == 1)
                        {
                            Session["usuario"] = id;
                            string id_usuario = id.ToString();
                            FormsAuthentication.SetAuthCookie(id_usuario, false);
                            Response.Redirect("Datos.aspx", false);
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                        }
                        else if (estado_usuario == 3)
                        {

                        }
                        else
                        {
                            Session["usuario"] = id;
                            string id_usuario = id.ToString();
                            FormsAuthentication.SetAuthCookie(id_usuario, false);
                            Response.Redirect("MiDinero.aspx", false);
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                        }

                    }

                    if (tipo_usuario == 2)
                    {
                        Session["usuario"] = id;
                        string id_usuario = id.ToString();
                        FormsAuthentication.SetAuthCookie(id_usuario, false);
                        Response.Redirect("Vender.aspx", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }

                    if (tipo_usuario == 3)
                    {
                        Session["usuario"] = id;
                        string id_usuario = id.ToString();
                        FormsAuthentication.SetAuthCookie(id_usuario, false);
                        Response.Redirect("Administrar.aspx", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {

                }  
            }
        }
    }
}