using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Consolidados_RealPlaza
    {
        public string NUMERO{ get; set; }
        public string CLIENTE{ get; set; }
        public string TELEFONO_CLIENTE{ get; set; }
        public string E_MAIL_CLIENTE{ get; set; }
        public string DIRECCION{ get; set; }
        public string DISTRITO{ get; set; }
        public string PROVINCIA{ get; set; }
        public string TIPO_DOCUMENTO{ get; set; }
        public string NUMERO_DOCUMENTO{ get; set; }
        public string RUC{ get; set; }
        public string RAZON_SOCIAL{ get; set; }
        public DateTime FECHA{ get; set; }
        public double TOTAL{ get; set; }
        public double TOTAL_ITEMS{ get; set; }
        public double COSTO_TOTAL_ENVIO{ get; set; }
        public double TOTAL_COMISION{ get; set; }
        public string ESTADO{ get; set; }
        public string SITIOS{ get; set; }
        public string SKU{ get; set; }
        public string NOMBRE_SKU{ get; set; }
        public int CANTIDAD_SKU{ get; set; }
        public double PRECIO_SKU { get; set; }
        public DateTime FECHA_PROCESO{ get; set; }
        public string ST_DESPACHO{ get; set; }
        public string ST_ORDEN{ get; set; }
        public string PARTNUMB_REAL{ get; set; }
        public int UNIDADES_REAL{ get; set; }
        public string FECHA_FILTRO { get; set; }
    }
}
