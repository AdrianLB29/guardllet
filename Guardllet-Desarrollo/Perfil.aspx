<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Guardllet_Desarrollo.Perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

    <link rel="stylesheet" type="text/css" href="Static/Bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="Static/Css/Perfil.css">
    <link rel="stylesheet" type="text/css" href="Static/Css/iconos.css">

    <title>Perfil</title>

</head>

<body>

    <form id="form1" runat="server">

        <header>
            <div class="menu">
                <button id="BotonHome" runat="server" type="submit" onserverclick="BotonHome_Click" class="btnMenuH"><span class="icon-home"></span></button>
                <button id="BotonServicios" runat="server" type="submit" onserverclick="BotonServicios_Click" class="btnMenuSV"><span class="icon-cart"></span></button>
                <button id="BotonPerfil" runat="server" type="submit" onserverclick="BotonPerfil_Click" class="btnMenuP"><span class="icon-user"></span></button>
                <button id="BotonSesion" runat="server" type="submit" onserverclick="BotonSesion_Click" class="BtnMenuS"><span class="icon-exit"></span></button>
            </div>
        </header>

        <div class="contenedor-in">
            <div class="contenedor-i">
                <div class="imagen">
                </div>
            </div>
            <div class="contenedor-n">
                <div class="nombre">
                    <p id="nombre">
                        <asp:Label runat="server" Text="" ID="LbNombre"></asp:Label>
                    </p>
                </div>
                <div class="escuela">
                    <p id="escuela">
                        <asp:Label runat="server" Text=" " ID="LbEscuela"></asp:Label>
                    </p>
                </div>
                <div class="boleta">
                    <p id="boleta">
                        <asp:Label runat="server" Text=" " ID="LbBoleta"></asp:Label>
                    </p>
                </div>
            </div>
        </div>

        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 margen">
            <div class="contenedor-tickets">
                <div class="titulo-tickets">
                    <p id="titulo">Comprobantes de compra</p>
                </div>
                <div id="ContenedorTickets" runat="server">
                </div>
            </div>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 margen">
            <div class="contenedor-datos">
                <div class="datos-titulo">
                    <p>Datos Personales</p>
                </div>
                <div class="datos-nombre">
                    <div class="atributo">
                        <p class="p-a">Nombre:</p>
                    </div>
                    <div class="valor">
                        <asp:Label ID="LbDNombre" runat="server" Text=" "></asp:Label>
                    </div>
                </div>
                <div class="datos-apellido-p">
                    <div class="atributo">
                        <p class="p-a">Apellido Paterno:</p>
                    </div>
                    <div class="valor">
                        <asp:Label ID="LbDApellidoP" runat="server" Text=" "></asp:Label>
                    </div>
                </div>
                <div class="datos-apellido-m">
                    <div class="atributo">
                        <p class="p-a">Apellido Materno:</p>
                    </div>
                    <div class="valor">
                        <asp:Label ID="LbDApellidoM" runat="server" Text=" "></asp:Label>
                    </div>
                </div>
                <div class="datos-celular">
                    <div class="atributo">
                        <p class="p-a">Celular:</p>
                    </div>
                    <div class="valor">
                        <asp:Label ID="LbDCelular" runat="server" Text=" "></asp:Label>
                    </div>
                </div>
                <div class="datos-edad">
                    <div class="atributo">
                        <p class="p-a">Edad:</p>
                    </div>
                    <div class="valor">
                        <asp:Label ID="LbDEdad" runat="server" Text=" "></asp:Label>
                    </div>
                </div>
                <div class="datos-boton">
                    <button type="button" id="BotonActualizar">Editar datos</button>
                </div>
            </div>
        </div>
    </form>

    <footer>
    </footer>

</body>

</html>

<script src="http://code.jquery.com/jquery-latest.js"></script>
<script type="text/javascript" src="Static/Js/jspdf.debug.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/jquery.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/bootstrap.min.js"></script>

<script>
     function DescargarPDF(ContenidoID, nombre) {
         var pdf = new jsPDF('p', 'pt', 'letter');
         html = $('#' + ContenidoID).html();
         specialElementHandlers = {};
         margins = { top: 10, bottom: 20, left: 20, width: 522 };
         pdf.fromHTML(html, margins.left, margins.top, { 'width': margins.width }, function (dispose) { pdf.save(nombre + '.pdf'); }, margins);
     }
</script>