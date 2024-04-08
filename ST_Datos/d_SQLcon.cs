using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace ST_Datos
{
   public class d_SQLcon
    {
        private SqlConnection conn;

        public SqlConnection Conecta_DB()
        {
            try
            {
                string CadenaConexion = "Data Source= PC005;Initial Catalog= DB_ST;User Id=STEC;Password=sasa;";
                conn = new SqlConnection(CadenaConexion);
                conn.Open();
                
                return conn;
                


            }
            catch (SqlException ex)
            {
              
               return null;
            }
        }

        public void Desconecta_DB()
        {
            conn.Close();
        }
    }
}
