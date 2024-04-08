using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_transportista
    {
        public string NOMBRE { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string DOCUMENTO { get; set; }
        public string NUMERO_MTC { get; set; }
        public string DIRECCION_FISCAL { get; set; }
        public DateTime FECHA_PROCESO { get; set; }
        public int ID_TRANSPORTISTA { get; set; }
    }
}
