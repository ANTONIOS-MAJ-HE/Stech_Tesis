using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ST_Entidades;

namespace ST_Datos
{
   public class d_Planta
    {

        d_SQLcon db_st = new d_SQLcon();
        //Esste query se repite mucho por el codigo, el que codifico esto asi lo hizo, es recomendable que se ponga como SP para asi no ir
        //buscando como modificarlo, yo no lo hice por v,pero seria una gran forma de optimizar y facilitar este codigo....
        //ahi muchas cosas que optimizar, pero ni le toman importancia
        public string Cargar_stock()
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                string truncar = "TRUNCATE TABLE ST_STOCK_HST_CONSULTA";
                string ingresar = "INSERT INTO ST_STOCK_HST_CONSULTA SELECT  a.SKU_SODIMAC,a.SKU_SAGA,a.SKU_TOTTUS,a.SKU_LINIO,a.SKU_RIPLEY,a.SKU_JUNTOZ," +
                    "a.SKU_REALPLAZA,a.SKU_LUMINGO, a.SKU_MLIBRE,a.SKU_CATPHONE,a.SKU_KINGSTON,a.UPC,a.EAN,a.MANDATORIO,a.EAN_UPC,a.MODELO,a.MINI_CODIGO," +
                    "a.PARTNUMBER,a.MARCA, a.TIPO,a.TITULO, ISNULL(a.CORTE_20210528,0) AS CORTE_20210623, ISNULL(E.ENTRADAS,0) AS ENTRADAS, " +

                    "(ISNULL(X.UNI_SAGA,0)+ISNULL(Y.UNI_LINIO,0)+ISNULL(Z.UNI_RIPLEY,0)+ISNULL(F.SALIDAS,0)+ISNULL(W.SALIDAS,0)+ISNULL(M.SALIDAS,0) +" +
                    "ISNULL(TRS.UNI_TRAS,0)+ ISNULL(LMG.UNI_LUMINGO,0)+ISNULL(RPG.UNI_REALP,0)+ " +
                    "ISNULL(MLIBRE.UNI_MLIBRE,0)+ISNULL(CAT.UNI_CAT,0)+ISNULL(PEDIDOS.UNI_PEDIDOS,0)+ISNULL(KNG.UNI_KNG,0)+ISNULL(C.UNI_PEDIDOS,0)+ISNULL(J.UNI_JTZ,0)+ISNULL(CB.UNI_CBX,0)+ISNULL(FLB.UNI_FBL,0) +ISNULL(CONECTA.UNI_CONECTA,0) ) AS SALIDAS, " +  //SE AGREGA +ISNULL(CONECTA.UNI_CONECTA,0)

                    "ISNULL(a.CORTE_20210528,0) + ISNULL(E.ENTRADAS,0) - ISNULL(X.UNI_SAGA,0) - ISNULL(Y.UNI_LINIO,0) - ISNULL(Z.UNI_RIPLEY,0) - ISNULL(F.SALIDAS,0) - " +
                    "ISNULL(W.SALIDAS,0)  - ISNULL(M.SALIDAS,0) - ISNULL(TRS.UNI_TRAS,0) - ISNULL(LMG.UNI_LUMINGO,0)-ISNULL(RPG.UNI_REALP,0)- " +
                    "ISNULL(MLIBRE.UNI_MLIBRE,0) -ISNULL(CAT.UNI_CAT,0)-ISNULL(PEDIDOS.UNI_PEDIDOS,0)-ISNULL(KNG.UNI_KNG,0)-ISNULL(C.UNI_PEDIDOS,0)-ISNULL(J.UNI_JTZ,0)-ISNULL(CB.UNI_CBX,0)-ISNULL(FLB.UNI_FBL,0) - ISNULL(CONECTA.UNI_CONECTA,0) AS STOCK_FINAL   , " +  //SE AGREGA - ISNULL(CONECTA.UNI_CONECTA,0)

                    "ISNULL(X.UNI_SAGA,0) AS V_SAGA, ISNULL(Y.UNI_LINIO,0) AS V_LNO, ISNULL(Z.UNI_RIPLEY,0)AS  V_RPL, ISNULL(PEDIDOS.UNI_PEDIDOS,0)AS V_OFI, " +
                    "ISNULL(LMG.UNI_LUMINGO,0)AS  V_LUMINGO, ISNULL(RPG.UNI_REALP,0) AS V_REALP, ISNULL(MLIBRE.UNI_MLIBRE,0) AS V_MLIBRE, " +
                    "ISNULL(CAT.UNI_CAT,0)AS V_CAT, ISNULL(TRS.UNI_TRAS,0) AS TRASLADOS, 0 AS V_JTZ, 0 AS V_SDMC, 0 AS V_TOTTUS, 0 AS V_DINNERS, MONEDA, " +  //SE AGREGA , ISNULL(CONECTA.UNI_CONECTA,0) AS V_CONECTA
                    "a.COSTO_U_S_IGV_DOLARES,a.COSTO_U_S_IGV_SOLES, GETDATE() AS FECHA_PROCESO,a.SKU_COOLBOX,a.SKU_FALABELLA,a.SKU_CONECTA, ISNULL(CONECTA.UNI_CONECTA,0) AS V_CONECTA  " +  //SE AGREGA ,a.SKU_CONECTA

                    "FROM ST_STOCK AS a LEFT JOIN ( SELECT E.MINICODIGO,SUM(ISNULL(E.CANTIDAD,0)) AS ENTRADAS FROM ST_ENTRADAS_CONS E " +
                    "WHERE YEAR(FECHA_ENTRADA)*10000+MONTH(FECHA_ENTRADA)*100+DAY(FECHA_ENTRADA) >= 20210623 GROUP BY E.MINICODIGO)E ON a.MINI_CODIGO = E.MINICODIGO " +

                    "LEFT JOIN( SELECT S.MINICODIGO,SUM(ISNULL(S.CANTIDAD,0)) AS SALIDAS FROM ST_SALIDAS_CONS S " +
                    "WHERE YEAR(S.FECHA_SALIDA)*10000+MONTH(FECHA_SALIDA)*100+DAY(FECHA_SALIDA) >= 20210623 AND CANAL = 'FACEBOOK' GROUP BY S.MINICODIGO )F " +
                    "ON F.MINICODIGO = a.EAN_UPC " +

                    "LEFT JOIN( SELECT S.MINICODIGO,SUM(ISNULL(S.CANTIDAD,0)) AS SALIDAS FROM ST_SALIDAS_CONS S " +
                    "WHERE YEAR(S.FECHA_SALIDA)*10000+MONTH(FECHA_SALIDA)*100+DAY(FECHA_SALIDA) >= 20210623 AND CANAL = 'WHATSAPP' GROUP BY S.MINICODIGO )W " +
                    "ON W.MINICODIGO = a.MINI_CODIGO " +

                    "LEFT JOIN ( SELECT d.MINI_CODIGO, SUM(CANTIDAD) AS UNI_PEDIDOS FROM ST_PEDIDO_DETALLE d WHERE YEAR(d.FECHA_PEDIDO)*10000+MONTH(d.FECHA_PEDIDO)*100+DAY(d.FECHA_PEDIDO) >= 20210623 AND CANAL LIKE '%COOLBOX%' GROUP BY d.MINI_CODIGO ) C ON a.MINI_CODIGO= C.MINI_CODIGO " +

                    "LEFT JOIN (SELECT JT.PART_NUMB_REAL,SUM(UNIDADES_REAL) AS UNI_JTZ FROM OC_JTZ_CONS JT WHERE YEAR(JT.FECHA_PROCESO)*10000+MONTH(JT.FECHA_PROCESO)*100+DAY(JT.FECHA_PROCESO) >= 20230531 GROUP BY JT.PART_NUMB_REAL) J ON a.PARTNUMBER=J.PART_NUMB_REAL " +

                    "LEFT JOIN (SELECT C.PART_NUMB_REAL, SUM(UNIDADES_REAL) AS UNI_FBL FROM OC_FBL_CONS c WHERE YEAR(c.FECHA_PROCESO)*10000+MONTH(c.FECHA_PROCESO)*100+DAY(c.FECHA_PROCESO) >= 20210623 AND FECHA_DESPACHO is not null GROUP BY C.PART_NUMB_REAL) FLB ON a.PARTNUMBER = FLB.PART_NUMB_REAL " +

                    "LEFT JOIN (SELECT C.PARTNUMBER_REAL,SUM(UNIDADES_REAL) AS UNI_CBX FROM OC_CLB_CONS C WHERE YEAR(C.FECHA_PROCESO)*10000+MONTH(C.FECHA_PROCESO)*100+DAY(C.FECHA_PROCESO) >= 20230601 AND FECHA_DESPACHO is not null GROUP BY C.PARTNUMBER_REAL) CB ON a.PARTNUMBER=CB.PARTNUMBER_REAL " +

