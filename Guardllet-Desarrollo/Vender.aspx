<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="Guardllet_Desarrollo.Frontend.Sellers.Vender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div>
        <asp:Label ID="Usuario" runat="server" Text=""></asp:Label>
    </div>
                <div>
            <asp:Label ID="lSaldo" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="tbNoMenedero" runat="server" ></asp:TextBox><asp:TextBox ID="tbsaldo" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnAgregar" runat="server" Text="Recargar" OnClick="btnAgregar_Click" /><asp:Button ID="btnCobrar" runat="server" Text="Button" />
        </div>
        <asp:Label ID="lFinal" runat="server" Text="Label" Visible="False"></asp:Label>
    </form>
</body>
</html>
