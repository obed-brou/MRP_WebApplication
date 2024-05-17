<%@ Page Title="Planeacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planeacion.aspx.cs" Inherits="MRP_Proyecto.Planeacion" %>

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
</style>&nbsp;<div class="container">
    <h1>Planeacion</h1>

    <div class="submenu">
        <ul>
            <li><asp:HyperLink ID="hlAgregarReceta" runat="server" NavigateUrl="Planeacion.aspx">Agregar Receta</asp:HyperLink></li>
            <li><asp:HyperLink ID="hlGenerarPlanificacion" runat="server" NavigateUrl="GenerarPlanificacion.aspx">Generar Planeacion</asp:HyperLink></li>
            </ul>
    </div>

    
</div>
                <div class="col-md-6">
                    <h2>Agregar Receta</h2>

                    <div class="form-group">
                        <label for="tbNombreReceta">Productos Existentes:</label><div style="overflow-y: scroll; height: 130px; Width: 487px;">
                            <asp:GridView ID="gvProductosExistentes" runat="server" CssClass="table-dark table-bordered" PageSize="4" BackColor="White" ForeColor="Black" Width="470px">
                                <HeaderStyle BackColor="#1C5E55" ForeColor="White" />

                            </asp:GridView>

                                                                                 </div>

                        <br />
                        <label for="tbNombreReceta">Codigo Producto:</label><asp:TextBox ID="tbCodigoProducto" runat="server" CssClass="form-control"></asp:TextBox>
                        <label for="tbTiempoReceta">Nombre Reseta:</label>
                        <asp:TextBox ID="tbNombreReceta" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="tbTiempoReceta">Tiempo (días):</label>
                        <asp:TextBox ID="tbTiempoReceta" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="tbCantidadReceta">Cantidad:</label>
                        <asp:TextBox ID="tbCantidadReceta" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        &nbsp;<asp:Label ID="lblUnidad2" runat="server">Unidad de Medida:</asp:Label>
                        <br />
                <asp:DropDownList ID="cbUnidadMProducto" runat="server">
                    <asp:ListItem>Kilogramos</asp:ListItem>
                    <asp:ListItem>Litros</asp:ListItem>
                    <asp:ListItem>Piezas</asp:ListItem>
                </asp:DropDownList>
                    </div>

                    <h3>&nbsp;</h3>

                    <div class="form-group">
                    </div>
                </div>

                
                <div class="col-md-6">
                    <h2>Detalles del Insumo</h2>

                    <div class="form-group">
                        &nbsp;<div style="overflow-y: scroll; height: 130px; Width: 487px;">
                            <asp:GridView ID="gvIsumosExistentes" runat="server" CssClass="table-dark table-bordered" CellPadding="4" PageSize="4" ForeColor="Black" GridLines="None" BackColor="White" Width="470px">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />

                            </asp:GridView>

                              </div>

                    <div class="form-group">
                        <label for="ddlBuscarInsumo">&nbsp;&nbsp; </label>
                        &nbsp;</div>

                    <div class="form-group">
                        &nbsp;<label for="ddlBuscarInsumo">Codigo Insumo:</label>&nbsp; <asp:TextBox ID="tbCodigoInsumo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="tbCantidadInsumo">Cantidad:</label><asp:TextBox ID="tbCantidadInsumo" runat="server" CssClass="form-control"></asp:TextBox>
                    &nbsp;</div>

                    <div class="form-group">
                        &nbsp;<asp:Label ID="lblUnidad1" runat="server">Unidad de Medida:</asp:Label>
                        <br />
                <asp:DropDownList ID="cbUnidadMInsumo" runat="server">
                    <asp:ListItem>Kilogramos</asp:ListItem>
                    <asp:ListItem>Litros</asp:ListItem>
                    <asp:ListItem>Piezas</asp:ListItem>
                </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Insumo" OnClick="btnAgregar_Click" CssClass="btn btn-secondary" BackColor="#0066FF" />

                    <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label></div></div>
                    <h3>Insumos de la Receta</h3>

                    <div style="overflow-y: scroll; height: 150px; Width: 517px;">
                        <asp:GridView ID="gvDetallesReceta" runat="server" CssClass="table-dark table-bordered" CellPadding="4" PageSize="4" ForeColor="Black" GridLines="None" BackColor="White" Width="500px" OnSelectedIndexChanged="gvDetallesReceta_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />

                        </asp:GridView>

                    </div>

                    <br />

                    <div class="form-group">

                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Receta" OnClick="btnGuardar_Click" CssClass="btn btn-primary" BackColor="#66FF66" />
                    <asp:Label ID="lblMensajeError2" runat="server" Text=""></asp:Label></div></div>
                </div>
            </div>
        </div>
    </main>
    </div>
</asp:Content>