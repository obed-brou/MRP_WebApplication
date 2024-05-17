<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MRP_Proyecto.Login" %>

<style>
    body {
    font-family: Arial, sans-serif;
    background-color: #f4f4f4;
}

form {
    max-width: 400px;
    margin: 50px auto;
    padding: 20px;
    background-color: #fff;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

h2 {
    text-align: center;
    color: #333;
}

label {
    display: block;
    margin: 10px 0 5px;
    color: #555;
}

.form-control {
    width: 100%;
    padding: 8px;
    margin-bottom: 10px;
    box-sizing: border-box;
    border: 1px solid #ccc;
    border-radius: 4px;
}

.btn-primary {
    background-color: #007bff;
    color: #fff;
    padding: 10px 15px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

.btn-primary:hover {
    background-color: #0056b3;
}

#lblMensaje {
    text-align: center;
    margin-top: 10px;
}
.btn-registro {
        background-color: #28a745;
        color: #fff;
        padding: 10px 15px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        display: block;
        margin-top: 10px;
        text-align: center;
        text-decoration: none;
    }

    .btn-registro:hover {
        background-color: #218838;
    }
    </style>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>

            <div>
                <label for="tbUsuario">Usuario:</label>
                <asp:TextBox ID="tbUsuario" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
            </div>

            <div>
                <label for="tbContraseña">Contraseña:</label>
                <asp:TextBox ID="tbContraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" CssClass="btn btn-primary" Width="401px" />

            <a href="RegistroDeUsuario.aspx" class="btn-registro">Crear Nuevo Usuario</a>
        </div>
    </form>
</body>
</html>