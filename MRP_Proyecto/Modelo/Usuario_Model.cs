using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRP_Proyecto.Modelo
{
    public class Usuario_Model
    {
        public int IdUsuario { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public string Tipo { get; set; }

        public string Nombre { get; set; }
    }
}