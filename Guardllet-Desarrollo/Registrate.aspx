<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrate.aspx.cs" Inherits="Guardllet_Desarrollo.Frontend.Accounts.Registrate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

<link rel="stylesheet" type="text/css" href="Static/Bootstrap/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="Static/Css/Registrate.css" />

    <title></title>

</head>
<body>

<header>

</header>

<div class="Contenedor-titulo">
    <div class="col-xs-12 col-sm-12 col-md-12">
        <h3 class="titulo">CREA TU CUENTA!</h3>
    </div>
</div>

<div class="container margen">
    <form id="form1" runat="server" class="form-horizontal">
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12">
                <asp:TextBox ID="TxtCorreo" runat="server" CssClass="form-control" placeholder="Correo" required TextMode="Email"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12">
                <asp:TextBox ID="TxtContraseña" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password" required></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12">
                <asp:TextBox ID="TxtContraseñaC" runat="server" CssClass="form-control" placeholder="Confrimar" TextMode="Password" required></asp:TextBox>
            </div>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 Lb-Error">
            <asp:Label ID="LbError" runat="server" Text=" " Visible="False"></asp:Label>
        </div>
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12">
                <asp:Button ID="BtnRegistrar" runat="server" Text="Continuar" OnClick="BtnRegistrar_Click" CssClass="btn-registrate"/>
            </div>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 a-s">
            <a href="Entra.aspx">Iniciar Sesion &nbsp;</a> | <a href="default.aspx">&nbsp; Inicio</a>
        </div>
    </form>
</div>

<footer>
   
</footer>

</body>
</html>

<script src="http://code.jquery.com/jquery-latest.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/jquery.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/bootstrap.min.js"></script>
