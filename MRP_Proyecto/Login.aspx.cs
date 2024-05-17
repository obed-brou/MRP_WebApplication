using MRP_Proyecto.Datos;
using MRP_Proyecto.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRP_Proyecto
{
    public partial class Login : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {
            string nombreArchivo = "MRP_Inventarios.mdf";
            string rutaRelativa = "~/App_Data/" + nombreArchivo; // Cambia esto según la ubicación real de tu archivo

            string rutaFisica = Server.MapPath(rutaRelativa);

            // Ahora, 'rutaFisica' contiene la ubicación física del archivo en el servidor

            Session["Conexion"] = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={rutaFisica}";
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string Usuario = tbUsuario.Text; 
            string Password = tbContraseña.Text;


            if (VerificarCredenciales(Usuario, Password))
            {
                // Inicio de sesión exitoso
                int usuarioId = ObtenerUsuarioId(Usuario, Password);
                Session["UsuarioId"] = usuarioId;
                Response.Redirect("Default.aspx");
            }
            else
            {
                // Credenciales incorrectas, muestra un mensaje de error
            }
        }
        private bool VerificarCredenciales(string Usuario, string Password)
        {
            // Aquí debes implementar tu lógica para verificar las credenciales del usuario utilizando ADO.NET

            // Ejemplo básico utilizando SqlConnection y SqlCommand
            string connectionString = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión válida
            string query = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Password", Password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        public int ObtenerUsuarioId(string Usuario, string Password)
        {
            // Aquí debes implementar tu lógica para obtener el valor del campo 'usuario_id' utilizando ADO.NET

            // Ejemplo básico utilizando SqlConnection y SqlCommand
            string connectionString = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión válida
            string query = "SELECT IdUsuario FROM Usuario WHERE Usuario = @Usuario AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", Usuario);
                    command.Parameters.AddWithValue("@Password", Password);

                    int usuarioId = (int?)command.ExecuteScalar() ?? 0;

                    return usuarioId;
                }
            }
        }
    }
}