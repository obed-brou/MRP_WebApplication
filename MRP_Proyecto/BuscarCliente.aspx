<%@ Page Title="BuscarCliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarCliente.aspx.cs" Inherits="MRP_Proyecto.BuscarCliente" %>

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

    
    <main aria-labelledby="title">
        <div class="container">
            <h1>Clientes</h1>

            <div class="submenu">
                <ul>
                    <li><asp:HyperLink ID="hlAgregarCliente" runat="server" NavigateUrl="AgregarCliente">Agregar Cliente</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlBuscarCliente" runat="server" NavigateUrl="BuscarCliente.aspx">Buscar Cliente</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlListaPrecios" runat="server" NavigateUrl="ListasDePrecio.aspx">Lista de Precios</asp:HyperLink></li>
                
                </ul>
            </div>

                <h2>Lista de Clientes Registrados</h2>

                <asp:GridView ID="gvClientesRegistrados" runat="server" CssClass="table-dark table-bordered" BackColor="White" BorderColor="Blue" ForeColor="Black">
                    <HeaderStyle BackColor="#0033CC" />
                    
                </asp:GridView>

                <h2>Detalles del Cliente</h2>

                <div class="form-group">
                    <label for="tbNombreCliente">Nombre:</label>
                    <asp:TextBox ID="tbNombreCliente" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="ddlListasPreciosCliente">Lista de Precios:</label>
                    <asp:DropDownList ID="ddlListasPreciosCliente" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>

                <asp:Button ID="btnEliminarCliente" runat="server" Text="Eliminar" OnClick="btnEliminarCliente_Click" CssClass="btn btn-danger" />
                <asp:Button ID="btnGuardarCambiosCliente" runat="server" Text="Guardar" OnClick="btnGuardarCambiosCliente_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </main>

    <script type="text/javascript">
        // Script para mostrar/ocultar el formulario de búsqueda de cliente al hacer clic en el enlace "Buscar Cliente"
        document.getElementById('<%= hlBuscarCliente.ClientID %>').addEventListener('click', function(e) {
            e.preventDefault();
            document.getElementById('buscarCliente').style.display = 'block';
        });
    </script>
</asp:Content>
