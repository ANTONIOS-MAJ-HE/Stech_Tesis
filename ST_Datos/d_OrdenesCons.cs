using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_OrdenesCons
    {
        d_SQLcon db_Conect = new d_SQLcon();
        public List<e_OrdenesCons> Listar_OCs_Consolidadas(e_OrdenesCons obj)
        {
            try
            {
                SqlConnection con = db_Conect.Conecta_DB();
                List<e_OrdenesCons> lista_ordenes_cons = new List<e_OrdenesCons>();
                e_OrdenesCons ordenes_cons = null;
                string consulta = string.Format("SELECT CANAL, NRO_OC, FECHA_CREACION, SKU, ISNULL(EAN_UPC, '-') AS EAN_UPC, ISNULL(MODELO, '-') AS MODELO, ISNULL(MINI_CODIGO, '-') AS MINI_CODIGO, ISNULL(PARTNUMBER, '-') AS PARTNUMBER, " +
                    "PRODUCTO_ORIGINAL,CANT_ORIGINAL, CANT_REAL, ISNULL(PRODUCTO_CAMBIADO,'-') AS PRODUCTO_CAMBIADO," +
                    " ISNULL(CONVERT(VARCHAR,COSTO_S_IGV),'0.00') AS COSTO_S_IGV,ISNULL(CONVERT(VARCHAR,COSTO_C_IGV),'0.00') AS COSTO_C_IGV,NUM_DOC, NOM_CLI, DIRECCION_CLI, ISNULL(CONVERT(VARCHAR,FECHA_DESPACHO),'-') AS FECHA_DESPACHO," +
                    " ISNULL(ESTADO_ORDEN,'-') AS ESTADO_ORDEN, ISNULL(ESTADO_DESP,'-') AS ESTADO_DESP, ISNULL(SERIE_CMP,'-') AS SERIE_CMP, " +
                    "ISNULL(NRO_CMP,'-')AS NRO_CMP, ISNULL(OBSERVACIONES,'-') AS OBSERVACIONES, ISNULL(CONVERT(VARCHAR,FECHA_PROCESO),'-') AS FECHA_PROCESO FROM ST_CONS_ORDENES WHERE NRO_OC = '{0}'",
                    obj.Nro_OC);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    ordenes_cons = new e_OrdenesCons();
                    ordenes_cons.Canal = (string)reader["CANAL"];
                    ordenes_cons.Nro_OC = (string)reader["NRO_OC"];
                    ordenes_cons.Fecha_Creacion = Convert.ToString((DateTime)reader["FECHA_CREACION"]);
                    ordenes_cons.SKU = (string)reader["SKU"];
                    ordenes_cons.EAN_UPC = (string)reader["EAN_UPC"];
                    ordenes_cons.Modelo = (string)reader["MODELO"];
                    ordenes_cons.Mini_Codigo = (string)reader["MINI_CODIGO"];
                    ordenes_cons.PartNumber = (string)reader["PARTNUMBER"];
                    ordenes_cons.Producto_Original = (string)reader["PRODUCTO_ORIGINAL"];
                    ordenes_cons.Cantidad_Original = (int)reader["CANT_ORIGINAL"];
                    ordenes_cons.Cantidad_Real = (int)reader["CANT_REAL"];
                    ordenes_cons.Producto_Cambiado = (string)reader["PRODUCTO_CAMBIADO"];
                    ordenes_cons.Costo_S_IGV = (string)reader["COSTO_S_IGV"];
                    ordenes_cons.Costo_C_IGV = (string)reader["COSTO_C_IGV"];
                    ordenes_cons.Nro_Doc= (string)reader["NUM_DOC"];
                    ordenes_cons.Nom_Cliente = (string)reader["NOM_CLI"];
                    ordenes_cons.Direccion_Cliente = (string)reader["DIRECCION_CLI"];
                    ordenes_cons.Fecha_Despacho = (string)reader["FECHA_DESPACHO"];
                    ordenes_cons.Estado_Orden = (string)reader["ESTADO_ORDEN"];
                    ordenes_cons.Estado_Despacho = (string)reader["ESTADO_DESP"];
                    ordenes_cons.Serie_Comp = (string)reader["SERIE_CMP"];
                    ordenes_cons.Nro_Comp = (string)reader["NRO_CMP"];
                    ordenes_cons.Observaciones = (string)reader["OBSERVACIONES"];
                    ordenes_cons.Fecha_Proceso = (string)reader["FECHA_PROCESO"];
                    lista_ordenes_cons.Add(ordenes_cons);

                }
                reader.Close();
                return lista_ordenes_cons;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                db_Conect.Desconecta_DB();
            }
            
        }
        public string Actualizar_Cons()
        {
            try
            {
                SqlConnection con = db_Conect.Conecta_DB();
                // ACTUALIZACION SAGA ----- 29/09/2021
                string upd_saga_0 = "UPDATE ST_CONS_ORDENES SET ESTADO_ORDEN = B.ST_ORDEN, ESTADO_DESP = B.ST_DESPACHO, OBSERVACIONES =" +
                    " B.ST_OBSERVACION, FECHA_PROCESO = GETDATE() FROM ST_CONS_ORDENES A JOIN OC_SF_CONS B ON A.NRO_OC = B.NRO_OC JOIN" +
                    " ST_STOCK C ON B.PART_NUMB_REAL = C.PARTNUMBER WHERE A.CANAL = 'SAGA' AND A.NRO_OC IN (SELECT NRO_OC FROM " +
                    "ST_INCIDENCIAS_CONS WHERE CANAL like '%SAGA%')";
                string upd_saga_1 = "UPDATE ST_CONS_ORDENES  SET PRODUCTO_CAMBIADO = C.TITULO FROM ST_CONS_ORDENES A JOIN OC_SF_CONS B" +
                    " ON A.NRO_OC = B.NRO_OC JOIN ST_STOCK C ON B.PART_NUMB_REAL = C.PARTNUMBER WHERE A.CANAL = 'SAGA' AND A.NRO_OC IN " +
                    "(SELECT NRO_OC FROM ST_INCIDENCIAS_CONS WHERE CANAL like '%SAGA%' AND TIPO = 'CAMBIO')";
                SqlCommand cmd_0 = new SqlCommand(upd_saga_0,con);
                SqlCommand cmd_1 = new SqlCommand(upd_saga_1,con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                // ACTUALIZACION LINIO ----- 29/09/2021
                string upd_lno_0 = "UPDATE ST_CONS_ORDENES SET ESTADO_ORDEN = B.ST_ORDEN, ESTADO_DESP = B.ST_DESPACHO, OBSERVACIONES =" +
                    " B.OBSERVACIONES, FECHA_PROCESO = GETDATE() FROM ST_CONS_ORDENES A JOIN OC_LNO_CONS B ON A.NRO_OC = B.ORDER_NUMBER " +
                    "JOIN ST_STOCK C ON B.PART_NUMB_REAL = C.PARTNUMBER WHERE A.CANAL = 'LINIO' AND A.NRO_OC IN (SELECT NRO_OC FROM" +
                    " ST_INCIDENCIAS_CONS WHERE CANAL like '%LINIO%')";
                string upd_lno_1 = "UPDATE ST_CONS_ORDENES  SET PRODUCTO_CAMBIADO = C.TITULO FROM ST_CONS_ORDENES A JOIN OC_LNO_CONS B ON " +
                    "A.NRO_OC = B.ORDER_NUMBER JOIN ST_STOCK C ON B.PART_NUMB_REAL = C.PARTNUMBER WHERE A.CANAL = 'LINIO' AND A.NRO_OC IN" +
                    " (SELECT NRO_OC FROM ST_INCIDENCIAS_CONS WHERE CANAL like '%LINIO%' AND TIPO = 'CAMBIO')";
                SqlCommand cmd_2 = new SqlCommand(upd_lno_0, con);
                SqlCommand cmd_3 = new SqlCommand(upd_lno_1, con);
                cmd_2.ExecuteNonQuery();
                cmd_3.ExecuteNonQuery();
                // ACTUALIZACION RIPLEY ----- 29/09/2021
                string upd_rpl_0 = "UPDATE ST_CONS_ORDENES SET ESTADO_ORDEN = B.ST_ORDEN, ESTADO_DESP = B.ST_DESPACHO, OBSERVACIONES =" +
                    " B.OBSERVACIONES, FECHA_PROCESO = GETDATE() FROM ST_CONS_ORDENES A JOIN OC_RPL_CONS B ON A.NRO_OC = B.NRO_PEDIDO J" +
                    "OIN ST_STOCK C ON B.PART_NUMB_REAL = C.PARTNUMBER WHERE A.CANAL = 'RIPLEY' AND A.NRO_OC IN (SELECT NRO_OC FROM" +
                    " ST_INCIDENCIAS_CONS WHERE CANAL like '%RIPLEY%')";
                string upd_rpl_1 = "UPDATE ST_CONS_ORDENES  SET PRODUCTO_CAMBIADO = C.TITULO FROM ST_CONS_ORDENES A JOIN OC_RPL_CONS B ON" +
                    " A.NRO_OC = B.NRO_PEDIDO JOIN ST_STOCK C ON B.PART_NUMB_REAL = C.PARTNUMBER WHERE A.CANAL = 'RIPLEY' AND A.NRO_OC IN" +
                    " (SELECT NRO_OC FROM ST_INCIDENCIAS_CONS WHERE CANAL like '%RIPLEY%' AND TIPO = 'CAMBIO')";
                SqlCommand cmd_4 = new SqlCommand(upd_rpl_0, con);
                SqlCommand cmd_5 = new SqlCommand(upd_rpl_1, con);
                cmd_4.ExecuteNonQuery();
                cmd_5.ExecuteNonQuery();
                //ACTUALIZACION REAL PLAZA ----- 29/09/2021
                string upd_rpg_0 = "UPDATE ST_CONS_ORDENES SET ESTADO_ORDEN = B.ST_ORDEN, ESTADO_DESP = B.ST_DESPACHO, OBSERVACIONES =" +
                    " B.OBSERVACIONES, FECHA_PROCESO = GETDATE() FROM ST_CONS_ORDENES A JOIN OC_RPG_CONS B ON A.NRO_OC = B.NUMERO JOIN " +
                    "ST_STOCK C ON B.PARTNUMBER_REAL = C.PARTNUMBER WHERE A.CANAL = 'REAL PLAZA' AND A.NRO_OC IN (SELECT NRO_OC FROM" +
                    " ST_INCIDENCIAS_CONS WHERE CANAL like '%REAL%')";
                string upd_rpg_1 = "UPDATE ST_CONS_ORDENES  SET PRODUCTO_CAMBIADO = C.TITULO FROM ST_CONS_ORDENES A JOIN OC_RPG_CONS B ON " +
                    "A.NRO_OC = B.NUMERO JOIN ST_STOCK C ON B.PARTNUMBER_REAL = C.PARTNUMBER WHERE A.CANAL = 'REAL PLAZA' AND A.NRO_OC IN " +
                    "(SELECT NRO_OC FROM ST_INCIDENCIAS_CONS WHERE CANAL like '%REAL%' AND TIPO = 'CAMBIO')";
                SqlCommand cmd_6 = new SqlCommand(upd_rpg_0, con);
                SqlCommand cmd_7 = new SqlCommand(upd_rpg_1, con);
                cmd_6.ExecuteNonQuery();
                cmd_7.ExecuteNonQuery();
                //ACTULIZACION MERCADO LIBRE ---- 29/09/2021
                string upd_mlibre_0 = "";
                string upd_mlibre_1 = "";
                SqlCommand cmd_8 = new SqlCommand();
                SqlCommand cmd_9 = new SqlCommand();
                cmd_8.ExecuteNonQuery();
                cmd_9.ExecuteNonQuery();

                return null;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                db_Conect.Desconecta_DB();
            }
        }

    }
}
