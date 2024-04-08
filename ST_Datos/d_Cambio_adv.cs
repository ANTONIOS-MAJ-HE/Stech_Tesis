using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
   public class d_Cambio_adv
    {
        d_SQLcon db_st = new d_SQLcon();

        public string Actualizar_Duplicado_RealPlaza(e_Cambio_adv obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string actualiza = string.Format("UPDATE OC_RPG_CONS SET UNIDADES_REAL = '{0}' WHERE NUMERO = '{1}' AND PARTNUMBER_REAL = '{2}'",
                    obj.CANT_PARTNUMB_1, obj.NRO_OC, obj.PARTNUMB_1);
                SqlCommand cmd_0 = new SqlCommand(actualiza, con);
                cmd_0.ExecuteNonQuery();
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
        public string Duplicar_REALPLAZA(e_Cambio_adv obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string duplica = string.Format("INSERT INTO OC_RPG_CONS (OBSERVACIONES,NRO_CMP,SERIE_CMP,UNIDADES_REAL,PARTNUMBER_REAL,FECHA_DESPACHO,ST_DESPACHO,ST_ORDEN,FECHA_PROCESO,MONTO_LIQUIDACION,FECHA_LIQUIDACION,TOTAL_PROMOCION_ECOMMERCE,PROMOCION_SELLER,TOTAL_PROMOCION_ADMIN,PROMOCION_ADMIN,PRECIO_SKU,CANTIDAD_SKU,NOMBRE_SKU,SKU,ETIQUETAS,SITIOS,NOMBRE_DEL_SELLER,FECHA_MAXIMA_ENTREGA,TIEMPO_ESTIMADO_ENTREGA,TRANSPORTADORA,ESTADO,TOTAL_COMISION,COSTO_TOTAL_ENVIO,TOTAL_DESCUENTOS,TOTAL_ITEMS,TOTAL,FECHA,RAZON_SOCIAL,RUC,NUMERO_DOCUMENTO,TIPO_DOCUMENTO,DEPARTAMENTO,PROVINCIA,DISTRITO,DIRECCION,EMAIL_CLIENTE,TELEFONO_CLIENTE,CLIENTE,NUMERO) SELECT '{0}',NRO_CMP,SERIE_CMP,'{1}','{2}',FECHA_DESPACHO,ST_DESPACHO,'DUPLICADO',FECHA_PROCESO,MONTO_LIQUIDACION,FECHA_LIQUIDACION,TOTAL_PROMOCION_ECOMMERCE,PROMOCION_SELLER,TOTAL_PROMOCION_ADMIN,PROMOCION_ADMIN,PRECIO_SKU,CANTIDAD_SKU,NOMBRE_SKU,SKU,ETIQUETAS,SITIOS,NOMBRE_DEL_SELLER,FECHA_MAXIMA_ENTREGA,TIEMPO_ESTIMADO_ENTREGA,TRANSPORTADORA,ESTADO,TOTAL_COMISION,COSTO_TOTAL_ENVIO,TOTAL_DESCUENTOS,TOTAL_ITEMS,TOTAL,FECHA,RAZON_SOCIAL,RUC,NUMERO_DOCUMENTO,TIPO_DOCUMENTO,DEPARTAMENTO,PROVINCIA,DISTRITO,DIRECCION,EMAIL_CLIENTE,TELEFONO_CLIENTE,CLIENTE,NUMERO FROM OC_RPG_CONS WHERE NUMERO LIKE '%{3}%' AND PARTNUMBER_REAL LIKE '%{4}%'",
                    obj.OBSERVACIONES, obj.CANT_PARTNUMB_2, obj.PARTNUMB_2, obj.NRO_OC, obj.PARTNUMB_1);
                SqlCommand cmd_0 = new SqlCommand(duplica, con);
                cmd_0.ExecuteNonQuery();
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

        public string Actualizar_Duplicado_Linio(e_Cambio_adv obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string actualiza = string.Format("UPDATE OC_LNO_CONS SET UNIDADES_REAL = '{0}' WHERE ORDER_NUMBER = '{1}' AND PART_NUMB_REAL = '{2}'",
                    obj.CANT_PARTNUMB_1, obj.NRO_OC, obj.PARTNUMB_1);
                SqlCommand cmd_0 = new SqlCommand(actualiza, con);
                cmd_0.ExecuteNonQuery();
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
        public string Duplicar_LINIO(e_Cambio_adv obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string duplica = string.Format("INSERT INTO OC_LNO_CONS  (OBSERVACIONES,NRO_CMP,SERIE_CMP,FECHA_DESPACHO,UNIDADES_REAL,PART_NUMB_REAL,ST_ORDEN,ST_DESPACHO,FECHA_PROCESO,PAYMENT_MEANS_ID,PAYMENT_MEANS_ID_CODE,TAX_SCHEME_CODE,PAYER_OBLIGATIONS_CODE,CUSTOMER_VERIFIER_DIGIT,RECEIVER_COMMERCIAL_NAME,RECEIVER_TYPE_REGIMEN,LEGAL_ID,DOCUMENT_TYPE,FISCAL_PERSON,RECEIVER_POSTCODE,RECEIVER_MUNICIPALITY,RECEIVER_REGION,RECEIVER_ADDRESS,RECEIVER_LEGAL_NAME,[SISTEMA_OPERATIVO (Filtro)],[PROCESADOR (Filtro)],DISCO_DURO_SECUNDARIO,REASON,STATUS,PREMIUM,PROMISED_SHIPPING_TIME,TRACKING_URL,TRACKING_CODE,CD_TRACKING_CODE,SHIPPING_PROVIDER_TYPE,SHIPMENT_TYPE_NAME,SHIPPING_PROVIDER,CD_SHIPPING_PROVIDER,VARIATION,ITEM_NAME,WALLET_CREDITS,SHIPPING_FEE,UNIT_PRICE,PAID_PRICE,PAYMENT_METHOD,BILLING_COUNTRY,BILLING_POSTCODE,BILLING_CITY,BILLING_ADDRESS_5,BILLING_ADDRESS_4,BILLING_ADDRESS_3,BILLING_ADDRESS_2,BILLING_ADDRESS,BILLING_NAME,SHIPPING_COUNTRY,SHIPPING_POSTCODE,SHIPPING_CITY,SHIPPING_ADDRESS_5,SHIPPING_ADDRESS_4,SHIPPING_ADDRESS_3,SHIPPING_ADDRESS_2,SHIPPING_ADDRESS,SHIPPING_NAME,NATIONAL_REGISTRATION_NUMBER,CUSTOMER_EMAIL,CUSTOMER_NAME,INVOICE_REQUIRED,ORDER_CURRENCY,ORDER_SOURCE,ORDER_NUMBER,UPDATED_AT,CREATED_AT,LINIO_SKU,SELLER_SKU,LINIO_ID,ORDER_ITEM_ID) SELECT '{0}',NRO_CMP,SERIE_CMP,FECHA_DESPACHO,'{1}','{2}','DUPLICADO',ST_DESPACHO,FECHA_PROCESO,PAYMENT_MEANS_ID,PAYMENT_MEANS_ID_CODE,TAX_SCHEME_CODE,PAYER_OBLIGATIONS_CODE,CUSTOMER_VERIFIER_DIGIT,RECEIVER_COMMERCIAL_NAME,RECEIVER_TYPE_REGIMEN,LEGAL_ID,DOCUMENT_TYPE,FISCAL_PERSON,RECEIVER_POSTCODE,RECEIVER_MUNICIPALITY,RECEIVER_REGION,RECEIVER_ADDRESS,RECEIVER_LEGAL_NAME,[SISTEMA_OPERATIVO (Filtro)],[PROCESADOR (Filtro)],DISCO_DURO_SECUNDARIO,REASON,STATUS,PREMIUM,PROMISED_SHIPPING_TIME,TRACKING_URL,TRACKING_CODE,CD_TRACKING_CODE,SHIPPING_PROVIDER_TYPE,SHIPMENT_TYPE_NAME,SHIPPING_PROVIDER,CD_SHIPPING_PROVIDER,VARIATION,ITEM_NAME,WALLET_CREDITS,SHIPPING_FEE,UNIT_PRICE,PAID_PRICE,PAYMENT_METHOD,BILLING_COUNTRY,BILLING_POSTCODE,BILLING_CITY,BILLING_ADDRESS_5,BILLING_ADDRESS_4,BILLING_ADDRESS_3,BILLING_ADDRESS_2,BILLING_ADDRESS,BILLING_NAME,SHIPPING_COUNTRY,SHIPPING_POSTCODE,SHIPPING_CITY,SHIPPING_ADDRESS_5,SHIPPING_ADDRESS_4,SHIPPING_ADDRESS_3,SHIPPING_ADDRESS_2,SHIPPING_ADDRESS,SHIPPING_NAME,NATIONAL_REGISTRATION_NUMBER,CUSTOMER_EMAIL,CUSTOMER_NAME,INVOICE_REQUIRED,ORDER_CURRENCY,ORDER_SOURCE,ORDER_NUMBER,UPDATED_AT,CREATED_AT,LINIO_SKU,SELLER_SKU,LINIO_ID,ORDER_ITEM_ID FROM OC_LNO_CONS WHERE ORDER_NUMBER LIKE '%{3}%' AND PART_NUMB_REAL LIKE '%{4}%'",
                    obj.OBSERVACIONES, obj.CANT_PARTNUMB_2, obj.PARTNUMB_2, obj.NRO_OC, obj.PARTNUMB_1);
                SqlCommand cmd_0 = new SqlCommand(duplica, con);
                cmd_0.ExecuteNonQuery();
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
        public string Actualizar_Duplicado_Saga(e_Cambio_adv obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string actualiza = string.Format("UPDATE OC_SF_CONS SET UNIDADES_REAL = '{0}' WHERE NRO_OC = '{1}' AND PART_NUMB_REAL = '{2}'",
                    obj.CANT_PARTNUMB_1, obj.NRO_OC, obj.PARTNUMB_1);
                SqlCommand cmd_0 = new SqlCommand(actualiza, con);
                cmd_0.ExecuteNonQuery();
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
        public string Duplicar_SAGA(e_Cambio_adv obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string duplica = string.Format("INSERT INTO OC_SF_CONS (NRO_GUIA,SUB_TOTAL,DSCTO,PRECIO_COSTO_S_IGV,NRO_FACT,SERIE_FACT,UNIDADES_REAL,PART_NUMB_REAL,ST_OBSERVACION,FECHA_ENTREGA,ST_ORDEN,ST_DESPACHO,FECHA_PROCESO,TALLA,FECHA_HASTA,FECHA_DESDE,PISO,MODELO_SKU,DNI_COMPRADOR,IDENTIFICACION_CLIENTE,REGION,FECHA_REPARTO_CLIENTE,ENTRE_CALLE,EMAIL,DOMICILIO_OFICINA,HORARIO_PROGRAMADO,SALUDO,PAPEL_REGALO,DESCUENTO,PRECIO_COSTO,UNIDADES,DESCRIPCION,SKU,UPC,OBSERVACION,DESPACHAR_A,LOCAL,NRO_LOCAL,ATENCION,TELEFONO_RECEPTOR,COD_POSTAL_RECEPTOR,CIUDAD_RECEPTOR,COMUNA_RECEPTOR,DIRECCION_RECEPTOR,NOM_RECEPTOR,TELEFONO_COMPRADOR,NOM_COMPRADOR,FECHA_DESPACHO_PACTADA,FECHA_EMISION_OC,NRO_OC,NRO_F12) SELECT NRO_GUIA,SUB_TOTAL,DSCTO,PRECIO_COSTO_S_IGV,NRO_FACT,SERIE_FACT,'{0}','{1}','{2}',FECHA_ENTREGA,'DUPLICADO',ST_DESPACHO,FECHA_PROCESO,TALLA,FECHA_HASTA,FECHA_DESDE,PISO,MODELO_SKU,DNI_COMPRADOR,IDENTIFICACION_CLIENTE,REGION,FECHA_REPARTO_CLIENTE,ENTRE_CALLE,EMAIL,DOMICILIO_OFICINA,HORARIO_PROGRAMADO,SALUDO,PAPEL_REGALO,DESCUENTO,PRECIO_COSTO,UNIDADES,DESCRIPCION,SKU,UPC,OBSERVACION,DESPACHAR_A,LOCAL,NRO_LOCAL,ATENCION,TELEFONO_RECEPTOR,COD_POSTAL_RECEPTOR,CIUDAD_RECEPTOR,COMUNA_RECEPTOR,DIRECCION_RECEPTOR,NOM_RECEPTOR,TELEFONO_COMPRADOR,NOM_COMPRADOR,FECHA_DESPACHO_PACTADA,FECHA_EMISION_OC,NRO_OC,NRO_F12 FROM OC_SF_CONS WHERE NRO_OC LIKE '%{3}%' AND PART_NUMB_REAL LIKE '%{4}%' ",
                   obj.CANT_PARTNUMB_2,  obj.PARTNUMB_2, obj.OBSERVACIONES, obj.NRO_OC, obj.PARTNUMB_1);
                SqlCommand cmd_0 = new SqlCommand(duplica, con);
                cmd_0.ExecuteNonQuery();
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
        public string Actualizar_Duplicado_Ripley(e_Cambio_adv obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string actualiza = string.Format("UPDATE OC_RPL_CONS SET UNIDADES_REAL = '{0}' WHERE NRO_PEDIDO = '{1}' AND PART_NUMB_REAL = '{2}'",
                    obj.CANT_PARTNUMB_1,obj.NRO_OC,obj.PARTNUMB_1);
                SqlCommand cmd_0 = new SqlCommand(actualiza, con);
                cmd_0.ExecuteNonQuery();
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
        public string Duplicar_RIPLEY(e_Cambio_adv obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string duplica = string.Format("INSERT INTO OC_RPL_CONS (OBSERVACIONES,NRO_CMP,SERIE_CMP,FECHA_DESPACHO,UNIDADES_REAL,PART_NUMB_REAL,ST_ORDEN,ST_DESPACHO,FECHA_PROCESO,PROMO,EMAIL,DNI,TICKET_AURIS,PICKUP_DROPOFF_POINT_ID,PLAZO_ENVIO_PEDIDO,METODO_PAGO,[DIRECCION_FACTURACION: TELEFONO_2],[DIRECCION_FACTURACION:TELEFONO],[DIRECCION_FACTURACION: PAIS],[DIRECCION_FACTURACION: PROVINCIA],[DIRECCION_FACTURACION: CIUDAD],[DIRECCION_FACTURACION: CODIGO_POSTAL],[DIRECCION_FACTURACION: COMPLEMENTARIA],[DIRECCION_FACTURACION: CALLE_2],[DIRECCION_FACTURACION: CALLE_1],[DIRECCION_FACTURACION: EMPRESA],[DIRECCION_FACTURACION: APELLIDO],[DIRECCION_FACTURACION: NOMBRE_DE_PILA],[DIRECCION_FACTURACION: CORTESIA],[DIRECCION_ENTREGA: INFORMACION_INTERNA],[DIRECCION_ENTREGA: INFORMACION_ADICIONAL],[DIRECCION_ENTREGA: TELEFONO_2],[DIRECCION_ENTREGA: TELEFONO],[DIRECCION_ENTREGA: PAIS],[DIRECCION_ENTREGA: PROVINCIA],[DIRECCION_ENTREGA: CIUDAD],[DIRECCION_ENTREGA: CODIGO_POSTAL],[DIRECCION_ENTREGA: COMPLEMENTARIA],[DIRECCION_ENTREGA: CALLE_2],[DIRECCION_ENTREGA: CALLE_1],[DIRECCION_ENTREGA: EMPRESA],[DIRECCION_ENTREGA: APELLIDO],[DIRECCION_ENTREGA: NOMBRE_DE_PILA],[DIRECCION_ENTREGA: CORTESIA],URL_SEGUIMIENTO,NRO_SEGUIMIENTO,EMPRESA_TRANSPORTE,FECHA_RECEPCION,FECHA_ENVIO,FECHA_LIMITE_ENVIO,FECHA_ACEPTACION,TIPO_IVA_EN_COMISION,INFORMACION_ADICIONAL_SOBRE_PRECIOS,[IMPORTE_REEMBOLSADO_A_TIENDA_(CON_IMPUESTOS)],[VALOR_COMISION_(CON_IMPUESTOS)],[COMISION_(SIN IMPUESTOS)],IMPORTE_TOTAL_PEDIDO,IMPORTE_TOTAL_ENVIO,PRECIO_ENVIO,PRECIO_UNIDAD,NRO_ASIENTO_PEDIDO,ESTADO_OFERTA,SKU_OFERTA,MOTIVO,SKU_TIENDA,PROCESO_PAGO,FECHA_DEBITO_CLIENTE,METODO_ENVIO,MONEDA,IMPORTE,ESTADO,DETALLES,CANTIDAD,NRO_PEDIDO,FECHA_DE_CREACION) SELECT '{0}',NRO_CMP,SERIE_CMP,FECHA_DESPACHO,'{1}','{2}','DUPLICADO',ST_DESPACHO,GETDATE(),PROMO,EMAIL,DNI,TICKET_AURIS,PICKUP_DROPOFF_POINT_ID,PLAZO_ENVIO_PEDIDO,METODO_PAGO,[DIRECCION_FACTURACION: TELEFONO_2],[DIRECCION_FACTURACION:TELEFONO],[DIRECCION_FACTURACION: PAIS],[DIRECCION_FACTURACION: PROVINCIA],[DIRECCION_FACTURACION: CIUDAD],[DIRECCION_FACTURACION: CODIGO_POSTAL],[DIRECCION_FACTURACION: COMPLEMENTARIA],[DIRECCION_FACTURACION: CALLE_2],[DIRECCION_FACTURACION: CALLE_1],[DIRECCION_FACTURACION: EMPRESA],[DIRECCION_FACTURACION: APELLIDO],[DIRECCION_FACTURACION: NOMBRE_DE_PILA],[DIRECCION_FACTURACION: CORTESIA],[DIRECCION_ENTREGA: INFORMACION_INTERNA],[DIRECCION_ENTREGA: INFORMACION_ADICIONAL],[DIRECCION_ENTREGA: TELEFONO_2],[DIRECCION_ENTREGA: TELEFONO],[DIRECCION_ENTREGA: PAIS],[DIRECCION_ENTREGA: PROVINCIA],[DIRECCION_ENTREGA: CIUDAD],[DIRECCION_ENTREGA: CODIGO_POSTAL],[DIRECCION_ENTREGA: COMPLEMENTARIA],[DIRECCION_ENTREGA: CALLE_2],[DIRECCION_ENTREGA: CALLE_1],[DIRECCION_ENTREGA: EMPRESA],[DIRECCION_ENTREGA: APELLIDO],[DIRECCION_ENTREGA: NOMBRE_DE_PILA],[DIRECCION_ENTREGA: CORTESIA],URL_SEGUIMIENTO,NRO_SEGUIMIENTO,EMPRESA_TRANSPORTE,FECHA_RECEPCION,FECHA_ENVIO,FECHA_LIMITE_ENVIO,FECHA_ACEPTACION,TIPO_IVA_EN_COMISION,INFORMACION_ADICIONAL_SOBRE_PRECIOS,[IMPORTE_REEMBOLSADO_A_TIENDA_(CON_IMPUESTOS)],[VALOR_COMISION_(CON_IMPUESTOS)],[COMISION_(SIN IMPUESTOS)],IMPORTE_TOTAL_PEDIDO,IMPORTE_TOTAL_ENVIO,PRECIO_ENVIO,PRECIO_UNIDAD,NRO_ASIENTO_PEDIDO,ESTADO_OFERTA,SKU_OFERTA,MOTIVO,SKU_TIENDA,PROCESO_PAGO,FECHA_DEBITO_CLIENTE,METODO_ENVIO,MONEDA,IMPORTE,ESTADO,DETALLES,CANTIDAD,NRO_PEDIDO,FECHA_DE_CREACION FROM OC_RPL_CONS WHERE NRO_PEDIDO LIKE '%{3}%' AND PART_NUMB_REAL LIKE '%{4}%'",
                   obj.OBSERVACIONES,obj.CANT_PARTNUMB_2, obj.PARTNUMB_2, obj.NRO_OC, obj.PARTNUMB_1);
                SqlCommand cmd_0 = new SqlCommand(duplica, con);
                cmd_0.ExecuteNonQuery();
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
        public string Cargar_CONS()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string carga = "INSERT INTO ST_CAMBIOS_ADV SELECT CANAL,GETDATE(),NRO_OC,PARTNUMB_1,ISNULL(TRY_CONVERT(INT,CANT_PARTNUMB_1),0),PARTNUMB_2, ISNULL(TRY_CONVERT(INT,CANT_PARTNUMB_2),0), OBSERVACIONES, ISNULL(TRY_CONVERT(DATETIME,FECHA_REGISTRO),''),RESPONSABLE FROM ST_CAMBIOS_ADV_INPUT WHERE ID_CAMB NOT IN (SELECT ID_CAMB FROM ST_CAMBIOS_ADV)";
                SqlCommand cmd_0 = new SqlCommand(carga, con);
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
        public List<e_Cambio_adv> Lista_cambios ()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Cambio_adv> lista = new List<e_Cambio_adv>();
                e_Cambio_adv camb = null;
                string listar = "SELECT ISNULL(CANAL,'-') AS CANAL, ISNULL(TRY_CONVERT(VARCHAR,FECHA_PROCESO,5),'-') " +
                    "AS FECHA_PROCESO,ISNULL (NRO_OC,'-') AS NRO_OC, ISNULL(PARTNUMB_1,'-') AS PARTNUMB_1, ISNULL(TRY_CONVERT(VARCHAR,CANT_PARTNUMB_1),'0') " +
                    "AS CANT_PARTNUMB_1, ISNULL(PARTNUMB_2,'-') AS PARTNUMB_2, ISNULL(TRY_CONVERT(VARCHAR,CANT_PARTNUMB_2),'0') AS CANT_PARTNUMB_2, " +
                    "ISNULL(OBSERVACIONES,'-') AS OBSERVACIONES, ISNULL(TRY_CONVERT(VARCHAR,FECHA_REGISTRO,5),'-') AS FECHA_REGISTRO ," +
                    "ISNULL(RESPONSABLE,'-') AS RESPONSABLE, ISNULL(ID_CAMB,'-') AS ID_CAMB FROM ST_CAMBIOS_ADV";
                SqlCommand cmd_0 = new SqlCommand(listar, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    camb = new e_Cambio_adv();
                    camb.CANAL = (string)reader["CANAL"];
                    camb.FECHA_PROCESO = (string)reader["FECHA_PROCESO"];
                    camb.NRO_OC = (string)reader["NRO_OC"];
                    camb.PARTNUMB_1 = (string)reader["PARTNUMB_1"];
                    camb.CANT_PARTNUMB_1 = (string)reader["CANT_PARTNUMB_1"];
                    camb.PARTNUMB_2 = (string)reader["PARTNUMB_2"];
                    camb.CANT_PARTNUMB_2 = (string)reader["CANT_PARTNUMB_2"];
                    camb.OBSERVACIONES = (string)reader["OBSERVACIONES"];
                    camb.FECHA_REGISTRO = (string)reader["FECHA_REGISTRO"];
                    camb.RESPONSABLE = (string)reader["RESPONSABLE"];
                    camb.ID_CAMB = (int)reader["ID_CAMB"];
                      
                    lista.Add(camb);
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

        public string Insertar_Incidencia_Avanzada(e_Cambio_adv obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string insert = string.Format("INSERT INTO ST_CAMBIOS_ADV_INPUT (CANAL,FECHA_REGISTRO,NRO_OC ,PARTNUMB_1 ,CANT_PARTNUMB_1,PARTNUMB_2,CANT_PARTNUMB_2, OBSERVACIONES, RESPONSABLE) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                     obj.CANAL,obj.FECHA_REGISTRO,obj.NRO_OC,obj.PARTNUMB_1,obj.CANT_PARTNUMB_1,obj.PARTNUMB_2,obj.CANT_PARTNUMB_2,obj.OBSERVACIONES,obj.RESPONSABLE);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Incidencia regitrada con exito";
            }
            catch (Exception)
            {
                return "Ocurrio un error";
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
    }
}
