using System;
using System.Collections.Generic;
using System.Text;
using ST_Datos;
using ST_Entidades;

namespace ST_Negocio
{
    public class n_Consolidados
    {
        d_Consolidados ConsolidadosDAOB;
        public n_Consolidados()
        {
            ConsolidadosDAOB = new d_Consolidados();
        }

        public List<e_Consolidados> Lista_entradas()
        {
            return ConsolidadosDAOB.Lista_Cons();
        }

        public List<e_Consolidados> Lista_entradas_F(string canal, string partnumb, string cliente, string numeroOrden, string fecha, string producto)
        {
            string fecha_p;
            if (fecha == "")
            {
                fecha_p = "";
            }
            else
            {
                DateTime fecha_d = Convert.ToDateTime(fecha);
                fecha_p = fecha_d.ToString("yyyy-MM-dd");
            }
            e_Consolidados cons = new e_Consolidados();
            cons.CANAL = canal;
            cons.PART_NUMBER = partnumb;
            cons.NOMBRE_CLIENTE = cliente;
            cons.NUMERO_ORDEN = numeroOrden;
            cons.FECHA_FILTRO = fecha_p;
            cons.NOMBRE_PRODUCTO = producto;
            return ConsolidadosDAOB.Lista_Cons_F(cons);
        }

        public string Cargar_desp_nuevo()
        {
            return ConsolidadosDAOB.Cargar_desp_nuevo();
        }

        //listado en reportes

        public List<e_Reporte> Lista_r_canal()
        {
            return ConsolidadosDAOB.Lista_r_canal();
        }
        public List<e_Ventas_Producto> Lista_Ventas_Producto()
        {
            return ConsolidadosDAOB.Lista_Ventas_Producto();
        }

        public List<e_Ventas_Mes> Lista_Ventas_Mes()
        {
            return ConsolidadosDAOB.Lista_Ventas_Mes();
        }

        //Listado Filtros

        public List<e_Reporte> Lista_Ventas_Canal_F(string canal, string fecha, string st_despacho)
        {
            string fecha_p;
            if (fecha == "")
            {
                fecha_p = "";
            }
            else
            {
                DateTime fecha_d = Convert.ToDateTime(fecha);
                fecha_p = fecha_d.ToString("yyyy-MM-dd");
            }
            e_Filtros_Reportes cons = new e_Filtros_Reportes();
            cons.Canal = canal;
            cons.Fecha_Proceso = fecha_p;
            cons.ST_Despacho = st_despacho;
            return ConsolidadosDAOB.Lista_Ventas_canal_F(cons);
        }

        public List<e_Reporte> Lista_Ventas_Canal_F2(string canal, string fecha_I, string fecha_F, string st_despacho)
        {
            string Fecha_I;
            string Fecha_F;
            if (fecha_I == "")
            {
                Fecha_I = "";
                Fecha_F = "";
            }
            else
            {
                DateTime fecha_I1 = Convert.ToDateTime(fecha_I);
                Fecha_I = fecha_I1.ToString("yyyy-MM-dd");

                DateTime fecha_F1 = Convert.ToDateTime(fecha_F);
                Fecha_F = fecha_F1.ToString("yyyy-MM-dd");
            }
            e_Filtros_Reportes cons = new e_Filtros_Reportes();
            cons.Canal = canal;
            cons.Fecha_Inicio = Fecha_I;
            cons.Fecha_Fin = Fecha_F;
            cons.ST_Despacho = st_despacho;
            return ConsolidadosDAOB.Lista_Ventas_canal_F1(cons);
        }

        //Producto

        public List<e_Ventas_Producto> Lista_Ventas_Producto_F1(string canal, string fecha, string st_despacho)
        {
            string fecha_p;
            if (fecha == "")
            {
                fecha_p = "";
            }
            else
            {
                DateTime fecha_d = Convert.ToDateTime(fecha);
                fecha_p = fecha_d.ToString("yyyy-MM-dd");
            }
            e_Filtros_Reportes cons = new e_Filtros_Reportes();
            cons.Canal = canal;
            cons.Fecha_Proceso = fecha_p;
            cons.ST_Despacho = st_despacho;
            return ConsolidadosDAOB.Lista_Ventas_Producto_F1(cons);
        }

        public List<e_Ventas_Producto> Lista_Ventas_Producto_F2(string canal, string fecha_I, string fecha_F, string st_despacho)
        {
            string Fecha_I;
            string Fecha_F;
            if (fecha_I == "")
            {
                Fecha_I = "";
                Fecha_F = "";
            }
            else
            {
                DateTime fecha_I1 = Convert.ToDateTime(fecha_I);
                Fecha_I = fecha_I1.ToString("yyyy-MM-dd");

                DateTime fecha_F1 = Convert.ToDateTime(fecha_F);
                Fecha_F = fecha_F1.ToString("yyyy-MM-dd");
            }
            e_Filtros_Reportes cons = new e_Filtros_Reportes();
            cons.Canal = canal;
            cons.Fecha_Inicio = Fecha_I;
            cons.Fecha_Fin = Fecha_F;
            cons.ST_Despacho = st_despacho;
            return ConsolidadosDAOB.Lista_Ventas_Producto_F2(cons);
        }

