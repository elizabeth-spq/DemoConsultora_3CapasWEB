using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Agregar
using System.Data;
using ProyConsultora_BE;
using ProyConsultora_BL;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Runtime.Remoting;

namespace SitioWEB_ConsultoraGUI.Transacciones
{
    public partial class RegistrarAsignacion : System.Web.UI.Page
    {
        DataTable mitb;
        DataColumn Ccodigo;
        DataColumn Cdescripcion;
        DataColumn Ctipo;
        ProyectoBL objProyectoBL = new ProyectoBL();
        ColaboradorBL objColaboradorBL = new ColaboradorBL();

        private void CrearTabla()
        {
            mitb = new DataTable("TBAsignaciones");
            //Creando las columnas para la tabla temporal de asignaciones
            //Columna Codigo
            DataColumn Ccodigo = new DataColumn("Cod_Col");
            Ccodigo.DataType = Type.GetType("System.String");
            mitb.Columns.Add(Ccodigo);
            //Columna Descripcion
            DataColumn Cdescripcion = new DataColumn("Colaborador");
            Cdescripcion.DataType = Type.GetType("System.String");
            mitb.Columns.Add(Cdescripcion);
            //Columna Cantidad
            Ctipo = new DataColumn("Tip_Asig");
            Ctipo.DataType = Type.GetType("System.String");
            mitb.Columns.Add(Ctipo);
            //definimos la PK
            mitb.PrimaryKey = new DataColumn[] { mitb.Columns["Cod_Col"] };
            grDetalles.DataSource = mitb;
            grDetalles.DataBind();
            Session["Detalles"] = mitb;

        }
        private void CargarProyectos()
        {


            //Enlazamos el combo de proyectos con el metodo ListarProyectosActivos
            DataTable dt = objProyectoBL.ListarProyectosActivos();
            DataRow dr;
            dr = dt.NewRow();
            dr["Cod_Proy"] = "X";
            dr["Nom_Proy"] = "--Seleccione--";
            dt.Rows.InsertAt(dr, 0);
            cboProyecto.DataSource = dt;
            cboProyecto.DataTextField = "Nom_Proy";
            cboProyecto.DataValueField = "Cod_Proy";
            cboProyecto.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    //Para el formao dd-mm-yyy
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PE");

                    //Mostramos las fechas actuales por defecto
                    txtFecAsig.Text = DateTime.Now.Date.ToShortDateString();

                    //cboProyecto_SelectedIndexChanged();
                    CargarProyectos();


                    //Crear tabla...
                    CrearTabla();

                }
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }

        }

        private void CargarColaboradores()
        {
            // Creamos un nuevo item de cliente
            DataTable dtCombos = new DataTable();
            DataRow drFila;

            // Llenamos la tabla de clientes
            dtCombos = objColaboradorBL.ListarColaboradoresActivos();
            // Creamos un nuevo item de cliente ....
            drFila = dtCombos.NewRow();
            drFila["Cod_Col"] = "X";
            drFila["Colaborador"] = "--Seleccione--";
            // Lo insertamos a la tabla de clientes en la posicion 0
            dtCombos.Rows.InsertAt(drFila, 0);
            // Enlazamos la lista al combo de clientes...
            cboColaboradores.DataSource = dtCombos;
            cboColaboradores.DataTextField = "Colaborador";
            cboColaboradores.DataValueField = "Cod_Col";
            cboColaboradores.DataBind();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProyecto.SelectedValue == "X")
                {
                    throw new Exception("Debe seleccionar un proyecto");
                }
                //mostramos el modalpoppup de detalle...


                CargarColaboradores();

                cboTipo.SelectedValue = "0";
                lblMensajeDetalle.Text = String.Empty;
                PopDetalle.Show();

            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }

        }

        protected void btnGrabarDetalle_Click(object sender, EventArgs e)
        {
            String tipo;
            try
            {
                // Validamos el detalle antes de registrarlo en memoria
                if (cboColaboradores.SelectedValue == "X")
                {
                    throw new Exception("Debe seleccionar un colaborador");
                }
                if (cboTipo.SelectedValue == "0")
                {
                    throw new Exception("Debe seleccionar un Tipo de Asignacion");
                }
                // Si todo esta OK casteamos la variable de sesion "Detalles" a DataTable
                mitb = (DataTable)Session["Detalles"];
                //Creamos una fila y la instanciamos como fila de mitb
                DataRow dr;
                dr = mitb.NewRow();
                //Llenamos los campos con lo ingresado en el Popup de detalle
                dr["Cod_Col"] = cboColaboradores.SelectedValue.ToString();
                dr["Colaborador"] = cboColaboradores.SelectedItem.ToString();
                if (cboTipo.SelectedValue == "1")
                {
                    tipo = "Semanal";
                }
                else
                if (cboTipo.SelectedValue == "2")
                {
                    tipo = "Mensual";
                }
                else { tipo = ""; }
                dr["Tip_Asig"] = tipo;
                //Agregamos la fila a la coleccion de filas de detalle
                mitb.Rows.Add(dr);
                // Lo mostramos en la grilla
                grDetalles.DataSource = mitb;
                grDetalles.DataBind();
            }
            catch (Exception ex)
            {
                lblMensajeDetalle.Text = "Error: " + ex.Message;
                PopDetalle.Show();
            }

        }
        protected void grDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                // Obtenemos el indice de la fila seleccionada
                int indicefila = Convert.ToInt16(e.CommandArgument);

                // Si se pulso en el boton eliminar , eliminamos el respectivo detalle de OC  de memoria
                if (e.CommandName == "Eliminar")
                {
                    mitb = (DataTable)Session["Detalles"];
                    mitb.Rows.RemoveAt(indicefila);
                    grDetalles.DataSource = mitb;
                    grDetalles.DataBind();
                    Session["Detalles"] = mitb;
                }
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }

        protected void btnVerGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                mitb = (DataTable)Session["Detalles"];

                // Validamos las fechas...
                if (txtFecAsig.Text == "")
                {
                    throw new Exception("Debe ingresar fecha de Asignacion");
                }

                //Si no hay detalles, no se puede registrar la  orden
                if (mitb.Rows.Count == 0)
                {
                    throw new Exception("No puede registrar una asignacion sin detalle.");
                }

                // Si todo esta OK mostramos el ModalPopup para el paso final de la generacion de la OC
                lblGrabarOC.Text = "";
                PopOCompra.Show();
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }

        }

        protected void btnGrabarOC_Click(object sender, EventArgs e)
        {
            try
            {
                if(fulOC.HasFile==false)
                {
                    throw new Exception("Debe adjuntar proforma");
                }
                //Si adjunto la proforma se valida que sea PDF y del 4MG
                String strNombreArchivo=fulOC.FileName;
                //Obtenemos la extensión del archivo seleccionado...
                String strExtension=Path.GetExtension(strNombreArchivo).ToLower();
                //Si la extension es PDF
                if(strExtension != ".pdf" && fulOC.PostedFile.ContentLength != 4200000)
                {
                    throw new Exception("El archivo no es PDF o excede los 4Mb");
                }
                AsignacionBE objAsignacionBE = new AsignacionBE();
                AsignacionBL objAsignacionBL = new AsignacionBL();


                //Asignamos valores de cabeceras (El nro lo genera el SP)
                objAsignacionBE.Fec_Asig = Convert.ToDateTime(txtFecAsig.Text);
                objAsignacionBE.Cod_Proy = cboProyecto.SelectedValue.ToString();
                objAsignacionBE.Tar_Asig = Convert.ToDouble(txtTarifa.Text.Trim());
                objAsignacionBE.Est_Asig = 1;
                objAsignacionBE.Usu_Registro = "pfrey";

                //Asignamos los detalles a la propiedad respectiva
                objAsignacionBE.DetallesASIG = mitb;

                //Se evalua el exito del metodo
                String strCodAsig = objAsignacionBL.RegistrarAsignacion(objAsignacionBE);
                if(strCodAsig==String.Empty)
                {
                    throw new Exception("Error, no se registró la Asignación. Revise");
                }
                else
                {
                    //Definimos la ruta destino de los documentos...
                    String strRuta = Server.MapPath("/") + @"Proformas\";
                    strRuta += strCodAsig + ".pdf";
                    //Enviamos el archivo al servidor...
                    fulOC.SaveAs(strRuta);
                    //Reinicio los controles y la tabla por si desea registrar una nueva orden de compra
                    txtFecAsig.Text=DateTime.Now.ToShortDateString();
                    cboProyecto.SelectedValue = "X";
                    txtTarifa.Text = "";
                    CrearTabla();
                    //Se envía mensaje
                    lblMensajePopup.Text = "Se registró la orden Nro: " + strCodAsig + " exitoramente";
                    PopMensaje.Show();

                }
             }
            catch (Exception ex)
            {
                lblGrabarOC.Text = ex.Message;
                PopOCompra.Show();
            }
        }


        protected void cboProyecto_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (grDetalles.Rows.Count > 0)
                {
                    throw new Exception("No se puede cambiar de proyecto con detales registrados");
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
