<%@ Page Title="GenerarPlanificacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerarPlanificacion.aspx.cs" Inherits="MRP_Proyecto.GenerarPlanificacion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div class="container">
            <div class="row">
                <style>
                    .submenu ul {
                        list-style: none;
                        padding: 0;
                        margin: 0;
                    }

                    .submenu ul li {
                        display: inline;
                        margin-right: 20px;
                    }

                    .submenu ul li a {
                        text-decoration: none;
                        color: #333;
                        font-weight: bold;
                        font-size: 16px;
                        padding: 5px 10px;
                        border-radius: 5px;
                        transition: background-color 0.3s ease;
                    }

                    .submenu ul li a:hover {
                        background-color: #f0f0f0;
                        color: #000;
                    }
                </style>

                <div class="container">
                    <h1>Planeacion</h1>

                    <div class="submenu">
                        <ul>
                            <li><asp:HyperLink ID="hlAgregarReceta" runat="server" NavigateUrl="Planeacion.aspx">Agregar Receta</asp:HyperLink></li>
                            <li><asp:HyperLink ID="hlGenerarPlanificacion" runat="server" NavigateUrl="GenerarPlanificacion.aspx">Generar Planeacion</asp:HyperLink></li>
                        </ul>
                    </div>

                    <div class="row">
                        
                        <div class="col-md-6">
                                <h2>Pedidos Registrados</h2>
                                <div style="overflow-y: scroll; height: 130px; Width: 487px;">
                             <asp:GridView ID="gvPedidosExistentes" runat="server" CssClass="table-dark table-bordered" PageSize="4" BackColor="White" ForeColor="Black" Width="470px">
                                <HeaderStyle BackColor="#1C5E55" ForeColor="White" />

                             </asp:GridView>

                                                        </div>

                                <label for="ddlRecetas">&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            </label>
                            <div>
                                &nbsp;
                                <br />
                                <label for="ddlRecetas">
                                Id del
                                Pedido:</label>&nbsp;
                                <asp:TextBox ID="tbPedido" runat="server"></asp:TextBox>
&nbsp;
                                <asp:Button ID="btnPlanificacion" runat="server" Text="Generar Planificacion" OnClick="btnPlanificacion_Click" CssClass="btn btn-secondary" BackColor="#0066FF" />
                            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label></div>
                        </div>

                        
                        <div class="col-md-6">
                            <h2>Planificaciónación</h2>
                            <div>
                                <asp:Label ID="lblCliente" runat="server" Text="Cliente:"></asp:Label>
                            &nbsp;
                            </div>
                            <div>
                                <asp:Label ID="lblFecha" runat="server" Text="Fecha del pedido:"></asp:Label>
                            &nbsp;
                            </div>
                            <div>
                                <asp:Label ID="lblTiempo" runat="server" Text="Tiempo para finalizar el pedido(dias):"></asp:Label>
&nbsp;

                            </div>
                            <div>
                                <asp:Label ID="lblExtra" runat="server" Text="Tiempo Extra por faltante de Insumo(dias):"></asp:Label>

                            &nbsp;

                            </div>
                            <div>
                                <asp:Label ID="lblEntrega" runat="server" Text="Tiempo Total estimado(dias):"></asp:Label>
                            &nbsp;
                            </div>
                            <div>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>
                            <div>
                                <asp:GridView ID="gvPlanificacion" runat="server" AutoGenerateColumns="False" ItemsSource="{Binding}" Width="692px">
                                    <Columns>
                                        <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" />
                                        <asp:BoundField DataField="Pedido" HeaderText="Pedido" SortExpression="Pedido" />
                                        <asp:BoundField DataField="Inventario" HeaderText="Inventario" SortExpression="Inventario" />
                                        <asp:BoundField DataField="Faltante" HeaderText="Faltante" SortExpression="Faltante" />
                                        <asp:BoundField DataField="Tiempo" HeaderText="Tiempo" SortExpression="Tiempo" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div>
                                <asp:Button ID="btnGenerarPDF" runat="server" Text="Generar PDF" OnClick="btnGenerarPDF_Click" BackColor="#990000" ForeColor="White" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>