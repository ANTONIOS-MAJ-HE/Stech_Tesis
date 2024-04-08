using ST_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ST_Datos
{
    public class d_Facturacion
    {
        d_SQLcon db_conect = new d_SQLcon();
        public string Guardar_Fact(e_FacturaEnviada obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = string.Format("IF NOT EXISTS(SELECT NRO_OC FROM ST_FACTURA WHERE NRO_OC = '{0}') INSERT INTO ST_FACTURA(NRO_OC,CODIGO_TIPO_OPERACION,TIPO_MONEDA,CLIENTE,CODIGO_TIPO_DOCUMENTO,NUMERO_DOCUMENTO,DIRECCION," +
                    "PRECIO_ENVIO,TOTAL_IMPUESTOS,TOTAL_VALOR,TOTAL_VENTA,FECHA_EMISION)" +
                    "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},{10},GETDATE())", obj.NRO_OC, obj.CODIGO_TIPO_OPERACION, obj.TIPO_MONEDA, obj.CLIENTE,
                    obj.CODIGO_TIPO_DOCUMENTO, obj.NUMERO_DOCUMENTO, obj.DIRECCION, obj.PRECIO_ENVIO, obj.TOTAL_IMPUESTOS, obj.TOTAL_VALOR, obj.TOTAL_VENTA);
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Factura completa";
            }
            catch (Exception ex)
            {
                return "Error en query: " + ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Guardar_Items_Fact(e_FacturaEnviada obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = string.Format("IF NOT EXISTS(SELECT NRO_OC,CODIGO_ITEM FROM ST_FACTURA_DETALLE WHERE NRO_OC = '{0}' AND CODIGO_ITEM= '{2}') INSERT INTO ST_FACTURA_DETALLE(NRO_OC,PRODUCTO,CODIGO_ITEM,CANTIDAD,PRECIO_UNITARIO,IGV_PRODUCTO)" +
                    "VALUES('{0}','{1}','{2}',{3},{4},{5})", obj.NRO_OC, obj.PRODUCTO, obj.CODIGO_INTERNO, obj.CANTIDAD, obj.PRECIO_UNITARIO, obj.IGV_PRODUCTO);
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Factura completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Guardar_serie(string serie, string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update ST_FACTURA SET SERIE = '" + serie + "',NUMERO_SERIE = '" + nro + "' Where NRO_OC = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Actualizar_NroFact_SAGA(string serie,string nro,string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_SF_CONS SET SERIE_FACT = '" + serie + "',NRO_FACT = '" + nro + "' Where NRO_OC = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Actualizar_NroFact_LINIO(string serie, string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_LNO_CONS SET SERIE_CMP = '" + serie + "',NRO_CMP = '" + nro + "' Where ORDER_NUMBER = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Actualizar_NroFact_Ripley(string serie, string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_RPL_CONS SET SERIE_CMP = '" + serie + "',NRO_CMP = '" + nro + "' Where NRO_PEDIDO = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Actualizar_NroFact_RealPlaza(string serie, string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_RPG_CONS SET SERIE_CMP = '" + serie + "',NRO_CMP = '" + nro + "' Where NUMERO = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Actualizar_NroFact_Kingston(string serie, string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_KNG_CONS SET SERIE_CMP = '" + serie + "',NRO_CMP = '" + nro + "' Where NRO_PEDIDO = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Actualizar_NroFact_MercadoLibre(string serie, string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_MLIBRE_CONS SET SERIE_CMP = '" + serie + "',NRO_CMP = '" + nro + "' Where N_VENTA = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Actualizar_NroFact_Juntoz(string serie, string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_JTZ_CONS SET SERIE_CMP = '" + serie + "',NRO_CMP = '" + nro + "' Where NRO_PEDIDO = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string Actualizar_NroFact_Coolbox(string serie, string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_CLB_CONS SET SERIE_FACT = '" + serie + "',NUMERO_FACT = '" + nro + "' Where OC_ORDER = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_RealPlaza()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "SELECT NUMERO,NOMBRE_SKU,NUMERO_DOCUMENTO,CLIENTE,CONCAT(DIRECCION,' ',DEPARTAMENTO,'-',PROVINCIA,'-',DISTRITO) AS DIRECCION," +
                    "EMAIL_CLIENTE,TELEFONO_CLIENTE,SKU,SUM(UNIDADES_REAL) AS UNIDADES, CONVERT(float,ISNULL(PRECIO_SKU/1.18,0.00)) AS PRECIO,CONVERT(float,COSTO_TOTAL_ENVIO/1.18) AS COSTO_TOTAL_ENVIO " +
                    " FROM OC_RPG_CONS " +
                    "WHERE ST_DESPACHO = 'PENDIENTE' AND CONVERT(varchar,FECHA_PROCESO,23) = CONVERT(varchar,GETDATE(),23) AND NUMERO not in (SELECT NRO_OC FROM ST_FACTURA) " +
                    "group by NUMERO,NUMERO_DOCUMENTO,CLIENTE,DIRECCION,DEPARTAMENTO,PROVINCIA,DISTRITO,EMAIL_CLIENTE,TELEFONO_CLIENTE,SKU,PRECIO_SKU,NOMBRE_SKU,COSTO_TOTAL_ENVIO";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NUMERO"];
                    Factura.Cliente_DNI = (string)reader["NUMERO_DOCUMENTO"];
                    Factura.Cliente_Nombre = (string)reader["CLIENTE"];
                    Factura.Direccion = (string)reader["DIRECCION"];
                    Factura.Email = (string)reader["EMAIL_CLIENTE"];
                    Factura.Telefono = (string)reader["TELEFONO_CLIENTE"];
                    Factura.Item = (string)reader["NOMBRE_SKU"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO"];
                    Factura.Costo_Envio = (double)reader["COSTO_TOTAL_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_MercadoLibre()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select N_VENTA,TITULO_PUBLICACION,ISNULL(DNI_FACT,0) AS DNI_FACT,ISNULL(NOMBRE_FACT,'-') AS NOMBRE_FACT,ISNULL(DOMICILIO,'-') AS DOMICILIO" +
                    ",'' AS EMAIL, ISNULL(TELEFONO_FACT,0) AS TELEFONO_FACT,SKU,UNIDADES,CONVERT(float,PRECIO_UNITARIO) AS PRECIO_UNITARIO," +
                    " CONVERT(float,ABS(COSTO_ENVIO)) AS COSTO_ENVIO " +
                    "from OC_MLIBRE_CONS WHERE NRO_CMP IS NULL AND CONVERT(varchar,FECHA_DESPACHO,23) >= CONVERT(varchar,GETDATE(),23) " +
                    "AND N_VENTA NOT IN (Select NRO_OC from ST_FACTURA)";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["N_VENTA"];
                    Factura.Cliente_DNI = (string)reader["DNI_FACT"];
                    Factura.Cliente_Nombre = (string)reader["NOMBRE_FACT"];
                    Factura.Direccion = (string)reader["DOMICILIO"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO_FACT"];
                    Factura.Item = (string)reader["TITULO_PUBLICACION"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO_UNITARIO"];
                    Factura.Costo_Envio = (double)reader["COSTO_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_MercadoLibre(string NRO)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select N_VENTA,TITULO_PUBLICACION,ISNULL(DNI_FACT,0) AS DNI_FACT,ISNULL(NOMBRE_FACT,'-') AS NOMBRE_FACT,ISNULL(DOMICILIO,'-') AS DOMICILIO" +
                    ",'' AS EMAIL," +
                    "ISNULL(TELEFONO_FACT,0) AS TELEFONO_FACT,SKU,UNIDADES,CONVERT(float,PRECIO_UNITARIO) AS PRECIO_UNITARIO,CONVERT(float,ABS(COSTO_ENVIO)) AS COSTO_ENVIO " +
                    "from OC_MLIBRE_CONS WHERE N_VENTA ='"+NRO+"'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["N_VENTA"];
                    Factura.Cliente_DNI = (string)reader["DNI_FACT"];
                    Factura.Cliente_Nombre = (string)reader["NOMBRE_FACT"];
                    Factura.Direccion = (string)reader["DOMICILIO"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO_FACT"];
                    Factura.Item = (string)reader["TITULO_PUBLICACION"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO_UNITARIO"];
                    Factura.Costo_Envio = (double)reader["COSTO_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Juntoz()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_PEDIDO,NOMBRE,ISNULL(DOCUMENTO_CLIENTE,0) AS DOCUMENTO_CLIENTE,ISNULL(NOMBRE_CLIENTE,'-') AS NOMBRE_CLIENTE," +
                    "CONCAT(DIRECCION_RECEPTOR,' ',REFERENCIA_RECEPTOR,' ',UBIGEO_RECEPTOR) AS DOMICILIO ,'' AS EMAIL, ISNULL(TELEFONO_CLIENTE,0) AS TELEFONO_CLIENTE," +
                    "SKU,CANTIDAD,CONVERT(float,PRECIO)/1.18 AS PRECIO_UNITARIO, CONVERT(float,ENVIO) AS COSTO_ENVIO from OC_JTZ_CONS" +
                    " WHERE CONVERT(varchar,FECHA_PROCESO,23) = CONVERT(varchar,GETDATE(),23) AND NRO_PEDIDO NOT IN (Select NRO_OC from ST_FACTURA) AND ESTADO='LISTO PARA ENVIAR'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_PEDIDO"];
                    Factura.Cliente_DNI = (string)reader["DOCUMENTO_CLIENTE"];
                    Factura.Cliente_Nombre = (string)reader["NOMBRE_CLIENTE"];
                    Factura.Direccion = (string)reader["DOMICILIO"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO_CLIENTE"];
                    Factura.Item = (string)reader["NOMBRE"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["CANTIDAD"];
                    Factura.Precio = (double)reader["PRECIO_UNITARIO"];
                    Factura.Costo_Envio = (double)reader["COSTO_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Juntoz(string NROOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_PEDIDO,NOMBRE,ISNULL(DOCUMENTO_CLIENTE,0) AS DOCUMENTO_CLIENTE,ISNULL(NOMBRE_CLIENTE,'-') AS NOMBRE_CLIENTE," +
                    "CONCAT(DIRECCION_RECEPTOR,' ',REFERENCIA_RECEPTOR,' ',UBIGEO_RECEPTOR) AS DOMICILIO ,'' AS EMAIL, ISNULL(TELEFONO_CLIENTE,0) AS TELEFONO_CLIENTE," +
                    "SKU,CANTIDAD,CONVERT(float,PRECIO)/1.18 AS PRECIO_UNITARIO, CONVERT(float,ENVIO) AS COSTO_ENVIO from OC_JTZ_CONS" +
                    " WHERE NRO_PEDIDO ='"+NROOC+"'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_PEDIDO"];
                    Factura.Cliente_DNI = (string)reader["DOCUMENTO_CLIENTE"];
                    Factura.Cliente_Nombre = (string)reader["NOMBRE_CLIENTE"];
                    Factura.Direccion = (string)reader["DOMICILIO"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO_CLIENTE"];
                    Factura.Item = (string)reader["NOMBRE"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["CANTIDAD"];
                    Factura.Precio = (double)reader["PRECIO_UNITARIO"];
                    Factura.Costo_Envio = (double)reader["COSTO_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Catphone()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select N_VENTA,TITULO_PUBLICACION,ISNULL(DNI_FACT,0) AS DNI_FACT,ISNULL(NOMBRE_FACT,'-') AS NOMBRE_FACT," +
                    "ISNULL(DIRECCION_FACT,'-') AS DOMICILIO ,'' AS EMAIL, ISNULL(TELEFONO_FACT,0) AS TELEFONO_FACT,SKU,UNIDADES,CONVERT(float,INGRESOS_PROD/1.18) AS PRECIO_UNITARIO, " +
                    "CONVERT(float,ABS(COSTO_ENVIO)) AS COSTO_ENVIO from OC_CATPHONE_CONS WHERE CONVERT(varchar,FECHA_PROCESO,23) = CONVERT(varchar,GETDATE(),23) " +
                    "AND N_VENTA NOT IN (Select NRO_OC from ST_FACTURA)";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_PEDIDO"];
                    Factura.Cliente_DNI = (string)reader["DOCUMENTO_CLIENTE"];
                    Factura.Cliente_Nombre = (string)reader["NOMBRE_CLIENTE"];
                    Factura.Direccion = (string)reader["DOMICILIO"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO_CLIENTE"];
                    Factura.Item = (string)reader["NOMBRE"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["CANTIDAD"];
                    Factura.Precio = (double)reader["PRECIO_UNITARIO"];
                    Factura.Costo_Envio = (double)reader["COSTO_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Catphone(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select N_VENTA,TITULO_PUBLICACION,ISNULL(DNI_FACT,0) AS DNI_FACT,ISNULL(NOMBRE_FACT,'-') AS NOMBRE_FACT," +
                    "ISNULL(DIRECCION_FACT,'-') AS DOMICILIO ,'' AS EMAIL, ISNULL(TELEFONO_FACT,0) AS TELEFONO_FACT,SKU,UNIDADES,CONVERT(float,INGRESOS_PROD/1.18) AS PRECIO_UNITARIO, " +
                    "CONVERT(float,ABS(COSTO_ENVIO)) AS COSTO_ENVIO from OC_CATPHONE_CONS WHERE N_VENTA ='"+NRO_OC+"'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_PEDIDO"];
                    Factura.Cliente_DNI = (string)reader["DOCUMENTO_CLIENTE"];
                    Factura.Cliente_Nombre = (string)reader["NOMBRE_CLIENTE"];
                    Factura.Direccion = (string)reader["DOMICILIO"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO_CLIENTE"];
                    Factura.Item = (string)reader["NOMBRE"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["CANTIDAD"];
                    Factura.Precio = (double)reader["PRECIO_UNITARIO"];
                    Factura.Costo_Envio = (double)reader["COSTO_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Oficina()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_PEDIDO,PRODUCTO,NRO_DOC,CLIENTE,DIRECCION,'' AS EMAIL, '' AS TELEFONO,MINI_CODIGO,CANTIDAD,CONVERT(float,PRECIO_UNIT_S_IGV) AS PRECIO_UNIT_S_IGV,ISNULL(COSTO_ENVIO,0.0) AS COSTO_ENVIO FROM " +
                    "ST_PEDIDO_DETALLE WHERE NRO_PEDIDO NOT IN (SELECT NRO_PEDIDO FROM ST_SALIDAS_CONS) AND CANTIDAD>0 AND CONVERT(varchar,FECHA_PROCESO,23)>'2023-01-15'" +
                    " AND NRO_PEDIDO !='399'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_PEDIDO"];
                    Factura.Cliente_DNI = (string)reader["NRO_DOC"];
                    Factura.Cliente_Nombre = (string)reader["CLIENTE"];
                    Factura.Direccion = (string)reader["DIRECCION"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO"];
                    Factura.Codigo_Item = (string)reader["MINI_CODIGO"];
                    Factura.Cantidad = (int)reader["CANTIDAD"];
                    Factura.Precio = (double)reader["PRECIO_UNIT_S_IGV"];
                    Factura.Costo_Envio = (double)reader["COSTO_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Oficina(string NRO)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_PEDIDO,NRO_DOC,CLIENTE,DIRECCION,'' AS EMAIL, '' AS TELEFONO,PRODUCTO,MINI_CODIGO,CANTIDAD,PRECIO_UNIT_S_IGV,ISNULL(COSTO_ENVIO,0.0) AS COSTO_ENVIO FROM " +
                    "ST_PEDIDO_DETALLE WHERE NRO_PEDIDO ='"+NRO+"'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_OC"];
                    Factura.Cliente_DNI = (string)reader["NRO_DOC"];
                    Factura.Cliente_Nombre = (string)reader["CLIENTE"];
                    Factura.Direccion = (string)reader["DIRECCION"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO"];
                    Factura.Item = (string)reader["PRODUCTO"];
                    Factura.Codigo_Item = (string)reader["MINI_CODIGO"];
                    Factura.Cantidad = (int)reader["CANTIDAD"];
                    Factura.Precio = (double)reader["PRECIO_UNIT_S_IGV"];
                    Factura.Costo_Envio = (double)reader["COSTO_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Kingston()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_PEDIDO, SUBSTRING(DETALLES,0,LEN(DETALLES)-70) AS DETALLES,ISNULL(DNI,'0') AS DNI, CONCAT([DIRECCION_FACTURACION: APELLIDO],', '," +
                    "[DIRECCION_FACTURACION: NOMBRE_DE_PILA]) AS NOM_CLI, CONCAT([DIRECCION_FACTURACION: CALLE_1],', ',[DIRECCION_ENTREGA: CALLE_2],' - '," +
                    "[DIRECCION_ENTREGA: CIUDAD]) AS DIRECCION_CLI, ISNULL(EMAIL,'-') as EMAIL, ISNULL([DIRECCION_FACTURACION:TELEFONO],'-') as " +
                    "TELEFONO, ISNULL(SKU_OFERTA,'-') as SKU_OFERTA, SUM(CANTIDAD) AS UNIDADES,ISNULL(SUM(PRECIO_UNIDAD)/1.18,0) as PRECIO,IMPORTE_TOTAL_ENVIO/1.18 AS  IMPORTE_TOTAL_ENVIO " +
                    "FROM OC_KNG_CONS WHERE ST_DESPACHO = 'PENDIENTE' AND NRO_PEDIDO NOT IN (SELECT NRO_OC FROM ST_FACTURA) AND ESTADO='ENVÍO EN CURSO' AND FECHA_PROCESO > '2023-03-04 00:00:000' group by NRO_PEDIDO,DNI,[DIRECCION_FACTURACION: APELLIDO],[DIRECCION_FACTURACION: NOMBRE_DE_PILA]," +
                    "[DIRECCION_FACTURACION: CALLE_1],[DIRECCION_ENTREGA: CALLE_2],[DIRECCION_ENTREGA: CIUDAD],EMAIL ,[DIRECCION_FACTURACION:TELEFONO]," +
                    "SKU_OFERTA,IMPORTE_TOTAL_ENVIO,DETALLES";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_PEDIDO"];
                    Factura.Cliente_DNI = (string)reader["DNI"];
                    Factura.Cliente_Nombre = (string)reader["NOM_CLI"];
                    Factura.Direccion = (string)reader["DIRECCION_CLI"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO"];
                    Factura.Item = (string)reader["DETALLES"];
                    Factura.Codigo_Item = (string)reader["SKU_OFERTA"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO"];
                    Factura.Costo_Envio = (double)reader["IMPORTE_TOTAL_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Kingston(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_PEDIDO, SUBSTRING(DETALLES,0,LEN(DETALLES)-70) AS DETALLES,ISNULL(DNI,'0') AS DNI, CONCAT([DIRECCION_FACTURACION: APELLIDO],', '," +
                    "[DIRECCION_FACTURACION: NOMBRE_DE_PILA]) AS NOM_CLI, CONCAT([DIRECCION_FACTURACION: CALLE_1],', ',[DIRECCION_ENTREGA: CALLE_2],' - '," +
                    "[DIRECCION_ENTREGA: CIUDAD]) AS DIRECCION_CLI, ISNULL(EMAIL,'-') as EMAIL, ISNULL([DIRECCION_FACTURACION:TELEFONO],'-') as " +
                    "TELEFONO, ISNULL(SKU_OFERTA,'-') as SKU_OFERTA, SUM(UNIDADES_REAL) AS UNIDADES,ISNULL(SUM(PRECIO_UNIDAD)/1.18,0) as PRECIO,IMPORTE_TOTAL_ENVIO/1.18 AS  IMPORTE_TOTAL_ENVIO " +
                    "FROM OC_KNG_CONS WHERE NRO_PEDIDO='" + NRO_OC + "' group by NRO_PEDIDO,DNI,[DIRECCION_FACTURACION: APELLIDO],[DIRECCION_FACTURACION: NOMBRE_DE_PILA]," +
                    "[DIRECCION_FACTURACION: CALLE_1],[DIRECCION_ENTREGA: CALLE_2],[DIRECCION_ENTREGA: CIUDAD],EMAIL ,[DIRECCION_FACTURACION:TELEFONO]," +
                    "SKU_OFERTA,IMPORTE_TOTAL_ENVIO,DETALLES";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_PEDIDO"];
                    Factura.Cliente_DNI = (string)reader["DNI"];
                    Factura.Cliente_Nombre = (string)reader["NOM_CLI"];
                    Factura.Direccion = (string)reader["DIRECCION_CLI"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO"];
                    Factura.Item = (string)reader["DETALLES"];
                    Factura.Codigo_Item = (string)reader["SKU_OFERTA"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO"];
                    Factura.Costo_Envio = (double)reader["IMPORTE_TOTAL_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_RealPlaza(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "SELECT NUMERO,NOMBRE_SKU,NUMERO_DOCUMENTO,CLIENTE,CONCAT(DIRECCION,' ',DEPARTAMENTO,'-',PROVINCIA,'-',DISTRITO) AS DIRECCION," +
                    "EMAIL_CLIENTE,TELEFONO_CLIENTE,SKU,SUM(UNIDADES_REAL) AS UNIDADES, CONVERT(float,ISNULL(PRECIO_SKU/1.18,0.00)) AS PRECIO,CONVERT(float,COSTO_TOTAL_ENVIO/1.18) AS COSTO_TOTAL_ENVIO" +
                    " FROM OC_RPG_CONS " +
                    "WHERE NUMERO = '" +NRO_OC+
                    "' group by NUMERO,NUMERO_DOCUMENTO,CLIENTE,DIRECCION,DEPARTAMENTO,PROVINCIA,DISTRITO,EMAIL_CLIENTE,TELEFONO_CLIENTE,SKU,PRECIO_SKU,NOMBRE_SKU,COSTO_TOTAL_ENVIO";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NUMERO"];
                    Factura.Cliente_DNI = (string)reader["NUMERO_DOCUMENTO"];
                    Factura.Cliente_Nombre = (string)reader["CLIENTE"];
                    Factura.Direccion = (string)reader["DIRECCION"];
                    Factura.Email = (string)reader["EMAIL_CLIENTE"];
                    Factura.Telefono = (string)reader["TELEFONO_CLIENTE"];
                    Factura.Item = (string)reader["NOMBRE_SKU"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO"];
                    Factura.Costo_Envio = (double)reader["COSTO_TOTAL_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Ripley()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_PEDIDO, SUBSTRING(DETALLES,0,LEN(DETALLES)-70) AS DETALLES,ISNULL(DNI,'0') AS DNI, CONCAT([DIRECCION_FACTURACION: APELLIDO],', '," +
                    "[DIRECCION_FACTURACION: NOMBRE_DE_PILA]) AS NOM_CLI, CONCAT([DIRECCION_FACTURACION: CALLE_1],', ',[DIRECCION_ENTREGA: CALLE_2],' - '," +
                    "[DIRECCION_ENTREGA: CIUDAD]) AS DIRECCION_CLI, ISNULL(EMAIL,'-') as EMAIL, ISNULL([DIRECCION_FACTURACION:TELEFONO],'-') as " +
                    "TELEFONO, ISNULL(SKU_OFERTA,'-') as SKU_OFERTA, SUM(UNIDADES_REAL) AS UNIDADES,ISNULL(SUM(PRECIO_UNIDAD)/1.18,0) as PRECIO,IMPORTE_TOTAL_ENVIO/1.18 AS  IMPORTE_TOTAL_ENVIO " +
                    "FROM OC_RPL_CONS WHERE ST_DESPACHO = 'PENDIENTE' AND NRO_PEDIDO NOT IN (SELECT NRO_OC FROM ST_FACTURA) AND ESTADO in  ('ENVÍO EN CURSO', 'Esperando envío' ) AND FECHA_PROCESO > '2023-03-04 00:00:000' group by NRO_PEDIDO,DNI,[DIRECCION_FACTURACION: APELLIDO],[DIRECCION_FACTURACION: NOMBRE_DE_PILA]," +
                    "[DIRECCION_FACTURACION: CALLE_1],[DIRECCION_ENTREGA: CALLE_2],[DIRECCION_ENTREGA: CIUDAD],EMAIL ,[DIRECCION_FACTURACION:TELEFONO]," +
                    "SKU_OFERTA,IMPORTE_TOTAL_ENVIO,DETALLES ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_PEDIDO"];
                    Factura.Cliente_DNI = (string)reader["DNI"];
                    Factura.Cliente_Nombre = (string)reader["NOM_CLI"];
                    Factura.Direccion = (string)reader["DIRECCION_CLI"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO"];
                    Factura.Item = (string)reader["DETALLES"];
                    Factura.Codigo_Item = (string)reader["SKU_OFERTA"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO"];
                    Factura.Costo_Envio = (double)reader["IMPORTE_TOTAL_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Ripley(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_PEDIDO, SUBSTRING(DETALLES,0,LEN(DETALLES)-70) AS DETALLES,ISNULL(DNI,'0') AS DNI, CONCAT([DIRECCION_FACTURACION: APELLIDO],', '," +
                    "[DIRECCION_FACTURACION: NOMBRE_DE_PILA]) AS NOM_CLI, CONCAT([DIRECCION_FACTURACION: CALLE_1],', ',[DIRECCION_ENTREGA: CALLE_2],' - '," +
                    "[DIRECCION_ENTREGA: CIUDAD]) AS DIRECCION_CLI, ISNULL(EMAIL,'-') as EMAIL, ISNULL([DIRECCION_FACTURACION:TELEFONO],'-') as " +
                    "TELEFONO, ISNULL(SKU_OFERTA,'-') as SKU_OFERTA, SUM(UNIDADES_REAL) AS UNIDADES,ISNULL(SUM(PRECIO_UNIDAD)/1.18,0) as PRECIO,IMPORTE_TOTAL_ENVIO/1.18 AS  IMPORTE_TOTAL_ENVIO " +
                    "FROM OC_RPL_CONS WHERE NRO_PEDIDO='"+NRO_OC+"' group by NRO_PEDIDO,DNI,[DIRECCION_FACTURACION: APELLIDO],[DIRECCION_FACTURACION: NOMBRE_DE_PILA]," +
                    "[DIRECCION_FACTURACION: CALLE_1],[DIRECCION_ENTREGA: CALLE_2],[DIRECCION_ENTREGA: CIUDAD],EMAIL ,[DIRECCION_FACTURACION:TELEFONO]," +
                    "SKU_OFERTA,IMPORTE_TOTAL_ENVIO,DETALLES";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_PEDIDO"];
                    Factura.Cliente_DNI = (string)reader["DNI"];
                    Factura.Cliente_Nombre = (string)reader["NOM_CLI"];
                    Factura.Direccion = (string)reader["DIRECCION_CLI"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO"];
                    Factura.Item = (string)reader["DETALLES"];
                    Factura.Codigo_Item = (string)reader["SKU_OFERTA"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO"];
                    Factura.Costo_Envio = (double)reader["IMPORTE_TOTAL_ENVIO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Saga()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_OC, DESCRIPCION,ISNULL(DNI_COMPRADOR,'0') AS DNI_COMPRADOR, ISNULL(NOM_COMPRADOR,'-') as NOM_COMPRADOR, " +
                    "ISNULL(DIRECCION_RECEPTOR,'-') AS DIRECCION_RECEPTOR, ISNULL(EMAIL,'-') as EMAIL, ISNULL(TELEFONO_COMPRADOR,'-') as TELEFONO_COMPRADOR, " +
                    "ISNULL(SKU,'-') as SKU, UNIDADES, ISNULL(PRECIO_COSTO,0.0) AS PRECIO_COSTO FROM OC_SF_CONS WHERE SERIE_FACT IS NULL " +
                    "AND ST_ORDEN NOT IN ('ANULADO','ANULADO BD','DEVUELTO') AND YEAR(FECHA_ENTREGA)*10000+MONTH(FECHA_ENTREGA)*100+DAY(FECHA_ENTREGA)< YEAR(GETDATE())*10000+MONTH(GETDATE())*100+DAY(GETDATE())";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC= (string)reader["NRO_OC"];
                    Factura.Cliente_DNI = (string)reader["DNI_COMPRADOR"];
                    Factura.Cliente_Nombre = (string)reader["NOM_COMPRADOR"];
                    Factura.Direccion = (string)reader["DIRECCION_RECEPTOR"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO_COMPRADOR"];
                    Factura.Item = (string)reader["DESCRIPCION"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO_COSTO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Saga(string NRO)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_OC, DESCRIPCION,ISNULL(DNI_COMPRADOR,'0') AS DNI_COMPRADOR, ISNULL(NOM_COMPRADOR,'-') as NOM_COMPRADOR, " +
                    "ISNULL(DIRECCION_RECEPTOR,'-') AS DIRECCION_RECEPTOR, ISNULL(EMAIL,'-') as EMAIL, ISNULL(TELEFONO_COMPRADOR,'-') as TELEFONO_COMPRADOR, " +
                    "ISNULL(SKU,'-') as SKU, UNIDADES, ISNULL(PRECIO_COSTO,0.0) AS PRECIO_COSTO FROM OC_SF_CONS WHERE NRO_OC='"+NRO +
                    "' AND ST_ORDEN NOT IN ('ANULADO','ANULADO BD','DEVUELTO') ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_OC"];
                    Factura.Cliente_DNI = (string)reader["DNI_COMPRADOR"];
                    Factura.Cliente_Nombre = (string)reader["NOM_COMPRADOR"];
                    Factura.Direccion = (string)reader["DIRECCION_RECEPTOR"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO_COMPRADOR"];
                    Factura.Item = (string)reader["DESCRIPCION"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO_COSTO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Saga_Filtro(string FECHA)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select NRO_OC, DESCRIPCION,ISNULL(DNI_COMPRADOR,'0') AS DNI_COMPRADOR, ISNULL(NOM_COMPRADOR,'-') as NOM_COMPRADOR, " +
                    "ISNULL(DIRECCION_RECEPTOR,'-') AS DIRECCION_RECEPTOR, ISNULL(EMAIL,'-') as EMAIL, ISNULL(TELEFONO_COMPRADOR,'-') as TELEFONO_COMPRADOR, " +
                    "ISNULL(SKU,'-') as SKU, UNIDADES, ISNULL(PRECIO_COSTO,0.0) AS PRECIO_COSTO FROM OC_SF_CONS WHERE CONVERT(varchar,FECHA_ENTREGA,23)='" + FECHA +"'"+
                    " AND ST_ORDEN NOT IN ('ANULADO','ANULADO BD','DEVUELTO') AND SERIE_FACT IS NULL";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["NRO_OC"];
                    Factura.Cliente_DNI = (string)reader["DNI_COMPRADOR"];
                    Factura.Cliente_Nombre = (string)reader["NOM_COMPRADOR"];
                    Factura.Direccion = (string)reader["DIRECCION_RECEPTOR"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["TELEFONO_COMPRADOR"];
                    Factura.Item = (string)reader["DESCRIPCION"];
                    Factura.Codigo_Item = (string)reader["SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO_COSTO"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_COOLBOX()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select OC_ORDER,CLIENT_DOCUMENT,CONCAT(CLIENT_NAME,' ',CLIENT_LAST_NAME) AS CLIENT_NAME,CONCAT(STREET,'-',NEIGHBORHOOD,'-',CITY) " +
                    "AS DIRECCION,EMAIL,PHONE,SKU_NAME,ID_SKU,UNIDADES_REAL,SKU_TOTAL_PRICE,SHIPPING_VALUE " +
                    "from OC_CLB_CONS " +
                    "WHERE CONVERT(varchar,FECHA_PROCESO,23)=CONVERT(varchar,GETDATE(),23) AND ST_ORDER NOT IN ('ANULADO','ANULADO BD','DEVUELTO') " +
                    "AND OC_ORDER NOT IN (SELECT NRO_OC FROM ST_FACTURA) AND UNIDADES_REAL IS NOT NULL";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["OC_ORDER"];
                    Factura.Cliente_DNI = (string)reader["CLIENT_DOCUMENT"];
                    Factura.Cliente_Nombre = (string)reader["CLIENT_NAME"];
                    Factura.Direccion = (string)reader["DIRECCION"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["PHONE"];
                    Factura.Item = (string)reader["SKU_NAME"];
                    Factura.Codigo_Item = (string)reader["ID_SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES_REAL"];
                    Factura.Precio = (double)reader["SKU_TOTAL_PRICE"];
                    Factura.Costo_Envio = (double)reader["SHIPPING_VALUE"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_COOLBOX(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select OC_ORDER,CLIENT_DOCUMENT,CONCAT(CLIENT_NAME,' ',CLIENT_LAST_NAME) AS CLIENT_NAME,CONCAT(STREET,'-',NEIGHBORHOOD,'-',CITY) " +
                    "AS DIRECCION,EMAIL,PHONE,SKU_NAME,ID_SKU,UNIDADES_REAL,SKU_TOTAL_PRICE,SHIPPING_VALUE " +
                    "from OC_CLB_CONS " +
                    "WHERE OC_ORDER='"+NRO_OC+"'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["OC_ORDER"];
                    Factura.Cliente_DNI = (string)reader["CLIENT_DOCUMENT"];
                    Factura.Cliente_Nombre = (string)reader["CLIENT_NAME"];
                    Factura.Direccion = (string)reader["DIRECCION"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = (string)reader["PHONE"];
                    Factura.Item = (string)reader["SKU_NAME"];
                    Factura.Codigo_Item = (string)reader["ID_SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES_REAL"];
                    Factura.Precio = (double)reader["SKU_TOTAL_PRICE"];
                    Factura.Costo_Envio = (double)reader["SHIPPING_VALUE"];
                    lista_facturas.Add(Factura);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_Saga_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_facturas = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select NRO_OC, DNI_COMPRADOR, NOM_COMPRADOR, DIRECCION_RECEPTOR, EMAIL, TELEFONO_COMPRADOR, SKU, UNIDADES, PRECIO_COSTO, " +
                    "DESCUENTO,DESCRIPCION FROM OC_SF_CONS where NRO_OC='" + NRO_OC+"'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["SKU"];
                    item.descripcion = (string)reader["DESCRIPCION"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["PRECIO_COSTO"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO_COSTO"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO_COSTO"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv= (double)reader["PRECIO_COSTO"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO_COSTO"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO_COSTO"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["PRECIO_COSTO"] * (int)reader["UNIDADES"]) +((double)reader["PRECIO_COSTO"] * (int)reader["UNIDADES"] * 0.18);
                    lista_facturas.Add(item);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_Oficina_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_facturas = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select NRO_PEDIDO,PRODUCTO,MINI_CODIGO,SUM(CANTIDAD) AS CANTIDAD,PRECIO_UNIT_S_IGV from " +
                    "ST_PEDIDO_DETALLE Where NRO_PEDIDO= '" + NRO_OC + "' group by MINI_CODIGO,PRODUCTO,PRECIO_UNIT_S_IGV,NRO_PEDIDO " +
                    "Union select NRO_PEDIDO,'COSTO DE ENVIO','AACSTO09ENVLNOPE-31122020',1,COSTO_ENVIO AS COSTO_ENVIO " +
                    "FRom ST_PEDIDO_DETALLE Where NRO_PEDIDO = '" + NRO_OC + "' And COSTO_ENVIO>0 group by NRO_PEDIDO,COSTO_ENVIO " +
                    "order by MINI_CODIGO DESC";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["MINI_CODIGO"];
                    item.descripcion = (string)reader["PRODUCTO"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["CANTIDAD"];
                    item.valor_unitario = (double)reader["PRECIO_UNIT_S_IGV"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO_UNIT_S_IGV"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO_UNIT_S_IGV"] * (int)reader["CANTIDAD"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["PRECIO_UNIT_S_IGV"] * (int)reader["CANTIDAD"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO_UNIT_S_IGV"] * (int)reader["CANTIDAD"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO_UNIT_S_IGV"] * (int)reader["CANTIDAD"];
                    item.total_item = ((double)reader["PRECIO_UNIT_S_IGV"] * (int)reader["CANTIDAD"]) + ((double)reader["PRECIO_UNIT_S_IGV"] * (int)reader["CANTIDAD"] * 0.18);
                    lista_facturas.Add(item);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Linio()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_items = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select ORDER_NUMBER,ITEM_NAME,NATIONAL_REGISTRATION_NUMBER,ITEM_NAME,LINIO_SKU,SUM(UNIDADES_REAL) AS UNIDADES,CUSTOMER_NAME," +
                    "UNIT_PRICE/1.18 as UNIT_PRICE,CUSTOMER_EMAIL,CONCAT(BILLING_ADDRESS,' ',BILLING_ADDRESS_2,' ',BILLING_ADDRESS_3,'-', BILLING_CITY) AS DIRECCION_CLI " +
                    ",SHIPPING_FEE/1.18 AS SHIPPING_FEE from OC_LNO_CONS " +
                    "WHERE CONVERT(varchar,FECHA_PROCESO,23) = CONVERT(varchar,GETDATE(),23) AND ORDER_NUMBER not in (SELECT NRO_OC FROM ST_FACTURA)  group by LINIO_SKU,ITEM_NAME,UNIT_PRICE,NATIONAL_REGISTRATION_NUMBER,CUSTOMER_EMAIL,ORDER_NUMBER,CUSTOMER_NAME," +
                    "BILLING_ADDRESS,BILLING_ADDRESS_2,BILLING_ADDRESS_3,BILLING_CITY,ITEM_NAME,SHIPPING_FEE";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["ORDER_NUMBER"];
                    Factura.Cliente_DNI = (string)reader["NATIONAL_REGISTRATION_NUMBER"];
                    Factura.Cliente_Nombre = (string)reader["CUSTOMER_NAME"];
                    Factura.Direccion = (string)reader["DIRECCION_CLI"];
                    Factura.Email = (string)reader["CUSTOMER_EMAIL"];
                    Factura.Telefono = "";
                    Factura.Item = (string)reader["ITEM_NAME"];
                    Factura.Codigo_Item = (string)reader["LINIO_SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["UNIT_PRICE"];
                    Factura.Costo_Envio = (double)reader["SHIPPING_FEE"];
                    lista_items.Add(Factura);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Artos()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_items = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select FB.ORDER_NUMBER,'20611125888 ' AS DOCUMENTO,ST.TITULO,ST.PARTNUMBER,SUM(FB.UNIDADES_REAL) AS " +
                    "UNIDADES ,'ARTOS ELECTRONIC E.I.R.L.' AS NOMBRE, CASE (E.MONEDA) WHEN 'PEN' THEN E.PRECIO_UNIT_S_IGV ELSE " +
                    "E.PRECIO_UNIT_S_IGV *TC.COMPRA END AS PRECIO,'' AS EMAIL, " +
                    "'AV. HONORIO DELGADO NRO. 224 URB. INGENIERIA LIMA - LIMA - SAN MARTIN DE PORRES' AS DIRECCION " +
                    "from ST_STOCK ST JOIN OC_FBL_CONS FB ON FB.FALABELLA_SKU = ST.SKU_FALABELLA " +
                    "LEFT JOIN ST_ENTRADAS_CONS E ON E.MINICODIGO = ST.MINI_CODIGO AND " +
                    "E.FECHA_PROCESO = (select MAX(FECHA_PROCESO) FROM ST_ENTRADAS_CONS WHERE MINICODIGO=ST.MINI_CODIGO AND " +
                    "PRECIO_UNIT_S_IGV IS NOT NULL AND PRECIO_UNIT_S_IGV >0) JOIN TC_SUNAT TC ON " +
                    "CONVERT(varchar,FB.FECHA_PROCESO,23) = CONVERT(varchar,TC.FECHA,23) " +
                    "WHERE CONVERT(varchar,FB.FECHA_PROCESO,23) = CONVERT(varchar,GETDATE(),23) " +
                    "AND CASE (E.MONEDA) WHEN 'PEN' THEN E.PRECIO_UNIT_S_IGV ELSE E.PRECIO_UNIT_S_IGV *TC.COMPRA END >1.0" +
                    "GROUP BY ST.TITULO,ST.PARTNUMBER,e.PRECIO_UNIT_S_IGV,FB.ORDER_NUMBER,E.MONEDA,TC.COMPRA";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["ORDER_NUMBER"];
                    Factura.Cliente_DNI = (string)reader["DOCUMENTO"];
                    Factura.Cliente_Nombre = (string)reader["NOMBRE"];
                    Factura.Direccion = (string)reader["DIRECCION"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = "";
                    Factura.Item = (string)reader["TITULO"];
                    Factura.Codigo_Item = (string)reader["PARTNUMBER"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO"];
                    Factura.Costo_Envio = 0.0;
                    lista_items.Add(Factura);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Artos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_items = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select FB.ORDER_NUMBER,'20611125888 ' AS DOCUMENTO,ST.TITULO,ST.PARTNUMBER,SUM(FB.UNIDADES_REAL) AS " +
                    "UNIDADES ,'ARTOS ELECTRONIC E.I.R.L.' AS NOMBRE, CASE (E.MONEDA) WHEN 'PEN' THEN E.PRECIO_UNIT_S_IGV ELSE " +
                    "E.PRECIO_UNIT_S_IGV *TC.COMPRA END AS PRECIO,'' AS EMAIL, " +
                    "'AV. HONORIO DELGADO NRO. 224 URB. INGENIERIA LIMA - LIMA - SAN MARTIN DE PORRES' AS DIRECCION, 0.0 AS COSTO_ENVIO " +
                    "from ST_STOCK ST JOIN OC_FBL_CONS FB ON FB.FALABELLA_SKU = ST.SKU_FALABELLA " +
                    "LEFT JOIN ST_ENTRADAS_CONS E ON E.MINICODIGO = ST.MINI_CODIGO AND " +
                    "E.FECHA_PROCESO = (select MAX(FECHA_PROCESO) FROM ST_ENTRADAS_CONS WHERE MINICODIGO=ST.MINI_CODIGO AND " +
                    "PRECIO_UNIT_S_IGV IS NOT NULL AND PRECIO_UNIT_S_IGV >0) JOIN TC_SUNAT TC ON " +
                    "CONVERT(varchar,FB.FECHA_PROCESO,23) = CONVERT(varchar,TC.FECHA,23) " +
                    "WHERE ORDER_NUMBER ='"+NRO_OC+"'" +
                    "GROUP BY ST.TITULO,ST.PARTNUMBER,e.PRECIO_UNIT_S_IGV,FB.ORDER_NUMBER,E.MONEDA,TC.COMPRA";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["ORDER_NUMBER"];
                    Factura.Cliente_DNI = (string)reader["DOCUMENTO"];
                    Factura.Cliente_Nombre = (string)reader["NOMBRE"];
                    Factura.Direccion = (string)reader["DIRECCION"];
                    Factura.Email = (string)reader["EMAIL"];
                    Factura.Telefono = "";
                    Factura.Item = (string)reader["TITULO"];
                    Factura.Codigo_Item = (string)reader["PARTNUMBER"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["PRECIO"];
                    Factura.Costo_Envio = (double)reader["COSTO_ENVIO"];
                    lista_items.Add(Factura);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Linio(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_items = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select ORDER_NUMBER,ITEM_NAME,NATIONAL_REGISTRATION_NUMBER,ITEM_NAME,LINIO_SKU,SUM(UNIDADES_REAL) AS UNIDADES,CUSTOMER_NAME," +
                    "UNIT_PRICE/1.18 as UNIT_PRICE,CUSTOMER_EMAIL,CONCAT(BILLING_ADDRESS,' ',BILLING_ADDRESS_2,' ',BILLING_ADDRESS_3,'-', BILLING_CITY) AS DIRECCION_CLI " +
                    ",SUM(SHIPPING_FEE)/1.18 AS SHIPPING_FEE from OC_LNO_CONS " +
                    "WHERE ORDER_NUMBER='"+NRO_OC+"' group by LINIO_SKU,ITEM_NAME,UNIT_PRICE,NATIONAL_REGISTRATION_NUMBER,CUSTOMER_EMAIL,ORDER_NUMBER,CUSTOMER_NAME," +
                    "BILLING_ADDRESS,BILLING_ADDRESS_2,BILLING_ADDRESS_3,BILLING_CITY,ITEM_NAME,SHIPPING_FEE";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["ORDER_NUMBER"];
                    Factura.Cliente_DNI = (string)reader["NATIONAL_REGISTRATION_NUMBER"];
                    Factura.Cliente_Nombre = (string)reader["CUSTOMER_NAME"];
                    Factura.Direccion = (string)reader["DIRECCION_CLI"];
                    Factura.Email = (string)reader["CUSTOMER_EMAIL"];
                    Factura.Telefono = "";
                    Factura.Item = (string)reader["ITEM_NAME"];
                    Factura.Codigo_Item = (string)reader["LINIO_SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["UNIT_PRICE"];
                    Factura.Costo_Envio = (double)reader["SHIPPING_FEE"];
                    lista_items.Add(Factura);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Falabella()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_items = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select ORDER_NUMBER,ITEM_NAME,NATIONAL_REGISTRATION_NUMBER,ITEM_NAME,FALABELLA_SKU,SUM(UNIDADES_REAL) AS UNIDADES,CUSTOMER_NAME," +
                    "UNIT_PRICE/1.18 as UNIT_PRICE,CONCAT(BILLING_ADDRESS,' ',BILLING_ADDRESS_2,' ',BILLING_ADDRESS_3,'-', BILLING_CITY) AS DIRECCION_CLI " +
                    ",SHIPPING_FEE/1.18 AS SHIPPING_FEE from OC_FBL_CONS " +
                    "WHERE CONVERT(varchar,FECHA_PROCESO,23) = CONVERT(varchar,GETDATE(),23) " +
                    "group by FALABELLA_SKU,ITEM_NAME,UNIT_PRICE,NATIONAL_REGISTRATION_NUMBER,ORDER_NUMBER,CUSTOMER_NAME," +
                    "BILLING_ADDRESS,BILLING_ADDRESS_2,BILLING_ADDRESS_3,BILLING_CITY,ITEM_NAME,SHIPPING_FEE";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["ORDER_NUMBER"];
                    Factura.Cliente_DNI = (string)reader["NATIONAL_REGISTRATION_NUMBER"];
                    Factura.Cliente_Nombre = (string)reader["CUSTOMER_NAME"];
                    Factura.Direccion = (string)reader["DIRECCION_CLI"];
                    Factura.Email = "";
                    Factura.Telefono = "";
                    Factura.Item = (string)reader["ITEM_NAME"];
                    Factura.Codigo_Item = (string)reader["FALABELLA_SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["UNIT_PRICE"];
                    Factura.Costo_Envio = (double)reader["SHIPPING_FEE"];
                    lista_items.Add(Factura);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_FacturasPendientes> Lista_Items_Falabella(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_FacturasPendientes> lista_items = new List<e_FacturasPendientes>();
                e_FacturasPendientes Factura = null;
                string consulta = "select ORDER_NUMBER,ITEM_NAME,NATIONAL_REGISTRATION_NUMBER,ITEM_NAME,FALABELLA_SKU,SUM(UNIDADES_REAL) AS UNIDADES,CUSTOMER_NAME," +
                    "UNIT_PRICE/1.18 as UNIT_PRICE,CONCAT(BILLING_ADDRESS,' ',BILLING_ADDRESS_2,' ',BILLING_ADDRESS_3,'-', BILLING_CITY) AS DIRECCION_CLI " +
                    ",SUM(SHIPPING_FEE)/1.18 AS SHIPPING_FEE from OC_FBL_CONS " +
                    "WHERE ORDER_NUMBER='" + NRO_OC + "' group by FALABELLA_SKU,ITEM_NAME,NATIONAL_REGISTRATION_NUMBER,ORDER_NUMBER,CUSTOMER_NAME," +
                    "BILLING_ADDRESS,BILLING_ADDRESS_2,BILLING_ADDRESS_3,BILLING_CITY,ITEM_NAME,SHIPPING_FEE,UNIT_PRICE";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    Factura = new e_FacturasPendientes();
                    Factura.NRO_OC = (string)reader["ORDER_NUMBER"];
                    Factura.Cliente_DNI = (string)reader["NATIONAL_REGISTRATION_NUMBER"];
                    Factura.Cliente_Nombre = (string)reader["CUSTOMER_NAME"];
                    Factura.Direccion = (string)reader["DIRECCION_CLI"];
                    Factura.Email = "";
                    Factura.Telefono = "";
                    Factura.Item = (string)reader["ITEM_NAME"];
                    Factura.Codigo_Item = (string)reader["FALABELLA_SKU"];
                    Factura.Cantidad = (int)reader["UNIDADES"];
                    Factura.Precio = (double)reader["UNIT_PRICE"];
                    Factura.Costo_Envio = (double)reader["SHIPPING_FEE"];
                    lista_items.Add(Factura);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_RealPlaza_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select NUMERO,NOMBRE_SKU,SKU,SUM(UNIDADES_REAL) AS UNIDADES,CONVERT(float,PRECIO_SKU/1.18)+((TOTAL_DESCUENTOS/CANTIDAD_SKU)/(SELECT COUNT(NUMERO) FROM OC_RPG_CONS WHERE NUMERO='" + NRO_OC + "')) as PRECIO_SKU from OC_RPG_CONS " +
                    "Where NUMERO= '"+NRO_OC+ "' group by SKU,NOMBRE_SKU,PRECIO_SKU,NUMERO,TOTAL_DESCUENTOS,CANTIDAD_SKU " +
                    "Union select NUMERO,'COSTO DE ENVIO','AACSTO09ENVLNOPE-31122020',1,COSTO_TOTAL_ENVIO/1.18 AS COSTO_ENVIO FRom OC_RPG_CONS " +
                    "Where NUMERO = '"+NRO_OC+ "' And COSTO_TOTAL_ENVIO>0 group by NUMERO,COSTO_TOTAL_ENVIO order by SKU ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["SKU"];
                    item.descripcion = (string)reader["NOMBRE_SKU"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["PRECIO_SKU"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO_SKU"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"]) + ((double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_MercadoLibre_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select N_VENTA,TITULO_PUBLICACION,SKU,SUM(UNIDADES_REAL) AS UNIDADES,CONVERT(float,PRECIO_UNIT_S_IGV) as PRECIO " +
                    "from OC_MLIBRE_CONS OC JOIN ST_SALIDAS_CONS ST ON ST.NRO_ORDEN = OC.N_VENTA  Where N_VENTA= '" + NRO_OC+ "' group by SKU,TITULO_PUBLICACION,PRECIO_UNIT_S_IGV,N_VENTA ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["SKU"];
                    item.descripcion = (string)reader["TITULO_PUBLICACION"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["PRECIO"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["PRECIO"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["PRECIO"] * (int)reader["UNIDADES"]) + ((double)reader["PRECIO"] * (int)reader["UNIDADES"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_CatPhone_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select N_VENTA,TITULO_PUBLICACION,SKU,SUM(UNIDADES_REAL) AS UNIDADES,CONVERT(float,INGRESOS_PROD/1.18) as PRECIO " +
                    "from OC_CATPHONE_CONS Where N_VENTA= '"+NRO_OC+"' group by SKU,TITULO_PUBLICACION,INGRESOS_PROD,N_VENTA " +
                    "Union select N_VENTA,'COSTO DE ENVIO','AACSTO09ENVLNOPE-31122020',1, CONVERT(float,ABS(COSTO_ENVIO))/1.18 AS COSTO_ENVIO " +
                    "FRom OC_CATPHONE_CONS Where N_VENTA = '"+NRO_OC+"' And COSTO_ENVIO<0 group by N_VENTA,COSTO_ENVIO order by SKU desc";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["SKU"];
                    item.descripcion = (string)reader["NOMBRE_SKU"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["PRECIO_SKU"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO_SKU"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"]) + ((double)reader["PRECIO_SKU"] * (int)reader["UNIDADES"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_Ripley_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select NRO_PEDIDO,SUBSTRING(DETALLES,0,LEN(DETALLES)-70) AS DETALLES,SKU_OFERTA,SUM(UNIDADES_REAL) AS UNIDADES,PRECIO_UNIDAD/1.18 as PRECIO_UNIDAD from " +
                    "OC_RPL_CONS Where NRO_PEDIDO= '" + NRO_OC + "' group by NRO_PEDIDO,DETALLES,SKU_OFERTA,UNIDADES_REAL,PRECIO_UNIDAD " +
                    "Union select NRO_PEDIDO,'COSTO DE ENVIO','AACSTO09ENVLNOPE-31122020',1,IMPORTE_TOTAL_ENVIO/1.18  FRom OC_RPL_CONS " +
                    "Where NRO_PEDIDO = '" + NRO_OC + "' And IMPORTE_TOTAL_ENVIO>0 group by NRO_PEDIDO,IMPORTE_TOTAL_ENVIO order by SKU_OFERTA desc, DETALLES desc";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["SKU_OFERTA"];
                    item.descripcion = (string)reader["DETALLES"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["PRECIO_UNIDAD"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO_UNIDAD"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"]) + ((double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_Juntoz_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select NRO_PEDIDO,NOMBRE,SKU,SUM(UNIDADES_REAL) AS UNIDADES,CONVERT(float,PRECIO/1.18) as PRECIO_UNIDAD  " +
                    "from OC_JTZ_CONS Where NRO_PEDIDO= '"+NRO_OC+"' group by NRO_PEDIDO,NOMBRE,SKU,UNIDADES_REAL,PRECIO " +
                    "Union select NRO_PEDIDO,'COSTO DE ENVIO','AACSTO09ENVLNOPE-31122020',1,CONVERT(float,ENVIO/1.18 ) AS ENVIO  " +
                    "FRom OC_JTZ_CONS Where NRO_PEDIDO = '"+NRO_OC+"' And ENVIO>0 group by NRO_PEDIDO,ENVIO order by SKU desc, NOMBRE desc";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["SKU"];
                    item.descripcion = (string)reader["NOMBRE"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["PRECIO_UNIDAD"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO_UNIDAD"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"]) + ((double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_Kingston_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select NRO_PEDIDO,SUBSTRING(DETALLES,0,LEN(DETALLES)-70) AS DETALLES,SKU_OFERTA,SUM(UNIDADES_REAL) AS UNIDADES,PRECIO_UNIDAD/1.18 as PRECIO_UNIDAD from " +
                    "OC_KNG_CONS Where NRO_PEDIDO= '" + NRO_OC + "' group by NRO_PEDIDO,DETALLES,SKU_OFERTA,UNIDADES_REAL,PRECIO_UNIDAD " +
                    "Union select NRO_PEDIDO,'COSTO DE ENVIO','AACSTO09ENVLNOPE-31122020',1,IMPORTE_TOTAL_ENVIO/1.18  FRom OC_KNG_CONS " +
                    "Where NRO_PEDIDO = '" + NRO_OC + "' And IMPORTE_TOTAL_ENVIO>0 group by NRO_PEDIDO,IMPORTE_TOTAL_ENVIO order by SKU_OFERTA desc, DETALLES desc";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["SKU_OFERTA"];
                    item.descripcion = (string)reader["DETALLES"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["PRECIO_UNIDAD"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO_UNIDAD"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"]) + ((double)reader["PRECIO_UNIDAD"] * (int)reader["UNIDADES"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_Linio_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select ORDER_NUMBER,ITEM_NAME,LINIO_SKU,SUM(UNIDADES_REAL) AS UNIDADES,UNIT_PRICE/1.18 as UNIT_PRICE from OC_LNO_CONS " +
                    "Where ORDER_NUMBER= '"+NRO_OC+ "' group by LINIO_SKU,ITEM_NAME,UNIT_PRICE,ORDER_NUMBER,FECHA_PROCESO " +
                    "Union select ORDER_NUMBER,'COSTO DE ENVIO','AACSTO09ENVLNOPE-31122020',1,SUM(SHIPPING_FEE)/1.18  FRom OC_LNO_CONS Where ORDER_NUMBER = '" + NRO_OC+"'" +
                    " And SHIPPING_FEE>0 group by ORDER_NUMBER,SHIPPING_FEE ORDER BY LINIO_SKU DESC";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["LINIO_SKU"];
                    item.descripcion = (string)reader["ITEM_NAME"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["UNIT_PRICE"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["UNIT_PRICE"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"]) + ((double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_Falabella_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select ORDER_NUMBER,ITEM_NAME,FALABELLA_SKU,SUM(UNIDADES_REAL) AS UNIDADES,UNIT_PRICE/1.18 as UNIT_PRICE " +
                    "from OC_FBL_CONS Where ORDER_NUMBER= '"+ NRO_OC + "' group by FALABELLA_SKU,ITEM_NAME,UNIT_PRICE,ORDER_NUMBER,FECHA_PROCESO " +
                    "Union select ORDER_NUMBER,'COSTO DE ENVIO','AACSTO09ENVLNOPE-31122020',1,SUM(SHIPPING_FEE)/1.18  " +
                    "FRom OC_FBL_CONS Where ORDER_NUMBER = '"+NRO_OC+"' And SHIPPING_FEE>0 group by ORDER_NUMBER,SHIPPING_FEE " +
                    "ORDER BY FALABELLA_SKU ASC";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["FALABELLA_SKU"];
                    item.descripcion = (string)reader["ITEM_NAME"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["UNIT_PRICE"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["UNIT_PRICE"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"]) + ((double)reader["UNIT_PRICE"] * (int)reader["UNIDADES"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_Artos_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select FB.ORDER_NUMBER,ST.TITULO,ST.PARTNUMBER,SUM(FB.UNIDADES_REAL) AS UNIDADES , " +
                    "CASE (E.MONEDA) WHEN 'PEN' THEN E.PRECIO_UNIT_S_IGV ELSE E.PRECIO_UNIT_S_IGV *TC.COMPRA END AS PRECIO " +
                    "from ST_STOCK ST " +
                    "JOIN OC_FBL_CONS FB ON FB.FALABELLA_SKU = ST.SKU_FALABELLA " +
                    "LEFT JOIN ST_ENTRADAS_CONS E ON E.MINICODIGO = ST.MINI_CODIGO AND E.FECHA_PROCESO = " +
                    "(select MAX(FECHA_PROCESO) FROM ST_ENTRADAS_CONS WHERE MINICODIGO=ST.MINI_CODIGO AND PRECIO_UNIT_S_IGV IS NOT NULL " +
                    "AND PRECIO_UNIT_S_IGV >0) " +
                    "JOIN TC_SUNAT TC ON CONVERT(varchar,FB.FECHA_PROCESO,23) = CONVERT(varchar,TC.FECHA,23) " +
                    "WHERE ORDER_NUMBER = '"+NRO_OC +"'"+
                    "GROUP BY ST.TITULO,ST.PARTNUMBER,e.PRECIO_UNIT_S_IGV,FB.ORDER_NUMBER,E.MONEDA,TC.COMPRA";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["PARTNUMBER"];
                    item.descripcion = (string)reader["TITULO"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES"];
                    item.valor_unitario = (double)reader["PRECIO"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO"] * (int)reader["UNIDADES"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["PRECIO"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO"] * (int)reader["UNIDADES"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO"] * (int)reader["UNIDADES"];
                    item.total_item = ((double)reader["PRECIO"] * (int)reader["UNIDADES"]) + ((double)reader["PRECIO"] * (int)reader["UNIDADES"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_ItemsFactura> Lista_Items_Coolbox_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_items = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select SKU_SELLING_PRICE/1.18 AS PRECIO,ID_SKU AS SKU,SKU_NAME,UNIDADES_REAL from OC_CLB_CONS WHERE OC_ORDER ='" + NRO_OC+"'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["SKU"];
                    item.descripcion = (string)reader["SKU_NAME"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES_REAL"];
                    item.valor_unitario = (double)reader["PRECIO"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["PRECIO"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["PRECIO"] * (int)reader["UNIDADES_REAL"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["PRECIO"] * (int)reader["UNIDADES_REAL"] * 0.18;
                    item.total_impuestos = (double)reader["PRECIO"] * (int)reader["UNIDADES_REAL"] * 0.18;
                    item.total_valor_item = (double)reader["PRECIO"] * (int)reader["UNIDADES_REAL"];
                    item.total_item = ((double)reader["PRECIO"] * (int)reader["UNIDADES_REAL"]) + ((double)reader["PRECIO"] * (int)reader["UNIDADES_REAL"] * 0.18);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_Juntoz_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select TIPO_DOC, CASE (TIPO_DOC) WHEN 'FACTURA' THEN RUC ELSE DOCUMENTO_CLIENTE END AS DOC_CLIENTE, " +
                    "CASE (TIPO_DOC) WHEN 'FACTURA' THEN RAZON_SOCIAL ELSE NOMBRE_CLIENTE END AS NOMBRE_CLIENTE,DIRECCION_RECEPTOR,EMAIL_CLIENTE," +
                    "TELEFONO_CLIENTE from OC_JTZ_CONS Where NRO_PEDIDO= '" + NRO_OC + "' ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = (string)reader["TIPO_DOC"] == "BOLETA" ? "1" : "6";
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["NOMBRE_CLIENTE"];
                    cliente.numero_documento = (string)reader["DOC_CLIENTE"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIRECCION_RECEPTOR"];
                    cliente.correo_electronico = (string)reader["EMAIL_CLIENTE"];
                    cliente.telefono = (string)reader["TELEFONO_CLIENTE"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_Ripley_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select DNI,CONCAT([DIRECCION_FACTURACION: APELLIDO],', ',[DIRECCION_FACTURACION: NOMBRE_DE_PILA]) AS NOM_CLI, " +
                    "CONCAT([DIRECCION_FACTURACION: CALLE_1],', ',[DIRECCION_ENTREGA: CALLE_2],' - ',[DIRECCION_ENTREGA: CIUDAD]) AS DIRECCION_CLI, " +
                    "EMAIL,[DIRECCION_FACTURACION:TELEFONO] AS TELEFONO from OC_RPL_CONS Where NRO_PEDIDO= '" + NRO_OC + "' ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = "1";
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["NOM_CLI"];
                    cliente.numero_documento = (string)reader["DNI"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIRECCION_CLI"];
                    cliente.correo_electronico = (string)reader["EMAIL"];
                    cliente.telefono = (string)reader["TELEFONO"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_Coolbox_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select CASE WHEN CORPORATE_NAME='' THEN CONCAT(CLIENT_NAME,CLIENT_LAST_NAME) ELSE CORPORATE_NAME END AS NAME,CASE WHEN CORPORATE_DOCUMENT='' THEN CLIENT_DOCUMENT " +
                    "ELSE CORPORATE_DOCUMENT END AS DOCUMENTO ,PHONE,EMAIL,CONCAT(REFERENCE,' ',STREET,'-',NEIGHBORHOOD,'-',CITY) AS DIRECCION " +
                    ",CASE WHEN CORPORATE_DOCUMENT='' THEN '1' ELSE '6' END AS TIPO_DOCUMENTO " +
                    "FROM OC_CLB_CONS Where OC_ORDER= '" + NRO_OC + "' ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = (string)reader["TIPO_DOCUMENTO"];
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["NAME"];
                    cliente.numero_documento = (string)reader["DOCUMENTO"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIRECCION"];
                    cliente.correo_electronico = (string)reader["EMAIL"];
                    cliente.telefono = (string)reader["PHONE"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_Kingston_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select DNI,CONCAT([DIRECCION_FACTURACION: APELLIDO],', ',[DIRECCION_FACTURACION: NOMBRE_DE_PILA]) AS NOM_CLI, " +
                    "CONCAT([DIRECCION_FACTURACION: CALLE_1],', ',[DIRECCION_ENTREGA: CALLE_2],' - ',[DIRECCION_ENTREGA: CIUDAD]) AS DIRECCION_CLI, " +
                    "EMAIL,[DIRECCION_FACTURACION:TELEFONO] AS TELEFONO from OC_KNG_CONS Where NRO_PEDIDO= '" + NRO_OC + "' ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = "1";
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["NOM_CLI"];
                    cliente.numero_documento = (string)reader["DNI"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIRECCION_CLI"];
                    cliente.correo_electronico = (string)reader["EMAIL"];
                    cliente.telefono = (string)reader["TELEFONO"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_Oficina_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select NRO_DOC,TIPO_DOC,CLIENTE, DIRECCION, '' AS EMAIL,'' AS TELEFONO from ST_PEDIDO_DETALLE Where NRO_PEDIDO= " +
                    "'" + NRO_OC + "' ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = (string)reader["TIPO_DOC"]=="DNI"?"1":"6";
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["CLIENTE"];
                    cliente.numero_documento = (string)reader["NRO_DOC"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIRECCION"];
                    cliente.correo_electronico = (string)reader["EMAIL"];
                    cliente.telefono = (string)reader["TELEFONO"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_RealPlaza_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select CASE (RUC) WHEN '' THEN '1' ELSE '6' END AS TIPO_DOC_CLIENTE, CASE (RUC) WHEN '' THEN NUMERO_DOCUMENTO ELSE RUC END " +
                    "AS NUM_DOC,CLIENTE, CONCAT(DIRECCION,' ',DISTRITO,' - ',DEPARTAMENTO ) AS DIRECCION_CLI, EMAIL_CLIENTE,'' AS TELEFONO " +
                    "from OC_RPG_CONS Where NUMERO= '" + NRO_OC + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = (string)reader["TIPO_DOC_CLIENTE"];
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["CLIENTE"];
                    cliente.numero_documento = (string)reader["NUM_DOC"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIRECCION_CLI"];
                    cliente.correo_electronico = (string)reader["EMAIL_CLIENTE"];
                    cliente.telefono = (string)reader["TELEFONO"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_MercadoLibre_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select DNI_CLI, NOM_CLI,DIR_DESTINO, '' AS E_MAIL,ISNULL(TEL_CLI,'') AS TELEFONO_FACT from ST_SALIDAS_CONS " +
                    "Where NRO_ORDEN= '" + NRO_OC + "' AND TIPO='DATOS MERCADO_LIBRE'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = Convert.ToString((string)reader["DNI_CLI"]).Length == 11 ? "6" : "1"; ;
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["NOM_CLI"];
                    cliente.numero_documento = (string)reader["DNI_CLI"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIR_DESTINO"];
                    cliente.correo_electronico = (string)reader["E_MAIL"];
                    cliente.telefono = (string)reader["TELEFONO_FACT"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_CatPhone_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select DNI_CLI, NOM_CLI,DIR_DESTINO, '' AS E_MAIL,ISNULL(TEL_CLI,'') AS TELEFONO_FACT from ST_SALIDAS_CONS " +
                    "Where NRO_ORDEN= '200000" + NRO_OC + "' AND TIPO='DATOS CATPHONE'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = Convert.ToString((string)reader["DNI_CLI"]).Length == 11 ? "6" : "1"; ;
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["NOM_CLI"];
                    cliente.numero_documento = (string)reader["DNI_CLI"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIR_DESTINO"];
                    cliente.correo_electronico = (string)reader["E_MAIL"];
                    cliente.telefono = (string)reader["TELEFONO_FACT"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_Linio_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select NATIONAL_REGISTRATION_NUMBER,CUSTOMER_NAME,CONCAT(BILLING_ADDRESS,' ',BILLING_ADDRESS_2,' ',BILLING_ADDRESS_3," +
                    "'-', BILLING_CITY) AS DIRECCION_CLI,CUSTOMER_EMAIL from OC_LNO_CONS " +
                    "Where ORDER_NUMBER= '" + NRO_OC + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = Convert.ToString((string)reader["NATIONAL_REGISTRATION_NUMBER"]).Length==11?"6":"1";
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["CUSTOMER_NAME"];
                    cliente.numero_documento = (string)reader["NATIONAL_REGISTRATION_NUMBER"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIRECCION_CLI"];
                    cliente.correo_electronico = (string)reader["CUSTOMER_EMAIL"];
                    cliente.telefono="";
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public e_ClienteFactura Lista_Cliente_Falabella_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "select NATIONAL_REGISTRATION_NUMBER,CUSTOMER_NAME,CONCAT(BILLING_ADDRESS,' ',BILLING_ADDRESS_2,' ',BILLING_ADDRESS_3," +
                    "'-', BILLING_CITY) AS DIRECCION_CLI from OC_FBL_CONS " +
                    "Where ORDER_NUMBER= '" + NRO_OC + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = Convert.ToString((string)reader["NATIONAL_REGISTRATION_NUMBER"]).Length == 11 ? "6" : "1";
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["CUSTOMER_NAME"];
                    cliente.numero_documento = (string)reader["NATIONAL_REGISTRATION_NUMBER"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIRECCION_CLI"];
                    cliente.correo_electronico = "";
                    cliente.telefono = "";
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        //AGREGANDO CONECTA: ****

        //agregando la actualizacion de conecta prueba
        public string Actualizar_NroFact_Conecta(string serie, string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_CONECTA_CONS SET SERIE_FACT = '" + serie + "',NRO_FACT = '" + nro + "' Where NUMERO_ORDEN = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        //WHERE SERIE_FACT IS NULL " +
        //            "AND ST_ORDEN NOT IN ('ANULADO','ANULADO BD','DEVUELTO') AND YEAR(FECHA_ENTREGA)*10000+MONTH(FECHA_ENTREGA)*100+DAY(FECHA_ENTREGA)< YEAR(GETDATE())*10000+MONTH(GETDATE())*100+DAY(GETDATE())

        //LISTADO DE LA FACTURA 
        public List<e_FacturasPendientes> Lista_Items_Conecta()
        {
            List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
            string consulta = "select NUMERO_ORDEN, DNI_CLIENTE, NOMBRE_CLIENTE, DIRECCION_CLIENTE, EMAIL_CLIENTE, TELEFONO_CLIENTE, DESCRIPCION_PRODUCTO, COD_PRODUCTO, UNIDADES_SOLICITADAS, COSTO_NETO_UNITARIO, TOTAL, B.[NOMBRE CLIENTE] AS [NOMBRE CLIENTE] from OC_CONECTA_CONS AS A JOIN GUIAS_CONECTA_CONS AS B ON B.NRO_OC = NUMERO_ORDEN " +
                "WHERE NUMERO_ORDEN not in (SELECT NRO_OC FROM ST_FACTURA) AND FECHA_ENTREGA > '2024-02-01' AND NRO_FACT IS NULL ORDER BY NUMERO_ORDEN "; // AND ESTADO='ENVÍO EN CURSO' AND FECHA_PROCESO > '2023-03-04 00:00:000'

            try
            {
                using (SqlConnection con = db_conect.Conecta_DB())
                {
                    SqlCommand cmd_0 = new SqlCommand(consulta, con);
                    using (SqlDataReader reader = cmd_0.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Asegúrate de que las conversiones de tipos son correctas.
                            lista_facturas.Add(new e_FacturasPendientes
                            {
                                NRO_OC = reader["NUMERO_ORDEN"].ToString(),
                                Cliente_DNI = reader["DNI_CLIENTE"].ToString(),
                                Cliente_Nombre = reader["NOMBRE_CLIENTE"].ToString(),
                                Direccion = reader["DIRECCION_CLIENTE"].ToString(),
                                Email = reader["EMAIL_CLIENTE"].ToString(),
                                Telefono = reader["TELEFONO_CLIENTE"].ToString(),
                                Item = reader["DESCRIPCION_PRODUCTO"].ToString(),
                                Codigo_Item = reader["COD_PRODUCTO"].ToString(),
                                Cantidad = Convert.ToInt32(reader["UNIDADES_SOLICITADAS"]),
                                Precio = Convert.ToDouble(reader["COSTO_NETO_UNITARIO"]),
                                Costo_Envio = Convert.ToDouble(reader["TOTAL"]),
                                Razon_Social = reader["NOMBRE CLIENTE"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                // Considera utilizar un mecanismo de logging más robusto
            }
            return lista_facturas;
        }

        //FILTRO POR NUMERO DE ORDEN
        public List<e_FacturasPendientes> Lista_Items_Conecta(string NRO)
        {

            List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
            string consulta = "select NUMERO_ORDEN, DNI_CLIENTE, NOMBRE_CLIENTE, DIRECCION_CLIENTE, EMAIL_CLIENTE, TELEFONO_CLIENTE, DESCRIPCION_PRODUCTO, COD_PRODUCTO, UNIDADES_SOLICITADAS, COSTO_NETO_UNITARIO, TOTAL " +
                "from OC_CONECTA_CONS WHERE NUMERO_ORDEN ='" + NRO + "'";
            try
            {
                using (SqlConnection con = db_conect.Conecta_DB())
                {
                    SqlCommand cmd_0 = new SqlCommand(consulta, con);
                    using (SqlDataReader reader = cmd_0.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Asegúrate de que las conversiones de tipos son correctas.
                            lista_facturas.Add(new e_FacturasPendientes
                            {
                                NRO_OC = reader["NUMERO_ORDEN"].ToString(),
                                Cliente_DNI = reader["DNI_CLIENTE"].ToString(),
                                Cliente_Nombre = reader["NOMBRE_CLIENTE"].ToString(),
                                Direccion = reader["DIRECCION_CLIENTE"].ToString(),
                                Email = reader["EMAIL_CLIENTE"].ToString(),
                                Telefono = reader["TELEFONO_CLIENTE"].ToString(),
                                Item = reader["DESCRIPCION_PRODUCTO"].ToString(),
                                Codigo_Item = reader["COD_PRODUCTO"].ToString(),
                                Cantidad = Convert.ToInt32(reader["UNIDADES_SOLICITADAS"]),
                                Precio = Convert.ToDouble(reader["COSTO_NETO_UNITARIO"]),
                                Costo_Envio = Convert.ToDouble(reader["TOTAL"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                // Considera utilizar un mecanismo de logging más robusto
            }
            return lista_facturas;
        }

        //filtro por fecha

        public List<e_FacturasPendientes> Lista_Items_Conecta_Filtro(string FECHA)
        {

            List<e_FacturasPendientes> lista_facturas = new List<e_FacturasPendientes>();
            string consulta = "select NUMERO_ORDEN, DNI_CLIENTE, NOMBRE_CLIENTE, DIRECCION_CLIENTE, EMAIL_CLIENTE, TELEFONO_CLIENTE, DESCRIPCION_PRODUCTO, COD_PRODUCTO, UNIDADES_SOLICITADAS, COSTO_NETO_UNITARIO, TOTAL " +
                "from OC_CONECTA_CONS WHERE FECHA_ENTREGA ='" + FECHA + "'";
            try
            {
                using (SqlConnection con = db_conect.Conecta_DB())
                {
                    SqlCommand cmd_0 = new SqlCommand(consulta, con);
                    using (SqlDataReader reader = cmd_0.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Asegúrate de que las conversiones de tipos son correctas.
                            lista_facturas.Add(new e_FacturasPendientes
                            {
                                NRO_OC = reader["NUMERO_ORDEN"].ToString(),
                                Cliente_DNI = reader["DNI_CLIENTE"].ToString(),
                                Cliente_Nombre = reader["NOMBRE_CLIENTE"].ToString(),
                                Direccion = reader["DIRECCION_CLIENTE"].ToString(),
                                Email = reader["EMAIL_CLIENTE"].ToString(),
                                Telefono = reader["TELEFONO_CLIENTE"].ToString(),
                                Item = reader["DESCRIPCION_PRODUCTO"].ToString(),
                                Codigo_Item = reader["COD_PRODUCTO"].ToString(),
                                Cantidad = Convert.ToInt32(reader["UNIDADES_SOLICITADAS"]),
                                Precio = Convert.ToDouble(reader["COSTO_NETO_UNITARIO"]),
                                Costo_Envio = Convert.ToDouble(reader["TOTAL"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                // Considera utilizar un mecanismo de logging más robusto
            }
            return lista_facturas;
        }


        //hacer calculos para enviar la factura
        public List<e_ItemsFactura> Lista_Items_Conecta_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ItemsFactura> lista_facturas = new List<e_ItemsFactura>();
                e_ItemsFactura item = null;
                string consulta = "select NUMERO_ORDEN, COD_PRODUCTO, DESCRIPCION_PRODUCTO, UNIDADES_SOLICITADAS, COSTO_NETO_UNITARIO FROM OC_CONECTA_CONS where NUMERO_ORDEN='" + NRO_OC + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new e_ItemsFactura();
                    item.codigo_interno = (string)reader["COD_PRODUCTO"];
                    item.descripcion = (string)reader["DESCRIPCION_PRODUCTO"];
                    item.codigo_producto_sunat = "";
                    item.unidad_de_medida = "NIU";
                    item.cantidad = (int)reader["UNIDADES_SOLICITADAS"];
                    item.valor_unitario = (double)reader["COSTO_NETO_UNITARIO"];
                    item.codigo_tipo_precio = "01";
                    item.precio_unitario = (double)reader["COSTO_NETO_UNITARIO"] * 1.18;
                    item.codigo_tipo_afectacion_igv = "10";
                    item.total_base_igv = (double)reader["COSTO_NETO_UNITARIO"] * (int)reader["UNIDADES_SOLICITADAS"];
                    item.porcentaje_igv = 18;
                    item.total_igv = (double)reader["COSTO_NETO_UNITARIO"] * (int)reader["UNIDADES_SOLICITADAS"] * 0.18;
                    item.total_impuestos = (double)reader["COSTO_NETO_UNITARIO"] * (int)reader["UNIDADES_SOLICITADAS"] * 0.18;
                    item.total_valor_item = (double)reader["COSTO_NETO_UNITARIO"] * (int)reader["UNIDADES_SOLICITADAS"];
                    item.total_item = ((double)reader["COSTO_NETO_UNITARIO"] * (int)reader["UNIDADES_SOLICITADAS"]) + ((double)reader["COSTO_NETO_UNITARIO"] * (int)reader["UNIDADES_SOLICITADAS"] * 0.18);
                    lista_facturas.Add(item);
                }
                reader.Close();
                return lista_facturas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        //MODIFICANDO LA RAZON SOCIAL
        //SE TRAE LOS DATOS DE LAS GUIAS PARA CARGAR EN LA FACTURA DE CONECTA
        public e_ClienteFactura Lista_Cliente_Conecta_datos(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_ClienteFactura> lista_clientes = new List<e_ClienteFactura>();
                e_ClienteFactura cliente = null;
                string consulta = "SELECT [TIPO DEL DOCUMENTO DEL CLIENTE], [NOMBRE CLIENTE], [NUMERO DE DOCUMENTO], [DIRECCION], [CORREO], [TELEFONO] FROM GUIAS_CONECTA_CONS Where NRO_OC= '" + NRO_OC + "' ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_ClienteFactura();
                    cliente.codigo_tipo_documento_identidad = (string)reader["TIPO DEL DOCUMENTO DEL CLIENTE"];
                    cliente.apellidos_y_nombres_o_razon_social = (string)reader["NOMBRE CLIENTE"];
                    cliente.numero_documento = (string)reader["NUMERO DE DOCUMENTO"];
                    cliente.codigo_pais = "PE";
                    cliente.ubigeo = "";
                    cliente.direccion = (string)reader["DIRECCION"];
                    cliente.correo_electronico = (string)reader["CORREO"];
                    cliente.telefono = (string)reader["TELEFONO"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        //ACTUALIZANDO GUIAS PARA QUE SE PUEDA VER EN LAS FACTURAS, SE ESTA USANDO LA TABLA GUIAS PARA REALIZAR LA FACTURA

        public string Update_Guias(string NRO_OC, string ruc, string cliente, string direccion)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string modif = "UPDATE GUIAS_CONECTA_CONS SET [NUMERO DE DOCUMENTO] = '" + ruc + "'  , [NOMBRE CLIENTE] = '" + cliente + "' ,  DIRECCION = '" + direccion + "' WHERE NRO_OC='" + NRO_OC + "'";
                SqlCommand cmd_0 = new SqlCommand(modif, con);
                cmd_0.ExecuteNonQuery();
                return "Se modificó exitosamente";

            }
            catch (Exception err)
            {
                return err.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();

            }
        }


    }
}
