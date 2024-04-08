using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Reporte
    {
        public string canal { get; set; }
        public int cantidad_Ordenes { get; set; }
        public int cantidad_productos { get; set; }
        public double precio_sin_igv { get; set; }
        public double precio_con_igv { get; set; }
        public double porcentaje { get; set; }

    }

    public class e_Filtros_Reportes
    {
        public string Canal { get; set; }
        public string Fecha_Proceso { get; set; }
        public string Fecha_Inicio { get; set; }
        public string Fecha_Fin { get; set; }
        public string ST_Despacho { get; set; }
    }

    public class e_Ventas_Producto
    {
        public string Marca_Producto { get; set; }
        public string Mini_Codigo { get; set; }
        public string Part_Number { get; set; }
        public int cantidad { get; set; }
        public int stock { get; set; }
        public double Total_sin_igv { get; set; }
        public double Total_con_igv { get; set; }
        public double Porcentaje { get; set; }
    }

    public class e_Ventas_Mes
    {
        public DateTime Dia { get; set; }
        public double Total_Soles_Dia { get; set; }
        public double Total_Unidades_Dia { get; set; }
        public double Total_Soles_Mes { get; set; }
        public double Total_Unidades_Mes { get; set; }
    }
}
