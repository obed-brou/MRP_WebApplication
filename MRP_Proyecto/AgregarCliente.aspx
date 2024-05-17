<%@ Page Title="AgregarClientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="MRP_Proyecto.AgregarCliente" %>

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
    <script type="text/javascript">
        // Script para mostrar/ocultar el formulario de registro de cliente al hacer clic en el enlace "Agregar Cliente"
        document.getElementById('<%= hlAgregarCliente.ClientID %>').addEventListener('click', function(e) {
            e.preventDefault();
            document.getElementById('registroCliente').style.display = 'block';
        });
    </script>
        <div class="container">
            <h1>Clientes</h1>

            <div class="submenu">
                <ul>
                    <li><asp:HyperLink ID="hlAgregarCliente" runat="server" NavigateUrl="#">Agregar Cliente</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlBuscarCliente" runat="server" NavigateUrl="BuscarCliente.aspx">Buscar Cliente</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlListaPrecios" runat="server" NavigateUrl="ListasDePrecio.aspx">Lista de Precios</asp:HyperLink></li>
                
                </ul>
            </div>

                <h2>Registrar Nuevo Cliente</h2>

                <div class="form-group">
                    <label for="tbID">ID:</label>
                    <asp:TextBox ID="tbID" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="btnGenerar" runat="server" BackColor="#0066FF" ForeColor="White" OnClick="btnGenerar_Click" Text="Generar Automaticamente" Width="259px" />
                </div>

                <div class="form-group">
                    <label for="tbNombre">Nombre:</label>
                    <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="ddlListaPrecios">Lista de Precios:</label>
                    <br />
                    <asp:DropDownList ID="dgvListaPrecios" runat="server">
                    </asp:DropDownList>
                </div>

                <asp:Button ID="btnGuardarCliente" runat="server" Text="Guardar" OnClick="btnGuardarCliente_Click" CssClass="btn btn-primary" BackColor="#0066FF" />
        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>    
        </div>
        </div>
    </asp:Content>
