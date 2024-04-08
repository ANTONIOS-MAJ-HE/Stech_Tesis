using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_OrdenesCons
    {
        public string Canal { get; set; }
        public string Nro_OC { get; set; }
        public string Fecha_Creacion { get; set; }
        public string SKU { get; set; }
        public string EAN_UPC { get; set; }
        public string Modelo { get; set; }
        public string Mini_Codigo { get; set; }
        public string PartNumber { get; set; }
        public string Producto_Original { get; set; }
        public int Cantidad_Original { get; set; }
        public int Cantidad_Real { get; set; }
        public string Producto_Cambiado { get; set; }
        public string Costo_S_IGV { get; set; }
        public string Costo_C_IGV { get; set; }
        public string Nro_Doc { get; set; }
        public string Nom_Cliente { get; set; }
        public string Direccion_Cliente { get; set; }
        public string Fecha_Despacho { get; set; }
        public string Estado_Orden { get; set; }
        public string Estado_Despacho { get; set; }
        public string Serie_Comp { get; set; }
        public string Nro_Comp { get; set; }
        public string Observaciones { get; set; }
        public string Fecha_Proceso { get; set; }

    }

}
