<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="MRP_Proyecto.Clientes" %>

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
                    <li><asp:HyperLink ID="hlAgregarCliente" runat="server" NavigateUrl="AgregarCliente.aspx">Agregar Cliente</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlBuscarCliente" runat="server" NavigateUrl="BuscarCliente.aspx">Buscar Cliente</asp:HyperLink></li>
                    <li><asp:HyperLink ID="hlListaPrecios" runat="server" NavigateUrl="ListasDePrecio.aspx">Lista de Precios</asp:HyperLink></li>
                </ul>
            </div>
        </div>
    </main>
</asp:Content>
