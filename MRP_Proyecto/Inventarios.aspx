<%@ Page Title="Inventarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventarios.aspx.cs" Inherits="MRP_Proyecto.Inventarios" %>

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
        .container {
            display: flex;
            justify-content: space-between;
            margin-top: 20px;
        }

        .left-section, .right-section {
            flex: 1;
            margin-right: 20px;
        }

        .grid-container {
            margin-top: 20px;
        }

        .details-container {
            margin-top: 20px;
        }

        .info-label {
            font-size: 12px;
            color: #999;
            margin-top: 10px;
        }

        .btn-container {
            margin-top: 20px;
        }
    </style>

    <main>
        <div class="container">
    <h1>Ver Inventarios</h1>

    <div class="submenu">
        <ul>
            <li><asp:HyperLink ID="hlVerInventario" runat="server" NavigateUrl="#">Ver Inventario</asp:HyperLink></li>
            <li><asp:HyperLink ID="hlCargarInventario" runat="server" NavigateUrl="CargarInventario.aspx">Cargar Inventario</asp:HyperLink></li>
            
        </ul>
    </div>
            </div>
        <div class="container">
            
            <div class="left-section">

                <div class="grid-container">
                    <label>Listas de registro de inventario:</label><div style="overflow-y: scroll; height: 400px;">
                        <asp:GridView ID="gvInventarios" runat="server" CssClass="table" CellPadding="0" PageSize="4">

                        </asp:GridView>

                                                                    </div>

                    <div class="date-picker-container">
                        &nbsp;</div>
                </div>
            </div>

            
            <div class="right-section">
                <h2>Detalles de inventario</h2>

                <div class="details-container">
                    <div>
                        <label>Busqueda por fecha:
                    </label>
                        <asp:TextBox ID="cFiltrar" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>

            
                    <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" BackColor="#0066CC" ForeColor="White" />
                        <br />
&nbsp;<br />
                        Id del inventario:&nbsp;
                        <asp:TextBox ID="tbIDInv" runat="server"></asp:TextBox>
&nbsp;
                        <asp:Button ID="btnDetalle" runat="server" BackColor="#0066FF" ForeColor="White" OnClick="btnDetalle_Click" Text="Ver  Detalles" />
                        <br />
                        <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblF" runat="server" Text="Fecha:" Visible="False"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblData" runat="server" Text="Almacenado por:" Visible="False"></asp:Label>
                        <br />
                        <br />
                        <div style="overflow-y: scroll; height: 400px;">
                        <asp:GridView ID="gvInventariosDetalle" runat="server" CssClass="table" Visible="False" CellPadding="0" PageSize="4">

                        </asp:GridView>

                                                                    </div>

                    </div>

                    &nbsp;<div class="btn-container">
                        &nbsp;<asp:Button ID="btnGenerarExcel" runat="server" Text="Generar Excel" CssClass="btn btn-success" OnClick="btnGenerarExcel_Click" Visible="False" />
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

