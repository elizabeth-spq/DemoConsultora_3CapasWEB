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
    public class ColaboradorBL
    {
        ColaboradorADO objColaboradorADO = new ColaboradorADO();

        public DataTable ListarColaborador()
        {
            return objColaboradorADO.ListarColaborador();
        }
        public ColaboradorBE ConsultarColaborador(String strCodigo)
        {
            return objColaboradorADO.ConsultarColaborador(strCodigo);
        }

        public Boolean InsertarColaborador(ColaboradorBE objColaboradorBE)
        {
            return objColaboradorADO.InsertarColaborador(objColaboradorBE);
        }
        public Boolean ActualizarColaborador(ColaboradorBE objColaboradorBE)
        {
            return objColaboradorADO.ActualizarColaborador(objColaboradorBE);
        }
        public Boolean EliminarColaborador(String strCodigo, string usuario)
        {
            return objColaboradorADO.EliminarColaborador(strCodigo);
        }
        public DataTable ListarColaborador_Paginacion
            (String strCod_Area, String strCod_Cat, String strEstado, Int16 intNumPag)
        {
            return objColaboradorADO.ListarColaborador_Paginacion(strCod_Area, strCod_Cat, strEstado, intNumPag);
        }
        public Int16 NumPag_ListarColaborador_Paginacion
            (String strCod_Area, String strCod_Cat, String strEstado)
        {
            return objColaboradorADO.NumPag_ListarColaborador_Paginacion(strCod_Area, strCod_Cat, strEstado);
        }
        public DataTable ListarColaboradoresActivos()
        {
            return objColaboradorADO.ListarColaboradoresActivos();
        }
    }
}
