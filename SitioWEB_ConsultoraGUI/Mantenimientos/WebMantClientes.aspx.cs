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
    public partial class WebMantClientes : System.Web.UI.Page
    {
        // Instancias...
        ClienteBE objClienteBE = new ClienteBE();
        ClienteBL objClienteBL = new ClienteBL();
        UbigeoBL objUbigeoBL = new UbigeoBL();
        GrupoEconomicoBL objGrupoEconomicoBL = new GrupoEconomicoBL();
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
            dtv = new DataView(objClienteBL.ListarCliente());
            dtv.RowFilter= "Nom_Cli like '%" + strFiltro + "%'";
            
            //Enlazamos el grid al dataview
            grvClientes.DataSource = dtv;
            grvClientes.DataBind();

            if(grvClientes.Rows.Count == 0)
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
     

        protected void grvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvClientes.PageIndex = e.NewPageIndex;
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
        private void CargarUbigeo(Int16 intAccion,String IdDepa, String IdProv, String IdDist)
        {
            // Combos de ubigeo para el CRUD del proveedor
            if (intAccion == 1) // Combos de insercion
            {
                cboDepartamento1.DataSource = objUbigeoBL.Ubigeo_Departamentos();
                cboDepartamento1.DataValueField = "IdDepa";
                cboDepartamento1.DataTextField = "Departamento";
                cboDepartamento1.DataBind();
                cboDepartamento1.SelectedValue = IdDepa;
                cboProvincia1.DataSource = objUbigeoBL.Ubigeo_ProvinciasDepartamento(IdDepa);
                cboProvincia1.DataValueField = "IdProv";
                cboProvincia1.DataTextField = "Provincia";
                cboProvincia1.DataBind();
                cboProvincia1.SelectedValue = IdProv;
                cboDistrito1.DataSource = objUbigeoBL.Ubigeo_DistritosProvinciaDepartamento(IdDepa, IdProv);
                cboDistrito1.DataValueField = "IdDist";
                cboDistrito1.DataTextField = "Distrito";
                cboDistrito1.DataBind();
                cboDistrito1.SelectedValue = IdDist;
            }
            else if (intAccion == 2) // Combos de actualizacion
            {
                cboDepartamento2.DataSource = objUbigeoBL.Ubigeo_Departamentos();
                cboDepartamento2.DataValueField = "IdDepa";
                cboDepartamento2.DataTextField = "Departamento";
                cboDepartamento2.DataBind();
                cboDepartamento2.SelectedValue = IdDepa;
                cboProvincia2.DataSource = objUbigeoBL.Ubigeo_ProvinciasDepartamento(IdDepa);
                cboProvincia2.DataValueField = "IdProv";
                cboProvincia2.DataTextField = "Provincia";
                cboProvincia2.DataBind();
                cboProvincia2.SelectedValue = IdProv;
                cboDistrito2.DataSource = objUbigeoBL.Ubigeo_DistritosProvinciaDepartamento(IdDepa, IdProv);
                cboDistrito2.DataValueField = "IdDist";
                cboDistrito2.DataTextField = "Distrito";
                cboDistrito2.DataBind();
                cboDistrito2.SelectedValue = IdDist;

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

        protected void cboDepartamento1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUbigeo(1,cboDepartamento1.SelectedValue.ToString(), "01", "01");
            //Para que al postear el evento SelectedIndexChanged se mantenga abierto el PopMan01
            PopMan01.Show();
        }

        protected void cboProvincia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUbigeo(1,cboDepartamento1.SelectedValue.ToString(),
                                    cboProvincia1.SelectedValue.ToString(), "01");
            //Para que al postear el evento SelectedIndexChanged se mantenga abierto el PopMant
            PopMan01.Show();
        }

        protected void grvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void cboDepartamento2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUbigeo(2,cboDepartamento2.SelectedValue.ToString(), "01", "01");
            //Para que al postear el evento SelectedIndexChanged se mantenga abierto el PopMan02
            PopMan02.Show();
        }

        protected void cboProvincia2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUbigeo(2,cboDepartamento2.SelectedValue.ToString(),
                                           cboProvincia2.SelectedValue.ToString(), "01");
            //Para que al postear el evento SelectedIndexChanged se mantenga abierto el PopMan02
            PopMan02.Show();
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

        protected void grvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                // El evento recorre cada fila del grid cada vez que este se enlaza a su origen de datos
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Obtenemos el valor del campo  Estado de cada fila (celda 8 )
                    String estado = e.Row.Cells[6].Text;
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