        //LISTADO SIN FILTROS
        //public List<e_Consolidados_Saga> Lista_entradas_S()
        //{
        //    return ConsolidadosDAOB.Lista_Cons_SAGA();
        //}
        //public List<e_Consolidados_Linio> Lista_entradas_L()
        //{
        //    return ConsolidadosDAOB.Lista_Cons_LINIO();
        //}
        //public List<e_Consolidados_Ripley> Lista_entradas_R()
        //{
        //    return ConsolidadosDAOB.Lista_Cons_RIPLEY();
        //}
        //public List<e_Consolidados_RealPlaza> Lista_entradas_RP()
        //{
        //    return ConsolidadosDAOB.Lista_Cons_REAL_PLAZA();
        //}
        //public List<e_Consolidados_Kingston> Lista_entradas_KG()
        //{
        //    return ConsolidadosDAOB.Lista_Cons_KINGSTON();
        //}
        ////LISTADO CON FILTROS
        //public List<e_Consolidados_Saga> Lista_entradas_S_F(string partnumb,string cliente, string numeroOrden, string fecha, string producto)
        //{
        //    string fecha_p;
        //    if (fecha == "")
        //    {
        //        fecha_p = "";
        //    }
        //    else
        //    {
        //        DateTime fecha_d = Convert.ToDateTime(fecha);
        //        fecha_p = fecha_d.ToString("yyyy-MM-dd");    
        //    }
        //    e_Consolidados_Saga cons = new e_Consolidados_Saga();
        //    cons.PARTNUMB_REAL = partnumb;
        //    cons.NOMBRE_COMPRADOR = cliente;
        //    cons.NRO_OC = numeroOrden;
        //    cons.FECHA_FILTRO = fecha_p;
        //    cons.DESCRIPCION = producto;
        //    return ConsolidadosDAOB.Lista_Cons_SAGA_F(cons);
        //}
        //public List<e_Consolidados_Linio> Lista_entradas_L_F(string partnumb, string cliente, string numeroOrden, string fecha, string producto)
        //{
        //    string fecha_p;
        //    if (fecha == "")
        //    {
        //        fecha_p = "";
        //    }
        //    else
        //    {
        //        DateTime fecha_d = Convert.ToDateTime(fecha);
        //        fecha_p = fecha_d.ToString("yyyy-MM-dd");
        //    }
        //    e_Consolidados_Linio cons = new e_Consolidados_Linio();
        //    cons.PART_NUMB_REAL = partnumb;
        //    cons.CUSTOMER_NAME = cliente;
        //    cons.ORDER_NUMBER = numeroOrden;
        //    cons.FECHA_FILTRO = fecha_p;
        //    cons.ITEM_NAME = producto;
        //    return ConsolidadosDAOB.Lista_Cons_LINIO_F(cons);
        //}
        //public List<e_Consolidados_Ripley> Lista_entradas_R_F(string partnumb, string cliente, string numeroOrden, string fecha, string producto)
        //{
        //    string fecha_p;
        //    if (fecha == "")
        //    {
        //        fecha_p = "";
        //    }
        //    else
        //    {
        //        DateTime fecha_d = Convert.ToDateTime(fecha);
        //        fecha_p = fecha_d.ToString("yyyy-MM-dd");
        //    }
        //    e_Consolidados_Ripley cons = new e_Consolidados_Ripley();
        //    cons.PARTNUMB_REAL = partnumb;
        //    cons.NOMBRE_DE_PILA = cliente;
        //    cons.NRO_PEDIDO = numeroOrden;
        //    cons.FECHA_FILTRO = fecha_p;
        //    cons.DETALLES = producto;
        //    return ConsolidadosDAOB.Lista_Cons_RIPLEY_F(cons);
        //}
        //public List<e_Consolidados_RealPlaza> Lista_entradas_RP_F(string partnumb, string cliente, string numeroOrden, string fecha, string producto)
        //{
        //    string fecha_p;
        //    if (fecha == "")
        //    {
        //        fecha_p = "";
        //    }
        //    else
        //    {
        //        DateTime fecha_d = Convert.ToDateTime(fecha);
        //        fecha_p = fecha_d.ToString("yyyy-MM-dd");
        //    }
        //    e_Consolidados_RealPlaza cons = new e_Consolidados_RealPlaza();
        //    cons.PARTNUMB_REAL = partnumb;
        //    cons.CLIENTE = cliente;
        //    cons.NUMERO = numeroOrden;
        //    cons.FECHA_FILTRO = fecha_p;
        //    cons.NOMBRE_SKU = producto;
        //    return ConsolidadosDAOB.Lista_Cons_REAL_PLAZA_F(cons);
        //}
        //public List<e_Consolidados_Kingston> Lista_entradas_KG_F(string partnumb, string cliente, string numeroOrden, string fecha, string producto)
        //{
        //    string fecha_p;
        //    if (fecha == "")
        //    {
        //        fecha_p = "";
        //    }
        //    else
        //    {
        //        DateTime fecha_d = Convert.ToDateTime(fecha);
        //        fecha_p = fecha_d.ToString("yyyy-MM-dd");
        //    }
        //    e_Consolidados_Kingston cons = new e_Consolidados_Kingston();
        //    cons.PARTNUMB_REAL = partnumb;
        //    cons.NOMBRE_DE_PILA = cliente;
        //    cons.NRO_PEDIDO = numeroOrden;
        //    cons.FECHA_FILTRO = fecha_p;
        //    cons.DETALLES = producto;
        //    return ConsolidadosDAOB.Lista_Cons_KINGSTON_F(cons);
        //}
    }
}
