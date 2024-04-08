using System;
using System.Collections.Generic;
using System.Text;
using ST_Entidades;
using System.Data.SqlClient;

namespace ST_Datos
{
    public class d_Salida
    {
        d_SQLcon db_st = new d_SQLcon ();
        public List<e_Salida> Lista_salidas()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Salida> salidas = new List<e_Salida>();
                e_Salida salida = null;
                string consult = "SELECT ISNULL(TIPO,'-') AS TIPO ,ISNULL(NRO_ORDEN,'-') AS NRO_ORDEN ,ISNULL(TRY_CONVERT(VARCHAR,FECHA_SALIDA),'-') AS FECHA_SALIDA," +
                    " ISNULL(RESPONSABLE,'-') as RESPONSABLE, ISNULL(TIPO_COMPROBANTE,'-') AS TIPO_COMPROBANTE, ISNULL(SERIE_COMPROBANTE,'-') AS SERIE_COMPROBANTE," +
                    "ISNULL(NRO_COMPROBANTE,'-') AS NRO_COMPROBANTE, ISNULL(CANAL,'-') AS CANAL, ISNULL (MINICODIGO,'-') AS MINICODIGO," +
                    "ISNULL(TIPO_PAGO,'-') AS TIPO_PAGO ,ISNULL(BANCO,'-') AS BANCO, ISNULL(NRO_OPERACION,'-') AS NRO_OPERACION, ISNULL(TRY_CONVERT(VARCHAR,CANTIDAD),'-') AS CANTIDAD," +
                    "ISNULL(MONEDA,'-') AS MONEDA,ISNULL(TRY_CONVERT(VARCHAR,PRECIO_UNIT_S_IGV),'-') AS PRECIO_UNIT_S_IGV,ISNULL(ORIGEN,'-') AS ORIGEN, ISNULL(DIR_DESTINO,'-') AS DIR_DESTINO," +
                    "ISNULL(OBSERVACIONES,'-') AS OBSERVACIONES, ISNULL(NOM_CLI,'-') AS NOM_CLI, ISNULL(DNI_CLI,'-') AS DNI_CLI, ISNULL(TEL_CLI,'-') AS TEL_CLI," +
                    "ISNULL(NOM_DELIV,'-') AS NOM_DELIV," +
                    "ISNULL(KM,'-') AS KM,ISNULL(TARIFA_ST,'-') AS TARIFA_ST, ISNULL(TARIFA_DELIV,'-') AS TARIFA_DELIV, ISNULL(TARIFA_OLVA,'-') AS TARIFA_OLVA," +
                    "ISNULL(PAGO_ONLINE,'-') AS PAGO_ONLINE, ISNULL(TRANSFERENCIA,'-') AS TRANSFERENCIA, ISNULL(EFECTIVO,'-') AS EFECTIVO, " +
                    "ISNULL(TRY_CONVERT(VARCHAR,NRO_PEDIDO),'-') AS NRO_PEDIDO,ID_SALIDA FROM ST_SALIDAS_CONS order by  ID_SALIDA DESC";
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                

