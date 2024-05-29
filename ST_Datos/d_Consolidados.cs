using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ST_Entidades;


namespace ST_Datos
{
    public class d_Consolidados
    {
        d_SQLcon db_st = new d_SQLcon();

        //Listado sin filtro Consolidados
        public List<e_Consolidados> Lista_Cons()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Consolidados> listado = new List<e_Consolidados>();
                e_Consolidados lista = null;
                string consulta = "SELECT ISNULL(CANAL,'-')  AS CANAL,ISNULL(NUMERO_ORDEN,'-')  AS NUMERO_ORDEN,ISNULL(NUMERO_FACTURA,'-')  AS NUMERO_FACTURA,ISNULL(DNI_CLIENTE,'-')  AS DNI_CLIENTE,ISNULL(NOMBRE_CLIENTE,'-') AS  NOMBRE_CLIENTE, " +
                    "ISNULL(DIRECCION_CLIENTE, '-')  AS DIRECCION_CLIENTE, ISNULL(REGION_VENTA, '-') AS REGION_VENTA, ISNULL(NOMBRE_PRODUCTO, '-') AS NOMBRE_PRODUCTO, ISNULL(MODELO_PRODUCTO, '-') AS MODELO_PRODUCTO, ISNULL(MARCA_PRODUCTO, '-')  AS MARCA_PRODUCTO, " +
                    "ISNULL(CATEGORIA_PRODUCTO, '-') AS CATEGORIA_PRODUCTO, ISNULL(CODIGO_PRODUCTO_CANAL, '-') AS CODIGO_PRODUCTO_CANAL, ISNULL(PART_NUMBER, '-') AS PART_NUMBER, ISNULL(CANTIDAD, 0) AS CANTIDAD, ISNULL(PRECIO_S_IGV, 0) AS PRECIO_S_IGV, " +
                    "ISNULL(PRECIO_C_IGV, 0) AS PRECIO_C_IGV, ISNULL(TOTAL_S_IGV, 0) AS TOTAL_S_IGV, ISNULL(TOTAL_C_IGV, 0) AS TOTAL_C_IGV, ISNULL(FECHA_ORDEN, '2021-01-01') AS FECHA_ORDEN, ISNULL(FECHA_PROCESO, '2021-01-01') AS FECHA_PROCESO," +
                    "ISNULL(FECHA_DESPACHO, '2021-01-01') AS FECHA_DESPACHO, ISNULL(ST_DESPACHO, '-')  AS ST_DESPACHO, ISNULL(ESTADO_ORDEN, '-') AS ESTADO_ORDEN, ISNULL(OBSERVACION_ORDEN, '-') AS OBSERVACION_ORDEN  FROM ST_CONS_ORDENES_NEW WHERE FECHA_ORDEN >= '2024' ORDER BY FECHA_ORDEN DESC";

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    lista = new e_Consolidados();
                    lista.CANAL = (string)reader["CANAL"];
                    lista.NUMERO_ORDEN = (string)reader["NUMERO_ORDEN"];
                    lista.NUMERO_FACTURA = (string)reader["NUMERO_FACTURA"];
                    lista.DNI_CLIENTE = (string)reader["DNI_CLIENTE"];
                    lista.NOMBRE_CLIENTE = (string)reader["NOMBRE_CLIENTE"];
                    lista.DIRECCION_CLIENTE = (string)reader["DIRECCION_CLIENTE"];
                    lista.REGION_VENTA = (string)reader["REGION_VENTA"];
                    lista.NOMBRE_PRODUCTO = (string)reader["NOMBRE_PRODUCTO"];
                    lista.MODELO_PRODUCTO = (string)reader["MODELO_PRODUCTO"];
                    lista.MARCA_PRODUCTO = (string)reader["MARCA_PRODUCTO"];
                    lista.CATEGORIA_PRODUCTO = (string)reader["CATEGORIA_PRODUCTO"];

                    lista.CODIGO_PRODUCTO_CANAL = (string)reader["CODIGO_PRODUCTO_CANAL"];
                    lista.PART_NUMBER = (string)reader["PART_NUMBER"];
                    lista.CANTIDAD = (int)reader["CANTIDAD"];
                    lista.PRECIO_S_IGV = (double)reader["PRECIO_S_IGV"];
                    lista.PRECIO_C_IGV = (double)reader["PRECIO_C_IGV"];
                    lista.TOTAL_S_IGV = (double)reader["TOTAL_S_IGV"];
                    lista.TOTAL_C_IGV = (double)reader["TOTAL_C_IGV"];
                    lista.FECHA_ORDEN = (DateTime)reader["FECHA_ORDEN"];
                    lista.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
                    lista.FECHA_DESPACHO = (DateTime)reader["FECHA_DESPACHO"];
                    lista.ST_DESPACHO = (string)reader["ST_DESPACHO"];
                    lista.ESTADO_ORDEN = (string)reader["ESTADO_ORDEN"];
                    lista.OBSERVACION_ORDEN = (string)reader["OBSERVACION_ORDEN"];

                    listado.Add(lista);
                }
                reader.Close();
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        

        //Filtros


