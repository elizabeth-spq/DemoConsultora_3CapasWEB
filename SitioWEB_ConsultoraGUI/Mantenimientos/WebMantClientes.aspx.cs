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
                //Limpiamos los controlles me PopMan01
                lblMensaje1.Text = String.Empty;
                txtNombre1.Text= String.Empty;
                CargarGE(1, "GE13");
                rdbRadioList1.SelectedValue = "1";
                txtNumDoc1.Text= String.Empty;
                txtDir1.Text= String.Empty;
                txtEmail1.Text= String.Empty;
                txtTel1.Text= String.Empty;
                CargarUbigeo(1, "14", "01", "01");
                chkTipo1.Checked= true;
                chkEstado1.Checked= true;
                txtNombre1.Focus();
                PopMan01.Show();

            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }
        private void CargarGE(Int16 intAccion, String grpEco)
        {
            // Combos de grupo economico para el CRUD del proveedor
            if (intAccion == 1) // Combos de insercion
            {
                cboGruEco1.DataSource = objGrupoEconomicoBL.ListarGE();
                cboGruEco1.DataTextField = "Nom_Gru_Eco";
                cboGruEco1.DataValueField = "Cod_Gru_Eco";
                cboGruEco1.DataBind();
                cboGruEco1.SelectedValue = grpEco;
            }
            else if (intAccion == 2) // Combos de actualizacion
            {
                cboGruEco2.DataSource = objGrupoEconomicoBL.ListarGE();
                cboGruEco2.DataTextField = "Nom_Gru_Eco";
                cboGruEco2.DataValueField = "Cod_Gru_Eco";
                cboGruEco2.DataBind();
                cboGruEco2.SelectedValue = grpEco;
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
            String tip = "";
            String tipCli = "";
            String est = "";

            try
            {
                if (txtNombre1.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre es obligatorio");
                }
                if (txtDir1.Text.Trim() == String.Empty)
                {
                    throw new Exception("La dirección es obligatoria");
                }

                if (txtNumDoc1.Text == String.Empty)
                {
                    throw new Exception("El Nº de Documento es obligatorio");
                }

                if(rdbRadioList1.SelectedValue == "1" && txtNumDoc1.Text.Trim().Length != 11 )
                {
                    throw new Exception("El Ruc debe tener 11 caracteres"); 
                }
                if (rdbRadioList1.SelectedValue == "2" && txtNumDoc1.Text.Trim().Length != 8)
                {
                    throw new Exception("El DNI debe tener 8 caracteres");
                }
                if ((rdbRadioList1.SelectedValue == "3") && (txtNumDoc1.Text.Trim().Length <= 7) || (txtNumDoc1.Text.Trim().Length >= 11))
                {
                    throw new Exception("El carné de extrajería debe tener entre 8 y 12 caracteres");
                }

                //CHKTIPO DE CLIENTE
                if (chkTipo1.Checked == true)
                {
                    tipCli = "1";
                }
                else
                {
                    tipCli = "2";
                }

                //CHK ESTADO
                if (chkEstado1.Checked == true)
                {
                    est = "1";
                }
                else
                {
                    est = "2";
                }

                //Si todo está ok...

                objClienteBE.Nom_Cli = txtNombre1.Text.Trim();
                objClienteBE.Cod_Gru_Eco = cboGruEco1.SelectedValue.ToString();
                objClienteBE.Num_Doc_Cli = txtNumDoc1.Text;
                objClienteBE.Tip_Doc_Cli = rdbRadioList1.SelectedValue.ToString();
                objClienteBE.Dir_Cli = txtDir1.Text.Trim();
                objClienteBE.Tip_Cli = tipCli;
                objClienteBE.Est_cli = est;
                objClienteBE.Email_Cli = txtEmail1.Text.Trim();
                objClienteBE.Tel_Cli = txtTel1.Text.Trim();
                objClienteBE.Id_Ubigeo = cboDepartamento1.SelectedValue.ToString() +
                                         cboProvincia1.SelectedValue.ToString() +
                                         cboDistrito1.SelectedValue.ToString();
                objClienteBE.Usu_Registro = "pfrey";

                //invocamos al metodo insertar

                if (objClienteBL.InsertarCliente(objClienteBE))
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
        protected void cboGruEco1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGE(1,cboGruEco1.SelectedValue.ToString());
            PopMan01.Show();
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
                //Obtenemos la fila del grid que se ha seleccionado
                Int16 fila = Convert.ToInt16(e.CommandArgument);
                //Validamos si el boton tiene el nombre Editar
                if(e.CommandName == "Editar")
                {
                    //Limpiamos el lblMensa2
                    lblMensaje2.Text = "";
                    //Obtenemos el codigo del proveedor de la celda 1 de la fila seleccionada
                    String strCod = grvClientes.Rows[fila].Cells[1].Text;
                    //Obtenemos la instancia del cliente a actualizar
                    objClienteBE = objClienteBL.ConsultarCliente(strCod);
                    //Mostramos el cliente en los controles del panel popMan2
                    //(popup para actualizar registro)

                    lblCod.Text = objClienteBE.Cod_Cli;
                    txtNombre2.Text = objClienteBE.Nom_Cli;
                    txtNumDoc2.Text = objClienteBE.Num_Doc_Cli;
                    txtDir2.Text = objClienteBE.Dir_Cli;
                    txtEmail2.Text = objClienteBE.Email_Cli;
                    txtTel2.Text = objClienteBE.Tel_Cli;


                    String Id_ubigeo = objClienteBE.Id_Ubigeo;
                    CargarUbigeo(2,Id_ubigeo.Substring(0, 2), Id_ubigeo.Substring(2, 2), Id_ubigeo.Substring(4, 2));

                    String Cod_Gru_Eco = objClienteBE.Cod_Gru_Eco;
                    CargarGE(2, Cod_Gru_Eco);
                    
                    ///tipo de cliente
                    Boolean tipCl;
                    if (objClienteBE.Tip_Cli.ToString() == "1")
                    {
                        tipCl = true;
                    }
                    else
                    {
                        tipCl = false;
                    }
                    //estado
                    Boolean est;
                    if (objClienteBE.Est_cli.ToString() == "1")
                    {
                        est = true;
                    }
                    else
                    {
                        est = false;
                    }


                    chkTipo2.Checked = tipCl;
                    chkEstado2.Checked = est;
                    /*
                    //tipo de documento
                    Boolean tip1, tip2, tip3;
                    if (objClienteBE.Tip_Doc_Cli.ToString() == "1")
                    {
                        tip1 = true;
                    }
                    else
                    {
                        tip1 = false;
                    }
                    if (objClienteBE.Tip_Doc_Cli.ToString() == "2")
                    {
                        tip2 = true;
                    }
                    else
                    {
                        tip2 = false;
                    }
                    if (objClienteBE.Tip_Doc_Cli.ToString() == "3")
                    {
                        tip3 = true;
                    }
                    else
                    {
                        tip3 = false;
                    }

                    rdbRuc.Checked = tip1;
                    rdbDni.Checked = tip2;
                    rdbCarne.Checked = tip3;
                    */

                    rdbRadioList2.SelectedValue = objClienteBE.Tip_Doc_Cli;

                    PopMan02.Show();
                }

            
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }
        protected void cboGruEco2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGE(2,cboGruEco2.SelectedValue.ToString());
            PopMan02.Show();
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
            String tipCli = "";
            String est = "";
            try
            {
                //Validamos...
                if (txtNombre2.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre es obligatorio");
                }
                if (txtDir2.Text.Trim() == String.Empty)
                {
                    throw new Exception("La dirección es obligatoria");
                }
                if (txtNumDoc2.Text == String.Empty)
                {
                    throw new Exception("El Nº de Documento es obligatorio");
                }
                if (rdbRadioList2.SelectedValue == "1" && txtNumDoc2.Text.Trim().Length != 11)
                {
                    throw new Exception("El Ruc debe tener 11 caracteres");
                }
                if (rdbRadioList2.SelectedValue == "2" && txtNumDoc2.Text.Trim().Length != 8)
                {
                    throw new Exception("El DNI debe tener 8 caracteres");
                }
                if ((rdbRadioList2.SelectedValue == "3") && (txtNumDoc2.Text.Trim().Length <= 7) || (txtNumDoc1.Text.Trim().Length >= 11))
                {
                    throw new Exception("El carné de extrajería debe tener entre 8 y 12 caracteres");
                }

                //CHKTIPO DE CLIENTE
                if (chkTipo2.Checked == true)
                {
                    tipCli = "1";
                }
                else
                {
                    tipCli = "2";
                }

                //CHK ESTADO
                if (chkEstado2.Checked == true)
                {
                    est = "1";
                }
                else
                {
                    est = "2";
                }

                //Si todo está ok...

                objClienteBE.Cod_Cli = lblCod.Text;

                objClienteBE.Nom_Cli = txtNombre2.Text.Trim();
                objClienteBE.Cod_Gru_Eco = cboGruEco2.SelectedValue.ToString();
                objClienteBE.Num_Doc_Cli = txtNumDoc2.Text;
                objClienteBE.Tip_Doc_Cli = rdbRadioList2.SelectedValue;
                objClienteBE.Dir_Cli = txtDir2.Text.Trim();
                objClienteBE.Tip_Cli = tipCli;
                objClienteBE.Est_cli = est;
                objClienteBE.Email_Cli = txtEmail2.Text.Trim();
                objClienteBE.Tel_Cli = txtTel2.Text.Trim();
                objClienteBE.Id_Ubigeo = cboDepartamento2.SelectedValue.ToString() +
                                         cboProvincia2.SelectedValue.ToString() +
                                         cboDistrito2.SelectedValue.ToString();
                objClienteBE.Usu_Ult_Mod = "pfrey";

                //invocamos al metodo insertar

                if (objClienteBL.ActualizarCliente(objClienteBE) == true)
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