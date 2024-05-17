using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Proyecto.Modelo
{
    public class InventarioDetalle_Model
    {
        public int IdInventario{ get; set; }

        public int IdUsuario { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public string Tipo_Producto { get; set; }

        public float InvInicial { get; set; }

        public float InvFinal { get; set; }

        public float Mermas { get; set; }

        public string MotivoMermas { get; set; }

        public string Fecha_Ultimo_Surtido { get; set; }
    }
}