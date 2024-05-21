using ST_Datos.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Datos.Rol
{
    public class CD_Rol : RepositoryBase
    {
        public List<e_Rol> GetAll()
        {
            List<e_Rol> lista = new List<e_Rol>();
            using (var connection = GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select IdRol,Descripcion from ROL";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new e_Rol()
                        {
                            IdRol = Convert.ToInt32(reader["IdRol"]),
                            Descripcion = reader["Descripcion"].ToString()
                        });
                    }
                }

            }

            return lista;
        }
    }
}
