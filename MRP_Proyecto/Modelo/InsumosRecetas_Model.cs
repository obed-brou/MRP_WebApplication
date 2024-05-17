using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Proyecto.Modelo
{
    public class InsumosRecetas_Model
    {
        public int IdReceta { get; set; }

        public int IdUsuario { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public string UnidadMedida { get; set; }
    }
}