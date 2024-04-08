using System;
using System.Collections.Generic;
using System.Text;


namespace ST_Entidades
{
    public class e_Pedido
    {
        public int Nro_Pedido { get; set;}
        public string Fecha_pedido { get; set; }
        public string Canal { get; set; }
        public string MiniCod { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public string Moneda { get; set; }
        public string Precio_Unit_S_IGV { get; set; }
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string Tipo_Doc { get; set; }
        public string Nro_Doc { get; set; }
        public string Fecha_Despacho { get; set; }
        public string Subtotal_S_IGV { get; set; }
        public string ST_Pedido { get; set; }
        public string ST_Despacho { get; set; }
        public int Id_Pedido { get; set; }
        public int N_Item { get; set; }
        public double Costo_envio { get; set; }

    }
}
