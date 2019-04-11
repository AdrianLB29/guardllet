<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Guardllet_Desarrollo._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

<link rel="stylesheet" type="text/css" href="Bootstrap/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="guardllet.css"/>

    <title>GUARDLLET</title>  

</head>
<body>
<form id="Form1" runat="server">
<asp:Button ID="BtnIngresar" runat="server" Text="Entrar" OnClick="BtnIngresar_Click" CssClass="btn-Ingresar"/>
<asp:Button ID="BtnRegitrarse" runat="server" Text="Registrarte" OnClick="BtnRegitrarse_Click" CssClass="btn-Registro"/>
</form>         
</body>
</html>

<script src="http://code.jquery.com/jquery-latest.js"></script>
<script type="text/javascript" src="Bootstrap/js/jquery.js"></script>
<script type="text/javascript" src="Bootstrap/js/bootstrap.min.js"></script>
