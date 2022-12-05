using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Agregar...
using ProyConsultora_BL;
using ProyConsultora_BE;
using System.Data;

namespace SitioWEB_ConsultoraGUI.Consultas
{

    public partial class WebAsignacionProyecto : System.Web.UI.Page
    {
        // Instancias ...
        ProyectoBL objProyectoBL = new ProyectoBL();
        ProyectoBE objProyectoBE = new ProyectoBE();
        AsignacionBL objAsignacionBL = new AsignacionBL();
        AreaBL objAreaBL = new AreaBL();

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
                //Buscamos el proyecto...
                objProyectoBE = objProyectoBL.ConsultarProyecto(txtCod.Text.Trim());

                //Validamos la existencia del proyecto 
                if (objProyectoBE.Nom_Proy == null)
                {
                    txtNombre.Text = String.Empty;
                    cboArea.SelectedValue = String.Empty;
                    txtTip.Text = String.Empty;
                    txtEstado.Text = String.Empty;
                    txtPresu.Text = String.Empty;
                    lblRegistros.Text = String.Empty;
                    btnConsultar.Enabled = false;
                    //Mandamos el mensaje respectivo

                    throw new Exception("Codigo de cliente no existe");

                }
                else
                {
                    txtNombre.Text = objProyectoBE.Nom_Proy;
                    String strCodArea = objProyectoBE.Cod_Area;

                    CargarArea(strCodArea);
                    //cboArea.Enabled = false;
                    //txtArea.Text=cboArea.Text ;
                    //Estado
                    if (objProyectoBE.Estado == 0)
                    {
                        txtEstado.Text = "Programado";
                    }
                    else if (objProyectoBE.Estado == 1)
                    {
                        txtEstado.Text = "En ejecucion";
                    }
                    else if (objProyectoBE.Estado == 2)
                    {
                        txtEstado.Text = "Detenido";
                    }
                    else if (objProyectoBE.Estado == 3)
                    {
                        txtEstado.Text = "Cancelado";
                    }
                    else if (objProyectoBE.Estado == 4)
                    {
                        txtEstado.Text = "Finalizado";
                    }
                    //tipo

                    if (objProyectoBE.Tip_Proy == "1")
                    {
                        txtTip.Text = "Facturable recurrente";
                    }
                    else if (objProyectoBE.Tip_Proy == "2")
                    {
                        txtTip.Text = "Facturable no recurrente";
                    }
                    else if (objProyectoBE.Tip_Proy == "3")
                    {
                        txtTip.Text = "Por horas trabajadas";
                    }
                    else if (objProyectoBE.Tip_Proy == "4")
                    {
                        txtTip.Text = "No Facturable";
                    }

                    Single sngPresu = Convert.ToSingle(objProyectoBE.Imp_Imp_Estm);
                    txtPresu.Text = "S/. " + sngPresu.ToString("#,###,##0.00");
                    btnConsultar.Enabled = true;
                    lblRegistros.Text = String.Empty;
                }

            }
            catch (Exception ex)
            {

                lblMensajePopup.Text = "Error: " + ex.Message;
                PopMensaje.Show();

            }
        }
        private void CargarArea(String area)
        {
            // Combos de ubigeo para el CRUD del proveedor

            DataTable dt = objAreaBL.ListarArea();

            cboArea.DataSource = dt;
            cboArea.DataTextField = "Nom_Area";
            cboArea.DataValueField = "Cod_Area";
            cboArea.DataBind();
            cboArea.SelectedValue = area;
            
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                grvAsignaciones.DataSource = objAsignacionBL.ListarAsignacionesProyectosFechas(txtCod.Text.Trim(),
                                             Convert.ToDateTime(txtFecIni.Text.Trim()),Convert.ToDateTime(txtFecFin.Text.Trim()));
                grvAsignaciones.DataBind();
                lblRegistros.Text = "Cantidad de Asignaciones" + grvAsignaciones.Rows.Count.ToString();
                
                          
            }
            catch(Exception ex)
            {
                lblMensajePopup.Text="Error: "+ex.Message;
                PopMensaje.Show();
            }
        }
    }
}