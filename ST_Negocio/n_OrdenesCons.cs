using System;
using System.Collections.Generic;
using System.Text;
using ST_Datos;
using ST_Entidades; 


namespace ST_Negocio
{
    
    public class n_OrdenesCons
    {
        d_OrdenesCons OrdenesconsDAOB;

        public n_OrdenesCons()
        {
            OrdenesconsDAOB = new d_OrdenesCons();
        }

        public List<e_OrdenesCons>Lista_Ods_Cons(string nro_oc)
        {
            e_OrdenesCons oc = new e_OrdenesCons
            {
                Nro_OC = nro_oc
            };
            return OrdenesconsDAOB.Listar_OCs_Consolidadas(oc);
        }
        public string Actualiza_CONS()
        {
            return OrdenesconsDAOB.Actualizar_Cons();
        }

    }
}
