using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_CuotasFactura
    {
        public string codigo_metodo_de_pago { get; set; }
        public string fecha { get; set; }
        public string codigo_tipo_moneda { get; set; }
        public double monto { get; set; }
    }
}
