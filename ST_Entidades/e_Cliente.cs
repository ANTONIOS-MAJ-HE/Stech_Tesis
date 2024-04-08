using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Cliente
    {
        public int ID_CLIENTE { get;set; }
        public string NOMBRE_RAZON_SOCIAL{ get;set; }
        public string TIPO_DOCUMENTO { get;set; }
        public string NRO_DOCUMENTO { get;set; }
        public string CORREO { get;set; }
        public string TELEFONO { get;set; }
        public DateTime FECHA_REGISTRO { get;set; }
        public string DIRECCION_FISCAL { get;set; }
        public string DIRECCION_ENTREGA { get;set; }
        public string UBIGEO { get;set; }
        public string COD_UBIGEO { get;set; }

    }
}
