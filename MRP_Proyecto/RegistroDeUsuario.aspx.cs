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
    public partial class RegistroDeUsuario : System.Web.UI.Page
    {
        Movimientos admin = new Movimientos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario_Model modelo = new Usuario_Model()
            {
                Usuario = tbUsuario.Text,
                Password = tbContraseña.Text,
                Tipo = ddlTipoUsuario.Text,
                Nombre = tbNombreUs.Text
            };

            admin.Crear_Usuario(modelo);

            Response.Redirect("Login.aspx");
        }
    }
}