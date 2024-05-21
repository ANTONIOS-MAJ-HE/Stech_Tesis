using ST_Datos.Rol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades.Rol
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public e_Rol oRol { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
    }
}
