using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Alerta_Stock
    {
        public string TITULO { get; set; }
        public string PARTNUMBER { get; set; }
        public string MARCA { get; set; }   //AGREGADO
        public string MINICODIGO { get; set; }
        public string STOCK_FINAL { get; set; }
        public string NOM_PROVEEDOR { get; set; }
        public string COSTO_U_S_IGV_DOLARES { get; set; }
        public string COSTO_U_S_IGV_SOLES { get; set; }
        public DateTime FECHA_CONSULTA { get; set; }
        public DateTime FECHA_CREACION { get; set; }     //AGREGADO
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
        public string SKU_KIGNSTON { get; set; }
}
}
