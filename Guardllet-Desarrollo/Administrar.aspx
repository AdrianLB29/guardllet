<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="Guardllet_Desarrollo.Frontend.Administrators.Administrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LUsuario" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnProducto" runat="server" Text="Producto" OnClick="btnProducto_Click" /><asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" OnClick="btnUsuarios_Click" /><asp:Button ID="btnInformacion" runat="server" Text="Informacion" />
    </div>
        <div>
            <asp:Label ID="lId" runat="server" Text="ID:" Visible="False"></asp:Label><asp:TextBox ID="txtID" runat="server"  Visible="False"></asp:TextBox>
            <br />
            <asp:Label ID="lNombre" runat="server" Text="Nombre:" Visible="False"></asp:Label><asp:TextBox ID="txtNombre" runat="server" Visible="False"></asp:TextBox>
            <br />
            <asp:Label ID="lCodigo" runat="server" Text="Codigo" Visible="False"></asp:Label><asp:TextBox ID="txtCodigo" runat="server" Visible="False"></asp:TextBox>
            <br />
            <asp:Label ID="lPrecio" runat="server" Text="Precio:" Visible="False"></asp:Label><asp:TextBox ID="txtPrecio" runat="server" Visible="False"></asp:TextBox>
            <br />
            <asp:Image ID="Image1" runat="server" Visible="False" /><asp:FileUpload ID="FileUpload1" runat="server" Visible="false" />
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

    </form>
</body>
</html>
