using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Comparativa
    {
        public int STOCK_FINAL { get; set; }
        public string PARTNUMBER { get; set; }
        public string TITULO { get; set; }
        public string PRECIO_PLANTA_USD { get; set; }
        public string PRECIO_PLANTA_PEN { get; set; }
        public string PRECIO_KARDEX_USD { get; set; }
        public DateTime FECHA_ULT_ENTRADA { get; set; }
        public string SKU_SAGA { get; set; }
        public DateTime FECHA_ULT_V_SAGA { get; set; }
        public string ULT_V_SAGA { get; set; }
        public string SKU_LINIO { get; set; }
        public string P_V_LINIO { get; set; }
        public DateTime FECHA_ULT_V_LINIO { get; set; }
        public string ULT_V_LINIO { get; set; }
        public string SKU_RIPLEY { get; set; }
        public string P_V_RIPLEY { get; set; }
        public DateTime FECHA_ULT_V_RIPLEY { get; set; }
        public string ULT_V_RIPLEY { get; set; }
        public string SKU_REALPLAZA { get; set; }
        public string P_V_REALPLAZA { get; set; }
        public DateTime FECHA_ULT_V_REALPLAZA { get; set; }
        public string ULT_V_REALPLAZA { get; set; }
    }
}
