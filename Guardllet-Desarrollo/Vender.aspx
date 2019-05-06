<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="Guardllet_Desarrollo.Frontend.Sellers.Vender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
  <link rel="stylesheet" type="text/css" href="Vender.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</head>
<body>  
    <form id="form1" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4">
        <asp:Label ID="Usuario" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
            <asp:Label ID="lSaldo" runat="server" Text=""></asp:Label>
              <div id="contenido">
                         <asp:TextBox ID="tbNoMenedero" runat="server"  ></asp:TextBox>
                  <br />
                         <asp:TextBox ID="tbsaldo" runat="server"></asp:TextBox>
                  <br />
                         <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-info"/>
                         <asp:Button ID="btnAgregar" runat="server" Text="Recargar" OnClick="btnAgregar_Click" class="btn btn-info" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                  <div id="CerrarSesion">
                      <asp:Button ID="btnCerar" runat="server" Text="Cerrar Sesión" OnClick="btnCerar_Click" class="btn btn-info" />
                  </div>
                   
             </div>
        <asp:Label ID="lFinal" runat="server" Text="Label" Visible="False"></asp:Label>
                   </div>
             </div>
    </form>
</body>
</html>
