<%@ Page Title="Lista de Precios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListasDePrecio.aspx.cs" Inherits="MRP_Proyecto.ListasDePrecio" %>

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
            background-color: #343a40; 
            transition: background-color 0.3s ease;
        }

        .submenu ul li a:hover {
            background-color: #808080; 
            color: #fff;
        }

        .container {
            display: flex;
            justify-content: space-between;
            margin-top: 20px;
        }

        .left-section, .middle-section, .right-section {
            flex: 1;
            margin-right: 20px;
        }

        .grid-container {
            margin-top: 20px;
        }

        .comments-container {
            margin-top: 20px;
            height: 252px;
        }

        .price-container {
            margin-top: 20px;
        }

        .btn-container {
            margin-top: 20px;
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
        <div class="container">
            
            <div class="left-section">
                <h2>Lista de Precios de los Productos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h2>

                <div class="grid-container">
                    <label>Listas registradas:</label>
                    <br />
                    <asp:GridView ID="gvListasRegistradas0" runat="server" CssClass="table-dark table-bordered" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" GridLines="Horizontal" Height="0px" HorizontalAlign="Left" Width="332px" ForeColor="Black">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                    <br />
                    <br />
                    <br />
            <asp:Panel ID="Panel2" runat="server" BackColor="Red" BorderColor="#990000" Enabled="False" ForeColor="White" Visible="False" Width="272px">
                 Faltan datos por rellenar</asp:Panel>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Lista:"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbLista" runat="server"></asp:TextBox>
                    <br />

                    <div class="btn-container">
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                        &nbsp;
                        <asp:Button ID="btnVer" runat="server" BackColor="Lime" CssClass="btn btn-danger" OnClick="btnVer_Click" Text="Ver" />
                        <br />
                        <br />
                    <asp:GridView ID="gvListaDetalle" runat="server" CssClass="table-dark table-bordered" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" GridLines="Horizontal" Height="0px" HorizontalAlign="Left" Width="332px" ForeColor="Black">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                        <br />
                        <br />
                        <br />
                    </div>

                </div>
            </div>

            
            <div class="right-section">
                <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Agregar Lista de Precios&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h2>
                <div class="comments-container" aria-expanded="undefined">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Nombre de la lista:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtNLista" runat="server"></asp:TextBox>
                    &nbsp;<br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Comentario:"></asp:Label>
                    &nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtComentarios" runat="server" Height="112px" MaxLength="100" TextMode="MultiLine" Width="431px"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:FileUpload ID="infExel" runat="server" CssClass="accordion-body" Font-Bold="True" Font-Size="X-Small" Width="760px" />
&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnImportar" runat="server" Text="Importar Excel seleccionado" CssClass="btn btn-primary" OnClick="btnImportar_Click" />
                    <br />
                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:GridView ID="gvPrecioProductos" runat="server" CssClass="table-dark table-bordered" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="2" GridLines="Horizontal" Height="0px" HorizontalAlign="Left" Width="382px">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                </div>
                <div class="price-container">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPProducto" runat="server" Font-Size="X-Large" ForeColor="Black" Text="Precios de Productos:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Visible="False" />
                </div>
                <div class="btn-container">
                </div>
            </div>
        </div>
            
    </main>
</asp:Content>