                    salida = new e_Salida();
                    salida.TIPO = (string)reader["TIPO"];
                    salida.NRO_ORDEN = (string)reader["NRO_ORDEN"];
                    salida.FECHA_SALIDA = (string)reader["FECHA_SALIDA"];
                    salida.RESPONSABLE = (string)reader["RESPONSABLE"];
                    salida.TIPO_COMPROBANTE = (string)reader["TIPO_COMPROBANTE"];
                    salida.SERIE_COMPROBANTE = (string)reader["SERIE_COMPROBANTE"];
                    salida.NRO_COMPROBANTE = (string)reader["NRO_COMPROBANTE"];
                    salida.MINICODIGO = (string)reader["MINICODIGO"];
                    salida.TIPO_PAGO = (string)reader["TIPO_PAGO"];
                    salida.BANCO = (string)reader["BANCO"];
                    salida.NRO_OPERACION = (string)reader["NRO_OPERACION"];
                    salida.CANTIDAD = (string)reader["CANTIDAD"];
                    salida.MONEDA = (string)reader["MONEDA"];
                    salida.PRECIO_UNIT_S_IGV = (string)reader["PRECIO_UNIT_S_IGV"];
                    salida.ORIGEN = (string)reader["ORIGEN"];
                    salida.DIR_DESTINO = (string)reader["DIR_DESTINO"];
                    salida.OBSERVACIONES = (string)reader["OBSERVACIONES"];
                    salida.NOM_CLI = (string)reader["NOM_CLI"];
                    salida.DNI_CLI = (string)reader["DNI_CLI"];
                    salida.TEL_CLI = (string)reader["TEL_CLI"];
                    salida.NOM_DELIV = (string)reader["NOM_DELIV"];
                    salida.KM = (string)reader["KM"];
                    salida.TARIFA_ST = (string)reader["TARIFA_ST"];
                    salida.TARIFA_DELIV = (string)reader["TARIFA_DELIV"];
                    salida.TARIFA_OLVA = (string)reader["TARIFA_OLVA"];
                    salida.PAGO_ONLINE = (string)reader["PAGO_ONLINE"];
                    salida.TRANSFERENCIA = (string)reader["TRANSFERENCIA"];
                    salida.EFECTIVO = (string)reader["EFECTIVO"];
                    salida.NRO_PEDIDO = (string)reader["NRO_PEDIDO"];
                    salida.ID_SALIDA = (int)reader["ID_SALIDA"];

                    salidas.Add(salida);
                }
                reader.Close();
                return salidas;

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

