using System;
using System.Collections.Generic;
using System.Text;
using ST_Entidades;
using ST_Datos;

namespace ST_Negocio
{
   public class n_Salida
    {
        d_Salida salidaDAOB;
        public n_Salida ()
        {
            salidaDAOB = new d_Salida();
        }
        public List<e_Salida>ListaSalidas()
        {
            return salidaDAOB.Lista_salidas();
        }
        public List<e_Salida> ListaSalidasxFILTRO(string TIPO, string NRO_ORDEN, string CANAL, string MINICODIGO, string FECHA_SALIDA, string NRO_PEDIDO)
        {
            e_Salida salida = new e_Salida()
            {
                TIPO= TIPO,
                NRO_ORDEN = NRO_ORDEN,
                CANAL = CANAL,
                MINICODIGO = MINICODIGO,
                FECHA_SALIDA = FECHA_SALIDA,
                NRO_PEDIDO = NRO_PEDIDO
            };


            return salidaDAOB.Lista_salidas_x_filtro(salida);
        }
        public List<e_Salida> Listaultorden()
        {
            return salidaDAOB.Get_last_orden();
        }
        public string Registrar_salida(string TIPO, string NRO_ORDEN, string FECHA_SALIDA, string RESPONSABLE, string TIPO_COMPROBANTE, string SERIE_COMPROBANTE, string NRO_COMPROBANTE, string CANAL,
                    string MINICODIGO, string TIPO_PAGO, string BANCO, string NRO_OPERACION, string CANTIDAD, string MONEDA, string PRECIO_UNIT_S_IGV, string ORIGEN, string DIR_DESTINO,
                    string OBSERVACIONES, string NOM_CLI, string DNI_CLI, string TEL_CLI, string NOM_DELIV, string KM, string TARIFA_ST, string TARIFA_DELIV, string TARIFA_OLVA,
                    string PAGO_ONLINE, string TRANSFERENCIA, string EFECTIVO, string NRO_PEDIDO)
        {
            e_Salida salida = new e_Salida()
            {
                TIPO = TIPO,
                NRO_ORDEN = NRO_ORDEN,
                FECHA_SALIDA = FECHA_SALIDA,
                RESPONSABLE = RESPONSABLE,
                TIPO_COMPROBANTE = TIPO_COMPROBANTE,
                SERIE_COMPROBANTE = SERIE_COMPROBANTE,
                NRO_COMPROBANTE = NRO_COMPROBANTE,
                CANAL = CANAL,
                MINICODIGO = MINICODIGO,
                TIPO_PAGO = TIPO_PAGO,
                BANCO = BANCO,
                NRO_OPERACION = NRO_OPERACION,
                CANTIDAD = CANTIDAD,
                MONEDA = MONEDA,
                PRECIO_UNIT_S_IGV = PRECIO_UNIT_S_IGV,
                ORIGEN = ORIGEN,
                DIR_DESTINO = DIR_DESTINO,
                OBSERVACIONES = OBSERVACIONES,
                NOM_CLI = NOM_CLI,
                DNI_CLI = DNI_CLI,
                TEL_CLI = TEL_CLI,
                NOM_DELIV = NOM_DELIV,
                KM = KM,
                TARIFA_ST = TARIFA_ST,
                TARIFA_DELIV = TARIFA_DELIV,
                TARIFA_OLVA = TARIFA_OLVA,
                PAGO_ONLINE = PAGO_ONLINE,
                TRANSFERENCIA = TRANSFERENCIA,
                EFECTIVO = EFECTIVO,
                NRO_PEDIDO = NRO_PEDIDO
            };
            return salidaDAOB.Ingresar_salida(salida);
        }
        public string Ingresar_cons()
        {
            return salidaDAOB.Ingresar_cons();
        }
        public string Modificar_salida(string TIPO, string NRO_ORDEN,  string RESPONSABLE, string TIPO_COMPROBANTE, 
            string SERIE_COMPROBANTE, string NRO_COMPROBANTE, string CANAL, string MINICODIGO, string TIPO_PAGO, string BANCO, string NRO_OPERACION, 
            string CANTIDAD, string MONEDA, string PRECIO_UNIT_S_IGV, string ORIGEN, string DIR_DESTINO, string OBSERVACIONES, string NOM_CLI, 
            string DNI_CLI, string TEL_CLI, string NOM_DELIV, string KM, string TARIFA_ST, string TARIFA_DELIV, string TARIFA_OLVA, string PAGO_ONLINE,
            string TRANSFERENCIA, string EFECTIVO, string NRO_PEDIDO,int ID_SALIDA)
        {
            e_Salida salida = new e_Salida()
            {
                ID_SALIDA = ID_SALIDA,
                TIPO = TIPO,
                NRO_ORDEN = NRO_ORDEN,
        
                RESPONSABLE = RESPONSABLE,
                TIPO_COMPROBANTE = TIPO_COMPROBANTE,
                SERIE_COMPROBANTE = SERIE_COMPROBANTE,
                NRO_COMPROBANTE = NRO_COMPROBANTE,
                CANAL = CANAL,
                MINICODIGO = MINICODIGO,
                TIPO_PAGO = TIPO_PAGO,
                BANCO = BANCO,
                NRO_OPERACION = NRO_OPERACION,
                CANTIDAD = CANTIDAD,
                MONEDA = MONEDA,
                PRECIO_UNIT_S_IGV =  PRECIO_UNIT_S_IGV,
                ORIGEN = ORIGEN,
                DIR_DESTINO = DIR_DESTINO,
                OBSERVACIONES = OBSERVACIONES,
                NOM_CLI  = NOM_CLI,
                DNI_CLI = DNI_CLI,
                TEL_CLI = TEL_CLI,
                NOM_DELIV = NOM_DELIV,
                KM = KM,
                TARIFA_ST = TARIFA_ST,
                TARIFA_DELIV = TARIFA_DELIV,
                TARIFA_OLVA= TARIFA_OLVA,
                PAGO_ONLINE = PAGO_ONLINE,
                TRANSFERENCIA = TRANSFERENCIA,
                EFECTIVO = EFECTIVO,
                NRO_PEDIDO = NRO_PEDIDO
                
            };
            return salidaDAOB.Modificar_salida(salida);

        }
        public string Ultima_Salida()
        {
            return salidaDAOB.Get_Last_ID();
        }

