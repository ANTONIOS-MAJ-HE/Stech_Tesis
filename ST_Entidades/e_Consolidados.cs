using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Consolidados
    {
        public string CANAL { get; set; }
        public string NUMERO_ORDEN { get; set; }
        public string NUMERO_FACTURA { get; set; }
        public string DNI_CLIENTE { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string DIRECCION_CLIENTE { get; set; }
        public string REGION_VENTA { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string MODELO_PRODUCTO { get; set; }
        public string MARCA_PRODUCTO { get; set; }
        public string CATEGORIA_PRODUCTO { get; set; }
        public string CODIGO_PRODUCTO_CANAL { get; set; }
        public string PART_NUMBER { get; set; }
        public int CANTIDAD { get; set; }
        public double PRECIO_S_IGV { get; set; }
        public double PRECIO_C_IGV { get; set; }
        public double TOTAL_S_IGV { get; set; }
        public double TOTAL_C_IGV { get; set; }
        public DateTime FECHA_ORDEN { get; set; }
        public DateTime FECHA_PROCESO { get; set; }
        public DateTime FECHA_DESPACHO { get; set; }
        public string ST_DESPACHO { get; set; }
        public string ESTADO_ORDEN { get; set; }
        public string OBSERVACION_ORDEN { get; set; }

        public string FECHA_FILTRO { get; set; }

    }
}
