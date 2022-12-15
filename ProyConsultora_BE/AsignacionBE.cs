using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyConsultora_BE
{
    public class AsignacionBE
    {
        // Definimos la entidad de negocio Cliente, con todas las propiedades de acuerdo a la estructura 
        // de la tabla Tb_Cliente
        public String Cod_Asig { get; set; }
        public String Cod_Proy { get; set; }
        public DateTime Fec_Asig { get; set; }
        public DateTime Fec_Reg { get; set; }
        public String Usu_Registro { get; set; }
        public DateTime Fec_Ult_Mod { get; set; }
        public String Usu_Ult_Mod { get; set; }
        public Int16 Est_Asig { get; set; }
        public Double Tar_Asig { get; set; }

        //Para el detalle
        private DataTable Detalles;
        public DataTable DetallesASIG
        {
            get { return Detalles; }
            set { Detalles = value; }
        }
    }
}
