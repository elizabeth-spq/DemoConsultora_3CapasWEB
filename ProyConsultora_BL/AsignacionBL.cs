using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agregar...
using ProyConsultora_ADO;
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
    }
}
