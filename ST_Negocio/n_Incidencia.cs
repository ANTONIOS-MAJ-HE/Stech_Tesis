using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST_Datos;
using ST_Entidades;
using System.Data.SqlClient;

namespace ST_Negocio
{
    public class n_Incidencia
    {
        n_Buscaminis buscaminisDAOB = new n_Buscaminis();
        d_Incidencia incidenciaDAOB;

        public n_Incidencia()
        {
            incidenciaDAOB = new d_Incidencia();
        }
        public List<e_Incidencia> Listar_incidencias_filtro(string tipo, string canal, string nro_oc, string fecha_registro)
        {
            e_Incidencia incidencia = new e_Incidencia()
            {
                Tipo = tipo,
                Canal = canal,
                Nro_OC = nro_oc,
                Fecha_Registro = fecha_registro
            };
            return incidenciaDAOB.Listar_incidencias_filtro(incidencia);
        }
        public string Registrar_incidencia(string tipo,string canal ,string fecha_proceso, string nro_oc, string fecha_retorno,
                   string minicod_1, string minicod_2, string estado_dev, string observaciones, string fecha_registro, string fecha_reprogramado,string nvo_cant)
        {
            e_Incidencia incidencia = new e_Incidencia()
            {
                //Id_Incidencia = id_incidencia,
                Tipo = tipo,
                Canal = canal,
                Fecha_Proceso = fecha_proceso,
                Nro_OC = nro_oc,
                Fecha_Retorno = fecha_retorno,
                Minicod_1 = minicod_1,
                Minicod_2 = minicod_2,
                Estado_Dev = estado_dev,
                Observaciones = observaciones,
                Fecha_Registro = fecha_registro,
                Fecha_Reprogramado = fecha_reprogramado,
                Nvo_cant = nvo_cant
            };
            return incidenciaDAOB.Registrar_incidencias(incidencia);
        }
        public string Modificar_incidencia(string tipo, string canal, string nro_oc, string minicod_1, 
            string minicod_2, string estado_dev,string observaciones, string fecha_reprogramado,int id_incidencia)
        {
            e_Incidencia incidencia = new e_Incidencia()
            {
                Id_Incidencia = id_incidencia,
                Tipo = tipo,
                Canal = canal,
                //Fecha_Proceso = fecha_proceso,
                Nro_OC = nro_oc,
                //Fecha_Retorno = fecha_retorno,
                Minicod_1 = minicod_1,
                Minicod_2 = minicod_2,
                Estado_Dev = estado_dev,
                Observaciones = observaciones,
                Fecha_Reprogramado = fecha_reprogramado
                //Fecha_Registro = fecha_registro
            };
            return incidenciaDAOB.Actualizar_Consolid(incidencia);

        }
        public List<e_Incidencia> Listar_incidencias()
        {

            return incidenciaDAOB.Listar_incidencias();
        }
        public string Ingresar_a_cons ()
        {
            return incidenciaDAOB.Ingresar_a_Consolid();
        }
        public string Actualiza_Saga()
        {
            return incidenciaDAOB.Actualizar_Saga();
        }
        public string Actualiza_Ripley()
        {
            return incidenciaDAOB.Actualizar_Ripley();
        }
        public string Actualiza_Linio()
        {
            return incidenciaDAOB.Actualizar_Linio();
        }
        public string Actualiza_Real_Plaza()
        {
            return incidenciaDAOB.Actualizar_RealPlaza();
        }
        public string Actualiza_Mercado_Libre()
        {
            return incidenciaDAOB.Actulizar_Mercado_Libre();
        }
        public string Actualiza_Catphone()
        {
            return incidenciaDAOB.Actualizar_Catphone();
        }
        public string Actualiza_Lumingo()
        {
            return incidenciaDAOB.Actualizar_Lumingo();
        }
        public string Actualiza_Oficina()
        {
            return incidenciaDAOB.Actualizar_Oficina();
        }
        public string Actualiza_Juntoz()
        {
            return incidenciaDAOB.Actualizar_Juntoz();
        }
        public string Actualiza_Kingston()
        {
            return incidenciaDAOB.Actualizar_Kingston();
        }
        public string Actualiza_Coolbox()
        {
            return incidenciaDAOB.Actualizar_Coolbox();
        }
        //agregando falabela
        public string Actualiza_Falabella()
        {
            return incidenciaDAOB.Actualizar_Falabella();
        }
        //agregando conecta
        public string Actualiza_Conecta()
        {
            return incidenciaDAOB.Actualizar_Conecta();
        }

