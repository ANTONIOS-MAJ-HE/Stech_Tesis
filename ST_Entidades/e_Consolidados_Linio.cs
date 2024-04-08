using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Consolidados_Linio
    {
        public string ORDER_ITEM_ID{ get; set; } 
        public string LINIO_ID{ get; set; }
        public string SELLER_SKU{ get; set; }
        public string LINIO_SKU{ get; set; }
        public DateTime CREATED_AT{ get; set; }
        public string ORDER_NUMBER{ get; set; }
        public string CUSTOMER_NAME{ get; set; }
        public string CUSTOMER_EMAIL{ get; set; }
        public string SHIPPING_NAME{ get; set; }
        public string SHIPPING_ADDRESS{ get; set; }
        public string SHIPPING_CITY{ get; set; }
        public double PAID_PRICE{ get; set; }
        public double UNIT_PRICE { get; set; }
        public double SHIPPING_FEE { get; set; }
        public string ITEM_NAME{ get; set; }
        public string STATUS{ get; set; }
        public DateTime FECHA_PROCESO{ get; set; }
        public string ST_DESPACHO{ get; set; }
        public string ST_ORDEN{ get; set; }
        public string PART_NUMB_REAL{ get; set; }
        public int UNIDADES_REAL{ get; set; }
        public string FECHA_FILTRO { get; set; }
    }
}
