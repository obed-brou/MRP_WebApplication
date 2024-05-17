using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Proyecto.Modelo
{
    public class ListaDetalle_Model
    {
        public int IdLista { get; set; }

        public int IdUsuario { get; set; }

        public string Codigo { get; set; }

        public float Precio { get; set; }
    }
}