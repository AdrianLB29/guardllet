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
        <asp:Button ID="btnProducto" runat="server" Text="Producto" OnClick="btnProducto_Click" /><asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" /><asp:Button ID="btnInformacion" runat="server" Text="Informacion" />
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
            <asp:Image ID="Image1" runat="server" Visible="False" />
        </div>

    </form>
</body>
</html>
