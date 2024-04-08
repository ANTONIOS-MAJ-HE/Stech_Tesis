using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_RespuestaJsonGuias
    {
        public bool success { get; set; }
        public Dataguias data { get; set; }
    }
    public class Dataguias
    {
        public string number { get; set; }
        public string filename { get; set; }
        public string external_id { get; set; }
    }
}
