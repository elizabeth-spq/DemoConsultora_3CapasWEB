using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agregar...

using ProyConsultora_ADO;
using ProyConsultora_BE;

namespace ProyConsultora_BL
{
    public  class ProyectoBL
    {
        ProyectoADO objProyectoADO = new ProyectoADO();

        public DataTable ListarProyecto()
        { 
           return objProyectoADO.ListarProyecto ();
        }
        public ProyectoBE ConsultarProyecto(String strCodigo)
        {
            return objProyectoADO.ConsultarProyecto (strCodigo );
        }

        public Boolean InsertarProyecto(ProyectoBE objProyectoBE)
        {
            return objProyectoADO.InsertarProyecto(objProyectoBE);
        }
        public Boolean ActualizarProyecto(ProyectoBE objProyectoBE)
        {
            return objProyectoADO.ActualizarProyecto(objProyectoBE);
        }
        public Boolean EliminarProyecto(String strCodigo, string usuario)
        {
            return objProyectoADO.EliminarProyecto(strCodigo);
        }
    }
}
