using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Proyecto.Modelo
{
    public class Cliente_Model
    {
        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public int IdLista { get; set; }
    }
}