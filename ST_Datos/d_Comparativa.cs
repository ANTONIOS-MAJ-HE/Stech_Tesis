using ST_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ST_Datos
{
    public class d_Comparativa
    {
        d_SQLcon db_st = new d_SQLcon();
        string QueryComp = "INSERT INTO ST_COMPARATIVA select DISTINCT ST.STOCK_FINAL, ST.PARTNUMBER, TITULO, CONVERT(varchar,ISNULL(COSTO_U_S_IGV_DOLARES,0)) AS COSTO_U_S_IGV_DOLARES, CONVERT(varchar,ISNULL(COSTO_U_S_IGV_SOLES,0)) AS COSTO_U_S_IGV_SOLES, CONVERT(varchar,ISNULL(SK.COSTO_UNI_PON_DOL,0)) AS COSTO_UNI_PON_DOL, E.FECHA_PROCESO as 'ULTIMA_ENTRADA', CONVERT(varchar,ISNULL(ST.SKU_SAGA,'-')) AS SKU_SAGA, ISNULL(SF.FECHA_PROCESO,'1999-01-01') AS 'FECHA ULTIMA VENTA SAGA', CONVERT(varchar,ISNULL(SF.PRECIO_COSTO,0)) AS 'ULTIMA VENTA SAGA', ISNULL(ST.SKU_LINIO,'-') AS SKU_LINIO, CONVERT(varchar,ISNULL(PLNO.PRECIO_VENTA,0)) AS 'PRECIO DE VENTA  LINIO', ISNULL(LN.FECHA_PROCESO,'1999-01-01') AS 'FECHA ULTIMA VENTA LINIO', CONVERT(varchar,ISNULL(LN.UNIT_PRICE,0)) AS 'PRECIO ULTIMA VENTA LINIO', ISNULL(ST.SKU_RIPLEY,'-') AS SKU_RIPLEY, CONVERT(varchar,ISNULL(PRPL.PRECIO,0)) AS 'PRECIO DE VENTA EN RIPLEY', ISNULL(RPL.FECHA_PROCESO,'1999-01-01') AS 'FECHA ULTIMA VENTA RIPLEY', CONVERT(varchar,ISNULL(RPL.PRECIO_UNIDAD,0)) AS 'PRECIO ULTIMA VENTA RIPLEY', ISNULL(ST.SKU_REALPLAZA,'-') AS SKU_REALPLAZA, CONVERT(varchar,ISNULL(PRPG.PRECIO_DESCUENTO,0)) AS 'PRECIO DE VENTA REALPLAZA', ISNULL(RPG.FECHA_PROCESO,'1999-01-01') AS 'FECHA ULTIMA VENTA REALPLAZA', CONVERT(varchar,ISNULL(RPG.PRECIO_SKU,0)) AS 'PRECIO ULTIMA VENTA REALPLAZA' from ST_STOCK_HST_CONSULTA ST INNER JOIN ST_ENTRADAS_CONS E ON E.MINICODIGO = ST.MINI_CODIGO AND E.FECHA_PROCESO = (select MAX(FECHA_PROCESO) from ST_ENTRADAS_CONS WHERE MINICODIGO=ST.MINI_CODIGO) LEFT JOIN OC_SF_CONS SF ON SF.SKU = ST.SKU_SAGA AND SF.FECHA_PROCESO =(select MAX(FECHA_PROCESO) from OC_SF_CONS WHERE SKU=ST.SKU_SAGA) LEFT JOIN OC_LNO_CONS LN ON LN.LINIO_SKU = ST.SKU_LINIO AND LN.FECHA_PROCESO =(select MAX(FECHA_PROCESO) from OC_LNO_CONS WHERE LINIO_SKU=ST.SKU_LINIO) LEFT JOIN OC_RPL_CONS RPL ON RPL.SKU_OFERTA = ST.SKU_RIPLEY AND RPL.FECHA_PROCESO =(select MAX(FECHA_PROCESO) from OC_RPL_CONS WHERE SKU_OFERTA=ST.SKU_RIPLEY) LEFT JOIN OC_RPG_CONS RPG ON RPG.SKU = ST.SKU_REALPLAZA AND RPG.FECHA_PROCESO =(select MAX(FECHA_PROCESO) from OC_RPG_CONS WHERE SKU=ST.SKU_REALPLAZA) LEft JOIN ST_KARDEX SK ON SK.PARTNUMBER = ST.PARTNUMBER AND SK.ID_KARDEX =(select MAX(ID_KARDEX) from ST_KARDEX  WHERE PARTNUMBER=ST.PARTNUMBER) LEFT JOIN PLANTA_LNO_INPUT PLNO ON PLNO.LINIO_SKU = ST.SKU_LINIO LEFT JOIN PLANTA_RPL_INPUT PRPL ON PRPL.SKU_OFERTA= ST.SKU_RIPLEY LEFT JOIN PLANTA_RPG_2 PRPG ON PRPG.SKU = ST.SKU_REALPLAZA";
        string Limp = "TRUNCATE TABLE ST_COMPARATIVA";

        public string Cargar_stock()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string truncar = Limp;
                string ingresar = QueryComp;
                SqlCommand cmd_0 = new SqlCommand(truncar, con);
                SqlCommand cmd_1 = new SqlCommand(ingresar, con);
                //Query no optimizado
                cmd_1.CommandTimeout= 0;

                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                return null;

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
        public string CARGA()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string truncar = Limp;
                string ingresar = QueryComp;
                SqlCommand cmd_0 = new SqlCommand(truncar, con);
                SqlCommand cmd_1 = new SqlCommand(ingresar, con);
                //Query no optimizado
                cmd_1.CommandTimeout = 0;

                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                return "CARGA EXITOSA";

            }
            catch (Exception e)
            {
                return "ERROR: "+e.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_Comparativa> Lista_comparaciones()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Comparativa> comparacion = new List<e_Comparativa>();
                e_Comparativa comparativa = null;
                string consulta = "select * from ST_COMPARATIVA";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    comparativa = new e_Comparativa();
                    comparativa.STOCK_FINAL = (int)reader["STOCK_FINAL"];
                    comparativa.PARTNUMBER = (string)reader["PARTNUMBER"];
                    comparativa.TITULO = (string)reader["TITULO"];
                    comparativa.PRECIO_PLANTA_USD = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    comparativa.PRECIO_PLANTA_PEN = (string)reader["COSTO_U_S_IGV_SOLES"];
                    comparativa.PRECIO_KARDEX_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    comparativa.FECHA_ULT_ENTRADA = (DateTime)reader["ULTIMA_ENTRADA"];
                    comparativa.SKU_SAGA = (string)reader["SKU_SAGA"];
                    comparativa.FECHA_ULT_V_SAGA = (DateTime)reader["FECHA ULTIMA VENTA SAGA"];
                    comparativa.ULT_V_SAGA = (string)reader["ULTIMA VENTA SAGA"];
                    comparativa.SKU_LINIO = (string)reader["SKU_LINIO"];
                    comparativa.P_V_LINIO = (string)reader["PRECIO DE VENTA  LINIO"];
                    comparativa.FECHA_ULT_V_LINIO = (DateTime)reader["FECHA ULTIMA VENTA LINIO"];
                    comparativa.ULT_V_LINIO = (string)reader["PRECIO ULTIMA VENTA LINIO"];
                    comparativa.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    comparativa.P_V_RIPLEY = (string)reader["PRECIO DE VENTA EN RIPLEY"];
                    comparativa.FECHA_ULT_V_RIPLEY = (DateTime)reader["FECHA ULTIMA VENTA RIPLEY"];
                    comparativa.ULT_V_RIPLEY = (string)reader["PRECIO ULTIMA VENTA RIPLEY"];
                    comparativa.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    comparativa.P_V_REALPLAZA = (string)reader["PRECIO DE VENTA REALPLAZA"];
                    comparativa.FECHA_ULT_V_REALPLAZA = (DateTime)reader["FECHA ULTIMA VENTA REALPLAZA"];
                    comparativa.ULT_V_REALPLAZA = (string)reader["PRECIO ULTIMA VENTA REALPLAZA"];

                    comparacion.Add(comparativa);
                }
                reader.Close();
                return comparacion;
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
        public List<e_Comparativa> Lista_Busqueda(string titulo)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Comparativa> comparacion = new List<e_Comparativa>();
                e_Comparativa comparativa = null;
                string consulta = "select * from ST_COMPARATIVA Where TITULO LIKE '%"+titulo+"%'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    comparativa = new e_Comparativa();
                    comparativa.STOCK_FINAL = (int)reader["STOCK_FINAL"];
                    comparativa.PARTNUMBER = (string)reader["PARTNUMBER"];
                    comparativa.TITULO = (string)reader["TITULO"];
                    comparativa.PRECIO_PLANTA_USD = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    comparativa.PRECIO_PLANTA_PEN = (string)reader["COSTO_U_S_IGV_SOLES"];
                    comparativa.PRECIO_KARDEX_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    comparativa.FECHA_ULT_ENTRADA = (DateTime)reader["ULTIMA_ENTRADA"];
                    comparativa.SKU_SAGA = (string)reader["SKU_SAGA"];
                    comparativa.FECHA_ULT_V_SAGA = (DateTime)reader["FECHA ULTIMA VENTA SAGA"];
                    comparativa.ULT_V_SAGA = (string)reader["ULTIMA VENTA SAGA"];
                    comparativa.SKU_LINIO = (string)reader["SKU_LINIO"];
                    comparativa.P_V_LINIO = (string)reader["PRECIO DE VENTA  LINIO"];
                    comparativa.FECHA_ULT_V_LINIO = (DateTime)reader["FECHA ULTIMA VENTA LINIO"];
                    comparativa.ULT_V_LINIO = (string)reader["PRECIO ULTIMA VENTA LINIO"];
                    comparativa.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    comparativa.P_V_RIPLEY = (string)reader["PRECIO DE VENTA EN RIPLEY"];
                    comparativa.FECHA_ULT_V_RIPLEY = (DateTime)reader["FECHA ULTIMA VENTA RIPLEY"];
                    comparativa.ULT_V_RIPLEY = (string)reader["PRECIO ULTIMA VENTA RIPLEY"];
                    comparativa.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    comparativa.P_V_REALPLAZA = (string)reader["PRECIO DE VENTA REALPLAZA"];
                    comparativa.FECHA_ULT_V_REALPLAZA = (DateTime)reader["FECHA ULTIMA VENTA REALPLAZA"];
                    comparativa.ULT_V_REALPLAZA = (string)reader["PRECIO ULTIMA VENTA REALPLAZA"];

                    comparacion.Add(comparativa);
                }
                reader.Close();
                return comparacion;
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
        public List<e_Comparativa> Lista_comparaciones_Filtro(string Partnumber)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Comparativa> comparacion = new List<e_Comparativa>();
                e_Comparativa comparativa = null;
                string consulta = "select * from ST_COMPARATIVA Where PARTNUMBER ='"+Partnumber+"'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    comparativa = new e_Comparativa();
                    comparativa.STOCK_FINAL = (int)reader["STOCK_FINAL"];
                    comparativa.PARTNUMBER = (string)reader["PARTNUMBER"];
                    comparativa.TITULO = (string)reader["TITULO"];
                    comparativa.PRECIO_PLANTA_USD = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    comparativa.PRECIO_PLANTA_PEN = (string)reader["COSTO_U_S_IGV_SOLES"];
                    comparativa.PRECIO_KARDEX_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    comparativa.FECHA_ULT_ENTRADA = (DateTime)reader["ULTIMA_ENTRADA"];
                    comparativa.SKU_SAGA = (string)reader["SKU_SAGA"];
                    comparativa.FECHA_ULT_V_SAGA = (DateTime)reader["FECHA ULTIMA VENTA SAGA"];
                    comparativa.ULT_V_SAGA = (string)reader["ULTIMA VENTA SAGA"];
                    comparativa.SKU_LINIO = (string)reader["SKU_LINIO"];
                    comparativa.P_V_LINIO = (string)reader["PRECIO DE VENTA  LINIO"];
                    comparativa.FECHA_ULT_V_LINIO = (DateTime)reader["FECHA ULTIMA VENTA LINIO"];
                    comparativa.ULT_V_LINIO = (string)reader["PRECIO ULTIMA VENTA LINIO"];
                    comparativa.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    comparativa.P_V_RIPLEY = (string)reader["PRECIO DE VENTA EN RIPLEY"];
                    comparativa.FECHA_ULT_V_RIPLEY = (DateTime)reader["FECHA ULTIMA VENTA RIPLEY"];
                    comparativa.ULT_V_RIPLEY = (string)reader["PRECIO ULTIMA VENTA RIPLEY"];
                    comparativa.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    comparativa.P_V_REALPLAZA = (string)reader["PRECIO DE VENTA REALPLAZA"];
                    comparativa.FECHA_ULT_V_REALPLAZA = (DateTime)reader["FECHA ULTIMA VENTA REALPLAZA"];
                    comparativa.ULT_V_REALPLAZA = (string)reader["PRECIO ULTIMA VENTA REALPLAZA"];

                    comparacion.Add(comparativa);
                }
                reader.Close();
                return comparacion;
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

        public e_Ratios Ratio_comparaciones_Filtro(string Partnumber,double TC)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                e_Ratios comparativa = null;
                string consulta = "select * from ST_COMPARATIVA Where PARTNUMBER ='" + Partnumber + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                string Ratio_SAGA="", Ratio_LINIO="", Ratio_RIPLEY="", Ratio_REALPLAZA="",PLANTA_PEN="",PLANTA_USD="",KARDEX_USD="";
                while (reader.Read())
                {
                    comparativa = new e_Ratios();
                    comparativa.Partnumber= (string)reader["PARTNUMBER"];
                    PLANTA_USD = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    PLANTA_PEN = (string)reader["COSTO_U_S_IGV_SOLES"];
                    KARDEX_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    Ratio_SAGA = (string)reader["ULTIMA VENTA SAGA"];
                    Ratio_LINIO = (string)reader["PRECIO DE VENTA  LINIO"];
                    Ratio_RIPLEY = (string)reader["PRECIO DE VENTA EN RIPLEY"];
                    Ratio_REALPLAZA = (string)reader["PRECIO DE VENTA REALPLAZA"];
                }
                reader.Close();
                comparativa.RatioSaga = Convert.ToString((Convert.ToDouble(Ratio_SAGA)/TC)/Convert.ToDouble(KARDEX_USD));
                double R_linio = Convert.ToDouble(Ratio_LINIO) / 1.15 / 1.18/TC;
                comparativa.RatioLinio = Convert.ToString(R_linio/ Convert.ToDouble(KARDEX_USD));
                double R_ripley = Convert.ToDouble(Ratio_RIPLEY) / 1.15 / 1.18/TC;
                comparativa.RatioRIpley = Convert.ToString(R_ripley / Convert.ToDouble(KARDEX_USD));
                double R_realplaza = Convert.ToDouble(Ratio_REALPLAZA) / 1.15 / 1.18 / TC;
                comparativa.RatioRealPlaza = Convert.ToString(R_realplaza / Convert.ToDouble(KARDEX_USD));
                return comparativa;
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
        public List<e_Ratios> Ratio_comparaciones_Filtro_ALL(double TC)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                e_Ratios comparativa = null;
                List<e_Ratios> lista = new List<e_Ratios>();
                string consulta = "select * from ST_COMPARATIVA";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                string Ratio_SAGA = "", Ratio_LINIO = "", Ratio_RIPLEY = "", Ratio_REALPLAZA = "", PLANTA_PEN = "", PLANTA_USD = "", KARDEX_USD = "";
                while (reader.Read())
                {
                    comparativa = new e_Ratios();
                    comparativa.Partnumber = (string)reader["PARTNUMBER"];
                    PLANTA_USD = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    PLANTA_PEN = (string)reader["COSTO_U_S_IGV_SOLES"];
                    KARDEX_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    Ratio_SAGA = (string)reader["ULTIMA VENTA SAGA"];
                    Ratio_LINIO = (string)reader["PRECIO DE VENTA  LINIO"];
                    Ratio_RIPLEY = (string)reader["PRECIO DE VENTA EN RIPLEY"];
                    Ratio_REALPLAZA = (string)reader["PRECIO DE VENTA REALPLAZA"];

                    comparativa.RatioSaga = Convert.ToString((Convert.ToDouble(Ratio_SAGA) / TC) / Convert.ToDouble(KARDEX_USD));
                    double R_linio = Convert.ToDouble(Ratio_LINIO) / 1.15 / 1.18 / TC;
                    comparativa.RatioLinio = Convert.ToString(R_linio / Convert.ToDouble(KARDEX_USD));
                    double R_ripley = Convert.ToDouble(Ratio_RIPLEY) / 1.15 / 1.18 / TC;
                    comparativa.RatioRIpley = Convert.ToString(R_ripley / Convert.ToDouble(KARDEX_USD));
                    double R_realplaza = Convert.ToDouble(Ratio_REALPLAZA) / 1.15 / 1.18 / TC;
                    comparativa.RatioRealPlaza = Convert.ToString(R_realplaza / Convert.ToDouble(KARDEX_USD));

                    lista.Add(comparativa);
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
