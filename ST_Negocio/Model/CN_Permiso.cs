using ST_Datos.Rol;
using ST_Entidades.Rol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Negocio.Model
{
    public class CN_Permiso
    {
        private readonly IPermisoRepository PermisoRepository;

        public CN_Permiso(IPermisoRepository permisoRepository)
        {
            this.PermisoRepository = permisoRepository;
        }

        public List<Permiso> Listar(int IdUsuario)
        {
            return PermisoRepository.Listar(IdUsuario);
        }

    }
}
