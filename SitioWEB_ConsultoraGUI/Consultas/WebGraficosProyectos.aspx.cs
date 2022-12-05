using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Agregar...
using ProyConsultora_BL;

namespace SitioWEB_ConsultoraGUI.Consultas
{
    public partial class WebGraficosProyectos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack==false)
                {
                    ProyectoBL objProyectoBL = new ProyectoBL();
                    grvProyectos.DataSource = objProyectoBL.ListarProyectoAnual();
                    grvProyectos.DataBind();

                    //para mostrar los datos en graficos se requiere convertir el datatable del metodo 
                    //Listar proyectos anuales e un objeto DataTableReader...

                    //grafTotales
                    DataTableReader dtReaderTotales = objProyectoBL.ListarProyectoAnual().CreateDataReader();
                    grafTotales.Series.Add("Totales");
                    grafTotales.Series["Totales"].Points.DataBindXY(dtReaderTotales, "Año", dtReaderTotales, "Total");
                    grafTotales.Series["Totales"].IsValueShownAsLabel = true;
                    grafTotales.Series["Totales"].LabelFormat = "c";//Formato monetario

                    //grafCantidades
                    DataTableReader dtReaderCantidades = objProyectoBL.ListarProyectoAnual().CreateDataReader();
                    grafCanti.Series.Add("Cantidades");
                    grafCanti.Series["Cantidades"].Points.DataBindXY(dtReaderCantidades, "Año", dtReaderCantidades, "CantProyectos");
                    grafCanti.Series["Cantidades"].IsValueShownAsLabel = true;
                    grafCanti.Series["Cantidades"].LabelFormat = "n";//Formato numerico


                }

            }
            catch(Exception ex)
            {
                lblMensaje.Text=ex.Message;
            }

        }
    }
}