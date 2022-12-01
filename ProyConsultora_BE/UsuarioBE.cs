using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyConsultora_BE
{
    public class UsuarioBE
    {
        public string Cod_Usu { get; set; }
        public string Nom_Usu { get; set; }
        public string Con_Usu { get; set; }
        public Int16 Est_Usu { get; set; }
        public Int16 Tip_Usu { get; set; }
        public DateTime Fec_Reg { get; set; }
        public string Usu_Registro { get; set; }
        public DateTime Fec_Ult_Mod { get; set; }
        public string Usu_Ult_Mod { get; set; }
    }

}
