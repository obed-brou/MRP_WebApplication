using NPOI.XWPF.UserModel;
using System;
using System.Drawing.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MRP_Proyecto.Modelo;
using System.Data.SqlClient;
using MRP_Proyecto.Datos;
using System.Security.Cryptography;
using System.Net;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Table = iText.Layout.Element.Table;
using Paragraph = iText.Layout.Element.Paragraph;
using Document = iTextSharp.text.Document;
using iText.IO.Font;
using System.Drawing;

namespace MRP_Proyecto
{
    public partial class GenerarPlanificacion : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarInfoPedidos();
        }


        protected void btnPlanificacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbPedido.Text))
                {
                    MostrarMensajeError("Por favor, ingrese el número de pedido.");
                    return;
                }
                // Conexión a la base de datos
                string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();
                DataTable dt7 = new DataTable();
                DataTable dt8 = new DataTable();
                DataTable dtFinal = new DataTable();

                int TiempoExtra = 0;
                int TiempoTotal = 0;
                int TiempoFinal = 0;

                string[] arreglo = new string[1000];
                int n = 0;
                arreglo[n] = "Hola";

                dtFinal.Columns.Add("Producto");
                dtFinal.Columns.Add("Pedido");
                dtFinal.Columns.Add("Inventario");
                dtFinal.Columns.Add("Faltante");
                dtFinal.Columns.Add("Tiempo");

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT IdPedido, IdCliente, Fecha FROM Pedido where IdPedido = {tbPedido.Text} and IdUsuario = {IdUsuario}";


                SqlCommand command = new SqlCommand(consulta, conexion);

                string IdPedido = "";
                int IdCliente = 0;
                string FechaPedido = "";
                dt.Load(command.ExecuteReader());

                foreach (DataRow r in dt.Rows)
                {

                    IdPedido = r["IdPedido"].ToString();
                    IdCliente = Convert.ToInt32(r["IdCliente"].ToString());
                    FechaPedido = r["Fecha"].ToString();

                    lblFecha.Text = lblFecha.Text + " " + FechaPedido;

                    string consulta2 = $"SELECT Nombre FROM Cliente where IdCliente = {IdCliente} and IdUsuario = {IdUsuario}";


                    SqlCommand command2 = new SqlCommand(consulta2, conexion);


                    dt2.Load(command2.ExecuteReader());


                    string Cliente = "";

                    foreach (DataRow r2 in dt2.Rows)
                    {
                        Cliente = r2["Nombre"].ToString();
                    }

                    lblCliente.Text = lblCliente.Text + " " + Cliente;



                    string consulta3 = $"SELECT Codigo, Cantidad FROM PedidoDetalle where IdPedido = {IdPedido} and IdUsuario = {IdUsuario}";


                    SqlCommand command3 = new SqlCommand(consulta3, conexion);


                    dt3.Load(command3.ExecuteReader());


                    string Codigo = "";
                    int Cantidad = 0;

                    foreach (DataRow r3 in dt3.Rows)
                    {
                        DataRow row = dtFinal.NewRow();
                        int InventarioProducto = 0;
                        int Faltante = 0;
                        int TiempoFabricacion = 1;
                        

                        Codigo = r3["Codigo"].ToString();
                        Cantidad = Convert.ToInt32(r3["Cantidad"].ToString());

                        row["Producto"] = Codigo;
                        row["Pedido"] = Cantidad;

                        string consulta4 = $"SELECT Top 1 InvFinal FROM InventarioDetalle where Codigo = '{Codigo}' and IdUsuario = {IdUsuario} order by IdInventario desc";


                        SqlCommand command4 = new SqlCommand(consulta4, conexion);


                        dt4.Load(command4.ExecuteReader());

                        foreach (DataRow r4 in dt4.Rows)
                        {
                            InventarioProducto = Convert.ToInt32(r4["InvFinal"].ToString());
                        }

                        row["Inventario"] = InventarioProducto;


                        if (InventarioProducto < Cantidad) 
                        {
                            int IdReceta = 0;
                            int CantidadReceta = 0;
                            int TiempoReceta = 0;
                            int nInsu = 1;

                            Faltante = Cantidad - InventarioProducto;


                            string consulta5 = $"SELECT IdReceta, TiempoFabricacion_dias, Cantidad FROM Recetas where Codigo = '{Codigo}' and IdUsuario = {IdUsuario}";


                            SqlCommand command5 = new SqlCommand(consulta5, conexion);


                            dt5.Load(command5.ExecuteReader());

                            foreach (DataRow r5 in dt5.Rows)
                            {
                                IdReceta = Convert.ToInt32(r5["IdReceta"].ToString());
                                TiempoReceta = Convert.ToInt32(r5["TiempoFabricacion_dias"].ToString());
                                CantidadReceta = Convert.ToInt32(r5["Cantidad"].ToString());
                            }

                            if (CantidadReceta < Faltante)
                            {
                                int CantidadRec = 0;
                                int TiempoRec = 0;
                                nInsu = 0;

                              for(int i = 0; i < 4; i++)
                                {
                                    i = 0;
                                    CantidadRec = CantidadRec + CantidadReceta;
                                    TiempoRec = TiempoRec + TiempoReceta;
                                    nInsu = nInsu + 1;

                                    if(Faltante <= CantidadRec)
                                    {
                                        i = 56;
                                    }
                                }
                              CantidadReceta = CantidadRec;
                              TiempoReceta = TiempoRec;
                            }


                            TiempoFabricacion = TiempoReceta;


                            int CantidadInsumo = 0;
                            string CodigoInsumo = "";
                            string UltimoSurtido = "";
                            int TiempoEspera = 0;


                            string consulta6 = $"SELECT Codigo, Cantidad FROM InsumosRecetas where IdReceta = {IdReceta} and IdUsuario = {IdUsuario}";


                            SqlCommand command6 = new SqlCommand(consulta6, conexion);


                            dt6.Load(command6.ExecuteReader());


                            foreach (DataRow r6 in dt6.Rows)
                            {
                                int InventarioInsumo = 0;
                                string USurtidoInsu = "";

                                CodigoInsumo = r6["Codigo"].ToString();
                                CantidadInsumo = Convert.ToInt32(r6["Cantidad"].ToString());

                                CantidadInsumo = CantidadInsumo * nInsu;

                                string consulta7 = $"SELECT top 1 InvFinal, Ultimo_Surtido FROM InventarioDetalle where Codigo = '{CodigoInsumo}' and IdUsuario = {IdUsuario} order by IdInventario desc";


                                SqlCommand command7 = new SqlCommand(consulta7, conexion);


                                dt7.Load(command7.ExecuteReader());


                                foreach (DataRow r7 in dt7.Rows)
                                {
                                    InventarioInsumo = Convert.ToInt32(r7["InvFinal"].ToString());
                                    UltimoSurtido = r7["Ultimo_Surtido"].ToString();
                                }

                                if (InventarioInsumo < CantidadInsumo)
                                {
                                    string consulta8 = $"SELECT TiempoEspera FROM Producto where Codigo = '{CodigoInsumo}' and IdUsuario = {IdUsuario}";


                                    SqlCommand command8 = new SqlCommand(consulta8, conexion);


                                    dt8.Load(command8.ExecuteReader());

                                    foreach (DataRow r8 in dt8.Rows)
                                    {
                                        TiempoEspera = Convert.ToInt32(r8["TiempoEspera"].ToString());
                                    }


                                    for (int i = 0; i < arreglo.Length; i++)
                                    {
                                        if (arreglo[i] == CodigoInsumo)
                                        {
                                            i = 1010;
                                        }

                                        if (string.IsNullOrEmpty(arreglo[i]))
                                        {
                                            int iDiaU;
                                            int iMesU;

                                            int iDiaA;
                                            int iMesA;

                                            int iDiaP;
                                            int iMesP;

                                            int l;

                                            arreglo[i] = CodigoInsumo;
                                            i = 1010;

                                            DateTime fechaSeleccionada = Convert.ToDateTime(UltimoSurtido);
                                            string FechaUSurtido = fechaSeleccionada.ToString("dd-MM-yyyy");

                                            DateTime fechaSeleccionada2 = DateTime.Now;
                                            string FechaActual = fechaSeleccionada2.ToString("dd-MM-yyyy");

                                            string[] partesFecha = FechaUSurtido.Split('-');

                                                iDiaU = Convert.ToInt32(partesFecha[0]);
                                                iMesU = Convert.ToInt32(partesFecha[1]);

                                            string[] partesFecha2 = FechaActual.Split('-');

                                                iDiaA = Convert.ToInt32(partesFecha2[0]);
                                                iMesA = Convert.ToInt32(partesFecha2[1]);

                                            iDiaP = iDiaU + TiempoEspera;
                                            iMesP = iMesU;

                                            if(iMesU == 1 && iDiaP > 31 || iMesU == 3 && iDiaP > 31 || iMesU == 5 && iDiaP > 31 || iMesU == 7 && iDiaP > 31 || iMesU == 8 && iDiaP > 31 || iMesU == 10 && iDiaP > 31 || iMesU == 12 && iDiaP > 31)
                                            {
                                                iDiaP = iDiaP - 31;
                                                iMesP = iMesP + 1;

                                                if (iDiaA > iDiaP)
                                                {
                                                    l = 31 - iDiaA;
                                                    TiempoExtra = TiempoExtra + l;
                                                }

                                                if (iDiaA < iDiaP)
                                                {
                                                    l = iDiaP - iDiaA;
                                                    TiempoExtra = TiempoExtra + l;
                                                }
                                            }


                                            if (iMesU == 2 && iDiaP > 29)
                                            {
                                                iDiaP = iDiaP - 29;
                                                iMesP = iMesP + 1;

                                                if (iDiaA > iDiaP)
                                                {
                                                    l = 29 - iDiaA;
                                                    TiempoExtra = TiempoExtra + l;
                                                }

                                                if (iDiaA < iDiaP)
                                                {
                                                    l = iDiaP - iDiaA;
                                                    TiempoExtra = TiempoExtra + l;
                                                }
                                            }


                                            if (iMesU == 4 && iDiaP > 30 || iMesU == 6 && iDiaP > 30 || iMesU == 9 && iDiaP > 30 || iMesU == 11 && iDiaP > 30)
                                            {
                                                iDiaP = iDiaP - 30;
                                                iMesP = iMesP + 1;

                                                if (iDiaA > iDiaP)
                                                {
                                                    l = 30 - iDiaA;
                                                    TiempoExtra = TiempoExtra + l;
                                                }

                                                if (iDiaA < iDiaP)
                                                {
                                                    l = iDiaP - iDiaA;
                                                    TiempoExtra = TiempoExtra + l;
                                                }
                                            }


                                            if (iMesU == iMesP)
                                            {
                                                l = iDiaP - iDiaA;
                                                TiempoExtra = TiempoExtra + l;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        row["Faltante"] = Faltante;
                        row["Tiempo"] = TiempoFabricacion;
                        dtFinal.Rows.Add(row);

                        TiempoTotal = TiempoTotal + TiempoFabricacion;

                    }

                    TiempoFinal = TiempoTotal + TiempoExtra;

                    lblExtra.Text = lblExtra.Text + " " + TiempoExtra.ToString();
                    lblTiempo.Text = lblTiempo.Text + " " + TiempoTotal.ToString();
                    lblEntrega.Text = lblEntrega.Text + " " + TiempoFinal.ToString();

                    gvPlanificacion.DataSource = dtFinal;
                    gvPlanificacion.DataBind();
                }

                conexion.Close();
            }
                MostrarMensajeExito("Operación de planificación realizada con éxito.");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Ajusta esto según tus necesidades
                MostrarMensajeError("Ocurrió un error al procesar la solicitud. Detalles: " + ex.Message);
            }
        }

        private void MostrarMensajeExito(string mensaje)
        {
            // Implementa la lógica para mostrar un mensaje de éxito,
            // por ejemplo, en un Label llamado lblMensajeExito.
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
        }

        private void MostrarMensajeError(string mensaje)
        {
            // Implementa la lógica para mostrar un mensaje de error,
            // por ejemplo, en un Label llamado lblMensajeError.
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
        }
        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            // Obtener la ruta del escritorio del usuario
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Buscar la ruta de Arial-Bold.ttf
            string fontPath = BuscarFuenteArialBold();

            if (fontPath != null)
            {
                // Crear el documento PDF
                string filePath = Path.Combine(desktopPath, "Planeacion.pdf");
                iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter(filePath);
                iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer);
                iText.Layout.Document document = new iText.Layout.Document(pdf);

                // Agregar el título "Planeacion"
                document.Add(new Paragraph("Planeacion")
                     .SetFont(iText.Kernel.Font.PdfFontFactory.CreateFont(fontPath, iText.IO.Font.PdfEncodings.IDENTITY_H))
                    .SetFontSize(18)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .Add("\n\n\n\n"));

                // Agregar la información de los labels
                AgregarInformacionLabel(document, lblCliente);
                AgregarInformacionLabel(document, lblFecha);
                AgregarInformacionLabel(document, lblTiempo);
                AgregarInformacionLabel(document, lblExtra);
                AgregarInformacionLabel(document, lblEntrega);


                AgregarInformacionGridView(document, gvPlanificacion);

                // Cerrar el documento
                document.Close();
            }
        }

        private string BuscarFuenteArialBold()
        {
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            FontFamily[] fonts = installedFonts.Families;

            // Buscar Arial-Bold.ttf en ubicaciones comunes
            string[] possiblePaths = {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arialbd.ttf"), // Windows
            "/usr/share/fonts/truetype/dejavu/DejaVuSans-Bold.ttf" // Ubicación común en sistemas Unix
        };

            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    return path;
                }
            }


            return null; // No se encontró Arial-Bold.ttf
        }

        private void AgregarInformacionGridView(iText.Layout.Document document, System.Web.UI.WebControls.GridView gridView)
        {
            // Verificar si el GridView tiene datos
            if (gridView.Rows.Count > 0)
            {
                // Crear una tabla para el GridView
                iText.Layout.Element.Table table = new iText.Layout.Element.Table(gridView.Columns.Count);

                // Agregar encabezados de columna
                foreach (System.Web.UI.WebControls.DataControlField column in gridView.Columns)
                {
                    table.AddHeaderCell(new iText.Layout.Element.Cell().Add(new Paragraph(column.HeaderText)));
                }

                // Agregar filas y celdas
                foreach (System.Web.UI.WebControls.GridViewRow row in gridView.Rows)
                {
                    foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                    {
                        table.AddCell(new iText.Layout.Element.Cell().Add(new Paragraph(cell.Text)));
                    }
                }

                // Agregar la tabla al documento
                document.Add(table);

                // Agregar saltos de línea después de la tabla
                document.Add(new Paragraph("\n\n"));
            }
        }


        private void AgregarInformacionLabel(iText.Layout.Document document, Label label)
        {
            // Agregar el texto del label al documento con saltos de línea
            document.Add(new Paragraph(label.Text).Add("\n\n"));
        }


        private void CargarInfoPedidos()
        {
            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                DataTable dt = new DataTable();
                dt.Columns.Add("Id del Pedido");
                dt.Columns.Add("Cliente");
                dt.Columns.Add("Fecha");

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT IdPedido, IdCliente, Fecha FROM Pedido where EstadoPedido = 'Activo' and IdUsuario = {IdUsuario}";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                string IdPedido = "";
                int IdCliente = 0;
                string Fecha = "";
                table.Load(command.ExecuteReader());

                foreach (DataRow r in table.Rows)
                {
                    IdPedido = r["IdPedido"].ToString();
                    IdCliente = Convert.ToInt32(r["IdCliente"].ToString());
                    Fecha = r["Fecha"].ToString();



                    string consulta2 = $"SELECT Nombre FROM Cliente where IdCliente = {IdCliente} and IdUsuario = {IdUsuario}";


                    SqlCommand command2 = new SqlCommand(consulta2, conexion);

                    // Llenar el DataTable con el id de la base de datos mas reciente
                    DataTable table2 = new DataTable();


                    table2.Load(command2.ExecuteReader());


                    string Cliente = "";

                    foreach (DataRow r2 in table2.Rows)
                    {
                        Cliente = r2["Nombre"].ToString();
                    }

                    // Crear una nueva fila con los valores
                    DataRow dr = dt.NewRow();
                    dr["Id del Pedido"] = IdPedido;
                    dr["Cliente"] = Cliente;
                    dr["Fecha"] = Fecha;

                    // Agregar la fila al DataTable
                    dt.Rows.Add(dr);
                    gvPedidosExistentes.DataSource = dt;
                    gvPedidosExistentes.DataBind();
                }

                conexion.Close();
            }
        }
    }
}