﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
            Image1.Visible = true;
            btnProducto.Enabled = false;
            btnAgregar.Visible = true;
            btnActualizar.Visible = true;
            btnBorrar.Visible = true;
            btnUsuarios.Enabled = true;
            btnBuscar.Visible = true;
            lPrecio.Visible = true;
            txtPrecio.Visible = true;
            FileUpload1.Visible = true;

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
            Image1.Visible = false;
            btnProducto.Enabled = true;
            btnAgregar.Visible = false;
            btnActualizar.Visible = false;
            btnBorrar.Visible = false;
            btnUsuarios.Enabled = false;
            btnBuscar.Visible = false;
            lPrecio.Visible = false;
            txtPrecio.Visible = false;
            FileUpload1.Visible = false;

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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            { 
            string StringConexion = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (SqlConnection Conexion = new SqlConnection(StringConexion))
                try
                {
                    int s = 0;
                    s = Convert.ToInt16(txtPrecio.Text);
                    Conexion.Open(); 
                    SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCTO (NOMBRE,CODIGO,PRECIO) VALUES ('"+ txtNombre.Text +"'," + "'" +txtCodigo.Text + "',"
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
            else if(txtID.Text != "")
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
                if( txtPrecio.Text != "")
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
            if(txtIDU.Text != "")
            {
                if(txtTipo.Text != "")
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
                if(txtEstado.Text != "")
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

            else if(txtIDU.Text == "")
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
                    SqlCommand cmd = new SqlCommand("delete from USUARIO where ID_USUARIO = " +  txtIDU.Text , Conexion);
                    cmd.ExecuteNonQuery();
                    txtIDU.Text = "Borrado con exito";
                    txtCodigo.Text = "";
                    txtTipo.Text = "";
                    
                }
                catch (Exception es)
                {

                }
        }
    }
}