
using ST_Datos.Repository;
using ST_Entidades.Rol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ST_Datos.Rol
{
    public class CD_Permiso : RepositoryBase, IPermisoRepository
    {

        List<Permiso> IPermisoRepository.Listar(int idusuario)
        {
            List<Permiso> permiso = new List<Permiso>();
            using (var connection = GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select p.IdRol,p.NombreMenu from PERMISO p inner join ROL r on r.IdRol = p.IdRol inner join USUARIO u on u.IdRol = r.IdRol where u.IdUsuario = @idusuario";
                command.Parameters.Add("@idusuario", SqlDbType.Int).Value = idusuario;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        permiso.Add(new Permiso()
                        {
                            oRol = new e_Rol() { IdRol = Convert.ToInt32(reader["IdRol"]) },
                            NombreMenu = reader["NombreMenu"].ToString(),
                        });


                    }
                }
            }

            return permiso;

        }

    }
}
