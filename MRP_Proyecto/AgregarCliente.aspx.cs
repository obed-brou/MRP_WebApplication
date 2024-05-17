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
    public partial class AgregarCliente : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNombresComboBoxLista();
            }
        }

        protected void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si los campos obligatorios están vacíos
                if (string.IsNullOrWhiteSpace(tbID.Text) || string.IsNullOrWhiteSpace(tbNombre.Text) || string.IsNullOrWhiteSpace(dgvListaPrecios.Text))
                {
                    MostrarMensajeError("Todos los campos son obligatorios. Por favor, complete la información antes de guardar.");
                    return;  // Sale del evento si algún campo obligatorio está vacío
                }

                // Los campos no están vacíos, puedes proceder con la lógica de guardar el cliente
                string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                    // Consulta SQL para obtener los nombres
                    string consulta = $"select IdLista from ListaPrecios where Nombre_Lista = '{dgvListaPrecios.Text}' and IdUsuario = {IdUsuario};";

                    // Adaptador de datos
                    SqlCommand command = new SqlCommand(consulta, conexion);

                    // Llenar el DataTable con el id de la base de datos más reciente
                    DataTable table = new DataTable();
                    string ILista = "";

                    table.Load(command.ExecuteReader());

                    foreach (DataRow r in table.Rows)
                    {
                        ILista = r["IdLista"].ToString();
                    }

                    int IdLista = Convert.ToInt32(ILista);

                    Cliente_Model modelo = new Cliente_Model()
                    {
                        IdCliente = Convert.ToInt32(tbID.Text),
                        IdUsuario = IdUsuario,
                        Nombre = tbNombre.Text,
                        IdLista = IdLista
                    };

                    admin.Agregar_Cliente(modelo);

                    conexion.Close();

                    // Operación exitosa, muestra un mensaje de éxito
                    MostrarMensajeExito("Cliente agregado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Puedes ajustar esto según tus necesidades
                MostrarMensajeError("Ocurrió un error al guardar el cliente. Detalles: " + ex.Message);
            }
        }
        private void MostrarMensajeExito(string mensaje)
        {
            // Puedes implementar la lógica para mostrar un mensaje de éxito aquí,
            // por ejemplo, mostrarlo en un Label o en un cuadro de diálogo.
            // Asegúrate de tener un control en tu página para mostrar mensajes de éxito,
            // por ejemplo, un Label llamado lblMensajeExito.
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
        }
        private void MostrarMensajeError(string mensaje)
        {
            // Puedes implementar la lógica para mostrar un mensaje de error aquí,
            // por ejemplo, mostrarlo en un Label o en un cuadro de diálogo.
            // Asegúrate de tener un control en tu página para mostrar mensajes de error,
            // por ejemplo, un Label llamado lblMensajeError.
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
        }

        private void CargarNombresComboBoxLista()
        {
            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT Nombre_Lista FROM ListaPrecios where IdUsuario = {IdUsuario}";

                // Adaptador de datos
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);

                // DataTable para almacenar los nombres
                DataTable datos = new DataTable();

                // Llenar el DataTable con los nombres de la base de datos
                adaptador.Fill(datos);

                // Enlazar los nombres al ComboBoxProveedor
                dgvListaPrecios.DataTextField = "Nombre_Lista"; // Nombre del campo que se mostrará
                dgvListaPrecios.DataValueField = "Nombre_Lista"; // Puedes establecer el campo que quieres usar como valor, si es necesario
                dgvListaPrecios.DataSource = datos;
                dgvListaPrecios.DataBind();
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"select IdCliente from Cliente where IdUsuario = {IdUsuario};";
                string consulta2 = $"select top 1 IdCliente from Cliente where IdUsuario = {IdUsuario} order by IdLista desc;";

                // Adaptador de datos
                SqlCommand command = new SqlCommand(consulta, conexion);
                SqlCommand command2 = new SqlCommand(consulta2, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());


                DataTable table2 = new DataTable();

                table2.Load(command2.ExecuteReader());

                for (int i = 0; i < 1; i++)
                {
                    i = i - 1;

                    Random random = new Random();

                    int numeroEnRango = random.Next(1, 10000);


                    foreach (DataRow r in table.Rows)
                    {
                        if (numeroEnRango == Convert.ToInt64(r["IdCliente"].ToString()))
                        {
                            break;
                        }

                        foreach (DataRow r2 in table.Rows)
                        {
                            if (Convert.ToInt64(r2["IdCliente"].ToString()) == Convert.ToInt64(r["IdCliente"].ToString()))
                            {
                                i = i + 30;

                                tbID.Text = numeroEnRango.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}