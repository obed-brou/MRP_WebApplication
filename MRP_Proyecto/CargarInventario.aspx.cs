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
    public partial class CargarInventario : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                    DateTime fechaSeleccionada = Convert.ToDateTime(tbFecha.Text);

                    // Convertir la fecha a una cadena (string)
                    string FechaS = fechaSeleccionada.ToString("yyyy-MM-dd");

                    // Consulta SQL para obtener los nombres
                    string consulta5 = $"select Nombre from Usuario where IdUsuario = {IdUsuario};";

                    // Adaptador de datos
                    SqlCommand command5 = new SqlCommand(consulta5, conexion);

                    // Llenar el DataTable con el id de la base de datos más reciente
                    DataTable table5 = new DataTable();
                    string Nombre = "";

                    table5.Load(command5.ExecuteReader());

                    foreach (DataRow r in table5.Rows)
                    {
                        Nombre = r["Nombre"].ToString();
                    }

                    Inventario_Model modelo = new Inventario_Model()
                    {
                        IdUsuario = IdUsuario,
                        Nombre = Nombre,
                        Fecha = FechaS
                    };

                    admin.Agregar_Inventario(modelo);

                    // Consulta SQL para obtener los nombres
                    string consulta = $"select top 1 IdInventario from Inventario where IdUsuario = {IdUsuario} order by IdInventario desc;";

                    // Adaptador de datos
                    SqlCommand command = new SqlCommand(consulta, conexion);

                    // Llenar el DataTable con el id de la base de datos más reciente
                    DataTable table = new DataTable();
                    string IInventa = "";
                    table.Load(command.ExecuteReader());

                    foreach (DataRow r in table.Rows)
                    {
                        IInventa = r["IdInventario"].ToString();
                    }

                    int IdInventa = Convert.ToInt32(IInventa);

                    string consulta2 = $"select * from Producto where IdUsuario = {IdUsuario};";

                    // Adaptador de datos
                    SqlCommand command2 = new SqlCommand(consulta2, conexion);

                    // Llenar el DataTable con el id de la base de datos más reciente
                    DataTable table2 = new DataTable();
                    table2.Load(command2.ExecuteReader());

                    DateTime fechaSurtido;

                    if (fileExel.HasFile)
                    {
                        string fileName = Path.GetFileName(fileExel.PostedFile.FileName);
                        string filePath = Server.MapPath("~/UploadedFiles/" + fileName);
                        fileExel.SaveAs(filePath);

                        // Leer datos desde el archivo Excel
                        DataTable dt = ReadExcelFile(filePath);

                        if (dt.Rows.Count > 0)  // Verifica si hay datos en el archivo Excel
                        {
                            foreach (DataRow r2 in dt.Rows)
                            {
                                foreach (DataRow r3 in table2.Rows)
                                {
                                    if (r2["Codigo"].ToString() == r3["Codigo"].ToString())
                                    {
                                        fechaSurtido = Convert.ToDateTime(r2["Ultimo_Surtido"].ToString());
                                        InventarioDetalle_Model modelo2 = new InventarioDetalle_Model()
                                        {
                                            IdInventario = IdInventa,
                                            IdUsuario = IdUsuario,
                                            Codigo = r2["Codigo"].ToString(),
                                            Descripcion = r3["Descripcion"].ToString(),
                                            Tipo_Producto = r3["Tipo_Producto"].ToString(),
                                            InvInicial = Convert.ToInt32(r2["InvInicial"].ToString()),
                                            InvFinal = Convert.ToInt32(r2["InvFinal"].ToString()),
                                            Mermas = Convert.ToInt32(r2["Mermas"].ToString()),
                                            MotivoMermas = r2["MotivoMermas"].ToString(),
                                            Fecha_Ultimo_Surtido = fechaSurtido.ToString("yyyy-MM-dd"),
                                        };

                                        admin.Agregar_InventarioDetalle(modelo2);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MostrarMensajeError("El archivo Excel está vacío. Por favor, seleccione un archivo válido.");
                        }

                        conexion.Close();
                    }
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
