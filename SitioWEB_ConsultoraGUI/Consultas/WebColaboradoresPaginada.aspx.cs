using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Agregamos...
using ProyConsultora_BL;
using System.Data;

namespace SitioWEB_ConsultoraGUI.Consultas
{
    public partial class WebColaboradoresPaginada : System.Web.UI.Page
    {
        // Creamos las instancias de los servicios involucrados....
        ColaboradorBL objColaborador = new ColaboradorBL();
        AreaBL objArea = new AreaBL();
        CategoriaBL objCategoria = new CategoriaBL();
        // Variable paginacion....
        String strTextPagina;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {

                    LlenarCombos();

                    //Llenamos la grilla, llamando al metodo con el flag en falso
                    Filtrar(false);

                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }

        }

        private void LlenarCombos()
        {
            // Creamos un nuevo item de cliente
            DataTable dtCombos = new DataTable();
            DataRow drFila;

            // Llenamos la tabla de clientes
            dtCombos = objArea.ListarArea();
            // Creamos un nuevo item de cliente ....
            drFila = dtCombos.NewRow();
            drFila["Cod_Area"] = "X";
            drFila["Nom_Area"] = "--Todos--";
            // Lo insertamos a la tabla de clientes en la posicion 0
            dtCombos.Rows.InsertAt(drFila, 0);
            // Enlazamos la lista al combo de clientes...
            cboArea.DataSource = dtCombos;
            cboArea.DataTextField = "Nom_Area";
            cboArea.DataValueField = "Cod_Area";
            cboArea.DataBind();

            // Ahora lo mismo pero con el combo de vendedores....
            dtCombos = objCategoria.ListarCategoria();
            drFila = dtCombos.NewRow();
            drFila["Cod_Cat_Col"] = "X";
            drFila["Nom_Cat"] = "--Todos--";
            dtCombos.Rows.InsertAt(drFila, 0);
            cboCategoria.DataSource = dtCombos;
            cboCategoria.DataTextField = "Nom_Cat";
            cboCategoria.DataValueField = "Cod_Cat_Col";
            cboCategoria.DataBind();
        }

        private void Filtrar(Boolean blnFlag)
        {

            Int16 pagina = 0;
            String estado;
            String codarea;
            String codcat;

            // Tamaño de pagina : 50
            Int16 intsize = 10;
            Int16 intnumpag;

            // Configuramos los parametros ....
            if (cboArea.SelectedValue == "X") 
            {
                // si eligio Todos del cboarea el codarea sera una cadena vacia
                codarea = "";

            }
            else
            {
                // de lo contrario codarea almacena el codigo del area seleccionado del cboArea
                codarea = cboArea.SelectedValue; 
            }

            if (cboCategoria.SelectedValue == "X") 
            {
                
                codcat = "";
            }
            else
            {
                codcat = cboCategoria.SelectedValue;
            }

            if (cboEstado.SelectedValue == "X") 
            {
                // si eligio Todos del cboEstado el estado sera una cadena vacia
                estado = "";
            }
            else
            {
                // de lo contrario estado sera el estado seleccionado desde el cboEstado
                estado = cboEstado.SelectedValue;
            }

            // Si el flag esta en verdadero es porque selecciono un numero de pagina del combo de paginas...
            if (blnFlag == true)
            {
                //Se obtiene el nro de pagina seleccionado desde el dropdown cboPaginas menos 1

                strTextPagina = cboPaginas.SelectedItem.ToString();
                pagina = Convert.ToInt16(strTextPagina) ;
                pagina = Convert.ToInt16(pagina - 1);


            }
            else // caso contrario sera siempre la primera pagina
            {
                pagina = 0;

            }

            // Si el combo de paginas esta aun vacio , se cargan las primeras 10 facturas, es decir , la pagina 0 del listado
            if (cboPaginas.Items.Count == 0)
            {
                grvColaboradores.DataSource = objColaborador.ListarColaborador_Paginacion("", "", "", 0);

            }
            else // caso contrario es porque ya se genero un filtro por uno , dos o los 3 criterios, por eso se le pasan las variables del filtro al metodo
            {
                grvColaboradores.DataSource = objColaborador.ListarColaborador_Paginacion(codarea, codcat, estado, pagina);

            }
            grvColaboradores.DataBind();

            // Obtenemos la cantidad de registros segun los parametros de criterio de la consulta...

            Int16 intNumRegistros;
            intNumRegistros = objColaborador.NumPag_ListarColaborador_Paginacion(codarea, codcat, estado);


            //Se carga el numero de paginas dentro del cboPaginas
            String strValue = cboPaginas.Text;
            cboPaginas.Items.Clear();

            if (intNumRegistros == 0)
            {
                // Si la consulta no devuelve registros....
                cboPaginas.Items.Add("0");
                cboPaginas.SelectedIndex = 0;

            }
            else
            {
                // Si la consulta devuelve registros, se obtiene la cantidad de paginas
                // dividiendo el numero de registros entre el tamaño de pagina (50) 

                if (intNumRegistros % intsize == 0)
                {
                    // Si la division es exacta,  (residuo 0) por ejemplo si intNumRegistros es = 200 entre el  intsize = 50 
                    // el numero de paginas seria 4 (200/50=4)
                    intnumpag = Convert.ToInt16(intNumRegistros / intsize);

                }
                else
                {
                    // Si la division no es exacta , por ejemplo intNumRegistros=220 entre el intsize =50 
                    // el numero de paginas seria (220/50) + 1 = 5  
                    intnumpag = Convert.ToInt16((intNumRegistros / intsize) + 1);
                }
                // Se procede a llenar el combo de paginas desde 1 hasta el numero de paginas obtenidas
                for (int indice = 1; indice <= intnumpag; indice = indice + 1)
                {
                    cboPaginas.Items.Add(indice.ToString());
                }

            }

            if (blnFlag == true)
            {
                cboPaginas.Text = strValue;
            }

            // Dormimos la aplicacion 2 segundos simulando la recarga de las paginas en un ambiente real....
            // NOTA : No hacer eso en produccion
            System.Threading.Thread.Sleep(2000);

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                Filtrar(false);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void cboPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando hay paginas se llama al metodo con el flag en verdadero
            Filtrar(true);
        }
    }
}