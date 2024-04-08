using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Planta
    {

        public string TITULO { get; set; }
        public string PARTNUMBER { get; set; }
        public string MODELO { get; set; }
        public string MARCA { get; set; }
        public string MINI_CODIGO { get; set; }
        public string TIPO { get; set; }
        public string COSTO_U_S_IGV_DOLARES { get; set; }
        public string COSTO_U_S_IGV_SOLES { get; set; }
        public string COSTO_U_C_IGV_SOLES { get; set; }
        public string COSTO_U_C_IGV_SOLES_2 { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public string STOCK_INICIAL_20210623 { get; set; }
        public string ENTRADAS { get; set; }
        public string SALIDAS { get; set; }
        public string STOCK_FINAL { get; set; }

        public string SKU_SODIMAC { get; set; }
        public string SKU_SAGA { get; set; }
        public string SKU_TOTTUS { get; set; }
        public string SKU_LINIO { get; set; }
        public string SKU_RIPLEY { get; set; }
        public string SKU_JUNTOZ { get; set; }
        public string SKU_REALPLAZA { get; set; }
        public string SKU_LUMINGO { get; set; }
        public string SKU_MLIBRE { get; set; }
        public string SKU_CATPHONE { get; set; }
        public string SKU_KINGSTON { get; set; }
        public string SKU_COOLBOX { get; set; }
        public string SKU_FALABELLA { get; set; }

        public string SKU_CONECTA { get; set; }   //SE AGREGA public string SKU_CONECTA { get; set; }

        public string UPC { get; set; }
        public string EAN { get; set; }
        public string MANDATORIO { get; set; }
        public string EAN_UPC { get; set; }


        //public string V_SAGA { get; set; }
        //public string V_LNO { get; set; }
        //public string V_RPL { get; set; }
        //public string V_OFI { get; set; }
        //public string V_LUMINGO { get; set; }
        //public string V_REALP { get; set; }
        //public string V_MLIBRE { get; set; }
        //public string V_CAT { get; set; }
        //public string TRASLADOS { get; set; }
        //public string V_JTZ { get; set; }
        //public string V_SDMC { get; set; }
        //public string V_TOTTUS { get; set; }
        //public string V_DINNERS { get; set; }
        public string MONEDA{ get; set; }
        public double tipo_camb { get; set; }

        public string DESCONTINUADO { get; set; }

        public string Kardex_Prec_USD { get; set; }
    }
}
