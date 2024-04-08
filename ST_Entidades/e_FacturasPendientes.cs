using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_FacturasPendientes
    {
        public string NRO_OC { get; set; }
        public string Cliente_DNI { get;set; }
        public string Cliente_Nombre { get; set;}
        public string Direccion { get; set;}
        public string Email { get; set;}
        public string Telefono { get; set;}
        public string Item { get; set; }
        public string Codigo_Item { get; set;}
        public int Cantidad { get; set;}
        public double Precio { get; set;}
        public double Costo_Envio { get; set; }

        public string Razon_Social { get; set; }

    }
}
