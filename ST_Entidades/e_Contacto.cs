using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Contacto
    {
        public int ID_CLIENTE { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string OBSERVACION { get; set; }
        public string DOCUMENTO { get; set; }
        public int NRO_CONTACTO { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
    }
}
