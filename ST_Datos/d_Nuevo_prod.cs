using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
   public class d_Nuevo_prod
    {
        d_SQLcon db_conect = new d_SQLcon();

        public List<e_Nuevo_prod>Lista_nuevos_prod()

        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Nuevo_prod> lista = new List<e_Nuevo_prod>();
                e_Nuevo_prod nvo_prod = null;
                string consulta = "SELECT ISNULL(TRY_CONVERT(VARCHAR,FECHA_REGISTRO),'-') AS FECHA_REGISTRO,isnull(try_convert(VARCHAR,UPC),'-') AS UPC," +
                    "isnull(try_convert(VARCHAR,EAN),'-') AS EAN,isnull(TRY_CONVERT(VARCHAR,MANDATORIO),'-') AS MANDATORIO,isnull(TRY_CONVERT(VARCHAR,MODELO),'-') AS MODELO," +
                    "isnull(TRY_CONVERT(VARCHAR,MINI_CODIGO),'-') AS MINICODIGO,isnull(TRY_CONVERT(VARCHAR,PARTNUMBER),'-')AS PARTNUMBER,isnull(TRY_CONVERT(VARCHAR,MARCA),'-')AS MARCA," +
                    "isnull(TRY_CONVERT(VARCHAR,TIPO),'-')AS TIPO,isnull(TRY_CONVERT(VARCHAR,TITULO),'-')AS TITULO,ID_NVOPRD,ISNULL(color,'-')as color, " +
                    "ISNULL(peso,0) as peso, ISNULL(empaque_alto,0) as empaque_alto, ISNULL(empaque_ancho,0) as empaque_ancho, " +
                    "ISNULL(empaque_largo,0) as empaque_largo, ISNULL(producto_alto,0) as producto_alto, ISNULL(producto_largo,0) as producto_largo, " +
                    "ISNULL(producto_ancho,0) as producto_ancho  " +
                    "FROM ST_NVO_PROD  ORDER BY FECHA_PROCESO DESC ";
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    nvo_prod = new e_Nuevo_prod();
                    nvo_prod.Fecha_registro = (string)reader["FECHA_REGISTRO"];
                    nvo_prod.UPC = (string)reader["UPC"];
                    nvo_prod.EAN = (string)reader["EAN"];
                    nvo_prod.Mandatorio = (string)reader["MANDATORIO"];
                    nvo_prod.Modelo = (string)reader["MODELO"];
                    nvo_prod.Minicod = (string)reader["MINICODIGO"];
                    nvo_prod.Partnumb = (string)reader["PARTNUMBER"];
                    nvo_prod.Marca = (string)reader["MARCA"];
                    nvo_prod.Tipo = (string)reader["TIPO"];
                    nvo_prod.Titulo = (string)reader["TITULO"];
                    nvo_prod.Id_nvop = (int)reader["ID_NVOPRD"];
                    nvo_prod.Color = (string)reader["color"];
                    nvo_prod.Peso = Convert.ToString((double)reader["peso"]);
                    nvo_prod.empaque_alto = Convert.ToString((double)reader["empaque_alto"]);
                    nvo_prod.empaque_ancho = Convert.ToString((double)reader["empaque_ancho"]);
                    nvo_prod.empaque_largo = Convert.ToString((double)reader["empaque_largo"]);
                    nvo_prod.producto_alto = Convert.ToString((double)reader["producto_alto"]);
                    nvo_prod.producto_largo = Convert.ToString((double)reader["producto_largo"]);
                    nvo_prod.producto_ancho = Convert.ToString((double)reader["producto_ancho"]);
                    lista.Add(nvo_prod);
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
        public string Ingresar_nuevos_prod(e_Nuevo_prod obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string registra = string.Format("INSERT INTO ST_NVO_PROD_INPUT (FECHA_REGISTRO,UPC,EAN,MANDATORIO," +
                    "MODELO,MINI_CODIGO,PARTNUMBER,MARCA,TIPO,TITULO,COLOR,PESO,EMPAQUE_ANCHO,EMPAQUE_ALTO,EMPAQUE_LARGO," +
                    "PRODUCTO_ALTO,PRODUCTO_LARGO,PRODUCTO_ANCHO) VALUES ('{0}','{1}','{2}','{3}'," +
                    "'{4}','{5}','{6}','{7}','{8}','{9}', '{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')", obj.Fecha_registro,obj.UPC,obj.EAN,
                    obj.Mandatorio,obj.Modelo,obj.Minicod,obj.Partnumb,obj.Marca,obj.Tipo,obj.Titulo, obj.Color,obj.Peso,obj.empaque_ancho,obj.empaque_alto,
                    obj.empaque_largo,obj.producto_alto,obj.producto_largo,obj.producto_ancho);
                SqlCommand cmd_0 = new SqlCommand(registra, con);
                cmd_0.ExecuteNonQuery();
                return "Nuevo producto registrado correctamente";

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
        public string Ingresar_Cons()
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string ordena = "UPDATE ST_NVO_PROD_INPUT SET FECHA_REGISTRO = CONCAT('0',FECHA_REGISTRO) WHERE LEN(FECHA_REGISTRO) = 9";
                string mod = "INSERT INTO ST_NVO_PROD SELECT TRY_CONVERT(DATETIME,CONCAT(SUBSTRING(REPLACE(RTRIM(LTRIM( FECHA_REGISTRO)),'/',''),5,4)," +
                    "SUBSTRING(REPLACE(RTRIM(LTRIM(FECHA_REGISTRO)),'/',''),3,2),SUBSTRING (REPLACE(RTRIM(LTRIM(FECHA_REGISTRO)),'/',''),1,2)))," +
                    "RTRIM(LTRIM(UPC)),RTRIM(LTRIM(EAN)),RTRIM(LTRIM (MANDATORIO)),RTRIM(LTRIM(EAN_UPC)),RTRIM(LTRIM(MODELO)),RTRIM(LTRIM(MINI_CODIGO))," +
                    "RTRIM(LTRIM( PARTNUMBER)),RTRIM(LTRIM(MARCA)),RTRIM(LTRIM(TIPO)), RTRIM(LTRIM(TITULO)),NULL,NULL,NULL,NULL,GETDATE(), " +
                    "ISNULL(CONVERT(varchar,color),'SIN COLOR') AS COLOR,ISNULL(CONVERT(float,PESO),0),ISNULL(CONVERT(float,EMPAQUE_ALTO),0)," +
                    "ISNULL(CONVERT(float,EMPAQUE_ANCHO),0),ISNULL(CONVERT(float,EMPAQUE_LARGO),0), ISNULL(CONVERT(float,PRODUCTO_ALTO),0)," +
                    "ISNULL(CONVERT(float,PRODUCTO_LARGO),0),ISNULL(CONVERT(float,PRODUCTO_ANCHO),0) FROM ST_NVO_PROD_INPUT " +
                    "WHERE PARTNUMBER NOT IN (SELECT PARTNUMBER FROM ST_NVO_PROD)";
                string planta = "INSERT INTO ST_STOCK (UPC,EAN,MANDATORIO,EAN_UPC,MODELO,MINI_CODIGO,PARTNUMBER,MARCA,TIPO," +
                    "TITULO,COLOR,PESO,EMPAQUE_ALTO,EMPAQUE_ANCHO,EMPAQUE_LARGO,PRODUCTO_ALTO,PRODUCTO_ANCHO,PRODUCTO_LARGO)SELECT UPC,EAN,MANDATORIO,EAN_UPC,MODELO," +
                    "MINI_CODIGO,PARTNUMBER,MARCA,TIPO,TITULO,COLOR,PESO,EMPAQUE_ALTO,EMPAQUE_ANCHO,EMPAQUE_LARGO,PRODUCTO_ALTO,PRODUCTO_ANCHO,PRODUCTO_LARGO " +
                    "FROM ST_NVO_PROD WHERE" +
                    " MINI_CODIGO NOT IN(SELECT MINI_CODIGO FROM ST_NVO_PROD WHERE MINI_CODIGO IN (SELECT MINI_CODIGO FROM ST_STOCK))AND " +
                    "FECHA_PROCESO IN (SELECT MAX(FECHA_PROCESO) FROM ST_NVO_PROD)";
                string mandatorio_0 = "UPDATE ST_NVO_PROD SET MANDATORIO = 'UPC' WHERE UPC <> '' OR UPC IS NOT NULL";
                string mandatorio_1 = "UPDATE ST_NVO_PROD SET MANDATORIO = 'EAN' WHERE UPC = '' OR UPC IS  NULL";
                string mandatorio_2 = "UPDATE TOP (1) ST_NVO_PROD SET EAN_UPC = CASE (MANDATORIO) WHEN 'UPC' THEN UPC ELSE EAN END where FECHA_PROCESO = (SELECT MAX(FECHA_PROCESO) FROM ST_NVO_PROD)";
                SqlCommand cmd_0 = new SqlCommand(ordena, con);
                SqlCommand cmd_1 = new SqlCommand(mod, con);
                SqlCommand cmd_2 = new SqlCommand(planta, con);
                SqlCommand cmd_3 = new SqlCommand(mandatorio_0, con);
                SqlCommand cmd_4 = new SqlCommand(mandatorio_1, con);
                SqlCommand cmd_5 = new SqlCommand(mandatorio_2, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                cmd_3.ExecuteNonQuery();
                cmd_4.ExecuteNonQuery();
                cmd_5.ExecuteNonQuery();
                cmd_2.ExecuteNonQuery();
                return null;
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
        public List<e_Marcas> Lista_marcas(e_Marcas obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Marcas> marcas = new List<e_Marcas>();
                e_Marcas marca = null;
                string consulta = string.Format ("SELECT DISTINCT (MARCA) FROM ST_STOCK WHERE MARCA LIKE '%{0}%'",obj.Marca);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    marca = new e_Marcas();
                    marca.Marca = (string)reader["MARCA"];
                    marcas.Add(marca);
                }
                reader.Close();
                return marcas;

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

        public List<e_Tipo> Lista_tipos(e_Tipo obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                List<e_Tipo> tipos = new List<e_Tipo>();
                e_Tipo tipo = null;
                string consulta = string.Format("SELECT DISTINCT (TIPO) FROM ST_STOCK WHERE TIPO LIKE '%{0}%'", obj.Tipo);
                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    tipo = new e_Tipo();
                    tipo.Tipo = (string)reader["TIPO"];
                    tipos.Add(tipo);
                }
                reader.Close();
                return tipos;
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
        public string Modificar_nvo_prod(e_Nuevo_prod obj)
        {
            try
            {
                SqlConnection con = db_conect.Conecta_DB();
                string modif = string.Format("UPDATE ST_NVO_PROD SET UPC = '{0}', EAN='{1}',MODELO = '{2}',MINI_CODIGO = '{3}'," +
                    " PARTNUMBER = '{4}',MARCA = '{5}', TIPO = '{6}',TITULO = '{7}',COLOR='{9}',PESO={10},EMPAQUE_ALTO={11},EMPAQUE_ANCHO={12},EMPAQUE_LARGO={13}," +
                    "PRODUCTO_LARGO={14},PRODUCTO_ANCHO={15},PRODUCTO_ALTO={16} WHERE ID_NVOPRD = {8}", 
                    obj.UPC,obj.EAN,obj.Modelo,obj.Minicod,obj.Partnumb,obj.Marca,obj.Tipo,obj.Titulo,obj.Id_nvop,obj.Color,obj.Peso,obj.empaque_alto,obj.empaque_ancho,obj.empaque_largo,
                    obj.producto_largo,obj.producto_ancho,obj.producto_alto);
                SqlCommand cmd_0 = new SqlCommand(modif, con);
                cmd_0.ExecuteNonQuery();
                return "Se modificó exitosamente";

            }
            catch (Exception)
            {
                return "Ocurrió un problema :C";
            }
            finally
            {
                db_conect.Desconecta_DB();
            }
        } 
    }

}