        public List<e_Consolidados> Lista_Cons_F(e_Consolidados obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Consolidados> listado = new List<e_Consolidados>();
                e_Consolidados lista = null;
                string consulta = string.Format("SELECT ISNULL(CANAL,'-')  AS CANAL,ISNULL(NUMERO_ORDEN,'-')  AS NUMERO_ORDEN,ISNULL(NUMERO_FACTURA,'-')  AS NUMERO_FACTURA,ISNULL(DNI_CLIENTE,'-')  AS DNI_CLIENTE,ISNULL(NOMBRE_CLIENTE,'-') AS  NOMBRE_CLIENTE, " +
                    "ISNULL(DIRECCION_CLIENTE, '-')  AS DIRECCION_CLIENTE, ISNULL(REGION_VENTA, '-') AS REGION_VENTA, ISNULL(NOMBRE_PRODUCTO, '-') AS NOMBRE_PRODUCTO, ISNULL(MODELO_PRODUCTO, '-') AS MODELO_PRODUCTO, ISNULL(MARCA_PRODUCTO, '-')  AS MARCA_PRODUCTO, " +
                    "ISNULL(CATEGORIA_PRODUCTO, '-') AS CATEGORIA_PRODUCTO, ISNULL(CODIGO_PRODUCTO_CANAL, '-') AS CODIGO_PRODUCTO_CANAL, ISNULL(PART_NUMBER, '-') AS PART_NUMBER, ISNULL(CANTIDAD, 0) AS CANTIDAD, ISNULL(PRECIO_S_IGV, 0) AS PRECIO_S_IGV, " +
                    "ISNULL(PRECIO_C_IGV, 0) AS PRECIO_C_IGV, ISNULL(TOTAL_S_IGV, 0) AS TOTAL_S_IGV, ISNULL(TOTAL_C_IGV, 0) AS TOTAL_C_IGV, ISNULL(FECHA_ORDEN, '2021-01-01') AS FECHA_ORDEN, ISNULL(FECHA_PROCESO, '2021-01-01') AS FECHA_PROCESO," +
                    "ISNULL(FECHA_DESPACHO, '2021-01-01') AS FECHA_DESPACHO, ISNULL(ST_DESPACHO, '-')  AS ST_DESPACHO, ISNULL(ESTADO_ORDEN, '-') AS ESTADO_ORDEN, ISNULL(OBSERVACION_ORDEN, '-') AS OBSERVACION_ORDEN  FROM ST_CONS_ORDENES_NEW WHERE NUMERO_ORDEN LIKE '%{0}%' AND NOMBRE_CLIENTE LIKE '%{1}%' AND PART_NUMBER LIKE '%{2}%' AND Convert(varchar,FECHA_PROCESO,23) LIKE '{3}%' " +
                    "AND NOMBRE_PRODUCTO LIKE '%{4}%' AND CANAL LIKE '%{5}%' ORDER BY FECHA_ORDEN DESC ",
                    obj.NUMERO_ORDEN, obj.NOMBRE_CLIENTE, obj.PART_NUMBER, obj.FECHA_FILTRO, obj.NOMBRE_PRODUCTO, obj.CANAL);

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    lista = new e_Consolidados();
                    lista.CANAL = (string)reader["CANAL"];
                    lista.NUMERO_ORDEN = (string)reader["NUMERO_ORDEN"];
                    lista.NUMERO_FACTURA = (string)reader["NUMERO_FACTURA"];
                    lista.DNI_CLIENTE = (string)reader["DNI_CLIENTE"];
                    lista.NOMBRE_CLIENTE = (string)reader["NOMBRE_CLIENTE"];
                    lista.DIRECCION_CLIENTE = (string)reader["DIRECCION_CLIENTE"];
                    lista.REGION_VENTA = (string)reader["REGION_VENTA"];
                    lista.NOMBRE_PRODUCTO = (string)reader["NOMBRE_PRODUCTO"];
                    lista.MODELO_PRODUCTO = (string)reader["MODELO_PRODUCTO"];
                    lista.MARCA_PRODUCTO = (string)reader["MARCA_PRODUCTO"];
                    lista.CATEGORIA_PRODUCTO = (string)reader["CATEGORIA_PRODUCTO"];
                    lista.CODIGO_PRODUCTO_CANAL = (string)reader["CODIGO_PRODUCTO_CANAL"];
                    lista.PART_NUMBER = (string)reader["PART_NUMBER"];
                    lista.CANTIDAD = (int)reader["CANTIDAD"];
                    lista.PRECIO_S_IGV = (double)reader["PRECIO_S_IGV"];
                    lista.PRECIO_C_IGV = (double)reader["PRECIO_C_IGV"];
                    lista.TOTAL_S_IGV = (double)reader["TOTAL_S_IGV"];
                    lista.TOTAL_C_IGV = (double)reader["TOTAL_C_IGV"];
                    lista.FECHA_ORDEN = (DateTime)reader["FECHA_ORDEN"];
                    lista.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
                    lista.FECHA_DESPACHO = (DateTime)reader["FECHA_DESPACHO"];
                    lista.ST_DESPACHO = (string)reader["ST_DESPACHO"];
                    lista.ESTADO_ORDEN = (string)reader["ESTADO_ORDEN"];
                    lista.OBSERVACION_ORDEN = (string)reader["OBSERVACION_ORDEN"];

                    listado.Add(lista);
                }
                reader.Close();
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }



        //Carga de todas las ordenes

        public string Cargar_desp_nuevo()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string get = "USE DB_ST EXEC msdb.dbo.sp_start_job 'Carga_Todas_Ordenes'";
                SqlCommand cmd_0 = new SqlCommand(get, con);
                cmd_0.ExecuteNonQuery();
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        //Reporte de 

        //listado

        //Ventas totales del mes            - -Listado por cada dia del mes

        public List<e_Ventas_Mes> Lista_Ventas_Mes()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Ventas_Mes> listado = new List<e_Ventas_Mes>();
                e_Ventas_Mes lista = null;
                string consulta = "SELECT DIA, TOTAL_SOLES_DIA, TOTAL_UNIDADES_DIA, " +
                    "(SELECT CONVERT(DECIMAL(20,2), SUM(TOTAL_S_IGV)) FROM ST_CONS_ORDENES_NEW WHERE CAST(CONVERT(VARCHAR(10), FECHA_PROCESO, 23) AS DATE) BETWEEN DATEADD(day, -(DAY(GETDATE())) + 1, CAST(GETDATE() AS DATE)) AND CAST(GETDATE() AS DATE)) AS TOTAL_SOLES_MES, " +
                    "(SELECT SUM(CANTIDAD) FROM ST_CONS_ORDENES_NEW WHERE CAST(CONVERT(VARCHAR(10), FECHA_PROCESO, 23) AS DATE) BETWEEN DATEADD(day, -(DAY(GETDATE())) + 1, CAST(GETDATE() AS DATE)) AND CAST(GETDATE() AS DATE)) AS TOTAL_UNIDADES_MES " +
                    "FROM(SELECT CAST(CONVERT(VARCHAR(10), FECHA_PROCESO, 23) AS DATE) AS DIA, CONVERT(DECIMAL(20,2), SUM(TOTAL_S_IGV)) AS TOTAL_SOLES_DIA, SUM(CANTIDAD) AS TOTAL_UNIDADES_DIA FROM ST_CONS_ORDENES_NEW " +
                    "WHERE CAST(CONVERT(VARCHAR(10), FECHA_PROCESO, 23) AS DATE) BETWEEN DATEADD(day, -(DAY(GETDATE())) + 1, CAST(GETDATE() AS DATE)) AND CAST(GETDATE() AS DATE) " +
                    "AND ST_DESPACHO IN (SELECT ST_DESPACHO FROM ST_CONS_ORDENES_NEW WHERE ST_DESPACHO = 'DESPACHODO' OR ST_DESPACHO = 'PENDIENTE' ) " +
                    "GROUP BY CAST(CONVERT(VARCHAR(10), FECHA_PROCESO, 23) AS DATE)) AS Subconsulta ORDER BY DIA DESC";

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    lista = new e_Ventas_Mes();
                    lista.Dia = (DateTime)reader["DIA"];
                    lista.Total_Soles_Dia = Convert.ToDouble((decimal)reader["TOTAL_SOLES_DIA"]);
                    lista.Total_Unidades_Dia = (int)reader["TOTAL_UNIDADES_DIA"];
                    lista.Total_Soles_Mes = Convert.ToDouble((decimal)reader["TOTAL_SOLES_MES"]);
                    lista.Total_Unidades_Mes = (int)reader["TOTAL_UNIDADES_MES"];

                    listado.Add(lista);
                }
                reader.Close();
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        //listado por canal

        public List<e_Reporte> Lista_r_canal()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Reporte> listado = new List<e_Reporte>();
                e_Reporte lista = null;
                string consulta = "SELECT CANAL,COUNT ( DISTINCT NUMERO_ORDEN) AS [CANTIDAD DE ORDENES], SUM(CANTIDAD) AS [CANTIDAD DE PRODUCTOS], " +
                    "CONVERT(DECIMAL(20, 2),SUM(TOTAL_S_IGV)) AS [PRECIO SIN IGV], CONVERT(DECIMAL(20, 2), SUM(TOTAL_C_IGV)) AS [PRECIO CON IGV], CONVERT(DECIMAL(10, 2), FORMAT(SUM(TOTAL_C_IGV) * 100.0 / SUM(SUM(TOTAL_C_IGV)) OVER(), 'N')) AS PORCENTAJE FROM ST_CONS_ORDENES_NEW " +
                    "WHERE FECHA_PROCESO >= CONVERT(VARCHAR(10), GETDATE(), 120) AND ST_DESPACHO IN (SELECT ST_DESPACHO FROM ST_CONS_ORDENES_NEW WHERE ST_DESPACHO = 'DESPACHODO' OR ST_DESPACHO = 'PENDIENTE' ) GROUP BY CANAL ORDER BY [PRECIO CON IGV] DESC ";

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    lista = new e_Reporte();
                    lista.canal = (string)reader["CANAL"];
                    lista.cantidad_Ordenes = (int)reader["CANTIDAD DE ORDENES"];
                    lista.cantidad_productos = (int)reader["CANTIDAD DE PRODUCTOS"];
                    lista.precio_sin_igv = Convert.ToDouble((decimal)reader["PRECIO SIN IGV"]);
                    lista.precio_con_igv = Convert.ToDouble((decimal)reader["PRECIO CON IGV"]);
                    lista.porcentaje = Convert.ToDouble((decimal)reader["PORCENTAJE"]);
                    listado.Add(lista);
                }
                reader.Close();
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        //Listado de productos

        public List<e_Ventas_Producto> Lista_Ventas_Producto()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Ventas_Producto> listado = new List<e_Ventas_Producto>();
                e_Ventas_Producto lista = null;
                string consulta = "SELECT MARCA_PRODUCTO, ST.MINI_CODIGO AS MINI_CODIGO, PART_NUMBER,STS.STOCK_FINAL AS STOCK_RESTANTE, SUM(CANTIDAD) AS CANTIDAD_PRODUCTOS_VENDIDOS, CONVERT(DECIMAL(20, 2), SUM(TOTAL_S_IGV)) AS SUBTOTAL_S_IGV, " +
                    "CONVERT(DECIMAL(20, 2), SUM(TOTAL_C_IGV)) AS TOTAL_C_IGV, CONVERT(DECIMAL(10, 2), FORMAT(SUM(TOTAL_C_IGV) * 100.0 / SUM(SUM(TOTAL_C_IGV)) OVER(), 'N')) AS PORCENTAJE " +
                    "FROM ST_CONS_ORDENES_NEW CO JOIN ST_STOCK  ST ON ST.PARTNUMBER = CO.PART_NUMBER JOIN ST_STOCK_HST_CONSULTA STS ON STS.PARTNUMBER = CO.PART_NUMBER  " +
                    "WHERE CO.FECHA_PROCESO >= CONVERT(VARCHAR(10), GETDATE(), 120) AND ST_DESPACHO IN (SELECT ST_DESPACHO FROM ST_CONS_ORDENES_NEW WHERE ST_DESPACHO = 'DESPACHODO' OR ST_DESPACHO = 'PENDIENTE' ) " +
                    "GROUP BY MARCA_PRODUCTO, ST.MINI_CODIGO, PART_NUMBER, STS.STOCK_FINAL ORDER BY PORCENTAJE DESC ";

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    lista = new e_Ventas_Producto();
                    lista.Marca_Producto = (string)reader["MARCA_PRODUCTO"];
                    lista.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    lista.Part_Number = (string)reader["PART_NUMBER"];
                    lista.cantidad = (int)reader["CANTIDAD_PRODUCTOS_VENDIDOS"];
                    lista.stock = (int)reader["STOCK_RESTANTE"];
                    lista.Total_sin_igv = Convert.ToDouble((decimal)reader["SUBTOTAL_S_IGV"]);
                    lista.Total_con_igv = Convert.ToDouble((decimal)reader["TOTAL_C_IGV"]);
                    lista.Porcentaje = Convert.ToDouble((decimal)reader["PORCENTAJE"]);
                    listado.Add(lista);
                }
                reader.Close();
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        //Filtros

        //Filtros del listado del canal, por canal, fecha(dia), st_despacho
        public List<e_Reporte> Lista_Ventas_canal_F(e_Filtros_Reportes obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Reporte> listado = new List<e_Reporte>();
                e_Reporte lista = null;
                string consulta = "SELECT CANAL, COUNT(DISTINCT NUMERO_ORDEN) AS [CANTIDAD DE ORDENES], SUM(CANTIDAD) AS [CANTIDAD DE PRODUCTOS], " +
                    "CONVERT(DECIMAL(20, 2), SUM(TOTAL_S_IGV)) AS [PRECIO SIN IGV], CONVERT(DECIMAL(20, 2), SUM(TOTAL_C_IGV)) AS [PRECIO CON IGV], CONVERT(DECIMAL(10, 2), FORMAT(SUM(TOTAL_C_IGV) * 100.0 / SUM(SUM(TOTAL_C_IGV)) OVER(), 'N')) AS PORCENTAJE FROM ST_CONS_ORDENES_NEW " +
                    "WHERE CANAL LIKE @canal AND Convert(varchar,FECHA_PROCESO,23) LIKE @fecha AND ST_DESPACHO LIKE @st_despacho AND ST_DESPACHO IN (SELECT ST_DESPACHO FROM ST_CONS_ORDENES_NEW WHERE ST_DESPACHO = 'DESPACHODO' OR ST_DESPACHO = 'PENDIENTE' ) GROUP BY CANAL ORDER BY [PRECIO CON IGV] DESC";

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                cmd_0.Parameters.AddWithValue("@canal", "%" + obj.Canal + "%");
                cmd_0.Parameters.AddWithValue("@fecha", "%" + obj.Fecha_Proceso + "%");
                cmd_0.Parameters.AddWithValue("@st_despacho", "%" + obj.ST_Despacho + "%");
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    lista = new e_Reporte();
                    lista.canal = (string)reader["CANAL"];
                    lista.cantidad_Ordenes = (int)reader["CANTIDAD DE ORDENES"];
                    lista.cantidad_productos = (int)reader["CANTIDAD DE PRODUCTOS"];
                    lista.precio_sin_igv = Convert.ToDouble((decimal)reader["PRECIO SIN IGV"]);
                    lista.precio_con_igv = Convert.ToDouble((decimal)reader["PRECIO CON IGV"]);
                    lista.porcentaje = Convert.ToDouble((decimal)reader["PORCENTAJE"]);
                    listado.Add(lista);
                }
                reader.Close();
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        //filtros desde DEL CANAL
        public List<e_Reporte> Lista_Ventas_canal_F1(e_Filtros_Reportes obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Reporte> listado = new List<e_Reporte>();
                e_Reporte lista = null;
                string consulta = "SELECT CANAL, COUNT(DISTINCT NUMERO_ORDEN) AS [CANTIDAD DE ORDENES], SUM(CANTIDAD) AS [CANTIDAD DE PRODUCTOS], " +
                    "CONVERT(DECIMAL(20, 2), SUM(TOTAL_S_IGV)) AS [PRECIO SIN IGV], CONVERT(DECIMAL(20, 2), SUM(TOTAL_C_IGV)) AS [PRECIO CON IGV], CONVERT(DECIMAL(10, 2), FORMAT(SUM(TOTAL_C_IGV) * 100.0 / SUM(SUM(TOTAL_C_IGV)) OVER(), 'N')) AS PORCENTAJE FROM ST_CONS_ORDENES_NEW " +
                    "WHERE CANAL LIKE @canal AND FECHA_PROCESO BETWEEN @FechaInicio AND @FechaFin " +
                    "AND ST_DESPACHO LIKE @st_despacho AND ST_DESPACHO IN (SELECT ST_DESPACHO FROM ST_CONS_ORDENES_NEW WHERE ST_DESPACHO = 'DESPACHODO' OR ST_DESPACHO = 'PENDIENTE' ) GROUP BY CANAL ORDER BY [PRECIO CON IGV] DESC";

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                cmd_0.Parameters.AddWithValue("@canal", "%" + obj.Canal + "%");
                cmd_0.Parameters.AddWithValue("@FechaInicio", obj.Fecha_Inicio);
                cmd_0.Parameters.AddWithValue("@FechaFin", obj.Fecha_Fin);
                cmd_0.Parameters.AddWithValue("@st_despacho", "%" + obj.ST_Despacho + "%");
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    lista = new e_Reporte();
                    lista.canal = (string)reader["CANAL"];
                    lista.cantidad_Ordenes = (int)reader["CANTIDAD DE ORDENES"];
                    lista.cantidad_productos = (int)reader["CANTIDAD DE PRODUCTOS"];
                    lista.precio_sin_igv = Convert.ToDouble((decimal)reader["PRECIO SIN IGV"]);
                    lista.precio_con_igv = Convert.ToDouble((decimal)reader["PRECIO CON IGV"]);
                    lista.porcentaje = Convert.ToDouble((decimal)reader["PORCENTAJE"]);
                    listado.Add(lista);
                }
                reader.Close();
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        //FILTROS PRODUCTOS POR 

        public List<e_Ventas_Producto> Lista_Ventas_Producto_F1(e_Filtros_Reportes obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Ventas_Producto> listado = new List<e_Ventas_Producto>();
                e_Ventas_Producto lista = null;
                string consulta = "SELECT MARCA_PRODUCTO, ST.MINI_CODIGO AS MINI_CODIGO, PART_NUMBER,STS.STOCK_FINAL AS STOCK_RESTANTE, SUM(CANTIDAD) AS CANTIDAD_PRODUCTOS_VENDIDOS, CONVERT(DECIMAL(20, 2), SUM(TOTAL_S_IGV)) AS SUBTOTAL_S_IGV,  " +
                    "CONVERT(DECIMAL(20, 2), SUM(TOTAL_C_IGV)) AS TOTAL_C_IGV, CONVERT(DECIMAL(10, 2), FORMAT(SUM(TOTAL_C_IGV) * 100.0 / SUM(SUM(TOTAL_C_IGV)) OVER(), 'N')) AS PORCENTAJE " +
                    "FROM ST_CONS_ORDENES_NEW CO JOIN ST_STOCK  ST ON ST.PARTNUMBER = CO.PART_NUMBER JOIN ST_STOCK_HST_CONSULTA STS ON STS.PARTNUMBER = CO.PART_NUMBER  " +
                    "WHERE CO.CANAL LIKE @canal AND Convert(varchar,CO.FECHA_PROCESO,23) LIKE @fecha AND CO.ST_DESPACHO LIKE @st_despacho AND ST_DESPACHO IN (SELECT ST_DESPACHO FROM ST_CONS_ORDENES_NEW WHERE ST_DESPACHO = 'DESPACHODO' OR ST_DESPACHO = 'PENDIENTE' ) " +
                    "GROUP BY MARCA_PRODUCTO, ST.MINI_CODIGO, PART_NUMBER, STS.STOCK_FINAL  ORDER BY PORCENTAJE DESC";

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                cmd_0.Parameters.AddWithValue("@canal", "%" + obj.Canal + "%");
                cmd_0.Parameters.AddWithValue("@fecha", "%" + obj.Fecha_Proceso + "%");
                cmd_0.Parameters.AddWithValue("@st_despacho", "%" + obj.ST_Despacho + "%");
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    lista = new e_Ventas_Producto();
                    lista.Marca_Producto = (string)reader["MARCA_PRODUCTO"];
                    lista.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    lista.Part_Number = (string)reader["PART_NUMBER"];
                    lista.cantidad = (int)reader["CANTIDAD_PRODUCTOS_VENDIDOS"];
                    lista.stock = (int)reader["STOCK_RESTANTE"];
                    lista.Total_sin_igv = Convert.ToDouble((decimal)reader["SUBTOTAL_S_IGV"]);
                    lista.Total_con_igv = Convert.ToDouble((decimal)reader["TOTAL_C_IGV"]);
                    lista.Porcentaje = Convert.ToDouble((decimal)reader["PORCENTAJE"]);
                    listado.Add(lista);
                }
                reader.Close();
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        //FILTROS DESDE

        public List<e_Ventas_Producto> Lista_Ventas_Producto_F2(e_Filtros_Reportes obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Ventas_Producto> listado = new List<e_Ventas_Producto>();
                e_Ventas_Producto lista = null;
                string consulta = "SELECT MARCA_PRODUCTO, ST.MINI_CODIGO AS MINI_CODIGO, PART_NUMBER,STS.STOCK_FINAL AS STOCK_RESTANTE, SUM(CANTIDAD) AS CANTIDAD_PRODUCTOS_VENDIDOS, CONVERT(DECIMAL(20, 2), SUM(TOTAL_S_IGV)) AS SUBTOTAL_S_IGV,  " +
                    "CONVERT(DECIMAL(20, 2), SUM(TOTAL_C_IGV)) AS TOTAL_C_IGV, CONVERT(DECIMAL(10, 2), FORMAT(SUM(TOTAL_C_IGV) * 100.0 / SUM(SUM(TOTAL_C_IGV)) OVER(), 'N')) AS PORCENTAJE " +
                    "FROM ST_CONS_ORDENES_NEW CO JOIN ST_STOCK  ST ON ST.PARTNUMBER = CO.PART_NUMBER JOIN ST_STOCK_HST_CONSULTA STS ON STS.PARTNUMBER = CO.PART_NUMBER  " +
                    "WHERE CO.CANAL LIKE @canal AND CO.FECHA_PROCESO BETWEEN @FechaInicio AND @FechaFin AND ST_DESPACHO IN (SELECT ST_DESPACHO FROM ST_CONS_ORDENES_NEW WHERE ST_DESPACHO = 'DESPACHODO' OR ST_DESPACHO = 'PENDIENTE' ) " +
                    "AND CO.ST_DESPACHO LIKE @st_despacho GROUP BY MARCA_PRODUCTO, ST.MINI_CODIGO, PART_NUMBER, STS.STOCK_FINAL ORDER BY PORCENTAJE DESC";

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                cmd_0.Parameters.AddWithValue("@canal", "%" + obj.Canal + "%");
                cmd_0.Parameters.AddWithValue("@FechaInicio", obj.Fecha_Inicio);
                cmd_0.Parameters.AddWithValue("@FechaFin", obj.Fecha_Fin);
                cmd_0.Parameters.AddWithValue("@st_despacho", "%" + obj.ST_Despacho + "%");
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    lista = new e_Ventas_Producto();
                    lista.Marca_Producto = (string)reader["MARCA_PRODUCTO"];
                    lista.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    lista.Part_Number = (string)reader["PART_NUMBER"];
                    lista.cantidad = (int)reader["CANTIDAD_PRODUCTOS_VENDIDOS"];
                    lista.stock = (int)reader["STOCK_RESTANTE"];
                    lista.Total_sin_igv = Convert.ToDouble((decimal)reader["SUBTOTAL_S_IGV"]);
                    lista.Total_con_igv = Convert.ToDouble((decimal)reader["TOTAL_C_IGV"]);
                    lista.Porcentaje = Convert.ToDouble((decimal)reader["PORCENTAJE"]);
                    listado.Add(lista);
                }
                reader.Close();
                return listado;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        //public List<e_Consolidados_Saga> Lista_Cons_SAGA()
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_Saga> listado = new List<e_Consolidados_Saga>();
        //        e_Consolidados_Saga saga = null;
        //        string consulta = "SELECT ISNULL(NRO_F12,'-') AS NRO_F12,ISNULL(NRO_OC,'-') AS NRO_OC,ISNULL(FECHA_EMISION_OC,'2021-01-01') AS FECHA_EMISION_OC," +
        //            "FECHA_DESPACHO_PACTADA,ISNULL(NOM_COMPRADOR,'-') AS NOM_COMPRADOR,ISNULL(NOM_RECEPTOR,'-') AS NOM_RECEPTOR,ISNULL(DIRECCION_RECEPTOR,'-') AS DIRECCION_RECEPTOR ," +
        //            "ISNULL(COMUNA_RECEPTOR,'-') AS COMUNA_RECEPTOR,ISNULL(CIUDAD_RECEPTOR,'-') AS CIUDAD_RECEPTOR,ISNULL(TELEFONO_COMPRADOR,'0') AS TELEFONO_COMPRADOR,ISNULL(TELEFONO_RECEPTOR,'0') AS TELEFONO_RECEPTOR,ISNULL(ATENCION,'-') AS ATENCION," +
        //            "ISNULL(OBSERVACION,'-') AS OBSERVACION,ISNULL(UPC,'-') AS UPC,ISNULL(SKU,'-') AS SKU," +
        //            "ISNULL(DESCRIPCION,'-') AS DESCRIPCION,ISNULL(UNIDADES,0) AS UNIDADES,ISNULL(PRECIO_COSTO,0) AS PRECIO_COSTO,ISNULL(EMAIL,'-') AS EMAIL,ISNULL(FECHA_REPARTO_CLIENTE,'2021-01-01') AS FECHA_REPARTO_CLIENTE,ISNULL(REGION,'-') AS REGION,ISNULL(DNI_COMPRADOR,'-') AS DNI_COMPRADOR," +
        //            "FECHA_PROCESO,ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ST_ORDEN,ISNULL(FECHA_ENTREGA,'2020-01-01') AS FECHA_ENTREGA,ISNULL(PART_NUMB_REAL,'-') AS PART_NUMB_REAL" +
        //            ",ISNULL(UNIDADES_REAL,0) AS UNIDADES_REAL,ISNULL(SERIE_FACT,'-') AS SERIE_FACT, ISNULL(NRO_FACT,'-') AS NRO_FACT,ISNULL(NRO_GUIA,'-') AS NRO_GUIA  " +
        //            "FROM OC_SF_CONS";

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            saga = new e_Consolidados_Saga();
        //            saga.NRO_F12 = (string)reader["NRO_F12"];
        //            saga.NRO_OC = (string)reader["NRO_OC"];
        //            saga.FECHA_EMISION_OC = (DateTime)reader["FECHA_EMISION_OC"];
        //            saga.FECHA_DESPACHO_PACTADA = (DateTime)reader["FECHA_DESPACHO_PACTADA"];
        //            saga.NOMBRE_COMPRADOR = (string)reader["NOM_COMPRADOR"];
        //            saga.TELEFONO_COMRPADOR = (string)reader["TELEFONO_COMPRADOR"];
        //            saga.NOMBRE_RECEPTOR = (string)reader["NOM_RECEPTOR"];
        //            saga.DIRECCION_RECEPTOR = (string)reader["DIRECCION_RECEPTOR"];
        //            saga.COMUNA_RECEPTOR = (string)reader["COMUNA_RECEPTOR"];
        //            saga.CIUDAD_RECEPTOR = (string)reader["CIUDAD_RECEPTOR"];
        //            saga.TELEFONO_RECEPTOR = (string)reader["TELEFONO_RECEPTOR"];
        //            saga.ATENCION = (string)reader["ATENCION"];
        //            saga.OBSERVACION = (string)reader["OBSERVACION"];
        //            saga.UPC = (string)reader["UPC"];
        //            saga.SKU = (string)reader["SKU"];
        //            saga.DESCRIPCION = (string)reader["DESCRIPCION"];
        //            saga.UNIDADES = (int)reader["UNIDADES"];
        //            saga.PRECIO_COSTO = (double)reader["PRECIO_COSTO"];
        //            saga.EMAIL = (string)reader["EMAIL"];
        //            saga.FECHA_REAPARTO_CLIENTE = (DateTime)reader["FECHA_REPARTO_CLIENTE"];
        //            saga.REGION = (string)reader["REGION"];
        //            saga.DNI_COMPRADOR = (string)reader["DNI_COMPRADOR"];
        //            saga.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            saga.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            saga.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            saga.FECHA_ENTREGA = (DateTime)reader["FECHA_ENTREGA"];
        //            saga.PARTNUMB_REAL = (string)reader["PART_NUMB_REAL"];
        //            saga.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            saga.SERIE_FACT = (string)reader["SERIE_FACT"];
        //            saga.NRO_FACT = (string)reader["NRO_FACT"];
        //            saga.NRO_GUIA = (string)reader["NRO_GUIA"];
        //            listado.Add(saga);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}

        //public List<e_Consolidados_Linio> Lista_Cons_LINIO()
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_Linio> listado = new List<e_Consolidados_Linio>();
        //        e_Consolidados_Linio linio = null;
        //        string consulta = "SELECT ISNULL(ORDER_ITEM_ID,'-') AS ORDER_ITEM_ID,ISNULL(LINIO_ID,'-') AS LINIO_ID, ISNULL(SELLER_SKU,'-') AS SELLER_SKU, " +
        //            "ISNULL(LINIO_SKU,'-') AS LINIO_SKU,ISNULL(CREATED_AT,'2021-01-01') AS CREATED_AT, ISNULL(ORDER_NUMBER,'-') AS ORDER_NUMBER," +
        //            "ISNULL(CUSTOMER_NAME,'-') AS CUSTOMER_NAME,ISNULL(CUSTOMER_EMAIL,'-') AS CUSTOMER_EMAIL,ISNULL(SHIPPING_NAME,'-') AS SHIPPING_NAME, " +
        //            "CONCAT(SHIPPING_ADDRESS,' ',SHIPPING_ADDRESS_2,' ',SHIPPING_ADDRESS_3,' ',SHIPPING_ADDRESS_4) AS SHIPPING_ADDRESS, " +
        //            "ISNULL(SHIPPING_CITY,'-') AS SHIPPING_CITY, ISNULL(PAID_PRICE,0) AS PAID_PRICE,ISNULL(UNIT_PRICE,0) AS UNIT_PRICE, " +
        //            "ISNULL(SHIPPING_FEE,0) AS SHIPPING_FEE, ISNULL(ITEM_NAME,'-') AS ITEM_NAME,ISNULL(STATUS,'-') AS STATUS, ISNULL(FECHA_PROCESO,'2021-01-01') AS FECHA_PROCESO, " +
        //            "ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ISNULL(ST_ORDEN,'-') AS ST_ORDEN, ISNULL(PART_NUMB_REAL,'-') AS PART_NUMB_REAL,ISNULL(UNIDADES_REAL,0) AS  UNIDADES_REAL " +
        //            "FROM OC_LNO_CONS";

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            linio = new e_Consolidados_Linio();
        //            linio.ORDER_ITEM_ID = (string)reader["ORDER_ITEM_ID"];
        //            linio.LINIO_ID = (string)reader["LINIO_ID"];
        //            linio.SELLER_SKU = (string)reader["SELLER_SKU"];
        //            linio.LINIO_SKU = (string)reader["LINIO_SKU"];
        //            linio.CREATED_AT = (DateTime)reader["CREATED_AT"];
        //            linio.ORDER_NUMBER = (string)reader["ORDER_NUMBER"];
        //            linio.CUSTOMER_NAME = (string)reader["CUSTOMER_NAME"];
        //            linio.CUSTOMER_EMAIL = (string)reader["CUSTOMER_EMAIL"];
        //            linio.SHIPPING_NAME = (string)reader["SHIPPING_NAME"];
        //            linio.SHIPPING_ADDRESS = (string)reader["SHIPPING_ADDRESS"];
        //            linio.SHIPPING_CITY = (string)reader["SHIPPING_CITY"]; 
        //            linio.PAID_PRICE = (double)reader["PAID_PRICE"];
        //            linio.UNIT_PRICE = (double)reader["UNIT_PRICE"];
        //            linio.SHIPPING_FEE = (double)reader["SHIPPING_FEE"];
        //            linio.ITEM_NAME = (string)reader["ITEM_NAME"];
        //            linio.STATUS = (string)reader["STATUS"];
        //            linio.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            linio.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            linio.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            linio.PART_NUMB_REAL = (string)reader["PART_NUMB_REAL"];
        //            linio.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            listado.Add(linio);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}
        //public List<e_Consolidados_Ripley> Lista_Cons_RIPLEY()
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_Ripley> listado = new List<e_Consolidados_Ripley>();
        //        e_Consolidados_Ripley ripley = null;
        //        string consulta = "SELECt ISNULL(FECHA_DE_CREACION,'2021-01-01') As FECHA_DE_CREACION,ISNULL(NRO_PEDIDO,'-') AS NRO_PEDIDO, ISNULL(CANTIDAD,0) AS CANTIDAD," +
        //            " ISNULL(DETALLES,'-') AS DETALLES,ISNULL(DETALLES,'-') AS  ESTADO,ISNULL(IMPORTE,0) AS IMPORTE,ISNULL(MONEDA,'-') AS MONEDA,ISNULL(METODO_ENVIO,'-') AS METODO_ENVIO, " +
        //            "ISNULL(FECHA_DEBITO_CLIENTE,'2021-01-01') AS FECHA_DEBITO_CLIENTE, ISNULL(SKU_TIENDA,'-') As SKU_TIENDA, ISNULL(MOTIVO,'-') As MOTIVO," +
        //            "ISNULL(NRO_ASIENTO_PEDIDO,'-') AS NRO_ASIENTO_PEDIDO, ISNULL(IMPORTE_TOTAL_ENVIO,0) AS IMPORTE_TOTAL_ENVIO, ISNULL(IMPORTE_TOTAL_PEDIDO,0) AS IMPORTE_TOTAL_PEDIDO," +
        //            "ISNULL(FECHA_ENVIO,'2021-01-01') AS FECHA_ENVIO,ISNULL([DIRECCION_ENTREGA: NOMBRE_DE_PILA],'-') AS NOMBRE_DE_PILA, " +
        //            "ISNULL([DIRECCION_ENTREGA: CALLE_1],'-') AS DIRECCION_ENTREGA_CALLE, ISNULL([DIRECCION_ENTREGA: CIUDAD],'-') AS DIRECCION_ENTREGA_CIUDAD," +
        //            "ISNULL([DIRECCION_ENTREGA: TELEFONO],'-') AS DIRECCION_ENTREGA_TELEFONO,ISNULL(FECHA_PROCESO,'2021-01-01') AS FECHA_PROCESO," +
        //            "ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ISNULL(ST_ORDEN,'-') AS ST_ORDEN, ISNULL(PART_NUMB_REAL,'-') AS PARTNUMB_REAL, ISNULL(UNIDADES_REAL,0) AS UNIDADES_REAL  " +
        //            "FROM OC_RPL_CONS";

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ripley = new e_Consolidados_Ripley();
        //            ripley.FECHA_CREACION = (DateTime)reader["FECHA_DE_CREACION"];
        //            ripley.NRO_PEDIDO = (string)reader["NRO_PEDIDO"];
        //            ripley.CANTIDAD = (int)reader["CANTIDAD"];
        //            ripley.DETALLES = (string)reader["DETALLES"];
        //            ripley.IMPORTE = (double)reader["IMPORTE"];
        //            ripley.MONEDA = (string)reader["MONEDA"];
        //            ripley.METODO_ENVIO = (string)reader["METODO_ENVIO"];
        //            ripley.FECHA_DEBITO_CLIENTE = (DateTime)reader["FECHA_DEBITO_CLIENTE"];
        //            ripley.SKU_TIENDA = (string)reader["SKU_TIENDA"];
        //            ripley.MOTIVO = (string)reader["MOTIVO"];
        //            ripley.NRO_ASIENTO_PEDIDO = (string)reader["NRO_ASIENTO_PEDIDO"];
        //            ripley.IMPORTE_TOTAL_ENVIO = (double)reader["IMPORTE_TOTAL_ENVIO"];
        //            ripley.FECHA_ENVIO = (DateTime)reader["FECHA_ENVIO"];
        //            ripley.NOMBRE_DE_PILA = (string)reader["NOMBRE_DE_PILA"];
        //            ripley.DIRECCION_ENTREGA_CALLE = (string)reader["DIRECCION_ENTREGA_CALLE"];
        //            ripley.DIRECCION_ENTREGA_CIUDAD = (string)reader["DIRECCION_ENTREGA_CIUDAD"];
        //            ripley.DIRECCION_ENTREGA_TELEFONO = (string)reader["DIRECCION_ENTREGA_TELEFONO"];
        //            ripley.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            ripley.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            ripley.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            ripley.PARTNUMB_REAL = (string)reader["PARTNUMB_REAL"];
        //            ripley.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            listado.Add(ripley);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}
        //public List<e_Consolidados_RealPlaza> Lista_Cons_REAL_PLAZA()
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_RealPlaza> listado = new List<e_Consolidados_RealPlaza>();
        //        e_Consolidados_RealPlaza realplaza = null;
        //        string consulta = "SELECT ISNULL(NUMERO,'-') AS NUMERO, ISNULL(CLIENTE,'-') AS CLIENTE, ISNULL(TELEFONO_CLIENTE,'-') AS TELEFONO_CLIENTE, " +
        //            "ISNULL(EMAIL_CLIENTE,'-') AS EMAIL_CLIENTE, ISNULL(DIRECCION,'-') AS DIRECCION, ISNULL(DISTRITO,'-') AS DISTRITO,ISNULL(PROVINCIA,'-') AS PROVINCIA," +
        //            " ISNULL(TIPO_DOCUMENTO,'-') AS TIPO_DOCUMENTO, ISNULL(NUMERO_DOCUMENTO,'-') as NUMERO_DOCUMENTO, ISNULL(RUC,'-') AS RUC," +
        //            "ISNULL(RAZON_SOCIAL,'-') AS RAZON_SOCIAL,ISNULL(FECHA,'2021-01-01') AS FECHA,ISNULL(TOTAL,0) AS TOTAl,ISNULL(TOTAL_ITEMS,0) AS TOTAL_ITEMS, " +
        //            "ISNULL(COSTO_TOTAL_ENVIO,0) AS COSTO_TOTAL_ENVIO, ISNULL(TOTAL_COMISION,0) AS TOTAL_COMISION, ISNULL(ESTADO,'-') AS ESTADO, " +
        //            "ISNULL(SITIOS,'-') AS SITIOS, ISNULL(SKU,'-') AS SKU, ISNULL(NOMBRE_SKU,'-') AS NOMBRE_SKU, ISNULL(PRECIO_SKU,0) AS PRECIO_SKU,ISNULL(CANTIDAD_SKU,'-') AS CANTIDAD_SKU, " +
        //            "ISNULL(FECHA_PROCESO,'2021-01-01') AS FECHA_PROCESO, ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO,ISNULL(ST_ORDEN,'-') AS ST_ORDEN, " +
        //            "ISNULL(PARTNUMBER_REAL,'-') AS PARTNUMB_REAL, ISNULL(UNIDADES_REAL,0) AS UNIDADES_REAL FROM OC_RPG_CONS";

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            realplaza = new e_Consolidados_RealPlaza();
        //            realplaza.NUMERO = (string)reader["NUMERO"];
        //            realplaza.CLIENTE = (string)reader["CLIENTE"];
        //            realplaza.TELEFONO_CLIENTE = (string)reader["TELEFONO_CLIENTE"];
        //            realplaza.E_MAIL_CLIENTE = (string)reader["EMAIL_CLIENTE"];
        //            realplaza.DIRECCION = (string)reader["DIRECCION"];
        //            realplaza.DISTRITO = (string)reader["DISTRITO"];
        //            realplaza.PROVINCIA = (string)reader["PROVINCIA"];
        //            realplaza.TIPO_DOCUMENTO = (string)reader["TIPO_DOCUMENTO"];
        //            realplaza.NUMERO_DOCUMENTO = (string)reader["NUMERO_DOCUMENTO"];
        //            realplaza.RUC = (string)reader["RUC"];
        //            realplaza.RAZON_SOCIAL = (string)reader["RAZON_SOCIAL"];
        //            realplaza.FECHA = (DateTime)reader["FECHA"];
        //            realplaza.TOTAL = Convert.ToDouble((decimal)reader["TOTAL"]);
        //            realplaza.TOTAL_ITEMS = Convert.ToDouble((decimal)reader["TOTAL_ITEMS"]);
        //            realplaza.COSTO_TOTAL_ENVIO = Convert.ToDouble((decimal)reader["COSTO_TOTAL_ENVIO"]);
        //            realplaza.TOTAL_COMISION = Convert.ToDouble((decimal)reader["TOTAL_COMISION"]);
        //            realplaza.PRECIO_SKU = Convert.ToDouble((decimal)reader["PRECIO_SKU"]);
        //            realplaza.ESTADO = (string)reader["ESTADO"];
        //            realplaza.SITIOS = (string)reader["SITIOS"];
        //            realplaza.SKU = (string)reader["SKU"];
        //            realplaza.NOMBRE_SKU = (string)reader["NOMBRE_SKU"];
        //            realplaza.CANTIDAD_SKU = (int)reader["CANTIDAD_SKU"];
        //            realplaza.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            realplaza.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            realplaza.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            realplaza.PARTNUMB_REAL = (string)reader["PARTNUMB_REAL"];
        //            realplaza.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            listado.Add(realplaza);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}
        //public List<e_Consolidados_Kingston> Lista_Cons_KINGSTON()
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_Kingston> listado = new List<e_Consolidados_Kingston>();
        //        e_Consolidados_Kingston kingston = null;
        //        string consulta = "SELECT ISNULL(FECHA_DE_CREACION,'2021-01-01') AS FECHA_DE_CREACION, ISNULL(NRO_PEDIDO,'-') AS NRO_PEDIDO, ISNULL(CANTIDAD,0) AS CANTIDAD, " +
        //            "ISNULL(DETALLES,'-') AS DETALLES, ISNULL(IMPORTE,0) AS IMPORTE, ISNULL(MONEDA,'-') AS MONEDA, ISNULL(METODO_ENVIO,'-') AS METODO_ENVIO," +
        //            "ISNULL(SKU_TIENDA,'-') AS SKU_TIENDA, ISNULL(PRECIO_UNIDAD,0) AS PRECIO_UNIDAD,ISNULL(PRECIO_ENVIO,0) AS PRECIO_ENVIO, ISNULL(IMPORTE_TOTAL_PEDIDO,0) AS IMPORTE_TOTAL_PEDIDO, " +
        //            "ISNULL([VALOR_COMISION_(CON_IMPUESTOS)],0) AS VALOR_COMISION, ISNULL([DIRECCION_ENTREGA: NOMBRE_DE_PILA],'-') AS NOMBRE_DE_PILA," +
        //            "ISNULL([DIRECCION_ENTREGA: CALLE_1],'-') AS DIRECCION_ENTREGA,ISNULL([DIRECCION_ENTREGA: CIUDAD],'-') AS CIUDAD_ENTREGA, ISNULL(FECHA_PROCESO,'2021-01-01') " +
        //            "AS FECHA_PROCESO, ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ISNULL(ST_ORDEN,'-') AS ST_ORDEN, ISNULL(PART_NUMB_REAL,'-') AS PART_NUMB_REAL,ISNULL(UNIDADES_REAL,0) AS UNIDADES_REAL " +
        //            "FROM OC_KNG_CONS";

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            kingston = new e_Consolidados_Kingston();
        //            kingston.FECHA_DE_CREACION = (DateTime)reader["FECHA_DE_CREACION"];
        //            kingston.NRO_PEDIDO = (string)reader["NRO_PEDIDO"];
        //            kingston.CANTIDAD = (int)reader["CANTIDAD"];
        //            kingston.DETALLES = (string)reader["DETALLES"];
        //            kingston.IMPORTE = (double)reader["IMPORTE"];
        //            kingston.MONEDA = (string)reader["MONEDA"];
        //            kingston.METODO_DE_ENVIO = (string)reader["METODO_ENVIO"];
        //            kingston.SKU_TIENDA = (string)reader["SKU_TIENDA"];
        //            kingston.PRECIO_UNIDAD = (double)reader["PRECIO_UNIDAD"];
        //            kingston.PRECIO_ENVIO = (double)reader["PRECIO_ENVIO"];
        //            kingston.IMPORTE_TOTAL_PEDIDO = (double)reader["IMPORTE_TOTAL_PEDIDO"];
        //            kingston.VALOR_COMISION = (double)reader["VALOR_COMISION"];
        //            kingston.NOMBRE_DE_PILA = (string)reader["NOMBRE_DE_PILA"];
        //            kingston.DIRECCION_ENTREGA = (string)reader["DIRECCION_ENTREGA"];
        //            kingston.CIUDAD_ENTREGA = (string)reader["CIUDAD_ENTREGA"];
        //            kingston.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            kingston.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            kingston.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            kingston.PARTNUMB_REAL = (string)reader["PART_NUMB_REAL"];
        //            kingston.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            listado.Add(kingston);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}
        //public List<e_Consolidados_Saga> Lista_Cons_SAGA_F(e_Consolidados_Saga obj)
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_Saga> listado = new List<e_Consolidados_Saga>();
        //        e_Consolidados_Saga saga = null;
        //        string consulta = string.Format("SELECT ISNULL(NRO_F12,'-') AS NRO_F12,ISNULL(NRO_OC,'-') AS NRO_OC,ISNULL(FECHA_EMISION_OC,'2021-01-01') AS FECHA_EMISION_OC," +
        //            "FECHA_DESPACHO_PACTADA,ISNULL(NOM_COMPRADOR,'-') AS NOM_COMPRADOR,ISNULL(NOM_RECEPTOR,'-') AS NOM_RECEPTOR,ISNULL(DIRECCION_RECEPTOR,'-') AS DIRECCION_RECEPTOR ," +
        //            "ISNULL(COMUNA_RECEPTOR,'-') AS COMUNA_RECEPTOR,ISNULL(CIUDAD_RECEPTOR,'-') AS CIUDAD_RECEPTOR,ISNULL(TELEFONO_COMPRADOR,'0') AS TELEFONO_COMPRADOR,ISNULL(TELEFONO_RECEPTOR,'0') AS TELEFONO_RECEPTOR,ISNULL(ATENCION,'-') AS ATENCION," +
        //            "ISNULL(OBSERVACION,'-') AS OBSERVACION,ISNULL(UPC,'-') AS UPC,ISNULL(SKU,'-') AS SKU," +
        //            "ISNULL(DESCRIPCION,'-') AS DESCRIPCION,ISNULL(UNIDADES,0) AS UNIDADES,ISNULL(PRECIO_COSTO,0) AS PRECIO_COSTO,ISNULL(EMAIL,'-') AS EMAIL,ISNULL(FECHA_REPARTO_CLIENTE,'2021-01-01') AS FECHA_REPARTO_CLIENTE,ISNULL(REGION,'-') AS REGION,ISNULL(DNI_COMPRADOR,'-') AS DNI_COMPRADOR," +
        //            "FECHA_PROCESO,ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ST_ORDEN,ISNULL(FECHA_ENTREGA,'2020-01-01') AS FECHA_ENTREGA,ISNULL(PART_NUMB_REAL,'-') AS PART_NUMB_REAL" +
        //            ",ISNULL(UNIDADES_REAL,0) AS UNIDADES_REAL,ISNULL(SERIE_FACT,'-') AS SERIE_FACT, ISNULL(NRO_FACT,'-') AS NRO_FACT,ISNULL(NRO_GUIA,'-') AS NRO_GUIA  " +
        //            "FROM OC_SF_CONS WHERE NRO_OC LIKE '%{0}%' AND NOM_COMPRADOR LIKE '%{1}%' AND PART_NUMB_REAL LIKE '%{2}%' AND Convert(varchar,FECHA_PROCESO,23) LIKE '{3}%' " +
        //            "AND DESCRIPCION LIKE '%{4}%'",
        //            obj.NRO_OC,obj.NOMBRE_COMPRADOR,obj.PARTNUMB_REAL,obj.FECHA_FILTRO,obj.DESCRIPCION);

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            saga = new e_Consolidados_Saga();
        //            saga.NRO_F12 = (string)reader["NRO_F12"];
        //            saga.NRO_OC = (string)reader["NRO_OC"];
        //            saga.FECHA_EMISION_OC = (DateTime)reader["FECHA_EMISION_OC"];
        //            saga.FECHA_DESPACHO_PACTADA = (DateTime)reader["FECHA_DESPACHO_PACTADA"];
        //            saga.NOMBRE_COMPRADOR = (string)reader["NOM_COMPRADOR"];
        //            saga.TELEFONO_COMRPADOR = (string)reader["TELEFONO_COMPRADOR"];
        //            saga.NOMBRE_RECEPTOR = (string)reader["NOM_RECEPTOR"];
        //            saga.DIRECCION_RECEPTOR = (string)reader["DIRECCION_RECEPTOR"];
        //            saga.COMUNA_RECEPTOR = (string)reader["COMUNA_RECEPTOR"];
        //            saga.CIUDAD_RECEPTOR = (string)reader["CIUDAD_RECEPTOR"];
        //            saga.TELEFONO_RECEPTOR = (string)reader["TELEFONO_RECEPTOR"];
        //            saga.ATENCION = (string)reader["ATENCION"];
        //            saga.OBSERVACION = (string)reader["OBSERVACION"];
        //            saga.UPC = (string)reader["UPC"];
        //            saga.SKU = (string)reader["SKU"];
        //            saga.DESCRIPCION = (string)reader["DESCRIPCION"];
        //            saga.UNIDADES = (int)reader["UNIDADES"];
        //            saga.PRECIO_COSTO = (double)reader["PRECIO_COSTO"];
        //            saga.EMAIL = (string)reader["EMAIL"];
        //            saga.FECHA_REAPARTO_CLIENTE = (DateTime)reader["FECHA_REPARTO_CLIENTE"];
        //            saga.REGION = (string)reader["REGION"];
        //            saga.DNI_COMPRADOR = (string)reader["DNI_COMPRADOR"];
        //            saga.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            saga.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            saga.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            saga.FECHA_ENTREGA = (DateTime)reader["FECHA_ENTREGA"];
        //            saga.PARTNUMB_REAL = (string)reader["PART_NUMB_REAL"];
        //            saga.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            saga.SERIE_FACT = (string)reader["SERIE_FACT"];
        //            saga.NRO_FACT = (string)reader["NRO_FACT"];
        //            saga.NRO_GUIA = (string)reader["NRO_GUIA"];
        //            listado.Add(saga);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}

        //public List<e_Consolidados_Linio> Lista_Cons_LINIO_F(e_Consolidados_Linio obj)
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_Linio> listado = new List<e_Consolidados_Linio>();
        //        e_Consolidados_Linio linio = null;
        //        string consulta = string.Format("SELECT ISNULL(ORDER_ITEM_ID,'-') AS ORDER_ITEM_ID,ISNULL(LINIO_ID,'-') AS LINIO_ID, ISNULL(SELLER_SKU,'-') AS SELLER_SKU, " +
        //            "ISNULL(LINIO_SKU,'-') AS LINIO_SKU,ISNULL(CREATED_AT,'2021-01-01') AS CREATED_AT, ISNULL(ORDER_NUMBER,'-') AS ORDER_NUMBER," +
        //            "ISNULL(CUSTOMER_NAME,'-') AS CUSTOMER_NAME,ISNULL(CUSTOMER_EMAIL,'-') AS CUSTOMER_EMAIL,ISNULL(SHIPPING_NAME,'-') AS SHIPPING_NAME, " +
        //            "CONCAT(SHIPPING_ADDRESS,' ',SHIPPING_ADDRESS_2,' ',SHIPPING_ADDRESS_3,' ',SHIPPING_ADDRESS_4) AS SHIPPING_ADDRESS, " +
        //            "ISNULL(SHIPPING_CITY,'-') AS SHIPPING_CITY, ISNULL(PAID_PRICE,0) AS PAID_PRICE,ISNULL(UNIT_PRICE,0) AS UNIT_PRICE, " +
        //            "ISNULL(SHIPPING_FEE,0) AS SHIPPING_FEE, ISNULL(ITEM_NAME,'-') AS ITEM_NAME,ISNULL(STATUS,'-') AS STATUS, ISNULL(FECHA_PROCESO,'2021-01-01') AS FECHA_PROCESO, " +
        //            "ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ISNULL(ST_ORDEN,'-') AS ST_ORDEN, ISNULL(PART_NUMB_REAL,'-') AS PART_NUMB_REAL,ISNULL(UNIDADES_REAL,0) AS  UNIDADES_REAL " +
        //            "FROM OC_LNO_CONS WHERE ORDER_NUMBER LIKE '%{0}%' AND CUSTOMER_NAME LIKE '%{1}%' AND PART_NUMB_REAL LIKE '%{2}%' AND Convert(varchar,FECHA_PROCESO,23) LIKE '{3}%' " +
        //            "AND ITEM_NAME LIKE '%{4}%'",
        //            obj.ORDER_NUMBER,obj.CUSTOMER_NAME,obj.PART_NUMB_REAL,obj.FECHA_FILTRO,obj.ITEM_NAME);

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            linio = new e_Consolidados_Linio();
        //            linio.ORDER_ITEM_ID = (string)reader["ORDER_ITEM_ID"];
        //            linio.LINIO_ID = (string)reader["LINIO_ID"];
        //            linio.SELLER_SKU = (string)reader["SELLER_SKU"];
        //            linio.LINIO_SKU = (string)reader["LINIO_SKU"];
        //            linio.CREATED_AT = (DateTime)reader["CREATED_AT"];
        //            linio.ORDER_NUMBER = (string)reader["ORDER_NUMBER"];
        //            linio.CUSTOMER_NAME = (string)reader["CUSTOMER_NAME"];
        //            linio.CUSTOMER_EMAIL = (string)reader["CUSTOMER_EMAIL"];
        //            linio.SHIPPING_NAME = (string)reader["SHIPPING_NAME"];
        //            linio.SHIPPING_ADDRESS = (string)reader["SHIPPING_ADDRESS"];
        //            linio.SHIPPING_CITY = (string)reader["SHIPPING_CITY"];
        //            linio.PAID_PRICE = (double)reader["PAID_PRICE"];
        //            linio.UNIT_PRICE = (double)reader["UNIT_PRICE"];
        //            linio.SHIPPING_FEE = (double)reader["SHIPPING_FEE"];
        //            linio.ITEM_NAME = (string)reader["ITEM_NAME"];
        //            linio.STATUS = (string)reader["STATUS"];
        //            linio.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            linio.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            linio.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            linio.PART_NUMB_REAL = (string)reader["PART_NUMB_REAL"];
        //            linio.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            listado.Add(linio);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}
        //public List<e_Consolidados_Ripley> Lista_Cons_RIPLEY_F(e_Consolidados_Ripley obj)
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_Ripley> listado = new List<e_Consolidados_Ripley>();
        //        e_Consolidados_Ripley ripley = null;
        //        string consulta = string.Format("SELECt ISNULL(FECHA_DE_CREACION,'2021-01-01') As FECHA_DE_CREACION,ISNULL(NRO_PEDIDO,'-') AS NRO_PEDIDO, ISNULL(CANTIDAD,0) AS CANTIDAD," +
        //            " ISNULL(DETALLES,'-') AS DETALLES,ISNULL(DETALLES,'-') AS  ESTADO,ISNULL(IMPORTE,0) AS IMPORTE,ISNULL(MONEDA,'-') AS MONEDA,ISNULL(METODO_ENVIO,'-') AS METODO_ENVIO, " +
        //            "ISNULL(FECHA_DEBITO_CLIENTE,'2021-01-01') AS FECHA_DEBITO_CLIENTE, ISNULL(SKU_TIENDA,'-') As SKU_TIENDA, ISNULL(MOTIVO,'-') As MOTIVO," +
        //            "ISNULL(NRO_ASIENTO_PEDIDO,'-') AS NRO_ASIENTO_PEDIDO, ISNULL(IMPORTE_TOTAL_ENVIO,0) AS IMPORTE_TOTAL_ENVIO, ISNULL(IMPORTE_TOTAL_PEDIDO,0) AS IMPORTE_TOTAL_PEDIDO," +
        //            "ISNULL(FECHA_ENVIO,'2021-01-01') AS FECHA_ENVIO,ISNULL([DIRECCION_ENTREGA: NOMBRE_DE_PILA],'-') AS NOMBRE_DE_PILA, " +
        //            "ISNULL([DIRECCION_ENTREGA: CALLE_1],'-') AS DIRECCION_ENTREGA_CALLE, ISNULL([DIRECCION_ENTREGA: CIUDAD],'-') AS DIRECCION_ENTREGA_CIUDAD," +
        //            "ISNULL([DIRECCION_ENTREGA: TELEFONO],'-') AS DIRECCION_ENTREGA_TELEFONO,ISNULL(FECHA_PROCESO,'2021-01-01') AS FECHA_PROCESO," +
        //            "ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ISNULL(ST_ORDEN,'-') AS ST_ORDEN, ISNULL(PART_NUMB_REAL,'-') AS PARTNUMB_REAL, ISNULL(UNIDADES_REAL,0) AS UNIDADES_REAL  " +
        //            "FROM OC_RPL_CONS WHERE NRO_PEDIDO LIKE '%{0}%' AND [DIRECCION_ENTREGA: NOMBRE_DE_PILA] LIKE '%{1}%' AND PART_NUMB_REAL LIKE '%{2}%' AND Convert(varchar,FECHA_PROCESO,23) LIKE '{3}%' " +
        //            "AND DETALLES LIKE '%{4}%'",
        //            obj.NRO_PEDIDO,obj.NOMBRE_DE_PILA,obj.PARTNUMB_REAL,obj.FECHA_FILTRO,obj.DETALLES);

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ripley = new e_Consolidados_Ripley();
        //            ripley.FECHA_CREACION = (DateTime)reader["FECHA_DE_CREACION"];
        //            ripley.NRO_PEDIDO = (string)reader["NRO_PEDIDO"];
        //            ripley.CANTIDAD = (int)reader["CANTIDAD"];
        //            ripley.DETALLES = (string)reader["DETALLES"];
        //            ripley.IMPORTE = (double)reader["IMPORTE"];
        //            ripley.MONEDA = (string)reader["MONEDA"];
        //            ripley.METODO_ENVIO = (string)reader["METODO_ENVIO"];
        //            ripley.FECHA_DEBITO_CLIENTE = (DateTime)reader["FECHA_DEBITO_CLIENTE"];
        //            ripley.SKU_TIENDA = (string)reader["SKU_TIENDA"];
        //            ripley.MOTIVO = (string)reader["MOTIVO"];
        //            ripley.NRO_ASIENTO_PEDIDO = (string)reader["NRO_ASIENTO_PEDIDO"];
        //            ripley.IMPORTE_TOTAL_ENVIO = (double)reader["IMPORTE_TOTAL_ENVIO"];
        //            ripley.FECHA_ENVIO = (DateTime)reader["FECHA_ENVIO"];
        //            ripley.NOMBRE_DE_PILA = (string)reader["NOMBRE_DE_PILA"];
        //            ripley.DIRECCION_ENTREGA_CALLE = (string)reader["DIRECCION_ENTREGA_CALLE"];
        //            ripley.DIRECCION_ENTREGA_CIUDAD = (string)reader["DIRECCION_ENTREGA_CIUDAD"];
        //            ripley.DIRECCION_ENTREGA_TELEFONO = (string)reader["DIRECCION_ENTREGA_TELEFONO"];
        //            ripley.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            ripley.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            ripley.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            ripley.PARTNUMB_REAL = (string)reader["PARTNUMB_REAL"];
        //            ripley.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            listado.Add(ripley);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}
        //public List<e_Consolidados_RealPlaza> Lista_Cons_REAL_PLAZA_F(e_Consolidados_RealPlaza obj)
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_RealPlaza> listado = new List<e_Consolidados_RealPlaza>();
        //        e_Consolidados_RealPlaza realplaza = null;
        //        string consulta = string.Format("SELECT ISNULL(NUMERO,'-') AS NUMERO, ISNULL(CLIENTE,'-') AS CLIENTE, ISNULL(TELEFONO_CLIENTE,'-') AS TELEFONO_CLIENTE, " +
        //            "ISNULL(EMAIL_CLIENTE,'-') AS EMAIL_CLIENTE, ISNULL(DIRECCION,'-') AS DIRECCION, ISNULL(DISTRITO,'-') AS DISTRITO,ISNULL(PROVINCIA,'-') AS PROVINCIA," +
        //            " ISNULL(TIPO_DOCUMENTO,'-') AS TIPO_DOCUMENTO, ISNULL(NUMERO_DOCUMENTO,'-') as NUMERO_DOCUMENTO, ISNULL(RUC,'-') AS RUC," +
        //            "ISNULL(RAZON_SOCIAL,'-') AS RAZON_SOCIAL,ISNULL(FECHA,'2021-01-01') AS FECHA,ISNULL(TOTAL,0) AS TOTAl,ISNULL(TOTAL_ITEMS,0) AS TOTAL_ITEMS, " +
        //            "ISNULL(COSTO_TOTAL_ENVIO,0) AS COSTO_TOTAL_ENVIO, ISNULL(TOTAL_COMISION,0) AS TOTAL_COMISION, ISNULL(ESTADO,'-') AS ESTADO, " +
        //            "ISNULL(SITIOS,'-') AS SITIOS, ISNULL(SKU,'-') AS SKU, ISNULL(NOMBRE_SKU,'-') AS NOMBRE_SKU, ISNULL(PRECIO_SKU,0) AS PRECIO_SKU,ISNULL(CANTIDAD_SKU,'-') AS CANTIDAD_SKU, " +
        //            "ISNULL(FECHA_PROCESO,'2021-01-01') AS FECHA_PROCESO, ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO,ISNULL(ST_ORDEN,'-') AS ST_ORDEN, " +
        //            "ISNULL(PARTNUMBER_REAL,'-') AS PARTNUMB_REAL, ISNULL(UNIDADES_REAL,0) AS UNIDADES_REAL FROM OC_RPG_CONS WHERE NUMERO LIKE '%{0}%' AND CLIENTE LIKE '%{1}%' AND  PARTNUMBER_REAL LIKE '%{2}%'" +
        //            " AND Convert(varchar,FECHA_PROCESO,23) LIKE '{3}%' AND NOMBRE_SKU LIKE '%{4}%'", obj.NUMERO,obj.CLIENTE,obj.PARTNUMB_REAL,obj.FECHA_FILTRO,obj.NOMBRE_SKU);

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            realplaza = new e_Consolidados_RealPlaza();
        //            realplaza.NUMERO = (string)reader["NUMERO"];
        //            realplaza.CLIENTE = (string)reader["CLIENTE"];
        //            realplaza.TELEFONO_CLIENTE = (string)reader["TELEFONO_CLIENTE"];
        //            realplaza.E_MAIL_CLIENTE = (string)reader["EMAIL_CLIENTE"];
        //            realplaza.DIRECCION = (string)reader["DIRECCION"];
        //            realplaza.DISTRITO = (string)reader["DISTRITO"];
        //            realplaza.PROVINCIA = (string)reader["PROVINCIA"];
        //            realplaza.TIPO_DOCUMENTO = (string)reader["TIPO_DOCUMENTO"];
        //            realplaza.NUMERO_DOCUMENTO = (string)reader["NUMERO_DOCUMENTO"];
        //            realplaza.RUC = (string)reader["RUC"];
        //            realplaza.RAZON_SOCIAL = (string)reader["RAZON_SOCIAL"];
        //            realplaza.FECHA = (DateTime)reader["FECHA"];
        //            realplaza.TOTAL = Convert.ToDouble((decimal)reader["TOTAL"]);
        //            realplaza.TOTAL_ITEMS = Convert.ToDouble((decimal)reader["TOTAL_ITEMS"]);
        //            realplaza.COSTO_TOTAL_ENVIO = Convert.ToDouble((decimal)reader["COSTO_TOTAL_ENVIO"]);
        //            realplaza.TOTAL_COMISION = Convert.ToDouble((decimal)reader["TOTAL_COMISION"]);
        //            realplaza.PRECIO_SKU = Convert.ToDouble((decimal)reader["PRECIO_SKU"]);
        //            realplaza.ESTADO = (string)reader["ESTADO"];
        //            realplaza.SITIOS = (string)reader["SITIOS"];
        //            realplaza.SKU = (string)reader["SKU"];
        //            realplaza.NOMBRE_SKU = (string)reader["NOMBRE_SKU"];
        //            realplaza.CANTIDAD_SKU = (int)reader["CANTIDAD_SKU"];
        //            realplaza.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            realplaza.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            realplaza.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            realplaza.PARTNUMB_REAL = (string)reader["PARTNUMB_REAL"];
        //            realplaza.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            listado.Add(realplaza);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}

        //public List<e_Consolidados_Kingston> Lista_Cons_KINGSTON_F(e_Consolidados_Kingston obj)
        //{
        //    try
        //    {
        //        SqlConnection con = db_st.Conecta_DB();
        //        List<e_Consolidados_Kingston> listado = new List<e_Consolidados_Kingston>();
        //        e_Consolidados_Kingston kingston = null;
        //        string consulta = string.Format("SELECT ISNULL(FECHA_DE_CREACION,'2021-01-01') AS FECHA_DE_CREACION, ISNULL(NRO_PEDIDO,'-') AS NRO_PEDIDO, ISNULL(CANTIDAD,0) AS CANTIDAD, " +
        //            "ISNULL(DETALLES,'-') AS DETALLES, ISNULL(IMPORTE,0) AS IMPORTE, ISNULL(MONEDA,'-') AS MONEDA, ISNULL(METODO_ENVIO,'-') AS METODO_ENVIO," +
        //            "ISNULL(SKU_TIENDA,'-') AS SKU_TIENDA, ISNULL(PRECIO_UNIDAD,0) AS PRECIO_UNIDAD,ISNULL(PRECIO_ENVIO,0) AS PRECIO_ENVIO, ISNULL(IMPORTE_TOTAL_PEDIDO,0) AS IMPORTE_TOTAL_PEDIDO, " +
        //            "ISNULL([VALOR_COMISION_(CON_IMPUESTOS)],0) AS VALOR_COMISION, ISNULL([DIRECCION_ENTREGA: NOMBRE_DE_PILA],'-') AS NOMBRE_DE_PILA," +
        //            "ISNULL([DIRECCION_ENTREGA: CALLE_1],'-') AS DIRECCION_ENTREGA,ISNULL([DIRECCION_ENTREGA: CIUDAD],'-') AS CIUDAD_ENTREGA, ISNULL(FECHA_PROCESO,'2021-01-01') " +
        //            "AS FECHA_PROCESO, ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ISNULL(ST_ORDEN,'-') AS ST_ORDEN, ISNULL(PART_NUMB_REAL,'-') AS PART_NUMB_REAL,ISNULL(UNIDADES_REAL,0) AS UNIDADES_REAL " +
        //            "FROM OC_KNG_CONS WHERE NRO_PEDIDO LIKE '%{0}%' AND [DIRECCION_ENTREGA: NOMBRE_DE_PILA] LIKE '%{1}%' AND PART_NUMB_REAL LIKE '%{2}%' AND " +
        //            "Convert(varchar,FECHA_PROCESO,23) LIKE '{3}%' AND DETALLES LIKE '%{4}%'", obj.NRO_PEDIDO,obj.NOMBRE_DE_PILA,obj.PARTNUMB_REAL,obj.FECHA_PROCESO,obj.DETALLES);

        //        SqlCommand cmd_0 = new SqlCommand(consulta, con);
        //        SqlDataReader reader = cmd_0.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            kingston = new e_Consolidados_Kingston();
        //            kingston.FECHA_DE_CREACION = (DateTime)reader["FECHA_DE_CREACION"];
        //            kingston.NRO_PEDIDO = (string)reader["NRO_PEDIDO"];
        //            kingston.CANTIDAD = (int)reader["CANTIDAD"];
        //            kingston.DETALLES = (string)reader["DETALLES"];
        //            kingston.IMPORTE = (double)reader["IMPORTE"];
        //            kingston.MONEDA = (string)reader["MONEDA"];
        //            kingston.METODO_DE_ENVIO = (string)reader["METODO_ENVIO"];
        //            kingston.SKU_TIENDA = (string)reader["SKU_TIENDA"];
        //            kingston.PRECIO_UNIDAD = (double)reader["PRECIO_UNIDAD"];
        //            kingston.PRECIO_ENVIO = (double)reader["PRECIO_ENVIO"];
        //            kingston.IMPORTE_TOTAL_PEDIDO = (double)reader["IMPORTE_TOTAL_PEDIDO"];
        //            kingston.VALOR_COMISION = (double)reader["VALOR_COMISION"];
        //            kingston.NOMBRE_DE_PILA = (string)reader["NOMBRE_DE_PILA"];
        //            kingston.DIRECCION_ENTREGA = (string)reader["DIRECCION_ENTREGA"];
        //            kingston.CIUDAD_ENTREGA = (string)reader["CIUDAD_ENTREGA"];
        //            kingston.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
        //            kingston.ST_DESPACHO = (string)reader["ST_DESPACHO"];
        //            kingston.ST_ORDEN = (string)reader["ST_ORDEN"];
        //            kingston.PARTNUMB_REAL = (string)reader["PART_NUMB_REAL"];
        //            kingston.UNIDADES_REAL = (int)reader["UNIDADES_REAL"];
        //            listado.Add(kingston);
        //        }
        //        reader.Close();
        //        return listado;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        db_st.Desconecta_DB();
        //    }
        //}
    }
}
