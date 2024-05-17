<%@ Page Title="Cargar Inventario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarInventario.aspx.cs" Inherits="MRP_Proyecto.CargarInventario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
        .container {
            margin-top: 20px;
        }

        .file-upload-container, .details-container, .btn-container {
            margin-top: 20px;
        }
    </style>

    <main>
            <div class="container">
<h1>&nbsp;</h1>
                <h1>Cargar Inventarios</h1>

<div class="submenu">
    <ul>
        <li><asp:HyperLink ID="hlCargarInventario" runat="server" NavigateUrl="#">Cargar Inventario</asp:HyperLink></li>
        <li><asp:HyperLink ID="hlVerInventario" runat="server" NavigateUrl="Inventarios.aspx">Ver Inventario</asp:HyperLink></li>
        
    </ul>
</div>
        </div>
        <div class="container">
            <h2>Cargar Inventario desde Excel</h2>

            
            <div class="details-container">
                <br />
                <label>
                Fecha:</label><asp:TextBox ID="tbFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>

            
                <br />

            
            <div class="file-upload-container">
                &nbsp;<label>Ruta de archivo de Excel:</label>&nbsp;
                <asp:FileUpload ID="fileExel" runat="server" />
            </div>

            
            </div>

           
            <div class="btn-container">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label></div>
        </div>
    </main>
</asp:Content>
