using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_TotalesFactura
    {
        public double total_descuentos { get; set; }
        public string total_exportacion { get; set; }
        public double total_operaciones_gravadas { get; set; }
        public string total_operaciones_inafectas { get; set; }
        public string total_operaciones_exoneradas { get; set; }
        public string total_operaciones_gratuitas { get; set; }
        public double total_igv { get; set; }
        public double total_impuestos { get; set; }
        public double total_valor { get; set; }
        public double total_venta { get; set;}
    }
}
