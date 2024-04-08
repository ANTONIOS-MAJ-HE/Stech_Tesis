using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
    public class d_Clientes
    {
        d_SQLcon db_conect = new d_SQLcon();

        public List<e_Cliente> Lista_Clientes()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Cliente> lista_clientes = new List<e_Cliente>();
                e_Cliente cliente = null;
                string consulta = "SELECT ISNULL(NOMBRE_RAZON_SOCIAL,'-') AS NOMBRE_RAZON_SOCIAL,ISNULL(TIPO_DOCUMENTO,'-') AS TIPO_DOCUMENTO,ISNULL(NRO_DOCUMENTO,'-') AS NRO_DOCUMENTO," +
                    "ISNULL(CORREO,'-') AS CORREO,ISNULL(TELEFONO,'-') AS TELEFONO,ISNULL(FECHA_DE_REGISTRO,'2021-01-01') AS FECHA_DE_REGISTRO,ISNULL(DIRECCION_FISCAL,'-') AS DIRECCION_FISCAL," +
                    "ISNULL(DIRECCION_DE_ENTREGA,'-') AS DIRECCION_DE_ENTREGA,ISNULL(UBIGEO,'-') AS UBIGEO,ISNULL(COD_UBIGEO,'-') AS COD_UBIGEO,ID_CLIENTE FROM ST_CLIENTES";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_Cliente();
                    cliente.NOMBRE_RAZON_SOCIAL = (string)reader["NOMBRE_RAZON_SOCIAL"];
                    cliente.TIPO_DOCUMENTO = (string)reader["TIPO_DOCUMENTO"];
                    cliente.NRO_DOCUMENTO = (string)reader["NRO_DOCUMENTO"];
                    cliente.CORREO = (string)reader["CORREO"];
                    cliente.TELEFONO = (string)reader["TELEFONO"];
                    cliente.FECHA_REGISTRO = (DateTime)reader["FECHA_DE_REGISTRO"];
                    cliente.DIRECCION_FISCAL = (string)reader["DIRECCION_FISCAL"];
                    cliente.DIRECCION_ENTREGA = (string)reader["DIRECCION_DE_ENTREGA"];
                    cliente.UBIGEO = (string)reader["UBIGEO"];
                    cliente.COD_UBIGEO = (string)reader["COD_UBIGEO"];
                    cliente.ID_CLIENTE = (int)reader["ID_CLIENTE"];
                    lista_clientes.Add(cliente);
                }
                reader.Close();
                return lista_clientes;
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

        public string Add_Cliente(e_Cliente obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string insert = string.Format("INSERT INTO ST_CLIENTES(NOMBRE_RAZON_SOCIAL,TIPO_DOCUMENTO,NRO_DOCUMENTO,CORREO,TELEFONO,FECHA_DE_REGISTRO" +
                    ",DIRECCION_FISCAL,DIRECCION_DE_ENTREGA,UBIGEO,COD_UBIGEO)VALUES('{0}','{1}','{2}','{3}','{4}',GETDATE(),'{5}','{6}','{7}','{8}')", obj.NOMBRE_RAZON_SOCIAL,obj.TIPO_DOCUMENTO,
                    obj.NRO_DOCUMENTO,obj.CORREO,obj.TELEFONO,obj.DIRECCION_FISCAL,obj.DIRECCION_ENTREGA,obj.UBIGEO,obj.COD_UBIGEO);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Cliente registrado correctamente";
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
        public string Actualizar_cliente(e_Cliente obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string insert = string.Format("UPDATE ST_CLIENTES SET NOMBRE_RAZON_SOCIAL = '{0}',TIPO_DOCUMENTO='{1}',NRO_DOCUMENTO='{2}',CORREO = '{3}'," +
                    " TELEFONO='{4}', DIRECCION_FISCAL='{5}',DIRECCION_DE_ENTREGA='{6}',UBIGEO='{7}',COD_UBIGEO='{8}' WHERE ID_CLIENTE={9}",obj.NOMBRE_RAZON_SOCIAL,
                    obj.TIPO_DOCUMENTO,obj.NRO_DOCUMENTO,obj.CORREO,obj.TELEFONO,obj.DIRECCION_FISCAL,obj.DIRECCION_ENTREGA,obj.UBIGEO,obj.COD_UBIGEO,obj.ID_CLIENTE);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Cliente actualizado correctamente";
            }
            catch(Exception err)
            {
                return err.Message;
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        }
        public List<e_Cliente> Lista_Clientes_Filtro(e_Cliente obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Cliente> lista_clientes = new List<e_Cliente>();
                e_Cliente cliente = null;
                string consulta = string.Format("SELECT ISNULL(NOMBRE_RAZON_SOCIAL,'-') AS NOMBRE_RAZON_SOCIAL,ISNULL(TIPO_DOCUMENTO,'-') AS TIPO_DOCUMENTO,ISNULL(NRO_DOCUMENTO,'-') " +
                    "AS NRO_DOCUMENTO,ISNULL(CORREO,'-') AS CORREO,ISNULL(TELEFONO,'-') AS TELEFONO,ISNULL(FECHA_DE_REGISTRO,'2021-01-01') AS FECHA_DE_REGISTRO," +
                    "ISNULL(DIRECCION_FISCAL,'-') AS DIRECCION_FISCAL,ISNULL(DIRECCION_DE_ENTREGA,'-') AS DIRECCION_DE_ENTREGA,ISNULL(UBIGEO,'-') AS UBIGEO,ISNULL(COD_UBIGEO,'-') " +
                    "AS COD_UBIGEO,ID_CLIENTE FROM ST_CLIENTES WHERE NOMBRE_RAZON_SOCIAL LIKE '%{0}%' AND NRO_DOCUMENTO LIKE '%{1}%' AND " +
                    "TIPO_DOCUMENTO LIKE '%{2}%' AND CORREO LIKE '%{3}%' AND TELEFONO LIKE '%{4}%' AND DIRECCION_FISCAL LIKE '%{5}%' AND DIRECCION_DE_ENTREGA " +
                    "LIKE '%{6}%' AND UBIGEO LIKE '%{7}%' AND COD_UBIGEO LIKE '%{8}%'", obj.NOMBRE_RAZON_SOCIAL,obj.NRO_DOCUMENTO, obj.TIPO_DOCUMENTO, obj.CORREO,obj.TELEFONO,obj.DIRECCION_FISCAL
                    ,obj.DIRECCION_ENTREGA,obj.UBIGEO,obj.COD_UBIGEO);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new e_Cliente();
                    cliente.NOMBRE_RAZON_SOCIAL = (string)reader["NOMBRE_RAZON_SOCIAL"];
                    cliente.TIPO_DOCUMENTO = (string)reader["TIPO_DOCUMENTO"];
                    cliente.NRO_DOCUMENTO = (string)reader["NRO_DOCUMENTO"];
                    cliente.CORREO = (string)reader["CORREO"];
                    cliente.TELEFONO = (string)reader["TELEFONO"];
                    cliente.FECHA_REGISTRO = (DateTime)reader["FECHA_DE_REGISTRO"];
                    cliente.DIRECCION_FISCAL = (string)reader["DIRECCION_FISCAL"];
                    cliente.DIRECCION_ENTREGA = (string)reader["DIRECCION_DE_ENTREGA"];
                    cliente.UBIGEO = (string)reader["UBIGEO"];
                    cliente.COD_UBIGEO = (string)reader["COD_UBIGEO"];
                    cliente.ID_CLIENTE = (int)reader["ID_CLIENTE"];
                    lista_clientes.Add(cliente);
                }
                reader.Close();
                return lista_clientes;
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
        public List<e_Ubigeo> lista_ubigeos()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Ubigeo> lista_ubigeo = new List<e_Ubigeo>();
                e_Ubigeo ubigeo = null;
                string consulta = "select * from ST_UBIGEO";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    ubigeo = new e_Ubigeo();
                    ubigeo.UBIGEO = (string)reader["Ubigeo"];
                    ubigeo.DEPARTAMENTO = (string)reader["Departamento"];
                    ubigeo.PROVINCIA = (string)reader["Provincia"];
                    ubigeo.DISTRITO = (string)reader["Distrito"];
                    lista_ubigeo.Add(ubigeo);
                }
                reader.Close();
                return lista_ubigeo;
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
        public List<e_Ubigeo> lista_ubigeos_Filtro(e_Ubigeo obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Ubigeo> lista_ubigeo = new List<e_Ubigeo>();
                e_Ubigeo ubigeo = null;
                string consulta = string.Format("select * from ST_UBIGEO WHERE Departamento LIKE '%{0}%' AND Provincia LIKE '%{1}%' AND Distrito LIKE '%{2}%'",
                    obj.DEPARTAMENTO,obj.PROVINCIA,obj.DISTRITO);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    ubigeo = new e_Ubigeo();
                    ubigeo.UBIGEO = (string)reader["Ubigeo"];
                    ubigeo.DEPARTAMENTO = (string)reader["Departamento"];
                    ubigeo.PROVINCIA = (string)reader["Provincia"];
                    ubigeo.DISTRITO = (string)reader["Distrito"];
                    lista_ubigeo.Add(ubigeo);
                }
                reader.Close();
                return lista_ubigeo;
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
        public List<e_Contacto> lst_Contactos()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Contacto> lista_contactos = new List<e_Contacto>();
                e_Contacto contacto = null;
                string consulta = "SELECT SC.ID_CLIENTE,ISNULL(SC.NOMBRE,'-') AS NOMBRE,ISNULL(SC.TELEFONO,'-') AS TELEFONO,ISNULL(SC.CORREO,'-') AS CORREO,ISNULL(SC.OBSERVACION,'-') " +
                    "AS OBSERVACION,ISNULL(SC.DOCUMENTO,'-') AS DOCUMENTO,ISNULL(SC.NRO_CONTACTOS,0) AS NRO_CONTACTOS,ISNULL(SC.FECHA_REGISTRO,'2021-01-01') AS FECHA_REGISTRO," +
                    "CC.NOMBRE_RAZON_SOCIAL FROM ST_CONTACTOS SC JOIN ST_CLIENTES CC ON CC.ID_CLIENTE = SC.ID_CLIENTE";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    contacto = new e_Contacto();
                    contacto.ID_CLIENTE = (int)reader["ID_CLIENTE"];
                    contacto.NOMBRE_CLIENTE = (string)reader["NOMBRE_RAZON_SOCIAL"]; 
                    contacto.NOMBRE = (string)reader["NOMBRE"];
                    contacto.TELEFONO = (string)reader["TELEFONO"];
                    contacto.CORREO = (string)reader["CORREO"];
                    contacto.OBSERVACION = (string)reader["OBSERVACION"];
                    contacto.DOCUMENTO = (string)reader["DOCUMENTO"];
                    contacto.NRO_CONTACTO = (int)reader["NRO_CONTACTOS"];
                    contacto.FECHA_REGISTRO = (DateTime)reader["FECHA_REGISTRO"];
                    lista_contactos.Add(contacto);
                }
                reader.Close();
                return lista_contactos;
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
        public List<e_Contacto> lst_Contactos_filtro(e_Contacto obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Contacto> lista_contactos = new List<e_Contacto>();
                e_Contacto contacto = null;
                string consulta = string.Format("SELECT SC.ID_CLIENTE,ISNULL(SC.NOMBRE,'-') AS NOMBRE,ISNULL(SC.TELEFONO,'-') AS TELEFONO,ISNULL(SC.CORREO,'-') AS CORREO," +
                    "ISNULL(SC.OBSERVACION,'-') AS OBSERVACION,ISNULL(SC.DOCUMENTO,'-') AS DOCUMENTO,ISNULL(SC.NRO_CONTACTOS,0) AS NRO_CONTACTOS,ISNULL(SC.FECHA_REGISTRO,'2021-01-01') " +
                    "AS FECHA_REGISTRO,CC.NOMBRE_RAZON_SOCIAL FROM ST_CONTACTOS SC JOIN ST_CLIENTES CC ON CC.ID_CLIENTE = SC.ID_CLIENTE WHERE SC.ID_CLIENTE LIKE '%{0}%' " +
                    "AND SC.NOMBRE LIKE '%{1}%' AND SC.TELEFONO LIKE '%{2}%' AND SC.CORREO LIKE" +
                    " '%{3}%' AND SC.DOCUMENTO LIKE '%{4}%'",obj.ID_CLIENTE,obj.NOMBRE,obj.TELEFONO,obj.CORREO,obj.DOCUMENTO);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    contacto = new e_Contacto();
                    contacto.ID_CLIENTE = (int)reader["ID_CLIENTE"];
                    contacto.NOMBRE_CLIENTE = (string)reader["NOMBRE_RAZON_SOCIAL"];
                    contacto.NOMBRE = (string)reader["NOMBRE"];
                    contacto.TELEFONO = (string)reader["TELEFONO"];
                    contacto.CORREO = (string)reader["CORREO"];
                    contacto.OBSERVACION = (string)reader["OBSERVACION"];
                    contacto.DOCUMENTO = (string)reader["DOCUMENTO"];
                    contacto.NRO_CONTACTO = (int)reader["NRO_CONTACTOS"];
                    contacto.FECHA_REGISTRO = (DateTime)reader["FECHA_REGISTRO"];
                    lista_contactos.Add(contacto);
                }
                reader.Close();
                return lista_contactos;
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
        public string Add_Ccntacto(e_Contacto obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string insert = string.Format("INSERT INTO ST_CONTACTOS (ID_CLIENTE,NOMBRE,TELEFONO,CORREO,OBSERVACION,DOCUMENTO,NRO_CONTACTOS,FECHA_REGISTRO) VALUES(" +
                    "{0},'{1}','{2}','{3}','{4}','{5}',{6},GETDATE())",obj.ID_CLIENTE,obj.NOMBRE,obj.TELEFONO,obj.CORREO,obj.OBSERVACION,obj.DOCUMENTO,obj.NRO_CONTACTO);
                SqlCommand cmd_0 = new SqlCommand(insert, con);
                cmd_0.ExecuteNonQuery();
                return "Contacto registrado correctamente";
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
        public string last_contacto(string id)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string contacto="1";
                string consulta = "SELECT MAX(NRO_CONTACTOS) AS NRO_CONTACTOS FROM ST_CONTACTOS WHERE ID_CLIENTE = " + id ;
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    contacto = Convert.ToString((int)reader["NRO_CONTACTOS"]+1);
                }
                reader.Close();
                return Convert.ToString(contacto);
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
