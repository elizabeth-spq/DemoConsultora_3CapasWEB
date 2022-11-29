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
    public  class ClienteADO
    {
        // Instancias.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;

        public DataTable ListarCliente()
        {
            
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection= cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarClienteConsultora";
                cmd.Parameters.Clear();


                DataSet dts=new DataSet();
                SqlDataAdapter ada =new SqlDataAdapter(cmd);
                ada.Fill(dts, "Clientes");

                return dts.Tables["Clientes"];



            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ClienteBE ConsultarCliente (String strCodigo)
        {
            
            try
            {
                ClienteBE objClienteBE=new ClienteBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultaClienteConsultora";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ccod_cli", strCodigo);

                //Se abre la conexion y ejecutamos
                cnx.Open();
                dtr= cmd.ExecuteReader();


                if(dtr.HasRows==true)
                {
                    dtr.Read();
                    objClienteBE.Cod_Cli = dtr["Cod_Cli"].ToString();
                    objClienteBE.Cod_Gru_Eco= dtr["Cod_Gru_Eco"].ToString();
                    objClienteBE.Nom_Cli = dtr["Nom_Cli"].ToString();
                    objClienteBE.Num_Doc_Cli = dtr["Num_Doc_Cli"].ToString();
                    objClienteBE.Tip_Doc_Cli = dtr["Tip_Doc_Cli"].ToString();
                    objClienteBE.Dir_Cli = dtr["Dir_Cli"].ToString();
                    objClienteBE.Tip_Cli = dtr["Tip_Cli"].ToString();
                    objClienteBE.Est_cli = dtr["Est_cli"].ToString();
                    objClienteBE.Email_Cli = dtr["Email_Cli"].ToString();
                    objClienteBE.Tel_Cli = dtr["Tel_Cli"].ToString();
                    objClienteBE.Id_Ubigeo = dtr["Id_Ubigeo"].ToString();
                }
                return objClienteBE;

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

        public Boolean InsertarCliente(ClienteBE objClienteBE)
        {
          
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarClienteConsultora";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@cnom", objClienteBE.Nom_Cli);
                cmd.Parameters.AddWithValue("@ccod_Gru", objClienteBE.Cod_Gru_Eco);
                cmd.Parameters.AddWithValue("@cnum_doc", objClienteBE.Num_Doc_Cli);
                cmd.Parameters.AddWithValue("@ctip_doc", objClienteBE.Tip_Doc_Cli);
                cmd.Parameters.AddWithValue("@cDir", objClienteBE.Dir_Cli);
                cmd.Parameters.AddWithValue("@cTip_Cli", objClienteBE.Tip_Cli);
                cmd.Parameters.AddWithValue("@cEst_cli", objClienteBE.Est_cli);
                cmd.Parameters.AddWithValue("@cemail", objClienteBE.Email_Cli);
                cmd.Parameters.AddWithValue("@cTel", objClienteBE.Tel_Cli);
                cmd.Parameters.AddWithValue("@cid_ubigeo", objClienteBE.Id_Ubigeo);
                cmd.Parameters.AddWithValue("@cUsu_Registro", objClienteBE.Usu_Registro);

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
        public Boolean ActualizarCliente(ClienteBE objClienteBE)
        {
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarClienteConsultora";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@ccod_cli", objClienteBE.Cod_Cli);
                cmd.Parameters.AddWithValue("@cnom", objClienteBE.Nom_Cli);
                cmd.Parameters.AddWithValue("@ccod_Gru", objClienteBE.Cod_Gru_Eco);
                cmd.Parameters.AddWithValue("@cnum_doc", objClienteBE.Num_Doc_Cli);
                cmd.Parameters.AddWithValue("@ctip_doc", objClienteBE.Tip_Doc_Cli);
                cmd.Parameters.AddWithValue("@cDir", objClienteBE.Dir_Cli);
                cmd.Parameters.AddWithValue("@cTip_Cli", objClienteBE.Tip_Cli);
                cmd.Parameters.AddWithValue("@cEst_cli", objClienteBE.Est_cli);
                cmd.Parameters.AddWithValue("@cemail", objClienteBE.Email_Cli);
                cmd.Parameters.AddWithValue("@cTel", objClienteBE.Tel_Cli);
                cmd.Parameters.AddWithValue("@cid_ubigeo", objClienteBE.Id_Ubigeo);
                cmd.Parameters.AddWithValue("@cUsu_ult_mod", objClienteBE.Usu_Ult_Mod);

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

        public Boolean EliminarCliente (String strCodigo)
        {
           

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_EliminarClienteConsultora";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ccod_cli", strCodigo);

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
