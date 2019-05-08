using Guardllet_Desarrollo.Backend.Data.Accounts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            if (!Page.IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    LUsuario.Text = Session["usuario"].ToString();
                }
                else
                {
                    Response.AppendHeader("Cache-Control", "no-store");
                    Response.Redirect("default.aspx");
                }
            }

            int usuario = Convert.ToInt16(Session["usuario"]);
        }

        protected void btnProducto_Click(object sender, EventArgs e)
        {
            lId.Visible = true;
            txtID.Visible = true;
            lNombre.Visible = true;
            txtNombre.Visible = true;
            lCodigo.Visible = true;
            txtCodigo.Visible = true;
            btnProducto.Enabled = false;
            btnAgregar.Visible = true;
            btnActualizar.Visible = true;
            btnBorrar.Visible = true;
            btnUsuarios.Enabled = true;
            btnBuscar.Visible = true;
            lPrecio.Visible = true;
            txtPrecio.Visible = true;
            btnREcargas.Visible = false;
            btnBuscar3.Visible = false;
            btnProductos.Visible = false;
            btnInformacion.Enabled = true;
            Grafica.Visible = false;
            Grafica1.Visible = false;
            Calendar1.Visible = false;
            Calendar2.Visible = false;





            lIDU.Visible = false;
            txtIDU.Visible = false;
            lTipo.Visible = false;
            txtTipo.Visible = false;
            lEstado.Visible = false;
            btnActualizarU.Visible = false;
            btnBuscarU.Visible = false;
            btnBorrarU.Visible = false;
            txtEstado.Visible = false;
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            lId.Visible = false;
            txtID.Visible = false;
            lNombre.Visible = false;
            txtNombre.Visible = false;
            lCodigo.Visible = false;
            txtCodigo.Visible = false;
            btnProducto.Enabled = true;
            btnAgregar.Visible = false;
            btnActualizar.Visible = false;
            btnBorrar.Visible = false;
            btnUsuarios.Enabled = false;
            btnBuscar.Visible = false;
            lPrecio.Visible = false;
            txtPrecio.Visible = false;
            btnBuscar3.Visible = false;
            btnREcargas.Visible = false;
            btnProductos.Visible = false;
            btnInformacion.Enabled = true;
            Grafica.Visible = false;
            Grafica1.Visible = false;
            Calendar1.Visible = false;
            Calendar2.Visible = false;





            lIDU.Visible = true;
            txtIDU.Visible = true;
            lTipo.Visible = true;
            txtTipo.Visible = true;
            lEstado.Visible = true;
            btnActualizarU.Visible = true;
            btnBuscarU.Visible = true;
            btnBorrarU.Visible = true;
            txtEstado.Visible = true;

        }
        protected void btnInformacion_Click(object sender, EventArgs e)
        {
            lId.Visible = false;
            txtID.Visible = false;
            lNombre.Visible = false;
            txtNombre.Visible = false;
            lCodigo.Visible = false;
            txtCodigo.Visible = false;
            btnProducto.Enabled = true;
            btnAgregar.Visible = false;
            btnActualizar.Visible = false;
            btnBorrar.Visible = false;
            btnUsuarios.Enabled = true;
            btnBuscar.Visible = false;
            lPrecio.Visible = false;
            txtPrecio.Visible = false;
            Grafica.Visible = false;
            Grafica1.Visible = false;
            Calendar1.Visible = false;
            Calendar2.Visible = false;



            btnProductos.Visible = true;
            btnREcargas.Visible = true;
            btnInformacion.Enabled = false;
        }

        protected void btnREcargas_Click(object sender, EventArgs e)
        {
            btnREcargas.Enabled = false;
            btnProducto.Enabled = true;
            lFechaI.Visible = true;
            lFechaFinal.Visible = true;

            btnBuscar3.Visible = true;
            btnInformacion.Enabled = false;
            btnProductos.Enabled = true;
            Grafica.Visible = true;
            Grafica1.Visible = false;
            Calendar1.Visible = true;
            Calendar2.Visible = true;

        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            btnProductos.Enabled = false;
            lFechaI.Visible = false;
            lFechaFinal.Visible = false;
            Calendar1.Visible = false;
            Calendar2.Visible = false;

            btnBuscar3.Visible = false;
            btnInformacion.Enabled = false;
            btnREcargas.Enabled = true;
            Grafica.Visible = false;
            Grafica1.Visible = true;
            OD1();
            txtinicio.Text = "";
            txtfinal.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                using (SqlConnection Conexion = new SqlConnection(StringConexion))
                    try
                    {
                        int s = 0;
                        s = Convert.ToInt16(txtPrecio.Text);
                        Conexion.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCTO (NOMBRE,CODIGO,PRECIO) VALUES ('" + txtNombre.Text + "'," + "'" + txtCodigo.Text + "',"
                                + s + ")", Conexion);
                        cmd.ExecuteNonQuery();
                        Conexion.Close();

                        txtID.Text = "";
                        txtNombre.Text = "";
                        txtCodigo.Text = "";
                        txtPrecio.Text = "";
                    }
                    catch (Exception es)
                    {

                    }
            }
            else if (txtID.Text != "")
            {
                txtID.Text = "El ID No se pone";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (txtNombre.Text != "")
                {
                    string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                    using (SqlConnection Conexion = new SqlConnection(StringConexion))
                        try
                        {
                            Conexion.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE PRODUCTO Set NOMBRE = '" + txtNombre.Text + "' where ID_PRODUCTO = " + txtID.Text + "", Conexion);
                            cmd.ExecuteNonQuery();




                        }
                        catch (Exception es)
                        {

                        }
                }
                if (txtPrecio.Text != "")
                {
                    string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                    using (SqlConnection Conexion = new SqlConnection(StringConexion))
                        try
                        {
                            int s = 0;
                            s = Convert.ToInt16(txtPrecio.Text);
                            Conexion.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE PRODUCTO Set PRECIO = " + s + " where ID_PRODUCTO = " + txtID.Text + "", Conexion);
                            cmd.ExecuteNonQuery();


                        }
                        catch (Exception es)
                        {

                        }

                }
                if (txtCodigo.Text != "")
                {
                    string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                    using (SqlConnection Conexion = new SqlConnection(StringConexion))
                        try
                        {

                            Conexion.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE PRODUCTO Set CODIGO = '" + txtCodigo.Text + "' where ID_PRODUCTO = " + txtID.Text + "", Conexion);
                            cmd.ExecuteNonQuery();



                        }
                        catch (Exception es)
                        {

                        }
                }
            }
            else if (txtID.Text == "")
            {
                txtID.Text = "Intorude una ID";
            }

            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtPrecio.Text = "";
            txtID.Text = "Actualizacion exitosa";
        }

        protected void btnBuscarU_Click(object sender, EventArgs e)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection Conexion = new SqlConnection(StringConexion))
                try
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("SELECT  ID_USUARIO,TIPO_USUARIO, ESTADO FROM USUARIO where ID_USUARIO = '" + txtIDU.Text + "'", Conexion);
                    SqlDataReader leer = cmd.ExecuteReader();
                    if (leer.Read() == true)
                    {

                        txtIDU.Text = leer["ID_USUARIO"].ToString();
                        txtTipo.Text = leer["TIPO_USUARIO"].ToString();
                        txtEstado.Text = leer["ESTADO"].ToString();
                    }
                    else
                    {

                    }

                    Conexion.Close();
                }
                catch (Exception es)
                {

                }
        }

        protected void btnActualizarU_Click(object sender, EventArgs e)
        {
            if (txtIDU.Text != "")
            {
                if (txtTipo.Text != "")
                {
                    string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                    using (SqlConnection Conexion = new SqlConnection(StringConexion))
                        try
                        {

                            Conexion.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE USUARIO Set TIPO_USUARIO = '" + txtTipo.Text + "' where ID_USUARIO = " + txtIDU.Text + "", Conexion);
                            cmd.ExecuteNonQuery();



                        }
                        catch (Exception es)
                        {

                        }
                }
                if (txtEstado.Text != "")
                {
                    string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                    using (SqlConnection Conexion = new SqlConnection(StringConexion))
                        try
                        {

                            Conexion.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE USUARIO Set ESTADO = '" + txtEstado.Text + "' where ID_USUARIO = " + txtIDU.Text + "", Conexion);
                            cmd.ExecuteNonQuery();



                        }
                        catch (Exception es)
                        {

                        }
                }
            }

            else if (txtIDU.Text == "")
            {
                txtIDU.Text = "Revise la informacion.";
            }

            txtIDU.Text = "Actualizacion Realizada";
            txtTipo.Text = "";
            txtEstado.Text = "";

        }

        protected void btnBorrarU_Click(object sender, EventArgs e)
        {
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection Conexion = new SqlConnection(StringConexion))
                try
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("delete from USUARIO where ID_USUARIO = " + txtIDU.Text, Conexion);
                    cmd.ExecuteNonQuery();
                    txtIDU.Text = "Borrado con exito";
                    txtCodigo.Text = "";
                    txtTipo.Text = "";

                }
                catch (Exception es)
                {

                }
        }



        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.AppendHeader("Cache-Control", "no-store");
            Response.AppendHeader("Pragma", "no-cache");
            Response.CacheControl = "no-cache"; Response.Expires = -1;
            Response.Redirect("default.aspx");
        }

        protected void btnBuscar3_Click(object sender, EventArgs e)
        {
            OD();
            txtfinal.Text = "";
            txtinicio.Text = "";
        }

        protected void OD()
        {
            int[] barras = new int[3];
            string[] nombs = new string[3];



            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection Conexion = new SqlConnection(StringConexion))
                try
                {
                    int cont = 0;
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("select sum(MONTO) as MontoFinal , FECHA as Fecha FROM MOVIMIENTO_R where FECHA > '" + txtinicio.Text +
                        "' and FECHA < '" + txtfinal.Text + "' GROUP BY FECHA", Conexion);
                    SqlDataReader leer = cmd.ExecuteReader();
                    while (leer.Read())
                    {
                        barras[cont] = leer.GetInt32(0);
                        nombs[cont] = leer.GetDateTime(1).ToShortDateString();
                        cont++;
                    }

                    leer.Close();
                    Conexion.Close();
                    Grafica.Series["Serie"].Points.DataBindXY(nombs, barras);
                }
                catch (Exception es)
                {

                }
        }
        protected void OD1()
        {
            int[] barras = new int[10];
            int[] nombs = new int[10];
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection Conexion = new SqlConnection(StringConexion))
                try
                {
                    int cont = 0;
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("select ID_PRODUCTO, COUNT (ID_PRODUCTO) AS TOTALPRODUCTOS FROM MOVIMIENTO_CV GROUP BY ID_PRODUCTO HAVING COUNT (ID_PRODUCTO) > 0", Conexion);
                    SqlDataReader leer = cmd.ExecuteReader();
                    while (leer.Read())
                    {
                        barras[cont] = leer.GetInt32(1);
                        nombs[cont] = leer.GetInt32(0);
                        cont++;
                    }

                    leer.Close();
                    Conexion.Close();
                    Grafica1.Series["Serie1"].Points.DataBindXY(nombs, barras);
                }
                catch (Exception es)
                {

                }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            DateTime a1 = Calendar1.SelectedDate;

            txtinicio.Text = a1.ToString("yyyy-MM-dd");

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            DateTime a2 = Calendar2.SelectedDate;

            txtfinal.Text = a2.ToString("yyyy-MM-dd");

        }
    }



}
