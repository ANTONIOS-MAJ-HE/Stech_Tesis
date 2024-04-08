using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_kardex
    {
        d_SQLcon db_st = new d_SQLcon();
        public string Actualizar_kardex(string obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string act = "UPDATE KD SET TIPO=P.TIPO, FECHA_FACTURA=P.FECHA_FACTURA, TC_FECHA_FACT=P.TC_FECHA_FACT, NUMERO_ORDEN_FACT=p.NUMERO_ORDEN_FACT, DETALLE=P.DETALLE, STOCK_INICIAL=p.STOCK_INICIAL, STOCK_ENTRADA=P.STOCK_ENTRADA, COSTO_UNI_ENT_DOL=p.COSTO_UNI_ENT_DOL, COSTO_UNI_ENT_SOL=p.COSTO_UNI_ENT_SOL, MONTO_ENT_DOL=P.MONTO_ENT_DOL, MONTO_ENT_SOL=P.MONTO_ENT_SOL, STOCK_SALIDA=P.STOCK_SALIDA, COSTO_UNI_SAL_DOL=p.COSTO_UNI_SAL_DOL, COSTO_UNI_PON_SOL=p.COSTO_UNI_PON_SOL, MONTO_SAL_DOL=p.MONTO_SAL_DOL, MONTO_SAL_SOL=p.MONTO_SAL_SOL, STOCK_FINAL=p.STOCK_FINAL, COSTO_UNI_PON_DOL=p.COSTO_UNI_PON_DOL, COSTO_UNI_PON_SOL=p.COSTO_UNI_PON_SOL, MONTO_DOL_TOTAL_FINAL=p.MONTO_DOL_TOTAL_FINAL, MONTO_SOL_TOTAL_FINAL=p.MONTO_SOL_TOTAL_FINAL,OBSERVACION='ENTRADA ERRONEA' from ( SELECT TOP 1 * FROM ST_KARDEX WHERE ID_KARDEX != '{0}' AND PARTNUMBER='"+obj+"' order by FECHA_PROCESO desc) P JOIN ST_KARDEX KD ON P.PARTNUMBER = KD.PARTNUMBER AND KD.FECHA_PROCESO = (SELECT MAX(FECHA_PROCESO) " +
                    "FROM ST_KARDEX WHERE PARTNUMBER=P.PARTNUMBER) WHERE KD.ID_KARDEX='"+obj+"'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message + "ERROR DE QUERY";
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        public List<e_Skardex_> Lista_Kardex(string obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Skardex_> lista = new List<e_Skardex_>();
                e_Skardex_ kardex = null;
                string consulta = "select ID_KARDEX,TIPO,FECHA_PROCESO,TC_FECHA_FACT,PARTNUMBER,DETALLE,ISNULL(STOCK_ENTRADA,0) AS STOCK_ENTRADA," +
                    "ISNULL(COSTO_UNI_ENT_DOL,0) AS COSTO_UNI_ENT_DOL,ISNULL(COSTO_UNI_ENT_SOL,0)AS COSTO_UNI_ENT_SOL,ISNULL(MONTO_ENT_DOL,0) AS MONTO_ENT_DOL," +
                    "ISNULL(MONTO_ENT_SOL,0) AS MONTO_ENT_SOL, ISNULL(STOCK_SALIDA,0) AS STOCK_SALIDA,ISNULL(COSTO_UNI_SAL_DOL,0) AS COSTO_UNI_SAL_DOL," +
                    "ISNULL(COSTO_UNI_SAL_SOL,0) AS COSTO_UNI_SAL_SOL,ISNULL(MONTO_SAL_DOL,0) AS MONTO_SAL_DOL,ISNULL(MONTO_SAL_SOL,0) AS MONTO_SAL_SOL,STOCK_FINAL," +
                    "COSTO_UNI_PON_DOL,COSTO_UNI_PON_SOL,ISNULL(MONTO_DOL_TOTAL_FINAL,0) AS MONTO_DOL_TOTAL_FINAL, ISNULL(MONTO_SOL_TOTAL_FINAL,0) AS MONTO_SOL_TOTAL_FINAL " +
                    "from ST_KARDEX " +
                    "WHERE PARTNUMBER='"+obj+"' order by FECHA_PROCESO desc";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    kardex = new e_Skardex_();
                    kardex.ID_KARDEX = (int)reader["ID_KARDEX"];
                    kardex.TIPO = (string)reader["TIPO"];
                    kardex.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
                    kardex.TC_FECHA_FACT = (double)reader["TC_FECHA_FACT"];
                    kardex.PARTNUMBER = (string)reader["PARTNUMBER"];
                    kardex.DETALLE = (string)reader["DETALLE"];
                    kardex.STOCK_ENTRADA = (int)reader["STOCK_ENTRADA"];
                    kardex.COSTO_UNI_ENT_DOL = (double)reader["COSTO_UNI_ENT_DOL"];
                    kardex.COSTO_UNI_ENT_SOL = (double)reader["COSTO_UNI_ENT_SOL"];
                    kardex.MONTO_ENT_DOL = (double)reader["MONTO_ENT_DOL"];
                    kardex.MONTO_ENT_SOL = (double)reader["MONTO_ENT_SOL"];
                    kardex.STOCK_SALIDA = (int)reader["STOCK_SALIDA"];
                    kardex.COSTO_UNI_SAL_DOL = (double)reader["COSTO_UNI_SAL_DOL"];
                    kardex.COSTO_UNI_SAL_SOL = (double)reader["COSTO_UNI_SAL_SOL"];
                    kardex.MONTO_SAL_DOL = (double)reader["MONTO_SAL_DOL"];
                    kardex.MONTO_SAL_SOL = (double)reader["MONTO_SAL_SOL"];
                    kardex.STOCK_FINAL = (int)reader["STOCK_FINAL"];
                    kardex.COSTO_UNI_PON_DOL = (double)reader["COSTO_UNI_PON_DOL"];
                    kardex.COSTO_UNI_PON_SOL = (double)reader["COSTO_UNI_PON_SOL"];
                    kardex.MONTO_DOL_TOTAL_FINAL = (double)reader["MONTO_DOL_TOTAL_FINAL"];
                    kardex.MONTO_SOL_TOTAL_FINAL = (double)reader["MONTO_SOL_TOTAL_FINAL"];

                    lista.Add(kardex);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
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
