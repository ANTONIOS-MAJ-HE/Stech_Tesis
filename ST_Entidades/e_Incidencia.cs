using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ST_Entidades
{
    public class e_Incidencia
    {
        public int Id_Incidencia { get; set; }
        public string Tipo { get; set; }
        public string Canal { get; set; }
        public string Fecha_Proceso { get; set; }
        public string Nro_OC { get; set; }
        public string Fecha_Retorno { get; set; }
        public string Minicod_1 { get; set; }
        public string Minicod_2 { get; set; }
        public string Estado_Dev { get; set; }
        public string Observaciones { get; set; }
        public string Fecha_Registro { get; set; }
        public string Fecha_Reprogramado { get; set; }

        public  string Nvo_cant { get; set; }
    }

}
