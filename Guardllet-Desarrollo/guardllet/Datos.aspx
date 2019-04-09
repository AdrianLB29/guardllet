<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="Guardllet_Desarrollo.Frontend.Accounts.Completar_Datos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

<link rel="stylesheet" type="text/css" href="Bootstrap/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="Css/Datos/Datos.css">

    
    <title></title>

</head>
<body>
<header>

</header>
<div class="Contenedor-titulo">
    <div class="col-xs-12 col-sm-12 col-md-12">
        <h3 class="titulo">COMPLETA TUS DATOS</h3>
    </div>
</div>
<div class="container margen">
    <form id="form1" runat="server" class="form-horizontal">
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <asp:TextBox ID="TxtNombre" runat="server" placeholder="Nombre(s) *" CssClass="form-control" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <asp:TextBox ID="TxtApellidoP" runat="server" placeholder="Apellido Paterno *" CssClass="form-control" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <asp:TextBox ID="TxtApellidoM" runat="server" placeholder="Apellido Materno *" CssClass="form-control" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <asp:TextBox ID="TxtCelular" runat="server" placeholder="Celular *" CssClass="form-control" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <asp:TextBox ID="TxtEdad" runat="server" placeholder="Edad *" CssClass="form-control" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <asp:DropDownList ID="ListaEscuelas" runat="server" CssClass="form-control" required></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <asp:TextBox ID="TxtBoleta" runat="server" placeholder="Boleta *" CssClass="form-control" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <asp:TextBox ID="TxtGrupo" runat="server" placeholder="Grupo *" CssClass="form-control" required></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12">
                    <asp:Button ID="BtnConfirmar" runat="server" Text="Continuar" OnClick="BtnConfirmar_Click" CssClass="btn-completar"/>
                </div>
            </div>
    </form>
</div>
</body>
</html>

<script src="http://code.jquery.com/jquery-latest.js"></script>
<script type="text/javascript" src="Bootstrap/js/jquery.js"></script>
<script type="text/javascript" src="Bootstrap/js/bootstrap.min.js"></script>