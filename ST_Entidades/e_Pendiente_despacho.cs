using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
   public class e_Pendiente_despacho
    {
        public string CANAL { get; set; }
        public string NRO_OC { get; set; }
        public string SKU { get; set; }
        public string EAN_UPC { get; set; }
        public string PRODUCTO { get; set; }
        public string MODELO { get; set; }
        public string MINI_CODIGO { get; set; }
        public string PARTNUMBER { get; set; }
        public int CANTIDAD { get; set; }
        public string FECHA_DESPACHO { get; set; }
        public int STOCK_RESTANTE { get; set; }
        public string COURIER { get; set; }
    }
}