        public string Actualiza_Kardex(string partnumber, DateTime fecha_factura, double tipo_cambio, string Moneda, int CTDSALIDA,
    double precio, string serie, string detalle, int tipo)
        {
            //RECOLECTA DATOS
            e_Kardex ultimaEntrada = salidaDAOB.Buscar_Kardex(partnumber);
            e_Kardex obj = new e_Kardex();
            bool caso;
            if (tipo == 0 || tipo == 3)
            {
                caso = true;
            }
            else
            {
                caso = false;
            }
            int CTD_SALIDA = CTDSALIDA - CTDSALIDA * 2;
            double soles = Moneda == "PEN" ? precio : precio * tipo_cambio;
            double dolares = Moneda == "USD" ? precio : precio / tipo_cambio;
            double solesN = soles - soles * 2;
            double DOLARESN = dolares - dolares * 2;
            //DATOS GENERALES
            obj.TIPO = "SAL";
            obj.FECHA_FACTURA = fecha_factura.ToString("yyyy-MM-dd");
            obj.TC_FECHA_FACT = tipo_cambio;
            obj.PARTNUMBER = partnumber;
            obj.NUMERO_ORDEN_FACT = serie;
            obj.DETALLE = detalle;
            obj.STOCK_INICIAL = ultimaEntrada.STOCK_FINAL;
            obj.MONEDA = Moneda;
            obj.COSTO_UNI_DOL_STOCK_INI = ultimaEntrada.COSTO_UNI_DOL_STOCK_INI;
            obj.COSTO_UNI_SOL_SOTCK_INI = ultimaEntrada.COSTO_UNI_SOL_SOTCK_INI;
            obj.MONTO_TOTAL_DOL_INI = ultimaEntrada.MONTO_TOTAL_DOL_INI;
            obj.MONTO_TOTAL_SOL_INI = ultimaEntrada.MONTO_TOTAL_SOL_INI;
            //DATOS DE LA ENTRADA
            obj.STOCK_ENTRADA = CTD_SALIDA;
            obj.COSTO_UNI_ENT_DOL = caso == true ? solesN : dolares;
            obj.COSTO_UNI_ENT_SOL = caso == true ? DOLARESN : soles;
            obj.MONTO_ENT_DOL = caso == true ? DOLARESN * CTD_SALIDA : dolares * CTD_SALIDA;
            obj.MONTO_ENT_SOL = caso == true ? solesN * CTD_SALIDA : soles * CTD_SALIDA;
            //DATOS DE  SALIDA
            obj.STOCK_SALIDA = 0;
            obj.COSTO_UNI_SAL_DOL = 0;
            obj.COSTO_UNI_SAL_SOL = 0;
            obj.MONTO_SAL_DOL = 0;
            obj.MONTO_SAL_SOL = 0;
            //CALCULA PONDERADO
            double ponderado_DOL = caso == true ? (ultimaEntrada.MONTO_DOL_TOTAL_FINAL + DOLARESN * CTD_SALIDA) / (ultimaEntrada.STOCK_FINAL + CTD_SALIDA) :
                ultimaEntrada.MONTO_DOL_TOTAL_FINAL + dolares * CTD_SALIDA / (ultimaEntrada.STOCK_FINAL + CTD_SALIDA);
            double ponderado_SOL = caso == true ? ultimaEntrada.MONTO_DOL_TOTAL_FINAL + solesN * CTD_SALIDA / (ultimaEntrada.STOCK_FINAL + CTD_SALIDA) :
                ultimaEntrada.MONTO_DOL_TOTAL_FINAL + soles * CTD_SALIDA / (ultimaEntrada.STOCK_FINAL + CTD_SALIDA);
            //DATOS PONDERADOS
            obj.STOCK_FINAL = ultimaEntrada.STOCK_FINAL + CTD_SALIDA;
            obj.COSTO_UNI_PON_DOL = ponderado_DOL;
            obj.COSTO_UNI_PON_SOL = ponderado_SOL;
            obj.MONTO_DOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL-CTDSALIDA) < 0 ? 0:ponderado_DOL * CTD_SALIDA;
            obj.MONTO_SOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTDSALIDA) < 0 ? 0:ponderado_SOL * CTD_SALIDA;

