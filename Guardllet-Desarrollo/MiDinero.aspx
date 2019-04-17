<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiDinero.aspx.cs" Inherits="Guardllet_Desarrollo.Frontend.Customers.MiDinero" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">

<link rel="stylesheet" type="text/css" href="Static/Bootstrap/css/bootstrap.min.css">
<link rel="stylesheet" type="text/css" href="Static/Css/MiDinero.css"/>

    <title></title>

</head>
<body>

<header>
    

</header>


<form id="form1" runat="server">

<div class="container">
  <div class="row">
    <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 margen">
        <div class="tarjeta-monedero">
            <div class="tarjeta-wrap">
                <div class="tarjeta">
                    <div class="adelante">
                        
                    </div>
                    <div class="atras">
                        <asp:Image ID="Monedero" runat="server" Height="99px" Width="220px" />
               
                        <asp:Label ID="Lb_Saldo" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 margen">
        <div class="saldo">

        </div>
    </div>
  </div>
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 margen">
            <div class="productos">

            </div>
        </div>
    </div>
</div>
</form>
 
<footer>

</footer>
           
</body>
</html>

<script src="http://code.jquery.com/jquery-latest.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/jquery.js"></script>
<script type="text/javascript" src="Static/Bootstrap/js/bootstrap.min.js"></script>