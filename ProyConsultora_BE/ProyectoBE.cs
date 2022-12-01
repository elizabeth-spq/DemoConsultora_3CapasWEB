using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyConsultora_BE
{
    public class ProyectoBE
    {
        // Definimos la entidad de negocio Cliente, con todas las propiedades de acuerdo a la estructura 
        // de la tabla Tb_Cliente
        public String Cod_Proy { get; set; }
        public String Cod_Area { get; set; }
        public String Nom_Proy { get; set; }
        public String Tip_Proy { get; set; }
        public DateTime Fec_Reg { get; set; }
        public String Usu_Registro { get; set; }
        public DateTime Fec_Ult_Mod { get; set; }
        public String Usu_Ult_Mod { get; set; }
        public Double Imp_Imp_Estm { get; set; }
        public Int16 Estado { get; set; }
    }

}