        public List<e_Salida> Lista_salidas_x_filtro(e_Salida obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Salida> salidas = new List<e_Salida>();
                e_Salida salida = null;
                string consult = string.Format(" SELECT ISNULL(TIPO,'-') AS TIPO ,ISNULL(NRO_ORDEN,'-') AS NRO_ORDEN ,ISNULL(TRY_CONVERT(VARCHAR,FECHA_SALIDA,5),'-') AS FECHA_SALIDA,ISNULL(RESPONSABLE,'-') as RESPONSABLE, ISNULL(TIPO_COMPROBANTE,'-') AS TIPO_COMPROBANTE, ISNULL(SERIE_COMPROBANTE,'-') AS SERIE_COMPROBANTE,ISNULL(NRO_COMPROBANTE,'-') AS NRO_COMPROBANTE, ISNULL(CANAL,'-') AS CANAL, ISNULL (MINICODIGO,'-') AS MINICODIGO,ISNULL(TIPO_PAGO,'-') AS TIPO_PAGO ,ISNULL(BANCO,'-') AS BANCO, ISNULL(NRO_OPERACION,'-') AS NRO_OPERACION, ISNULL(TRY_CONVERT(VARCHAR,CANTIDAD),'-') AS CANTIDAD,ISNULL(MONEDA,'-') AS MONEDA,ISNULL(TRY_CONVERT(VARCHAR,PRECIO_UNIT_S_IGV),'-') AS PRECIO_UNIT_S_IGV,ISNULL(ORIGEN,'-') AS ORIGEN, ISNULL(DIR_DESTINO,'-') AS DIR_DESTINO,ISNULL(OBSERVACIONES,'-') AS OBSERVACIONES, ISNULL(NOM_CLI,'-') AS NOM_CLI, ISNULL(DNI_CLI,'-') AS DNI_CLI, ISNULL(TEL_CLI,'-') AS TEL_CLI,ISNULL(NOM_DELIV,'-') AS NOM_DELIV,ISNULL(KM,'-') AS KM,ISNULL(TARIFA_ST,'-') AS TARIFA_ST, ISNULL(TARIFA_DELIV,'-') AS TARIFA_DELIV, ISNULL(TARIFA_OLVA,'-') AS TARIFA_OLVA,ISNULL(PAGO_ONLINE,'-') AS PAGO_ONLINE, ISNULL(TRANSFERENCIA,'-') AS TRANSFERENCIA, ISNULL(EFECTIVO,'-') AS EFECTIVO,ISNULL(TRY_CONVERT(VARCHAR,NRO_PEDIDO),'-') AS NRO_PEDIDO,ID_SALIDA FROM ST_SALIDAS_CONS" +
                    " WHERE TIPO LIKE '%{0}%'AND NRO_ORDEN LIKE '%{1}%' AND CANAL like '%{2}%' AND MINICODIGO LIKE '%{3}%' AND concat(substring(convert(varchar,FECHA_SALIDA,3),0,7),'20',substring(convert(varchar,FECHA_SALIDA,3),7,2)) LIKE '%{4}%' AND NRO_PEDIDO LIKE '%{5}%'order by  ID_SALIDA DESC", obj.TIPO,obj.NRO_ORDEN,obj.CANAL,obj.MINICODIGO,obj.FECHA_SALIDA,obj.NRO_PEDIDO);
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {


                    salida = new e_Salida();
                    salida.TIPO = (string)reader["TIPO"];
                    salida.NRO_ORDEN = (string)reader["NRO_ORDEN"];
                    salida.FECHA_SALIDA = (string)reader["FECHA_SALIDA"];
                    salida.RESPONSABLE = (string)reader["RESPONSABLE"];
                    salida.TIPO_COMPROBANTE = (string)reader["TIPO_COMPROBANTE"];
                    salida.SERIE_COMPROBANTE = (string)reader["SERIE_COMPROBANTE"];
                    salida.NRO_COMPROBANTE = (string)reader["NRO_COMPROBANTE"];
                    salida.MINICODIGO = (string)reader["MINICODIGO"];
                    salida.TIPO_PAGO = (string)reader["TIPO_PAGO"];
                    salida.BANCO = (string)reader["BANCO"];
                    salida.NRO_OPERACION = (string)reader["NRO_OPERACION"];
                    salida.CANTIDAD = (string)reader["CANTIDAD"];
                    salida.MONEDA = (string)reader["MONEDA"];
                    salida.PRECIO_UNIT_S_IGV = (string)reader["PRECIO_UNIT_S_IGV"];
                    salida.ORIGEN = (string)reader["ORIGEN"];
                    salida.DIR_DESTINO = (string)reader["DIR_DESTINO"];
                    salida.OBSERVACIONES = (string)reader["OBSERVACIONES"];
                    salida.NOM_CLI = (string)reader["NOM_CLI"];
                    salida.DNI_CLI = (string)reader["DNI_CLI"];
                    salida.TEL_CLI = (string)reader["TEL_CLI"];
                    salida.NOM_DELIV = (string)reader["NOM_DELIV"];
                    salida.KM = (string)reader["KM"];
                    salida.TARIFA_ST = (string)reader["TARIFA_ST"];
                    salida.TARIFA_DELIV = (string)reader["TARIFA_DELIV"];
                    salida.TARIFA_OLVA = (string)reader["TARIFA_OLVA"];
                    salida.PAGO_ONLINE = (string)reader["PAGO_ONLINE"];
                    salida.TRANSFERENCIA = (string)reader["TRANSFERENCIA"];
                    salida.EFECTIVO = (string)reader["EFECTIVO"];
                    salida.NRO_PEDIDO = (string)reader["NRO_PEDIDO"];
                    salida.ID_SALIDA = (int)reader["ID_SALIDA"];

                    salidas.Add(salida);
                }
                reader.Close();
                return salidas;

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

        public string Ingresar_salida(e_Salida obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string insert = string.Format("INSERT INTO ST_SALIDAS_INPUT (TIPO,NRO_ORDEN,FECHA_SALIDA,RESPONSABLE,TIPO_COMPROBANTE," +
                    "SERIE_COMPROBANTE,NRO_COMPROBANTE,CANAL,MINICODIGO,TIPO_PAGO,BANCO,NRO_OPERACION,CANTIDAD,MONEDA,PRECIO_UNIT_S_IGV," +
                    "ORIGEN,DIR_DESTINO,OBSERVACIONES,NOM_CLI,DNI_CLI,TEL_CLI,NOM_DELIV,KM,TARIFA_ST,TARIFA_DELIV,TARIFA_OLVA,PAGO_ONLINE," +
                    "TRANSFERENCIA,EFECTIVO,NRO_PEDIDO) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'," +
                    "'{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}')",
                    obj.TIPO,obj.NRO_ORDEN,obj.FECHA_SALIDA,obj.RESPONSABLE,obj.TIPO_COMPROBANTE,obj.SERIE_COMPROBANTE,obj.NRO_COMPROBANTE,obj.CANAL,
                    obj.MINICODIGO,obj.TIPO_PAGO,obj.BANCO,obj.NRO_OPERACION,obj.CANTIDAD,obj.MONEDA,obj.PRECIO_UNIT_S_IGV,obj.ORIGEN,obj.DIR_DESTINO,
                    obj.OBSERVACIONES,obj.NOM_CLI,obj.DNI_CLI,obj.TEL_CLI,obj.NOM_DELIV,obj.KM,obj.TARIFA_ST,obj.TARIFA_DELIV,obj.TARIFA_OLVA,
                    obj.PAGO_ONLINE,obj.TRANSFERENCIA,obj.EFECTIVO,obj.NRO_PEDIDO);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Salida registrada correctamente";

            }
            catch (Exception ex)
            {
                return "ERROR de Query: "+ex.Message+ " en: "+ex.Source;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        public string Ingresar_cons()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                //string close = "SET IDENTITY_INSERT ST_SALIDAS_CONS OFF";
                string fecha = "UPDATE ST_SALIDAS_INPUT SET FECHA_SALIDA = CONCAT('0',FECHA_SALIDA) WHERE LEN(FECHA_SALIDA)= 9";
                string insert = "INSERT INTO ST_SALIDAS_CONS (TIPO,NRO_ORDEN,FECHA_SALIDA,RESPONSABLE,TIPO_COMPROBANTE,SERIE_COMPROBANTE," +
                    "NRO_COMPROBANTE,CANAL,MINICODIGO,TIPO_PAGO,BANCO,NRO_OPERACION,CANTIDAD,MONEDA,PRECIO_UNIT_S_IGV,ORIGEN,DIR_DESTINO,OBSERVACIONES," +
                    "NOM_CLI,DNI_CLI,TEL_CLI,NOM_DELIV,KM,TARIFA_ST,TARIFA_DELIV,TARIFA_OLVA,PAGO_ONLINE,TRANSFERENCIA,EFECTIVO,FECHA_PROCESO,NRO_PEDIDO,ID_SALIDA)" +
                    " SELECT TIPO,NRO_ORDEN,TRY_CONVERT(DATETIME,CONCAT(SUBSTRING(REPLACE(FECHA_SALIDA,'/',''),5,4),SUBSTRING(REPLACE(FECHA_SALIDA,'/','')" +
                    ",3,2),SUBSTRING(REPLACE(FECHA_SALIDA,'/',''),1,2))),RESPONSABLE,TIPO_COMPROBANTE,SERIE_COMPROBANTE,NRO_COMPROBANTE,CANAL,MINICODIGO," +
                    "TIPO_PAGO,BANCO,NRO_OPERACION,TRY_CONVERT(INT,CANTIDAD),MONEDA,TRY_CONVERT(DECIMAL(20,4),RTRIM(LTRIM(PRECIO_UNIT_S_IGV))),ORIGEN," +
                    "UPPER(DIR_DESTINO),OBSERVACIONES,UPPER(NOM_CLI),DNI_CLI,TEL_CLI,NOM_DELIV,KM,TARIFA_ST,TARIFA_DELIV,TARIFA_OLVA,PAGO_ONLINE,TRANSFERENCIA," +
                    "EFECTIVO,GETDATE(),NRO_PEDIDO,ID_SALIDA FROM ST_SALIDAS_INPUT WHERE ID_SALIDA NOT IN (SELECT ID_SALIDA FROM ST_SALIDAS_CONS)";
                //string open = "SET IDENTITY_INSERT ST_SALIDAS_CONS ON";
                //SqlCommand cmd_0 = new SqlCommand(close, con);
                SqlCommand cmd_1 = new SqlCommand(fecha, con);
                SqlCommand cmd_2 = new SqlCommand(insert, con);
                //SqlCommand cmd_3 = new SqlCommand(open, con);
                //cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                //cmd_3.ExecuteNonQuery();

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

        public List<e_Salida> Get_last_orden()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Salida> lista = new List<e_Salida>();
                e_Salida salida;
                string get = "SELECT CONCAT('OC_000',MAX(TRY_CONVERT(INT,REPLACE(NRO_ORDEN ,'OC_00',''))+1)) AS NRO_OC FROM ST_SALIDAS_CONS WHERE TIPO = 'VENTA C/NRO DE PEDIDO'";
                SqlCommand cmd_0 = new SqlCommand(get, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    salida = new e_Salida();
                    salida.NRO_ORDEN = (string)reader["NRO_OC"];
                    lista.Add(salida);
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
        public string Get_Last_ID()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string ID="0";
                string get = "SELECT TOP 1 ID_SALIDA FROM ST_SALIDAS_CONS order by ID_SALIDA DESC";
                SqlCommand cmd_0 = new SqlCommand(get, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    ID = "S"+Convert.ToString((int)reader["ID_SALIDA"]);
                }
                reader.Close();
                return ID;

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
        public string Modificar_salida(e_Salida obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string modif = string.Format("UPDATE ST_SALIDAS_CONS SET TIPO = '{0}',NRO_ORDEN = '{1}',RESPONSABLE = '{2}',TIPO_COMPROBANTE = '{3}',SERIE_COMPROBANTE = '{4}',NRO_COMPROBANTE = '{5}',CANAL = '{6}',MINICODIGO = '{7}',TIPO_PAGO = '{8}',BANCO = '{9}',NRO_OPERACION = '{10}',CANTIDAD = TRY_CONVERT(INT,'{11}'),MONEDA = '{12}',PRECIO_UNIT_S_IGV = '{13}',ORIGEN = '{14}',DIR_DESTINO = '{15}',OBSERVACIONES = '{16}',NOM_CLI = '{17}',DNI_CLI = '{18}',TEL_CLI = '{19}',NOM_DELIV = '{20}',KM = '{21}',TARIFA_ST = '{22}',TARIFA_DELIV = '{23}',TARIFA_OLVA = '{24}',PAGO_ONLINE = '{25}',TRANSFERENCIA = '{26}',EFECTIVO = '{27}',NRO_PEDIDO = TRY_CONVERT(INT,'{28}') WHERE ID_SALIDA = {29}",
                obj.TIPO,obj.NRO_ORDEN,obj.RESPONSABLE,obj.TIPO_COMPROBANTE,obj.SERIE_COMPROBANTE,obj.NRO_COMPROBANTE,obj.CANAL,obj.MINICODIGO,obj.TIPO_PAGO,obj.BANCO,obj.NRO_OPERACION,obj.CANTIDAD,obj.MONEDA,obj.PRECIO_UNIT_S_IGV,obj.ORIGEN,obj.DIR_DESTINO,obj.OBSERVACIONES,obj.NOM_CLI,obj.DNI_CLI,obj.TEL_CLI,obj.NOM_DELIV,obj.KM,obj.TARIFA_ST,obj.TARIFA_DELIV,obj.TARIFA_OLVA,obj.PAGO_ONLINE,obj.TRANSFERENCIA,obj.EFECTIVO,obj.NRO_PEDIDO,obj.ID_SALIDA);
                SqlCommand cmd_0 = new SqlCommand(modif, con);
                cmd_0.ExecuteNonQuery();
                return "Salida modificada correctamente";
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
        public string Actualizar_kardex(e_Kardex obj)
        {
            try
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
                    obj.STOCK_FINAL, obj.COSTO_UNI_PON_DOL, obj.COSTO_UNI_PON_SOL, obj.MONTO_DOL_TOTAL_FINAL, obj.MONTO_SOL_TOTAL_FINAL, obj.PRECIO_VENTA_SOLES,obj.PRECIO_VENTA_DOLARES);
                SqlCommand cmd_0 = new SqlCommand(registra, con);
                cmd_0.ExecuteNonQuery();
                return "Kardex Actualizado";
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
        public e_Kardex Buscar_Kardex(string filtro)
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

    }
}
