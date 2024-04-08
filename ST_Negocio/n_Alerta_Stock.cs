using System;
using System.Collections.Generic;
using System.Text;
using ST_Datos;
using ST_Entidades;

namespace ST_Negocio
{
    public class n_Alerta_Stock
    {
        d_Alerta_Stock alert_DAOB;
        public n_Alerta_Stock()
        {
            alert_DAOB = new d_Alerta_Stock();
        }

        public List<e_Alerta_Stock> Lista_alerta(string cant)
        {
            e_Alerta_Stock alert = new e_Alerta_Stock()
            {
                STOCK_FINAL = cant
            };
            return alert_DAOB.Lista_alertas(alert);
        }
        public List<e_Alerta_Stock> Lista_alerta_total()
        {
        
            return alert_DAOB.Lista_alertas_total();
        }
    }
}
