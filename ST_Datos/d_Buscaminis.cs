using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_Buscaminis
    {
        d_SQLcon db_conect = new d_SQLcon();

        public List<e_Buscaminis> Lista_minicods(e_Buscaminis obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Buscaminis> lista_minis = new List<e_Buscaminis>();
                e_Buscaminis minis = null;
                string consulta = string.Format("SELECT distinct S.STOCK_FINAL,S.MINI_CODIGO,S.PARTNUMBER,S.TITULO,S.MARCA,ISNULL(ENT.NOM_PROVEEDOR,'-') AS NOM_PROVEEDOR, ISNULL(ENT.FECHA_ENTRADA,0000-00-00) AS FECHA_ENTRADA FROM ST_STOCK_HST_CONSULTA S LEFT JOIN  (SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'USD')Z ON A.MINI_CODIGO = Z.MINICODIGO UNION SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'PEN')Z ON A.MINI_CODIGO = Z.MINICODIGO )ENT  ON S.MINI_CODIGO = ENT.MINICODIGO WHERE S.TITULO LIKE '%{0}%'",
                    obj.Mini_Codigo);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    minis = new e_Buscaminis();
                    minis.Stock = (int)reader["STOCK_FINAL"];
                    minis.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    minis.Partnumber = (string)reader["PARTNUMBER"];
                    minis.Producto = (string)reader["TITULO"];
                    minis.Marca = (string)reader["MARCA"];
                    minis.Proveedor = (string)reader["NOM_PROVEEDOR"];
                    minis.Fecha = (DateTime)reader["FECHA_ENTRADA"];
                    lista_minis.Add(minis);
                }
                reader.Close();
                return lista_minis;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        public List<e_Buscaminis> Lista_titulos(e_Buscaminis obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Buscaminis> lista_minis = new List<e_Buscaminis>();
                e_Buscaminis minis = null;
                string consulta = string.Format("SELECT distinct S.STOCK_FINAL,S.MINI_CODIGO,S.PARTNUMBER,S.TITULO,S.MARCA,ISNULL(ENT.NOM_PROVEEDOR,'-') AS NOM_PROVEEDOR, ISNULL(ENT.FECHA_ENTRADA,0000-00-00) AS FECHA_ENTRADA FROM ST_STOCK_HST_CONSULTA S LEFT JOIN  (SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'USD')Z ON A.MINI_CODIGO = Z.MINICODIGO UNION SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'PEN')Z ON A.MINI_CODIGO = Z.MINICODIGO )ENT  ON S.MINI_CODIGO = ENT.MINICODIGO WHERE S.PARTNUMBER LIKE '%{0}%'",
                    obj.Partnumber);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    minis = new e_Buscaminis();
                    minis.Stock = (int)reader["STOCK_FINAL"];
                    minis.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    minis.Partnumber = (string)reader["PARTNUMBER"];
                    minis.Producto = (string)reader["TITULO"];
                    minis.Marca = (string)reader["MARCA"];
                    minis.Proveedor = (string)reader["NOM_PROVEEDOR"];
                    minis.Fecha = (DateTime)reader["FECHA_ENTRADA"];
                    lista_minis.Add(minis);
                }
                reader.Close();
                return lista_minis;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        public List<e_Buscaminis> Lista_minicods(string filtro)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Buscaminis> lista_minis = new List<e_Buscaminis>();
                e_Buscaminis minis = null;
                string consulta = "SELECT distinct S.STOCK_FINAL,S.MINI_CODIGO,S.PARTNUMBER,S.TITULO,S.MARCA,ISNULL(ENT.NOM_PROVEEDOR,'-') AS NOM_PROVEEDOR, ISNULL(ENT.FECHA_ENTRADA,0000-00-00) AS FECHA_ENTRADA FROM ST_STOCK_HST_CONSULTA S LEFT JOIN  (SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'USD')Z ON A.MINI_CODIGO = Z.MINICODIGO UNION SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'PEN')Z ON A.MINI_CODIGO = Z.MINICODIGO )ENT  ON S.MINI_CODIGO = ENT.MINICODIGO WHERE S.TITULO LIKE '%" + filtro + "%'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    minis = new e_Buscaminis();
                    minis.Stock = (int)reader["STOCK_FINAL"];
                    minis.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    minis.Partnumber = (string)reader["PARTNUMBER"];
                    minis.Producto = (string)reader["TITULO"];
                    minis.Marca = (string)reader["MARCA"];
                    minis.Proveedor = (string)reader["NOM_PROVEEDOR"];
                    minis.Fecha = (DateTime)reader["FECHA_ENTRADA"];
                    lista_minis.Add(minis);
                }
                reader.Close();
                return lista_minis;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_Buscaminis> Lista_minicods(string filtro, string filtro2)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Buscaminis> lista_minis = new List<e_Buscaminis>();
                e_Buscaminis minis = null;
                string consulta = "SELECT distinct S.STOCK_FINAL,S.MINI_CODIGO,S.PARTNUMBER,S.TITULO,S.MARCA,ISNULL(ENT.NOM_PROVEEDOR,'-') AS NOM_PROVEEDOR, ISNULL(ENT.FECHA_ENTRADA,0000-00-00) AS FECHA_ENTRADA FROM ST_STOCK_HST_CONSULTA S LEFT JOIN  (SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'USD')Z ON A.MINI_CODIGO = Z.MINICODIGO UNION SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'PEN')Z ON A.MINI_CODIGO = Z.MINICODIGO )ENT  ON S.MINI_CODIGO = ENT.MINICODIGO WHERE S.TITULO LIKE '%" + filtro + "%' " +
                    "AND S.TITULO LIKE '%" + filtro2 + "%'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    minis = new e_Buscaminis();
                    minis.Stock = (int)reader["STOCK_FINAL"];
                    minis.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    minis.Partnumber = (string)reader["PARTNUMBER"];
                    minis.Producto = (string)reader["TITULO"];
                    minis.Marca = (string)reader["MARCA"];
                    minis.Proveedor = (string)reader["NOM_PROVEEDOR"];
                    minis.Fecha = (DateTime)reader["FECHA_ENTRADA"];
                    lista_minis.Add(minis);
                }
                reader.Close();
                return lista_minis;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_Buscaminis> Lista_minicods(string filtro, string filtro2, string filtro3)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Buscaminis> lista_minis = new List<e_Buscaminis>();
                e_Buscaminis minis = null;
                string consulta = "SELECT distinct S.STOCK_FINAL,S.MINI_CODIGO,S.PARTNUMBER,S.TITULO,S.MARCA,ISNULL(ENT.NOM_PROVEEDOR,'-') AS NOM_PROVEEDOR, ISNULL(ENT.FECHA_ENTRADA,0000-00-00) AS FECHA_ENTRADA FROM ST_STOCK_HST_CONSULTA S LEFT JOIN  (SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'USD')Z ON A.MINI_CODIGO = Z.MINICODIGO UNION SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'PEN')Z ON A.MINI_CODIGO = Z.MINICODIGO )ENT  ON S.MINI_CODIGO = ENT.MINICODIGO WHERE S.TITULO LIKE '%" + filtro + "%'" +
                    " AND S.TITULO LIKE '%" + filtro2 + "%' AND S.TITULO LIKE '%" + filtro3 + "%'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    minis = new e_Buscaminis();
                    minis.Stock = (int)reader["STOCK_FINAL"];
                    minis.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    minis.Partnumber = (string)reader["PARTNUMBER"];
                    minis.Producto = (string)reader["TITULO"];
                    minis.Marca = (string)reader["MARCA"];
                    minis.Proveedor = (string)reader["NOM_PROVEEDOR"];
                    minis.Fecha = (DateTime)reader["FECHA_ENTRADA"];
                    lista_minis.Add(minis);
                }
                reader.Close();
                return lista_minis;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_Buscaminis> Lista_minicods(string filtro, string filtro2, string filtro3, string filtro4)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Buscaminis> lista_minis = new List<e_Buscaminis>();
                e_Buscaminis minis = null;
                string consulta = "SELECT distinct S.STOCK_FINAL,S.MINI_CODIGO,S.PARTNUMBER,S.TITULO,S.MARCA,ISNULL(ENT.NOM_PROVEEDOR,'-') AS NOM_PROVEEDOR, ISNULL(ENT.FECHA_ENTRADA,0000-00-00) AS FECHA_ENTRADA FROM ST_STOCK_HST_CONSULTA S LEFT JOIN  (SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'USD')Z ON A.MINI_CODIGO = Z.MINICODIGO UNION SELECT * FROM ST_STOCK A JOIN (SELECT A.MINICODIGO,B.NOM_PROVEEDOR,B.PRECIO_UNIT_S_IGV,b.FECHA_ENTRADA FROM (SELECT MINICODIGO,MAX(FECHA_ENTRADA) AS FECHA_ENTRADA FROM ST_ENTRADAS_CONS WHERE TIPO = 'COMPRA'AND PRECIO_UNIT_S_IGV NOT IN (0)GROUP BY MINICODIGO) A JOIN ST_ENTRADAS_CONS B ON A.FECHA_ENTRADA = B.FECHA_ENTRADA WHERE A.MINICODIGO = B.MINICODIGO AND B.PRECIO_UNIT_S_IGV NOT IN (0) AND MONEDA = 'PEN')Z ON A.MINI_CODIGO = Z.MINICODIGO )ENT  ON S.MINI_CODIGO = ENT.MINICODIGO WHERE S.TITULO LIKE '%" + filtro + "%' " +
                    "AND S.TITULO LIKE '%" + filtro2 + "%' AND S.TITULO LIKE '%" + filtro3 + "%' AND S.TITULO LIKE '%" + filtro4 + "%'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    minis = new e_Buscaminis();
                    minis.Stock = (int)reader["STOCK_FINAL"];
                    minis.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    minis.Partnumber = (string)reader["PARTNUMBER"];
                    minis.Producto = (string)reader["TITULO"];
                    minis.Marca = (string)reader["MARCA"];
                    minis.Proveedor = (string)reader["NOM_PROVEEDOR"];
                    minis.Fecha = (DateTime)reader["FECHA_ENTRADA"];
                    lista_minis.Add(minis);
                }
                reader.Close();
                return lista_minis;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        public string MostrarPrecio(string filtro)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string consulta = "SELECT ISNULL(COSTO_U_S_IGV_SOLES,0.0) AS COSTO_U_S_IGV_SOLES, ISNULL(COSTO_U_S_IGV_DOLARES,0.0) AS COSTO_U_S_IGV_DOLARES  FROM ST_STOCK WHERE MINI_CODIGO = '" + filtro + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                string mensaje = "S/:";
                while (reader.Read())
                {
                    decimal number = (decimal)reader["COSTO_U_S_IGV_SOLES"] != 999999 ? (decimal)reader["COSTO_U_S_IGV_SOLES"] : 0;
                    mensaje += Convert.ToString(number);
                    mensaje += "| $:";
                    mensaje += Convert.ToString((decimal)reader["COSTO_U_S_IGV_DOLARES"] != 999999 ? (decimal)reader["COSTO_U_S_IGV_DOLARES"] : 0);
                }
                reader.Close();
                return mensaje;
            }
            catch (Exception e)
            {

                return e.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        public string MostrarPartnumber(string filtro)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string consulta = "SELECT PARTNUMBER FROM ST_STOCK WHERE MINI_CODIGO = '" + filtro + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                string mensaje = "S";
                while (reader.Read())
                {
                    mensaje = (string)reader["PARTNUMBER"];
                }
                reader.Close();
                return mensaje;
            }
            catch (Exception e)
            {

                return e.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
    }
}
