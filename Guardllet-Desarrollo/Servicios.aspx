<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="Guardllet_Desarrollo.Servicios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

<link rel="stylesheet" type="text/css" href="Static/Swiper/swiper.min.css">
<link rel="stylesheet" type="text/css" href="Static/Bootstrap/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="Static/Css/Servicios.css"/>
<link rel="stylesheet" type="text/css" href="Static/Css/iconos.css"/>

    <title>Servicios</title>

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

<main>

   <div class="swiper-container">

      <div class="swiper-wrapper">

        <div class="swiper-slide">
            <div class="servicio">
                <div class="imagen">

                </div>
                <div class="descripcion">
                    <p>!Pago de examen a titulo de suficiencia!
                    <br />
                        <small>Precio: 10$</small>
                    </p>
                    <button class="Boton-Detalles"><span class="icon-file-text"></span>&nbsp; Detalles</button>
                </div>
            </div>
        </div>
        <div class="swiper-slide">
            <div class="servicio">
                <div class="imagen">

                </div>
                <div class="descripcion">
                    <p>!Paga la reposicion de tu credencial!
                    <br />
                        <small>Precio: 58$</small>
                    </p>
                    <button class="Boton-Detalles"><span class="icon-file-text"></span>&nbsp; Detalles</button>
                </div>
            </div>
        </div>
        <div class="swiper-slide">
            <div class="servicio">
                <div class="imagen">

                </div>
                <div class="descripcion">
                    <p>!Paga tus Articulos de Papeleria!
                    <br />
                        <small>Precios desde 1$</small>
                    </p>
                    <button class="Boton-Detalles"><span class="icon-file-text"></span>&nbsp; Detalles</button>
                </div>
            </div>
        </div>
      </div>
      <div class="swiper-pagination"></div>
   </div>
   <div class="mas-informacion">

   </div>
</main>
</form>

<footer>

</footer>

</body>
</html>

<script src="http://code.jquery.com/jquery-latest.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/jquery.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/bootstrap.min.js"></script>
<script type="text/javascript" src="Static/Swiper/swiper.min.js"></script>

<script>

    var swiper = new Swiper('.swiper-container', {
        effect: 'coverflow',
        grabCursor: true,
        centeredSlides: true,
        slidesPerView: 'auto',
        coverflowEffect: {
            rotate: 50,
            stretch: 1,
            depth: 100,
            modifier: 1,
            slideShadows: true,
        },
        pagination: {
            el: '.swiper-pagination',
        },
    });

</script>