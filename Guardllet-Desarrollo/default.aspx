<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Guardllet_Desarrollo._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Guardllet</h1>
        <asp:Button ID="BtnEntrar" runat="server" Text="Iniciar Sesion" OnClick="BtnEntrar_Click" />
        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrate" OnClick="BtnRegistrar_Click" />
    </div>
    </form>
</body>
</html>
