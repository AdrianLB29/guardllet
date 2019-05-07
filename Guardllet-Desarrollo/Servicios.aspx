<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="Guardllet_Desarrollo.Servicios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

    <link rel="stylesheet" type="text/css" href="Static/Swiper/swiper.min.css">
    <link rel="stylesheet" type="text/css" href="Static/Bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="Static/Css/Servicios.css" />
    <link rel="stylesheet" type="text/css" href="Static/Css/iconos.css" />

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
                <div class="imagen-ets">

                </div>
                <div class="descripcion">
                    <p>!Pago de examen a titulo de suficiencia!
                    <br />
                        <small>Precio: 10$</small>
                    </p>
                    <button class="Boton-Detalles" onclick="ets()" type="button"><span class="icon-file-text"></span>&nbsp; Comprar</button>
                </div>
            </div>
        </div>
        <div class="swiper-slide">
            <div class="servicio">
                <div class="imagen-credencial">

                </div>
                <div class="descripcion">
                    <p>!Paga la reposicion de tu credencial!
                    <br />
                        <small>Precio: 58$</small>
                    </p>
                    <button class="Boton-Detalles" onclick="credencial()" type="button"><span class="icon-file-text"></span>&nbsp; Comprar</button>
                </div>
            </div>
        </div>
        <div class="swiper-slide">
            <div class="servicio">
                <div class="imagen-deuda">

                </div>
                <div class="descripcion">
                    <p>!Paga tu deuda en biblioteca!
                    <br />
                        <small>Precio: 68$</small>
                    </p>
                    <button class="Boton-Detalles" onclick="deuda()" type="button"><span class="icon-file-text"></span>&nbsp; Comprar</button>
                </div>
            </div>
        </div>
        <div class="swiper-slide">
            <div class="servicio">
                <div class="imagen-pape">

                </div>
                <div class="descripcion">
                    <p>!Paga tus Articulos de Papeleria!
                    <br />
                        <small>Precios desde 1$</small>
                    </p>
                    <button class="Boton-Detalles" onclick="copias()" type="button"><span class="icon-file-text"></span>&nbsp; Comprar</button>
                </div>
            </div>
        </div>
      </div>
      <div class="swiper-pagination"></div>
   </div>
   <div class="mas-informacion" id="informacion">
       <div class="informacion" id="ets">
           <div class="titulo-producto">
               <p>Examen a titulo de suficiencia</p>
           </div>
           <div class="elementos">
               <div class="categoria">
                   <div class="letras">
                       <p>Categoria</p>
                   </div>
                   <div class="numeros">
                       <p>Tramites escolares</p>
                   </div>
               </div>
               <div class="precio">
                   <div class="letras">
                       <p>Precio</p>
                   </div>
                   <div class="numeros">
                       <p>10</p>
                   </div>
               </div>
               <div class="comision">
                   <div class="letras">
                       <p>Comision</p>
                   </div>
                   <div class="numeros">
                       <p>0</p>
                   </div>
               </div>
               <div class="total">
                   <div class="letras">
                       <p>Total</p>
                   </div>
                   <div class="numeros">
                       <p>10</p>
                   </div>
               </div>
           </div>
           <div class="pagar">
              <center><button type="submit" id="BotonPagar" runat="server" onserverclick="BotonPagar_Click"><span class="icon-credit-card"></span>&nbsp; Pagar</button></center> 
           </div>
       </div>
       <div class="informacion-dos" id="credencial">
           <div class="titulo-producto">
               <p>Reposicion de credencial</p>
           </div>
           <div class="elementos">
               <div class="categoria">
                   <div class="letras">
                       <p>Categoria</p>
                   </div>
                   <div class="numeros">
                       <p>Tramites escolares</p>
                   </div>
               </div>
               <div class="precio">
                   <div class="letras">
                       <p>Precio</p>
                   </div>
                   <div class="numeros">
                       <p>58</p>
                   </div>
               </div>
               <div class="comision">
                   <div class="letras">
                       <p>Comision</p>
                   </div>
                   <div class="numeros">
                       <p>0</p>
                   </div>
               </div>
               <div class="total">
                   <div class="letras">
                       <p>Total</p>
                   </div>
                   <div class="numeros">
                       <p>58</p>
                   </div>
               </div>
           </div>
           <div class="pagar">
              <center><button type="submit" id="BotonPagardos" runat="server" onserverclick="BotonPagardos_Click"><span class="icon-credit-card"></span>&nbsp; Pagar</button></center> 
           </div>
       </div>
       <div class="informacion-tres" id="biblioteca">
           <div class="titulo-producto">
               <p>Deuda en biblioteca</p>
           </div>
           <div class="elementos">
               <div class="categoria">
                   <div class="letras">
                       <p>Categoria</p>
                   </div>
                   <div class="numeros">
                       <p>Tramites escolares</p>
                   </div>
               </div>
               <div class="precio">
                   <div class="letras">
                       <p>Precio</p>
                   </div>
                   <div class="numeros">
                       <p>68</p>
                   </div>
               </div>
               <div class="comision">
                   <div class="letras">
                       <p>Comision</p>
                   </div>
                   <div class="numeros">
                       <p>0</p>
                   </div>
               </div>
               <div class="total">
                   <div class="letras">
                       <p>Total</p>
                   </div>
                   <div class="numeros">
                       <p>68</p>
                   </div>
               </div>
           </div>
           <div class="pagar">
              <center><button type="submit" id="BotonPagartres" runat="server" onserverclick="BotonPagartres_Click"><span class="icon-credit-card"></span>&nbsp; Pagar</button></center> 
           </div>
       </div>
       <div class="informacion-cuatro" id="copias">
           <div class="titulo-producto">
               <p>Papeleria</p>
           </div>
           <div class="elementos">
               <div class="categoria">
                   <div class="letras">
                       <p>Categoria</p>
                   </div>
                   <div class="numeros">
                       <p>Utiles escolares</p>
                   </div>
               </div>
               <div class="precio">
                   <div class="letras">
                       <p>Precio</p>
                   </div>
                   <div class="numeros">
                       <p>No aplica</p>
                   </div>
               </div>
               <div class="comision">
                   <div class="letras">
                       <p>Comision</p>
                   </div>
                   <div class="numeros">
                       <p>No aplica</p>
                   </div>
               </div>
               <div class="total">
                   <div class="letras">
                       <p>Total</p>
                   </div>
                   <div class="numeros">
                       <p>No aplica</p>
                   </div>
               </div>
           </div>
           <div class="pagar">
              <center><button type="submit" id="BotonPagarcuatro" runat="server" onserverclick="BotonPagarcuatro_Click"><span class="icon-credit-card"></span>&nbsp; Pagar</button></center> 
           </div>
       </div>
   </div>
