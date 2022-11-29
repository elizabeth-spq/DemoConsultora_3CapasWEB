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
    public  class GrupoEconomicoBL
    {
        GrupoEconomicoADO objGrupoEconomicoADO = new GrupoEconomicoADO();

        public DataTable ListarGE()
        {
            return objGrupoEconomicoADO.ListarGE();
        }
    }
}
