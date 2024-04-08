using System;
using System.Collections.Generic;
using System.Text;
using ST_Datos;
using ST_Entidades;

namespace ST_Negocio
{
    public class n_Kardex
    {
        d_kardex actDAOB;
        public n_Kardex()
        {
            actDAOB = new d_kardex();
        }

        public string Actualizar_kardex(string ID)
        {
            return actDAOB.Actualizar_kardex(ID);
        }
        public List<e_Skardex_> Lista_kardex_codigo(string COD)
        {
            return actDAOB.Lista_Kardex(COD);
        }
    }
}
