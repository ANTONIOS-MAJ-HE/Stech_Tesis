using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_TipoCambio
    {
        d_SQLcon db_st = new d_SQLcon();
        public string NewCambio(e_Tipo_cambio tc)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string insert = string.Format("IF NOT EXISTS(SELECT FECHA,COMPRA FROM TC_SUNAT WHERE FECHA = '{0}' AND COMPRA = {2} ) INSERT INTO TC_SUNAT (FECHA,DIA,COMPRA,VENTA) VALUES ('{0}',{1},{2},{3}) ", tc.FECHA, tc.DIA_ORIGEN, tc.COMPRA_ORIGEN, tc.VENTA_ORIGEN);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Tipo de cambio registrado correctamente";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }
        public List<e_Tipo_cambio> listarCambios()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Tipo_cambio> lista = new List<e_Tipo_cambio>();
                e_Tipo_cambio cambio = null;
                string consulta = "SELECT TOP 365 * FROM TC_SUNAT ORDER by FECHA DESC,DIA DESC";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cambio = new e_Tipo_cambio();
                    cambio.FECHA = (string)reader["FECHA"];
                    cambio.DIA_ORIGEN = (double)reader["DIA"];
                    cambio.COMPRA_ORIGEN = (double)reader["COMPRA"];
                    cambio.VENTA_ORIGEN = (double)reader["VENTA"];
                    lista.Add(cambio);
                }
                reader.Close();
                return lista;
            }
            catch (SqlException ex)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_Tipo_cambio> listarCambios(string filtro)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Tipo_cambio> lista = new List<e_Tipo_cambio>();
                e_Tipo_cambio cambio = null;
                string consulta = "SELECT * FROM TC_SUNAT WHERE FECHA = '" + filtro + "' ORDER BY FECHA";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cambio = new e_Tipo_cambio();
                    cambio.FECHA = (string)reader["FECHA"];
                    cambio.DIA_ORIGEN = (double)reader["DIA"];
                    cambio.COMPRA_ORIGEN = (double)reader["COMPRA"];
                    cambio.VENTA_ORIGEN = (double)reader["VENTA"];
                    lista.Add(cambio);
                }
                reader.Close();
                return lista;
            }
            catch (SqlException ex)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_Tipo_cambio> listarCambiosM(string filtro)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Tipo_cambio> lista = new List<e_Tipo_cambio>();
                e_Tipo_cambio cambio = null;
                string consulta = "SELECT * FROM TC_SUNAT WHERE FECHA LIKE '" + filtro + "%' ORDER BY FECHA";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cambio = new e_Tipo_cambio();
                    cambio.FECHA = (string)reader["FECHA"];
                    cambio.DIA_ORIGEN = (double)reader["DIA"];
                    cambio.COMPRA_ORIGEN = (double)reader["COMPRA"];
                    cambio.VENTA_ORIGEN = (double)reader["VENTA"];
                    lista.Add(cambio);
                }
                reader.Close();
                return lista;
            }
            catch (SqlException ex)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
    }
}
