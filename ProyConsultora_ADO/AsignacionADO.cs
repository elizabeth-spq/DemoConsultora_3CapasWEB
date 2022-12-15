using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyConsultora_BE;

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

        public String RegistrarAsignacion(AsignacionBE objAsignacionBE)
        {
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.CommandText = "usp_RegistrarAsignacion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vcodproy", objAsignacionBE.Cod_Proy);
                cmd.Parameters.AddWithValue("@vfecasig", objAsignacionBE.Fec_Asig);
                cmd.Parameters.AddWithValue("@vUsuRegistro", objAsignacionBE.Usu_Registro);
                cmd.Parameters.AddWithValue("@vestasg", objAsignacionBE.Est_Asig);
                cmd.Parameters.AddWithValue("@vtarf", objAsignacionBE.Tar_Asig);

                //Parametro de salida...
                cmd.Parameters.Add(new SqlParameter("@vcodasig", SqlDbType.VarChar, 4));
                cmd.Parameters["@vcodasig"].Direction=ParameterDirection.Output;

                //Parametro tipo tabla con los detalles de la orden de compra...
                cmd.Parameters.Add(new SqlParameter("@detalles", SqlDbType.Structured));
                cmd.Parameters["@detalles"].Value = objAsignacionBE.DetallesASIG;

                //ejecutamos...
                cnx.Open();
                cmd.ExecuteNonQuery();

                //Retornamos el numero de Asignacion generado
                return cmd.Parameters["@vcodasig"].Value.ToString();
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }

        }

        public DataTable ListarAsignacion()
        {
            try
            {
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection= cnx;
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarAsignacion";
                cmd.Parameters.Clear();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts,"Asignaciones");
                return dts.Tables["Asignaciones"];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
