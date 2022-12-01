using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Agregamos...
using ProyConsultora_BE;
using ProyConsultora_BL;

namespace SitioWEB_ConsultoraGUI.Mantenimientos
{
    public partial class WebMantProyectos : System.Web.UI.Page
    {
        // Instancias...
        ProyectoBE objProyectoBE = new ProyectoBE();
        ProyectoBL objProyectoBL = new ProyectoBL();
        UbigeoBL objUbigeoBL = new UbigeoBL();
        DataView dtv;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {                                      
                    CargarDatos("");                
                }
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = "Error : " + ex.Message;
                PopMensaje.Show();
            }
            
        }
        private void CargarDatos(String strFiltro)
        {
            // Codifique
           
        }

        protected void btnFiltrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CargarDatos(txtFiltro.Text);

            }
            catch (Exception ex)
            {

                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }
     

        protected void grvProyectos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvProyectos.PageIndex = e.NewPageIndex;
            CargarDatos(txtFiltro.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                // Codifique

            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }
        private void CargarArea(Int16 intAccion,String IdDepa, String IdProv, String IdDist)
        {
            // Combos de ubigeo para el CRUD del proveedor
            if (intAccion == 1) // Combos de insercion
            {
                
            }
            else if (intAccion == 2) // Combos de actualizacion
            {
                

            }
        }

        protected void btnGrabar1_Click(object sender, EventArgs e)
        {
            try
            {
                //Codifique
            }
            catch (Exception ex)
            {
                lblMensaje1.Text = ex.Message;
                PopMan01.Show();// para mantener el popup abierto tras el clic en Grabar1
            }
        }

       protected void grvProyectos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                // Codifique

            
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }
        protected void cboArea1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGrabar2_Click(object sender, EventArgs e)
        {
            try
            {
                // Codifique
                
            }
            catch (Exception ex)
            {
                lblMensaje2.Text = ex.Message;
                PopMan02.Show();
            }
        }

        protected void grvProyectos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                // El evento recorre cada fila del grid cada vez que este se enlaza a su origen de datos
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Obtenemos el valor del campo  Estado de cada fila (celda 8 )
                    String estado = e.Row.Cells[8].Text;
                    // Si esta inactivo el color de la fuente (ForeColor) de la fila estara en rojo
                    if (estado == "Inactivo")
                    {
                        e.Row.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }
    }
}