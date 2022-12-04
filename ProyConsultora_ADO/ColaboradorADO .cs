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
    public class ColaboradorADO
    {
        // Instancias.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;


        public DataTable ListarColaborador()
        {

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarColaboradores";
                cmd.Parameters.Clear();


                DataSet dts = new DataSet();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "Colaboradores");

                return dts.Tables["Colaboradores"];



            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ColaboradorBE ConsultarColaborador(String strCodigo)
        {

            try
            {
                ColaboradorBE objColaboradorBE = new ColaboradorBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarColaborador";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ccod", strCodigo);

                //Se abre la conexion y ejecutamos
                cnx.Open();
                dtr = cmd.ExecuteReader();


                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objColaboradorBE.Cod_Col = dtr["Cod_Col"].ToString();
                    objColaboradorBE.Cod_Cat_Col = dtr["Cod_Cat_Col"].ToString();
                    objColaboradorBE.Nom_Col = dtr["Nom_Col"].ToString();
                    objColaboradorBE.Ape_Col = dtr["Ape_Col"].ToString();
                    objColaboradorBE.Fec_Nac = Convert.ToDateTime(dtr["Fec_Nac"]);
                    objColaboradorBE.Doc_Col = dtr["Doc_Col"].ToString();
                    objColaboradorBE.Num_Doc_Col = dtr["Num_Doc_Col"].ToString();
                    objColaboradorBE.Tel_Col = dtr["Tel_Col"].ToString();
                    objColaboradorBE.Cel_Col = dtr["Cel_Col"].ToString();
                    objColaboradorBE.Ema_Col = dtr["Ema_Col"].ToString();
                    objColaboradorBE.Dir_Col = dtr["Dir_Col"].ToString();
                    objColaboradorBE.Cod_Area = dtr["Cod_Area"].ToString();
                    objColaboradorBE.Id_Ubigeo = dtr["Id_Ubigeo"].ToString();
                    objColaboradorBE.Sue_Col = Convert.ToDouble(dtr["Sue_Col"]);
                    objColaboradorBE.Est_Col = Convert.ToInt16(dtr["Est_Col"]);
                    objColaboradorBE.Fot_Col = (Byte[])(dtr["Fot_Col"]);

                }
                return objColaboradorBE;

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

        public Boolean InsertarColaborador(ColaboradorBE objColaboradorBE)
        {

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarColaborador";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@vCod_Cat_Col", objColaboradorBE.Cod_Cat_Col);
                cmd.Parameters.AddWithValue("@vNom_Col", objColaboradorBE.Nom_Col);
                cmd.Parameters.AddWithValue("@vApe_Col", objColaboradorBE.Ape_Col);
                cmd.Parameters.AddWithValue("@vFec_Nac", objColaboradorBE.Fec_Nac);
                cmd.Parameters.AddWithValue("@vDoc_Col", objColaboradorBE.Doc_Col);
                cmd.Parameters.AddWithValue("@vNum_Doc_Col", objColaboradorBE.Num_Doc_Col);
                cmd.Parameters.AddWithValue("@vTel_Col", objColaboradorBE.Tel_Col);
                cmd.Parameters.AddWithValue("@vCel_Col", objColaboradorBE.Cel_Col);
                cmd.Parameters.AddWithValue("@vEma_Col", objColaboradorBE.Ema_Col);
                cmd.Parameters.AddWithValue("@vDir_Col", objColaboradorBE.Dir_Col);
                cmd.Parameters.AddWithValue("@vCod_Area", objColaboradorBE.Cod_Area);
                cmd.Parameters.AddWithValue("@vId_Ubigeo", objColaboradorBE.Id_Ubigeo);
                cmd.Parameters.AddWithValue("@vSue_Col", objColaboradorBE.Sue_Col);
                cmd.Parameters.AddWithValue("@vEst_Col", objColaboradorBE.Est_Col);
                cmd.Parameters.AddWithValue("@vUsu_Registro", objColaboradorBE.Usu_Registro);
                cmd.Parameters.AddWithValue("@vFot_Col", objColaboradorBE.Fot_Col);
       

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
        public Boolean ActualizarColaborador(ColaboradorBE objColaboradorBE)
        {
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarColaborador";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@ccod", objColaboradorBE.Cod_Col);

                cmd.Parameters.AddWithValue("@vCod_Cat_Col", objColaboradorBE.Cod_Cat_Col);
                cmd.Parameters.AddWithValue("@vNom_Col", objColaboradorBE.Nom_Col);
                cmd.Parameters.AddWithValue("@vApe_Col", objColaboradorBE.Ape_Col);
                cmd.Parameters.AddWithValue("@vFec_Nac", objColaboradorBE.Fec_Nac);
                cmd.Parameters.AddWithValue("@vDoc_Col", objColaboradorBE.Doc_Col);
                cmd.Parameters.AddWithValue("@vNum_Doc_Col", objColaboradorBE.Num_Doc_Col);
                cmd.Parameters.AddWithValue("@vTel_Col", objColaboradorBE.Tel_Col);
                cmd.Parameters.AddWithValue("@vCel_Col", objColaboradorBE.Cel_Col);
                cmd.Parameters.AddWithValue("@vEma_Col", objColaboradorBE.Ema_Col);
                cmd.Parameters.AddWithValue("@vDir_Col", objColaboradorBE.Dir_Col);
                cmd.Parameters.AddWithValue("@vCod_Area", objColaboradorBE.Cod_Area);
                cmd.Parameters.AddWithValue("@vId_Ubigeo", objColaboradorBE.Id_Ubigeo);
                cmd.Parameters.AddWithValue("@vSue_Col", objColaboradorBE.Sue_Col);
                cmd.Parameters.AddWithValue("@vEst_Col", objColaboradorBE.Est_Col);
                cmd.Parameters.AddWithValue("@vUsu_Ult_Registro", objColaboradorBE.Usu_Ult_Mod);
                cmd.Parameters.AddWithValue("@vFot_Col", objColaboradorBE.Fot_Col);


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

        public Boolean EliminarColaborador(String strCodigo)
        {


            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_EliminarColaborador";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ccod", strCodigo);

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

        public DataTable ListarColaborador_Paginacion
            (String strCod_Area,String strCod_Cat,String strEstado,Int16 intNumPag)
        {

            try
            {
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarColaboradores_Paginacion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Cod_Area", strCod_Area);
                cmd.Parameters.AddWithValue("@Cod_Cat", strCod_Cat);
                cmd.Parameters.AddWithValue("@Estado", strEstado);
                cmd.Parameters.AddWithValue("@NumPag", intNumPag);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dts, "ColaboradoresPaginacion");
                return dts.Tables["ColaboradoresPaginacion"];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Int16 NumPag_ListarColaborador_Paginacion
            ( String strCod_Area, String strCod_Cat, String strEstado)
        {
            //Metodo que retorna la cantidad de registros devueltos de acuerdo a los parametros 

            try
            {
                
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_NumPag_ListarColaboradores_Paginacion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Cod_Area", strCod_Area);
                cmd.Parameters.AddWithValue("@Cod_Cat", strCod_Cat);
                cmd.Parameters.AddWithValue("@Estado", strEstado);
               //parametro de salida que devolvera la cantidad de registros de la consulta
                cmd.Parameters.Add("@NumReg",SqlDbType.Int);
                cmd.Parameters["@NumReg"].Direction = ParameterDirection.Output;
                cnx.Open();
                cmd.ExecuteScalar();
                Int16 NumReg = Convert.ToInt16(cmd.Parameters["@NumReg"].Value);
                return NumReg;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if(cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
            }

        }


    }
}
