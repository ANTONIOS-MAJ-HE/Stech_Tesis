using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class Data
    {
        public string number { get; set; }
        public string filename { get; set; }
        public string external_id { get; set; }
        public string state_type_id { get; set; }
        public string state_type_description { get; set; }
        public string number_to_letter { get; set; }
        public string hash { get; set; }
        public string qr { get; set; }
        public int id { get; set; }
    }

    public class Links
    {
        public string xml { get; set; }
        public string pdf { get; set; }
        public string cdr { get; set; }
    }

    public class e_RespuestaJson
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public Links links { get; set; }
        public List<object> response { get; set; }
    }
}
