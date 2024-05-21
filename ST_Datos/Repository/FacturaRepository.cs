using ST_Entidades.Rol;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Datos.Repository
{
    public class FacturaRepository : RepositoryBase, IFacturaRepository
    {

        void IFacturaRepository.Add(Factura order)
        {
            throw new NotImplementedException();
        }

        void IFacturaRepository.Edit(Factura order)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Factura> IFacturaRepository.GetByAll()
        {
            List<Factura> facturas = new List<Factura>();
            using (var connection = GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from FACTURA";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        facturas.Add(new Factura()
                        {
                            Numero_Orden = reader.GetDouble(0),
                            Ruc_Proveedor = reader.GetString(1),
                        });
                    }
                }
            }
            return facturas;
        }

        Factura IFacturaRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Factura IFacturaRepository.GetByFactura()
        {
            Factura factura = null;
            using (var connection = GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from FACTURA";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        factura = new Factura()
                        {
                            Numero_Orden = reader.GetDouble(0),
                            Ruc_Proveedor = reader.GetString(1),
                        };
                    }
                }
            }
            return factura;
        }

        void IFacturaRepository.Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