            obj.PRECIO_VENTA_SOLES = 0;

            return salidaDAOB.Actualizar_kardex(obj);
        }

        public string Actualiza_Kardex(string partnumber, DateTime fecha_factura, double tipo_cambio, string Moneda, int CTD_SALIDA,
   double precio, string serie, string detalle)
        {
            //RECOLECTA DATOS
            e_Kardex ultimaEntrada = salidaDAOB.Buscar_Kardex(partnumber);
            e_Kardex obj = new e_Kardex();
            double soles = Moneda == "PEN" ? precio : precio * tipo_cambio;
            double dolares = Moneda == "USD" ? precio : precio / tipo_cambio;
            if (Moneda == "")
            {
                dolares = ultimaEntrada.COSTO_UNI_PON_DOL;
                soles = ultimaEntrada.COSTO_UNI_PON_SOL;
            }
            else
            {
                 soles = Moneda == "PEN" ? precio : precio * tipo_cambio;
                 dolares = Moneda == "USD" ? precio : precio / tipo_cambio;
            }
            //DATOS GENERALES
            obj.TIPO = "SAL";
            obj.FECHA_FACTURA = fecha_factura.ToString("yyyy-MM-dd");
            obj.TC_FECHA_FACT = tipo_cambio;
            obj.PARTNUMBER = partnumber;
            obj.NUMERO_ORDEN_FACT = serie;
            obj.DETALLE = detalle;
            obj.STOCK_INICIAL = ultimaEntrada.STOCK_FINAL;
            obj.MONEDA = Moneda;
            obj.COSTO_UNI_DOL_STOCK_INI = ultimaEntrada.COSTO_UNI_PON_DOL;
            obj.COSTO_UNI_SOL_SOTCK_INI = ultimaEntrada.COSTO_UNI_PON_SOL;
            obj.MONTO_TOTAL_DOL_INI = ultimaEntrada.MONTO_DOL_TOTAL_FINAL;
            obj.MONTO_TOTAL_SOL_INI = ultimaEntrada.MONTO_SOL_TOTAL_FINAL;
            //DATOS DE LA ENTRADA
            obj.STOCK_ENTRADA = 0;
            obj.COSTO_UNI_ENT_DOL =  0;
            obj.COSTO_UNI_ENT_SOL =  0;
            obj.MONTO_ENT_DOL =  0 ;
            obj.MONTO_ENT_SOL =  0 ;
            //DATOS DE  SALIDA
            obj.STOCK_SALIDA = CTD_SALIDA;
            obj.COSTO_UNI_SAL_DOL = dolares;
            obj.COSTO_UNI_SAL_SOL = soles;
            obj.MONTO_SAL_DOL = dolares * CTD_SALIDA;
            obj.MONTO_SAL_SOL = soles * CTD_SALIDA;
            //DATOS PONDERADOS
            obj.STOCK_FINAL = ultimaEntrada.STOCK_FINAL - CTD_SALIDA;
            obj.COSTO_UNI_PON_DOL = ultimaEntrada.COSTO_UNI_PON_DOL;
            obj.COSTO_UNI_PON_SOL = ultimaEntrada.COSTO_UNI_PON_SOL;
            obj.MONTO_DOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTD_SALIDA) < 0 ? 0 : ultimaEntrada.COSTO_UNI_PON_DOL * (ultimaEntrada.STOCK_FINAL - CTD_SALIDA);
            obj.MONTO_SOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTD_SALIDA) < 0 ? 0 : ultimaEntrada.COSTO_UNI_PON_SOL * (ultimaEntrada.STOCK_FINAL - CTD_SALIDA);

            obj.PRECIO_VENTA_SOLES = Moneda == "PEN" ? precio*CTD_SALIDA : (precio / tipo_cambio) * CTD_SALIDA;
            obj.PRECIO_VENTA_DOLARES = Moneda == "USD" ? precio * CTD_SALIDA :( precio * tipo_cambio) * CTD_SALIDA;

            return salidaDAOB.Actualizar_kardex(obj);
        }
    }
}
