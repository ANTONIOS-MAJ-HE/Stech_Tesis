using ST_Entidades.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ST_Negocio.Model
{
    public class UserModel
    {
        private readonly IUserRepository UserRepository;

        public UserModel(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        public string recoverPassword(string userRequesting)
        {
            return UserRepository.recoverPassword(userRequesting);
        }

        public List<Usuario> listar()
        {
            return UserRepository.GetByAll().ToList();
        }
    }
}