                    "LEFT JOIN( SELECT S.MINICODIGO,SUM(ISNULL(S.CANTIDAD,0)) AS SALIDAS FROM ST_SALIDAS_CONS S WHERE YEAR(S.FECHA_SALIDA)*10000+MONTH(FECHA_SALIDA)*100+DAY(FECHA_SALIDA) >= 20210623 AND CANAL = 'MERCADO LIBRE' AND TIPO = 'VENTA' GROUP BY S.MINICODIGO )M ON M.MINICODIGO = a.MINI_CODIGO " +
                    
                    "LEFT JOIN( SELECT S.MINICODIGO,SUM(ISNULL(S.CANTIDAD,0)) AS SALIDAS FROM ST_SALIDAS_CONS S WHERE YEAR(S.FECHA_SALIDA)*10000+MONTH(FECHA_SALIDA)*100+DAY(FECHA_SALIDA) >= 20210623 AND CANAL = 'OFICINA' GROUP BY S.MINICODIGO)OFI ON OFI.MINICODIGO = a.MINI_CODIGO " +
                    "LEFT JOIN( SELECT S.MINICODIGO,SUM(ISNULL(S.CANTIDAD,0)) AS UNI_TRAS FROM ST_SALIDAS_CONS S WHERE YEAR(S.FECHA_SALIDA)*10000+MONTH(FECHA_SALIDA)*100+DAY(FECHA_SALIDA) >= 20210623 AND TIPO= 'TRASLADO' GROUP BY S.MINICODIGO )TRS ON TRS.MINICODIGO = a.MINI_CODIGO " +
                    "LEFT JOIN (SELECT B.PART_NUMB_REAL,SUM(UNIDADES_REAL) AS UNI_SAGA FROM OC_SF_CONS B WHERE YEAR(b.FECHA_PROCESO)*10000+MONTH(b.FECHA_PROCESO)*100+DAY(b.FECHA_PROCESO) >= 20210623 GROUP BY B.PART_NUMB_REAL) X ON a.PARTNUMBER = X.PART_NUMB_REAL " +
                    "LEFT JOIN (SELECT C.PART_NUMB_REAL, SUM(UNIDADES_REAL) AS UNI_LINIO FROM OC_LNO_CONS c WHERE YEAR(c.FECHA_PROCESO)*10000+MONTH(c.FECHA_PROCESO)*100+DAY(c.FECHA_PROCESO) >= 20210623 AND FECHA_DESPACHO is not null GROUP BY C.PART_NUMB_REAL) Y ON a.PARTNUMBER = Y.PART_NUMB_REAL " +
                    "LEFT JOIN ( SELECT d.PART_NUMB_REAL, SUM(UNIDADES_REAL) AS UNI_RIPLEY FROM OC_RPL_CONS d WHERE YEAR(d.FECHA_PROCESO)*10000+MONTH(d.FECHA_PROCESO)*100+DAY(d.FECHA_PROCESO) >= 20210623 AND FECHA_DESPACHO is not null GROUP BY d.PART_NUMB_REAL) Z ON a.PARTNUMBER = Z.PART_NUMB_REAL " +
                    "LEFT JOIN ( SELECT d.SKU_SELLER, SUM(UNIDADES_REAL) AS UNI_LUMINGO FROM OC_LMG_CONS d WHERE YEAR(d.FECHA_PROCESO)*10000+MONTH(d.FECHA_PROCESO)*100+DAY(d.FECHA_PROCESO) >= 20210623 GROUP BY d.SKU_SELLER) LMG ON a.SKU_LUMINGO = LMG.SKU_SELLER LEFT JOIN ( SELECT d.PARTNUMBER_REAL, SUM(UNIDADES_REAL) AS UNI_REALP FROM OC_RPG_CONS d WHERE YEAR(d.FECHA_PROCESO)*10000+MONTH(d.FECHA_PROCESO)*100+DAY(d.FECHA_PROCESO) >= 20210623 AND FECHA_DESPACHO is not null GROUP BY d.PARTNUMBER_REAL) RPG ON a.PARTNUMBER= RPG.PARTNUMBER_REAL LEFT JOIN ( SELECT d.PARTNUMB_REAL, SUM(UNIDADES_REAL) AS UNI_MLIBRE FROM OC_MLIBRE_CONS d WHERE YEAR(d.FECHA_PROCESO)*10000+MONTH(d.FECHA_PROCESO)*100+DAY(d.FECHA_PROCESO) >= 20210623 GROUP BY d.PARTNUMB_REAL) MLIBRE ON a.PARTNUMBER= MLIBRE.PARTNUMB_REAL LEFT JOIN (SELECT d.PARTNUMB_REAL, SUM(UNIDADES_REAL) AS UNI_CAT FROM OC_CATPHONE_CONS d WHERE YEAR(d.FECHA_PROCESO)*10000+MONTH(d.FECHA_PROCESO)*100+DAY(d.FECHA_PROCESO) >= 20210623 GROUP BY d.PARTNUMB_REAL) CAT ON a.PARTNUMBER= CAT.PARTNUMB_REAL LEFT JOIN ( SELECT d.MINI_CODIGO, SUM(CANTIDAD) AS UNI_PEDIDOS FROM ST_PEDIDO_DETALLE d WHERE YEAR(d.FECHA_PEDIDO)*10000+MONTH(d.FECHA_PEDIDO)*100+DAY(d.FECHA_PEDIDO) >= 20210623 AND CANAL LIKE '%OFICINA%' GROUP BY d.MINI_CODIGO ) PEDIDOS ON a.MINI_CODIGO= PEDIDOS.MINI_CODIGO LEFT JOIN ( SELECT d.PART_NUMB_REAL, SUM(CANTIDAD) AS UNI_KNG FROM OC_KNG_CONS d WHERE YEAR(d.FECHA_PROCESO)*10000+MONTH(d.FECHA_PROCESO)*100+DAY(d.FECHA_PROCESO) >= 20210623 GROUP BY d.PART_NUMB_REAL ) KNG ON a.PARTNUMBER= KNG.PART_NUMB_REAL" +
                    " LEFT JOIN (SELECT con.PART_NUMB_REAL,SUM(con.UNIDADES_REAL) AS UNI_CONECTA FROM OC_CONECTA_CONS con WHERE YEAR(con.FECHA_PROCESO)*10000 + MONTH(con.FECHA_PROCESO)*100 + DAY(con.FECHA_PROCESO) >= 20210623 GROUP BY con.PART_NUMB_REAL) CONECTA ON a.PARTNUMBER = CONECTA.PART_NUMB_REAL";  ///SE AGREGA EL CANAL DE CONECTA
                SqlCommand cmd_0 = new SqlCommand(truncar, con);
                SqlCommand cmd_1 = new SqlCommand(ingresar, con);
                cmd_0.ExecuteNonQuery();
                cmd_1.ExecuteNonQuery();
                return null;

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

