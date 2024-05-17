using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MRP_Proyecto.Datos;
using MRP_Proyecto.Modelo;

namespace MRP_Proyecto
{
    public partial class BuscarCliente : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarInfoDataGridListaClientes();
            CargarComboBoxLista();
        }
        protected void btnGuardarCambiosCliente_Click(object sender, EventArgs e)
        {

        }
        protected void btnEliminarCliente_Click(object sender, EventArgs e)
        {

        }

        private void CargarComboBoxLista()
        {
            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT Nombre_Lista FROM ListaPrecios where IdUsuario = {IdUsuario};";

                // Adaptador de datos
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);

                // DataTable para almacenar los nombres
                DataTable datos = new DataTable();

                // Llenar el DataTable con los nombres de la base de datos
                adaptador.Fill(datos);

                // Enlazar los nombres al ComboBoxProveedor
                ddlListasPreciosCliente.DataTextField = "Nombre_Lista"; // Nombre del campo que se mostrará
                ddlListasPreciosCliente.DataValueField = "Nombre_Lista"; // Puedes establecer el campo que quieres usar como valor, si es necesario
                ddlListasPreciosCliente.DataSource = datos;
                ddlListasPreciosCliente.DataBind();
            }
        }

        private void CargarInfoDataGridListaClientes()
        {
            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT * FROM Cliente where IdUsuario = {IdUsuario}";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());

                gvClientesRegistrados.DataSource = table;
                gvClientesRegistrados.DataBind();

                conexion.Close();
            }
        }
    }
}