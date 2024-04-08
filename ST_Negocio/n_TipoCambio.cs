using System;
using System.Collections.Generic;
using System.Text;
using ST_Entidades;
using ST_Datos;

namespace ST_Negocio
{
    public class n_TipoCambio
    {
        d_TipoCambio d_TipoCambio;
        public n_TipoCambio()
        {
            d_TipoCambio = new d_TipoCambio();
        }
        public string newCambio(e_Tipo_cambio tc)
        {
            return d_TipoCambio.NewCambio(tc);
        }
        public List<e_Tipo_cambio> listaCambios()
        {
            return d_TipoCambio.listarCambios();
        }

        public List<e_Tipo_cambio> listaCambios(string filtro)
        {
            return d_TipoCambio.listarCambios(filtro);
        }
        public List<e_Tipo_cambio> listaCambiosM(string filtro)
        {
            return d_TipoCambio.listarCambiosM(filtro);
        }
        //envia la compra de hoy en string
        public string MostrarCambio(string filtro)
        {
            List<e_Tipo_cambio> e_Tipo_Cambios = d_TipoCambio.listarCambios(filtro);
            e_Tipo_cambio e_Tipo_Cambio = e_Tipo_Cambios[0];
            return Convert.ToString(e_Tipo_Cambio.VENTA_ORIGEN);
        }
    }
}