        public string Actualiza_Salidas_Kardex(string serie,string detalle,int CTD_SALIDA)
        {
            //RECOLECTA DATOS
            e_Kardex ultimaEntrada = incidenciaDAOB.Buscar_Kardex(serie);
            e_Kardex lasEntrance = incidenciaDAOB.Buscar_Kardex_2(ultimaEntrada.PARTNUMBER);
            e_Kardex obj = new e_Kardex();
            int CTDSALIDA =  ultimaEntrada.STOCK_SALIDA - (ultimaEntrada.STOCK_SALIDA*2) ;

            double solesN = ultimaEntrada.COSTO_UNI_SAL_SOL - ultimaEntrada.COSTO_UNI_SAL_SOL * 2;
            double DOLARESN = ultimaEntrada.COSTO_UNI_SAL_DOL - ultimaEntrada.COSTO_UNI_SAL_DOL * 2;
            //DATOS GENERALES
            obj.TIPO = "SAL";
            obj.FECHA_FACTURA = ultimaEntrada.FECHA_FACTURA;
            obj.TC_FECHA_FACT = ultimaEntrada.TC_FECHA_FACT;
            obj.PARTNUMBER = ultimaEntrada.PARTNUMBER;
            obj.NUMERO_ORDEN_FACT = serie;
            obj.DETALLE = detalle;
            obj.STOCK_INICIAL = ultimaEntrada.STOCK_FINAL;
            obj.MONEDA = ultimaEntrada.MONEDA;
            obj.COSTO_UNI_DOL_STOCK_INI = ultimaEntrada.COSTO_UNI_DOL_STOCK_INI;
            obj.COSTO_UNI_SOL_SOTCK_INI = ultimaEntrada.COSTO_UNI_SOL_SOTCK_INI;
            obj.MONTO_TOTAL_DOL_INI = ultimaEntrada.MONTO_TOTAL_DOL_INI;
            obj.MONTO_TOTAL_SOL_INI = ultimaEntrada.MONTO_TOTAL_SOL_INI;
            //DATOS DE LA ENTRADA
            obj.STOCK_ENTRADA = 0;
            obj.COSTO_UNI_ENT_DOL = 0;
            obj.COSTO_UNI_ENT_SOL = 0;
            obj.MONTO_ENT_DOL = 0;
            obj.MONTO_ENT_SOL = 0;
            //DATOS DE  SALIDA
            obj.STOCK_SALIDA = CTDSALIDA;
            obj.COSTO_UNI_SAL_DOL = DOLARESN;
            obj.COSTO_UNI_SAL_SOL = solesN;
            obj.MONTO_SAL_DOL = CTDSALIDA* DOLARESN;
            obj.MONTO_SAL_SOL = CTDSALIDA* solesN;
            //CALCULA PONDERADO

            //DATOS PONDERADOS
            obj.STOCK_FINAL = lasEntrance.STOCK_FINAL - CTDSALIDA;
            obj.COSTO_UNI_PON_DOL = ultimaEntrada.COSTO_UNI_PON_DOL;
            obj.COSTO_UNI_PON_SOL = ultimaEntrada.COSTO_UNI_PON_SOL;
            obj.MONTO_DOL_TOTAL_FINAL = (lasEntrance.STOCK_FINAL - CTD_SALIDA)<0? 0:lasEntrance.COSTO_UNI_PON_DOL * (ultimaEntrada.STOCK_FINAL - CTD_SALIDA);
            obj.MONTO_SOL_TOTAL_FINAL = (lasEntrance.STOCK_FINAL - CTD_SALIDA) < 0 ? 0 : lasEntrance.COSTO_UNI_PON_SOL * (lasEntrance.STOCK_FINAL - CTDSALIDA);

            obj.PRECIO_VENTA_SOLES = 0;
            obj.PRECIO_VENTA_DOLARES = 0;

            return incidenciaDAOB.Actualizar_Kardex_Ent(obj);
        }
        public string Actualiza_Salidas_Kardex(string serie,  string detalle)
        {
            //RECOLECTA DATOS
            e_Kardex ultimaEntrada = incidenciaDAOB.Buscar_Kardex(serie);
            e_Kardex obj = new e_Kardex();

            int CTDSALIDA = ultimaEntrada.STOCK_FINAL - ultimaEntrada.STOCK_FINAL * 2;
            double solesN = ultimaEntrada.COSTO_UNI_SAL_SOL - ultimaEntrada.COSTO_UNI_SAL_SOL * 2;
            double DOLARESN = ultimaEntrada.COSTO_UNI_SAL_DOL - ultimaEntrada.COSTO_UNI_SAL_DOL * 2;
            //DATOS GENERALES
            obj.TIPO = "ENT";
            obj.FECHA_FACTURA = ultimaEntrada.FECHA_FACTURA;
            obj.TC_FECHA_FACT = ultimaEntrada.TC_FECHA_FACT;
            obj.PARTNUMBER = ultimaEntrada.PARTNUMBER;
            obj.NUMERO_ORDEN_FACT = serie;
            obj.DETALLE = detalle;
            obj.STOCK_INICIAL = ultimaEntrada.STOCK_FINAL;
            obj.MONEDA = ultimaEntrada.MONEDA;
            obj.COSTO_UNI_DOL_STOCK_INI = ultimaEntrada.COSTO_UNI_DOL_STOCK_INI;
            obj.COSTO_UNI_SOL_SOTCK_INI = ultimaEntrada.COSTO_UNI_SOL_SOTCK_INI;
            obj.MONTO_TOTAL_DOL_INI = ultimaEntrada.MONTO_TOTAL_DOL_INI;
            obj.MONTO_TOTAL_SOL_INI = ultimaEntrada.MONTO_TOTAL_SOL_INI;
            //DATOS DE LA ENTRADA
            obj.STOCK_ENTRADA = 0;
            obj.COSTO_UNI_ENT_DOL = 0;
            obj.COSTO_UNI_ENT_SOL = 0;
            obj.MONTO_ENT_DOL = 0;
            obj.MONTO_ENT_SOL = 0;
            //DATOS DE  SALIDA
            obj.STOCK_SALIDA = CTDSALIDA;
            obj.COSTO_UNI_SAL_DOL = DOLARESN;
            obj.COSTO_UNI_SAL_SOL = solesN;
            obj.MONTO_SAL_DOL = CTDSALIDA * DOLARESN;
            obj.MONTO_SAL_SOL = CTDSALIDA * solesN; ;
            //CALCULA PONDERADO
            double ponderado_DOL = ultimaEntrada.MONTO_DOL_TOTAL_FINAL + CTDSALIDA * DOLARESN;
            double ponderado_SOL = ultimaEntrada.MONTO_SOL_TOTAL_FINAL + CTDSALIDA * solesN;
            //DATOS PONDERADOS
            obj.STOCK_FINAL = ultimaEntrada.STOCK_FINAL + CTDSALIDA;
            obj.COSTO_UNI_PON_DOL =  ultimaEntrada.COSTO_UNI_PON_DOL;
            obj.COSTO_UNI_PON_SOL =  ultimaEntrada.COSTO_UNI_PON_SOL;
            obj.MONTO_DOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTDSALIDA) < 0 ? 0 : ponderado_DOL * CTDSALIDA;
            obj.MONTO_SOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTDSALIDA) < 0 ? 0 : ponderado_SOL * CTDSALIDA;

