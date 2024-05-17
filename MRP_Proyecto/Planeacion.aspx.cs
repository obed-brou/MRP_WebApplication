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
    public partial class Planeacion : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarInfoProductos();
            CargarInfoInsumos();

            if (!IsPostBack)
            {
                // Si no es un postback, crea la estructura del DataTable y guárdala en la sesión
                DataTable dt = new DataTable();
                dt.Columns.Add("Codigo");
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("UnidadMedida");

                Session["DetallesReceta"] = dt;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                string consulta = $"select Descripcion from Producto where Codigo = '{tbCodigoProducto.Text}' and IdUsuario = {IdUsuario};";

                // Adaptador de datos
                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();
                string Des = "";
                table.Load(command.ExecuteReader());
                foreach (DataRow r in table.Rows)
                {
                    Des = r["Descripcion"].ToString();
                }

                Receta_Model modelo2 = new Receta_Model()
                {
                    IdUsuario = IdUsuario,
                    NombreReceta = tbNombreReceta.Text,
                    Codigo = tbCodigoProducto.Text,
                    Descripcion = Des,
                    TiempoFabricacion_dias = Convert.ToInt32(tbTiempoReceta.Text),
                    Cantidad = Convert.ToInt32(tbCantidadReceta.Text),
                    UnidadMedida = cbUnidadMProducto.Text
                };

                admin.Agregar_Receta(modelo2);


                string consulta2 = $"select top 1 IdReceta from Recetas where IdUsuario = {IdUsuario} order by IdReceta desc;";

                // Adaptador de datos
                SqlCommand command2 = new SqlCommand(consulta2, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table2 = new DataTable();
                string IReceta = "";
                table2.Load(command2.ExecuteReader());
                foreach (DataRow r in table2.Rows)
                {
                    IReceta = r["IdReceta"].ToString();
                }

                int IdReceta = Convert.ToInt32(IReceta);

                for (int i = 0; i < gvDetallesReceta.Rows.Count; i++)
                {
                    InsumosRecetas_Model modelo = new InsumosRecetas_Model()
                    {
                        IdReceta = IdReceta,
                        IdUsuario = IdUsuario,
                        Codigo = gvDetallesReceta.Rows[i].Cells[0].Text,
                        Descripcion = gvDetallesReceta.Rows[i].Cells[1].Text,
                        Cantidad = Convert.ToInt32(gvDetallesReceta.Rows[i].Cells[2].Text),
                        UnidadMedida = gvDetallesReceta.Rows[i].Cells[3].Text,
                    };

                    admin.Agregar_InsumosRecetas(modelo);
                }
                conexion.Close();
            }
        }

        private void CargarInfoProductos()
        {
            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT Codigo, Descripcion, UnidadMedida FROM Producto where Tipo_Producto = 'Producto' and IdUsuario = {IdUsuario}";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());

                gvProductosExistentes.DataSource = table;
                gvProductosExistentes.DataBind();

                conexion.Close();
            }
        }

        private void CargarInfoInsumos()
        {
            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT Codigo, Descripcion, UnidadMedida FROM Producto where Tipo_Producto = 'Insumo' and IdUsuario = {IdUsuario}";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());

                gvIsumosExistentes.DataSource = table;
                gvIsumosExistentes.DataBind();

                conexion.Close();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                    string consulta = $"select Descripcion from Producto where Codigo = '{tbCodigoInsumo.Text}' and IdUsuario = {IdUsuario};";

                    // Adaptador de datos
                    SqlCommand command = new SqlCommand(consulta, conexion);

                    // Llenar el DataTable con el id de la base de datos más reciente
                    DataTable table = new DataTable();
                    string Des = "";
                    table.Load(command.ExecuteReader());
                    foreach (DataRow r in table.Rows)
                    {
                        Des = r["Descripcion"].ToString();
                    }

                    string codigo = tbCodigoInsumo.Text;
                    string descripcion = Des;

                    if (float.TryParse(tbCantidadInsumo.Text, out float cantidad) && cantidad > 0)
                    {
                        string unidadMedida = cbUnidadMInsumo.Text;

                        // Recuperar el DataTable de la sesión
                        DataTable dt = (DataTable)Session["DetallesReceta"];

                        // Crear una nueva fila con los valores
                        DataRow dr = dt.NewRow();
                        dr["Codigo"] = codigo;
                        dr["Descripcion"] = descripcion;
                        dr["Cantidad"] = cantidad;
                        dr["UnidadMedida"] = unidadMedida;

                        // Agregar la fila al DataTable
                        dt.Rows.Add(dr);

                        // Asignar el DataTable al GridView
                        gvDetallesReceta.DataSource = dt;
                        gvDetallesReceta.DataBind();
                    }
                    else
                    {
                        MostrarMensajeError("La cantidad debe ser un número válido y mayor que cero.");
                    }

                    conexion.Close();
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

        protected void gvDetallesReceta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}