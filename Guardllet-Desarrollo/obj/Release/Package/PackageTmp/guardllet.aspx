<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guardllet.aspx.cs" Inherits="Guardllet_Desarrollo.guardllet" %>

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

<main>

<header>
    <nav id="barra" class="navbar navbar-default nav-prs">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-1">
                    <span class="sr-only">Menu</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a href="#" class="navbar-brand color"> GUARDLLET</a>
            </div>
            <div class="collapse navbar-collapse" id="navbar-1">
                <ul class="nav navbar-nav navbar-right color">
                    <li><a href="#inicio" class="color">Inicio</a></li>
                    <li><a href="#quienes" class="color">¿Quienes somos?</a></li>
                    <li><a href="#contacto" class="color">Contacto</a></li>
                </ul>      
           </div>
        </div>
    </nav>    
</header>

<div id="inicio">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-4">
             <form id="Form1" runat="server">
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12">
                        <asp:Button ID="BtnIngresar" runat="server" Text="Entrar" OnClick="BtnIngresar_Click" CssClass="btn-Ingresar"/>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12">
                        <asp:Button ID="BtnRegitrarse" runat="server" Text="Registrarte" OnClick="BtnRegitrarse_Click" CssClass="btn-Registro"/>
                    </div>
                </div>
            </form>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-8">
       
        </div>
    </div>
</div>

<div id="quienes" class="efecto">

</div>

<div id="contacto" class="efecto">

</div>

</main>
</body>
</html>

<script src="http://code.jquery.com/jquery-latest.js"></script>
<script type="text/javascript" src="Bootstrap/js/jquery.js"></script>
<script type="text/javascript" src="Bootstrap/js/bootstrap.min.js"></script>
