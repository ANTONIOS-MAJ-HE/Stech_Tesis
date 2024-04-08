using System;
using System.Collections.Generic;
using System.Text;
using ST_Entidades;
using System.Data.SqlClient;

namespace ST_Datos
{
    public class d_Alerta_Stock
    {
        d_SQLcon db_st = new d_SQLcon();
        public List<e_Alerta_Stock>Lista_alertas(e_Alerta_Stock obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Alerta_Stock> lista = new List<e_Alerta_Stock>();
                e_Alerta_Stock alert = null;
                string qury = string.Format("EXEC ALERTA_STOCK '{0}'",obj.STOCK_FINAL);
                SqlCommand cmd_0 = new SqlCommand(qury, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    alert = new e_Alerta_Stock();
                    alert.FECHA_CONSULTA = Convert.ToDateTime((string)reader["FECHA_CONSULTA"]);
                    alert.FECHA_CREACION = Convert.ToDateTime((string)reader["FECHA_CREACION"]);
                    alert.MINICODIGO = (string)reader["MINI_CODIGO"];
                    alert.PARTNUMBER = (string)reader["PARTNUMBER"];
                    alert.MARCA = (string)reader["MARCA"];
                    alert.STOCK_FINAL = (string)reader["STOCK_FINAL"];
                    alert.TITULO = (string)reader["TITULO"];
                    alert.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    alert.SKU_SAGA = (string)reader["SKU_SAGA"];
                    alert.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    alert.SKU_LINIO = (string)reader["SKU_LINIO"];
                    alert.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    alert.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    alert.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    alert.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    alert.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    alert.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    alert.SKU_KIGNSTON = (string)reader["SKU_KINGSTON"];
                    alert.NOM_PROVEEDOR = (string)reader["NOM_PROVEEDOR"];
                    alert.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    alert.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    lista.Add(alert);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_Alerta_Stock> Lista_alertas_total()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Alerta_Stock> lista = new List<e_Alerta_Stock>();
                e_Alerta_Stock alert = null;
                string qury = "EXEC ALERTA_STOCK_TOTAL";
                SqlCommand cmd_0 = new SqlCommand(qury, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    alert = new e_Alerta_Stock();
                    alert.FECHA_CONSULTA = Convert.ToDateTime((string)reader["FECHA_CONSULTA"]);
                    alert.FECHA_CREACION = Convert.ToDateTime((string)reader["FECHA_CREACION"]);
                    alert.MINICODIGO = (string)reader["MINI_CODIGO"];
                    alert.PARTNUMBER = (string)reader["PARTNUMBER"];
                    alert.MARCA = (string)reader["MARCA"];
                    alert.STOCK_FINAL = (string)reader["STOCK_FINAL"];
                    alert.TITULO = (string)reader["TITULO"];
                    alert.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    alert.SKU_SAGA = (string)reader["SKU_SAGA"];
                    alert.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    alert.SKU_LINIO = (string)reader["SKU_LINIO"];
                    alert.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    alert.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    alert.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    alert.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    alert.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    alert.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    alert.SKU_KIGNSTON = (string)reader["SKU_KINGSTON"];
                    alert.NOM_PROVEEDOR = (string)reader["NOM_PROVEEDOR"];
                    alert.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    alert.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    lista.Add(alert);
                }
                reader.Close();
                return lista;
            }
            catch (Exception)
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
