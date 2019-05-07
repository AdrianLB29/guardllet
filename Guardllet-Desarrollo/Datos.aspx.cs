using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

using Guardllet_Desarrollo.Backend.Data.Customers;
using Guardllet_Desarrollo.Backend.Data.Accounts;
using Guardllet_Desarrollo.Backend.Data.Wallet;

namespace Guardllet_Desarrollo.Frontend.Accounts
{
    public partial class Completar_Datos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    if (!IsPostBack)
                    {

                        // Carga el DrowpList con las escuelas disponibles 
                        ListaEscuelas.Items.Insert(0, "Selecciona tu escuela");
                        Dictionary<int, Dictionary<string, string>> Escuelas = Datos.ObtenerEscuelas();
                        int numero_escuelas = Escuelas.Count();
                        for (int i = 0; i < numero_escuelas; i++)
                        {
                            Dictionary<string, string> Escuela = Escuelas[i];
                            int id = Convert.ToInt16(Escuela["Id"]);
                            string nombre = Escuela["Nombre"];
                            ListaEscuelas.Items.Insert(id, nombre);
                        }



                    }
                }
                else
                {
                    Response.AppendHeader("Cache-Control", "no-store");
                    Response.Redirect("default.aspx");
                }
            }
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            // ID del usuario que esta en sesion
            int id = Convert.ToInt16(Session["usuario"].ToString());

            // Obtiene la escuela que selecciono en usuario
            int escuela = Convert.ToInt16(ListaEscuelas.SelectedIndex.ToString());

            bool valida_celular = Validar.Celular(TxtCelular.Text.Trim());

            if (valida_celular)
            {
                bool valida_boleta = Validar.Boleta(TxtBoleta.Text.Trim());

                if (valida_boleta)
                {
                    bool valida_grupo = Validar.Grupo(TxtGrupo.Text.Trim().ToUpper());

                    if (valida_grupo)
                    {
                        int registro_datos = AgregarDatos.Generales(TxtNombre.Text.Trim(), TxtApellidoP.Text.Trim(), TxtApellidoM.Text.Trim(), TxtCelular.Text.Trim());

                        if (registro_datos != 0)
                        {
                            int registro_datos_escolares = AgregarDatos.Escolares(escuela, TxtBoleta.Text.Trim(), TxtGrupo.Text.Trim().ToUpper(), TxtEdad.Text.Trim());

                            if (registro_datos_escolares != 0)
                            {
                                int vincular_datos = Datos.VincularDatosGenerales(id, registro_datos);

                                if (vincular_datos != 0)
                                {
                                    int vincular_datos_escolares = Datos.VincularDatosEscolares(registro_datos, registro_datos_escolares);

                                    if (vincular_datos_escolares != 0)
                                    {

                                        string codigo = CreacionCodigo.Monedero(TxtBoleta.Text.Trim());
                                        Byte[] codigo_barras = CreacionCodigo.Barras(codigo);

                                        int registro_monedero = Monedero.Crear(codigo, codigo_barras);

                                        if (registro_monedero != 0)
                                        {

                                            int vincular_codigo = Monedero.Vincular(id, registro_monedero);

                                            if (vincular_codigo != 0)
                                            {

                                                string id_usuario = id.ToString();
                                                FormsAuthentication.SetAuthCookie(id_usuario, false);
                                                Response.Redirect("MiDinero.aspx", false);
                                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                                                Response.AppendHeader("Cache-Control", "no-store");
                                                Response.AppendHeader("Pragma", "no-cache");
                                                Response.CacheControl = "no-cache"; Response.Expires = -1;
                                            }
                                            else
                                            {
                                                LbError.Visible = true;
                                                LbError.Text = "Error al registrar datos, intentalo mas tarde";
                                            }
                                        }
                                        else
                                        {
                                            LbError.Visible = true;
                                            LbError.Text = "Error al registrar datos, intentalo mas tarde";
                                        }
                                    }
                                    else
                                    {
                                        LbError.Visible = true;
                                        LbError.Text = "Error al registrar datos, intentalo mas tarde";
                                    }
                                }
                                else
                                {
                                    LbError.Visible = true;
                                    LbError.Text = "Error al registrar datos, intentalo mas tarde";
                                }
                            }
                            else
                            {
                                LbError.Visible = true;
                                LbError.Text = "Error al registrar datos, intentalo mas tarde";
                            }
                        }
                        else
                        {
                            LbError.Visible = true;
                            LbError.Text = "Error al registrar datos, intentalo mas tarde";
                        }
                    }
                    else
                    {
                        LbError.Visible = true;
                        LbError.Text = "Ingresa un grupo valido";
                    }
                }
                else
                {
                    LbError.Visible = true;
                    LbError.Text = "Ingresa un numero de boleta valido";

                }

            }
            else
            {
                LbError.Visible = true;
                LbError.Text = "Ingresa un numero de celular valido";
            }
        }
    }
}