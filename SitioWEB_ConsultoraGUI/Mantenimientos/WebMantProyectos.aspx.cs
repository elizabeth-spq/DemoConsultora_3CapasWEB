using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        AreaBL objAreaBL = new AreaBL();
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
            dtv = new DataView(objProyectoBL.ListarProyecto());
            dtv.RowFilter = "Nom_Proy like '%" + strFiltro + "%'";

            //Enlazamos el grid al dataview
            grvProyectos.DataSource = dtv;
            grvProyectos.DataBind();

            if (grvProyectos.Rows.Count == 0)
            {
                lblMensajePopup.Text = "No existen registros con el criterio ingresado";
                PopMensaje.Show();
            }

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
                //Limpiamos los controlles me PopMan01
                lblMensaje1.Text = String.Empty;
                txtNombre1.Text = String.Empty;
                CargarArea(1, "");
                rdbListTip1.SelectedValue = "3";
                rdbListEstado1.SelectedValue = "0";
                txtPresu1.Text = String.Empty;
                txtNombre1.Focus();
                PopMan01.Show();

            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }
        private void CargarArea(Int16 intAccion, String area)
        {
            // Combos de ubigeo para el CRUD del proveedor
            if (intAccion == 1) // Combos de insercion
            {
                DataTable dt = objAreaBL.ListarArea();
                DataRow dr;

                dr = dt.NewRow();
                dr["Cod_Area"] = "";
                dr["Nom_Area"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);
                cboArea1.DataSource = dt;
                cboArea1.DataTextField = "Nom_Area";
                cboArea1.DataValueField = "Cod_Area";
                cboArea1.DataBind();
                cboArea1.SelectedValue = area;

            }
            else if (intAccion == 2) // Combos de actualizacion
            {
                cboArea2.DataSource = objAreaBL.ListarArea();
                cboArea2.DataTextField = "Nom_Area";
                cboArea2.DataValueField = "Cod_Area";
                cboArea2.DataBind();
                cboArea2.SelectedValue = area;

            }
        }

        protected void btnGrabar1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validamos...
                if (txtNombre1.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre es obligatorio");
                }
                if (cboArea1.SelectedValue == "")
                {
                    throw new Exception("El área es obligatoria");
                }

                if (txtPresu1.Text.Trim() == String.Empty)
                {
                    throw new Exception("El presupuesto es obligatorio");
                }

                //Si todo está ok...
                objProyectoBE.Cod_Area = cboArea1.SelectedValue.ToString();
                objProyectoBE.Nom_Proy = txtNombre1.Text.Trim();
                objProyectoBE.Tip_Proy = rdbListTip1.SelectedValue;
                objProyectoBE.Usu_Registro = "pfrey";
                objProyectoBE.Imp_Imp_Estm = Convert.ToDouble(txtPresu1.Text.Trim());
                objProyectoBE.Estado = Convert.ToInt16(rdbListEstado1.SelectedValue);

                //invocamos al metodo insertar

                if (objProyectoBL.InsertarProyecto(objProyectoBE) == true)
                {
                    CargarDatos(txtFiltro.Text);
                }
                else
                {
                    throw new Exception("No se insertó registro, contate con TI");
                }
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
                //Obtenemos la fila del grid que se ha seleccionado
                Int16 fila = Convert.ToInt16(e.CommandArgument);
                //Validamos si el boton tiene el nombre Editar
                if (e.CommandName == "Editar")
                {
                    //Limpiamos el lblMensa2
                    lblMensaje2.Text = "";
                    //Obtenemos el codigo del proveedor de la celda 1 de la fila seleccionada
                    String strCod = grvProyectos.Rows[fila].Cells[1].Text;
                    //Obtenemos la instancia del cliente a actualizar
                    objProyectoBE = objProyectoBL.ConsultarProyecto(strCod);
                    //Mostramos el cliente en los controles del panel popMan2
                    //(popup para actualizar registro)

                    lblCod.Text = objProyectoBE.Cod_Proy;
                    txtNombre2.Text = objProyectoBE.Nom_Proy;
                    rdbListTip2.Text = objProyectoBE.Tip_Proy;
                    rdbListEstado2.Text = Convert.ToString(objProyectoBE.Estado);
                    txtPresu2.Text = Convert.ToString(objProyectoBE.Imp_Imp_Estm);

                    String Cod_Gru_Eco = objProyectoBE.Cod_Area;
                    CargarArea(2, Cod_Gru_Eco);
                    PopMan02.Show();
                }
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }
        protected void cboArea1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarArea(1, cboArea1.SelectedValue.ToString());
            PopMan01.Show();
        }

        protected void btnGrabar2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validamos...
                if (txtNombre2.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre es obligatorio");
                }
                if (cboArea2.SelectedValue == "")
                {
                    throw new Exception("El área es obligatoria");
                }

                if (txtPresu2.Text.Trim() == String.Empty)
                {
                    throw new Exception("El presupuesto es obligatorio");
                }

                //Si todo está ok...

                objProyectoBE.Cod_Proy = lblCod.Text;
                objProyectoBE.Nom_Proy = txtNombre2.Text.Trim();
                objProyectoBE.Cod_Area = cboArea2.SelectedValue.ToString();
                objProyectoBE.Tip_Proy = rdbListTip2.SelectedValue;
                objProyectoBE.Imp_Imp_Estm = Convert.ToDouble(txtPresu2.Text.Trim());
                objProyectoBE.Estado = Convert.ToInt16(rdbListEstado2.SelectedValue);
                objProyectoBE.Usu_Ult_Mod = "pfrey";

                //invocamos al metodo insertar

                if (objProyectoBL.ActualizarProyecto(objProyectoBE) == true)
                {
                    CargarDatos(txtFiltro.Text);
                }
                else
                {
                    throw new Exception("No se actualizó el registro, contate con TI");
                }
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
                    String estado = e.Row.Cells[6].Text;
                    // Si esta inactivo el color de la fuente (ForeColor) de la fila estara en rojo
                    if (estado == "Finalizado")
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

        protected void cboArea2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarArea(2, cboArea2.SelectedValue.ToString());
            PopMan02.Show();
        }
    }
}