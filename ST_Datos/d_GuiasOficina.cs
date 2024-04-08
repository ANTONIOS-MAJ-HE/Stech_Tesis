using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_GuiasOficina
    {
        d_SQLcon db_conect = new d_SQLcon();

        public List<e_Guias> Lista_Guias(string nro)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Guias> lista_guias = new List<e_Guias>();
                e_Guias guias = null;
                string consulta = "SELECT * FROM ST_GUIAS_OFICINA WHERE NRO_OC ='"+nro+"'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    guias = new e_Guias();
                    guias.NRO_OC = (string)reader["NRO_OC"];
                    guias.SERIE_FACTURA = "";
                    guias.NUMERO_DOCUMENTO_FACTURA = "";
                    guias.TIPO_DOCUMENTO = "";
                    guias.TIPO_DOCUMENTO_CLIENTE = (string)reader["TIPO_DEL_DOCUMENTO_DEL_CLIENTE"];
                    guias.NUMERO_DOCUMENTO = (string)reader["NUMERO_DE_DOCUMENTO"];
                    guias.NOMBRE_CLIENTE = (string)reader["NOMBRE_CLIENTE"];
                    guias.DIRECCION_CLIENTE = (string)reader["DIRECCION"];
                    guias.CORREO = (string)reader["CORREO"];
                    guias.TELEFONO = (string)reader["TELEFONO"];
                    guias.OBSERVACION = (string)reader["OBSERVACIONES"];
                    guias.DESCRIPCION_MOTIVO = (string)reader["DESCRIPCION_DEL_MOTIVO_DEL_TRASLADO"];
                    guias.FECHA_TRASLADO = (string)reader["FECHA_DE_TRASLADO"];
                    guias.PESO = (string)reader["PESO"];
                    guias.UBIGEO_LLEGADA = (string)reader["UBIGEO_DE_LLEGADA"];
                    guias.DIRECCION_LLEGADA = (string)reader["DIRECCION_LLEGADA"];
                    guias.CODIGO_DOMICILIO = (string)reader["CODIGO_DEL_DOMICILIO_DE_LLEGADA"];
                    guias.TIPO_DOCUMENTO_TRANSPORTISTA = (string)reader["TIPO_DOCUMENTO_TRANSPORTISTA"];
                    guias.DOCUMENTO_TRANSPORTISTA = (string)reader["DOCUMENTO_TRANSPORTISTA"];
                    guias.NOMBRE_TRANSPORTISTA = (string)reader["NOMBRE_TRANSPORTISTA"];
                    guias.NUMERO_MTC = (string)reader["NUMERO_MTC"];
                    guias.CODIGO_ITEM_SKU = (string)reader["CODIGO_ITEM"];
                    guias.CANTIDAD = (string)reader["CANTIDAD"];
                    lista_guias.Add(guias);
                }
                reader.Close();
                return lista_guias;
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
        public List<Item> Lista_Item_Guias(string nro)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<Item> lista_items = new List<Item>();
                Item item = null;
                string consulta = "SELECT CODIGO_ITEM,CANTIDAD FROM ST_GUIAS_OFICINA WHERE NRO_OC ='" + nro + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new Item();
                    item.codigo_interno = (string)reader["CODIGO_ITEM"];
                    item.cantidad = Convert.ToInt32((string)reader["CANTIDAD"]);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
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
        public List<Item> Lista_Item_Guias_PRIV(string nro)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<Item> lista_items = new List<Item>();
                Item item = null;
                string consulta = "SELECT CODIGO_ITEM,CANTIDAD FROM ST_GUIAS_OFICINA_PRIV WHERE NRO_OC ='" + nro + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    item = new Item();
                    item.codigo_interno = (string)reader["CODIGO_ITEM"];
                    item.cantidad = Convert.ToInt32((string)reader["CANTIDAD"]);
                    lista_items.Add(item);
                }
                reader.Close();
                return lista_items;
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
        public string IngresarGuia(e_Guias obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string insert = string.Format(" IF NOT EXISTS(SELECT NRO_OC FROM ST_GUIAS_OFICINA WHERE NRO_OC = '{0}') INSERT INTO ST_GUIAS_OFICINA (NRO_OC,SERIE_DE_FACTURA,NUMERO_DOCUMENTO_FACTURA,TIPO_DEL_DOCUMENTO," +
                    "TIPO_DEL_DOCUMENTO_DEL_CLIENTE,NUMERO_DE_DOCUMENTO,NOMBRE_CLIENTE,DIRECCION,CORREO,TELEFONO,OBSERVACIONES," +
                    "DESCRIPCION_DEL_MOTIVO_DEL_TRASLADO,FECHA_DE_TRASLADO,PESO,UBIGEO_DE_LLEGADA,DIRECCION_LLEGADA,CODIGO_DEL_DOMICILIO_DE_LLEGADA," +
                    "TIPO_DOCUMENTO_TRANSPORTISTA,DOCUMENTO_TRANSPORTISTA,NOMBRE_TRANSPORTISTA,NUMERO_MTC,CODIGO_ITEM,CANTIDAD) VALUES " +
                    "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'" +
                    ",'{21}',{22})", obj.NRO_OC,obj.SERIE_FACTURA,obj.NUMERO_DOCUMENTO_FACTURA,obj.TIPO_DOCUMENTO,obj.TIPO_DOCUMENTO_CLIENTE,
                    obj.NUMERO_DOCUMENTO,obj.NOMBRE_CLIENTE,obj.DIRECCION_CLIENTE,obj.CORREO,obj.TELEFONO,obj.OBSERVACION,obj.DESCRIPCION_MOTIVO,
                    obj.FECHA_TRASLADO,obj.PESO,obj.UBIGEO_LLEGADA,obj.DIRECCION_LLEGADA,obj.CODIGO_DOMICILIO,obj.TIPO_DOCUMENTO_TRANSPORTISTA,
                    obj.DOCUMENTO_TRANSPORTISTA,obj.NOMBRE_TRANSPORTISTA,obj.NUMERO_MTC,obj.CODIGO_ITEM_SKU,obj.CANTIDAD);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Guia registrada correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        //Guias Privadas
        public List<e_GuiasPriv> Lista_Guias_Priv(string nro)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_GuiasPriv> lista_guias = new List<e_GuiasPriv>();
                e_GuiasPriv guias = null;
                string consulta = "SELECT * FROM ST_GUIAS_OFICINA_PRIV WHERE NRO_OC ='" + nro + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    guias = new e_GuiasPriv();
                    guias.NRO_OC = (string)reader["NRO_OC"];
                    guias.SERIE_FACTURA = "";
                    guias.NUMERO_DOCUMENTO_FACTURA = "";
                    guias.TIPO_DOCUMENTO = "";
                    guias.TIPO_DOCUMENTO_CLIENTE = (string)reader["TIPO_DEL_DOCUMENTO_DEL_CLIENTE"];
                    guias.NUMERO_DOCUMENTO = (string)reader["NUMERO_DE_DOCUMENTO"];
                    guias.NOMBRE_CLIENTE = (string)reader["NOMBRE_CLIENTE"];
                    guias.DIRECCION_CLIENTE = (string)reader["DIRECCION"];
                    guias.CORREO = (string)reader["CORREO"];
                    guias.TELEFONO = (string)reader["TELEFONO"];
                    guias.OBSERVACION = (string)reader["OBSERVACIONES"];
                    guias.DESCRIPCION_MOTIVO = (string)reader["DESCRIPCION_DEL_MOTIVO_DEL_TRASLADO"];
                    guias.FECHA_TRASLADO = (string)reader["FECHA_DE_TRASLADO"];
                    guias.PESO = (string)reader["PESO"];
                    guias.UBIGEO_LLEGADA = (string)reader["UBIGEO_DE_LLEGADA"];
                    guias.DIRECCION_LLEGADA = (string)reader["DIRECCION_LLEGADA"];
                    guias.CODIGO_DOMICILIO = (string)reader["CODIGO_DEL_DOMICILIO_DE_LLEGADA"];
                    guias.TIPO_DOCUMENTO_CHOFER = (string)reader["TIPO_DOCUMENTO_CHOFER"];
                    guias.DOCUMENTO_CHOFER = (string)reader["DOCUMENTO_CHOFER"];
                    guias.NOMBRE_CHOFER = (string)reader["NOMBRE_CHOFER"];
                    guias.APELLIDO_CHOFER = "";
                    guias.LICENCIA = (string)reader["LICENCIA"];
                    guias.PLACA = (string)reader["PLACA"];
                    guias.CODIGO_ITEM_SKU = (string)reader["CODIGO_ITEM"];
                    guias.CANTIDAD = (string)reader["CANTIDAD"];
                    lista_guias.Add(guias);
                }
                reader.Close();
                return lista_guias;
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
        public string IngresarGuia_Priv(e_GuiasPriv obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string insert = string.Format(" IF NOT EXISTS(SELECT NRO_OC FROM ST_GUIAS_OFICINA_PRIV WHERE NRO_OC = '{0}') " +
                    "INSERT INTO ST_GUIAS_OFICINA_PRIV (NRO_OC,SERIE_DE_FACTURA,NUMERO_DOCUMENTO_FACTURA,TIPO_DEL_DOCUMENTO," +
                    "TIPO_DEL_DOCUMENTO_DEL_CLIENTE,NUMERO_DE_DOCUMENTO,NOMBRE_CLIENTE,DIRECCION,CORREO,TELEFONO,OBSERVACIONES," +
                    "DESCRIPCION_DEL_MOTIVO_DEL_TRASLADO,FECHA_DE_TRASLADO,PESO,UBIGEO_DE_LLEGADA,DIRECCION_LLEGADA,CODIGO_DEL_DOMICILIO_DE_LLEGADA," +
                    "TIPO_DOCUMENTO_CHOFER,DOCUMENTO_CHOFER,NOMBRE_CHOFER,LICENCIA,PLACA,CODIGO_ITEM,CANTIDAD) VALUES " +
                    "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}'" +
                    ",'{21}','{22}',{23})", obj.NRO_OC, obj.SERIE_FACTURA, obj.NUMERO_DOCUMENTO_FACTURA, obj.TIPO_DOCUMENTO, obj.TIPO_DOCUMENTO_CLIENTE,
                    obj.NUMERO_DOCUMENTO, obj.NOMBRE_CLIENTE, obj.DIRECCION_CLIENTE, obj.CORREO, obj.TELEFONO, obj.OBSERVACION, obj.DESCRIPCION_MOTIVO,
                    obj.FECHA_TRASLADO, obj.PESO, obj.UBIGEO_LLEGADA, obj.DIRECCION_LLEGADA, obj.CODIGO_DOMICILIO, obj.TIPO_DOCUMENTO_CHOFER,
                    obj.DOCUMENTO_CHOFER, obj.NOMBRE_CHOFER, obj.LICENCIA,obj.PLACA, obj.CODIGO_ITEM_SKU, obj.CANTIDAD);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Guia registrada correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public string ObtenerOC(string filtro)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string NRO="";
                string get = "SELECT SUBSTRING(NRO_ORDEN,4,8) AS NRO_ORDEN FROM ST_SALIDAS_CONS WHERE TIPO = 'VENTA C/NRO DE PEDIDO' AND NRO_PEDIDO ='" + filtro + "'";
                SqlCommand cmd_0 = new SqlCommand(get, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    NRO = (string)reader["NRO_ORDEN"];
                }
                reader.Close();
                return NRO;

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
    }
}
