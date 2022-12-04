using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Agregar...
using ProyConsultora_BL;
using ProyConsultora_BE;
namespace SitioWEB_ConsultoraGUI.Consultas
{
    
    public partial class WebAsignacionProyecto : System.Web.UI.Page
    {
        // Instancias ...
        ProyectoBL objClienteBL = new ProyectoBL();
        ProyectoBE objClienteBE = new ProyectoBE();
        AsignacionBL objFacturaBL = new AsignacionBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                // El boton btnConsultar se inicia desactivado....
                btnConsultar.Enabled = false;
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //Codifique

            }
            catch (Exception ex)
            {

                lblMensajePopup.Text = "Error: " + ex.Message;
                PopMensaje.Show();

            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // Codifique
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = "Error: " + ex.Message;
                PopMensaje.Show();
            }
        }
    }
}