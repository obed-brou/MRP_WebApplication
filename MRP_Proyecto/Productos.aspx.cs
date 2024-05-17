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
    public partial class Productos : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarNombresComboBoxProveedor();
                CargarInfoDataGridProductos();
            }
        }
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if(tbCodigo.Text == "")
            {
                Panel2.Visible = true;
                return;
            }

            if (tbDescripcion.Text == "")
            {
                Panel2.Visible = true;
                return;
            }

            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"select IdProveedor from Proveedor where Nombre = '{comboboxProveedor.Text}' and IdUsuario = {IdUsuario};";

                // Adaptador de datos
                SqlCommand command = new SqlCommand(consulta, conexion);
                // Llenar el DataTable con los nombres de la base de datos
                DataTable table = new DataTable();
                string Proveedor = "";
                table.Load(command.ExecuteReader());
                foreach (DataRow r in table.Rows)
                {
                    Proveedor = r["IdProveedor"].ToString();
                }

                int idProveedor = Convert.ToInt32(Proveedor);

                if(cbTipo.Text == "Insumo")
                {
                      if (tbTiempoEspera.Text == "")
                     {
                        Panel2.Visible = true;
                        return;
                     }

                    Producto_Model modelo = new Producto_Model()
                    {
                        Codigo = tbCodigo.Text,
                        IdUsuario = IdUsuario,
                        Tipo_Producto = cbTipo.Text,
                        Descripcion = tbDescripcion.Text,
                        IdProveedor = idProveedor,
                        TiempoEspera = Convert.ToInt32(tbTiempoEspera.Text),
                        UnidadMedida = cbUnidad.Text
                    };

                    admin.Agregar_Producto(modelo);

                    Panel1.Visible = true;

                    CargarInfoDataGridProductos();
                }

                if (cbTipo.Text == "Producto")
                {
                    Producto_Model modelo = new Producto_Model()
                    {
                        Codigo = tbCodigo.Text,
                        IdUsuario = IdUsuario,
                        Tipo_Producto = cbTipo.Text,
                        Descripcion = tbDescripcion.Text,
                        UnidadMedida = cbUnidad.Text
                    };

                    admin.Agregar_Producto(modelo);

                    Panel1.Visible = true;

                    CargarInfoDataGridProductos();
                }
            }
        }

        protected void btnRegistrarProveedor_Click(object sender, EventArgs e)
        {
            int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

            if (tbProveedor.Text == "")
            {
                lblProveedor.Visible = true;
            }

            else
            {
                Proveedor_Model modelo = new Proveedor_Model()
                {
                    IdUsuario = IdUsuario,
                    Nombre = tbProveedor.Text
                };

                admin.Crear_Proveedor(modelo);

                lblProveedor.Visible = false;
                tbProveedor.Text = "";

                tbProveedor.Enabled = false;
                btnRegistrarProveedor.Enabled = false;
                cbProveedor.Checked = false;

                CargarNombresComboBoxProveedor();
            }
        }

        protected void cbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if(cbProveedor.Checked == true)
            {
                tbProveedor.Enabled = true;
                btnRegistrarProveedor.Enabled = true;
            }

            if (cbProveedor.Checked == false)
            {
                tbProveedor.Enabled = false;
                btnRegistrarProveedor.Enabled = false;
            }
        }

        private void CargarNombresComboBoxProveedor()
        {
            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT Nombre FROM Proveedor where IdUsuario = {IdUsuario}";

                // Adaptador de datos
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);

                // DataTable para almacenar los nombres
                DataTable datos = new DataTable();

                // Llenar el DataTable con los nombres de la base de datos
                adaptador.Fill(datos);

                // Enlazar los nombres al ComboBoxProveedor
                comboboxProveedor.DataTextField = "Nombre"; // Nombre del campo que se mostrará
                comboboxProveedor.DataValueField = "Nombre"; // Puedes establecer el campo que quieres usar como valor, si es necesario
                comboboxProveedor.DataSource = datos;
                comboboxProveedor.DataBind();
            }
        }

        private void CargarInfoDataGridProductos()
        {
            // Conexión a la base de datos
            string cadenaConexion = Session["Conexion"].ToString(); // Reemplaza con tu cadena de conexión
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                int IdUsuario = Convert.ToInt32(Session["UsuarioId"].ToString());

                // Consulta SQL para obtener los nombres
                string consulta = $"SELECT * FROM Producto where IdUsuario = {IdUsuario}";


                SqlCommand command = new SqlCommand(consulta, conexion);

                // Llenar el DataTable con el id de la base de datos mas reciente
                DataTable table = new DataTable();

                table.Load(command.ExecuteReader());

                gvProductos.DataSource = table;
                gvProductos.DataBind();

                conexion.Close();
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;

            if (cbTipo.Text == "Insumo")
            {
                lblCodigo.Visible = true;
                tbCodigo.Visible=true;
                lblDescripcion.Visible = true;
                tbDescripcion.Visible = true;
                lblUnidad.Visible = true;
                cbUnidad.Visible = true;
                lblProv.Visible = true;
                tbProveedor.Visible = true;
                cbProveedor .Visible = true;
                comboboxProveedor.Visible=true;
                lblEspera.Visible = true;
                btnRegistrarProveedor.Visible = true;
                tbTiempoEspera.Visible = true;
            }

            if (cbTipo.Text == "Producto")
            {
                lblCodigo.Visible = true;
                tbCodigo.Visible = true;
                lblDescripcion.Visible = true;
                tbDescripcion.Visible = true;
                lblUnidad.Visible = true;
                cbUnidad.Visible = true;
                lblProv.Visible = false;
                tbProveedor.Visible = false;
                cbProveedor.Visible = false;
                comboboxProveedor.Visible = false;
                lblEspera.Visible = false;
                btnRegistrarProveedor.Visible = false;
                tbTiempoEspera.Visible = false;
            }
        }
    }
}