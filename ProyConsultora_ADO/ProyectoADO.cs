using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agregar....
using System.Data;
using System.Data.SqlClient;
using ProyConsultora_BE;

namespace ProyConsultora_ADO
{
    public class ProyectoADO
    {
        // Instancias.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;


        public DataTable ListarProyecto()
        {

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarProyectos";
                cmd.Parameters.Clear();


                DataSet dts = new DataSet();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Proyectos");

                return dts.Tables["Proyectos"];



            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ProyectoBE ConsultarProyecto(String strCodigo)
        {

            try
            {
                ProyectoBE objproyectoBE = new ProyectoBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vcod", strCodigo);

                //Se abre la conexion y ejecutamos
                cnx.Open();
                dtr = cmd.ExecuteReader();


                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objproyectoBE.Cod_Proy = dtr["Cod_Proy"].ToString();
                    objproyectoBE.Cod_Area = dtr["Cod_Area"].ToString();
                    objproyectoBE.Nom_Proy = dtr["Nom_Proy"].ToString();
                    objproyectoBE.Tip_Proy = dtr["Tip_Proy"].ToString();
                    objproyectoBE.Imp_Imp_Estm = Convert.ToDouble(dtr["Imp_Imp_Estm"]);
                    objproyectoBE.Estado = Convert.ToInt16(dtr["Estado"]);

                }
                return objproyectoBE;

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
        }

        public Boolean InsertarProyecto(ProyectoBE objproyectoBE)
        {

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarProyecto";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@Cod_Area", objproyectoBE.Cod_Area);
                cmd.Parameters.AddWithValue("@vNom_Proy", objproyectoBE.Nom_Proy);
                cmd.Parameters.AddWithValue("@vTip_Proy", objproyectoBE.Tip_Proy);
                cmd.Parameters.AddWithValue("@vUsu_Registro", objproyectoBE.Usu_Registro);
                cmd.Parameters.AddWithValue("@vImp_Imp_Estm", objproyectoBE.Imp_Imp_Estm);
                cmd.Parameters.AddWithValue("@vEst", objproyectoBE.Estado);

                //Abrimos la conexion y ejecutamos

                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }
        }
        public Boolean ActualizarProyecto(ProyectoBE objproyectoBE)
        {
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarProyecto";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@vcod", objproyectoBE.Cod_Proy);
                cmd.Parameters.AddWithValue("@Cod_Area", objproyectoBE.Cod_Area);
                cmd.Parameters.AddWithValue("@vNom_Proy", objproyectoBE.Nom_Proy);
                cmd.Parameters.AddWithValue("@vTip_Proy", objproyectoBE.Tip_Proy);
                cmd.Parameters.AddWithValue("@vUsu_Ult_Mod", objproyectoBE.Usu_Ult_Mod);
                cmd.Parameters.AddWithValue("@vImp_Imp_Estm", objproyectoBE.Imp_Imp_Estm);
                cmd.Parameters.AddWithValue("@Est", objproyectoBE.Estado);
                

                //Abrimos la conexion y ejecutamos

                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }


        }

        public Boolean EliminarProyecto(String strCodigo)
        {


            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_EliminarProyecto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@vcod", strCodigo);

                //abrimos conexion y ejecutamos
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }


        }


    }
}
