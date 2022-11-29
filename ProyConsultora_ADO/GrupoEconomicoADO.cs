using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyConsultora_ADO
{
    public class GrupoEconomicoADO
    {
        // Instancias.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;

        public DataTable ListarGE()
        {
            DataSet dts = new DataSet();
            cnx.ConnectionString = MiConexion.GetCnx();
            cmd.Connection = cnx;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ListarGE";
            try
            {

                cmd.Parameters.Clear();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "GrEconomico");
                return dts.Tables["GrEconomico"];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
