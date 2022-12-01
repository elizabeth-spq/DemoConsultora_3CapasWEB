using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar ...
using ProyConsultora_ADO;
using ProyConsultora_BE;
namespace ProyConsultora_BL
{
    public class UsuarioBL
    {
        UsuarioADO objUsuarioADO = new UsuarioADO();

        public UsuarioBE ConsultarUsuario(String strCodigo)
        {
            return objUsuarioADO.ConsultarUsuario(strCodigo);  
        }
    }
}