</main>
    </form>

    <footer>
        <div class="derechos">
            <p>© Derechos reservados a Guardllet S.A de CV.</p>
        </div>
        <div class="sociales">
            <button type="button" id="SocialesFacebook"><span class="icon-facebook"></span></button>
            <button type="button" id="SocialesTwitter"><span class="icon-twitter"></span></button>
            <button type="button" id="SocialesInstagram"><span class="icon-instagram"></span></button>
        </div>
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

<script type="text/javascript">

    function ets() {
        document.getElementById('ets').style.display = 'block';
        document.getElementById('credencial').style.display = 'none';
        document.getElementById('biblioteca').style.display = 'none';
        document.getElementById('copias').style.display = 'none';
        location.href = "#informacion";
    }

    function credencial() {
        document.getElementById('ets').style.display = 'none';
        document.getElementById('credencial').style.display = 'block';
        document.getElementById('biblioteca').style.display = 'none';
        document.getElementById('copias').style.display = 'none';
        location.href = "#informacion";
    }

    function deuda() {
        document.getElementById('ets').style.display = 'none';
        document.getElementById('credencial').style.display = 'none';
        document.getElementById('biblioteca').style.display = 'block';
        document.getElementById('copias').style.display = 'none';
        location.href = "#informacion";
    }

    function copias() {
        document.getElementById('ets').style.display = 'none';
        document.getElementById('credencial').style.display = 'none';
        document.getElementById('biblioteca').style.display = 'none';
        document.getElementById('copias').style.display = 'block';
        location.href = "#informacion";
    }

</script>
