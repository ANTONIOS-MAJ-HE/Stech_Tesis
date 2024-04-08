using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_Incidencia
    {
        d_SQLcon db_st = new d_SQLcon();

        public List<e_Incidencia> Listar_incidencias()
        {
            try
            {
                List<e_Incidencia> lst_incidencias = new List<e_Incidencia>();
                e_Incidencia incidencia = null;
                SqlConnection con = db_st.Conecta_DB();
                SqlCommand cmd_0 = new SqlCommand("	SELECT  ID_INCIDENCIA, ISNULL(TIPO,'-') AS TIPO , ISNULL(CANAL,'-') AS CANAL, FECHA_PROCESO, ISNULL(NRO_OC,'-') AS NRO_OC,ISNULL(TRY_CONVERT(varchar, FECHA_RETORNO), '-') AS FECHA_RETORNO, ISNULL(MINICOD_PRODUCTO, '-') AS MINICOD_PRODUCTO, ISNULL(MINICOD_PRODUCTO_2, '-') AS MINICOD_PRODUCTO_2, ISNULL(ESTADO_DEVOLUCION, '-') AS ESTADO_DEVOLUCION, ISNULL(OBSERVACIONES, '-') AS OBSERVACIONES,ISNULL(TRY_CONVERT(varchar, FECHA_REGISTRO), '-') AS  FECHA_REGISTRO, ISNULL(TRY_CONVERT(varchar, FECHA_REPROG), '-') AS FECHA_REPROG, ISNULL(TRY_CONVERT(VARCHAR, NUEVA_CANT), '-') AS NUEVA_CANT FROM ST_INCIDENCIAS_CONS ORDER BY ID_INCIDENCIA DESC", con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    incidencia = new e_Incidencia();
                    incidencia.Id_Incidencia = (int)reader["ID_INCIDENCIA"];
                    incidencia.Tipo = (string)reader["TIPO"];
                    incidencia.Canal = (string)reader["CANAL"];
                    incidencia.Fecha_Proceso = Convert.ToString((DateTime)reader["FECHA_PROCESO"]);
                    incidencia.Nro_OC = (string)reader["NRO_OC"];
                    incidencia.Fecha_Retorno = (string)reader["FECHA_RETORNO"];
                    incidencia.Minicod_1 = (string)reader["MINICOD_PRODUCTO"];
                    incidencia.Minicod_2 = (string)reader["MINICOD_PRODUCTO_2"];
                    incidencia.Estado_Dev = (string)reader["ESTADO_DEVOLUCION"];
                    incidencia.Observaciones = (string)reader["OBSERVACIONES"];
                    incidencia.Fecha_Registro = (string)reader["fecha_registro"];
                    incidencia.Fecha_Reprogramado = (string)reader["FECHA_REPROG"];
                    incidencia.Nvo_cant = (string)reader["NUEVA_CANT"];

                    lst_incidencias.Add(incidencia);

                }
                reader.Close();
                return lst_incidencias;
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

        public List<e_Incidencia> Listar_incidencias_filtro(e_Incidencia obj)
        {
            try
            {
                List<e_Incidencia> lst_incidencias = new List<e_Incidencia>();
                e_Incidencia incidencia = null;
                SqlConnection con = db_st.Conecta_DB();
                string consulta = string.Format("SELECT  ID_INCIDENCIA, TIPO, CANAL, FECHA_PROCESO, NRO_OC, ISNULL(TRY_CONVERT(varchar, FECHA_RETORNO), '-') AS FECHA_RETORNO, MINICOD_PRODUCTO, MINICOD_PRODUCTO_2, ESTADO_DEVOLUCION, OBSERVACIONES, FECHA_REGISTRO, ISNULL(TRY_CONVERT(varchar, FECHA_REPROG), '-') AS FECHA_REPROG , ISNULL(TRY_CONVERT(VARCHAR ,NUEVA_CANT),'-') AS NUEVA_CANT FROM ST_INCIDENCIAS_CONS WHERE TIPO LIKE '%{0}%' and CANAL LIKE '%{1}%' AND NRO_OC LIKE '%{2}%' AND concat(substring(convert(varchar, FECHA_REGISTRO, 3), 0, 7), '20', substring(convert(varchar, FECHA_REGISTRO, 3), 7, 2)) like '%{3}%'ORDER BY ID_INCIDENCIA DESC", obj.Tipo, obj.Canal, obj.Nro_OC, obj.Fecha_Registro);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    incidencia = new e_Incidencia();
                    incidencia.Id_Incidencia = (int)reader["ID_INCIDENCIA"];
                    incidencia.Tipo = (string)reader["TIPO"];
                    incidencia.Canal = (string)reader["CANAL"];
                    incidencia.Fecha_Proceso = Convert.ToString((DateTime)reader["FECHA_PROCESO"]);
                    incidencia.Nro_OC = (string)reader["NRO_OC"];
                    incidencia.Fecha_Retorno = (string)reader["FECHA_RETORNO"];
                    incidencia.Minicod_1 = (string)reader["MINICOD_PRODUCTO"];
                    incidencia.Minicod_2 = (string)reader["MINICOD_PRODUCTO_2"];
                    incidencia.Estado_Dev = (string)reader["ESTADO_DEVOLUCION"];
                    incidencia.Observaciones = (string)reader["OBSERVACIONES"];
                    incidencia.Fecha_Registro = Convert.ToString((DateTime)reader["fecha_registro"]);
                    incidencia.Fecha_Reprogramado = (string)reader["FECHA_REPROG"];
                    incidencia.Nvo_cant = (string)reader["NUEVA_CANT"];

                    lst_incidencias.Add(incidencia);

                }
                reader.Close();
                return lst_incidencias;
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
        public string Registrar_incidencias(e_Incidencia obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string insert = string.Format("INSERT INTO ST_INCIDENCIAS_INPUT (TIPO,CANAL,FECHA_PROCESO,NRO_OC,FECHA_RETORNO," +
                    "MINICOD_PRODUCTO,MINICOD_PRODUCTO_2,ESTADO_DEVOLUCION,OBSERVACIONES,FECHA_REGISTRO,FECHA_REPROG,NUEVA_CANT) " +
                    "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", obj.Tipo, obj.Canal, obj.Fecha_Proceso, obj.Nro_OC,
                    obj.Fecha_Retorno, obj.Minicod_1, obj.Minicod_2, obj.Estado_Dev, obj.Observaciones, obj.Fecha_Registro, obj.Fecha_Reprogramado, obj.Nvo_cant);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Se insertó correctamente";
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
        public string Ingresar_a_Consolid()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string parche = "UPDATE ST_INCIDENCIAS_INPUT SET FECHA_PROCESO = CONCAT('0',FECHA_PROCESO) WHERE LEN(FECHA_PROCESO)=9 " +
                    "UPDATE ST_INCIDENCIAS_INPUT SET FECHA_RETORNO = CONCAT('0',FECHA_RETORNO) WHERE LEN(FECHA_RETORNO)=9 " +
                    "UPDATE ST_INCIDENCIAS_INPUT SET FECHA_REGISTRO = CONCAT('0',FECHA_REGISTRO) WHERE LEN(FECHA_REGISTRO)=9 " +
                    "UPDATE ST_INCIDENCIAS_INPUT SET FECHA_REPROG = CONCAT('0',FECHA_REPROG) WHERE LEN(FECHA_REPROG)=9";
                string close = "SET IDENTITY_INSERT ST_INCIDENCIAS_CONS OFF";
                string insert = "INSERT INTO ST_INCIDENCIAS_CONS (TIPO,CANAL,FECHA_PROCESO,NRO_OC,FECHA_RETORNO,MINICOD_PRODUCTO,MINICOD_PRODUCTO_2,ESTADO_DEVOLUCION,OBSERVACIONES,FECHA_REGISTRO,FECHA_REPROG,NUEVA_CANT)SELECT RTRIM(LTRIM(TIPO)),RTRIM(LTRIM(CANAL)),TRY_CONVERT(DATETIME,CONCAT(SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_PROCESO)),'/',''),5,4),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_PROCESO)),'/',''),3,2),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_PROCESO)),'/',''),1,2))),RTRIM(LTRIM(NRO_OC)),TRY_CONVERT(DATETIME,CONCAT(SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_RETORNO)),'/',''),5,4),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_RETORNO)),'/',''),3,2),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_RETORNO)),'/',''),1,2))),RTRIM(LTRIM(MINICOD_PRODUCTO)),RTRIM(LTRIM(MINICOD_PRODUCTO_2)),RTRIM(LTRIM(ESTADO_DEVOLUCION)),RTRIM(LTRIM(OBSERVACIONES)),GETDATE(),  TRY_CONVERT(DATETIME,CONCAT(SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_REPROG)),'/',''),5,4),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_REPROG)),'/',''),3,2),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_REPROG)),'/',''),1,2))) , TRY_CONVERT(INT,RTRIM(LTRIM(NUEVA_CANT))) FROM ST_INCIDENCIAS_INPUT  WHERE ID_INCIDENCIA NOT IN (SELECT ID_INCIDENCIA FROM ST_INCIDENCIAS_CONS)";
                string open = "SET IDENTITY_INSERT ST_INCIDENCIAS_CONS ON";
                SqlCommand cmd_0 = new SqlCommand(close, con);
                SqlCommand cmd_1 = new SqlCommand(insert, con);
                SqlCommand cmd_2 = new SqlCommand(open, con);
                SqlCommand cmd_4 = new SqlCommand(parche, con);
                cmd_4.ExecuteNonQuery();
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
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
        public string Actualizar_Consolid(e_Incidencia obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string actualizar = string.Format("UPDATE ST_INCIDENCIAS_CONS SET TIPO = '{0}', CANAL = '{1}',NRO_OC = '{2}'" +
                    ",MINICOD_PRODUCTO='{3}',MINICOD_PRODUCTO_2 ='{4}',ESTADO_DEVOLUCION = '{5}'," +
                    "OBSERVACIONES = CONCAT('{6}',' - MODIFICADO EL: ',GETDATE()), FECHA_REPROG = '{7}' WHERE ID_INCIDENCIA = {8}",
                    obj.Tipo, obj.Canal, obj.Nro_OC, obj.Minicod_1, obj.Minicod_2, obj.Estado_Dev, obj.Observaciones, obj.Fecha_Reprogramado, obj.Id_Incidencia);
                SqlCommand cmd_0 = new SqlCommand(actualizar, con);
                cmd_0.ExecuteNonQuery();
                return "Se modificó correctamente";
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
        public string Actualizar_Saga()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A SET A.PART_NUMB_REAL = C.PARTNUMBER, A.ST_OBSERVACION = CONCAT(A.ST_OBSERVACION,' / ', B.OBSERVACIONES,' - ',GETDATE()) FROM OC_SF_CONS A JOIN ST_STOCK V ON A.PART_NUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.NRO_OC = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.ST_OBSERVACION IS NULL";
                string anulacion = "UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0, A.FECHA_ENTREGA = NULL, A.ST_OBSERVACION = CONCAT(A.ST_OBSERVACION,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_SF_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_OC = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN in ('RECIBIDO', 'REZAGADO')";
                string devolucion = "UPDATE A SET  A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_SF_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_OC = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN in ('RECIBIDO', 'REZAGADO')";
                string reprog = "UPDATE A  SET A.ST_DESPACHO = 'PENDIENTE', A.ST_ORDEN = 'RECIBIDO', A.FECHA_ENTREGA = B.FECHA_REPROG, A.UNIDADES_REAL = UNIDADES FROM OC_SF_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_OC = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_3 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_3.ExecuteNonQuery();
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
        public string Actualizar_Ripley()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A SET  A.PART_NUMB_REAL = C.PARTNUMBER, A.OBSERVACIONES =  CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_RPL_CONS A JOIN ST_STOCK V ON A.PART_NUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.OBSERVACIONES IS NULL";
                string anulacion = "UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0, A.FECHA_DESPACHO = NULL, A.OBSERVACIONES = CONCAT(A.OBSERVACIONES, ' / ', B.OBSERVACIONES, ' - ', GETDATE()) FROM OC_RPL_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN = 'RECIBIDO'";
                string devolucion = "UPDATE A SET  A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_RPL_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN = 'RECIBIDO'";
                string reprog = "UPDATE A  SET A.ST_DESPACHO = 'PENDIENTE', A.ST_ORDEN = 'RECIBIDO', A.FECHA_DESPACHO = B.FECHA_REPROG, UNIDADES_REAL = CANTIDAD FROM OC_RPL_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_3 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_3.ExecuteNonQuery();
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
        public string Actualizar_Linio()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A  SET  A.PART_NUMB_REAL = C.PARTNUMBER, A.OBSERVACIONES =  CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_LNO_CONS A JOIN ST_STOCK V ON A.PART_NUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.ORDER_NUMBER = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.OBSERVACIONES IS NULL";
                string anulacion = "UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0, A.FECHA_DESPACHO = NULL, A.OBSERVACIONES =  CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_LNO_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.ORDER_NUMBER = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN = 'RECIBIDO'";
                string devolucion = "UPDATE A SET A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_LNO_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.ORDER_NUMBER = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN = 'RECIBIDO'";
                string reprog = "UPDATE A  SET A.ST_DESPACHO = 'PENDIENTE', A.ST_ORDEN = 'RECIBIDO', A.FECHA_DESPACHO = B.FECHA_REPROG, A.UNIDADES_REAL = 1 FROM OC_LNO_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.ORDER_NUMBER = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();

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
        public string Actualizar_RealPlaza()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A SET  A.PARTNUMBER_REAL = C.PARTNUMBER, A.OBSERVACIONES =  CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_RPG_CONS A JOIN ST_STOCK V ON A.PARTNUMBER_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.NUMERO = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.OBSERVACIONES IS NULL";
                string anulacion = "UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0,A.FECHA_DESPACHO = NULL, A.OBSERVACIONES =  CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_RPG_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NUMERO = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN = 'RECIBIDO'";
                string devolucion = "UPDATE A SET  A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_RPG_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NUMERO = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN = 'RECIBIDO'";
                string reprogr = "	UPDATE A  SET A.ST_DESPACHO = 'PENDIENTE', A.ST_ORDEN = 'RECIBIDO', A.FECHA_DESPACHO = B.FECHA_REPROG, A.UNIDADES_REAL = CANTIDAD_SKU FROM OC_RPG_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NUMERO = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprogr, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
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
        public string Actulizar_Mercado_Libre()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = " UPDATE A SET  A.PARTNUMB_REAL = C.PARTNUMBER, A.OBSERVACIONES =  CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_MLIBRE_CONS A JOIN ST_STOCK V ON A.PARTNUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.N_VENTA = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.OBSERVACIONES IS NULL";
                string anulacion = " UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0, A.FECHA_DESPACHO = NULL, A.OBSERVACIONES =  CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_MLIBRE_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.N_VENTA = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN ='RECIBIDO'";
                string devolucion = " UPDATE A SET  A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_MLIBRE_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.N_VENTA = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN = 'RECIBIDO'";
                string reprog = "UPDATE A  SET A.ST_DESPACHO = 'PENDIENTE', A.ST_ORDEN = 'RECIBIDO', A.FECHA_DESPACHO = B.FECHA_REPROG,A.UNIDADES_REAL = UNIDADES FROM OC_MLIBRE_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.N_VENTA = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
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
        public string Actualizar_Catphone()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A SET A.PARTNUMB_REAL = C.PARTNUMBER, OBSERVACIONES = CONCAT(A.OBSERVACIONES, ' / ',B.OBSERVACIONES, ' - ', GETDATE()) FROM OC_CATPHONE_CONS A JOIN ST_STOCK V ON A.PARTNUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.N_VENTA = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.OBSERVACIONES IS NULL";
                string anulacion = "UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0, A.FECHA_DESPACHO = NULL, A.OBSERVACIONES = CONCAT(A.OBSERVACIONES, ' / ', B.OBSERVACIONES, ' - ', GETDATE()) FROM OC_CATPHONE_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.N_VENTA = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN = 'RECIBIDO'";
                string devolucion = " UPDATE A SET  A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_CATPHONE_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.N_VENTA = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN = 'RECIBIDO'";
                string reprog = " UPDATE A  SET A.ST_DESPACHO = 'PENDIENTE', A.ST_ORDEN = 'RECIBIDO', A.FECHA_DESPACHO = B.FECHA_REPROG, A.UNIDADES_REAL = UNIDADES FROM OC_CATPHONE_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.N_VENTA = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
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
        public string Actualizar_Lumingo()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A SET A.PARTNUMB_REAL = C.PARTNUMBER, A.OBSERVACIONES = CONCAT(A.OBSERVACIONES, ' / ', B.OBSERVACIONES, ' - ', GETDATE()) FROM OC_LMG_CONS A JOIN ST_STOCK V ON A.PARTNUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.N_OC = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.OBSERVACIONES IS NULL";
                string anulacion = " UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0, A.FECHA_DESPACHO = NULL, A.OBSERVACIONES = CONCAT(A.OBSERVACIONES, ' / ', B.OBSERVACIONES, ' - ', GETDATE()) FROM OC_LMG_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.N_OC = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN = 'RECIBIDO'";
                string devolucion = "UPDATE A SET A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_LMG_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.N_OC = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN = 'RECIBIDO'";
                string reprog = "UPDATE A SET A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_LMG_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.N_OC = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN = 'RECIBIDO'";

                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
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
        public string Actualizar_Oficina()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "";
                string anulacion = "UPDATE ST_PEDIDO_DETALLE SET ST_DESPACHO = 'CANCELADO', ST_PEDIDO = 'ANULADO', CANTIDAD = 0," +
                    " FECHA_DESPACHO = NULL FROM ST_PEDIDO_DETALLE A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC " +
                    "WHERE B.TIPO = 'ANULACION' AND A.ST_PEDIDO = 'RECIBIDO'";
                string devolucion = "UPDATE ST_PEDIDO_DETALLE SET ST_PEDIDO = 'DEVUELTO', CANTIDAD = 0 FROM ST_PEDIDO_DETALLE A JOIN" +
                    " ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_PEDIDO = 'RECIBIDO'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
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
        public string Actualizar_Juntoz()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE OC_JTZ_CONS SET  PART_NUMB_REAL = C.PARTNUMBER, OBSERVACIONES =  CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_JTZ_CONS A JOIN ST_STOCK V ON A.PART_NUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.OBSERVACIONES IS NULL";
                string anulacion = "UPDATE OC_JTZ_CONS SET ST_DESPACHO = 'CANCELADO', ST_ORDEN = 'ANULADO', UNIDADES_REAL = 0,FECHA_DESPACHO = NULL, OBSERVACIONES = CONCAT(A.OBSERVACIONES, ' / ', B.OBSERVACIONES, ' - ', GETDATE()) FROM OC_JTZ_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN = 'RECIBIDO'";
                string devolucion = "UPDATE OC_JTZ_CONS SET  ST_ORDEN = 'DEVUELTO', UNIDADES_REAL = 0 FROM OC_JTZ_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN = 'RECIBIDO'";
                string reprog = "UPDATE OC_JTZ_CONS  SET ST_DESPACHO = 'PENDIENTE', ST_ORDEN = 'RECIBIDO', FECHA_DESPACHO = B.FECHA_REPROG,UNIDADES_REAL = CANTIDAD FROM OC_JTZ_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
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

        public string Actualizar_Kingston()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A SET  A.PART_NUMB_REAL = C.PARTNUMBER, A.OBSERVACIONES =  CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_KNG_CONS A JOIN ST_STOCK V ON A.PART_NUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.OBSERVACIONES IS NULL";
                string anulacion = "UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0,A.FECHA_DESPACHO = NULL, A.OBSERVACIONES = CONCAT(A.OBSERVACIONES, ' / ', B.OBSERVACIONES, ' - ', GETDATE()) FROM OC_KNG_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN = 'RECIBIDO'";
                string devolucion = "UPDATE A SET  A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_KNG_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN = 'RECIBIDO'";
                string reprog = "UPDATE OC_KNG_CONS  SET ST_DESPACHO = 'PENDIENTE', ST_ORDEN = 'RECIBIDO', FECHA_DESPACHO = B.FECHA_REPROG,UNIDADES_REAL = CANTIDAD FROM OC_KNG_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NRO_PEDIDO = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
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
        public string Actualizar_Coolbox()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A SET  A.PARTNUMBER_REAL = C.PARTNUMBER, A.ST_OBSERVACION =  CONCAT(A.ST_OBSERVACION,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_CLB_CONS A JOIN ST_STOCK V ON A.PARTNUMBER_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.OC_ORDER = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.ST_OBSERVACION IS NULL";
                string anulacion = "UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDER = 'ANULADO', A.UNIDADES_REAL = 0,A.FECHA_DESPACHO = NULL, A.ST_OBSERVACION = CONCAT(A.ST_OBSERVACION, ' / ', B.OBSERVACIONES, ' - ', GETDATE()) FROM OC_CLB_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.OC_ORDER = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDER = 'RECIBIDO'";
                string devolucion = "UPDATE A SET  A.ST_ORDER = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_CLB_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.OC_ORDER = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDER = 'RECIBIDO'";
                string reprog = "UPDATE OC_CLB_CONS  SET ST_DESPACHO = 'PENDIENTE', ST_ORDER = 'RECIBIDO', FECHA_DESPACHO = B.FECHA_REPROG,UNIDADES_REAL = QUANTITY_SKU FROM OC_CLB_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.OC_ORDER = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
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

        //agregando incidencia de falabela

        public string Actualizar_Falabella()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A SET A.PART_NUMB_REAL = C.PARTNUMBER, A.OBSERVACIONES = CONCAT(A.OBSERVACIONES,' / ', B.OBSERVACIONES,' - ',GETDATE()) FROM OC_FBL_CONS A JOIN ST_STOCK V ON A.PART_NUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.ORDER_NUMBER = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.OBSERVACIONES IS NULL";
                string anulacion = "UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0, A.FECHA_DESPACHO = NULL, A.OBSERVACIONES = CONCAT(A.OBSERVACIONES,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_FBL_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.ORDER_NUMBER = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN = 'RECIBIDO'";
                string devolucion = "UPDATE A SET  A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_FBL_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.ORDER_NUMBER = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN in ('RECIBIDO', 'REZAGADO')";
                string reprog = "UPDATE A  SET A.ST_DESPACHO = 'PENDIENTE', A.ST_ORDEN = 'RECIBIDO', A.FECHA_DESPACHO = B.FECHA_REPROG, A.UNIDADES_REAL = 1FROM OC_FBL_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.ORDER_NUMBER = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
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

        //agregando incidencia de conecta

        public string Actualizar_Conecta()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string cambio = "UPDATE A SET A.PART_NUMB_REAL = C.PARTNUMBER, A.ST_OBSERVACION = CONCAT(A.ST_OBSERVACION,' / ', B.OBSERVACIONES,' - ',GETDATE()) FROM OC_CONECTA_CONS A JOIN ST_STOCK V ON A.PART_NUMB_REAL = V.PARTNUMBER JOIN ST_INCIDENCIAS_CONS B ON A.NUMERO_ORDEN = B.NRO_OC JOIN ST_STOCK C ON B.MINICOD_PRODUCTO_2 = C.MINI_CODIGO WHERE V.MINI_CODIGO = B.MINICOD_PRODUCTO AND B.TIPO = 'CAMBIO' AND A.ST_OBSERVACION IS NULL";
                string anulacion = "UPDATE A SET A.ST_DESPACHO = 'CANCELADO', A.ST_ORDEN = 'ANULADO', A.UNIDADES_REAL = 0, A.FECHA_ENTREGA = NULL, A.ST_OBSERVACION = CONCAT(A.ST_OBSERVACION,' / ',B.OBSERVACIONES,' - ',GETDATE()) FROM OC_CONECTA_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NUMERO_ORDEN = B.NRO_OC WHERE B.TIPO = 'ANULACION' AND A.ST_ORDEN = 'RECIBIDO'";
                string devolucion = "UPDATE A SET  A.ST_ORDEN = 'DEVUELTO', A.UNIDADES_REAL = 0 FROM OC_CONECTA_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NUMERO_ORDEN = B.NRO_OC WHERE B.TIPO = 'DEVOLUCION' AND A.ST_ORDEN in ('RECIBIDO', 'REZAGADO')";
                string reprog = "UPDATE A  SET A.ST_DESPACHO = 'PENDIENTE', A.ST_ORDEN = 'RECIBIDO', A.FECHA_ENTREGA = B.FECHA_REPROG, A.UNIDADES_REAL = UNIDADES_SOLICITADAS FROM OC_CONECTA_CONS A JOIN ST_INCIDENCIAS_CONS B ON A.NUMERO_ORDEN = B.NRO_OC WHERE B.TIPO = 'REPROGRAMACION'";
                SqlCommand cmd_0 = new SqlCommand(cambio, con);
                SqlCommand cmd_1 = new SqlCommand(anulacion, con);
                SqlCommand cmd_2 = new SqlCommand(devolucion, con);
                SqlCommand cmd_4 = new SqlCommand(reprog, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
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

        public e_Kardex Buscar_Kardex(string filtro)
        {
            SqlConnection con = db_st.Conecta_DB();
            string Busca = "SELEcT TOP 1 TIPO,FECHA_PROCESO,FECHA_FACTURA,TC_FECHA_FACT,PARTNUMBER,STOCK_INICIAL,MONEDA,COSTO_UNI_DOL_STOCK_INI,COSTO_UNI_SOL_SOTCK_INI," +
                "MONTO_TOTAL_DOL_INI,MONTO_TOTAL_SOL_INI,STOCK_SALIDA,COSTO_UNI_SAL_DOL,COSTO_UNI_SAL_SOL,MONTO_SAL_DOL,MONTO_SAL_SOL,STOCK_FINAL," +
                "ISNULL(COSTO_UNI_PON_DOL,COSTO_UNI_DOL_STOCK_INI) AS COSTO_UNI_PON_DOL," +
                "ISNULL(COSTO_UNI_PON_SOL,COSTO_UNI_SOL_SOTCK_INI) as COSTO_UNI_PON_SOL,MONTO_DOL_TOTAL_FINAL,MONTO_SOL_TOTAL_FINAL from ST_KARDEX WHERE NUMERO_ORDEN_FACT = '" + filtro + "' order by FECHA_FACTURA DESC";
            SqlCommand cmd_0 = new SqlCommand(Busca, con);
            SqlDataReader reader = cmd_0.ExecuteReader();
            e_Kardex e_Kardex = new e_Kardex();
            while (reader.Read())
            {
                e_Kardex.TIPO = (string)reader["TIPO"];
                e_Kardex.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
                e_Kardex.FECHA_FACTURA = Convert.ToString((DateTime)reader["FECHA_FACTURA"]);
                e_Kardex.TC_FECHA_FACT = (double)reader["TC_FECHA_FACT"];
                e_Kardex.PARTNUMBER = (string)reader["PARTNUMBER"];
                e_Kardex.STOCK_INICIAL = (int)reader["STOCK_INICIAL"];
                e_Kardex.MONEDA = (string)reader["MONEDA"];
                e_Kardex.COSTO_UNI_DOL_STOCK_INI = (double)reader["COSTO_UNI_DOL_STOCK_INI"];
                e_Kardex.COSTO_UNI_SOL_SOTCK_INI = (double)reader["COSTO_UNI_SOL_SOTCK_INI"];
                e_Kardex.MONTO_TOTAL_DOL_INI = (double)reader["MONTO_TOTAL_DOL_INI"];
                e_Kardex.MONTO_TOTAL_SOL_INI = (double)reader["MONTO_TOTAL_SOL_INI"];
                e_Kardex.STOCK_SALIDA = (int)reader["STOCK_SALIDA"];
                e_Kardex.COSTO_UNI_SAL_DOL = (double)reader["COSTO_UNI_SAL_DOL"];
                e_Kardex.COSTO_UNI_SAL_SOL = (double)reader["COSTO_UNI_SAL_SOL"];
                e_Kardex.MONTO_SAL_DOL = (double)reader["MONTO_SAL_DOL"];
                e_Kardex.MONTO_SAL_SOL = (double)reader["MONTO_SAL_SOL"];
                e_Kardex.STOCK_FINAL = (int)reader["STOCK_FINAL"];
                e_Kardex.COSTO_UNI_PON_DOL = (double)reader["COSTO_UNI_PON_DOL"];
                e_Kardex.COSTO_UNI_PON_SOL = (double)reader["COSTO_UNI_PON_SOL"];
                e_Kardex.MONTO_DOL_TOTAL_FINAL = (double)reader["MONTO_DOL_TOTAL_FINAL"];
                e_Kardex.MONTO_SOL_TOTAL_FINAL = (double)reader["MONTO_SOL_TOTAL_FINAL"];
            }
            reader.Close();
            return e_Kardex;
        }
        public e_Kardex Buscar_Kardex_2(string filtro)
        {
            SqlConnection con = db_st.Conecta_DB();
            string Busca = "SELEcT TOP 1 TIPO,FECHA_PROCESO,FECHA_FACTURA,TC_FECHA_FACT,PARTNUMBER,STOCK_INICIAL,MONEDA,COSTO_UNI_DOL_STOCK_INI,COSTO_UNI_SOL_SOTCK_INI," +
                "MONTO_TOTAL_DOL_INI,MONTO_TOTAL_SOL_INI,STOCK_FINAL,ISNULL(COSTO_UNI_PON_DOL,COSTO_UNI_DOL_STOCK_INI) AS COSTO_UNI_PON_DOL," +
                "ISNULL(COSTO_UNI_PON_SOL,COSTO_UNI_SOL_SOTCK_INI) as COSTO_UNI_PON_SOL,MONTO_DOL_TOTAL_FINAL,MONTO_SOL_TOTAL_FINAL  from ST_KARDEX WHERE PARTNUMBER = '" + filtro + "' order by ID_KARDEX DESC";
            SqlCommand cmd_0 = new SqlCommand(Busca, con);
            SqlDataReader reader = cmd_0.ExecuteReader();
            e_Kardex e_Kardex = new e_Kardex();
            while (reader.Read())
            {
                e_Kardex.TIPO = (string)reader["TIPO"];
                e_Kardex.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
                e_Kardex.FECHA_FACTURA = Convert.ToString((DateTime)reader["FECHA_FACTURA"]);
                e_Kardex.TC_FECHA_FACT = (double)reader["TC_FECHA_FACT"];
                e_Kardex.PARTNUMBER = (string)reader["PARTNUMBER"];
                e_Kardex.STOCK_INICIAL = (int)reader["STOCK_INICIAL"];
                e_Kardex.MONEDA = (string)reader["MONEDA"];
                e_Kardex.COSTO_UNI_DOL_STOCK_INI = (double)reader["COSTO_UNI_DOL_STOCK_INI"];
                e_Kardex.COSTO_UNI_SOL_SOTCK_INI = (double)reader["COSTO_UNI_SOL_SOTCK_INI"];
                e_Kardex.MONTO_TOTAL_DOL_INI = (double)reader["MONTO_TOTAL_DOL_INI"];
                e_Kardex.MONTO_TOTAL_SOL_INI = (double)reader["MONTO_TOTAL_SOL_INI"];
                e_Kardex.STOCK_FINAL = (int)reader["STOCK_FINAL"];
                e_Kardex.COSTO_UNI_PON_DOL = (double)reader["COSTO_UNI_PON_DOL"];
                e_Kardex.COSTO_UNI_PON_SOL = (double)reader["COSTO_UNI_PON_SOL"];
                e_Kardex.MONTO_DOL_TOTAL_FINAL = (double)reader["MONTO_DOL_TOTAL_FINAL"];
                e_Kardex.MONTO_SOL_TOTAL_FINAL = (double)reader["MONTO_SOL_TOTAL_FINAL"];
            }
            reader.Close();
            return e_Kardex;
        }
        public string Actualizar_Kardex_Ent(e_Kardex obj)
        {
            SqlConnection con = db_st.Conecta_DB();
            string registra = string.Format("INSERT INTO ST_KARDEX (TIPO,FECHA_PROCESO,FECHA_FACTURA,TC_FECHA_FACT,PARTNUMBER," +
            "NUMERO_ORDEN_FACT,DETALLE,STOCK_INICIAL,MONEDA,COSTO_UNI_DOL_STOCK_INI,COSTO_UNI_SOL_SOTCK_INI,MONTO_TOTAL_DOL_INI,MONTO_TOTAL_SOL_INI," +
            "STOCK_ENTRADA,COSTO_UNI_ENT_DOL,COSTO_UNI_ENT_SOL,MONTO_ENT_DOL,MONTO_ENT_SOL,STOCK_SALIDA,COSTO_UNI_SAL_DOL,COSTO_UNI_SAL_SOL,MONTO_SAL_DOL" +
            ",MONTO_SAL_SOL,STOCK_FINAL,COSTO_UNI_PON_DOL,COSTO_UNI_PON_SOL,MONTO_DOL_TOTAL_FINAL,MONTO_SOL_TOTAL_FINAL,PRECIO_VENTA_SOLES,PRECIO_VENTA_DOLARES) VALUES " +
            "('{0}',GETDATE(),CONVERT(DATETIME,'{1}'),{2},'{3}','{4}','{5}',{6},'{7}',{8},{9},{10},{11}, {12},{13},{14},{15},{16}, {17},{18},{19},{20},{21}, " +
            "{22},{23},{24},{25},{26},{27},{28})",
            obj.TIPO, obj.FECHA_FACTURA, obj.TC_FECHA_FACT, obj.PARTNUMBER, obj.NUMERO_ORDEN_FACT, obj.DETALLE, obj.STOCK_INICIAL, obj.MONEDA, obj.COSTO_UNI_DOL_STOCK_INI,
            obj.COSTO_UNI_SOL_SOTCK_INI, obj.MONTO_TOTAL_DOL_INI, obj.MONTO_TOTAL_SOL_INI, obj.STOCK_ENTRADA, obj.COSTO_UNI_ENT_DOL, obj.COSTO_UNI_ENT_SOL,
            obj.MONTO_ENT_DOL, obj.MONTO_ENT_SOL, obj.STOCK_SALIDA, obj.COSTO_UNI_SAL_DOL, obj.COSTO_UNI_SAL_SOL, obj.MONTO_SAL_DOL, obj.MONTO_SAL_SOL,
            obj.STOCK_FINAL, obj.COSTO_UNI_PON_DOL, obj.COSTO_UNI_PON_SOL, obj.MONTO_DOL_TOTAL_FINAL, obj.MONTO_SOL_TOTAL_FINAL, obj.PRECIO_VENTA_SOLES,
            obj.PRECIO_VENTA_DOLARES);
            SqlCommand cmd_0 = new SqlCommand(registra, con);
            cmd_0.ExecuteNonQuery();

            return null;
        }
    }
}
