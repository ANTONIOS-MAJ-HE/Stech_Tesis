using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_Act_planta
    {
        d_SQLcon db_st = new d_SQLcon();

        public string Actualizar_planta(e_Planta obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                //string act = string.Format("UPDATE ST_STOCK SET UPC = '{0}',EAN = '{1}',MODELO = '{2}',MINI_CODIGO = '{3}',PARTNUMBER = '{4}',MARCA = '{5}',TIPO = '{6}',TITULO = '{7}',DESCONTINUADO = '{8}',SKU_SAGA = '{9}',SKU_LINIO = '{10}',SKU_RIPLEY = '{11}',SKU_REALPLAZA = '{12}',SKU_JUNTOZ = '{13}',SKU_LUMINGO = '{14}',SKU_SODIMAC = '{15}',SKU_TOTTUS = '{16}',SKU_KINGSTON = '{17}',COSTO_U_S_IGV_DOLARES = '{18}',COSTO_U_S_IGV_SOLES = '{19}', SKU_CATPHONE = '{21}', SKU_MLIBRE = '{22}' WHERE PARTNUMBER = '{20}'",
                //                            obj.UPC,obj.EAN,obj.MODELO,obj.MINI_CODIGO,obj.PARTNUMBER,obj.MARCA,obj.TIPO,obj.TITULO, obj.DESCONTINUADO, obj.SKU_SAGA, obj.SKU_LINIO,obj.SKU_RIPLEY,obj.SKU_REALPLAZA,obj.SKU_JUNTOZ,obj.SKU_LUMINGO,obj.SKU_SODIMAC,obj.SKU_TOTTUS,obj.SKU_KINGSTON,obj.COSTO_U_S_IGV_DOLARES,obj.COSTO_U_S_IGV_SOLES,obj.MANDATORIO,obj.SKU_CATPHONE,obj.SKU_MLIBRE);
                string act = string.Format("UPDATE ST_STOCK SET UPC = '{0}',EAN = '{1}',MODELO = '{2}',MINI_CODIGO = '{3}',PARTNUMBER = '{4}',MARCA = '{5}',TIPO = '{6}',TITULO = '{7}',DESCONTINUADO = '{8}',SKU_SAGA = '{9}',SKU_LINIO = '{10}',SKU_RIPLEY = '{11}',SKU_REALPLAZA = '{12}',SKU_JUNTOZ = '{13}',SKU_LUMINGO = '{14}',SKU_SODIMAC = '{15}',SKU_TOTTUS = '{16}',SKU_KINGSTON = '{17}', SKU_CATPHONE = '{19}', SKU_MLIBRE = '{20}',SKU_COOLBOX ='{21}',SKU_FALABELLA ='{22}' WHERE PARTNUMBER = '{18}'",
                            obj.UPC, obj.EAN, obj.MODELO, obj.MINI_CODIGO, obj.PARTNUMBER, obj.MARCA, obj.TIPO, obj.TITULO, obj.DESCONTINUADO, obj.SKU_SAGA, obj.SKU_LINIO, obj.SKU_RIPLEY, obj.SKU_REALPLAZA, obj.SKU_JUNTOZ, obj.SKU_LUMINGO, obj.SKU_SODIMAC, obj.SKU_TOTTUS, obj.SKU_KINGSTON, obj.MANDATORIO, obj.SKU_CATPHONE, obj.SKU_MLIBRE,obj.SKU_COOLBOX,obj.SKU_FALABELLA);
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
            }
            catch (Exception ex)
            {
                return ex.Message+"ERROR DE QUERY";
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_Planta> Lista_planta_cod(e_Planta obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> lista = new List<e_Planta>();
                e_Planta planta = null;
                string consulta = string.Format("SELECT ISNULL(TRY_CONVERT(VARCHAR,DESCONTINUADO),'') AS DESCONTINUADO, ISNULL(TRY_CONVERT(VARCHAR,MONEDA_1),'') AS MONEDA_1, " +
                    "ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV_DOLARES),'') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV_SOLES),'') AS COSTO_U_S_IGV_SOLES, " +
                    "ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210528),'') AS CORTE_20210528, ISNULL(TRY_CONVERT(VARCHAR,SKU_CATPHONE),'') AS SKU_CATPHONE, " +
                    "ISNULL(TRY_CONVERT(VARCHAR,ST_PRODUCTO),'') AS ST_PRODUCTO, ISNULL(TRY_CONVERT(VARCHAR,SKU_LUMINGO),'') AS SKU_LUMINGO," +
                    " ISNULL(TRY_CONVERT(VARCHAR,SKU_KINGSTON),'') AS SKU_KINGSTON, ISNULL(TRY_CONVERT(VARCHAR,SKU_MLIBRE),'') AS SKU_MLIBRE, " +
                    "ISNULL(TRY_CONVERT(VARCHAR,SKU_REALPLAZA),'') AS SKU_REALPLAZA, ISNULL(TRY_CONVERT(VARCHAR,PROMEDIO_COSTO_S_IGV),'') AS PROMEDIO_COSTO_S_IGV, " +
                    "ISNULL(TRY_CONVERT(VARCHAR,NVO_COSTO_S_IGV),'') AS NVO_COSTO_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV),'') AS COSTO_U_S_IGV, " +
                    "ISNULL(TRY_CONVERT(VARCHAR,MONEDA),'') AS MONEDA, ISNULL(TRY_CONVERT(VARCHAR,REGISTRO),'') AS REGISTRO, ISNULL(TRY_CONVERT(VARCHAR,OBS),'') AS OBS, " +
                    "ISNULL(TRY_CONVERT(VARCHAR,DESCRIPCION),'') AS DESCRIPCION, ISNULL(TRY_CONVERT(VARCHAR,STOCK_INICIAL),'') AS STOCK_INICIAL, " +
                    "TITULO, ISNULL(TRY_CONVERT(VARCHAR,TIPO),'') AS TIPO, ISNULL(TRY_CONVERT(VARCHAR,MARCA),'') AS MARCA, " +
                    "ISNULL(TRY_CONVERT(VARCHAR,PARTNUMBER),'') AS PARTNUMBER, ISNULL(TRY_CONVERT(VARCHAR,MINI_CODIGO),'') AS MINI_CODIGO, ISNULL(TRY_CONVERT(VARCHAR,MODELO),'') AS MODELO, ISNULL(TRY_CONVERT(VARCHAR,EAN_UPC),'') AS EAN_UPC, ISNULL(TRY_CONVERT(VARCHAR,MANDATORIO),'') AS MANDATORIO, ISNULL(TRY_CONVERT(VARCHAR,EAN),'') AS EAN, ISNULL(TRY_CONVERT(VARCHAR,UPC),'') AS UPC, ISNULL(TRY_CONVERT(VARCHAR,SKU_JUNTOZ),'') AS SKU_JUNTOZ, ISNULL(TRY_CONVERT(VARCHAR,SKU_RIPLEY),'') AS SKU_RIPLEY, ISNULL(TRY_CONVERT(VARCHAR,SKU_LINIO),'') AS SKU_LINIO, ISNULL(TRY_CONVERT(VARCHAR,SKU_TOTTUS),'') AS SKU_TOTTUS, ISNULL(TRY_CONVERT(VARCHAR,SKU_SAGA),'') AS SKU_SAGA, ISNULL(TRY_CONVERT(VARCHAR,SKU_SODIMAC),'') AS SKU_SODIMAC, ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE, ISNULL(SKU_MLIBRE,'-') AS MLIBRE,ISNULL(SKU_COOLBOX,'-') AS SKU_COOLBOX  FROM ST_STOCK WHERE CONCAT(MINI_CODIGO,'-',MODELO, '-' , PARTNUMBER),  LIKE '%{0}%'", obj.MODELO);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.TITULO = (string)reader["TITULO"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.UPC = (string)reader["UPC"];
                    planta.EAN = (string)reader["EAN"];
                    planta.DESCONTINUADO = (string)reader["DESCONTINUADO"];

                    lista.Add(planta);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_Planta> Lista_planta_barra(e_Planta obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> lista = new List<e_Planta>();
                e_Planta planta = null;
                string consulta = string.Format("SELECT ISNULL(TRY_CONVERT(VARCHAR,DESCONTINUADO),'') AS DESCONTINUADO, ISNULL(TRY_CONVERT(VARCHAR,MONEDA_1),'') AS MONEDA_1, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV_DOLARES),'') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV_SOLES),'') AS COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210528),'') AS CORTE_20210528, ISNULL(TRY_CONVERT(VARCHAR,SKU_CATPHONE),'') AS SKU_CATPHONE, ISNULL(TRY_CONVERT(VARCHAR,ST_PRODUCTO),'') AS ST_PRODUCTO, ISNULL(TRY_CONVERT(VARCHAR,SKU_LUMINGO),'') AS SKU_LUMINGO, ISNULL(TRY_CONVERT(VARCHAR,SKU_KINGSTON),'') AS SKU_KINGSTON, ISNULL(TRY_CONVERT(VARCHAR,SKU_MLIBRE),'') AS SKU_MLIBRE, ISNULL(TRY_CONVERT(VARCHAR,SKU_REALPLAZA),'') AS SKU_REALPLAZA, ISNULL(TRY_CONVERT(VARCHAR,PROMEDIO_COSTO_S_IGV),'') AS PROMEDIO_COSTO_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,NVO_COSTO_S_IGV),'') AS NVO_COSTO_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV),'') AS COSTO_U_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,MONEDA),'') AS MONEDA, ISNULL(TRY_CONVERT(VARCHAR,REGISTRO),'') AS REGISTRO, ISNULL(TRY_CONVERT(VARCHAR,OBS),'') AS OBS, ISNULL(TRY_CONVERT(VARCHAR,DESCRIPCION),'') AS DESCRIPCION, ISNULL(TRY_CONVERT(VARCHAR,STOCK_INICIAL),'') AS STOCK_INICIAL, TITULO, ISNULL(TRY_CONVERT(VARCHAR,TIPO),'') AS TIPO, ISNULL(TRY_CONVERT(VARCHAR,MARCA),'') AS MARCA, ISNULL(TRY_CONVERT(VARCHAR,PARTNUMBER),'') AS PARTNUMBER, ISNULL(TRY_CONVERT(VARCHAR,MINI_CODIGO),'') AS MINI_CODIGO, ISNULL(TRY_CONVERT(VARCHAR,MODELO),'') AS MODELO, ISNULL(TRY_CONVERT(VARCHAR,EAN_UPC),'') AS EAN_UPC, ISNULL(TRY_CONVERT(VARCHAR,MANDATORIO),'') AS MANDATORIO, ISNULL(TRY_CONVERT(VARCHAR,EAN),'') AS EAN, ISNULL(TRY_CONVERT(VARCHAR,UPC),'') AS UPC, ISNULL(TRY_CONVERT(VARCHAR,SKU_JUNTOZ),'') AS SKU_JUNTOZ, ISNULL(TRY_CONVERT(VARCHAR,SKU_RIPLEY),'') AS SKU_RIPLEY, ISNULL(TRY_CONVERT(VARCHAR,SKU_LINIO),'') AS SKU_LINIO, ISNULL(TRY_CONVERT(VARCHAR,SKU_TOTTUS),'') AS SKU_TOTTUS, ISNULL(TRY_CONVERT(VARCHAR,SKU_SAGA),'') AS SKU_SAGA, ISNULL(TRY_CONVERT(VARCHAR,SKU_SODIMAC),'') AS SKU_SODIMAC, ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE, ISNULL(SKU_MLIBRE,'-') AS MLIBRE,ISNULL(SKU_COOLBOX,'-') AS SKU_COOLBOX FROM ST_STOCK WHERE CONCAT(EAN,'-',UPC) LIKE '%{0}%'", obj.EAN);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.TITULO = (string)reader["TITULO"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.UPC = (string)reader["UPC"];
                    planta.EAN = (string)reader["EAN"];
                    planta.DESCONTINUADO = (string)reader["DESCONTINUADO"];

                    lista.Add(planta);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_Planta> Lista_planta_titulo(e_Planta obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> lista = new List<e_Planta>();
                e_Planta planta = null;
                string consulta = string.Format ("SELECT ISNULL(TRY_CONVERT(VARCHAR,DESCONTINUADO),'') AS DESCONTINUADO, ISNULL(TRY_CONVERT(VARCHAR,MONEDA_1),'') AS MONEDA_1, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV_DOLARES),'') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV_SOLES),'') AS COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210528),'') AS CORTE_20210528, ISNULL(TRY_CONVERT(VARCHAR,SKU_CATPHONE),'') AS SKU_CATPHONE, ISNULL(TRY_CONVERT(VARCHAR,ST_PRODUCTO),'') AS ST_PRODUCTO, ISNULL(TRY_CONVERT(VARCHAR,SKU_LUMINGO),'') AS SKU_LUMINGO, ISNULL(TRY_CONVERT(VARCHAR,SKU_KINGSTON),'') AS SKU_KINGSTON, ISNULL(TRY_CONVERT(VARCHAR,SKU_MLIBRE),'') AS SKU_MLIBRE, ISNULL(TRY_CONVERT(VARCHAR,SKU_REALPLAZA),'') AS SKU_REALPLAZA, ISNULL(TRY_CONVERT(VARCHAR,PROMEDIO_COSTO_S_IGV),'') AS PROMEDIO_COSTO_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,NVO_COSTO_S_IGV),'') AS NVO_COSTO_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV),'') AS COSTO_U_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,MONEDA),'') AS MONEDA, ISNULL(TRY_CONVERT(VARCHAR,REGISTRO),'') AS REGISTRO, ISNULL(TRY_CONVERT(VARCHAR,OBS),'') AS OBS, ISNULL(TRY_CONVERT(VARCHAR,DESCRIPCION),'') AS DESCRIPCION, ISNULL(TRY_CONVERT(VARCHAR,STOCK_INICIAL),'') AS STOCK_INICIAL, TITULO, ISNULL(TRY_CONVERT(VARCHAR,TIPO),'') AS TIPO, ISNULL(TRY_CONVERT(VARCHAR,MARCA),'') AS MARCA, ISNULL(TRY_CONVERT(VARCHAR,PARTNUMBER),'') AS PARTNUMBER, ISNULL(TRY_CONVERT(VARCHAR,MINI_CODIGO),'') AS MINI_CODIGO, ISNULL(TRY_CONVERT(VARCHAR,MODELO),'') AS MODELO, ISNULL(TRY_CONVERT(VARCHAR,EAN_UPC),'') AS EAN_UPC, ISNULL(TRY_CONVERT(VARCHAR,MANDATORIO),'') AS MANDATORIO, ISNULL(TRY_CONVERT(VARCHAR,EAN),'') AS EAN, ISNULL(TRY_CONVERT(VARCHAR,UPC),'') AS UPC, ISNULL(TRY_CONVERT(VARCHAR,SKU_JUNTOZ),'') AS SKU_JUNTOZ, ISNULL(TRY_CONVERT(VARCHAR,SKU_RIPLEY),'') AS SKU_RIPLEY, ISNULL(TRY_CONVERT(VARCHAR,SKU_LINIO),'') AS SKU_LINIO, ISNULL(TRY_CONVERT(VARCHAR,SKU_TOTTUS),'') AS SKU_TOTTUS, ISNULL(TRY_CONVERT(VARCHAR,SKU_SAGA),'') AS SKU_SAGA, ISNULL(TRY_CONVERT(VARCHAR,SKU_SODIMAC),'') AS SKU_SODIMAC, ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE, ISNULL(SKU_MLIBRE,'-') AS MLIBRE,ISNULL(SKU_COOLBOX,'-') AS SKU_COOLBOX FROM ST_STOCK WHERE TITULO LIKE '%{0}%'", obj.TITULO);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.TITULO = (string)reader["TITULO"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.UPC = (string)reader["UPC"];
                    planta.EAN = (string)reader["EAN"];
                    planta.DESCONTINUADO = (string)reader["DESCONTINUADO"];

                    lista.Add(planta);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_Planta>Lista_planta()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> lista = new List<e_Planta>();
                e_Planta planta = null;
                string consulta = "SELECT ISNULL(TRY_CONVERT(VARCHAR,DESCONTINUADO),'') AS DESCONTINUADO, ISNULL(TRY_CONVERT(VARCHAR,MONEDA_1),'') AS MONEDA_1, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV_DOLARES),'') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV_SOLES),'') AS COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210528),'') AS CORTE_20210528, ISNULL(TRY_CONVERT(VARCHAR,SKU_CATPHONE),'') AS SKU_CATPHONE, ISNULL(TRY_CONVERT(VARCHAR,ST_PRODUCTO),'') AS ST_PRODUCTO, ISNULL(TRY_CONVERT(VARCHAR,SKU_LUMINGO),'') AS SKU_LUMINGO, ISNULL(TRY_CONVERT(VARCHAR,SKU_KINGSTON),'') AS SKU_KINGSTON, ISNULL(TRY_CONVERT(VARCHAR,SKU_MLIBRE),'') AS SKU_MLIBRE, ISNULL(TRY_CONVERT(VARCHAR,SKU_REALPLAZA),'') AS SKU_REALPLAZA, ISNULL(TRY_CONVERT(VARCHAR,PROMEDIO_COSTO_S_IGV),'') AS PROMEDIO_COSTO_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,NVO_COSTO_S_IGV),'') AS NVO_COSTO_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,COSTO_U_S_IGV),'') AS COSTO_U_S_IGV, ISNULL(TRY_CONVERT(VARCHAR,MONEDA),'') AS MONEDA, ISNULL(TRY_CONVERT(VARCHAR,REGISTRO),'') AS REGISTRO, ISNULL(TRY_CONVERT(VARCHAR,OBS),'') AS OBS, ISNULL(TRY_CONVERT(VARCHAR,DESCRIPCION),'') AS DESCRIPCION, ISNULL(TRY_CONVERT(VARCHAR,STOCK_INICIAL),'') AS STOCK_INICIAL, TITULO, ISNULL(TRY_CONVERT(VARCHAR,TIPO),'') AS TIPO, ISNULL(TRY_CONVERT(VARCHAR,MARCA),'') AS MARCA, ISNULL(TRY_CONVERT(VARCHAR,PARTNUMBER),'') AS PARTNUMBER, ISNULL(TRY_CONVERT(VARCHAR,MINI_CODIGO),'') AS MINI_CODIGO, ISNULL(TRY_CONVERT(VARCHAR,MODELO),'') AS MODELO, ISNULL(TRY_CONVERT(VARCHAR,EAN_UPC),'') AS EAN_UPC, ISNULL(TRY_CONVERT(VARCHAR,MANDATORIO),'') AS MANDATORIO, ISNULL(TRY_CONVERT(VARCHAR,EAN),'') AS EAN, ISNULL(TRY_CONVERT(VARCHAR,UPC),'') AS UPC, ISNULL(TRY_CONVERT(VARCHAR,SKU_JUNTOZ),'') AS SKU_JUNTOZ, ISNULL(TRY_CONVERT(VARCHAR,SKU_RIPLEY),'') AS SKU_RIPLEY, ISNULL(TRY_CONVERT(VARCHAR,SKU_LINIO),'') AS SKU_LINIO, ISNULL(TRY_CONVERT(VARCHAR,SKU_TOTTUS),'') AS SKU_TOTTUS, ISNULL(TRY_CONVERT(VARCHAR,SKU_SAGA),'') AS SKU_SAGA, ISNULL(TRY_CONVERT(VARCHAR,SKU_SODIMAC),'') AS SKU_SODIMAC, ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE, ISNULL(SKU_MLIBRE,'-') AS MLIBRE,ISNULL(SKU_COOLBOX,'-') AS SKU_COOLBOX FROM ST_STOCK";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.TITULO = (string)reader["TITULO"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.UPC = (string)reader["UPC"];
                    planta.EAN = (string)reader["EAN"];
                    planta.DESCONTINUADO = (string)reader["DESCONTINUADO"];

                    lista.Add(planta);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }


    }
}