            obj.PRECIO_VENTA_SOLES = 0;
            obj.PRECIO_VENTA_DOLARES = 0;
            return incidenciaDAOB.Actualizar_Kardex_Ent(obj);
        }
        public string Actualiza_Salida_Kardex(string serie, string t_partnumber, string detalle)
        {

            //RECOLECTA DATOS
            e_Kardex ultimaEntrada = incidenciaDAOB.Buscar_Kardex(serie);
            string partnumber = buscaminisDAOB.Mostrar_Partnumb(t_partnumber);
            e_Kardex Lobj = new e_Kardex();
            e_Kardex obj = new e_Kardex();

            int CTDSALIDA = ultimaEntrada.STOCK_SALIDA;
            double solesN = ultimaEntrada.COSTO_UNI_SAL_SOL - ultimaEntrada.COSTO_UNI_SAL_SOL * 2;
            double DOLARESN = ultimaEntrada.COSTO_UNI_SAL_DOL - ultimaEntrada.COSTO_UNI_SAL_DOL * 2;
            //GENERA LA SALIDA NEGATIVA DEL ANTERIOR PRODUCTO
            //DATOS GENERALES
            Lobj.TIPO = "ENT";
            Lobj.FECHA_FACTURA = ultimaEntrada.FECHA_FACTURA;
            Lobj.TC_FECHA_FACT = ultimaEntrada.TC_FECHA_FACT;
            Lobj.PARTNUMBER = ultimaEntrada.PARTNUMBER;
            Lobj.NUMERO_ORDEN_FACT = serie;
            Lobj.DETALLE = detalle;
            Lobj.STOCK_INICIAL = ultimaEntrada.STOCK_FINAL;
            Lobj.MONEDA = ultimaEntrada.MONEDA;
            Lobj.COSTO_UNI_DOL_STOCK_INI = ultimaEntrada.COSTO_UNI_DOL_STOCK_INI;
            Lobj.COSTO_UNI_SOL_SOTCK_INI = ultimaEntrada.COSTO_UNI_SOL_SOTCK_INI;
            Lobj.MONTO_TOTAL_DOL_INI = ultimaEntrada.MONTO_TOTAL_DOL_INI;
            Lobj.MONTO_TOTAL_SOL_INI = ultimaEntrada.MONTO_TOTAL_SOL_INI;
            //DATOS DE LA ENTRADA
            Lobj.STOCK_ENTRADA = 0;
            Lobj.COSTO_UNI_ENT_DOL = 0;
            Lobj.COSTO_UNI_ENT_SOL = 0;
            Lobj.MONTO_ENT_DOL = 0;
            Lobj.MONTO_ENT_SOL = 0;
            //DATOS DE  SALIDA
            Lobj.STOCK_SALIDA = CTDSALIDA;
            Lobj.COSTO_UNI_SAL_DOL = ultimaEntrada.COSTO_UNI_SAL_DOL;
            Lobj.COSTO_UNI_SAL_SOL = ultimaEntrada.COSTO_UNI_SAL_SOL;
            Lobj.MONTO_SAL_DOL = CTDSALIDA * ultimaEntrada.MONTO_SAL_DOL;
            Lobj.MONTO_SAL_SOL = CTDSALIDA * ultimaEntrada.MONTO_SAL_SOL;
            //CALCULA PONDERADO
            double ponderado_DOL_L = ultimaEntrada.MONTO_DOL_TOTAL_FINAL + (CTDSALIDA * ultimaEntrada.MONTO_SAL_DOL) / (ultimaEntrada.STOCK_FINAL + CTDSALIDA);
            double ponderado_SOL_L = ultimaEntrada.MONTO_SOL_TOTAL_FINAL + (CTDSALIDA * ultimaEntrada.MONTO_SAL_SOL) / (ultimaEntrada.STOCK_FINAL + CTDSALIDA);
            //DATOS PONDERADOS
            Lobj.STOCK_FINAL = ultimaEntrada.STOCK_FINAL + CTDSALIDA;
            Lobj.COSTO_UNI_PON_DOL = ultimaEntrada.COSTO_UNI_PON_DOL;
            Lobj.COSTO_UNI_PON_SOL = ultimaEntrada.COSTO_UNI_PON_SOL;
            Lobj.MONTO_DOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTDSALIDA) < 0 ? 0 : ponderado_DOL_L * CTDSALIDA;
            Lobj.MONTO_SOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTDSALIDA) < 0 ? 0 : ponderado_SOL_L * CTDSALIDA;

            Lobj.PRECIO_VENTA_SOLES = 0;

            incidenciaDAOB.Actualizar_Kardex_Ent(Lobj);

            //GENERA LA SALIDA DEL NUEVO PRODUCTO
            //DATOS GENERALES
            obj.TIPO = "ENT";
            obj.FECHA_FACTURA = ultimaEntrada.FECHA_FACTURA;
            obj.TC_FECHA_FACT = ultimaEntrada.TC_FECHA_FACT;
            obj.PARTNUMBER = partnumber;
            obj.NUMERO_ORDEN_FACT = serie;
            obj.DETALLE = detalle;
            obj.STOCK_INICIAL = ultimaEntrada.STOCK_FINAL;
            obj.MONEDA = ultimaEntrada.MONEDA;
            obj.COSTO_UNI_DOL_STOCK_INI = ultimaEntrada.COSTO_UNI_DOL_STOCK_INI;
            obj.COSTO_UNI_SOL_SOTCK_INI = ultimaEntrada.COSTO_UNI_SOL_SOTCK_INI;
            obj.MONTO_TOTAL_DOL_INI = ultimaEntrada.MONTO_TOTAL_DOL_INI;
            obj.MONTO_TOTAL_SOL_INI = ultimaEntrada.MONTO_TOTAL_SOL_INI;
            //DATOS DE LA ENTRADA
            obj.STOCK_ENTRADA = 0;
            obj.COSTO_UNI_ENT_DOL = 0;
            obj.COSTO_UNI_ENT_SOL = 0;
            obj.MONTO_ENT_DOL = 0;
            obj.MONTO_ENT_SOL = 0;
            //DATOS DE  SALIDA
            obj.STOCK_SALIDA = CTDSALIDA;
            obj.COSTO_UNI_SAL_DOL = ultimaEntrada.COSTO_UNI_SAL_DOL;
            obj.COSTO_UNI_SAL_SOL = ultimaEntrada.COSTO_UNI_SAL_SOL;
            obj.MONTO_SAL_DOL = CTDSALIDA * ultimaEntrada.MONTO_SAL_DOL;
            obj.MONTO_SAL_SOL = CTDSALIDA * ultimaEntrada.MONTO_SAL_SOL;
            //CALCULA PONDERADO
            double ponderado_DOL = ultimaEntrada.MONTO_DOL_TOTAL_FINAL + (CTDSALIDA * ultimaEntrada.MONTO_SAL_DOL) / (ultimaEntrada.STOCK_FINAL + CTDSALIDA);
            double ponderado_SOL = ultimaEntrada.MONTO_SOL_TOTAL_FINAL + (CTDSALIDA * ultimaEntrada.MONTO_SAL_SOL) / (ultimaEntrada.STOCK_FINAL + CTDSALIDA);
            //DATOS PONDERADOS
            obj.STOCK_FINAL = ultimaEntrada.STOCK_FINAL + CTDSALIDA;
            obj.COSTO_UNI_PON_DOL = ultimaEntrada.COSTO_UNI_PON_DOL;
            obj.COSTO_UNI_PON_SOL = ultimaEntrada.COSTO_UNI_PON_SOL;
            obj.MONTO_DOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTDSALIDA) < 0 ? 0 : ponderado_DOL * CTDSALIDA;
            obj.MONTO_SOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTDSALIDA) < 0 ? 0 : ponderado_SOL * CTDSALIDA;

            obj.PRECIO_VENTA_SOLES = 0;
            obj.PRECIO_VENTA_DOLARES = 0;
            return incidenciaDAOB.Actualizar_Kardex_Ent(obj);
        }
        public string Actualiza_Entradas_Kardex(string serie, string partnumber, string detalle)
        {
            //RECOLECTA DATOS
            e_Kardex ultimaEntrada = incidenciaDAOB.Buscar_Kardex(serie);
            e_Kardex obj = new e_Kardex();

            int CTDSALIDA = ultimaEntrada.STOCK_FINAL;
            double solesN = ultimaEntrada.COSTO_UNI_SAL_SOL;
            double DOLARESN = ultimaEntrada.COSTO_UNI_SAL_DOL;
            //DATOS GENERALES
            obj.TIPO = "ENT";
            obj.FECHA_FACTURA = ultimaEntrada.FECHA_FACTURA;
            obj.TC_FECHA_FACT = ultimaEntrada.TC_FECHA_FACT;
            obj.PARTNUMBER = partnumber;
            obj.NUMERO_ORDEN_FACT = serie;
            obj.DETALLE = detalle;
            obj.STOCK_INICIAL = ultimaEntrada.STOCK_FINAL;
            obj.MONEDA = ultimaEntrada.MONEDA;
            obj.COSTO_UNI_DOL_STOCK_INI = ultimaEntrada.COSTO_UNI_DOL_STOCK_INI;
            obj.COSTO_UNI_SOL_SOTCK_INI = ultimaEntrada.COSTO_UNI_SOL_SOTCK_INI;
            obj.MONTO_TOTAL_DOL_INI = ultimaEntrada.MONTO_TOTAL_DOL_INI;
            obj.MONTO_TOTAL_SOL_INI = ultimaEntrada.MONTO_TOTAL_SOL_INI;
            //DATOS DE LA ENTRADA
            obj.STOCK_ENTRADA = 0;
            obj.COSTO_UNI_ENT_DOL = 0;
            obj.COSTO_UNI_ENT_SOL = 0;
            obj.MONTO_ENT_DOL = 0;
            obj.MONTO_ENT_SOL = 0;
            //DATOS DE  SALIDA
            obj.STOCK_SALIDA = CTDSALIDA;
            obj.COSTO_UNI_SAL_DOL = ultimaEntrada.COSTO_UNI_SAL_DOL;
            obj.COSTO_UNI_SAL_SOL = ultimaEntrada.COSTO_UNI_SAL_SOL;
            obj.MONTO_SAL_DOL = CTDSALIDA * ultimaEntrada.MONTO_SAL_DOL;
            obj.MONTO_SAL_SOL = CTDSALIDA * ultimaEntrada.MONTO_SAL_SOL;
            //CALCULA PONDERADO
            double ponderado_DOL = ultimaEntrada.MONTO_DOL_TOTAL_FINAL + (CTDSALIDA * ultimaEntrada.MONTO_SAL_DOL) / (ultimaEntrada.STOCK_FINAL + CTDSALIDA);
            double ponderado_SOL = ultimaEntrada.MONTO_SOL_TOTAL_FINAL + (CTDSALIDA * ultimaEntrada.MONTO_SAL_SOL) / (ultimaEntrada.STOCK_FINAL + CTDSALIDA);
            //DATOS PONDERADOS
            obj.STOCK_FINAL = ultimaEntrada.STOCK_FINAL + CTDSALIDA;
            obj.COSTO_UNI_PON_DOL = ultimaEntrada.COSTO_UNI_PON_DOL;
            obj.COSTO_UNI_PON_SOL = ultimaEntrada.COSTO_UNI_PON_SOL;
            obj.MONTO_DOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTDSALIDA) < 0 ? 0 : ponderado_DOL * CTDSALIDA;
            obj.MONTO_SOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTDSALIDA) < 0 ? 0 : ponderado_SOL * CTDSALIDA;

            obj.PRECIO_VENTA_SOLES = 0;
            obj.PRECIO_VENTA_DOLARES = 0;
            return incidenciaDAOB.Actualizar_Kardex_Ent(obj);
        }
        public string Actualiza_MSalidas_Kardex(string serie, string detalle, int CTD_SALIDA)
        {
            //RECOLECTA DATOS
            e_Kardex ultimaEntrada = incidenciaDAOB.Buscar_Kardex(serie);
            e_Kardex obj = new e_Kardex();
            int CTDSALIDA = CTD_SALIDA>ultimaEntrada.STOCK_SALIDA? CTD_SALIDA-ultimaEntrada.STOCK_SALIDA:ultimaEntrada.STOCK_SALIDA-CTD_SALIDA;
            double solesN = ultimaEntrada.COSTO_UNI_SAL_SOL - ultimaEntrada.COSTO_UNI_SAL_SOL * 2;
            double DOLARESN = ultimaEntrada.COSTO_UNI_SAL_DOL - ultimaEntrada.COSTO_UNI_SAL_DOL * 2;
            //DATOS GENERALES
            obj.TIPO = "ENT";
            obj.FECHA_FACTURA = ultimaEntrada.FECHA_FACTURA;
            obj.TC_FECHA_FACT = ultimaEntrada.TC_FECHA_FACT;
            obj.PARTNUMBER = ultimaEntrada.PARTNUMBER;
            obj.NUMERO_ORDEN_FACT = serie;
            obj.DETALLE = detalle;
            obj.STOCK_INICIAL = ultimaEntrada.STOCK_FINAL;
            obj.MONEDA = ultimaEntrada.MONEDA;
            obj.COSTO_UNI_DOL_STOCK_INI = ultimaEntrada.COSTO_UNI_DOL_STOCK_INI;
            obj.COSTO_UNI_SOL_SOTCK_INI = ultimaEntrada.COSTO_UNI_SOL_SOTCK_INI;
            obj.MONTO_TOTAL_DOL_INI = ultimaEntrada.MONTO_TOTAL_DOL_INI;
            obj.MONTO_TOTAL_SOL_INI = ultimaEntrada.MONTO_TOTAL_SOL_INI;
            //DATOS DE LA ENTRADA
            obj.STOCK_ENTRADA = 0;
            obj.COSTO_UNI_ENT_DOL = 0;
            obj.COSTO_UNI_ENT_SOL = 0;
            obj.MONTO_ENT_DOL = 0;
            obj.MONTO_ENT_SOL = 0;
            //DATOS DE  SALIDA
            obj.STOCK_SALIDA = CTDSALIDA;
            obj.COSTO_UNI_SAL_DOL = ultimaEntrada.COSTO_UNI_SAL_DOL;
            obj.COSTO_UNI_SAL_SOL = ultimaEntrada.COSTO_UNI_SAL_SOL;
            obj.MONTO_SAL_DOL = CTDSALIDA * ultimaEntrada.MONTO_SAL_DOL;
            obj.MONTO_SAL_SOL = CTDSALIDA * ultimaEntrada.MONTO_SAL_SOL;
            //CALCULA PONDERADO
            double ponderado_DOL = ultimaEntrada.MONTO_DOL_TOTAL_FINAL + (CTDSALIDA * ultimaEntrada.MONTO_SAL_DOL) / (ultimaEntrada.STOCK_FINAL + CTDSALIDA);
            double ponderado_SOL = ultimaEntrada.MONTO_SOL_TOTAL_FINAL + (CTDSALIDA * ultimaEntrada.MONTO_SAL_SOL) / (ultimaEntrada.STOCK_FINAL + CTDSALIDA);
            //DATOS PONDERADOS
            obj.STOCK_FINAL = ultimaEntrada.STOCK_FINAL + CTDSALIDA;
            obj.COSTO_UNI_PON_DOL = ultimaEntrada.COSTO_UNI_PON_DOL;
            obj.COSTO_UNI_PON_SOL = ultimaEntrada.COSTO_UNI_PON_SOL;
            obj.MONTO_DOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTD_SALIDA) < 0 ? 0 : ponderado_DOL * CTDSALIDA;
            obj.MONTO_SOL_TOTAL_FINAL = (ultimaEntrada.STOCK_FINAL - CTD_SALIDA) < 0 ? 0 : ponderado_SOL * CTDSALIDA;

            obj.PRECIO_VENTA_SOLES = 0;
            obj.PRECIO_VENTA_DOLARES = 0;
            return incidenciaDAOB.Actualizar_Kardex_Ent(obj);
        }
    }
}
