using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregar...
using System.Data;
using System.Data.SqlClient;
using ProyConsultora_BE;


namespace ProyConsultora_ADO
{
    public class UsuarioADO
    {

        //Instancias....
        ConexionADO MiConexion=new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;

        public UsuarioBE ConsultarUsuario(String strCodigo)
        {
            try
            {
                UsuarioBE objUsuarioBE = new UsuarioBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarUsuario";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Vlogin", strCodigo);

                //Abrimos la coneccion y ejecutamos
                cnx.Open();
                dtr = cmd.ExecuteReader();

                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    objUsuarioBE.Cod_Usu = dtr["Cod_Usu"].ToString();
                    objUsuarioBE.Nom_Usu = dtr["Nom_Usu"].ToString();
                    objUsuarioBE.Con_Usu = dtr["Con_Usu"].ToString();
                    objUsuarioBE.Est_Usu = Convert.ToInt16(dtr["Est_Usu"]);
                    objUsuarioBE.Tip_Usu = Convert.ToInt16(dtr["Tip_Usu"]);
                    //objUsuarioBE.Fec_Reg = Convert.ToDateTime(dtr["Fec_Registro"]); 
                    objUsuarioBE.Usu_Registro = dtr["Usu_Registro"].ToString();
                   // objUsuarioBE.Fec_Ult_Mod = Convert.ToDateTime(dtr["Fec_Registro"]); 
                    objUsuarioBE.Usu_Ult_Mod = dtr["Usu_Ult_Mod"].ToString(); ;
                    
                }
                return objUsuarioBE;

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
    }
}
