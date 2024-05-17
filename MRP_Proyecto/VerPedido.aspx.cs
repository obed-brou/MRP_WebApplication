using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRP_Proyecto
{
    public partial class VerPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltrarActivo_Click(object sender, EventArgs e)
        {

        }

        protected void btnFiltrarFinalizado_Click(object sender, EventArgs e)
        {

        }

        protected void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            // Verificar si el TextBox está vacío
            if (string.IsNullOrWhiteSpace(txtIdPedidoFinalizar0.Text))
            {
                MostrarMensajeError("Ingrese un valor para el Id del Pedido antes de finalizar.");
                return;  // Sale del evento si el TextBox está vacío
            }

            // El TextBox no está vacío, puedes proceder con el resto de la lógica
            int idPedido = Convert.ToInt32(txtIdPedidoFinalizar0.Text);

            // Resto de la lógica aquí...
        }

        private void MostrarMensajeError(string mensaje)
        {
            // Puedes implementar la lógica para mostrar un mensaje de error aquí,
            // por ejemplo, mostrarlo en un Label o en un cuadro de diálogo.
            // Asegúrate de tener un control en tu página para mostrar mensajes de error,
            // por ejemplo, un Label llamado lblMensajeError.
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
        }
    }
}