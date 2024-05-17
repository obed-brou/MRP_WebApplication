<%@ Page  Title="Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="MRP_Proyecto.Pedidos" %>

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
        <li><asp:HyperLink ID="hlCargarExcel" runat="server" NavigateUrl="#">Cargar Pedido</asp:HyperLink></li>
        <li><asp:HyperLink ID="hlVerPedido" runat="server" NavigateUrl="VerPedido.aspx">Ver Pedido</asp:HyperLink></li>
        
    </ul>
</div>
    <main aria-labelledby="title">
        <div class="left-section">
	<h2>Cargar Pedidos desde Excel&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h2>

            <div class="form-group">
                &nbsp;</div>

            <div class="row">
                <div class="col-md-6">
                <label for="fuArchivoExcel">Ruta de Archivo de Excel:</label><br />
                <asp:FileUpload ID="fuArchivoExcel" runat="server" CssClass="form-control" />
                <label for="fuArchivoExcel">
                    <asp:Button ID="btnExel" runat="server" BackColor="#0066FF" ForeColor="White" OnClick="btnExel_Click" Text="Importar Excel seleccionado" />
                    </label>
                    <br />
                    <br />
                <label for="tbCliente">Cliente:</label><asp:TextBox ID="tbCliente" runat="server" CssClass="form-control"></asp:TextBox>
                <label for="dtFecha">Fecha:</label><asp:TextBox ID="dtFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    

            
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" BackColor="#0066FF" />
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <div class="col-md-6">
                    <h2>Lista de Productos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h2>
                    <asp:GridView ID="gvProductos" runat="server" CssClass="table">
                       
                    </asp:GridView>

                </div>
            </div>
        </div>
    </main>
</asp:Content>