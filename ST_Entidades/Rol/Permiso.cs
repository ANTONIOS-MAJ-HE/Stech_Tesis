using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Datos.Rol
{
    public class Permiso
    {
        public int IdPermiso { get; set; }
        public e_Rol oRol { get; set; }
        public string NombreMenu { get; set; }
        public string FechaRegistro { get; set; }
    }
}
