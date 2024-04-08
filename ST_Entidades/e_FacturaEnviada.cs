using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_FacturaEnviada
    {
        public string NRO_OC { get; set; }
        public string CODIGO_TIPO_OPERACION { get; set; }
        public string TIPO_MONEDA { get; set; }
        public string CLIENTE { get; set; }
        public string CODIGO_TIPO_DOCUMENTO { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public string DIRECCION { get; set; }
        public string PRODUCTO { get; set; }
        public string CODIGO_INTERNO { get; set; }
        public int CANTIDAD { get; set; }
        public double PRECIO_UNITARIO { get; set; }
        public double IGV_PRODUCTO { get; set; }
        public double PRECIO_ENVIO { get; set; }
        public double TOTAL_IMPUESTOS { get; set; }
        public double TOTAL_VALOR { get; set; }
        public double TOTAL_VENTA { get; set; }
        public DateTime FECHA_EMISION { get; set; }
        public string SERIE { get; set; }
        public string NUMERO_SERIE { get; set; }
    }
}
