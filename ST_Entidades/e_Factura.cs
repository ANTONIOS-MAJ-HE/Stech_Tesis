using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Factura
    {
        public string serie_documento { get; set; }
        public string numero_documento { get; set; }
        public string fecha_de_emision { get; set; }
        public string hora_de_emision { get; set; }
        public string codigo_tipo_operacion { get; set; }
        public string codigo_tipo_documento { get; set; }
        public string codigo_tipo_moneda { get; set; }
        public string fecha_de_vencimiento { get; set; }
        public string numero_orden_de_compra { get; set; }
        public e_ClienteFactura datos_del_cliente_o_receptor { get; set; }
        public string codigo_condicion_de_pago { get; set; }
        public List<e_CuotasFactura> cuotas { get; set; }  
        public e_TotalesFactura totales { get; set; }
        public List<e_ItemsFactura> items { get; set; }

    }
}
