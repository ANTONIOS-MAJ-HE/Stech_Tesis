using System;
using System.Collections.Generic;
using System.Text;
using ST_Datos;
using ST_Entidades;

namespace ST_Negocio
{
    public class n_Entradas
    {
        d_Entradas entradasDAOB;
        public n_Entradas ()
        {
            entradasDAOB = new d_Entradas();
        }


        public List<e_Entradas> Lista_entradas()
        {
            return entradasDAOB.Lista_Entradas();
        }

        public List<e_Entradas> Lista_entradas_filtro(string Nro_Fact, string RUC_Proveedor, string Proveedor, string Producto, string Marca )
        {
            e_Entradas entrada = new e_Entradas()
            {
                Nro_Fact = Nro_Fact,
                RUC_Proveedor = RUC_Proveedor,
                Proveedor = Proveedor,
                Producto = Producto,
                Marca = Marca
            };


            return entradasDAOB.Lista_Entradas_filtro(entrada);
        }
        public string Registra_Entradas(string Tipo, string Fecha_Entrada, string Serie_Fact, string Nro_Fact, string MiniCodigo, int Cantidad, string Moneda, decimal Precio_Unitario, string RUC_Proveedor,
                    string Proveedor, string Origen, string Responsable, string Observaciones, string Fecha_factura, string Fecha_guia)
        {
            e_Entradas entrada = new e_Entradas()
            {
                Tipo = Tipo,
                Fecha_Entrada = Fecha_Entrada,
                Serie_Fact = Serie_Fact,
                Nro_Fact = Nro_Fact,
                MiniCodigo = MiniCodigo,
                Cantidad = Cantidad,
                Moneda = Moneda,
                Precio_Unitario = Precio_Unitario,
                RUC_Proveedor = RUC_Proveedor,
                Proveedor = Proveedor,
                Origen = Origen,
                Responsable = Responsable,
                Observaciones = Observaciones,
                Fecha_factura = Fecha_factura,
                Fecha_guia = Fecha_guia

            };
            return entradasDAOB.Registrar_Entradas(entrada);
        }
        public string Ingresa_Cons()
        {
            return entradasDAOB.Ingresar_Cons();
        }
        public string  Modifica_Cons(string Tipo, string Serie_Fact, string Nro_Fact, string MiniCodigo, int Cantidad, string Moneda, decimal Precio_Unitario,
                    string RUC_Proveedor, string Proveedor, string Origen, string Observaciones, int Id_Entrada)
        {
            e_Entradas entrada = new e_Entradas()
            {
                Tipo = Tipo,
                //Fecha_Entrada = Fecha_Entrada,
                Serie_Fact = Serie_Fact,
                Nro_Fact = Nro_Fact,
                MiniCodigo = MiniCodigo,
                Cantidad = Cantidad,
                Moneda = Moneda,
                Precio_Unitario = Precio_Unitario,
                RUC_Proveedor = RUC_Proveedor,
                Proveedor = Proveedor,
                Origen = Origen,
                // Responsable = Responsable,
                Observaciones = Observaciones,
                // Fecha_factura = Fecha_factura,
                // Fecha_guia = Fecha_guia
                Id_Entrada = Id_Entrada
            };
            return entradasDAOB.Modificar_Cons(entrada);
          
        }

        public List<e_Proveedor>Lista_proveedores(string proveeedor)
        {
            e_Proveedor prov = new e_Proveedor()
            {
                Proveedor = proveeedor
            };
            return entradasDAOB.Lista_proveedores(prov);
        }
        public List<e_TotalFact>Lista_total(string factura)
        {
            e_TotalFact fact = new e_TotalFact()
            {
                Factura = factura
            };
            return entradasDAOB.Lista_fact(fact);
        }
        public string Actualizar_precios()
        {
            return entradasDAOB.Modificar_costos();
        }

