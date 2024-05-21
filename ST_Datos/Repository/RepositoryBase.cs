using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ST_Datos.Repository
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Data Source= LAPTOP-R1VL050P\\MSSQLSERVER01;Initial Catalog= DBSISTEMA_VENTA;Integrated Security=True;";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

    public class d_SQLcon
    {
        private SqlConnection conn;

        public SqlConnection Conecta_DB()
        {
            try
            {
                //string CadenaConexion = "Data Source= PC005;Initial Catalog= DB_ST;User Id=STEC;Password=sasa;";               
                string CadenaConexion = "Data Source= LAPTOP-R1VL050P\\MSSQLSERVER01; Initial Catalog = DBSISTEMA_VENTA; Integrated Security = True;";
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
