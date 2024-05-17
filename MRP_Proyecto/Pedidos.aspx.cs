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
    public partial class Pedidos : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())  // Llamada a la función de validación
            {
                string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());


                    string consulta1 = $"select IdCliente from Cliente where Nombre = '{tbCliente.Text}' and IdUsuario = {IdUsuario};";

                    // Adaptador de datos
                    SqlCommand command1 = new SqlCommand(consulta1, conexion);

                    // Llenar el DataTable con el id de la base de datos mas reciente
                    DataTable table1 = new DataTable();
                    string IClient = "";

                    table1.Load(command1.ExecuteReader());

                    foreach (DataRow r2 in table1.Rows)
                    {
                        IClient = r2["IdCliente"].ToString();
                    }

                    DateTime fechaSeleccionada = Convert.ToDateTime(dtFecha.Text);

                    string FechaS = fechaSeleccionada.ToString("yyyy-MM-dd");

                    Pedido_Model modelo = new Pedido_Model()
                    {
                        IdUsuario = IdUsuario,
                        IdCliente = Convert.ToInt32(IClient),
                        Fecha = FechaS,
                        EstadoPedido = "Activo"
                    };

                    admin.Agregar_Pedido(modelo);

                    // Consulta SQL para obtener los nombres
                    string consulta = $"select top 1 IdPedido from Pedido where IdUsuario = {IdUsuario} order by IdPedido desc;";

                    // Adaptador de datos
                    SqlCommand command = new SqlCommand(consulta, conexion);

                    // Llenar el DataTable con el id de la base de datos mas reciente
                    DataTable table = new DataTable();
                    string IPedido = "";

                    table.Load(command.ExecuteReader());

                    foreach (DataRow r3 in table.Rows)
                    {
                        IPedido = r3["IdPedido"].ToString();
                    }

                    // Consulta SQL para obtener los nombres
                    string consulta2 = $"select * from Producto where IdUsuario = {IdUsuario};";

                    // Adaptador de datos
                    SqlCommand command2 = new SqlCommand(consulta2, conexion);

                    // Llenar el DataTable con el id de la base de datos mas reciente
                    DataTable table2 = new DataTable();

                    table2.Load(command2.ExecuteReader());


                    int IdPedido = Convert.ToInt32(IPedido);

                    for (int i = 0; i < gvProductos.Rows.Count; i++)
                    {
                        foreach (DataRow r4 in table2.Rows)
                        {
                            if (gvProductos.Rows[i].Cells[0].Text == r4["Codigo"].ToString())
                            {

                                PedidoDetalle_Model modelo2 = new PedidoDetalle_Model()
                                {
                                    IdPedido = IdPedido,
                                    IdUsuario = IdUsuario,
                                    Codigo = gvProductos.Rows[i].Cells[0].Text,
                                    Descripcion = r4["Descripcion"].ToString(),
                                    Cantidad = Convert.ToInt32(gvProductos.Rows[i].Cells[1].Text),
                                    UnidadMedida = r4["UnidadMedida"].ToString()
                                };

                                admin.Agregar_PedidoDetalle(modelo2);
                            }
                        }
                    }
                    conexion.Close();
                }
            }
        }
        private bool ValidarCampos()
        {
            // Validación de campos aquí
            if (string.IsNullOrEmpty(tbCliente.Text))
            {
                // Puedes mostrar un mensaje o realizar alguna acción en caso de error
                MostrarMensajeError("El campo Cliente no puede estar vacío.");
                return false;
            }

            DateTime fechaSeleccionada;
            if (!DateTime.TryParse(dtFecha.Text, out fechaSeleccionada))
            {
                MostrarMensajeError("Fecha seleccionada no válida.");
                return false;
            }

            // Puedes agregar más validaciones según tus necesidades

            return true;
        }
        private void MostrarMensajeError(string mensaje)
        {
            // Aquí puedes implementar la lógica para mostrar un mensaje de error,
            // como por ejemplo, mostrarlo en un control Label o en un cuadro de diálogo
            // o registrar el error en un log.
            // Ejemplo para mostrar el mensaje en un Label (asegúrate de tener un Label en tu página):
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
        }

        protected void btnExel_Click(object sender, EventArgs e)
        {
            if (fuArchivoExcel.HasFile)
            {
                string fileName = Path.GetFileName(fuArchivoExcel.PostedFile.FileName);
                string filePath = Server.MapPath("~/UploadedFiles/" + fileName);
                fuArchivoExcel.SaveAs(filePath);

                // Leer datos desde el archivo Excel
                DataTable dt = ReadExcelFile(filePath);

                // Mostrar datos en el GridView
                gvProductos.DataSource = dt;
                gvProductos.DataBind();
            }
        }

        private DataTable ReadExcelFile(string filePath)
        {
            DataTable dt = new DataTable();

            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                IXLWorksheet workSheet = workBook.Worksheet(1);

                bool firstRow = true;

                foreach (IXLRow row in workSheet.Rows())
                {
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;

                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }
            }

            return dt;
        }
    }
}