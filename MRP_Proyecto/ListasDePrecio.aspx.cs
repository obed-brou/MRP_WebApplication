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
    public partial class ListasDePrecio : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarInfoDataGridListas();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
          
        }


        protected void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (infExel.HasFile)
                {
                    // Verificar si el archivo es un archivo Excel
                    string extension = Path.GetExtension(infExel.FileName);
                    if (!string.IsNullOrEmpty(extension) && (extension.Equals(".xls") || extension.Equals(".xlsx")))
                    {
                        lblPProducto.Visible = true;
                        btnGuardar.Visible = true;

                        string fileName = Path.GetFileName(infExel.PostedFile.FileName);
                        string filePath = Server.MapPath("~/UploadedFiles/" + fileName);
                        infExel.SaveAs(filePath);

                        // Leer datos desde el archivo Excel
                        DataTable dt = ReadExcelFile(filePath);

                        // Mostrar datos en el GridView
                        gvPrecioProductos.DataSource = dt;
                        gvPrecioProductos.DataBind();
                    }
                    else
                    {
                        MostrarMensajeError("Por favor, seleccione un archivo Excel válido (.xls o .xlsx).");
                    }
                }
                else
                {
                    MostrarMensajeError("Por favor, seleccione un archivo antes de importar.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Puedes ajustar esto según tus necesidades
                MostrarMensajeError("Ocurrió un error al importar el archivo. Detalles: " + ex.Message);
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {

                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                Lista_Model modelo = new Lista_Model()
                {
                    IdUsuario = IdUsuario,  
                    Nombre = txtNLista.Text,
                    Comentario = txtComentarios.Text
                };

                admin.Agregar_Lista(modelo);

                // Consulta SQL para obtener los nombres
                string consulta = $"select top 1 IdLista from ListaPrecios where IdUsuario = {IdUsuario} order by IdLista desc;";

                // Adaptador de datos
                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();
                string ILista = "";
                table.Load(command.ExecuteReader());
                foreach (DataRow r in table.Rows)
                {
                    ILista = r["IdLista"].ToString();
                }

                int IdLista = Convert.ToInt32(ILista);

                for (int i = 0; i < gvPrecioProductos.Rows.Count; i++)
                {
                    ListaDetalle_Model modelo2 = new ListaDetalle_Model()
                    {
                        IdLista = IdLista,
                        IdUsuario = IdUsuario,
                        Codigo = gvPrecioProductos.Rows[i].Cells[0].Text,
                        Precio = Convert.ToInt32(gvPrecioProductos.Rows[i].Cells[1].Text)
                    };

                    admin.Agregar_ListaDetalle(modelo2);
                }
                conexion.Close();
            }
            CargarInfoDataGridListas();
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
                string consulta = $"SELECT Nombre_Lista,Comentarios FROM ListaPrecios  where IdUsuario = {IdUsuario};";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());

                gvListasRegistradas0.DataSource = table;
                gvListasRegistradas0.DataBind();

                conexion.Close();
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            if (tbLista.Text == "")
            {
                Panel2.Visible = true;
                return;
            }

            if (tbLista.Text != "")
            {
                Panel2.Visible = false;
            }

            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT IdLista FROM ListaPrecios where Nombre_Lista = '{tbLista.Text}' and IdUsuario = {IdUsuario}";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();

                string ILista = "";

                table.Load(command.ExecuteReader());

                foreach (DataRow r in table.Rows)
                {
                    ILista = r["IdLista"].ToString();
                }


                string consulta1 = $"SELECT Codigo, Precio FROM DetalleListaPrecio where IdLista = {ILista} and IdUsuario = {IdUsuario}";

                SqlCommand command2 = new SqlCommand(consulta1, conexion);

                table2.Load(command2.ExecuteReader());

                gvListaDetalle.DataSource = table2;
                gvListaDetalle.DataBind();

                conexion.Close();
            }
        }
    } 
}