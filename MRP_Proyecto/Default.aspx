<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MRP_Proyecto._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .dashboard-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            margin-top: 20px;
        }

        .dashboard-item {
            flex: 1;
            padding: 20px;
            margin: 10px;
            background-color: #f8f9fa;
            border: 1px solid #dee2e6;
            border-radius: 4px;
            text-align: center;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .dashboard-item a {
            text-decoration: none;
            color: #343a40;
        }

        .dashboard-item:hover {
            background-color: #e9ecef;
        }

        .dashboard-item.large {
            flex: 2;
        }
    </style>
    <main>
        <div class="container">
            <div class="dashboard-container">
                <div class="dashboard-item">
                    <a href="Productos.aspx">
                        <h2>Productos</h2>
                        <p>Administra tus productos</p>
                    </a>
                </div>
                <div class="dashboard-item">
                    <a href="Pedidos.aspx">
                        <h2>Pedidos</h2>
                        <p>Gestiona los pedidos de tus clientes</p>
                    </a>
                </div>
                <div class="dashboard-item">
                    <a href="Clientes.aspx">
                        <h2>Clientes</h2>
                        <p>Administra la información de tus clientes</p>
                    </a>
                </div>
                <div class="dashboard-item">
                    <a href="Inventarios.aspx">
                        <h2>Inventarios</h2>
                        <p>Controla el inventario de tus productos</p>
                    </a>
                </div>
                <div class="dashboard-item large">
                    <a href="Planeacion.aspx">
                        <h2>Planeacion</h2>
                        <p>Planifica y organiza tus actividades</p>
                    </a>
                </div>
            </div>
        </div>            <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Producto Escaso:" Visible="False"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
        <div class="dashboard-item">
            <a href="">
                <div style="overflow-y: scroll; height: 200px; Width: 1017px;">
                    <asp:GridView ID="gvProductosFaltantes" runat="server" CssClass="table-dark table-bordered" CellPadding="4" PageSize="4" ForeColor="Black" GridLines="None" BackColor="White" Width="1000px">

                        <HeaderStyle BackColor="#006666" ForeColor="White" />

                    </asp:GridView>

                </div>
            </a>
        </div>
    </asp:Panel>
    </main>
</asp:Content>
