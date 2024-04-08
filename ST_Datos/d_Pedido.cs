using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_Pedido
    {
        private d_SQLcon db_st = new d_SQLcon();



        public List<e_Pedido> ListaPedidos()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Pedido> lsta = new List<e_Pedido>();
                e_Pedido pedido = null;
                string consulta = "SELECT convert(int,NRO_PEDIDO) as NRO_PEDIDO, ISNULL(CONVERT(VARCHAR,FECHA_PEDIDO,5),'-') AS FECHA_PEDIDO, CANAL, " +
                    "MINI_CODIGO, PRODUCTO,  CANTIDAD, MONEDA,ISNULL(CONVERT(VARCHAR,PRECIO_UNIT_S_IGV),'-') AS PRECIO_UNIT_S_IGV," +
                    " ISNULL(CLIENTE,'-') AS CLIENTE,  ISNULL(DIRECCION,'-') AS DIRECCION, ISNULL(TIPO_DOC,'-') AS TIPO_DOC, " +
                    "ISNULL(NRO_DOC,'') AS NRO_DOC, ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO,5),'-') AS FECHA_DESPACHO, " +
                    "ISNULL(CONVERT(VARCHAR,SUBTOTAL_S_IGV),'-') AS SUBTOTAL_S_IGV, ISNULL(ST_PEDIDO,'-') AS ST_PEDIDO," +
                    " ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ID_PEDIDO , N_ITEM,ISNULL(COSTO_ENVIO,0.0) AS COSTO_ENVIO FROM ST_PEDIDO_DETALLE ORDER BY ID_PEDIDO DESC";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pedido = new e_Pedido();

                    pedido.Nro_Pedido = (int)reader["NRO_PEDIDO"];
                    pedido.Fecha_pedido = (string)reader["FECHA_PEDIDO"];
                    pedido.Canal = (string)reader["CANAL"];
                    pedido.MiniCod = (string)reader["MINI_CODIGO"];
                    pedido.Producto = (string)reader["PRODUCTO"];
                    pedido.Cantidad = (int)reader["CANTIDAD"];
                    pedido.Moneda = (string)reader["MONEDA"];
                    pedido.Precio_Unit_S_IGV = (string)reader["PRECIO_UNIT_S_IGV"];
                    pedido.Cliente = (string)reader["CLIENTE"];
                    pedido.Direccion = (string)reader["DIRECCION"];
                    pedido.Tipo_Doc = (string)reader["TIPO_DOC"];
                    pedido.Nro_Doc = (string)reader["NRO_DOC"];
                    pedido.Fecha_Despacho = (string)reader["FECHA_DESPACHO"];
                    pedido.Subtotal_S_IGV = (string)reader["SUBTOTAL_S_IGV"];
                    pedido.ST_Despacho = (string)reader["ST_DESPACHO"];
                    pedido.ST_Pedido = (string)reader["ST_PEDIDO"];
                    pedido.Id_Pedido = (int)reader["ID_PEDIDO"];
                    pedido.N_Item = (int)reader["N_ITEM"];
                    pedido.Costo_envio = (double)reader["COSTO_ENVIO"];
                    lsta.Add(pedido);
                }

                reader.Close();

                return lsta;
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
        public List<e_Pedido> ListaPedidos_x_nro_pedido(e_Pedido obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Pedido> lsta = new List<e_Pedido>();
                e_Pedido pedido = null;
                string consulta = string.Format("SELECT convert(int,NRO_PEDIDO) as NRO_PEDIDO, ISNULL(CONVERT(VARCHAR,FECHA_PEDIDO,5),'-') AS FECHA_PEDIDO, CANAL, " +
                    "MINI_CODIGO, PRODUCTO,  CANTIDAD, MONEDA,ISNULL(CONVERT(VARCHAR,PRECIO_UNIT_S_IGV),'-') AS PRECIO_UNIT_S_IGV," +
                    " ISNULL(CLIENTE,'-') AS CLIENTE,  ISNULL(DIRECCION,'-') AS DIRECCION, ISNULL(TIPO_DOC,'-') AS TIPO_DOC, " +
                    "ISNULL(NRO_DOC,'') AS NRO_DOC, ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO,5),'-') AS FECHA_DESPACHO, " +
                    "ISNULL(CONVERT(VARCHAR,SUBTOTAL_S_IGV),'-') AS SUBTOTAL_S_IGV, ISNULL(ST_PEDIDO,'-') AS ST_PEDIDO," +
                    " ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ID_PEDIDO ,  N_ITEM,ISNULL(COSTO_ENVIO,0.0) AS COSTO_ENVIO FROM ST_PEDIDO_DETALLE WHERE NRO_PEDIDO = {0} ORDER BY ID_PEDIDO DESC", obj.Nro_Pedido);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pedido = new e_Pedido();

                    pedido.Nro_Pedido = (int)reader["NRO_PEDIDO"];
                    pedido.Fecha_pedido = (string)reader["FECHA_PEDIDO"];
                    pedido.Canal = (string)reader["CANAL"];
                    pedido.MiniCod = (string)reader["MINI_CODIGO"];
                    pedido.Producto = (string)reader["PRODUCTO"];
                    pedido.Cantidad = (int)reader["CANTIDAD"];
                    pedido.Moneda = (string)reader["MONEDA"];
                    pedido.Precio_Unit_S_IGV = (string)reader["PRECIO_UNIT_S_IGV"];
                    pedido.Cliente = (string)reader["CLIENTE"];
                    pedido.Direccion = (string)reader["DIRECCION"];
                    pedido.Tipo_Doc = (string)reader["TIPO_DOC"];
                    pedido.Nro_Doc = (string)reader["NRO_DOC"];
                    pedido.Fecha_Despacho = (string)reader["FECHA_DESPACHO"];
                    pedido.Subtotal_S_IGV = (string)reader["SUBTOTAL_S_IGV"];
                    pedido.ST_Despacho = (string)reader["ST_DESPACHO"];
                    pedido.ST_Pedido = (string)reader["ST_PEDIDO"];
                    pedido.Id_Pedido = (int)reader["ID_PEDIDO"];
                    pedido.N_Item = (int)reader["N_ITEM"];
                    pedido.Costo_envio = (double)reader["COSTO_ENVIO"];
                    lsta.Add(pedido);
                }

                reader.Close();

                return lsta;
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
        public List<e_Pedido> ListaPedidos_x_cliente(e_Pedido obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Pedido> lsta = new List<e_Pedido>();
                e_Pedido pedido = null;
                string consulta = string.Format("SELECT convert(int,NRO_PEDIDO) as NRO_PEDIDO, ISNULL(CONVERT(VARCHAR,FECHA_PEDIDO,5),'-') AS FECHA_PEDIDO, CANAL, " +
                    "MINI_CODIGO, PRODUCTO,  CANTIDAD, MONEDA,ISNULL(CONVERT(VARCHAR,PRECIO_UNIT_S_IGV),'-') AS PRECIO_UNIT_S_IGV," +
                    " ISNULL(CLIENTE,'-') AS CLIENTE,  ISNULL(DIRECCION,'-') AS DIRECCION, ISNULL(TIPO_DOC,'-') AS TIPO_DOC, " +
                    "ISNULL(NRO_DOC,'') AS NRO_DOC, ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO,5),'-') AS FECHA_DESPACHO, " +
                    "ISNULL(CONVERT(VARCHAR,SUBTOTAL_S_IGV),'-') AS SUBTOTAL_S_IGV, ISNULL(ST_PEDIDO,'-') AS ST_PEDIDO," +
                    " ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ID_PEDIDO, N_ITEM,ISNULL(COSTO_ENVIO,0.0) AS COSTO_ENVIO  FROM ST_PEDIDO_DETALLE WHERE CLIENTE LIKE '%{0}%' ORDER BY ID_PEDIDO DESC", obj.Cliente);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pedido = new e_Pedido();

                    pedido.Nro_Pedido = (int)reader["NRO_PEDIDO"];
                    pedido.Fecha_pedido = (string)reader["FECHA_PEDIDO"];
                    pedido.Canal = (string)reader["CANAL"];
                    pedido.MiniCod = (string)reader["MINI_CODIGO"];
                    pedido.Producto = (string)reader["PRODUCTO"];
                    pedido.Cantidad = (int)reader["CANTIDAD"];
                    pedido.Moneda = (string)reader["MONEDA"];
                    pedido.Precio_Unit_S_IGV = (string)reader["PRECIO_UNIT_S_IGV"];
                    pedido.Cliente = (string)reader["CLIENTE"];
                    pedido.Direccion = (string)reader["DIRECCION"];
                    pedido.Tipo_Doc = (string)reader["TIPO_DOC"];
                    pedido.Nro_Doc = (string)reader["NRO_DOC"];
                    pedido.Fecha_Despacho = (string)reader["FECHA_DESPACHO"];
                    pedido.Subtotal_S_IGV = (string)reader["SUBTOTAL_S_IGV"];
                    pedido.ST_Despacho = (string)reader["ST_DESPACHO"];
                    pedido.ST_Pedido = (string)reader["ST_PEDIDO"];
                    pedido.Id_Pedido = (int)reader["ID_PEDIDO"];
                    pedido.N_Item = (int)reader["N_ITEM"];
                    pedido.Costo_envio = (double)reader["COSTO_ENVIO"];
                    lsta.Add(pedido);
                }

                reader.Close();

                return lsta;
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

        public List<e_Pedido> ListaPedidos_x_fecha(e_Pedido obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Pedido> lsta = new List<e_Pedido>();
                e_Pedido pedido = null;
                string consulta = string.Format("SELECT convert(int,NRO_PEDIDO) as NRO_PEDIDO, ISNULL(CONVERT(VARCHAR,FECHA_PEDIDO,5),'-') AS FECHA_PEDIDO, CANAL, " +
                    "MINI_CODIGO, PRODUCTO,  CANTIDAD, MONEDA,ISNULL(CONVERT(VARCHAR,PRECIO_UNIT_S_IGV),'-') AS PRECIO_UNIT_S_IGV," +
                    " ISNULL(CLIENTE,'-') AS CLIENTE,  ISNULL(DIRECCION,'-') AS DIRECCION, ISNULL(TIPO_DOC,'-') AS TIPO_DOC, " +
                    "ISNULL(NRO_DOC,'') AS NRO_DOC, ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO,5),'-') AS FECHA_DESPACHO, " +
                    "ISNULL(CONVERT(VARCHAR,SUBTOTAL_S_IGV),'-') AS SUBTOTAL_S_IGV, ISNULL(ST_PEDIDO,'-') AS ST_PEDIDO," +
                    " ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ID_PEDIDO , N_ITEM,ISNULL(COSTO_ENVIO,0.0) AS COSTO_ENVIO FROM ST_PEDIDO_DETALLE WHERE concat(substring(convert(varchar,FECHA_PEDIDO,3),0,7),'20',substring(convert(varchar,FECHA_PEDIDO,3),7,2)) = '{0}' ORDER BY ID_PEDIDO DESC", obj.Fecha_pedido);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pedido = new e_Pedido();

                    pedido.Nro_Pedido = (int)reader["NRO_PEDIDO"];
                    pedido.Fecha_pedido = (string)reader["FECHA_PEDIDO"];
                    pedido.Canal = (string)reader["CANAL"];
                    pedido.MiniCod = (string)reader["MINI_CODIGO"];
                    pedido.Producto = (string)reader["PRODUCTO"];
                    pedido.Cantidad = (int)reader["CANTIDAD"];
                    pedido.Moneda = (string)reader["MONEDA"];
                    pedido.Precio_Unit_S_IGV = (string)reader["PRECIO_UNIT_S_IGV"];
                    pedido.Cliente = (string)reader["CLIENTE"];
                    pedido.Direccion = (string)reader["DIRECCION"];
                    pedido.Tipo_Doc = (string)reader["TIPO_DOC"];
                    pedido.Nro_Doc = (string)reader["NRO_DOC"];
                    pedido.Fecha_Despacho = (string)reader["FECHA_DESPACHO"];
                    pedido.Subtotal_S_IGV = (string)reader["SUBTOTAL_S_IGV"];
                    pedido.ST_Despacho = (string)reader["ST_DESPACHO"];
                    pedido.ST_Pedido = (string)reader["ST_PEDIDO"];
                    pedido.Id_Pedido = (int)reader["ID_PEDIDO"];
                    pedido.N_Item = (int)reader["N_ITEM"];
                    pedido.Costo_envio = (double)reader["COSTO_ENVIO"];
                    lsta.Add(pedido);
                }

                reader.Close();

                return lsta;
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
        public List<e_Pedido> ListaPedidos_x_nrodoc(e_Pedido obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Pedido> lsta = new List<e_Pedido>();
                e_Pedido pedido = null;
                string consulta = string.Format("SELECT convert(int,NRO_PEDIDO) as NRO_PEDIDO, ISNULL(CONVERT(VARCHAR,FECHA_PEDIDO,5),'-') AS FECHA_PEDIDO, CANAL, " +
                    "MINI_CODIGO, PRODUCTO,  CANTIDAD, MONEDA,ISNULL(CONVERT(VARCHAR,PRECIO_UNIT_S_IGV),'-') AS PRECIO_UNIT_S_IGV," +
                    " ISNULL(CLIENTE,'-') AS CLIENTE,  ISNULL(DIRECCION,'-') AS DIRECCION, ISNULL(TIPO_DOC,'-') AS TIPO_DOC, " +
                    "ISNULL(NRO_DOC,'') AS NRO_DOC, ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO,5),'-') AS FECHA_DESPACHO, " +
                    "ISNULL(CONVERT(VARCHAR,SUBTOTAL_S_IGV),'-') AS SUBTOTAL_S_IGV, ISNULL(ST_PEDIDO,'-') AS ST_PEDIDO," +
                    " ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO, ID_PEDIDO , N_ITEM,ISNULL(COSTO_ENVIO,0.0) AS COSTO_ENVIO FROM ST_PEDIDO_DETALLE WHERE NRO_DOC = '{0}' ORDER BY ID_PEDIDO DESC", obj.Nro_Doc);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pedido = new e_Pedido();

                    pedido.Nro_Pedido = (int)reader["NRO_PEDIDO"];
                    pedido.Fecha_pedido = (string)reader["FECHA_PEDIDO"];
                    pedido.Canal = (string)reader["CANAL"];
                    pedido.MiniCod = (string)reader["MINI_CODIGO"];
                    pedido.Producto = (string)reader["PRODUCTO"];
                    pedido.Cantidad = (int)reader["CANTIDAD"];
                    pedido.Moneda = (string)reader["MONEDA"];
                    pedido.Precio_Unit_S_IGV = (string)reader["PRECIO_UNIT_S_IGV"];
                    pedido.Cliente = (string)reader["CLIENTE"];
                    pedido.Direccion = (string)reader["DIRECCION"];
                    pedido.Tipo_Doc = (string)reader["TIPO_DOC"];
                    pedido.Nro_Doc = (string)reader["NRO_DOC"];
                    pedido.Fecha_Despacho = (string)reader["FECHA_DESPACHO"];
                    pedido.Subtotal_S_IGV = (string)reader["SUBTOTAL_S_IGV"];
                    pedido.ST_Despacho = (string)reader["ST_DESPACHO"];
                    pedido.ST_Pedido = (string)reader["ST_PEDIDO"];
                    pedido.Id_Pedido = (int)reader["ID_PEDIDO"];
                    pedido.N_Item = (int)reader["N_ITEM"];
                    pedido.Costo_envio = (double)reader["COSTO_ENVIO"];
                    lsta.Add(pedido);
                }

                reader.Close();

                return lsta;
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
        public string IngresarPedido(e_Pedido obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string insert = string.Format("INSERT INTO ST_PD_INPUT (NRO_PEDIDO,FECHA_PEDIDO,CANAL,MINI_CODIGO,PRODUCTO,CANTIDAD," +
                    "MONEDA,PRECIO_UNIT_S_IGV,CLIENTE,DIRECCION,TIPO_DOC,NRO_DOC,FECHA_DESPACHO,SUBTOTAL_S_IGV,N_ITEM,COSTO_ENVIO) VALUES " +
                    "({0},'{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},{15})", obj.Nro_Pedido, obj.Fecha_pedido,
                    obj.Canal, obj.MiniCod, obj.Producto, obj.Cantidad, obj.Moneda, obj.Precio_Unit_S_IGV, obj.Cliente, obj.Direccion, obj.Tipo_Doc,
                    obj.Nro_Doc, obj.Fecha_Despacho, obj.Subtotal_S_IGV, obj.N_Item,obj.Costo_envio);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Pedido registrado correctamente";
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
        public List<e_Pedido> Get_last_pedido()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string consulta = "SELECT convert(int,NRO_PEDIDO) as NRO_PEDIDO, ISNULL(CONVERT(VARCHAR,FECHA_PEDIDO,5),'-') AS FECHA_PEDIDO, CANAL, " +
                    "MINI_CODIGO, PRODUCTO,  CANTIDAD, MONEDA,ISNULL(CONVERT(VARCHAR,PRECIO_UNIT_S_IGV),'-') AS PRECIO_UNIT_S_IGV," +
                    " ISNULL(CLIENTE,'-') AS CLIENTE,  ISNULL(DIRECCION,'-') AS DIRECCION, ISNULL(TIPO_DOC,'-') AS TIPO_DOC, " +
                    "ISNULL(NRO_DOC,'') AS NRO_DOC, ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO,5),'-') AS FECHA_DESPACHO, " +
                    "ISNULL(CONVERT(VARCHAR,SUBTOTAL_S_IGV),'-') AS SUBTOTAL_S_IGV, ISNULL(ST_PEDIDO,'-') AS ST_PEDIDO," +
                    " ISNULL(ST_DESPACHO,'-') AS ST_DESPACHO FROM ST_PEDIDO_DETALLE WHERE NRO_PEDIDO IN (SELECT MAX(convert(int,NRO_PEDIDO)) FROM ST_PEDIDO_DETALLE)";
                List<e_Pedido> ultimo_pedido = new List<e_Pedido>();
                e_Pedido ult_pd = null;
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    ult_pd = new e_Pedido();

                    ult_pd.Nro_Pedido = (int)reader["NRO_PEDIDO"];
                    ultimo_pedido.Add(ult_pd);
                }
                reader.Close();
                return ultimo_pedido;
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

        public List<e_Pedido> Get_last_nitem(e_Pedido obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Pedido> ultimo_pedido = new List<e_Pedido>();
                e_Pedido ult_pd = null;
                string get = string.Format("SELECT  MAX(N_ITEM) as N_ITEM from st_pedido_detalle WHERE NRO_PEDIDO = {0}", obj.Nro_Pedido);
                SqlCommand cmd_0 = new SqlCommand(get, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    ult_pd = new e_Pedido();
                    ult_pd.N_Item = (int)reader["N_ITEM"];
                    ultimo_pedido.Add(ult_pd);

                }
                reader.Close();
                return ultimo_pedido;

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
        public string Ingresar_Cons()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string close = "SET IDENTITY_INSERT ST_PEDIDO_DETALLE OFF";
                string fecha = "UPDATE ST_PD_INPUT SET FECHA_PEDIDO = CONCAT('0',FECHA_PEDIDO) WHERE LEN(FECHA_PEDIDO)= 9 " +
                    "UPDATE ST_PD_INPUT SET FECHA_DESPACHO = CONCAT('0',FECHA_DESPACHO) WHERE LEN(FECHA_DESPACHO)= 9";
                string insert = "INSERT INTO ST_PEDIDO_DETALLE(NRO_PEDIDO,FECHA_PEDIDO,CANAL,MINI_CODIGO,PRODUCTO,CANTIDAD," +
                    "MONEDA,PRECIO_UNIT_S_IGV,CLIENTE,DIRECCION,TIPO_DOC,NRO_DOC,FECHA_DESPACHO,SUBTOTAL_S_IGV, ST_PEDIDO," +
                 "ST_DESPACHO,FECHA_PROCESO,ID_PEDIDO,N_ITEM,COSTO_ENVIO)" +
                    "SELECT NRO_PEDIDO,TRY_CONVERT(DATETIME,CONCAT(SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_PEDIDO))," +
                    "'/',''),5,4),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_PEDIDO)),'/',''),3,2),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_PEDIDO))," +
                    "'/',''),1,2))),CANAL,MINI_CODIGO,PRODUCTO,TRY_CONVERT(INT,CANTIDAD),MONEDA,ISNULL(TRY_convert(DECIMAL(20,4),PRECIO_UNIT_S_IGV),0),CLIENTE,DIRECCION,TIPO_DOC,NRO_DOC," +
                    "TRY_CONVERT(DATETIME,CONCAT(SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_DESPACHO)),'/',''),5,4),SUBSTRING(REPLACE(RTRIM" +
                    "(LTRIM(FECHA_DESPACHO)),'/',''),3,2),SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_DESPACHO)),'/',''),1,2))),ISNULL(TRY_convert(DECIMAL(20,4),SUBTOTAL_S_IGV),0)," +
                    "'RECIBIDO', 'PENDIENTE',GETDATE(),TRY_CONVERT(INT,ID_PEDIDO), TRY_CONVERT(INT,N_ITEM),COSTO_ENVIO FROM ST_PD_INPUT WHERE ID_PEDIDO NOT IN (SELECT ID_PEDIDO FROM ST_PEDIDO_DETALLE)";
                //string open = "SET IDENTITY_INSERT ST_PEDIDO_DETALLE ON";
                //SqlCommand cmd_0 = new SqlCommand(close, con);
                SqlCommand cmd_1 = new SqlCommand(fecha, con);
                SqlCommand cmd_2 = new SqlCommand(insert, con);
                //SqlCommand cmd_3 = new SqlCommand(open, con);
                // cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                // cmd_3.ExecuteNonQuery();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }

        public string Ingresar_Cons_oc()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string insert = "INSERT INTO ST_CONS_ORDENES SELECT 'OFICINA',NULL AS NRO_PEDIDO,A.FECHA_PEDIDO,NULL AS SKU,NULL AS  EAN_UPC,NULL AS  MODELO,A.MINI_CODIGO AS  MINI_CODIGO,NULL AS  PARTNUMBER,A.PRODUCTO,A.CANTIDAD,A.CANTIDAD,NULL,A.PRECIO_UNIT_S_IGV,NULL,A.NRO_DOC,A.CLIENTE,A.DIRECCION,A.FECHA_DESPACHO,A.ST_PEDIDO,A.ST_DESPACHO,NULL AS SERIE_CMP,NULL AS NRO_CMP,NULL AS OBSERVACIONES,GETDATE(),A.NRO_PEDIDO AS NRO_PEDIDO FROM ST_PEDIDO_DETALLE A WHERE A.NRO_PEDIDO NOT IN (SELECT NRO_PEDIDO FROM ST_CONS_ORDENES WHERE CANAL = 'OFICINA')  UPDATE A SET A.EAN_UPC= B.EAN_UPC,A.MODELO = B.MODELO,A.PARTNUMBER = B.PARTNUMBER FROM ST_CONS_ORDENES A , ST_STOCK B WHERE A.MINI_CODIGO = B.MINI_CODIGO AND A.CANAL = 'OFICINA' ";
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return null;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }


        public string Modificar_Cons(e_Pedido obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string modif = string.Format("UPDATE ST_PEDIDO_DETALLE SET CANAL = '{0}',MINI_CODIGO = '{1}',PRODUCTO = '{2}'," +
                    " CANTIDAD = {3},MONEDA = '{4}', PRECIO_UNIT_S_IGV = {5}, CLIENTE = '{6}', DIRECCION = '{7}',TIPO_DOC = '{8}'," +
                    "NRO_DOC = '{9}',COSTO_ENVIO = {11} WHERE ID_PEDIDO = {10}", obj.Canal, obj.MiniCod, obj.Producto, obj.Cantidad, obj.Moneda, obj.Precio_Unit_S_IGV,
                    obj.Cliente, obj.Direccion, obj.Tipo_Doc, obj.Nro_Doc, obj.Id_Pedido,obj.Costo_envio);
                SqlCommand cmd_0 = new SqlCommand(modif, con);
                cmd_0.ExecuteNonQuery();
                return "Pedido modificado con éxito";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_st.Desconecta_DB();
            }
        }
        public List<e_ProductosxPedido> Productos_x_nro_pedido(string nro)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_ProductosxPedido> lsta = new List<e_ProductosxPedido>();
                e_ProductosxPedido pedido = null;
                string consulta = "SELECT  PRODUCTO,  CANTIDAD,P.MINI_CODIGO,ISNULL(PESO,0) AS PESO FROM ST_PEDIDO_DETALLE P " +
                    "JOIN ST_STOCK PN ON p.MINI_CODIGO=pn.MINI_CODIGO WHERE NRO_PEDIDO = '" + nro + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    pedido = new e_ProductosxPedido();

                    pedido.PRODUCTO = (string)reader["PRODUCTO"];
                    pedido.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    pedido.PESO = (double)reader["PESO"];
                    pedido.CANTIDAD = (int)reader["CANTIDAD"];

                    lsta.Add(pedido);
                }

                reader.Close();

                return lsta;
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
