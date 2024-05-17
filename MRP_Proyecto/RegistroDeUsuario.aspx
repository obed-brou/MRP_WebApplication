<%@ Page Title="Registro de Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroDeUsuario.aspx.cs" Inherits="MRP_Proyecto.RegistroDeUsuario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container {
            margin-top: 20px;
        }

        .form-group, .btn-container {
            margin-top: 15px;
        }
    </style>

    <main>
        <div class="container">
            <h2>&nbsp;</h2>
            <h2>Registro de Usuarios</h2>

            <div class="form-group">
                <label for="tbNombre">Nombre:</label>
                <asp:TextBox ID="tbNombreUs" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="tbUsuario">Usuario:</label>
                <asp:TextBox ID="tbUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="tbContraseña">Contraseña:</label>
                <asp:TextBox ID="tbContraseña" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="tbConfirmarContraseña">Confirmar Contraseña:</label>
                <asp:TextBox ID="tbConfirmarContraseña" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="ddlTipoUsuario">Tipo de Usuario:</label>
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Administrador" Value="Admin"></asp:ListItem>
                    <asp:ListItem Text="Usuario" Value="User"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="btn-container">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </main>
</asp:Content>
