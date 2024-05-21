using ST_Datos.Repository;
using ST_Entidades.Rol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ST_Datos.Rol
{
    public class CD_Usuario : RepositoryBase
    {

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (var connection = GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "select u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.Descripcion from usuario u inner join rol r on r.IdRol = u.IdRol ";

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        lista.Add(new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Documento = dr["Documento"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"]),
                            oRol = new e_Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                        });

                    }
                }

            }

            return lista;

        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (var connection = GetConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SP_REGISTRARUSUARIO";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("Documento", obj.Documento);
                        command.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                        command.Parameters.AddWithValue("Correo", obj.Correo);
                        command.Parameters.AddWithValue("Clave", obj.Clave);
                        command.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                        connection.Open();
                        command.ExecuteNonQuery();

                        idusuariogenerado = Convert.ToInt32(command.Parameters["IdUsuarioResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }

            return idusuariogenerado;
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (var connection = GetConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SP_EDITARUSUARIO";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                        command.Parameters.AddWithValue("Documento", obj.Documento);
                        command.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                        command.Parameters.AddWithValue("Correo", obj.Correo);
                        command.Parameters.AddWithValue("Clave", obj.Clave);
                        command.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                        connection.Open();
                        command.ExecuteNonQuery();

                        respuesta = Convert.ToBoolean(command.Parameters["Respuesta"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (var connection = GetConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SP_ELIMINARUSUARIO";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                        command.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                        connection.Open();
                        command.ExecuteNonQuery();

                        respuesta = Convert.ToBoolean(command.Parameters["Respuesta"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }


    }
}
