using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using ClosedXML.Excel;
using System.Web.UI.WebControls;
using System.Data;
using MRP_Proyecto.Modelo;
using System.Data.SqlClient;
using MRP_Proyecto.Datos;
using NPOI.Util;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MRP_Proyecto
{
    public partial class Inventarios : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInfoDataGridListas();
            }
        }

        protected void btnGenerarExcel_Click(object sender, EventArgs e)
        {

        }

        private void CargarInfoDataGridListas()
        {
            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT * FROM Inventario where IdUsuario = {IdUsuario}";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());

                gvInventarios.DataSource = table;
                gvInventarios.DataBind();

                conexion.Close();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                DateTime fechaSeleccionada = Convert.ToDateTime(cFiltrar.Text);

                // Convertir la fecha a una cadena (string)
                string FechaS = fechaSeleccionada.ToString("yyyy-MM-dd");

                // Consulta SQL para obtener los nombres
                string consulta = $"select* from Inventario where Fecha = '{FechaS}' and IdUsuario = {IdUsuario};";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());

                gvInventarios.DataSource = table;
                gvInventarios.DataBind();

                conexion.Close();
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbIDInv.Text))
                {
                    lblF.Visible = true;
                    lblData.Visible = true;
                    gvInventariosDetalle.Visible = true;
                    btnGenerarExcel.Visible = true;

                    string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
                    using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                        string consulta2 = $"select * from Inventario where IdInventario = {tbIDInv.Text} and IdUsuario = {IdUsuario};";

                        SqlCommand command2 = new SqlCommand(consulta2, conexion);

                        // Llenar el DataTable con el id de la base de datos mas reciente
                        DataTable table2 = new DataTable();

                        table2.Load(command2.ExecuteReader());

                        string Orig;
                        foreach (DataRow r in table2.Rows)
                        {
                            DateTime fechaSeleccionada = Convert.ToDateTime(r["Fecha"].ToString());
                            lblData.Text = "Almacenado por:  " + r["Nombre"].ToString();
                            lblF.Text = "Fecha:  " + fechaSeleccionada.ToString("dd-MM-yyyy");
                        }

                        // Consulta SQL para obtener los nombres
                        string consulta = $"select Codigo, Descripcion, InvInicial, InvFinal, Mermas, MotivoMermas, Ultimo_Surtido from InventarioDetalle where IdInventario = '{tbIDInv.Text}' and IdUsuario = {IdUsuario};";

                        SqlCommand command = new SqlCommand(consulta, conexion);

                        // Llenar el DataTable con el id de la base de datos mas reciente
                        DataTable table = new DataTable();

                        table.Load(command.ExecuteReader());

                        gvInventariosDetalle.DataSource = table;
                        gvInventariosDetalle.DataBind();

                        conexion.Close();
                    }
                }
                else
                {
                    MostrarMensajeError("Por favor, ingrese un ID de inventario válido.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Puedes ajustar esto según tus necesidades
                MostrarMensajeError("Ocurrió un error al procesar la solicitud. Detalles: " + ex.Message);
            }
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
    }
}