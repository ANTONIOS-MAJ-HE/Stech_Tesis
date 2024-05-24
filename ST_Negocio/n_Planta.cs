using System;
using System.Collections.Generic;
using System.Text;
using ST_Datos;
using ST_Entidades;

namespace ST_Negocio
{
    public class n_Planta
    {
        d_Planta plantaDAOB;
        d_Act_planta actDAOB;
        public n_Planta()
        {
            plantaDAOB = new d_Planta();
            actDAOB = new d_Act_planta();
        }

        public string Actualizar_planta(string UPC, string EAN,string MODELO, string MINI_CODIGO, string PARTNUMBER, string MARCA, string TIPO, string TITULO, string DESCONTINUADO, string SKU_SAGA, string SKU_LINIO, string SKU_RIPLEY, string SKU_REALPLAZA, string SKU_JUNTOZ, string SKU_LUMINGO, string SKU_SODIMAC, string SKU_TOTTUS, string SKU_KINGSTON, string COSTO_U_S_IGV_DOLARES, string COSTO_U_S_IGV_SOLES, string ID, string SKU_CATPHONE, string SKU_MLIBRE,string SKU_COOLBOX,string SKU_FALABELLA, string SKU_CONECTA)  //AGREGANDO CONECTA 
        {
            e_Planta planta = new e_Planta()
            {
                UPC = UPC,
                EAN = EAN,
                MODELO = MODELO,
                MINI_CODIGO = MINI_CODIGO,
                PARTNUMBER = PARTNUMBER,
                MARCA = MARCA,
                TIPO = TIPO,
                TITULO = TITULO,
                DESCONTINUADO = DESCONTINUADO,
                SKU_SAGA = SKU_SAGA,
                SKU_LINIO = SKU_LINIO,
                SKU_RIPLEY = SKU_RIPLEY,
                SKU_REALPLAZA = SKU_REALPLAZA,
                SKU_JUNTOZ = SKU_JUNTOZ,
                SKU_LUMINGO = SKU_LUMINGO,
                SKU_SODIMAC = SKU_SODIMAC,
                SKU_TOTTUS = SKU_TOTTUS,
                SKU_KINGSTON = SKU_KINGSTON,
                COSTO_U_S_IGV_DOLARES = COSTO_U_S_IGV_DOLARES,
                COSTO_U_S_IGV_SOLES = COSTO_U_S_IGV_SOLES,
                MANDATORIO = ID,
                SKU_CATPHONE = SKU_CATPHONE,
                SKU_MLIBRE = SKU_MLIBRE,
                SKU_COOLBOX=SKU_COOLBOX,
                SKU_FALABELLA=SKU_FALABELLA,
                //AGREGANDO CONECTA
                SKU_CONECTA = SKU_CONECTA
            };
            return actDAOB.Actualizar_planta(planta);
 
        }
        public List<e_Planta> Lista_planta_codigo(string COD)
        {
            e_Planta planta = new e_Planta()
            {
                MODELO = COD
            };
            return actDAOB.Lista_planta_cod(planta);
        }
        public List<e_Planta> Lista_planta_barras(string BARRA)
        {
            e_Planta planta = new e_Planta()
            {
                EAN = BARRA
            };
            return actDAOB.Lista_planta_barra(planta);
        }
        public List<e_Planta> Lista_planta_titulo(string TITULO)
        {
            e_Planta planta = new e_Planta()
            {
                TITULO = TITULO
            };
            return actDAOB.Lista_planta_titulo(planta);
        }

        public List<e_Planta>Lista_planta()
        {
            return actDAOB.Lista_planta();
        }
        public string Cargar_stock()
        {
            return plantaDAOB.Cargar_stock();
        }
        public List<e_Planta> Listar_Productos (double tipo_Ca)
        {
            e_Planta planta = new e_Planta()
            {
                tipo_camb = tipo_Ca
            };
            return plantaDAOB.Lista_stock(planta);
        }

        public List<e_Planta> Listar_Filtro(string minicod,string titulo, string marca, string ean_upc, string tipo, string modelo , string partnumber
            ,string sku,double tipo_Ca)
        {
     
               e_Planta planta = new e_Planta()
            {
                MINI_CODIGO = minicod,
                TITULO = titulo,
                MARCA = marca,
                EAN_UPC = ean_upc,
                TIPO = tipo,
                MODELO = modelo,
                PARTNUMBER = partnumber,
                SKU_CATPHONE = sku,
                tipo_camb = tipo_Ca
                
            };

            return plantaDAOB.Lista_filter(planta);
        }

        public List<e_Planta> Listar_FiltroSKU(string SKU, int canal, string TC)
        {
            switch (canal)
            {
                case 0:
                    return plantaDAOB.BuscarSKU(SKU, "SODIMAC", TC);
                    break;
                case 1:
                    return plantaDAOB.BuscarSKU(SKU, "SAGA", TC);
                    break;
                case 2:
                    return plantaDAOB.BuscarSKU(SKU, "TOTTUS", TC);
                    break;
                case 3:
                    return plantaDAOB.BuscarSKU(SKU, "LINIO", TC);
                    break;
                case 4:
                    return plantaDAOB.BuscarSKU(SKU, "RIPLEY", TC);
                    break;
                case 5:
                    return plantaDAOB.BuscarSKU(SKU, "JUNTOZ", TC);
                    break;
                case 6:
                    return plantaDAOB.BuscarSKU(SKU, "REALPLAZA", TC);
                    break;
                case 7:
                    return plantaDAOB.BuscarSKU(SKU, "LUMINGO", TC);
                    break;
                case 8:
                    return plantaDAOB.BuscarSKU(SKU, "MLIBRE", TC);
                    break;
                case 9:
                    return plantaDAOB.BuscarSKU(SKU, "CATPHONE", TC);
                    break;
                case 10:
                    return plantaDAOB.BuscarSKU(SKU, "KINGSTON", TC);
                    break;
                default:
                    return plantaDAOB.BuscarSKU(SKU, "SAGA", TC);
                    break;
            }

        }

        public List<e_Planta> FiltraPalabras(string titulo,string tipoCambio)
        {
            string[] filtros = titulo.Split(' ');
            switch (filtros.Length)
            {
                case 0:
                    return plantaDAOB.ListrarFiltrWords(titulo,tipoCambio);
                    break;
                case 1:
                    return plantaDAOB.ListrarFiltrWords(titulo, tipoCambio);
                    break;
                case 2:
                    return plantaDAOB.ListrarFiltrWords(filtros[0], filtros[1], tipoCambio);
                    break;
                case 3:
                    return plantaDAOB.ListrarFiltrWords(filtros[0], filtros[1], filtros[2], tipoCambio);
                    break;
                case 4:
                    return plantaDAOB.ListrarFiltrWords(filtros[0], filtros[1], filtros[2], filtros[3], tipoCambio);
                    break;
                default:
                    return plantaDAOB.ListrarFiltrWords(titulo, tipoCambio);
                    break;
            }
        }
    }
}
