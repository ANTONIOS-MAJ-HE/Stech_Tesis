using ST_Datos.Rol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Negocio.Model
{
    public class CN_Rol
    {
        private CD_Rol objcd_rol = new CD_Rol();


        public List<e_Rol> Listar()
        {
            return objcd_rol.GetAll();
        }
    }
}
