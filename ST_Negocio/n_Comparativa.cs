using ST_Datos;
using ST_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Negocio
{
    public class n_Comparativa
    {
        d_Comparativa comparativaDAOB;
        public n_Comparativa()
        {
            comparativaDAOB = new d_Comparativa();
        }
        public List<e_Comparativa> listaComparacion() 
        { 
            return comparativaDAOB.Lista_comparaciones();
        }
        public List<e_Comparativa> listaComparacionFiltro(string partnumber)
        {
            return comparativaDAOB.Lista_comparaciones_Filtro(partnumber);
        }
        public e_Ratios CalculaRatio(string partnumer,double tc)
        {
            return comparativaDAOB.Ratio_comparaciones_Filtro(partnumer,tc);
        }
        public void Carga() => comparativaDAOB.Cargar_stock();
        public string CargaManual() =>comparativaDAOB.CARGA();
        public List<e_Comparativa> ListaBusqueda(string titulo) => comparativaDAOB.Lista_Busqueda(titulo);
        public List<e_Ratios> ListaRatios ( double tc) => comparativaDAOB.Ratio_comparaciones_Filtro_ALL( tc);
    }
}
