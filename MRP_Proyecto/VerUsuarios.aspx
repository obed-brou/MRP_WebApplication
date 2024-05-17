<%@ Page Title="Ver Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="MRP_Proyecto.VerUsuarios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container {
            display: flex;
            justify-content: space-between;
            margin-top: 20px;
        }

        .left-section, .right-section {
            flex: 1;
            margin-right: 20px;
        }

        .grid-container, .details-container, .btn-container {
            margin-top: 20px;
        }
    </style>

    <main>
        <div class="container">
            
            <div class="left-section">
                <h2>Listas de Usuarios</h2>

                <div class="grid-container">
                    <label>Usuarios registrados:</label>
                    <asp:GridView ID="gvUsuarios" runat="server" CssClass="table">
                        
                    </asp:GridView>
                </div>
            </div>

            
            <div class="right-section">
                <h2>Detalles del Usuario</h2>

                <div class="details-container">
                    <div class="form-group">
                        <label for="tbID">ID:</label>
                        <asp:TextBox ID="tbID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="tbNombre">Nombre:</label>
                        <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control"></asp:TextBox>
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
                        <label for="ddlTipoUsuario">Tipo de Usuario:</label>
                        <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Administrador" Value="Admin"></asp:ListItem>
                            <asp:ListItem Text="Usuario" Value="User"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="btn-container">
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
