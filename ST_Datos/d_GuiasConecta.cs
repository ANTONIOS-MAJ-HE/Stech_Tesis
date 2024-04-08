using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_GuiasConecta
    {
        d_SQLcon db_conect = new d_SQLcon();
        public List<e_Guias> Listar_guias()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Guias> lista = new List<e_Guias>();
                e_Guias guias = null;
                string consulta = "SELECT DISTINCT SG.NRO_OC,SG.[TIPO DEL DOCUMENTO DEL CLIENTE],SG.[NUMERO DE DOCUMENTO],SG.[NOMBRE CLIENTE],SG.DIRECCION, SG.CORREO, SG.TELEFONO" +
                    ",SG. OBSERVACIONES, SG.[DESCRIPCION DEL MOTIVO DEL TRASLADO], CONVERT(varchar,SG.FECHA_DE_TRASLADO,23) AS FECHA_DE_TRASLADO, SG.PESO, SG.[UBIGEO DE LLEGADA], SG.[DIRECCION LLEGADA], " +
                    "SG.[CODIGO DEL DOMICILIO DE LLEGADA], SG.[TIPO DOCUMENTO TRANSPORTISTA], SG.DOCUMENTO_TRANSPORTISTA,SG.[NOMBRE TRANSPORTISTA], SG.[NUMERO MTC], SG.[CODIGO ITEM(SKU)], " +
                    "SG.CANTIDAD FROM GUIAS_CONECTA_CONS SG LEFT JOIN OC_CONECTA_CONS SF ON SG.NRO_OC=SF.NUMERO_ORDEN WHERE SG.NRO_OC IN (select NUMERO_ORDEN FROM OC_CONECTA_CONS WHERE ST_DESPACHO='PENDIENTE' AND FECHA_ENTREGA  >= CONVERT(datetime, GETDATE()-2)) AND NRO_GUIA IS NULL ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    guias = new e_Guias();
                    guias.NRO_OC = (string)reader["NRO_OC"];
                    guias.SERIE_FACTURA = "";
                    guias.NUMERO_DOCUMENTO_FACTURA = "";
                    guias.TIPO_DOCUMENTO = "";
                    guias.TIPO_DOCUMENTO_CLIENTE = (string)reader["TIPO DEL DOCUMENTO DEL CLIENTE"];
                    guias.NUMERO_DOCUMENTO = (string)reader["NUMERO DE DOCUMENTO"];
                    guias.NOMBRE_CLIENTE = (string)reader["NOMBRE CLIENTE"];
                    guias.DIRECCION_CLIENTE = (string)reader["DIRECCION"];
                    guias.CORREO = (string)reader["CORREO"];
                    guias.TELEFONO = (string)reader["TELEFONO"];
                    guias.OBSERVACION = (string)reader["OBSERVACIONES"];
                    guias.DESCRIPCION_MOTIVO = (string)reader["DESCRIPCION DEL MOTIVO DEL TRASLADO"];
                    guias.FECHA_TRASLADO = (string)reader["FECHA_DE_TRASLADO"];
                    guias.PESO = Convert.ToString((double)reader["PESO"]);
                    guias.UBIGEO_LLEGADA = (string)reader["UBIGEO DE LLEGADA"];
                    guias.DIRECCION_LLEGADA = (string)reader["DIRECCION LLEGADA"];
                    guias.CODIGO_DOMICILIO = (string)reader["CODIGO DEL DOMICILIO DE LLEGADA"];
                    guias.TIPO_DOCUMENTO_TRANSPORTISTA = (string)reader["TIPO DOCUMENTO TRANSPORTISTA"];
                    guias.DOCUMENTO_TRANSPORTISTA = (string)reader["DOCUMENTO_TRANSPORTISTA"];
                    guias.NOMBRE_TRANSPORTISTA = (string)reader["NOMBRE TRANSPORTISTA"];
                    guias.NUMERO_MTC = (string)reader["NUMERO MTC"];
                    guias.CODIGO_ITEM_SKU = (string)reader["CODIGO ITEM(SKU)"];
                    guias.CANTIDAD = Convert.ToString((int)reader["CANTIDAD"]);
                    lista.Add(guias);
                }
                reader.Close();
                return lista;
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
        public List<e_Guias> Listar_guias_NROOC(string Filtro)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Guias> lista = new List<e_Guias>();
                e_Guias guias = null;
                string consulta = "SELECT DISTINCT SG.NRO_OC,SG.[TIPO DEL DOCUMENTO DEL CLIENTE],SG.[NUMERO DE DOCUMENTO],SG.[NOMBRE CLIENTE],SG.DIRECCION, SG.CORREO, " +
                    "SG.TELEFONO ,SG. OBSERVACIONES, SG.[DESCRIPCION DEL MOTIVO DEL TRASLADO], CONVERT(varchar,SG.FECHA_DE_TRASLADO,23) AS FECHA_DE_TRASLADO, SG.PESO, " +
                    "SG.[UBIGEO DE LLEGADA], SG.[DIRECCION LLEGADA], SG.[CODIGO DEL DOMICILIO DE LLEGADA], SG.[TIPO DOCUMENTO TRANSPORTISTA], SG.DOCUMENTO_TRANSPORTISTA," +
                    "SG.[NOMBRE TRANSPORTISTA], SG.[NUMERO MTC], SG.[CODIGO ITEM(SKU)], SG.CANTIDAD, SF.NUMERO_ORDEN FROM GUIAS_CONECTA_CONS SG " +
                    "LEFT JOIN OC_CONECTA_CONS SF ON SG.NRO_OC=SF.NUMERO_ORDEN WHERE SG.NRO_OC = '" + Filtro + "' order by SF.NUMERO_ORDEN";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    guias = new e_Guias();
                    guias.NRO_OC = (string)reader["NRO_OC"];
                    guias.SERIE_FACTURA = "";
                    guias.NUMERO_DOCUMENTO_FACTURA = "";
                    guias.TIPO_DOCUMENTO = "";
                    guias.TIPO_DOCUMENTO_CLIENTE = (string)reader["TIPO DEL DOCUMENTO DEL CLIENTE"];
                    guias.NUMERO_DOCUMENTO = (string)reader["NUMERO DE DOCUMENTO"];
                    guias.NOMBRE_CLIENTE = (string)reader["NOMBRE CLIENTE"];
                    guias.DIRECCION_CLIENTE = (string)reader["DIRECCION"];
                    guias.CORREO = (string)reader["CORREO"];
                    guias.TELEFONO = (string)reader["TELEFONO"];
                    guias.OBSERVACION = (string)reader["OBSERVACIONES"];
                    guias.DESCRIPCION_MOTIVO = (string)reader["DESCRIPCION DEL MOTIVO DEL TRASLADO"];
                    guias.FECHA_TRASLADO = (string)reader["FECHA_DE_TRASLADO"];
                    guias.PESO = Convert.ToString((double)reader["PESO"]);
                    guias.UBIGEO_LLEGADA = (string)reader["UBIGEO DE LLEGADA"];
                    guias.DIRECCION_LLEGADA = (string)reader["DIRECCION LLEGADA"];
                    guias.CODIGO_DOMICILIO = (string)reader["CODIGO DEL DOMICILIO DE LLEGADA"];
                    guias.TIPO_DOCUMENTO_TRANSPORTISTA = (string)reader["TIPO DOCUMENTO TRANSPORTISTA"];
                    guias.DOCUMENTO_TRANSPORTISTA = (string)reader["DOCUMENTO_TRANSPORTISTA"];
                    guias.NOMBRE_TRANSPORTISTA = (string)reader["NOMBRE TRANSPORTISTA"];
                    guias.NUMERO_MTC = (string)reader["NUMERO MTC"];
                    guias.CODIGO_ITEM_SKU = (string)reader["CODIGO ITEM(SKU)"];
                    guias.CANTIDAD = Convert.ToString((int)reader["CANTIDAD"]);
                    lista.Add(guias);
                }
                reader.Close();
                return lista;
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
        public List<e_Guias> Listar_guias_Filtro(string nroOc)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Guias> lista = new List<e_Guias>();
                e_Guias guias = null;
                string consulta = "SELECT NRO_OC,[TIPO DEL DOCUMENTO DEL CLIENTE],[NUMERO DE DOCUMENTO],[NOMBRE CLIENTE],DIRECCION, CORREO, TELEFONO" +
                    ", OBSERVACIONES, [DESCRIPCION DEL MOTIVO DEL TRASLADO], CONVERT(varchar,FECHA_DE_TRASLADO,23) AS FECHA_DE_TRASLADO, PESO, [UBIGEO DE LLEGADA], [DIRECCION LLEGADA], " +
                    "[CODIGO DEL DOMICILIO DE LLEGADA], [TIPO DOCUMENTO TRANSPORTISTA], DOCUMENTO_TRANSPORTISTA,[NOMBRE TRANSPORTISTA], [NUMERO MTC], [CODIGO ITEM(SKU)], " +
                    "CANTIDAD FROM GUIAS_CONECTA_CONS WHERE NRO_OC = '" + nroOc + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    guias = new e_Guias();
                    guias.NRO_OC = (string)reader["NRO_OC"];
                    guias.SERIE_FACTURA = "";
                    guias.NUMERO_DOCUMENTO_FACTURA = "";
                    guias.TIPO_DOCUMENTO = "";
                    guias.TIPO_DOCUMENTO_CLIENTE = (string)reader["TIPO DEL DOCUMENTO DEL CLIENTE"];
                    guias.NUMERO_DOCUMENTO = (string)reader["NUMERO DE DOCUMENTO"];
                    guias.NOMBRE_CLIENTE = (string)reader["NOMBRE CLIENTE"];
                    guias.DIRECCION_CLIENTE = (string)reader["DIRECCION"];
                    guias.CORREO = (string)reader["CORREO"];
                    guias.TELEFONO = (string)reader["TELEFONO"];
                    guias.OBSERVACION = (string)reader["OBSERVACIONES"];
                    guias.DESCRIPCION_MOTIVO = (string)reader["DESCRIPCION DEL MOTIVO DEL TRASLADO"];
                    guias.FECHA_TRASLADO = (string)reader["FECHA_DE_TRASLADO"];
                    guias.PESO = Convert.ToString((double)reader["PESO"]);
                    guias.UBIGEO_LLEGADA = (string)reader["UBIGEO DE LLEGADA"];
                    guias.DIRECCION_LLEGADA = (string)reader["DIRECCION LLEGADA"];
                    guias.CODIGO_DOMICILIO = (string)reader["CODIGO DEL DOMICILIO DE LLEGADA"];
                    guias.TIPO_DOCUMENTO_TRANSPORTISTA = (string)reader["TIPO DOCUMENTO TRANSPORTISTA"];
                    guias.DOCUMENTO_TRANSPORTISTA = (string)reader["DOCUMENTO_TRANSPORTISTA"];
                    guias.NOMBRE_TRANSPORTISTA = (string)reader["NOMBRE TRANSPORTISTA"];
                    guias.NUMERO_MTC = (string)reader["NUMERO MTC"];
                    guias.CODIGO_ITEM_SKU = (string)reader["CODIGO ITEM(SKU)"];
                    guias.CANTIDAD = Convert.ToString((int)reader["CANTIDAD"]);
                    lista.Add(guias);
                }
                reader.Close();
                return lista;
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

        public List<Item> Listar_Saga_Items(string nroOc)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<Item> lista = new List<Item>();
                Item guias = null;
                string consulta = "SELECT [CODIGO ITEM(SKU)], " +
                    "CANTIDAD FROM GUIAS_CONECTA_CONS WHERE NRO_OC = '" + nroOc + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    guias = new Item();
                    guias.codigo_interno = (string)reader["CODIGO ITEM(SKU)"];
                    guias.cantidad = (int)reader["CANTIDAD"];
                    lista.Add(guias);
                }
                reader.Close();
                return lista;
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
        public List<e_Guias> Listar_guias_F(string fecha)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Guias> lista = new List<e_Guias>();
                e_Guias guias = null;
                string consulta = "SELECT NRO_OC,[TIPO DEL DOCUMENTO DEL CLIENTE],[NUMERO DE DOCUMENTO],[NOMBRE CLIENTE],DIRECCION, CORREO, TELEFONO" +
                    ", OBSERVACIONES, [DESCRIPCION DEL MOTIVO DEL TRASLADO], CONVERT(varchar,FECHA_DE_TRASLADO,23) AS FECHA_DE_TRASLADO, PESO, [UBIGEO DE LLEGADA], [DIRECCION LLEGADA], " +
                    "[CODIGO DEL DOMICILIO DE LLEGADA], [TIPO DOCUMENTO TRANSPORTISTA], DOCUMENTO_TRANSPORTISTA,[NOMBRE TRANSPORTISTA], [NUMERO MTC], [CODIGO ITEM(SKU)], " +
                    "CANTIDAD FROM GUIAS_CONECTA_CONS WHERE NRO_OC IN (select NUMERO_ORDEN FROM OC_CONECTA_CONS WHERE FECHA_ENTREGA = '" + fecha + "')";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    guias = new e_Guias();
                    guias.NRO_OC = (string)reader["NRO_OC"];
                    guias.SERIE_FACTURA = "";
                    guias.NUMERO_DOCUMENTO_FACTURA = "";
                    guias.TIPO_DOCUMENTO = "";
                    guias.TIPO_DOCUMENTO_CLIENTE = (string)reader["TIPO DEL DOCUMENTO DEL CLIENTE"];
                    guias.NUMERO_DOCUMENTO = (string)reader["NUMERO DE DOCUMENTO"];
                    guias.NOMBRE_CLIENTE = (string)reader["NOMBRE CLIENTE"];
                    guias.DIRECCION_CLIENTE = (string)reader["DIRECCION"];
                    guias.CORREO = (string)reader["CORREO"];
                    guias.TELEFONO = (string)reader["TELEFONO"];
                    guias.OBSERVACION = (string)reader["OBSERVACIONES"];
                    guias.DESCRIPCION_MOTIVO = (string)reader["DESCRIPCION DEL MOTIVO DEL TRASLADO"];
                    guias.FECHA_TRASLADO = (string)reader["FECHA_DE_TRASLADO"];
                    guias.PESO = Convert.ToString((double)reader["PESO"]);
                    guias.UBIGEO_LLEGADA = (string)reader["UBIGEO DE LLEGADA"];
                    guias.DIRECCION_LLEGADA = (string)reader["DIRECCION LLEGADA"];
                    guias.CODIGO_DOMICILIO = (string)reader["CODIGO DEL DOMICILIO DE LLEGADA"];
                    guias.TIPO_DOCUMENTO_TRANSPORTISTA = (string)reader["TIPO DOCUMENTO TRANSPORTISTA"];
                    guias.DOCUMENTO_TRANSPORTISTA = (string)reader["DOCUMENTO_TRANSPORTISTA"];
                    guias.NOMBRE_TRANSPORTISTA = (string)reader["NOMBRE TRANSPORTISTA"];
                    guias.NUMERO_MTC = (string)reader["NUMERO MTC"];
                    guias.CODIGO_ITEM_SKU = (string)reader["CODIGO ITEM(SKU)"];
                    guias.CANTIDAD = Convert.ToString((int)reader["CANTIDAD"]);
                    lista.Add(guias);
                }
                reader.Close();
                return lista;
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
        //produccion
        public string Update_Guias(string observacions, string NRO_OC, string fecha, string ruc, string cliente, string direccion)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string modif = "UPDATE GUIAS_CONECTA_CONS SET FECHA_DE_TRASLADO = '" + fecha + "' , [NUMERO DE DOCUMENTO] = '" + ruc + "'  , [NOMBRE CLIENTE] = '" + cliente + "' , OBSERVACIONES = '" + observacions + "' , DIRECCION = '" + direccion + "' WHERE NRO_OC='" + NRO_OC + "'; UPDATE OC_CONECTA_CONS SET FECHA_ENTREGA = '" + fecha + "' WHERE NUMERO_ORDEN = '" + NRO_OC + "';";
                SqlCommand cmd_0 = new SqlCommand(modif, con);
                cmd_0.ExecuteNonQuery();
                return "Se modificó exitosamente";

            }
            catch (Exception err)
            {
                return err.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();

            }
        }
        public string colectar_informacion(string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string observacion = "";
                string consulta = "SELECT OBSERVACIONES FROM GUIAS_CONECTA_CONS WHERE NRO_OC ='" + NRO_OC + "'";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    observacion = (string)reader["OBSERVACIONES"];
                }
                reader.Close();
                return observacion;
            }
            catch (Exception err)
            {
                return err.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        public string Guias_a_entregar()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string modif = "INSERT INTO GUIAS_CONECTA_CONS SELECT S.NUMERO_ORDEN, " +
                    "'' AS 'SERIE DE FACTURA', " +
                    "'' AS 'NUMERO DOCUMENTO FACTURA', " +
                    "'' AS 'TIPO DEL DOCUMENTO'," +
                    "'6' AS 'TIPO DEL DOCUMENTO DEL CLIENTE', " +
                    "'20141189850' AS 'NUMERO DE DOCUMENTO', " +
                    "'CONECTA RETAIL S.A.' AS 'NOMBRE CLIENTE'," +
                    "'AV. LUIS GONZALES NRO. 1315 URB. CERCADO DE CHICLAYO , CHICLAYO , CHICLAYO - LAMBAYEQUE' AS 'DIRECCION', " +  //
                    "'stech.pagos@gmail.com' AS 'CORREO'," +
                    "'6161000' AS 'TELEFONO', " +
                    "'OPERADOR LOGISTICO: 20607505277 - GRUPO LAFAME S.A.C' AS OBSERVACIONES," + //FATAL PORNER EL NRO_F12
                    "'VENTA DE PRODUCTOS' AS 'DESCRIPCION DEL MOTIVO DEL TRASLADO', " +
                    "Convert(varchar,CONVERT(datetime,S.FECHA_ENTREGA),23) AS 'FECHA_DE_TRASLADO'," +
                    "Z.PESO*S.UNIDADES_SOLICITADAS AS 'PESO', " +
                    "'150142' AS 'UBIGEO DE LLEGADA', " +
                    "'PREDIO RUSTICO NRO. SN UNIDAD CATASTRAL 10048, LIMA - LIMA - VILLA EL SALVADOR ' AS 'DIRECCION LLEGADA'," + //
                    "'0' AS 'CODIGO DEL DOMICILIO DE LLEGADA', " +
                    "'6' AS 'TIPO DOCUMENTO TRANSPORTISTA', " +
                    "'20607505277 ' AS 'DOCUMENTO_TRANSPORTISTA'," +
                    "'GRUPO LAFAME S.A.C' AS 'NOMBRE TRANSPORTISTA', " +
                    "'15103295CNG' AS 'NUMERO MTC', " +
                    "S.COD_PRODUCTO AS 'CODIGO ITEM(SKU)'," +
                    "S.UNIDADES_SOLICITADAS AS CANTIDAD," +
                    "GETDATE() AS FECHA_PROCESO " +
                    "FROM OC_CONECTA_CONS S JOIN ( SELECT SS.NUMERO_ORDEN, SUM(CONVERT(float,LL.PESO))AS PESO " +
                    "from OC_CONECTA_CONS SS JOIN LOGISTICA_CONECTA LL ON LL.SKU = SS.COD_PRODUCTO group by SS.NUMERO_ORDEN )Z ON Z.NUMERO_ORDEN = S.NUMERO_ORDEN " +
                    "WHERE ST_DESPACHO='PENDIENTE' AND FECHA_ENTREGA  >= CONVERT(datetime, GETDATE()-1) AND S.NUMERO_ORDEN NOT IN (SELECT NRO_OC FROM GUIAS_CONECTA_CONS) AND NRO_GUIA IS NULL";
                SqlCommand cmd_0 = new SqlCommand(modif, con);
                cmd_0.ExecuteNonQuery();
                return "Se añadieron las guias correctamente";

            }
            catch (Exception err)
            {
                return err.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();

            }
        }
        public string GuardarGuia(string nro, string nroOC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string act = "Update OC_CONECTA_CONS SET NRO_GUIA = '" + nro + "' Where NUMERO_ORDEN = '" + nroOC + "'";
                SqlCommand cmd_0 = new SqlCommand(act, con);
                cmd_0.ExecuteNonQuery();
                return "Actualizacion completa";
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
    }
}
