﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Guardllet_Desarrollo.carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

<link rel="stylesheet" type="text/css" href="Static/Bootstrap/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="Static/Css/Carrito.css">
<link rel="stylesheet" type="text/css" href="Static/Css/iconos.css">

    <title></title>

</head>
<body>

<header>

</header>

    <div class="container">
        <asp:Label ID="LbExamen" runat="server" Text="Paga tu examen a titulo de suficiencia" Visible="False"></asp:Label>
        <asp:Label ID="LbCredencial" runat="server" Text="Paga la reposicion de tu credencial" Visible="False"></asp:Label>
        <asp:Label ID="LbDeuda" runat="server" Text="Paga tu deuda en biblioteca" Visible="False"></asp:Label>
        <asp:Label ID="LbCopias" runat="server" Text="Paga tus copias" Visible="False"></asp:Label>
    </div>

    <div class="container">
        <form id="form1" runat="server" class="form-horizontal">
            <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12">
                <asp:TextBox ID="TxtMateria" runat="server" Visible="False" CssClass="form-control" required placeholder="Materia"></asp:TextBox>
                <asp:TextBox ID="TxtMonto" runat="server" Visible="False"  CssClass="form-control" required type="number" max="500" placeholder="Total de la deuda"></asp:TextBox>
                <asp:TextBox ID="TxtCopias" runat="server" Visible="False" CssClass="form-control" required type="number" max="500" placeholder="Total a pagar"></asp:TextBox>
            </div>
            </div>
            <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12">
                <asp:Button ID="BtnPagarEts" runat="server" OnClick="BtnPagarEts_Click" class="Boton-Ets" Text="Pagar" Visible="False" />
                <asp:Button ID="BtnPagarCrd" runat="server" OnClick="BtnPagarCrd_Click" class="Boton-Crd" Text="Pagar" Visible="False"/>
                <asp:Button ID="BtnPagarDeu" runat="server" OnClick="BtnPagarDeu_Click" class="Boton-Deu" Text="Pagar" Visible="False"/>
                <asp:Button ID="BtnPagarCop" runat="server" OnClick="BtnPagarCop_Click" class="Boton-Cop" Text="Pagar" Visible="False"/>
            </div>
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