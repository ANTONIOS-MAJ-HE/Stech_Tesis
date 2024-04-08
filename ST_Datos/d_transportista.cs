using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;
namespace ST_Datos
{
    public class d_transportista
    {
        d_SQLcon db_conect = new d_SQLcon();
        public List<e_transportista> Lista_transportistas()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_transportista> lista_trans = new List<e_transportista>();
                e_transportista transportista = null;
                string consulta = "SELECT * FROM ST_TRANSPORTISTAS";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    transportista = new e_transportista();
                    transportista.NOMBRE = (string)reader["NOMBRE"];
                    transportista.TIPO_DOCUMENTO = (string)reader["TIPO_DOCUMENTO"];
                    transportista.DOCUMENTO = (string)reader["DOCUMENTO"];
                    transportista.NUMERO_MTC = (string)reader["NUMERO_MTC"];
                    transportista.DIRECCION_FISCAL = (string)reader["DIRECCION_FISCAL"];
                    transportista.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
                    transportista.ID_TRANSPORTISTA = (int)reader["ID_TRANSPORTISTA"];
                    lista_trans.Add(transportista);
                }
                reader.Close();
                return lista_trans;
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

        public string Add_transportista(e_transportista obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string insert = string.Format("INSERT INTO ST_TRANSPORTISTAS(NOMBRE,TIPO_DOCUMENTO,DOCUMENTO,NUMERO_MTC,DIRECCION_FISCAL,FECHA_PROCESO)" +
                    "VALUES('{0}','{1}','{2}','{3}','{4}',GETDATE())",obj.NOMBRE,obj.TIPO_DOCUMENTO,obj.DOCUMENTO,obj.NUMERO_MTC,obj.DIRECCION_FISCAL);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Transportista registrado correctamente";
            }
            catch (Exception er)
            {
                return er.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }

        public List<e_transportista> Lista_transportistas_filtro(e_transportista obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_transportista> lista_trans = new List<e_transportista>();
                e_transportista transportista = null;
                string consulta = string.Format("SELECT * FROM ST_TRANSPORTISTAS WHERE NOMBRE LIKE '%{0}%' AND TIPO_DOCUMENTO LIKE '%{1}%' AND DOCUMENTO " +
                    "LIKE '%{2}%' AND NUMERO_MTC LIKE '%{3}%' AND DIRECCION_FISCAL LIKE '%{4}%'",obj.NOMBRE,obj.TIPO_DOCUMENTO,obj.DOCUMENTO,obj.NUMERO_MTC,
                    obj.DIRECCION_FISCAL);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    transportista = new e_transportista();
                    transportista.NOMBRE = (string)reader["NOMBRE"];
                    transportista.TIPO_DOCUMENTO = (string)reader["TIPO_DOCUMENTO"];
                    transportista.DOCUMENTO = (string)reader["DOCUMENTO"];
                    transportista.NUMERO_MTC = (string)reader["NUMERO_MTC"];
                    transportista.DIRECCION_FISCAL = (string)reader["DIRECCION_FISCAL"];
                    transportista.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
                    transportista.ID_TRANSPORTISTA = (int)reader["ID_TRANSPORTISTA"];
                    lista_trans.Add(transportista);
                }
                reader.Close();
                return lista_trans;
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

        public List<e_choferes> Lista_choferes()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_choferes> lista_choferes = new List<e_choferes>();
                e_choferes chofer = null;
                string consulta = "SELECT * FROM ST_CONDUCTORES";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    chofer = new e_choferes();
                    chofer.NOMBRE = (string)reader["NOMBRE"];
                    chofer.TIPO_DOCUMENTO = (string)reader["TIPO_DOCUMENTO"];
                    chofer.DOCUMENTO = (string)reader["DOCUMENTO"];
                    chofer.TELEFONO = (string)reader["TELEFONO"];
                    chofer.LICENCIA = (string)reader["LICENCIA"];
                    chofer.NRO_PLACA = (string)reader["NRO_PLACA"];
                    chofer.MODELO = (string)reader["MODELO"];
                    chofer.MARCA = (string)reader["MARCA"];
                    chofer.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
                    chofer.ID_CHOFER = (int)reader["ID_CONDUCTOR"];
                    lista_choferes.Add(chofer);
                }
                reader.Close();
                return lista_choferes;
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
        public List<e_choferes> Lista_choferes_filtro(e_choferes obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_choferes> lista_choferes = new List<e_choferes>();
                e_choferes chofer = null;
                string consulta = string.Format("SELECT * FROM ST_CONDUCTORES WHERE NOMBRE LIKE '%{0}%' AND TIPO_DOCUMENTO LIKE '%{1}%' AND DOCUMENTO LIKE '%{2}%' AND" +
                    " TELEFONO LIKE '%{3}%' AND LICENCIA LIKE '%{4}%' AND NRO_PLACA LIKE '%{5}%' AND MODELO LIKE '%{6}%' AND MARCA LIKE '%{7}%'",obj.NOMBRE,obj.TIPO_DOCUMENTO,
                    obj.DOCUMENTO,obj.TELEFONO,obj.LICENCIA,obj.NRO_PLACA,obj.MODELO,obj.MARCA);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    chofer = new e_choferes();
                    chofer.NOMBRE = (string)reader["NOMBRE"];
                    chofer.TIPO_DOCUMENTO = (string)reader["TIPO_DOCUMENTO"];
                    chofer.DOCUMENTO = (string)reader["DOCUMENTO"];
                    chofer.TELEFONO = (string)reader["TELEFONO"];
                    chofer.LICENCIA = (string)reader["LICENCIA"];
                    chofer.NRO_PLACA = (string)reader["NRO_PLACA"];
                    chofer.MODELO = (string)reader["MODELO"];
                    chofer.MARCA = (string)reader["MARCA"];
                    chofer.FECHA_PROCESO = (DateTime)reader["FECHA_PROCESO"];
                    chofer.ID_CHOFER = (int)reader["ID_CONDUCTOR"];
                    lista_choferes.Add(chofer);
                }
                reader.Close();
                return lista_choferes;
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
        public string Add_Chofer(e_choferes obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string insert = string.Format("INSERT INTO ST_CONDUCTORES(NOMBRE,TIPO_DOCUMENTO,DOCUMENTO,TELEFONO,LICENCIA,NRO_PLACA,MODELO,MARCA,FECHA_PROCESO)" +
                    "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GETDATE())", obj.NOMBRE, obj.TIPO_DOCUMENTO, obj.DOCUMENTO,obj.TELEFONO,obj.LICENCIA,
                    obj.NRO_PLACA,obj.MODELO, obj.MARCA);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Chofer registrado correctamente";
            }
            catch (Exception er)
            {
                return er.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
    }
}