        public List<e_Planta> Lista_stock(e_Planta obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> listado = new List<e_Planta>();
                e_Planta planta = null;
                string consulta =string.Format( "SELECT ISNULL(SKU_SODIMAC,'-') AS SKU_SODIMAC,ISNULL(SKU_SAGA, '-') AS SKU_SAGA,ISNULL(SKU_TOTTUS,'-') AS" +
                    " SKU_TOTTUS,ISNULL(SKU_LINIO,'-')AS SKU_LINIO,ISNULL (SKU_RIPLEY,'-')AS SKU_RIPLEY,ISNULL(SKU_JUNTOZ,'-')AS" +
                    " SKU_JUNTOZ,ISNULL(SKU_REALPLAZA,'-') AS SKU_REALPLAZA,ISNULL(SKU_LUMINGO,'-') AS SKU_LUMINGO,ISNULL(SKU_MLIBRE,'-') AS" +
                    " SKU_MLIBRE,ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE,ISNULL(SKU_KINGSTON,'-') AS SKU_KINGSTON,ISNULL(A.UPC,'-') AS " +
                    "UPC,ISNULL(A.EAN,'-') AS EAN,ISNULL(A.MANDATORIO,'-') AS MANDATORIO,ISNULL(A.EAN_UPC,'-')AS EAN_UPC,ISNULL(A.MODELO,'-')AS" +
                    " MODELO,ISNULL(A.MINI_CODIGO,'-') AS MINI_CODIGO,ISNULL(A.PARTNUMBER,'-') AS PARTNUMBER,ISNULL(A.MARCA,'-')AS MARCA,ISNULL" +
                    "(A.TIPO,'-') AS TIPO,ISNULL(A.TITULO,'-') AS TITULO,ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210623),'-') AS CORTE_20210623,ISNULL" +
                    "(TRY_CONVERT(VARCHAR,ENTRADAS),'-') AS ENTRADAS,ISNULL(TRY_CONVERT(VARCHAR,SALIDAS),'-') AS SALIDAS,ISNULL(TRY_CONVERT" +
                    "(VARCHAR,A.STOCK_FINAL),'-')AS STOCK_FINAL,ISNULL(TRY_CONVERT(VARCHAR,V_SAGA),'-')AS V_SAGA,ISNULL(TRY_CONVERT(VARCHAR,V_LNO),'-')AS" +
                    " V_LNO,ISNULL(TRY_CONVERT(VARCHAR,V_RPL),'-')AS V_RPL,ISNULL(TRY_CONVERT(VARCHAR,V_OFI),'-')AS V_OFI,ISNULL(TRY_CONVERT" +
                    "(VARCHAR,V_LUMINGO),'-')AS V_LUMINGO,ISNULL(TRY_CONVERT(VARCHAR,V_REALP),'-')AS V_REALP,ISNULL(TRY_CONVERT(VARCHAR,V_MLIBRE),'-')AS " +
                    "V_MLIBRE,ISNULL(TRY_CONVERT(VARCHAR,V_CAT),'-') AS V_CAT,ISNULL(TRY_CONVERT(VARCHAR,TRASLADOS),'-')AS TRASLADOS,ISNULL" +
                    "(TRY_CONVERT(VARCHAR,V_JTZ),'-')AS V_JTZ,ISNULL(TRY_CONVERT(VARCHAR,V_SDMC),'-')AS V_SDMC,ISNULL(TRY_CONVERT(VARCHAR,V_TOTTUS),'-')AS" +
                    " V_TOTTUS,ISNULL(TRY_CONVERT(VARCHAR,V_DINNERS),'-')AS V_DINNERS,  ISNULL(TRY_CONVERT(VARCHAR,V_CONECTA),'-')AS V_CONECTA,  ISNULL(A.MONEDA,'-')AS MONEDA,ISNULL(TRY_CONVERT" +  //SE AGREGA ISNULL(TRY_CONVERT(VARCHAR,V_CONECTA),'-')AS V_CONECTA
                    "(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_DOLARES)),'-') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_SOLES)),'-') AS " +
                    "COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,B.FECHA_REGISTRO,5),'01-12-20') AS FECHA_INGRESO, isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2)," +
                    "(CASE WHEN (COSTO_U_S_IGV_DOLARES >0) THEN COSTO_U_S_IGV_DOLARES*1.18*{0} WHEN (COSTO_U_S_IGV_DOLARES IS NULL) THEN COSTO_U_S_IGV_SOLES*1.18 END))),'-') AS COSTO_C_IGV_SOLES  " +
                    ",isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),(CASE WHEN (COSTO_U_S_IGV_SOLES >0) THEN COSTO_U_S_IGV_SOLES*1.18 WHEN (COSTO_U_S_IGV_SOLES IS NULL) THEN 0 END))),'-') AS COSTO_C_IGV_SOLES_2 " +
                    ",ISNULL(TRY_CONVERT(varchar,K.COSTO_UNI_PON_DOL),'-') AS COSTO_UNI_PON_DOL,ISNULL (SKU_COOLBOX,'-')AS SKU_COOLBOX,ISNULL (SKU_FALABELLA,'-')AS SKU_FALABELLA,  ISNULL (SKU_CONECTA,'-') AS SKU_CONECTA " + //SE AGREGA ,  ISNULL (SKU_CONECTA,'-') AS SKU_CONECTA
                    "FROM ST_STOCK_HST_CONSULTA A LEFT JOIN " +
                    "ST_NVO_PROD B ON A.MINI_CODIGO = B.MINI_CODIGO " +
                    "LEFT JOIN ST_KARDEX K ON K.PARTNUMBER = A.PARTNUMBER AND K.ID_KARDEX = (SELECT MAX(ID_KARDEX) FROM ST_KARDEX WHERE PARTNUMBER=A.PARTNUMBER)" +
                    "ORDER BY MARCA , MINI_CODIGO", obj.tipo_camb);

                SqlCommand cmd_0 = new SqlCommand(consulta, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.STOCK_INICIAL_20210623 = (string)reader["CORTE_20210623"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES = (string)reader["COSTO_C_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES_2 = (string)reader["COSTO_C_IGV_SOLES_2"];
                    planta.EAN = (string)reader["EAN"];
                    planta.EAN_UPC = (string)reader["EAN_UPC"];
                    planta.ENTRADAS = (string)reader["ENTRADAS"];
                    planta.MANDATORIO = (string)reader["MANDATORIO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MONEDA = (string)reader["MONEDA"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.SALIDAS = (string)reader["SALIDAS"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.STOCK_FINAL = (string)reader["STOCK_FINAL"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.TITULO = (string)reader["TITULO"];
                    //planta.TRASLADOS = (string)reader["TRASLADOS"];
                    planta.UPC = (string)reader["UPC"];
                    //planta.V_CAT = (string)reader["V_CAT"];
                    //planta.V_DINNERS = (string)reader["V_DINNERS"];
                    //planta.V_JTZ = (string)reader["V_JTZ"];
                    //planta.V_LNO = (string)reader["V_LNO"];
                    //planta.V_LUMINGO = (string)reader["V_LUMINGO"];
                    //planta.V_MLIBRE = (string)reader["V_MLIBRE"];
                    //planta.V_OFI = (string)reader["V_OFI"];
                    //planta.V_REALP = (string)reader["V_REALP"];
                    //planta.V_RPL = (string)reader["V_RPL"];
                    //planta.V_SAGA = (string)reader["V_SAGA"];
                    //planta.V_SDMC = (string)reader["V_SDMC"];
                    //planta.V_TOTTUS = (string)reader["V_TOTTUS"];
                    planta.FECHA_INGRESO = Convert.ToDateTime((string)reader["FECHA_INGRESO"]);
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.SKU_FALABELLA = (string)reader["SKU_FALABELLA"];

                    planta.SKU_CONECTA = (string)reader["SKU_CONECTA"];         //SE AGREGA planta.SKU_CONECTA = (string)reader["SKU_CONECTA"];

                    planta.Kardex_Prec_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    listado.Add(planta);
                }
                reader.Close();
                return listado;              
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
        public List<e_Planta> Lista_filter(e_Planta obj)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> listado = new List<e_Planta>();
                e_Planta planta = null;
                string consult = string.Format("SELECT ISNULL(SKU_SODIMAC,'-') AS SKU_SODIMAC,ISNULL(SKU_SAGA, '-') AS SKU_SAGA,ISNULL(SKU_TOTTUS,'-') AS" +
                    " SKU_TOTTUS,ISNULL(SKU_LINIO,'-')AS SKU_LINIO,ISNULL (SKU_RIPLEY,'-')AS SKU_RIPLEY,ISNULL(SKU_JUNTOZ,'-')AS" +
                    " SKU_JUNTOZ,ISNULL(SKU_REALPLAZA,'-') AS SKU_REALPLAZA,ISNULL(SKU_LUMINGO,'-') AS SKU_LUMINGO,ISNULL(SKU_MLIBRE,'-') AS" +
                    " SKU_MLIBRE,ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE,ISNULL(SKU_KINGSTON,'-') AS SKU_KINGSTON,ISNULL(A.UPC,'-') AS " +
                    "UPC,ISNULL(A.EAN,'-') AS EAN,ISNULL(A.MANDATORIO,'-') AS MANDATORIO,ISNULL(A.EAN_UPC,'-')AS EAN_UPC,ISNULL(A.MODELO,'-')AS" +
                    " MODELO,ISNULL(A.MINI_CODIGO,'-') AS MINI_CODIGO,ISNULL(A.PARTNUMBER,'-') AS PARTNUMBER,ISNULL(A.MARCA,'-')AS MARCA,ISNULL" +
                    "(A.TIPO,'-') AS TIPO,ISNULL(A.TITULO,'-') AS TITULO,ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210623),'-') AS CORTE_20210623,ISNULL" +
                    "(TRY_CONVERT(VARCHAR,ENTRADAS),'-') AS ENTRADAS,ISNULL(TRY_CONVERT(VARCHAR,SALIDAS),'-') AS SALIDAS,ISNULL(TRY_CONVERT" +
                    "(VARCHAR,A.STOCK_FINAL),'-')AS STOCK_FINAL,ISNULL(TRY_CONVERT(VARCHAR,V_SAGA),'-')AS V_SAGA,ISNULL(TRY_CONVERT(VARCHAR,V_LNO),'-')AS" +
                    " V_LNO,ISNULL(TRY_CONVERT(VARCHAR,V_RPL),'-')AS V_RPL,ISNULL(TRY_CONVERT(VARCHAR,V_OFI),'-')AS V_OFI,ISNULL(TRY_CONVERT" +
                    "(VARCHAR,V_LUMINGO),'-')AS V_LUMINGO,ISNULL(TRY_CONVERT(VARCHAR,V_REALP),'-')AS V_REALP,ISNULL(TRY_CONVERT(VARCHAR,V_MLIBRE),'-')AS " +
                    "V_MLIBRE,ISNULL(TRY_CONVERT(VARCHAR,V_CAT),'-') AS V_CAT,ISNULL(TRY_CONVERT(VARCHAR,TRASLADOS),'-')AS TRASLADOS,ISNULL" +
                    "(TRY_CONVERT(VARCHAR,V_JTZ),'-')AS V_JTZ,ISNULL(TRY_CONVERT(VARCHAR,V_SDMC),'-')AS V_SDMC,ISNULL(TRY_CONVERT(VARCHAR,V_TOTTUS),'-')AS" +
                    " V_TOTTUS,ISNULL(TRY_CONVERT(VARCHAR,V_DINNERS),'-')AS V_DINNERS,ISNULL(A.MONEDA,'-')AS MONEDA,ISNULL(TRY_CONVERT" +
                    "(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_DOLARES)),'-') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_SOLES)),'-') AS " +
                    "COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,B.FECHA_REGISTRO,5),'01-12-20') AS FECHA_INGRESO, isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2)," +
                    "(CASE WHEN (COSTO_U_S_IGV_DOLARES >0) THEN COSTO_U_S_IGV_DOLARES*1.18*{8} WHEN (COSTO_U_S_IGV_DOLARES IS NULL) THEN COSTO_U_S_IGV_SOLES*1.18 END))),'-') AS COSTO_C_IGV_SOLES  " +
                    ",isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),(CASE WHEN (COSTO_U_S_IGV_SOLES >0) THEN COSTO_U_S_IGV_SOLES*1.18 WHEN (COSTO_U_S_IGV_SOLES IS NULL) THEN 0 END))),'-') AS COSTO_C_IGV_SOLES_2 " +
                    ",ISNULL(TRY_CONVERT(varchar,K.COSTO_UNI_PON_DOL),'-') AS COSTO_UNI_PON_DOL,ISNULL (SKU_COOLBOX,'-')AS SKU_COOLBOX,ISNULL (SKU_FALABELLA,'-')AS SKU_FALABELLA ,ISNULL (SKU_CONECTA,'-')AS SKU_CONECTA " + //AGREGANDO CONECTA
                    "FROM ST_STOCK_HST_CONSULTA A LEFT JOIN " +
                    "ST_NVO_PROD B ON A.MINI_CODIGO = B.MINI_CODIGO " +
                    "LEFT JOIN ST_KARDEX K ON K.PARTNUMBER = A.PARTNUMBER AND K.ID_KARDEX = (SELECT MAX(ID_KARDEX) FROM ST_KARDEX WHERE PARTNUMBER=A.PARTNUMBER)" +
                    "   where A.FECHA_PROCESO = (SELECT MAX(FECHA_PROCESO)FROM ST_STOCK_HST_CONSULTA) AND A.MINI_CODIGO LIKE '%{0}%' AND " +
                    "A.TITULO LIKE '%{1}%' AND A.MARCA LIKE '%{2}%' AND (A.EAN LIKE '%{3}%' OR A.UPC LIKE '%{3}%') AND A.TIPO LIKE '%{4}%' AND " +
                    "A.MODELO LIKE '%{5}%' AND A.PARTNUMBER LIKE '%{6}%' ORDER BY A.MARCA,A.MINI_CODIGO"
                    , obj.MINI_CODIGO, obj.TITULO, obj.MARCA, obj.EAN_UPC, obj.TIPO, obj.MODELO, obj.PARTNUMBER, obj.SKU_CATPHONE, obj.tipo_camb);
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    string costo_s = (string)reader["COSTO_C_IGV_SOLES"];
                    planta = new e_Planta();
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.STOCK_INICIAL_20210623 = (string)reader["CORTE_20210623"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES = (string)reader["COSTO_C_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES_2 = (string)reader["COSTO_C_IGV_SOLES_2"];
                    planta.EAN = (string)reader["EAN"];
                    planta.EAN_UPC = (string)reader["EAN_UPC"];
                    planta.ENTRADAS = (string)reader["ENTRADAS"];
                    planta.MANDATORIO = (string)reader["MANDATORIO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MONEDA = (string)reader["MONEDA"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.SALIDAS = (string)reader["SALIDAS"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.STOCK_FINAL = (string)reader["STOCK_FINAL"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.TITULO = (string)reader["TITULO"];
                    //planta.TRASLADOS = (string)reader["TRASLADOS"];
                    planta.UPC = (string)reader["UPC"];
                    //planta.V_CAT = (string)reader["V_CAT"];
                    //planta.V_DINNERS = (string)reader["V_DINNERS"];
                    //planta.V_JTZ = (string)reader["V_JTZ"];
                    //planta.V_LNO = (string)reader["V_LNO"];
                    //planta.V_LUMINGO = (string)reader["V_LUMINGO"];
                    //planta.V_MLIBRE = (string)reader["V_MLIBRE"];
                    //planta.V_OFI = (string)reader["V_OFI"];
                    //planta.V_REALP = (string)reader["V_REALP"];
                    //planta.V_RPL = (string)reader["V_RPL"];
                    //planta.V_SAGA = (string)reader["V_SAGA"];
                    //planta.V_SDMC = (string)reader["V_SDMC"];
                    //planta.V_TOTTUS = (string)reader["V_TOTTUS"];
                    planta.FECHA_INGRESO = Convert.ToDateTime((string)reader["FECHA_INGRESO"]);
                    planta.Kardex_Prec_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.SKU_FALABELLA = (string)reader["SKU_FALABELLA"];
                    planta.SKU_CONECTA = (string)reader["SKU_CONECTA"];  //AGREGANDO CONECTA
                    listado.Add(planta);
                }
                reader.Close();
                return listado;

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
        //Filtra por SKU
        public List<e_Planta> BuscarSKU(string SKU, string canal, string TC)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> listado = new List<e_Planta>();
                e_Planta planta = null;
                string consult = string.Format("SELECT ISNULL(SKU_SODIMAC,'-') AS SKU_SODIMAC,ISNULL(SKU_SAGA, '-') AS SKU_SAGA,ISNULL(SKU_TOTTUS,'-') AS" +
                    " SKU_TOTTUS,ISNULL(SKU_LINIO,'-')AS SKU_LINIO,ISNULL (SKU_RIPLEY,'-')AS SKU_RIPLEY,ISNULL(SKU_JUNTOZ,'-')AS" +
                    " SKU_JUNTOZ,ISNULL(SKU_REALPLAZA,'-') AS SKU_REALPLAZA,ISNULL(SKU_LUMINGO,'-') AS SKU_LUMINGO,ISNULL(SKU_MLIBRE,'-') AS" +
                    " SKU_MLIBRE,ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE,ISNULL(SKU_KINGSTON,'-') AS SKU_KINGSTON,ISNULL(A.UPC,'-') AS " +
                    "UPC,ISNULL(A.EAN,'-') AS EAN,ISNULL(A.MANDATORIO,'-') AS MANDATORIO,ISNULL(A.EAN_UPC,'-')AS EAN_UPC,ISNULL(A.MODELO,'-')AS" +
                    " MODELO,ISNULL(A.MINI_CODIGO,'-') AS MINI_CODIGO,ISNULL(A.PARTNUMBER,'-') AS PARTNUMBER,ISNULL(A.MARCA,'-')AS MARCA,ISNULL" +
                    "(A.TIPO,'-') AS TIPO,ISNULL(A.TITULO,'-') AS TITULO,ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210623),'-') AS CORTE_20210623,ISNULL" +
                    "(TRY_CONVERT(VARCHAR,ENTRADAS),'-') AS ENTRADAS,ISNULL(TRY_CONVERT(VARCHAR,SALIDAS),'-') AS SALIDAS,ISNULL(TRY_CONVERT" +
                    "(VARCHAR,A.STOCK_FINAL),'-')AS STOCK_FINAL,ISNULL(TRY_CONVERT(VARCHAR,V_SAGA),'-')AS V_SAGA,ISNULL(TRY_CONVERT(VARCHAR,V_LNO),'-')AS" +
                    " V_LNO,ISNULL(TRY_CONVERT(VARCHAR,V_RPL),'-')AS V_RPL,ISNULL(TRY_CONVERT(VARCHAR,V_OFI),'-')AS V_OFI,ISNULL(TRY_CONVERT" +
                    "(VARCHAR,V_LUMINGO),'-')AS V_LUMINGO,ISNULL(TRY_CONVERT(VARCHAR,V_REALP),'-')AS V_REALP,ISNULL(TRY_CONVERT(VARCHAR,V_MLIBRE),'-')AS " +
                    "V_MLIBRE,ISNULL(TRY_CONVERT(VARCHAR,V_CAT),'-') AS V_CAT,ISNULL(TRY_CONVERT(VARCHAR,TRASLADOS),'-')AS TRASLADOS,ISNULL" +
                    "(TRY_CONVERT(VARCHAR,V_JTZ),'-')AS V_JTZ,ISNULL(TRY_CONVERT(VARCHAR,V_SDMC),'-')AS V_SDMC,ISNULL(TRY_CONVERT(VARCHAR,V_TOTTUS),'-')AS" +
                    " V_TOTTUS,ISNULL(TRY_CONVERT(VARCHAR,V_DINNERS),'-')AS V_DINNERS,ISNULL(A.MONEDA,'-')AS MONEDA,ISNULL(TRY_CONVERT" +
                    "(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_DOLARES)),'-') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_SOLES)),'-') AS " +
                    "COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,B.FECHA_REGISTRO,5),'01-12-20') AS FECHA_INGRESO, isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2)," +
                    "(CASE WHEN (COSTO_U_S_IGV_DOLARES >0) THEN COSTO_U_S_IGV_DOLARES*1.18*" + TC + " WHEN (COSTO_U_S_IGV_DOLARES IS NULL) THEN COSTO_U_S_IGV_SOLES*1.18 END))),'-') AS COSTO_C_IGV_SOLES  " +
                    ",isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),(CASE WHEN (COSTO_U_S_IGV_SOLES >0) THEN COSTO_U_S_IGV_SOLES*1.18 WHEN (COSTO_U_S_IGV_SOLES IS NULL) THEN 0 END))),'-') AS COSTO_C_IGV_SOLES_2 " +
                    ",ISNULL(TRY_CONVERT(varchar,K.COSTO_UNI_PON_DOL),'-') AS COSTO_UNI_PON_DOL,ISNULL (SKU_COOLBOX,'-')AS SKU_COOLBOX,ISNULL (SKU_FALABELLA,'-')AS SKU_FALABELLA  ,ISNULL (SKU_CONECTA,'-')AS SKU_CONECTA " + //AGREGANDO CONECTA
                    "FROM ST_STOCK_HST_CONSULTA A LEFT JOIN " +
                    "ST_NVO_PROD B ON A.MINI_CODIGO = B.MINI_CODIGO " +
                    "LEFT JOIN ST_KARDEX K ON K.PARTNUMBER = A.PARTNUMBER AND K.ID_KARDEX = (SELECT MAX(ID_KARDEX) FROM ST_KARDEX WHERE PARTNUMBER=A.PARTNUMBER)" +
                    "where A.FECHA_PROCESO = (SELECT MAX(FECHA_PROCESO)FROM ST_STOCK_HST_CONSULTA) AND SKU_" + canal + " = '" + SKU + "'");
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.STOCK_INICIAL_20210623 = (string)reader["CORTE_20210623"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES = (string)reader["COSTO_C_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES_2 = (string)reader["COSTO_C_IGV_SOLES_2"];
                    planta.EAN = (string)reader["EAN"];
                    planta.EAN_UPC = (string)reader["EAN_UPC"];
                    planta.ENTRADAS = (string)reader["ENTRADAS"];
                    planta.MANDATORIO = (string)reader["MANDATORIO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MONEDA = (string)reader["MONEDA"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.SALIDAS = (string)reader["SALIDAS"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.STOCK_FINAL = (string)reader["STOCK_FINAL"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.TITULO = (string)reader["TITULO"];
                    //planta.TRASLADOS = (string)reader["TRASLADOS"];
                    planta.UPC = (string)reader["UPC"];
                    //planta.V_CAT = (string)reader["V_CAT"];
                    //planta.V_DINNERS = (string)reader["V_DINNERS"];
                    //planta.V_JTZ = (string)reader["V_JTZ"];
                    //planta.V_LNO = (string)reader["V_LNO"];
                    //planta.V_LUMINGO = (string)reader["V_LUMINGO"];
                    //planta.V_MLIBRE = (string)reader["V_MLIBRE"];
                    //planta.V_OFI = (string)reader["V_OFI"];
                    //planta.V_REALP = (string)reader["V_REALP"];
                    //planta.V_RPL = (string)reader["V_RPL"];
                    //planta.V_SAGA = (string)reader["V_SAGA"];
                    //planta.V_SDMC = (string)reader["V_SDMC"];
                    //planta.V_TOTTUS = (string)reader["V_TOTTUS"];
                    planta.FECHA_INGRESO = Convert.ToDateTime((string)reader["FECHA_INGRESO"]);
                    planta.Kardex_Prec_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.SKU_FALABELLA = (string)reader["SKU_FALABELLA"];
                    planta.SKU_CONECTA = (string)reader["SKU_CONECTA"];  //AGREGANDO CONECTA
                    listado.Add(planta);
                }
                reader.Close();
                return listado;

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
        public List<e_Planta> ListrarFiltrWords(string filtro1, string TC)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> listado = new List<e_Planta>();
                e_Planta planta = null;
                string consult = "SELECT ISNULL(SKU_SODIMAC,'-') AS SKU_SODIMAC,ISNULL(SKU_SAGA, '-') AS SKU_SAGA,ISNULL(SKU_TOTTUS,'-') AS" +
                " SKU_TOTTUS,ISNULL(SKU_LINIO,'-')AS SKU_LINIO,ISNULL (SKU_RIPLEY,'-')AS SKU_RIPLEY,ISNULL(SKU_JUNTOZ,'-')AS" +
                " SKU_JUNTOZ,ISNULL(SKU_REALPLAZA,'-') AS SKU_REALPLAZA,ISNULL(SKU_LUMINGO,'-') AS SKU_LUMINGO,ISNULL(SKU_MLIBRE,'-') AS" +
                " SKU_MLIBRE,ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE,ISNULL(SKU_KINGSTON,'-') AS SKU_KINGSTON,ISNULL(A.UPC,'-') AS " +
                "UPC,ISNULL(A.EAN,'-') AS EAN,ISNULL(A.MANDATORIO,'-') AS MANDATORIO,ISNULL(A.EAN_UPC,'-')AS EAN_UPC,ISNULL(A.MODELO,'-')AS" +
                " MODELO,ISNULL(A.MINI_CODIGO,'-') AS MINI_CODIGO,ISNULL(A.PARTNUMBER,'-') AS PARTNUMBER,ISNULL(A.MARCA,'-')AS MARCA,ISNULL" +
                "(A.TIPO,'-') AS TIPO,ISNULL(A.TITULO,'-') AS TITULO,ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210623),'-') AS CORTE_20210623,ISNULL" +
                "(TRY_CONVERT(VARCHAR,ENTRADAS),'-') AS ENTRADAS,ISNULL(TRY_CONVERT(VARCHAR,SALIDAS),'-') AS SALIDAS,ISNULL(TRY_CONVERT" +
                "(VARCHAR,A.STOCK_FINAL),'-')AS STOCK_FINAL,ISNULL(TRY_CONVERT(VARCHAR,V_SAGA),'-')AS V_SAGA,ISNULL(TRY_CONVERT(VARCHAR,V_LNO),'-')AS" +
                " V_LNO,ISNULL(TRY_CONVERT(VARCHAR,V_RPL),'-')AS V_RPL,ISNULL(TRY_CONVERT(VARCHAR,V_OFI),'-')AS V_OFI,ISNULL(TRY_CONVERT" +
                "(VARCHAR,V_LUMINGO),'-')AS V_LUMINGO,ISNULL(TRY_CONVERT(VARCHAR,V_REALP),'-')AS V_REALP,ISNULL(TRY_CONVERT(VARCHAR,V_MLIBRE),'-')AS " +
                "V_MLIBRE,ISNULL(TRY_CONVERT(VARCHAR,V_CAT),'-') AS V_CAT,ISNULL(TRY_CONVERT(VARCHAR,TRASLADOS),'-')AS TRASLADOS,ISNULL" +
                "(TRY_CONVERT(VARCHAR,V_JTZ),'-')AS V_JTZ,ISNULL(TRY_CONVERT(VARCHAR,V_SDMC),'-')AS V_SDMC,ISNULL(TRY_CONVERT(VARCHAR,V_TOTTUS),'-')AS" +
                " V_TOTTUS,ISNULL(TRY_CONVERT(VARCHAR,V_DINNERS),'-')AS V_DINNERS,ISNULL(A.MONEDA,'-')AS MONEDA,ISNULL(TRY_CONVERT" +
                "(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_DOLARES)),'-') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_SOLES)),'-') AS " +
                "COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,B.FECHA_REGISTRO,5),'01-12-20') AS FECHA_INGRESO, isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2)," +
                "(CASE WHEN (COSTO_U_S_IGV_DOLARES >0) THEN COSTO_U_S_IGV_DOLARES*1.18*" + TC + " WHEN (COSTO_U_S_IGV_DOLARES IS NULL) THEN COSTO_U_S_IGV_SOLES*1.18 END))),'-') AS COSTO_C_IGV_SOLES  " +
                ",isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),(CASE WHEN (COSTO_U_S_IGV_SOLES >0) THEN COSTO_U_S_IGV_SOLES*1.18 WHEN (COSTO_U_S_IGV_SOLES IS NULL) THEN 0 END))),'-') AS COSTO_C_IGV_SOLES_2 " +
                ",ISNULL(TRY_CONVERT(varchar,K.COSTO_UNI_PON_DOL),'-') AS COSTO_UNI_PON_DOL,ISNULL (SKU_COOLBOX,'-')AS SKU_COOLBOX,ISNULL (SKU_FALABELLA,'-')AS SKU_FALABELLA  ,ISNULL (SKU_CONECTA,'-')AS SKU_CONECTA " + //AGREGANDO CONECTA
                "FROM ST_STOCK_HST_CONSULTA A LEFT JOIN " +
                "ST_NVO_PROD B ON A.MINI_CODIGO = B.MINI_CODIGO " +
                "LEFT JOIN ST_KARDEX K ON K.PARTNUMBER = A.PARTNUMBER AND K.ID_KARDEX = (SELECT MAX(ID_KARDEX) FROM ST_KARDEX WHERE PARTNUMBER=A.PARTNUMBER)" +
                "   where A.TITULO LIKE '%" + filtro1 + "%'";
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.STOCK_INICIAL_20210623 = (string)reader["CORTE_20210623"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES = (string)reader["COSTO_C_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES_2 = (string)reader["COSTO_C_IGV_SOLES_2"];
                    planta.EAN = (string)reader["EAN"];
                    planta.EAN_UPC = (string)reader["EAN_UPC"];
                    planta.ENTRADAS = (string)reader["ENTRADAS"];
                    planta.MANDATORIO = (string)reader["MANDATORIO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MONEDA = (string)reader["MONEDA"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.SALIDAS = (string)reader["SALIDAS"];
                    planta.STOCK_FINAL = (string)reader["STOCK_FINAL"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.UPC = (string)reader["UPC"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.TITULO = (string)reader["TITULO"];
                    planta.FECHA_INGRESO = Convert.ToDateTime((string)reader["FECHA_INGRESO"]);
                    planta.Kardex_Prec_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.SKU_FALABELLA = (string)reader["SKU_FALABELLA"];
                    planta.SKU_CONECTA = (string)reader["CONECTA"]; //AGREGANDO CONECTA
                    listado.Add(planta);
                }
                reader.Close();
                return listado;

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
        public List<e_Planta> ListrarFiltrWords(string filtro1, string filtro2, string TC)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> listado = new List<e_Planta>();
                e_Planta planta = null;
                string consult = "SELECT ISNULL(SKU_SODIMAC,'-') AS SKU_SODIMAC,ISNULL(SKU_SAGA, '-') AS SKU_SAGA,ISNULL(SKU_TOTTUS,'-') AS" +
                " SKU_TOTTUS,ISNULL(SKU_LINIO,'-')AS SKU_LINIO,ISNULL (SKU_RIPLEY,'-')AS SKU_RIPLEY,ISNULL(SKU_JUNTOZ,'-')AS" +
                " SKU_JUNTOZ,ISNULL(SKU_REALPLAZA,'-') AS SKU_REALPLAZA,ISNULL(SKU_LUMINGO,'-') AS SKU_LUMINGO,ISNULL(SKU_MLIBRE,'-') AS" +
                " SKU_MLIBRE,ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE,ISNULL(SKU_KINGSTON,'-') AS SKU_KINGSTON,ISNULL(A.UPC,'-') AS " +
                "UPC,ISNULL(A.EAN,'-') AS EAN,ISNULL(A.MANDATORIO,'-') AS MANDATORIO,ISNULL(A.EAN_UPC,'-')AS EAN_UPC,ISNULL(A.MODELO,'-')AS" +
                " MODELO,ISNULL(A.MINI_CODIGO,'-') AS MINI_CODIGO,ISNULL(A.PARTNUMBER,'-') AS PARTNUMBER,ISNULL(A.MARCA,'-')AS MARCA,ISNULL" +
                "(A.TIPO,'-') AS TIPO,ISNULL(A.TITULO,'-') AS TITULO,ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210623),'-') AS CORTE_20210623,ISNULL" +
                "(TRY_CONVERT(VARCHAR,ENTRADAS),'-') AS ENTRADAS,ISNULL(TRY_CONVERT(VARCHAR,SALIDAS),'-') AS SALIDAS,ISNULL(TRY_CONVERT" +
                "(VARCHAR,A.STOCK_FINAL),'-')AS STOCK_FINAL,ISNULL(TRY_CONVERT(VARCHAR,V_SAGA),'-')AS V_SAGA,ISNULL(TRY_CONVERT(VARCHAR,V_LNO),'-')AS" +
                " V_LNO,ISNULL(TRY_CONVERT(VARCHAR,V_RPL),'-')AS V_RPL,ISNULL(TRY_CONVERT(VARCHAR,V_OFI),'-')AS V_OFI,ISNULL(TRY_CONVERT" +
                "(VARCHAR,V_LUMINGO),'-')AS V_LUMINGO,ISNULL(TRY_CONVERT(VARCHAR,V_REALP),'-')AS V_REALP,ISNULL(TRY_CONVERT(VARCHAR,V_MLIBRE),'-')AS " +
                "V_MLIBRE,ISNULL(TRY_CONVERT(VARCHAR,V_CAT),'-') AS V_CAT,ISNULL(TRY_CONVERT(VARCHAR,TRASLADOS),'-')AS TRASLADOS,ISNULL" +
                "(TRY_CONVERT(VARCHAR,V_JTZ),'-')AS V_JTZ,ISNULL(TRY_CONVERT(VARCHAR,V_SDMC),'-')AS V_SDMC,ISNULL(TRY_CONVERT(VARCHAR,V_TOTTUS),'-')AS" +
                " V_TOTTUS,ISNULL(TRY_CONVERT(VARCHAR,V_DINNERS),'-')AS V_DINNERS,ISNULL(A.MONEDA,'-')AS MONEDA,ISNULL(TRY_CONVERT" +
                "(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_DOLARES)),'-') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_SOLES)),'-') AS " +
                "COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,B.FECHA_REGISTRO,5),'01-12-20') AS FECHA_INGRESO, isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2)," +
                "(CASE WHEN (COSTO_U_S_IGV_DOLARES >0) THEN COSTO_U_S_IGV_DOLARES*1.18*" + TC + " WHEN (COSTO_U_S_IGV_DOLARES IS NULL) THEN COSTO_U_S_IGV_SOLES*1.18 END))),'-') AS COSTO_C_IGV_SOLES  " +
                ",isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),(CASE WHEN (COSTO_U_S_IGV_SOLES >0) THEN COSTO_U_S_IGV_SOLES*1.18 WHEN (COSTO_U_S_IGV_SOLES IS NULL) THEN 0 END))),'-') AS COSTO_C_IGV_SOLES_2 " +
                ",ISNULL(TRY_CONVERT(varchar,K.COSTO_UNI_PON_DOL),'-') AS COSTO_UNI_PON_DOL,ISNULL (SKU_COOLBOX,'-')AS SKU_COOLBOX,ISNULL (SKU_FALABELLA,'-')AS SKU_FALABELLA ,ISNULL (SKU_CONECTA,'-')AS SKU_CONECTA  " + //agregando conecta
                "FROM ST_STOCK_HST_CONSULTA A LEFT JOIN " +
                "ST_NVO_PROD B ON A.MINI_CODIGO = B.MINI_CODIGO " +
                "LEFT JOIN ST_KARDEX K ON K.PARTNUMBER = A.PARTNUMBER AND K.ID_KARDEX = (SELECT MAX(ID_KARDEX) FROM ST_KARDEX WHERE PARTNUMBER=A.PARTNUMBER)" +
                "   where A.TITULO LIKE '%" + filtro1 + "%' AND A.TITULO LIKE '%" + filtro2 + "%'";
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.STOCK_INICIAL_20210623 = (string)reader["CORTE_20210623"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES = (string)reader["COSTO_C_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES_2 = (string)reader["COSTO_C_IGV_SOLES_2"];
                    planta.EAN = (string)reader["EAN"];
                    planta.EAN_UPC = (string)reader["EAN_UPC"];
                    planta.ENTRADAS = (string)reader["ENTRADAS"];
                    planta.MANDATORIO = (string)reader["MANDATORIO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MONEDA = (string)reader["MONEDA"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.SALIDAS = (string)reader["SALIDAS"];
                    planta.STOCK_FINAL = (string)reader["STOCK_FINAL"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.UPC = (string)reader["UPC"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.TITULO = (string)reader["TITULO"];
                    planta.FECHA_INGRESO = Convert.ToDateTime((string)reader["FECHA_INGRESO"]);
                    planta.Kardex_Prec_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.SKU_FALABELLA = (string)reader["SKU_FALABELLA"];
                    planta.SKU_CONECTA = (string)reader["SKU_CONECTA"]; //AGREGANDO CONECTA
                    listado.Add(planta);
                }
                reader.Close();
                return listado;

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
        public List<e_Planta> ListrarFiltrWords(string filtro1, string filtro2, string filtro3, string TC)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> listado = new List<e_Planta>();
                e_Planta planta = null;
                string consult = "SELECT ISNULL(SKU_SODIMAC,'-') AS SKU_SODIMAC,ISNULL(SKU_SAGA, '-') AS SKU_SAGA,ISNULL(SKU_TOTTUS,'-') AS" +
                " SKU_TOTTUS,ISNULL(SKU_LINIO,'-')AS SKU_LINIO,ISNULL (SKU_RIPLEY,'-')AS SKU_RIPLEY,ISNULL(SKU_JUNTOZ,'-')AS" +
                " SKU_JUNTOZ,ISNULL(SKU_REALPLAZA,'-') AS SKU_REALPLAZA,ISNULL(SKU_LUMINGO,'-') AS SKU_LUMINGO,ISNULL(SKU_MLIBRE,'-') AS" +
                " SKU_MLIBRE,ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE,ISNULL(SKU_KINGSTON,'-') AS SKU_KINGSTON,ISNULL(A.UPC,'-') AS " +
                "UPC,ISNULL(A.EAN,'-') AS EAN,ISNULL(A.MANDATORIO,'-') AS MANDATORIO,ISNULL(A.EAN_UPC,'-')AS EAN_UPC,ISNULL(A.MODELO,'-')AS" +
                " MODELO,ISNULL(A.MINI_CODIGO,'-') AS MINI_CODIGO,ISNULL(A.PARTNUMBER,'-') AS PARTNUMBER,ISNULL(A.MARCA,'-')AS MARCA,ISNULL" +
                "(A.TIPO,'-') AS TIPO,ISNULL(A.TITULO,'-') AS TITULO,ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210623),'-') AS CORTE_20210623,ISNULL" +
                "(TRY_CONVERT(VARCHAR,ENTRADAS),'-') AS ENTRADAS,ISNULL(TRY_CONVERT(VARCHAR,SALIDAS),'-') AS SALIDAS,ISNULL(TRY_CONVERT" +
                "(VARCHAR,A.STOCK_FINAL),'-')AS STOCK_FINAL,ISNULL(TRY_CONVERT(VARCHAR,V_SAGA),'-')AS V_SAGA,ISNULL(TRY_CONVERT(VARCHAR,V_LNO),'-')AS" +
                " V_LNO,ISNULL(TRY_CONVERT(VARCHAR,V_RPL),'-')AS V_RPL,ISNULL(TRY_CONVERT(VARCHAR,V_OFI),'-')AS V_OFI,ISNULL(TRY_CONVERT" +
                "(VARCHAR,V_LUMINGO),'-')AS V_LUMINGO,ISNULL(TRY_CONVERT(VARCHAR,V_REALP),'-')AS V_REALP,ISNULL(TRY_CONVERT(VARCHAR,V_MLIBRE),'-')AS " +
                "V_MLIBRE,ISNULL(TRY_CONVERT(VARCHAR,V_CAT),'-') AS V_CAT,ISNULL(TRY_CONVERT(VARCHAR,TRASLADOS),'-')AS TRASLADOS,ISNULL" +
                "(TRY_CONVERT(VARCHAR,V_JTZ),'-')AS V_JTZ,ISNULL(TRY_CONVERT(VARCHAR,V_SDMC),'-')AS V_SDMC,ISNULL(TRY_CONVERT(VARCHAR,V_TOTTUS),'-')AS" +
                " V_TOTTUS,ISNULL(TRY_CONVERT(VARCHAR,V_DINNERS),'-')AS V_DINNERS,ISNULL(A.MONEDA,'-')AS MONEDA,ISNULL(TRY_CONVERT" +
                "(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_DOLARES)),'-') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_SOLES)),'-') AS " +
                "COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,B.FECHA_REGISTRO,5),'01-12-20') AS FECHA_INGRESO, isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2)," +
                "(CASE WHEN (COSTO_U_S_IGV_DOLARES >0) THEN COSTO_U_S_IGV_DOLARES*1.18*" + TC + " WHEN (COSTO_U_S_IGV_DOLARES IS NULL) THEN COSTO_U_S_IGV_SOLES*1.18 END))),'-') AS COSTO_C_IGV_SOLES  " +
                ",isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),(CASE WHEN (COSTO_U_S_IGV_SOLES >0) THEN COSTO_U_S_IGV_SOLES*1.18 WHEN (COSTO_U_S_IGV_SOLES IS NULL) THEN 0 END))),'-') AS COSTO_C_IGV_SOLES_2 " +
                ",ISNULL(TRY_CONVERT(varchar,K.COSTO_UNI_PON_DOL),'-') AS COSTO_UNI_PON_DOL,ISNULL (SKU_COOLBOX,'-')AS SKU_COOLBOX,ISNULL (SKU_FALABELLA,'-')AS SKU_FALABELLA  ,ISNULL (SKU_CONECTA,'-')AS SKU_CONECTA " + //AGREGANDO CONECTA
                "FROM ST_STOCK_HST_CONSULTA A LEFT JOIN " +
                "ST_NVO_PROD B ON A.MINI_CODIGO = B.MINI_CODIGO " +
                "LEFT JOIN ST_KARDEX K ON K.PARTNUMBER = A.PARTNUMBER AND K.ID_KARDEX = (SELECT MAX(ID_KARDEX) FROM ST_KARDEX WHERE PARTNUMBER=A.PARTNUMBER)" +
                "   where A.TITULO LIKE '%" + filtro1 + "%' AND A.TITULO LIKE '%" + filtro2 + "%' AND A.TITULO LIKE '%" + filtro3 + "%'";
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.STOCK_INICIAL_20210623 = (string)reader["CORTE_20210623"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES = (string)reader["COSTO_C_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES_2 = (string)reader["COSTO_C_IGV_SOLES_2"];
                    planta.EAN = (string)reader["EAN"];
                    planta.EAN_UPC = (string)reader["EAN_UPC"];
                    planta.ENTRADAS = (string)reader["ENTRADAS"];
                    planta.MANDATORIO = (string)reader["MANDATORIO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MONEDA = (string)reader["MONEDA"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.SALIDAS = (string)reader["SALIDAS"];
                    planta.STOCK_FINAL = (string)reader["STOCK_FINAL"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.UPC = (string)reader["UPC"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.TITULO = (string)reader["TITULO"];
                    planta.FECHA_INGRESO = Convert.ToDateTime((string)reader["FECHA_INGRESO"]);
                    planta.Kardex_Prec_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.SKU_FALABELLA = (string)reader["SKU_FALABELLA"];
                    planta.SKU_CONECTA = (string)reader["SKU_CONECTA"]; //AGREGANDO CONECTA
                    listado.Add(planta);
                }
                reader.Close();
                return listado;

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
        public List<e_Planta> ListrarFiltrWords(string filtro1, string filtro2, string filtro3, string filtro4, string TC)
        {
            try
            {
                SqlConnection con = db_st.Conecta_DB();
                List<e_Planta> listado = new List<e_Planta>();
                e_Planta planta = null;
                string consult = "SELECT ISNULL(SKU_SODIMAC,'-') AS SKU_SODIMAC,ISNULL(SKU_SAGA, '-') AS SKU_SAGA,ISNULL(SKU_TOTTUS,'-') AS" +
                " SKU_TOTTUS,ISNULL(SKU_LINIO,'-')AS SKU_LINIO,ISNULL (SKU_RIPLEY,'-')AS SKU_RIPLEY,ISNULL(SKU_JUNTOZ,'-')AS" +
                " SKU_JUNTOZ,ISNULL(SKU_REALPLAZA,'-') AS SKU_REALPLAZA,ISNULL(SKU_LUMINGO,'-') AS SKU_LUMINGO,ISNULL(SKU_MLIBRE,'-') AS" +
                " SKU_MLIBRE,ISNULL(SKU_CATPHONE,'-') AS SKU_CATPHONE,ISNULL(SKU_KINGSTON,'-') AS SKU_KINGSTON,ISNULL(A.UPC,'-') AS " +
                "UPC,ISNULL(A.EAN,'-') AS EAN,ISNULL(A.MANDATORIO,'-') AS MANDATORIO,ISNULL(A.EAN_UPC,'-')AS EAN_UPC,ISNULL(A.MODELO,'-')AS" +
                " MODELO,ISNULL(A.MINI_CODIGO,'-') AS MINI_CODIGO,ISNULL(A.PARTNUMBER,'-') AS PARTNUMBER,ISNULL(A.MARCA,'-')AS MARCA,ISNULL" +
                "(A.TIPO,'-') AS TIPO,ISNULL(A.TITULO,'-') AS TITULO,ISNULL(TRY_CONVERT(VARCHAR,CORTE_20210623),'-') AS CORTE_20210623,ISNULL" +
                "(TRY_CONVERT(VARCHAR,ENTRADAS),'-') AS ENTRADAS,ISNULL(TRY_CONVERT(VARCHAR,SALIDAS),'-') AS SALIDAS,ISNULL(TRY_CONVERT" +
                "(VARCHAR,A.STOCK_FINAL),'-')AS STOCK_FINAL,ISNULL(TRY_CONVERT(VARCHAR,V_SAGA),'-')AS V_SAGA,ISNULL(TRY_CONVERT(VARCHAR,V_LNO),'-')AS" +
                " V_LNO,ISNULL(TRY_CONVERT(VARCHAR,V_RPL),'-')AS V_RPL,ISNULL(TRY_CONVERT(VARCHAR,V_OFI),'-')AS V_OFI,ISNULL(TRY_CONVERT" +
                "(VARCHAR,V_LUMINGO),'-')AS V_LUMINGO,ISNULL(TRY_CONVERT(VARCHAR,V_REALP),'-')AS V_REALP,ISNULL(TRY_CONVERT(VARCHAR,V_MLIBRE),'-')AS " +
                "V_MLIBRE,ISNULL(TRY_CONVERT(VARCHAR,V_CAT),'-') AS V_CAT,ISNULL(TRY_CONVERT(VARCHAR,TRASLADOS),'-')AS TRASLADOS,ISNULL" +
                "(TRY_CONVERT(VARCHAR,V_JTZ),'-')AS V_JTZ,ISNULL(TRY_CONVERT(VARCHAR,V_SDMC),'-')AS V_SDMC,ISNULL(TRY_CONVERT(VARCHAR,V_TOTTUS),'-')AS" +
                " V_TOTTUS,ISNULL(TRY_CONVERT(VARCHAR,V_DINNERS),'-')AS V_DINNERS,ISNULL(A.MONEDA,'-')AS MONEDA,ISNULL(TRY_CONVERT" +
                "(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_DOLARES)),'-') AS COSTO_U_S_IGV_DOLARES, ISNULL(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),COSTO_U_S_IGV_SOLES)),'-') AS " +
                "COSTO_U_S_IGV_SOLES, ISNULL(TRY_CONVERT(VARCHAR,B.FECHA_REGISTRO,5),'01-12-20') AS FECHA_INGRESO, isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2)," +
                "(CASE WHEN (COSTO_U_S_IGV_DOLARES >0) THEN COSTO_U_S_IGV_DOLARES*1.18*" + TC + " WHEN (COSTO_U_S_IGV_DOLARES IS NULL) THEN COSTO_U_S_IGV_SOLES*1.18 END))),'-') AS COSTO_C_IGV_SOLES  " +
                ",isnull(TRY_CONVERT(VARCHAR,TRY_CONVERT(DECIMAL(20,2),(CASE WHEN (COSTO_U_S_IGV_SOLES >0) THEN COSTO_U_S_IGV_SOLES*1.18 WHEN (COSTO_U_S_IGV_SOLES IS NULL) THEN 0 END))),'-') AS COSTO_C_IGV_SOLES_2 " +
                ",ISNULL(TRY_CONVERT(varchar,K.COSTO_UNI_PON_DOL),'-') AS COSTO_UNI_PON_DOL,ISNULL (SKU_COOLBOX,'-')AS SKU_COOLBOX,ISNULL (SKU_FALABELLA,'-')AS SKU_FALABELLA  ,ISNULL (SKU_CONECTA,'-')AS SKU_CONECTA " + //AGREGANDO CONECTA
                "FROM ST_STOCK_HST_CONSULTA A LEFT JOIN " +
                "ST_NVO_PROD B ON A.MINI_CODIGO = B.MINI_CODIGO " +
                "LEFT JOIN ST_KARDEX K ON K.PARTNUMBER = A.PARTNUMBER AND K.ID_KARDEX = (SELECT MAX(ID_KARDEX) FROM ST_KARDEX WHERE PARTNUMBER=A.PARTNUMBER)" +
                "   where A.TITULO LIKE '%" + filtro1 + "%' AND A.TITULO LIKE '%" + filtro2 + "%' AND A.TITULO LIKE '%" + filtro3 + "%' AND A.TITULO LIKE '%" + filtro4 + "%'";
                SqlCommand cmd_0 = new SqlCommand(consult, con);
                SqlDataReader reader = cmd_0.ExecuteReader();
                while (reader.Read())
                {
                    planta = new e_Planta();
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.STOCK_INICIAL_20210623 = (string)reader["CORTE_20210623"];
                    planta.COSTO_U_S_IGV_DOLARES = (string)reader["COSTO_U_S_IGV_DOLARES"];
                    planta.COSTO_U_S_IGV_SOLES = (string)reader["COSTO_U_S_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES = (string)reader["COSTO_C_IGV_SOLES"];
                    planta.COSTO_U_C_IGV_SOLES_2 = (string)reader["COSTO_C_IGV_SOLES_2"];
                    planta.EAN = (string)reader["EAN"];
                    planta.EAN_UPC = (string)reader["EAN_UPC"];
                    planta.ENTRADAS = (string)reader["ENTRADAS"];
                    planta.MANDATORIO = (string)reader["MANDATORIO"];
                    planta.MARCA = (string)reader["MARCA"];
                    planta.MINI_CODIGO = (string)reader["MINI_CODIGO"];
                    planta.MODELO = (string)reader["MODELO"];
                    planta.MONEDA = (string)reader["MONEDA"];
                    planta.PARTNUMBER = (string)reader["PARTNUMBER"];
                    planta.SALIDAS = (string)reader["SALIDAS"];
                    planta.STOCK_FINAL = (string)reader["STOCK_FINAL"];
                    planta.SKU_CATPHONE = (string)reader["SKU_CATPHONE"];
                    planta.SKU_JUNTOZ = (string)reader["SKU_JUNTOZ"];
                    planta.SKU_KINGSTON = (string)reader["SKU_KINGSTON"];
                    planta.SKU_LINIO = (string)reader["SKU_LINIO"];
                    planta.SKU_LUMINGO = (string)reader["SKU_LUMINGO"];
                    planta.SKU_MLIBRE = (string)reader["SKU_MLIBRE"];
                    planta.SKU_REALPLAZA = (string)reader["SKU_REALPLAZA"];
                    planta.SKU_RIPLEY = (string)reader["SKU_RIPLEY"];
                    planta.SKU_SAGA = (string)reader["SKU_SAGA"];
                    planta.SKU_SODIMAC = (string)reader["SKU_SODIMAC"];
                    planta.SKU_TOTTUS = (string)reader["SKU_TOTTUS"];
                    planta.UPC = (string)reader["UPC"];
                    planta.TIPO = (string)reader["TIPO"];
                    planta.TITULO = (string)reader["TITULO"];
                    planta.FECHA_INGRESO = Convert.ToDateTime((string)reader["FECHA_INGRESO"]);
                    planta.Kardex_Prec_USD = (string)reader["COSTO_UNI_PON_DOL"];
                    planta.SKU_COOLBOX = (string)reader["SKU_COOLBOX"];
                    planta.SKU_FALABELLA = (string)reader["SKU_FALABELLA"];
                    planta.SKU_CONECTA = (string)reader["SKU_CONECTA"]; //AGREGANDO CONECTA
                    listado.Add(planta);
                }
                reader.Close();
                return listado;

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
    }
}
