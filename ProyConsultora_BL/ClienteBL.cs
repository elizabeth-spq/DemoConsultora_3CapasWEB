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
    public  class ClienteBL
    {
        ClienteADO objClienteADO = new ClienteADO();

        public DataTable ListarCliente()
        { 
           return objClienteADO.ListarCliente ();
        }
        public ClienteBE ConsultarCliente(String strCodigo)
        {
            return objClienteADO.ConsultarCliente (strCodigo );
        }

        public Boolean InsertarCliente(ClienteBE objClienteBE)
        {
            return objClienteADO.InsertarCliente(objClienteBE);
        }
        public Boolean ActualizarCliente(ClienteBE objClienteBE)
        {
            return objClienteADO.ActualizarCliente(objClienteBE);
        }
        public Boolean EliminarCliente(String strCodigo, string usuario)
        {
            return objClienteADO.EliminarCliente(strCodigo);
        }
    }
}
