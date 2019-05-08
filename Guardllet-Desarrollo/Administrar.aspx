<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="Guardllet_Desarrollo.Frontend.Administrators.Administrar" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %> 


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="Static/Css/Administrar.css"/>
    <link rel="stylesheet" type="text/css" href="Static/Css/iconos.css" />

    <title>Administrador</title>

</head>
<body>
    <form id="form1" runat="server">
        
        <main>
            <header>
                <asp:Label ID="LUsuario" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnProducto" runat="server" Text="Producto" OnClick="btnProducto_Click" />
                <asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" OnClick="btnUsuarios_Click" />
                <asp:Button ID="btnInformacion" runat="server" Text="Informacion" OnClick="btnInformacion_Click" />
                <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" />
            </header>
            <div class="contenido">
                <div class="formulario">
                    <div id="producto">
                        <div class="definicion">
                            <asp:Label ID="lId" runat="server" Text="ID:" Visible="False"></asp:Label>
                        </div>
                        <div class="texto">
                            <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="definicion">
                            <asp:Label ID="lNombre" runat="server" Text="Nombre:" Visible="False"></asp:Label>
                        </div>
                        <div class="texto">
                            <asp:TextBox ID="txtNombre" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="definicion">
                            <asp:Label ID="lCodigo" runat="server" Text="Codigo:" Visible="False"></asp:Label>
                        </div>
                        <div class="texto">
                            <asp:TextBox ID="txtCodigo" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="definicion">
                            <asp:Label ID="lPrecio" runat="server" Text="Precio:" Visible="False"></asp:Label>
                        </div>
                        <div class="texto">
                            <asp:TextBox ID="txtPrecio" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="boton-bu">
                            <asp:Button ID="btnBuscar" runat="server" Text ="Buscar" Visible="false" />
                        </div>
                        <div class="boton-a">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Visible="False" OnClick="btnAgregar_Click"/>
                        </div>
                        <div class="boton-ac">
                            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" Visible="False" OnClick="btnActualizar_Click"/>
                        </div>
                        <div class="boton-b">
                            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" Visible="False"/>
                        </div>
                        
                    </div>
                    <div id="usuario">
                        <div class="definicion">
                           <asp:Label ID="lIDU" runat="server" Text ="ID:" Visible="false"></asp:Label> 
                        </div>
                        <div class="texto">
                           <asp:TextBox ID="txtIDU" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="definicion">
                           <asp:Label ID="lTipo" runat="server" Text="Tipo de Usuario:" Visible="false"></asp:Label>
                        </div>
                        <div class="texto">
                           <asp:TextBox ID="txtTipo" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="definicion">
                           <asp:Label ID="lEstado" runat="server" Text="Estado:" Visible="false"></asp:Label>
                        </div>
                        <div class="texto">
                           <asp:TextBox ID="txtEstado" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="boton-bus">
                            <asp:Button ID="btnBuscarU" runat="server" Text="Buscar" Visible="false" OnClick="btnBuscarU_Click" />
                        </div>
                        <div class="boton-act">
                            <asp:Button ID="btnActualizarU" runat="server" Text="Actualizar" Visible="false" OnClick="btnActualizarU_Click" />
                        </div>
                        <div class="boton-borr">
                            <asp:Button ID="btnBorrarU" runat="server" Text="Borrar" Visible="false" OnClick="btnBorrarU_Click" />
                        </div>
                    </div>
                    <div id="informacion">

                        <asp:TextBox ID="txtinicio" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtfinal" runat="server" Visible="false"></asp:TextBox>
                        <div class="menu-grf">
                            <div class="boton-recargas">
                                <asp:Button ID="btnREcargas" runat="server" Text="Recarga" Visible ="false" OnClick="btnREcargas_Click" />
                            </div>
                            <div class="boton-productos">
                                <asp:Button ID="btnProductos" runat="server" Text="Productos" Visible ="false" OnClick="btnProductos_Click" />
                            </div>
                        </div>
                        
                    </div>
                </div>
                <div class="resultados">
                    <div class="contenedor-resultados">
                        <div class="contenedor-calendarios">
                            <div class="calendario-uno">
                                <asp:Label ID="lFechaI" runat="server" Text="Fecha de inicio" Visible="false"></asp:Label>
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" visible="false" Height="100px" Width="250px"></asp:Calendar>
                            </div>
                            <div class="calendario-dos">
                                <asp:Label ID="lFechaFinal" runat="server" Text="Fecha Final" Visible="false"></asp:Label>
                                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible="false" Height="100px" Width="250px"></asp:Calendar>
                            </div>
                            <div class="boton-buscar">
                                <asp:Button ID="btnBuscar3" runat="server" Text="Buscar" Visible="false" OnClick="btnBuscar3_Click"/>
                            </div>
                        </div>
                        <asp:Chart ID="Grafica" runat="server" Visible="true">
                        <Series><asp:Series Name="Serie"></asp:Series></Series>
                        <ChartAreas><asp:ChartArea Name="ChartArea"></asp:ChartArea></ChartAreas>
                        </asp:Chart>

                        <asp:Chart ID="Grafica1" runat="server" Visible="false">
                        <Series><asp:Series Name="Serie1"></asp:Series></Series>
                        <ChartAreas><asp:ChartArea Name="ChartArea"></asp:ChartArea></ChartAreas>
                        </asp:Chart>

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
