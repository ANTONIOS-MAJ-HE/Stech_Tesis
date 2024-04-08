using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_ItemsFactura
    {
        public string codigo_interno { get; set; }
        public string descripcion { get; set; }
        public string codigo_producto_sunat { get; set;}
        public string unidad_de_medida { get; set;}
        public int cantidad { get; set;}
        public double valor_unitario { get; set;}
        public string codigo_tipo_precio { get; set;}
        public double precio_unitario { get; set;}
        public string codigo_tipo_afectacion_igv { get; set;}
        public double total_base_igv { get; set;}
        public double porcentaje_igv { get; set;}
        public double total_igv { get; set;}
        public double total_impuestos { get; set;}
        public double total_valor_item { get; set;}
        public double total_item { get;set;}
    }
}