        public string Actualiza_Kardex(string partnumber, DateTime fecha_factura, double tipo_cambio, string Moneda, int CTDENTRADA,
            double precio,string serie,string detalle,int tipo)
        {
            //RECOLECTA DATOS
            e_Kardex ultimaEntrada = entradasDAOB.Buscar_Kardex(partnumber);
            e_Kardex obj = new e_Kardex();
            bool caso;

            if (detalle== "TRASLADO")
            {
                precio = ultimaEntrada.COSTO_UNI_PON_DOL;
                Moneda = "USD";
            }

            if (tipo == 0)
            {
                caso = true;
            }
            else
            {
                caso = false;
            }
            double soles = Moneda == "PEN" ? precio : precio * tipo_cambio;
            double dolares = Moneda == "USD" ? precio : precio / tipo_cambio;
            double solesN= soles - soles*2;
            double DOLARESN = dolares - dolares * 2;
            int CTD_ENTRADA = caso==true?CTDENTRADA - CTDENTRADA * 2: CTDENTRADA;
            //DATOS GENERALES
            obj.TIPO = "ENT";
            obj.FECHA_FACTURA = fecha_factura.ToString("yyyy-MM-dd");
            obj.TC_FECHA_FACT = tipo_cambio;
            obj.PARTNUMBER = partnumber;
            obj.NUMERO_ORDEN_FACT = serie;
            obj.DETALLE = detalle;
            obj.STOCK_INICIAL = ultimaEntrada.STOCK_FINAL;
            obj.MONEDA = Moneda;
            obj.COSTO_UNI_DOL_STOCK_INI = ultimaEntrada.COSTO_UNI_PON_DOL;
            obj.COSTO_UNI_SOL_SOTCK_INI = ultimaEntrada.COSTO_UNI_PON_SOL;
            obj.MONTO_TOTAL_DOL_INI = ultimaEntrada.COSTO_UNI_PON_DOL* ultimaEntrada.STOCK_FINAL;
            obj.MONTO_TOTAL_SOL_INI = ultimaEntrada.COSTO_UNI_PON_SOL * ultimaEntrada.STOCK_FINAL;
            //DATOS DE LA ENTRADA
            obj.STOCK_ENTRADA = CTD_ENTRADA;
            obj.COSTO_UNI_ENT_DOL = caso == true ? DOLARESN : dolares;
            obj.COSTO_UNI_ENT_SOL = caso == true ? solesN : soles;
            obj.MONTO_ENT_DOL = caso == true ? DOLARESN * CTD_ENTRADA: dolares * CTD_ENTRADA;
            obj.MONTO_ENT_SOL = caso == true ? solesN * CTD_ENTRADA : soles * CTD_ENTRADA;
            //DATOS DE  SALIDA
            obj.STOCK_SALIDA = 0;
            obj.COSTO_UNI_SAL_DOL = 0;
            obj.COSTO_UNI_SAL_SOL = 0;
            obj.MONTO_SAL_DOL = 0;
            obj.MONTO_SAL_SOL = 0;
            //CALCULA PONDERADO
            double ponderado_DOL = caso == true ? (ultimaEntrada.MONTO_DOL_TOTAL_FINAL + (DOLARESN * CTD_ENTRADA))/(ultimaEntrada.STOCK_FINAL + CTD_ENTRADA) :
                (ultimaEntrada.MONTO_DOL_TOTAL_FINAL + (dolares * CTD_ENTRADA)) / (ultimaEntrada.STOCK_FINAL + CTD_ENTRADA);
            //DATOS PONDERADOS
            obj.STOCK_FINAL = ultimaEntrada.STOCK_FINAL+CTD_ENTRADA;
            obj.COSTO_UNI_PON_DOL = ultimaEntrada.STOCK_FINAL<0? dolares : ponderado_DOL;
            obj.COSTO_UNI_PON_SOL = ultimaEntrada.STOCK_FINAL < 0 ? soles : ponderado_DOL * tipo_cambio;
            obj.MONTO_DOL_TOTAL_FINAL = ponderado_DOL * (ultimaEntrada.STOCK_FINAL + CTD_ENTRADA);
            obj.MONTO_SOL_TOTAL_FINAL = (ponderado_DOL * (ultimaEntrada.STOCK_FINAL + CTD_ENTRADA)) * tipo_cambio;

            obj.PRECIO_VENTA_SOLES = 0;
            obj.PRECIO_VENTA_DOLARES = 0;

            return entradasDAOB.Actualizar_kardex(obj);
        }
        public string Ultima_Entrada()
        {
            return entradasDAOB.Get_Last_ID();
        }
    }
}
