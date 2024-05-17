using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Proyecto.Modelo
{
    public class Producto_Model
    {
        public string Codigo { get; set; }

        public int IdUsuario { get; set; }

        public string Tipo_Producto { get; set; }

        public string Descripcion { get; set; }

        public int IdProveedor { get; set; }

        public int TiempoEspera{ get; set; }

        public string UnidadMedida { get; set; }
    }
}