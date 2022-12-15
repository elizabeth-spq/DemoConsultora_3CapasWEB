using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Agregar
using ProyConsultora_BL;
using System.IO;

namespace SitioWEB_ConsultoraGUI.Transacciones
{
    public partial class WebListarAsignaciones : System.Web.UI.Page
    {
        AsignacionBL objAsignacionBL = new AsignacionBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();

            }
            catch (Exception ex)
            {

                lblMensajePopup.Text = "Error: " + ex.Message;
                PopMensaje.Show();
            }

        }
        private void CargarDatos()
        {
            grvASIG.DataSource = objAsignacionBL.ListarAsignacion();
            grvASIG.DataBind();
        }

        protected void grvASIG_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvASIG.PageIndex = e.NewPageIndex;
            CargarDatos();
        }

        protected void grvASIG_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //Obtenemos la fila donde se hizo click en el boton descargar
                Int16 fila = Convert.ToInt16(e.CommandArgument);

                //Si se invoco a la columna Descargar
                if(e.CommandName == "Descargar")
                {
                    //Se obtiene el nombre de archivo a descargar
                    String strNomArchivo = grvASIG.Rows[fila].Cells[0].Text + ".pdf";

                    //Obtenemos la ruta del archivo de la carpeta Proformas
                    String strRuta = Server.MapPath("/") + @"Proformas\" + strNomArchivo;
                    if(File.Exists(strRuta)==true)
                    {
                        //Se codifica los eventos en el cliente para la descarga del archivo
                        /*
                        Response.Clear();

                        Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", strNomArchivo));
                        Response.ContentType = "application/octet-stream";

                        Response.WriteFile(Server.MapPath("/") + @"∼/Proformas" + strNomArchivo);
                        Response.End();
                        */

                        Response.Clear();

                        Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", strNomArchivo));
                        Response.ContentType = "application/octet-stream";

                        Response.WriteFile(Server.MapPath(Path.Combine("~/Proformas", strNomArchivo)));
                        Response.End();
                    }
                    else
                    {
                        throw new Exception("Archivo no existe");
                    }
                }

            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = "Error: " + ex.Message;
                PopMensaje.Show();
            }
        }
    }
}