using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyConsultora_ADO
{
    public class AsignacionADO
    {
        // Instancias.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;

        public DataTable ListarAsignacionesProyectoFechas(String strCodProy,
                                                        DateTime FecIni, DateTime FecFin)
        {
            try
            {

                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarAsignacionesProyectoFechas";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codproy",strCodProy);
                cmd.Parameters.AddWithValue("@fecini", FecIni);
                cmd.Parameters.AddWithValue("@fecfin", FecFin);

                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "AsigProFec");
                return dts.Tables["AsigProFec"];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
