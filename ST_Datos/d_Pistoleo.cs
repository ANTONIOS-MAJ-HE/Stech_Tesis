using System;
using System.Collections.Generic;
using System.Text;
using ST_Entidades;
using System.Data.SqlClient;

namespace ST_Datos
{
    public class d_Pistoleo
    {
        d_SQLcon db_st = new d_SQLcon();
        
        public string Actualizar_Folio()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string act = "UPDATE A SET A.FOLIO = B.NRO_F12 FROM ST_PIST_CONS A JOIN OC_SF_CONS B ON A.NRO_OC = B.NRO_OC WHERE FOLIO IS NULL";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return null;
            }
            catch (Exception ex)
            {
               return  ex.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        public string Actualizar_prod_listo(e_Ordenes_pistoleo obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string updt = string.Format("UPDATE PROD_LISTO SET N_GUIA = '{0}',N_SERIE = '{1}', FOLIO = '{2}' WHERE NRO_OC = '{3}'"
                    , obj.NRO_GUIA, obj.NRO_SERIE, obj.FOLIO, obj.NRO_OC);
                string upd = "  UPDATE ST_PIST_CONS SET NRO_GUIA = B.N_GUIA , NRO_SERIE =B.N_SERIE , FOLIO = B.FOLIO FROM ST_PIST_CONS A JOIN PROD_LISTO B ON A.NRO_OC = B.NRO_OC ";
                SqlCommand cmd_0 = new SqlCommand(updt, con);
                SqlCommand cmd_1 = new SqlCommand(upd, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                return "LISTO!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public string Cargar_desp_nuevo ()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string get = "USE DB_ST EXEC msdb.dbo.sp_start_job 'Carga_pendientes_despacho'";
                SqlCommand cmd_0 = new SqlCommand(get, con);
                cmd_0.ExecuteNonQuery();
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
        public List<e_Pisto_Rapido> Lista_pisto_rapido()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Pisto_Rapido> lista = new List<e_Pisto_Rapido>();
                e_Pisto_Rapido pisto = null;
                string consulta = "SELECT PRODUCTO,CANAL FROM PROD_LISTO WHERE NRO_OC IS NULL";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pisto = new e_Pisto_Rapido();
                    pisto.PRODUCTO = (string)reader["PRODUCTO"];
                    pisto.CANAL = (string)reader["CANAL"];
                    lista.Add(pisto);
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
        public string Actualizar_pisto_rapido()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string act_0 = "UPDATE ST_PIST_CONS SET ESTADO = 'LISTO PARA RECOJO' FROM ST_PIST_CONS X JOIN (SELECT * FROM (SELECT PARTNUMBER AS PARTNUMB,CANAL AS CANAL_1,COUNT(PARTNUMBER) AS UNIDADES_LIST FROM ST_PIST_CONS GROUP BY PARTNUMBER,CANAL) A  JOIN (SELECT PARTNUMBER,CANAL,COUNT(PARTNUMBER) AS UNIDADES_LECT FROM PROD_LISTO GROUP BY PARTNUMBER,CANAL) B  ON A.CANAL_1 = B.CANAL  WHERE A.PARTNUMB = B.PARTNUMBER)Y ON X.PARTNUMBER = Y.PARTNUMBER WHERE  X.CANAL = Y.CANAL AND Y.UNIDADES_LIST = Y.UNIDADES_LECT AND Y.UNIDADES_LECT > 0";
                string act_1 = "UPDATE ST_PIST_CONS SET ESTADO = 'ERROR LECTURA'FROM ST_PIST_CONS X JOIN (SELECT * FROM (SELECT PARTNUMBER AS PARTNUMB,CANAL AS CANAL_1,COUNT(PARTNUMBER) AS UNIDADES_LIST FROM ST_PIST_CONS GROUP BY PARTNUMBER,CANAL) A JOIN(SELECT PARTNUMBER,CANAL,COUNT(PARTNUMBER) AS UNIDADES_LECT FROM PROD_LISTO GROUP BY PARTNUMBER,CANAL) B  ON A.CANAL_1 = B.CANAL  WHERE A.PARTNUMB = B.PARTNUMBER)Y ON X.PARTNUMBER = Y.PARTNUMBER WHERE  X.CANAL = Y.CANAL AND (Y.UNIDADES_LIST < Y.UNIDADES_LECT OR  Y.UNIDADES_LIST > Y.UNIDADES_LECT )";
                SqlCommand cmd_0 = new SqlCommand(act_0, con);
                SqlCommand cmd_1 = new SqlCommand(act_1, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_Ordenes_pistoleo> Lista_pistoleo_rapido( )
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Ordenes_pistoleo> lista = new List<e_Ordenes_pistoleo>();
                e_Ordenes_pistoleo pisto = null;
                string consult = "SELECT ISNULL(CANAL,'-') AS CANAL,ISNULL(NRO_OC,'-') AS NRO_OC,ISNULL(ESTADO,'-') AS ESTADO,ISNULL(EAN_UPC,'-') AS" +
                    " EAN_UPC,ISNULL(PRODUCTO,'-') AS PRODUCTO,ISNULL(CANTIDAD,0) AS CANTIDAD,ISNULL(NRO_SERIE,'-') AS NRO_SERIE,ISNULL(NRO_GUIA,'-') AS" +
                    " NRO_GUIA,ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO,5),'-') AS FECHA_DESPACHO,ISNULL(PARTNUMBER,'-') AS PARTNUMBER FROM ST_PIST_CONS";
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pisto = new e_Ordenes_pistoleo();
                    pisto.CANAL = (string)reader["CANAL"];
                    pisto.ESTADO = (string)reader["ESTADO"];
                    pisto.NRO_OC = (string)reader["NRO_OC"];
                    pisto.EAN_UPC = (string)reader["EAN_UPC"];
                    pisto.PRODUCTO = (string)reader["PRODUCTO"];
                    pisto.CANTIDAD = (int)reader["CANTIDAD"];
                    pisto.NRO_SERIE = (string)reader["NRO_SERIE"];
                    pisto.NRO_GUIA = (string)reader["NRO_GUIA"];
                    pisto.FECHA_DESPACHO = (string)reader["FECHA_DESPACHO"];
                    pisto.PARTNUMBER = (string)reader["PARTNUMBER"];
                    lista.Add(pisto);
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
        public List<e_Ordenes_pistoleo> Lista_cant_pendiente(e_Ordenes_pistoleo obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Ordenes_pistoleo> lista = new List<e_Ordenes_pistoleo>();
                e_Ordenes_pistoleo prod = null;
                string cons = string.Format("SELECT  distinct(NRO_OC) FROM ST_PIST_CONS WHERE ESTADO = 'PENDIENTE' AND CANAL LIKE '%{0}%'",obj.CANAL);
                SqlCommand cmd_0 = new SqlCommand(cons, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    prod = new e_Ordenes_pistoleo();
                    prod.NRO_OC = (string)reader["NRO_OC"];
                    lista.Add(prod);
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
        public string Actualizar_lista_ocs()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string actualiza = "UPDATE ST_PIST_CONS SET ESTADO = 'LISTO PARA RECOJO', NRO_GUIA = B.N_GUIA, NRO_SERIE= B.N_SERIE, FOLIO=B.FOLIO ,RESPONSABLE = B.RESPONSABLE FROM ST_PIST_CONS A JOIN PROD_LISTO B ON A.NRO_OC = B.NRO_OC WHERE A.PARTNUMBER = B.PARTNUMBER AND ESTADO = 'PENDIENTE'";
                SqlCommand cmd_0 = new SqlCommand(actualiza, con);
                cmd_0.ExecuteNonQuery();
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

        public string Ingresar_pistoleo_rapido(e_Prod_listo obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string insert = string.Format("INSERT INTO PROD_LISTO (EAN_UPC,PRODUCTO,CANAL,MODELO,PARTNUMBER,FECHA_PISTOLEO,RESPONSABLE)" +
                    "values('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}')", 
                                obj.EAN_UPC,obj.PRODUCTO,obj.CANAL,obj.MODELO,obj.PARTNUMBER,obj.RESPONSABLE);
                //string truncar = "TRUNCATE TABLE PROD_LISTO_TEMP";
                SqlCommand cmd_0 = new SqlCommand(insert, con);
               //SqlCommand cmd_1 = new SqlCommand(truncar, con);
                cmd_0.ExecuteNonQuery();
               // cmd_1.ExecuteNonQuery();
                return "LISTO!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public string Limpiar_prod_listo_temp()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string limpia = "TRUNCATE TABLE PROD_LISTO_TEMP";
                SqlCommand cmd_0 = new SqlCommand(limpia, con);
                cmd_0.ExecuteNonQuery();
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
        public string Ingresar_pistoleo(e_Prod_listo obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string insert = string.Format("INSERT INTO PROD_LISTO (EAN_UPC,PRODUCTO,CANAL,NRO_OC,MODELO,PARTNUMBER,FECHA_PISTOLEO, N_ITEM,N_GUIA,N_SERIE,RESPONSABLE,FOLIO)" +
                    " SELECT EAN_UPC,PRODUCTO,CANAL,NRO_OC,MODELO,PARTNUMBER,GETDATE(),N_ITEM,'{0}','{1}','{2}','{3}' FROM PROD_LISTO_TEMP",
                                obj.MODELO, obj.PARTNUMBER,obj.RESPONSABLE,obj.EAN_UPC);
                string truncar = "TRUNCATE TABLE PROD_LISTO_TEMP";
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                SqlCommand cmd_1 = new SqlCommand(truncar, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                return "LISTO!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        public string Eliminar_prod_lista_pisto_Temp(e_Prod_listo obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string delete = string.Format("DELETE FROM PROD_LISTO_TEMP WHERE N_ITEM = {0}", obj.N_ITEM);
                SqlCommand cmd_0 = new SqlCommand(delete, con);
                cmd_0.ExecuteNonQuery();
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
        public List<e_Pisto_Error>Lista_errores_pisto(e_Ordenes_pistoleo obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Pisto_Error> lista = new List<e_Pisto_Error>();
                e_Pisto_Error error = null;
                string consult = string.Format("Select * from( SELECT PRODUCTO,CANTIDAD,CANTIDAD_2, CANTIDAD - CANTIDAD_2 AS DIF, NRO_OC,CASE WHEN  (CANTIDAD - CANTIDAD_2= 0 )THEN 'LISTO' WHEN (CANTIDAD - CANTIDAD_2 > 0)THEN  CONCAT('FALTA(N): ',CANTIDAD - CANTIDAD_2,' PRODUCTO(S)') WHEN (CANTIDAD>0 AND CANTIDAD - CANTIDAD_2 < 0)THEN CONCAT('SOBRA(N) ',CANTIDAD_2 - CANTIDAD ,' PRODUCTO(S)') WHEN (CANTIDAD = 0 AND CANTIDAD_2 >0)THEN CONCAT(CANTIDAD_2-CANTIDAD,' PRODUCTO(S) NO LISTADO(S)')  END as MSG FROM (select A.PRODUCTO,A.CANTIDAD,COUNT(B.PRODUCTO) AS CANTIDAD_2 ,A.NRO_OC from ST_PIST_CONS A   left JOIN PROD_LISTO_TEMP B ON A.PARTNUMBER = B.PARTNUMBER WHERE A.CANAL like '%{0}%' AND A.NRO_OC like '%{1}%'  GROUP BY A.PRODUCTO,A.CANTIDAD,A.NRO_OC UNION SELECT B.PRODUCTO,0 AS CANTIDAD, COUNT(B.PRODUCTO) AS CANTIDAD_2 ,B.NRO_OC  FROM ST_PIST_CONS A RIGHT JOIN PROD_LISTO_TEMP B ON A.PARTNUMBER = B.PARTNUMBER WHERE A.PARTNUMBER IS NULL GROUP BY B.PRODUCTO,B.NRO_OC UNION select A.PRODUCTO,0 AS CANTIDAD,COUNT(B.PRODUCTO) AS CANTIDAD_2 ,a.NRO_OC from ST_PIST_CONS A   JOIN PROD_LISTO_TEMP B ON A.PARTNUMBER = B.PARTNUMBER   WHERE A.CANAL like '%{0}%' AND  B.PARTNUMBER NOT IN (SELECT PARTNUMBER FROM ST_PIST_DEMO WHERE CANAL LIKE '%{0}%' GROUP BY PARTNUMBER  HAVING COUNT (PARTNUMBER) >1 )  AND A.NRO_OC<>b.NRO_OC GROUP BY A.PRODUCTO,A.CANTIDAD,A.NRO_OC,A.NRO_OC) Z )Y where MSG <> 'LISTO' AND NRO_OC LIKE '%{1}%'", obj.CANAL,obj.NRO_OC);
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    error = new e_Pisto_Error();
                    error.PRODUCTO = (string)reader["PRODUCTO"];
                   // error.LEIDO = (string)reader["CANTIDAD_2"];
                    //error.LISTADO = (string)reader["CANTIDAD"];
                    error.MENSAJE = (string)reader["MSG"];
                    lista.Add(error);
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

        public List<e_Prod_listo>Lista_prod_listos()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Prod_listo> lista = new List<e_Prod_listo>();
                e_Prod_listo prod = null;
                string listar = "SELECT ISNULL(EAN_UPC,'-') AS EAN_UPC , ISNULL(PRODUCTO,'-') AS PRODUCTO, ISNULL(CANAL,'-') AS CANAL, ISNULL(NRO_OC,'-') AS NRO_OC, ISNULL(MODELO,'-') AS MODELO, ISNULL(PARTNUMBER,'-') AS PARTNUMBER,N_ITEM FROM PROD_LISTO_TEMP";
                SqlCommand cmd_0 = new SqlCommand(listar, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    prod = new e_Prod_listo();
                    prod.EAN_UPC = (string)reader["EAN_UPC"];
                    prod.CANAL = (string)reader["CANAL"];
                    prod.MODELO = (string)reader["MODELO"];
                    prod.NRO_OC = (string)reader["NRO_OC"];
                    prod.PARTNUMBER = (string)reader["PARTNUMBER"];
                    prod.PRODUCTO = (string)reader["PRODUCTO"];
                    prod.N_ITEM = (int)reader["N_ITEM"];
                    lista.Add(prod);
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
        public string Ingresar_prod_temp(e_Prod_listo obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string ingresar = string.Format("INSERT INTO PROD_LISTO_TEMP (EAN_UPC,PRODUCTO,CANAL,NRO_OC,MODELO,PARTNUMBER)" +
                    "VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",obj.EAN_UPC, obj.PRODUCTO,obj.CANAL,obj.NRO_OC,obj.MODELO,obj.PARTNUMBER);
                SqlCommand cmd_0 = new SqlCommand(ingresar, con);
                cmd_0.ExecuteNonQuery();
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
        public List<e_BuscaPisto>Lista_Prod_Listos_barras(e_BuscaPisto obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_BuscaPisto> lista = new List<e_BuscaPisto>();
                e_BuscaPisto prod = null;
                string consulta = string.Format("SELECT ISNULL(EAN_UPC,'-') AS EAN_UPC, ISNULL(TITULO,'-') AS PRODUCTO, ISNULL(MODELO,'-')AS MODELO , ISNULL(PARTNUMBER,'-') AS" +
                    " PARTNUMBER  FROM ST_STOCK WHERE CONCAT(EAN,' - ',UPC) LIKE '%{0}%'", obj.EAN_UPC);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    prod = new e_BuscaPisto();
                    prod.EAN_UPC = (string)reader["EAN_UPC"];
                    prod.MODELO = (string)reader["MODELO"];
                    prod.PARTNUMBER = (string)reader["PARTNUMBER"];
                    prod.PRODUCTO = (string)reader["PRODUCTO"];
             
                    lista.Add(prod);
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
        public List<e_BuscaPisto> Lista_Prod_Listos_part(e_BuscaPisto obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_BuscaPisto> lista = new List<e_BuscaPisto>();
                e_BuscaPisto prod = null;
                string consulta = string.Format("SELECT ISNULL(EAN_UPC,'-') AS EAN_UPC, ISNULL(TITULO,'-') AS PRODUCTO, ISNULL(MODELO,'-')AS MODELO , ISNULL(PARTNUMBER,'-') AS" +
                    " PARTNUMBER  FROM ST_STOCK WHERE CONCAT(MODELO,' - ',PARTNUMBER,'-',MINICODIGO) LIKE '%{0}%'", obj.EAN_UPC);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    prod = new e_BuscaPisto();
                    prod.EAN_UPC = (string)reader["EAN_UPC"];
                    prod.MODELO = (string)reader["MODELO"];
                    prod.PARTNUMBER = (string)reader["PARTNUMBER"];
                    prod.PRODUCTO = (string)reader["PRODUCTO"];

                    lista.Add(prod);
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


        public List<e_Prod_OC> Lista_productosXorden (e_Ordenes_pistoleo obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Prod_OC> lista = new List<e_Prod_OC>();
                e_Prod_OC prod = null;
                string consulta = string.Format("SELECT ISNULL(EAN_UPC,'-')  AS EAN_UPC ,PRODUCTO, CANTIDAD FROM ST_PIST_CONS WHERE CANAL LIKE '%{0}%' AND NRO_OC LIKE '%{1}%'",
                    obj.CANAL, obj.NRO_OC);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    prod = new e_Prod_OC();
                    prod.EAN_UPC = (string)reader["EAN_UPC"];
                    prod.PRODUCTO = (string)reader["PRODUCTO"];
                    prod.CANTIDAD = (int)reader["CANTIDAD"];
                    lista.Add(prod);
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

        public List<e_Ordenes_pistoleo> Lista_pistoleo_oc (e_Ordenes_pistoleo obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Ordenes_pistoleo> lista = new List<e_Ordenes_pistoleo>();
                e_Ordenes_pistoleo pisto = null;
                string consult = string.Format("SELECT B.STOCK_FINAL,ISNULL(CANAL,'-') AS CANAL,ISNULL(NRO_OC,'-') AS NRO_OC,ISNULL(ESTADO,'-') AS ESTADO,ISNULL(A.EAN_UPC,'-') AS EAN_UPC,ISNULL(PRODUCTO,'-') AS PRODUCTO,ISNULL(CANTIDAD,0) AS CANTIDAD,ISNULL(NRO_SERIE,'-') AS NRO_SERIE,ISNULL(NRO_GUIA,'-') AS NRO_GUIA,ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO,5),'-') AS FECHA_DESPACHO,ISNULL(A.PARTNUMBER,'-') AS PARTNUMBER, ISNULL(FOLIO,'-') AS FOLIO FROM ST_PIST_CONS A JOIN ST_STOCK_HST_CONSULTA B ON A.PARTNUMBER = B.PARTNUMBER WHERE CANAL LIKE '%{0}%' AND CONCAT(B.EAN,' - ',B.UPC) LIKE '%{1}%' AND NRO_OC IN (SELECT ISNULL(NRO_OC,'-') AS NRO_OC FROM ST_PIST_CONS WHERE CANAL LIKE '%{0}%' AND   (YEAR(FECHA_PROCESO)*10000 + MONTH(FECHA_PROCESO)*100+DAY(FECHA_PROCESO) = YEAR(GETDATE())*10000 + MONTH(GETDATE())*100+DAY(GETDATE())) OR ESTADO = 'PENDIENTE')", obj.CANAL, obj.EAN_UPC);
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pisto = new e_Ordenes_pistoleo();
                    pisto.STOCK = (int)reader["STOCK_FINAL"];
                    pisto.CANAL = (string)reader["CANAL"];
                    pisto.ESTADO = (string)reader["ESTADO"];
                    pisto.NRO_OC = (string)reader["NRO_OC"];
                    pisto.EAN_UPC = (string)reader["EAN_UPC"];
                    pisto.PRODUCTO = (string)reader["PRODUCTO"];
                    pisto.CANTIDAD = (int)reader["CANTIDAD"];
                    pisto.NRO_SERIE = (string)reader["NRO_SERIE"];
                    pisto.NRO_GUIA = (string)reader["NRO_GUIA"];
                    pisto.FECHA_DESPACHO = (string)reader["FECHA_DESPACHO"];
                    pisto.PARTNUMBER = (string)reader["PARTNUMBER"];
                    pisto.FOLIO = (string)reader["FOLIO"];
                    lista.Add(pisto);
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
        public List<e_Pendiente_despacho> Lista_Pendiente_dsp (e_Pendiente_despacho obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Pendiente_despacho> lista = new List<e_Pendiente_despacho>();
                e_Pendiente_despacho pend = null;
                string consult = string.Format("SELECT ISNULL(CANAL,'-') AS CANAL,ISNULL(NRO_OC,'-') AS NRO_OC,ISNULL(SKU,'-') AS SKU," +
                    "ISNULL(EAN_UPC,'-') AS EAN_UPC,ISNULL(PRODUCTO,'-') AS PRODUCTO,ISNULL(MODELO,'-') AS MODELO," +
                    "ISNULL(MINI_CODIGO,'-') AS MINI_CODIGO,ISNULL(PARTNUMBER,'-') AS PARTNUMBER,ISNULL(CANTIDAD,0) AS CANTIDAD," +
                    "ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO,5),'-') AS FECHA_DESPACHO,ISNULL(STOCK_RESTANTE,0) AS STOCK_RESTANTE," +
                    "ISNULL(COURIER,'-') AS COURIER FROM ST_PIST_CONS WHERE CANAL LIKE '%{0}%' AND PRODUCTO LIKE '%{1}%' AND NRO_OC LIKE '%{2}%' AND" +
                    " MINI_CODIGO LIKE '%{3}%' AND FECHA_DESPACHO LIKE '%{4}%'  AND  (YEAR(FECHA_PROCESO)*10000 + MONTH(FECHA_PROCESO)*100+DAY(FECHA_PROCESO) = YEAR(GETDATE())*10000 + MONTH(GETDATE())*100+DAY(GETDATE()) OR ESTADO = 'PENDIENTE') ORDER BY CANAL ", obj.CANAL,obj.PRODUCTO,obj.NRO_OC,obj.MINI_CODIGO,obj.FECHA_DESPACHO);
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pend = new e_Pendiente_despacho();
                    pend.CANAL = (string)reader["CANAL"];
                    pend.NRO_OC = (string)reader["NRO_OC"];
                    pend.SKU = (string)reader["SKU"];
                    pend.EAN_UPC = (string)reader["EAN_UPC"];
                    pend.MODELO = (string)reader["MODELO"];
                    pend.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    pend.PARTNUMBER = (string)reader["PARTNUMBER"];
                    pend.CANTIDAD = (int)reader["CANTIDAD"];
                    pend.COURIER = (string)reader["COURIER"];
                    pend.PRODUCTO = (string)reader["PRODUCTO"];
                    pend.FECHA_DESPACHO = (string)reader["FECHA_DESPACHO"];
                    pend.STOCK_RESTANTE = (int)reader["STOCK_RESTANTE"];

                    lista.Add(pend);
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

        public List<e_cant_pendientes>Lista_cant_canal ()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_cant_pendientes> list = new List<e_cant_pendientes>();
                e_cant_pendientes pend = null;
                string consult = "SELECT CANAL, COUNT(CANAL) AS CANTIDAD FROM ST_PIST_CONS WHERE ESTADO = 'PENDIENTE' GROUP BY CANAL";
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pend = new e_cant_pendientes();
                    pend.CANAL = (string)reader["CANAL"];
                    pend.CANTIDAD = (int)reader["CANTIDAD"];
                    list.Add(pend);
                }
                reader.Close();
                return list;
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
