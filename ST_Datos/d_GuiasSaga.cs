using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_GuiasSaga
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
                    "SG.CANTIDAD,SF.NRO_F12 FROM GUIAS_SAGA_CONS SG LEFT JOIN OC_SF_CONS SF ON SG.NRO_OC=SF.NRO_OC WHERE SG.NRO_OC IN (select NRO_OC FROM OC_SF_CONS WHERE ST_DESPACHO='PENDIENTE' AND FECHA_ENTREGA IN (SELECT MIN(FECHA_ENTREGA) " +
                    "FROM OC_SF_CONS WHERE ST_DESPACHO = 'PENDIENTE' AND FECHA_ENTREGA > GETDATE())) AND NRO_GUIA IS NULL order by SF.NRO_F12";
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
                    "SG.[NOMBRE TRANSPORTISTA], SG.[NUMERO MTC], SG.[CODIGO ITEM(SKU)], SG.CANTIDAD,SF.NRO_F12 FROM GUIAS_SAGA_CONS SG " +
                    "LEFT JOIN OC_SF_CONS SF ON SG.NRO_OC=SF.NRO_OC WHERE SG.NRO_OC = '"+Filtro+"' order by SF.NRO_F12";
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
                    "CANTIDAD FROM GUIAS_SAGA_CONS WHERE NRO_OC = '"+nroOc+"'";
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
                    "CANTIDAD FROM GUIAS_SAGA_CONS WHERE NRO_OC = '" + nroOc + "'";
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
                    "CANTIDAD FROM GUIAS_SAGA_CONS WHERE NRO_OC IN (select NRO_OC FROM OC_SF_CONS WHERE FECHA_ENTREGA = '"+fecha+"')";
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
        public string Update_Guias(string observacions, string NRO_OC)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string modif = "UPDATE GUIAS_SAGA_CONS SET OBSERVACIONES = '"+observacions+"' WHERE NRO_OC='"+NRO_OC+"'";
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
                string consulta = "SELECT OBSERVACIONES FROM GUIAS_SAGA_CONS WHERE NRO_OC ='"+NRO_OC+"'";
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
                string modif = "INSERT INTO GUIAS_SAGA_CONS SELECT S.NRO_OC, '' AS 'SERIE DE FACTURA', '' AS 'NUMERO DOCUMENTO FACTURA', '' AS 'TIPO DEL DOCUMENTO', " +
                    "'6' AS 'TIPO DEL DOCUMENTO DEL CLIENTE', '20100128056' AS 'NUMERO DE DOCUMENTO', 'SAGA FALABELLA S A' AS 'NOMBRE CLIENTE', " +
                    "'AV. PASEO DE LA REPUBLICA NRO. 3220 URB. JARDIN LIMA - LIMA - SAN ISIDRO' AS 'DIRECCION', 'stech.pagos@gmail.com' AS 'CORREO', " +
                    "'965744589' AS 'TELEFONO', CONCAT('SKU:',S.SKU,' EOT:',' ',' FO:',S.NRO_F12,' OC:',S.NRO_OC) AS OBSERVACIONES, " +
                    "'VENTA DE PRODUCTOS' AS 'DESCRIPCION DEL MOTIVO DEL TRASLADO', Convert(varchar,CONVERT(datetime,S.FECHA_DESPACHO_PACTADA),23) AS 'FECHA_DE_TRASLADO', " +
                    "Z.PESO*S.UNIDADES AS 'PESO', '150142' AS 'UBIGEO DE LLEGADA', 'AV. EL SOL 2295 ZONA AGROPECUARIA VILLA RICA - VILLA EL SALVADOR -LIMA' AS 'DIRECCION LLEGADA'," +
                    " '0' AS 'CODIGO DEL DOMICILIO DE LLEGADA', '6' AS 'TIPO DOCUMENTO TRANSPORTISTA', '20606971053' AS 'DOCUMENTO TRANSPORTISTA', " +
                    "'LIMA SUR CORPORATION SOCIEDAD ANONIMA CERRADA' AS 'NOMBRE TRANSPORTISTA', '15103295CNG' AS 'NUMERO MTC', S.SKU AS 'CODIGO ITEM(SKU)'," +
                    " S.UNIDADES AS CANTIDAD,GETDATE() AS FECHA_PROCESO FROM OC_SF_CONS S JOIN ( SELECT SS.NRO_OC, SUM(CONVERT(float,LL.PESO))AS PESO " +
                    "from OC_SF_CONS SS JOIN LOGISTICA_SAGA LL ON LL.SKU = SS.SKU group by SS.NRO_OC )Z ON Z.NRO_OC = S.NRO_OC " +
                    "WHERE ST_DESPACHO='PENDIENTE' AND FECHA_ENTREGA IN (SELECT MIN(FECHA_ENTREGA) FROM OC_SF_CONS " +
                    "WHERE ST_DESPACHO = 'PENDIENTE' AND FECHA_ENTREGA > GETDATE()) AND S.NRO_OC NOT IN (SELECT NRO_OC FROM GUIAS_SAGA_CONS) ORDER by S.NRO_F12 ASC";
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
                string act = "Update OC_SF_CONS SET NRO_GUIA = '" + nro + "' Where NRO_OC = '" + nroOC + "'";
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
