<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="VerPedido.aspx.cs" Inherits="MRP_Proyecto.VerPedido" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .submenu ul {
        list-style: none;
        padding: 0;
        margin: 0;
    }

    .submenu ul li {
        display: inline;
        margin-right: 1px;
    }

    .submenu ul li a {
        text-decoration: none;
        color: #fff;
        font-weight: bold;
        font-size: 16px;
        padding: 5px 10px;
        border-radius: 0px;
        background-color: #343a40; /* Color de fondo oscuro */
        transition: background-color 0.3s ease;
    }

    .submenu ul li a:hover {
        background-color: #808080; /* Color de fondo más oscuro al hacer hover */
        color: #fff;
    }
</style>

    <h1>Pedidos</h1>
    <div class="submenu">
        <ul>
            <li><asp:HyperLink ID="hlCargarExcel" runat="server" NavigateUrl="Pedidos.aspx">Cargar Pedido</asp:HyperLink></li>
            <li><asp:HyperLink ID="hlVerPedido" runat="server" NavigateUrl="VerPedido.aspx">Ver Pedido</asp:HyperLink></li>
        </ul>
    </div>

   
    <h2>Pedidos Activos</h2>
    <div>
        <label for="txtFiltrarActivo">Filtrar por ID de Pedido:</label>
        <asp:TextBox ID="txtFiltrarActivo" runat="server"></asp:TextBox>
        <asp:Button ID="btnFiltrarActivo" runat="server" Text="Filtrar" OnClick="btnFiltrarActivo_Click" />
    </div>
    <asp:GridView ID="gvPedidosActivos" runat="server"></asp:GridView>

    
    <br />
        <label for="txtIdPedidoFinalizar">ID del Pedido a Finalizar:</label>&nbsp;
        <asp:TextBox ID="txtIdPedidoFinalizar0" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnFinalizarPedido0" runat="server" Text="Finalizar Pedido" OnClick="btnFinalizarPedido_Click" />
    <br />
    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
    <br />

    
    <h2>Pedidos Finalizados</h2>
    <div>
        <label for="txtFiltrarFinalizado">Filtrar por ID de Pedido:</label>
        <asp:TextBox ID="txtFiltrarFinalizado" runat="server"></asp:TextBox>
        <asp:Button ID="btnFiltrarFinalizado" runat="server" Text="Filtrar" OnClick="btnFiltrarFinalizado_Click" />
    </div>
    <asp:GridView ID="gvPedidosFinalizados" runat="server"></asp:GridView>

    
    <div>
        &nbsp;</div>
</asp:Content>