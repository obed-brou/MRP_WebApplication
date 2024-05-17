using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRP_Proyecto.Datos
{
    public class Conexion
    {
        protected SqlConnection cnn;

        protected void Conectar()
        {

            string nombreArchivo = "MRP_Inventarios.mdf";
            string rutaRelativa = "~/App_Data/" + nombreArchivo; // Cambia esto según la ubicación real de tu archivo

            HttpContext contexto = HttpContext.Current;

            string rutaFisica = contexto.Server.MapPath(rutaRelativa);


            try
            {
                cnn = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={rutaFisica}");
                cnn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        protected void Desconectar()
        {
            try
            {
                cnn.Close();
                cnn.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}