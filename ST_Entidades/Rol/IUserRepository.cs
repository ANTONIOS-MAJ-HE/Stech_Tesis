using ST_Datos.Rol;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ST_Entidades.Rol
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(Usuario userModel);
        void Edit(Usuario userModel);
        void Remove(int id);
        Usuario GetById(int id);
        Usuario GetByUsername(string username);
        IEnumerable<Usuario> GetByAll();
        //...

        string recoverPassword(string userRequesting);
    }

    public interface IFacturaRepository
    {
        Factura GetById(int id);

        // Obtener todas las órdenes
        IEnumerable<Factura> GetByAll();

        // Agregar una nueva orden
        void Add(Factura order);

        // Editar una orden existente
        void Edit(Factura order);

        // Eliminar una orden por su ID
        void Remove(int id);

        Factura GetByFactura();
    }

    public interface IPermisoRepository
    {
        List<Permiso> Listar(int idusuario);
    }
}
