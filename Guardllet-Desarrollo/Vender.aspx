<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="Guardllet_Desarrollo.Frontend.Sellers.Vender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
<link rel="stylesheet" type="text/css" href="Static/Css/Vender.css" />

    <title>Recargar</title>
  
</head>
<body>  
    <form id="form1" runat="server">
        <main>
            <header>
                <div class="boton-cerrar">
                    <asp:Label ID="Usuario" runat="server" Text=""></asp:Label>
                     <asp:Button ID="btnCerar" runat="server" Text="Cerrar Sesión" OnClick="btnCerar_Click" class="BtnCerrar" />
                </div>
            </header>
            <div class="contenido">
                <div class="numeros">
                    <div class="saldo">
                        <p id="TxtSaldo">Saldo Actual</p>
                        <asp:Label ID="lSaldo" runat="server" Text=""></asp:Label>$
                        <asp:Label ID="lFinal" runat="server" Text="Label" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="texto">
                    <div class="Columna1">
                        <asp:TextBox ID="tbNoMenedero" runat="server" placeholder="Numero de Monedero"></asp:TextBox>
                        <p id="TxtAyuda">Numero de Monedero</p>
                    </div>
                    <div class="Columna2">
                        <asp:TextBox ID="tbsaldo" runat="server" placeholder="Dinero" type="number" min="1" max="1000"></asp:TextBox>
                        <p id="TxtAyuda">Dinero</p>
                    </div>
                </div>
                <div class="botones">
                    <div class="Columna1">
                         <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="BtnBuscar"/>
                    </div>
                    <div class="Columna2">
                        <asp:Button ID="btnAgregar" runat="server" Text="Recargar" OnClick="btnAgregar_Click" class="BtnAgregar"/>
                    </div>
                </div>
            </div>
            <footer>
                 <div class="derechos">
                    <p>© Derechos reservados a Guardllet S.A de CV.</p>
                </div>
            </footer>
        </main>  
    </form>
</body>
</html>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>