<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Guardllet_Desarrollo._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    
<link rel="stylesheet" type="text/css" href="Static/Swiper/swiper.min.css">
<link rel="stylesheet" type="text/css" href="Static/Bootstrap/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="Static/Css/default.css">
<link rel="stylesheet" type="text/css" href="Static/Css/iconos.css">

    <title>Guardllet</title>
</head>
<body>

    <header>
      <form id="form1" runat="server">
         <asp:Button ID="BtnEntrar" runat="server" Text="Iniciar Sesion" OnClick="BtnEntrar_Click" />
         <asp:Button ID="BtnRegistrar" runat="server" Text="Registrate" OnClick="BtnRegistrar_Click" />
     </form>
    </header> 

<main>
   
  <div class="swiper-container">
        <div class="swiper-wrapper">
            <div id="inicio" class="swiper-slide">
                
            </div>
            <div id="contacto" class="swiper-slide">

            </div>
            <div id="acerca"  class="swiper-slide">

            </div>
        </div>
        <div class="swiper-pagination"></div>
   </div>
</main>
</body>
</html>

<script src="http://code.jquery.com/jquery-latest.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/jquery.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/bootstrap.min.js"></script>
<script type="text/javascript" src="Static/Swiper/swiper.min.js"></script>

<script>

    var swiper = new Swiper('.swiper-container', {
        direction: 'vertical',
        slidesPerView: 1,
        spaceBetween: 30,
        mousewheel: true,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
    });

</script>