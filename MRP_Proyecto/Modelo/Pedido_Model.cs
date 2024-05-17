using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Proyecto.Modelo
{
    public class Pedido_Model
    {
        public int IdUsuario { get; set; }

        public int IdCliente { get; set; }

        public string Fecha { get; set; }

        public string EstadoPedido { get; set; }
    }
}