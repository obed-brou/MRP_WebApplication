<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="MRP_Proyecto.Productos" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">
        <div class="container">
            <h1>Agregar Producto</h1>

            <asp:Label ID="lblMensaje2" runat="server"></asp:Label>
              <div style="overflow-y: scroll; height: 200px; Width: 817px;">
                  <asp:GridView ID="gvProductos" runat="server" CssClass="table-dark table-bordered" CellPadding="4" PageSize="4" ForeColor="Black" GridLines="None" BackColor="White" Width="800px">
                      <HeaderStyle BackColor="#006666" ForeColor="White" />

                  </asp:GridView>

              </div>
            <br />

            <asp:Label ID="lblMensaje0" runat="server"></asp:Label>
            <asp:Panel ID="Panel3" runat="server" BackColor="Red" BorderColor="#990000" Enabled="False" ForeColor="White" Visible="False" Width="800px">
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ubo algun problema al registrar el producto</asp:Panel>
            <asp:Panel ID="Panel2" runat="server" BackColor="Red" BorderColor="#990000" Enabled="False" ForeColor="White" Visible="False" Width="800px">
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Faltan datos por rellenar</asp:Panel>
            <asp:Panel ID="Panel1" runat="server" BackColor="#00FF99" BorderColor="Lime" Enabled="False" ForeColor="White" Visible="False" Width="800px">
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Producto registrado Exitosamente</asp:Panel>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            &nbsp;<br />
            <br />
                <label for="cbUnidadMedida">Tipo de Producto:</label>
                <br />
                <asp:DropDownList ID="cbTipo" runat="server">
                    <asp:ListItem>Insumo</asp:ListItem>
                    <asp:ListItem>Producto</asp:ListItem>
                </asp:DropDownList>
            &nbsp;<asp:Button ID="btnInicio" runat="server" BackColor="#0066FF" BorderColor="#0066CC" ForeColor="White" OnClick="btnInicio_Click" Text="Iniciar" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            &nbsp;<br />
            <asp:Label ID="lblCodigo" runat="server" Visible="False">Codigo:</asp:Label>
            <br />

            <div class="form-group">
                &nbsp;<asp:TextBox ID="tbCodigo" runat="server" CssClass="form-control" Visible="False"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="Label4" runat="server"></asp:Label>
                <br />
            <asp:Label ID="lblDescripcion" runat="server" Visible="False">Descripcion:</asp:Label>
            &nbsp;<asp:TextBox ID="tbDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control" Visible="False"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="lblUnidad" runat="server" Visible="False">Unidad de Medida:</asp:Label>
            &nbsp;<br />
                <asp:DropDownList ID="cbUnidad" runat="server" Visible="False">
                    <asp:ListItem>Kilogramos</asp:ListItem>
                    <asp:ListItem>Litros</asp:ListItem>
                    <asp:ListItem>Piezas</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
            <asp:Label ID="lblProv" runat="server" Visible="False">Proveedor:</asp:Label>
            &nbsp;<asp:DropDownList ID="comboboxProveedor" runat="server" CssClass="form-control" AutoPostBack="True" Visible="False"></asp:DropDownList>
                
                <asp:SqlDataSource ID="MRP_Inventarios" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [Nombre] FROM [Proveedor]"></asp:SqlDataSource>
                
            </div>
            <asp:TextBox ID="tbProveedor" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            <asp:CheckBox ID="cbProveedor" runat="server" AutoPostBack="True" OnCheckedChanged="cbProveedor_CheckedChanged" Text="Agregar Proveedor" Visible="False" />
            <br />
            <asp:Label ID="lblProveedor" runat="server" ForeColor="Red" Text="Debes proporsionar el nombre del proveedor" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="btnRegistrarProveedor" runat="server" Text="Registrar Proveedor" OnClick="btnRegistrarProveedor_Click" CssClass="btn btn-secondary" Enabled="False" Visible="False" />
                
             <br />
            <asp:Label ID="Label5" runat="server"></asp:Label>
                
             <br />
                
             <div class="form-group">
                 &nbsp;<asp:Label ID="lblEspera" runat="server" Visible="False">Tiempo de espera(dias):</asp:Label>
            &nbsp;<asp:TextBox ID="tbTiempoEspera" runat="server" CssClass="form-control" Visible="False"></asp:TextBox>
                
             </div>

            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" CssClass="btn btn-primary" />

        </div>
    </main>
</asp:Content>