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
   
    public class AsignacionBL
    {
        AsignacionADO objAsignacionADO = new AsignacionADO();

        public DataTable ListarAsignacionesProyectosFechas
            (String strCodProy,DateTime FecIni, DateTime FecFin)
        {
            return objAsignacionADO.ListarAsignacionesProyectoFechas(strCodProy, FecIni, FecFin); 
        }
        public string RegistrarAsignacion(AsignacionBE objAsignacionBE)
        {
            return objAsignacionADO.RegistrarAsignacion(objAsignacionBE);
        }

        public DataTable ListarAsignacion()
        {
            return objAsignacionADO.ListarAsignacion();
        }
    }
    
}
