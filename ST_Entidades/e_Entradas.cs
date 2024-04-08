using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Entradas
    {
        public string Tipo { get; set; }
        public string Responsable { get; set; }
        public string Fecha_Entrada { get; set; }
        public string Serie_Fact { get; set; }
        public string Nro_Fact { get; set; }
        public string RUC_Proveedor { get; set; }
        public string Proveedor { get; set; }
        public string Origen { get; set; }
        public string Moneda { get; set; }
        public string MiniCodigo { get; set; }
        public string Producto { get; set; }
        public string Marca { get; set; }
        public decimal Precio_Unitario { get; set; }
        public int Cantidad { get; set; }
        public string Fecha_guia { get; set; }
        public string Fecha_factura { get; set; }
        public string Observaciones { get; set; }
        public int Id_Entrada{ get; set; }

    }
}
