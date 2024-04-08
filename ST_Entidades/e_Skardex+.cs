using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Skardex_
    {
        public int ID_KARDEX { get; set; }
        public string TIPO { get; set; }
        public DateTime FECHA_PROCESO { get; set; }
        public double TC_FECHA_FACT { get; set; }
        public string PARTNUMBER { get; set; }
        public string DETALLE { get; set; }
        public int STOCK_ENTRADA { get; set; }
        public double COSTO_UNI_ENT_DOL { get; set; }
        public double COSTO_UNI_ENT_SOL { get; set; }
        public double MONTO_ENT_DOL { get; set; }
        public double MONTO_ENT_SOL { get; set; }
        public int STOCK_SALIDA { get; set; }
        public double COSTO_UNI_SAL_DOL { get; set; }
        public double COSTO_UNI_SAL_SOL { get; set; }
        public double MONTO_SAL_DOL { get; set; }
        public double MONTO_SAL_SOL { get; set; }
        public int STOCK_FINAL { get; set; }
        public double COSTO_UNI_PON_DOL { get; set; }
        public double COSTO_UNI_PON_SOL { get; set; }
        public double MONTO_DOL_TOTAL_FINAL { get; set; }
        public double MONTO_SOL_TOTAL_FINAL { get; set; }
    }
}
