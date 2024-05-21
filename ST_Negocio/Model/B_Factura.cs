using ST_Entidades;
using ST_Entidades.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ST_Negocio.Model
{
    public class B_Factura
    {
        private readonly IFacturaRepository FacturaRepository;

        public B_Factura(IFacturaRepository facturaRepository)
        {
            this.FacturaRepository = facturaRepository;
        }

        public List<Factura> listar()
        {
            return FacturaRepository.GetByAll().ToList();
        }
    }
}
