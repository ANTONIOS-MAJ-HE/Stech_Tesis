using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ST_Datos.Repository;
using ST_Entidades.Rol;
using ST_Datos.Rol;

namespace ST_Datos.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(Usuario userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [USUARIO] where Documento=@username and [Clave]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(Usuario userModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Usuario> GetByAll()
        {
            throw new NotImplementedException();
        }
        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Usuario GetByUsername(string username)
        {
            Usuario user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.Descripcion from usuario u inner join rol r on r.IdRol = u.IdRol where u.Documento=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(reader[0]),
                            Documento = reader[1].ToString(),
                            NombreCompleto = reader[2].ToString(),
                            Correo = reader[3].ToString(),
                            Clave = reader[4].ToString(),
                            Estado = Convert.ToBoolean(reader[5]),
                            oRol = new e_Rol() { IdRol = Convert.ToInt32(reader[6]), Descripcion = reader[7].ToString()}
                        };
                    }
                }
            }
            return user;
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public string recoverPassword(string userRequesting)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from usuario where Documento=@user or Correo=@mail";
                    command.Parameters.AddWithValue("@user", userRequesting);
                    command.Parameters.AddWithValue("@mail", userRequesting);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(2) + ", " + reader.GetString(1);
                        string userMail = reader.GetString(3);
                        string accountPassword = reader.GetString(4);
                        var mailService = new SystemSupportMail();
                        mailService.sendMail(
                          subject: "SYSTEM: Password recovery request",
                          body: "Hi, " + userName + "\nYou Requested to Recover your password.\n" +
                          "your current password is: " + accountPassword +
                          "\nHowever, we ask that you change your password inmediately once you enter the system.",
                          recipientMail: new List<string> { userMail }
                          );
                        return "Hi, " + userName + "\nYou Requested to Recover your password.\n" +
                          "Please check your mail: " + userMail +
                          "\nHowever, we ask that you change your password inmediately once you enter the system.";
                    }
                    else
                        return "Sorry, you do not have an account with that mail or username";
                }
            }
        }


    }
}
