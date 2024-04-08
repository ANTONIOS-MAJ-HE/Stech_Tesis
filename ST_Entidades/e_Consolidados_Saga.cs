using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Consolidados_Saga
    {
        public string NRO_F12 { get; set; }
        public string NRO_OC { get; set; }
        public DateTime FECHA_EMISION_OC{ get; set; }
        public DateTime FECHA_DESPACHO_PACTADA{ get; set; }
        public string NOMBRE_COMPRADOR{ get; set; }
        public string TELEFONO_COMRPADOR{ get; set; }
        public string NOMBRE_RECEPTOR{ get; set; }
        public string DIRECCION_RECEPTOR{ get; set; }
        public string COMUNA_RECEPTOR{ get; set; }
        public string CIUDAD_RECEPTOR{ get; set; }
        public string TELEFONO_RECEPTOR{ get; set; }
        public string ATENCION{ get; set; }
        public string OBSERVACION{ get; set; }
        public string UPC{ get; set; }
        public string SKU{ get; set; }
        public string DESCRIPCION{ get; set; }
        public int UNIDADES{ get; set; }
        public double PRECIO_COSTO{ get; set; }
        public string EMAIL{ get; set; }
        public DateTime FECHA_REAPARTO_CLIENTE{ get; set; }
        public string REGION{ get; set; }
        public string DNI_COMPRADOR{ get; set; }
        public DateTime FECHA_PROCESO{ get; set; }
        public string ST_DESPACHO{ get; set; }
        public string ST_ORDEN{ get; set; }
        public DateTime FECHA_ENTREGA{ get; set; }
        public string PARTNUMB_REAL{ get; set; }
        public int UNIDADES_REAL{ get; set; }
        public string SERIE_FACT{ get; set; }
        public string NRO_FACT{ get; set; }
        public string NRO_GUIA{ get; set; }

        public string FECHA_FILTRO { get; set; }
    }
}
