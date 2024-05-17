using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using NPOI.XWPF.UserModel;
using ClosedXML.Excel;
using System.Web.UI.WebControls;
using System.Data;
using MRP_Proyecto.Modelo;
using MRP_Proyecto.Datos;
using NPOI.Util;
using static NPOI.HSSF.Util.HSSFColor;

namespace MRP_Proyecto
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                string consulta0 = $"select top 1 IdInventario from InventarioDetalle where IdUsuario = {IdUsuario} order by IdInventario desc;";

                // Adaptador de datos
                SqlCommand command0 = new SqlCommand(consulta0, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table0 = new DataTable();
                string ILista = "";
                table0.Load(command0.ExecuteReader());
                foreach (DataRow r in table0.Rows)
                {
                    ILista = r["IdInventario"].ToString();
                }

                int IdLista = 0;

                if (ILista != "")
                {
                    IdLista = Convert.ToInt32(ILista);
                }
                

                // Consulta SQL para obtener los nombres
                string consulta = $"select Codigo, Descripcion, InvFinal, Ultimo_Surtido from InventarioDetalle where IdInventario = {IdLista} and InvFinal <= 60 and Tipo_Producto = 'Insumo' and IdUsuario = {IdUsuario};";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());

                string Codigo = "";

                foreach (DataRow r in table0.Rows)
                {
                    Codigo = r["IdInventario"].ToString();
                }

                if (Codigo != "")
                {
                    Label1.Visible = true;
                }

                gvProductosFaltantes.DataSource = table;
                gvProductosFaltantes.DataBind();

                conexion.Close();
            }
        }
    }
}