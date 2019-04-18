<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Guardllet_Desarrollo._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

<link rel="stylesheet" type="text/css" href="Static/Bootstrap/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="Static/Css/default.css">
<link rel="stylesheet" type="text/css" href="Static/Css/iconos.css">

    <title></title>
</head>
<body>
    <header>
        <button id="botonInicio" type="button" onclick="window.location='#contenedor-inicio'"><span class="icon-home3"></span>&nbsp; Inicio</button>
         <button id="botonContacto" type="button" onclick="window.location='#contenedor-contacto'" ><span class="icon-mail2"></span>&nbsp; Contacto</button>
        <button id="botonAcerca" type="button" onclick="window.location='#contenedor-acerca'"><span class="icon-notification"></span>&nbsp; Acerca de</button>
    </header> 
<main>
    <div id="contenedor-inicio">
       <form id="form1" runat="server">
           <asp:Button ID="BtnEntrar" runat="server" Text="Iniciar Sesion" OnClick="BtnEntrar_Click" />
           <asp:Button ID="BtnRegistrar" runat="server" Text="Registrate" OnClick="BtnRegistrar_Click" />
       </form>
    </div>
    
    <div id="contenedor-contacto" class="efecto">
        <a href="#contenedor-inicio"></a>
    </div>

    <div id="contenedor-acerca" class="efecto">

    </div>
</main>
</body>
</html>


<script src="http://code.jquery.com/jquery-latest.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/jquery.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/bootstrap.min.js"></script>