using System;
using System.Collections.Generic;
using System.Text;
using ST_Entidades;
using ST_Datos;

namespace ST_Negocio
{
    public class n_Cambio_adv
    {
        d_Cambio_adv CambioDAOB;
        public n_Cambio_adv()
        {
            CambioDAOB = new d_Cambio_adv();
        }

        public string Cargar_Cons()
        {
            return CambioDAOB.Cargar_CONS();
        }

        public string Act_Dupl_RealPlaza(string CANT_PARTNUMB_1, string NRO_OC, string PARTNUMB_1)
        {
            e_Cambio_adv cambio = new e_Cambio_adv()
            {
                CANT_PARTNUMB_1 = CANT_PARTNUMB_1,
                NRO_OC = NRO_OC,
                PARTNUMB_1 = PARTNUMB_1
            };
            return CambioDAOB.Actualizar_Duplicado_RealPlaza(cambio);
        }
        public string Dupl_RealPlaza(string OBSERVACIONES, string CANT_PARTNUMB_2, string PARTNUMB_2, string NRO_OC, string PARTNUMB_1)
        {
            e_Cambio_adv cambio = new e_Cambio_adv()
            {
                OBSERVACIONES = OBSERVACIONES,
                PARTNUMB_1 = PARTNUMB_1,
                CANT_PARTNUMB_2 = CANT_PARTNUMB_2,
                PARTNUMB_2 = PARTNUMB_2,
                NRO_OC = NRO_OC
            };
            return CambioDAOB.Duplicar_REALPLAZA(cambio);


        }


        public string Act_Dupl_Linio(string CANT_PARTNUMB_1, string NRO_OC, string PARTNUMB_1)
        {
            e_Cambio_adv cambio = new e_Cambio_adv()
            {
                CANT_PARTNUMB_1 = CANT_PARTNUMB_1,
                NRO_OC = NRO_OC,
                PARTNUMB_1 = PARTNUMB_1
            };
            return CambioDAOB.Actualizar_Duplicado_Linio(cambio);
        }
        public string Dupl_Linio(string OBSERVACIONES, string CANT_PARTNUMB_2, string PARTNUMB_2, string NRO_OC, string PARTNUMB_1)
        {
            e_Cambio_adv cambio = new e_Cambio_adv()
            {
                OBSERVACIONES = OBSERVACIONES,
                PARTNUMB_1 = PARTNUMB_1,
                CANT_PARTNUMB_2 = CANT_PARTNUMB_2,
                PARTNUMB_2 = PARTNUMB_2,
                NRO_OC = NRO_OC
            };
            return CambioDAOB.Duplicar_LINIO(cambio);


        }

        public string Act_Dupl_Saga(string CANT_PARTNUMB_1, string NRO_OC, string PARTNUMB_1)
        {
            e_Cambio_adv cambio = new e_Cambio_adv()
            {
                CANT_PARTNUMB_1 = CANT_PARTNUMB_1,
                NRO_OC = NRO_OC,
                PARTNUMB_1 = PARTNUMB_1
            };
            return CambioDAOB.Actualizar_Duplicado_Saga(cambio);
        }
        public string Dupl_Saga( string CANT_PARTNUMB_2, string PARTNUMB_2, string OBSERVACIONES, string NRO_OC, string PARTNUMB_1)
        {
            e_Cambio_adv cambio = new e_Cambio_adv()
            {
                CANT_PARTNUMB_2 = CANT_PARTNUMB_2,
                PARTNUMB_2 = PARTNUMB_2,
                OBSERVACIONES = OBSERVACIONES,            
                NRO_OC = NRO_OC,
                PARTNUMB_1 = PARTNUMB_1
            };
            return CambioDAOB.Duplicar_SAGA(cambio);


        }
        public string Act_Dupl_Ripley (string CANT_PARTNUMB_1, string NRO_OC, string PARTNUMB_1)
        {
            e_Cambio_adv cambio = new e_Cambio_adv()
            {
                CANT_PARTNUMB_1 = CANT_PARTNUMB_1,
                NRO_OC = NRO_OC,
                PARTNUMB_1 = PARTNUMB_1
            };
            return CambioDAOB.Actualizar_Duplicado_Ripley(cambio);
        }
        public string Dupl_Ripley(string OBSERVACIONES, string CANT_PARTNUMB_2, string PARTNUMB_2, string NRO_OC, string PARTNUMB_1)
        {
            e_Cambio_adv cambio = new e_Cambio_adv()
            {
                OBSERVACIONES = OBSERVACIONES,
                PARTNUMB_1 = PARTNUMB_1,
                CANT_PARTNUMB_2 = CANT_PARTNUMB_2,
                PARTNUMB_2 = PARTNUMB_2,
                NRO_OC = NRO_OC
            };
            return CambioDAOB.Duplicar_RIPLEY(cambio);
            

        }
        public string Ingresa_cambio_adv (string CANAL, string FECHA_REGISTRO, string NRO_OC, string PARTNUMB_1, string CANT_PARTNUMB_1, string PARTNUMB_2, string CANT_PARTNUMB_2, string OBSERVACIONES,string RESPONSABLE)
        {
            e_Cambio_adv cambio = new e_Cambio_adv()
            {
                CANAL = CANAL,
                FECHA_REGISTRO = FECHA_REGISTRO,
                NRO_OC = NRO_OC,
                PARTNUMB_1 = PARTNUMB_1,
                CANT_PARTNUMB_1 = CANT_PARTNUMB_1,
                PARTNUMB_2 = PARTNUMB_2,
                CANT_PARTNUMB_2 = CANT_PARTNUMB_2,
                OBSERVACIONES = OBSERVACIONES,
                RESPONSABLE = RESPONSABLE
            };
            return CambioDAOB.Insertar_Incidencia_Avanzada(cambio);
        }
        public  List<e_Cambio_adv> Listar_cambios()
        {
            return CambioDAOB.Lista_cambios();
        }
    }
}
