using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyConsultora_BE
{
    public class ClienteBE
    {
        // Definimos la entidad de negocio Cliente, con todas las propiedades de acuerdo a la estructura 
        // de la tabla Tb_Cliente
        public String Cod_Cli { get; set; }
        public String Cod_Gru_Eco { get; set; }
        public String Nom_Cli { get; set; }
        public String Num_Doc_Cli { get; set; }
        public String Tip_Doc_Cli { get; set; }
        public String Dir_Cli { get; set; }
        public String Tip_Cli { get; set; }
        public String Est_cli { get; set; }
        public String Email_Cli { get; set; }
        public String Tel_Cli { get; set; }
        public String Id_Ubigeo { get; set; }
        public DateTime Fec_Reg { get; set; }
        public String Usu_Registro { get; set; }
        public DateTime Fec_Ult_Mod { get; set; }
        public String Usu_Ult_Mod { get; set; }

    }
}
