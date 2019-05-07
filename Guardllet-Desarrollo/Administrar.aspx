<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="Guardllet_Desarrollo.Frontend.Administrators.Administrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
<link rel="stylesheet" type="text/css" href="Static/Css/Administrar.css"/>

    <title>Administrador</title>

</head>
<body>
    <form id="form1" runat="server">
        
        <main>
            <header>
                <asp:Label ID="LUsuario" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnProducto" runat="server" Text="Producto" OnClick="btnProducto_Click" />
                <asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" OnClick="btnUsuarios_Click" />
                <asp:Button ID="btnInformacion" runat="server" Text="Informacion" OnClick="btnInformacion_Click" />
                <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" />
            </header>
            <div class="contenido">
                <div>
                    <asp:Label ID="lId" runat="server" Text="ID:" Visible="False"></asp:Label><asp:TextBox ID="txtID" runat="server"  Visible="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="lNombre" runat="server" Text="Nombre:" Visible="False"></asp:Label><asp:TextBox ID="txtNombre" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="lCodigo" runat="server" Text="Codigo" Visible="False"></asp:Label><asp:TextBox ID="txtCodigo" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="lPrecio" runat="server" Text="Precio:" Visible="False"></asp:Label><asp:TextBox ID="txtPrecio" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Visible="False" OnClick="btnAgregar_Click"/>
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" Visible="False" OnClick="btnActualizar_Click"/>
                    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Visible="False"/>
                    <asp:Button ID="btnBuscar" runat="server" Text ="Buscar" Visible="false" />
                    </div>
                    <div>
                    <asp:Label ID="lIDU" runat="server" Text ="ID:" Visible="false"></asp:Label> <asp:TextBox ID="txtIDU" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="lTipo" runat="server" Text="Tipo de Usuario" Visible="false"></asp:Label> <asp:TextBox ID="txtTipo" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <asp:Label ID="lEstado" runat="server" Text="Estado" Visible="false"></asp:Label> <asp:TextBox ID="txtEstado" runat="server" Visible="false"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnBuscarU" runat="server" Text="Buscar" Visible="false" OnClick="btnBuscarU_Click" />
                    <asp:Button ID="btnActualizarU" runat="server" Text="Actualizar" Visible="false" OnClick="btnActualizarU_Click" />
                    <asp:Button ID="btnBorrarU" runat="server" Text="Borrar" Visible="false" OnClick="btnBorrarU_Click" />
                    </div>
                    <div>
                    <asp:Label ID="lFechaI" runat="server" Text="Fecha de inicio" Visible="false"></asp:Label><asp:TextBox ID="txtFechaI" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lFechaFinal" runat="server" Text="Fecha Final" Visible="false"></asp:Label><asp:TextBox ID="txtFechaF" runat="server" Visible="false"></asp:TextBox>
                    <asp:Button ID="btnBuscar3" runat="server" Text="Buscar" Visible="false" OnClick="btnBuscar3_Click"/>
                    <asp:GridView ID="GridView1" runat="server" Visible="False" ></asp:GridView>
                    </div>
                </div>
            <footer>
                <div class="derechos">
                    <p>© Derechos reservados a Guardllet S.A de CV.</p>
                </div>
            </footer>
        </main>
    </form>
</body>
</html>
