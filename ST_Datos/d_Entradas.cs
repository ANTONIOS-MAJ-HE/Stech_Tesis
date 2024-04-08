using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_Entradas
    {
        private d_SQLcon db_st = new d_SQLcon();

        public List <e_Entradas>Lista_Entradas()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Entradas> entradas = new List<e_Entradas>();
                e_Entradas entrada = null;
                string consulta = "SELECT ISNULL(A.TIPO,'-') AS TIPO, ISNULL(CONVERT(VARCHAR,FECHA_ENTRADA,5),'-') AS FECHA_ENTRADA, ISNULL(SERIE_FACTURA,'-') AS SERIE_FACTURA, ISNULL(NRO_FACTURA,'-') AS NRO_FACTURA, ISNULL(MINICODIGO,'-') AS MINICODIGO, ISNULL(CANTIDAD,0) AS CANTIDAD, ISNULL(A.MONEDA,'-') AS MONEDA, ISNULL(PRECIO_UNIT_S_IGV,0.00) AS PRECIO_UNIT_S_IGV , ISNULL(RUC_PROVEEDOR,'-') AS RUC_PROVEEDOR, ISNULL(NOM_PROVEEDOR,'-') AS NOM_PROVEEDOR, ISNULL(ORIGEN,'-') AS ORIGEN, ISNULL(DESTINO,'-') AS DESTINO,ISNULL(RESPONSABLE,'-') AS RESPONSABLE, ISNULL(OBSERVACIONES,'-') AS OBSERVACIONES, ISNULL(CONVERT(VARCHAR,FECHA_PROCESO,5),'-') AS FECHA_PROCESO,ISNULL(CONVERT(VARCHAR,FECHA_FACTURA,5),'-') AS FECHA_FACTURA, ISNULL(CONVERT(VARCHAR,FECHA_GUIA,5),'-') AS FECHA_GUIA, ID_ENTRADA, ISNULL(B.TITULO,'-') AS PRODUCTO, ISNULL(B.MARCA,'-') AS MARCA  FROM ST_ENTRADAS_CONS A LEFT JOIN ST_STOCK B ON A.MINICODIGO = B.MINI_CODIGO ORDER BY ID_ENTRADA DESC";       
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    entrada = new e_Entradas();
                    entrada.Fecha_Entrada = (string)reader["FECHA_ENTRADA"];
                    entrada.Serie_Fact = (string)reader["SERIE_FACTURA"];
                    entrada.Nro_Fact = (string)reader["NRO_FACTURA"];
                    entrada.Tipo = (string)reader["TIPO"];
                    entrada.Responsable = (string)reader["RESPONSABLE"];
                    entrada.MiniCodigo = (string)reader["MINICODIGO"];
                    entrada.Moneda = (string)reader["MONEDA"];
                    entrada.Cantidad = (int)reader["CANTIDAD"];
                    entrada.Precio_Unitario = (decimal)reader["PRECIO_UNIT_S_IGV"];
                    entrada.RUC_Proveedor = (string)reader["RUC_PROVEEDOR"];
                    entrada.Proveedor = (string)reader["NOM_PROVEEDOR"];
                    entrada.Origen = (string)reader["ORIGEN"];
                    entrada.Observaciones = (string)reader["OBSERVACIONES"];
                    entrada.Fecha_factura = (string)reader["FECHA_FACTURA"];
                    entrada.Fecha_guia = (string)reader["FECHA_GUIA"];
                    entrada.Id_Entrada = (int)reader["ID_ENTRADA"];
                    entrada.Producto = (string)reader["PRODUCTO"];
                    entrada.Marca = (string)reader["MARCA"];
              
                    entradas.Add(entrada);
                }
                reader.Close();
                return entradas;
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

        public List<e_Entradas> Lista_Entradas_filtro(e_Entradas obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Entradas> entradas = new List<e_Entradas>();
                e_Entradas entrada = null;
                string consulta = string.Format( "SELECT ISNULL(A.TIPO,'-') AS TIPO, ISNULL(CONVERT(VARCHAR,FECHA_ENTRADA,5),'-') AS FECHA_ENTRADA, ISNULL(SERIE_FACTURA,'-') AS SERIE_FACTURA, ISNULL(NRO_FACTURA,'-') AS NRO_FACTURA, ISNULL(MINICODIGO,'-') AS MINICODIGO, ISNULL(CANTIDAD,0) AS CANTIDAD, ISNULL(A.MONEDA,'-') AS MONEDA, ISNULL(PRECIO_UNIT_S_IGV,0.00) AS PRECIO_UNIT_S_IGV , ISNULL(RUC_PROVEEDOR,'-') AS RUC_PROVEEDOR, ISNULL(NOM_PROVEEDOR,'-') AS NOM_PROVEEDOR, ISNULL(ORIGEN,'-') AS ORIGEN, ISNULL(DESTINO,'-') AS DESTINO,ISNULL(RESPONSABLE,'-') AS RESPONSABLE, ISNULL(OBSERVACIONES,'-') AS OBSERVACIONES, ISNULL(CONVERT(VARCHAR,FECHA_PROCESO,5),'-') AS FECHA_PROCESO,ISNULL(CONVERT(VARCHAR,FECHA_FACTURA,5),'-') AS FECHA_FACTURA, ISNULL(CONVERT(VARCHAR,FECHA_GUIA,5),'-') AS FECHA_GUIA, ID_ENTRADA, ISNULL(B.TITULO,'-') AS PRODUCTO, ISNULL(B.MARCA,'-') AS MARCA  FROM ST_ENTRADAS_CONS A LEFT JOIN ST_STOCK B ON A.MINICODIGO = B.MINI_CODIGO where NRO_FACTURA like '%{0}%' AND RUC_PROVEEDOR LIKE '%{1}%' AND NOM_PROVEEDOR LIKE '%{2}%' AND B.TITULO LIKE '%{3}%' AND MARCA LIKE '%{4}%' ORDER BY ID_ENTRADA DESC",obj.Nro_Fact,obj.RUC_Proveedor,obj.Proveedor,obj.Producto,obj.Marca);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    entrada = new e_Entradas();
                    entrada.Fecha_Entrada = (string)reader["FECHA_ENTRADA"];
                    entrada.Serie_Fact = (string)reader["SERIE_FACTURA"];
                    entrada.Nro_Fact = (string)reader["NRO_FACTURA"];
                    entrada.Tipo = (string)reader["TIPO"];
                    entrada.Responsable = (string)reader["RESPONSABLE"];
                    entrada.MiniCodigo = (string)reader["MINICODIGO"];
                    entrada.Moneda = (string)reader["MONEDA"];
                    entrada.Cantidad = (int)reader["CANTIDAD"];
                    entrada.Precio_Unitario = (decimal)reader["PRECIO_UNIT_S_IGV"];
                    entrada.RUC_Proveedor = (string)reader["RUC_PROVEEDOR"];
                    entrada.Proveedor = (string)reader["NOM_PROVEEDOR"];
                    entrada.Origen = (string)reader["ORIGEN"];
                    entrada.Observaciones = (string)reader["OBSERVACIONES"];
                    entrada.Fecha_factura = (string)reader["FECHA_FACTURA"];
                    entrada.Fecha_guia = (string)reader["FECHA_GUIA"];
                    entrada.Id_Entrada = (int)reader["ID_ENTRADA"];
                    entrada.Producto = (string)reader["PRODUCTO"];
                    entrada.Marca = (string)reader["MARCA"];

                    entradas.Add(entrada);
                }
                reader.Close();
                return entradas;
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

        public string Registrar_Entradas(e_Entradas obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string registra = string.Format("INSERT INTO ST_ENTRADAS_INPUT (TIPO,FECHA_ENTRADA,SERIE_FACTURA,NRO_FACTURA,MINICODIGO," +
                    "CANTIDAD,MONEDA,PRECIO_UNIT_S_IGV,RUC_PROVEEDOR,NOM_PROVEEDOR,ORIGEN,RESPONSABLE,OBSERVACIONES,FECHA_PROCESO,FECHA_FACTURA," +
                    "FECHA_GUIA) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',GETDATE(),'{13}','{14}')",
                    obj.Tipo,obj.Fecha_Entrada,obj.Serie_Fact,obj.Nro_Fact,obj.MiniCodigo,obj.Cantidad,obj.Moneda,obj.Precio_Unitario,obj.RUC_Proveedor,
                    obj.Proveedor,obj.Origen,obj.Responsable,obj.Observaciones,obj.Fecha_factura,obj.Fecha_guia);
                SqlCommand cmd_0 = new SqlCommand(registra, con);
                cmd_0.ExecuteNonQuery();
                return "Entrada registrada correctamente";
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
                    obj.TIPO, obj.FECHA_FACTURA, obj.TC_FECHA_FACT, obj.PARTNUMBER, obj.NUMERO_ORDEN_FACT, obj.DETALLE,obj.STOCK_INICIAL,obj.MONEDA,obj.COSTO_UNI_DOL_STOCK_INI,
                    obj.COSTO_UNI_SOL_SOTCK_INI, obj.MONTO_TOTAL_DOL_INI, obj.MONTO_TOTAL_SOL_INI, obj.STOCK_ENTRADA, obj.COSTO_UNI_ENT_DOL, obj.COSTO_UNI_ENT_SOL,
                    obj.MONTO_ENT_DOL, obj.MONTO_ENT_SOL, obj.STOCK_SALIDA, obj.COSTO_UNI_SAL_DOL,obj.COSTO_UNI_SAL_SOL,obj.MONTO_SAL_DOL,obj.MONTO_SAL_SOL,
                    obj.STOCK_FINAL,obj.COSTO_UNI_PON_DOL,obj.COSTO_UNI_PON_SOL,obj.MONTO_DOL_TOTAL_FINAL,obj.MONTO_SOL_TOTAL_FINAL,obj.PRECIO_VENTA_SOLES,obj.PRECIO_VENTA_DOLARES);
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
                "ISNULL(COSTO_UNI_PON_SOL,COSTO_UNI_SOL_SOTCK_INI) as COSTO_UNI_PON_SOL,MONTO_DOL_TOTAL_FINAL,MONTO_SOL_TOTAL_FINAL  from ST_KARDEX WHERE PARTNUMBER = '" + filtro + "' " +
                "order by ID_KARDEX DESC";
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
        public int ultimaEntrada()
        {
            SqlConnection con = db_st.Conecta_DB();
            string Busca = "SELECT TOP 1 ID_ENTRADA from ST_ENTRADAS_CONS order by FECHA_PROCESO desc";
            SqlCommand cmd_0 = new SqlCommand(Busca, con);
            SqlDataReader reader = cmd_0.ExecuteReader();
            return (int)reader["ID_ENTRADA"];
        }

        public string Ingresar_Cons()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string fechas = "UPDATE ST_ENTRADAS_INPUT SET FECHA_ENTRADA = CONCAT('0',FECHA_ENTRADA) WHERE LEN(FECHA_ENTRADA)= 9" +
                    "UPDATE ST_ENTRADAS_INPUT SET FECHA_FACTURA = CONCAT('0',FECHA_FACTURA) WHERE LEN(FECHA_FACTURA)= 9" +
                    "UPDATE ST_ENTRADAS_INPUT SET FECHA_GUIA = CONCAT('0',FECHA_GUIA) WHERE LEN(FECHA_GUIA)= 9";
                //string close = "SET IDENTITY_INSERT ST_ENTRADAS_CONS OFF";
                string ingresar = "INSERT INTO ST_ENTRADAS_CONS (TIPO,FECHA_ENTRADA,SERIE_FACTURA,NRO_FACTURA,MINICODIGO," +
                    "CANTIDAD,MONEDA,PRECIO_UNIT_S_IGV,RUC_PROVEEDOR,NOM_PROVEEDOR,ORIGEN,DESTINO,RESPONSABLE,OBSERVACIONES," +
                    "FECHA_PROCESO,FECHA_FACTURA,FECHA_GUIA,ID_ENTRADA) SELECT RTRIM(LTRIM(TIPO)),TRY_CONVERT(DATETIME,CONCAT(SUBSTRING" +
                    "(REPLACE(RTRIM(LTRIM(FECHA_ENTRADA)),'/',''),5,4),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_ENTRADA)),'/',''),3,2)" +
                    ",SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_ENTRADA)),'/',''),1,2))),RTRIM(LTRIM(SERIE_FACTURA)),RTRIM(LTRIM" +
                    "(NRO_FACTURA)),RTRIM(LTRIM(MINICODIGO)),CONVERT(INT,RTRIM(LTRIM(CANTIDAD))),RTRIM(LTRIM(MONEDA)),TRY_CONVERT" +
                    "(decimal (20,4),RTRIM(LTRIM(PRECIO_UNIT_S_IGV))),RTRIM(LTRIM(RUC_PROVEEDOR)),RTRIM(LTRIM(NOM_PROVEEDOR))," +
                    "RTRIM(LTRIM(ORIGEN)),RTRIM(LTRIM(DESTINO)),RTRIM(LTRIM(RESPONSABLE)),RTRIM(LTRIM(OBSERVACIONES)),GETDATE()," +
                    "TRY_CONVERT(DATETIME,CONCAT(SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_FACTURA)),'/',''),5,4),SUBSTRING(REPLACE" +
                    "(RTRIM(LTRIM(FECHA_FACTURA)),'/',''),3,2),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_FACTURA)),'/',''),1,2)))," +
                    "TRY_CONVERT(DATETIME,CONCAT(SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_GUIA)),'/',''),5,4), SUBSTRING(REPLACE" +
                    "(RTRIM(LTRIM(FECHA_GUIA)),'/',''),3,2), SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_GUIA)),'/',''),1,2))), ID_ENTRADA " +
                    "FROM ST_ENTRADAS_INPUT WHERE ID_ENTRADA NOT IN (SELECT ID_ENTRADA FROM ST_ENTRADAS_CONS)";
                //string open = "SET IDENTITY_INSERT ST_ENTRADAS_CONS ON";
                SqlCommand cmd_0 = new SqlCommand(fechas, con);
                //SqlCommand cmd_1 = new SqlCommand(close, con);
                SqlCommand cmd_2 = new SqlCommand(ingresar, con);
                //SqlCommand cmd_3 = new SqlCommand(open, con);
                cmd_0.ExecuteNonQuery();
                //cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                //cmd_3.ExecuteNonQuery();
                return "S";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public string Modificar_Cons(e_Entradas obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string modif = string.Format("UPDATE ST_ENTRADAS_CONS SET TIPO = '{0}',SERIE_FACTURA = '{1}',NRO_FACTURA = '{2}'," +
                    " MINICODIGO = '{3}', CANTIDAD = '{4}', MONEDA = '{5}', PRECIO_UNIT_S_IGV = '{6}', RUC_PROVEEDOR = '{7}'," +
                    " NOM_PROVEEDOR = '{8}', ORIGEN = '{9}', OBSERVACIONES = CONCAT('{10}',' - MODIFICADO EL: ',GETDATE())" +
                    " WHERE ID_ENTRADA = {11}",obj.Tipo,obj.Serie_Fact,obj.Nro_Fact,obj.MiniCodigo,obj.Cantidad,obj.Moneda,obj.Precio_Unitario,
                    obj.RUC_Proveedor, obj.Proveedor, obj.Origen,obj.Observaciones,obj.Id_Entrada);
                SqlCommand cmd_0 = new SqlCommand(modif, con);
                cmd_0.ExecuteNonQuery();
                return "Entrada modificada correctamente";
            }   
            catch (Exception ex)
            {
                return "Ocurrió un problema: "+ex.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        public List<e_Proveedor> Lista_proveedores(e_Proveedor obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Proveedor> listaprov = new List<e_Proveedor>();
                e_Proveedor prov = null;
                string consult = string.Format("SELECT DISTINCT (NOM_PROVEEDOR) AS NOM_PROVEEDOR,ISNULL(RUC_PROVEEDOR,'') AS RUC_PROVEEDOR  FROM ST_ENTRADAS_CONS WHERE NOM_PROVEEDOR NOT IN ('','NA','NULL') AND NOM_PROVEEDOR IS NOT NULL AND NOM_PROVEEDOR LIKE '%{0}%'", obj.Proveedor);
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    prov = new e_Proveedor();
                    prov.Proveedor = (string)reader["NOM_PROVEEDOR"];
                    prov.RUC_Prov = (string)reader["RUC_PROVEEDOR"];
                    listaprov.Add(prov);
                }
                reader.Close();
                return listaprov;
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

        public List<e_TotalFact>Lista_fact(e_TotalFact obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_TotalFact> listafact = new List<e_TotalFact>();
                e_TotalFact total = null;
                string consulta = string.Format("SELECT CONCAT(SERIE_FACTURA, '-',NRO_FACTURA) AS FACTURA , CONVERT(VARCHAR,SUM(PRECIO_UNIT_S_IGV)) AS TOTAL_S_IGV, CONVERT(VARCHAR,SUM(CANTIDAD)) AS CANTIDAD FROM ST_ENTRADAS_CONS WHERE CONCAT(SERIE_FACTURA,'-',NRO_FACTURA) = '{0}' GROUP BY SERIE_FACTURA,NRO_FACTURA ", obj.Factura);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    total = new e_TotalFact();
                    total.Cantidad = (string)reader["CANTIDAD"];
                    total.Factura = (string)reader["FACTURA"];
                    total.Total = (string)reader["TOTAL_S_IGV"];
                    listafact.Add(total);
                }
                reader.Close();
                return listafact;
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
        public string Modificar_costos()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string actualiza_dol = "UPDATE ST_STOCK SET COSTO_U_S_IGV_DOLARES = Z.PRECIO_USD FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,CASE WHEN B.MONEDA='USD' THEN B.PRECIO_UNIT_S_IGV ELSE B.PRECIO_UNIT_S_IGV/TC.VENTA END AS 'PRECIO_USD', CASE WHEN B.MONEDA='PEN' THEN B.PRECIO_UNIT_S_IGV ELSE B.PRECIO_UNIT_S_IGV/TC.VENTA END AS 'PRECIO_PEN',b.FECHA_ENTRADA FROM  (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA JOIN TC_SUNAT TC ON CONVERT(varchar,TC.FECHA,23) = CONVERT(varchar,B.FECHA_FACTURA,23) WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0))Z ON A.MINI_CODIGO = Z.MINICODIGO";
                string actualiza_sol = "UPDATE ST_STOCK SET COSTO_U_S_IGV_SOLES = A.COSTO_U_S_IGV_DOLARES*(select VENTA from TC_SUNAT where CONVERT(varchar,FECHA,23) = CONVERT(varchar,GETDATE(),23)) FROM ST_STOCK A WHERE A.COSTO_U_S_IGV_DOLARES NOT IN (0,999999.0000,NULL) ";
                SqlCommand cmd_0 = new SqlCommand(actualiza_dol, con);
                SqlCommand cmd_1 = new SqlCommand(actualiza_sol, con);
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

        public string Get_Last_ID()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string ID = "0";
                string get = "SELECT TOP 1 ID_ENTRADA FROM ST_ENTRADAS_CONS order by ID_ENTRADA DESC";
                SqlCommand cmd_0 = new SqlCommand(get, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    ID = "E" + Convert.ToString((int)reader["ID_ENTRADA"]);
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
    }
}
