using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Consolidados_Kingston
    {
        public DateTime FECHA_DE_CREACION { get; set; }
        public string NRO_PEDIDO { get; set; }
        public int CANTIDAD { get; set; }
        public string DETALLES { get; set; }
        public string ESTADO { get; set; }
        public double IMPORTE { get; set; }
        public string MONEDA { get; set; }
        public string METODO_DE_ENVIO { get; set; }
        public string SKU_TIENDA { get; set; }
        public double PRECIO_UNIDAD { get; set; }
        public double PRECIO_ENVIO { get; set; }
        public double IMPORTE_TOTAL_PEDIDO { get; set; }
        public double VALOR_COMISION { get; set; }
        public string NOMBRE_DE_PILA { get; set; }
        public string DIRECCION_ENTREGA { get; set; }
        public string CIUDAD_ENTREGA { get; set; }
        public DateTime FECHA_PROCESO { get; set; }
        public string ST_DESPACHO { get; set; }
        public string ST_ORDEN { get; set; }
        public string PARTNUMB_REAL { get; set; }
        public int UNIDADES_REAL { get; set; }
        public string FECHA_FILTRO { get; set; }
    }
}
