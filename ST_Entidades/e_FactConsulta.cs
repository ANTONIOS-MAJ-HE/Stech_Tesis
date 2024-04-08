using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_FactConsulta
    {
        public string NRO { get; set; }
        public string Usuario_Vendedor { get; set; }
        public string Tipo_Doc { get; set; }
        public string Numero { get; set; }
        public string Fecha_Emision  { get; set; }
        public string Fecha_Vencimiento { get; set; }
        public string Doc { get; set; }
        public string Guial { get; set; }
        public string Cotización { get; set; }
        public string Caso { get; set; }
        public string DIST { get; set; }
        public string DPTO { get; set; }
        public string PROV { get; set; }
        public string Cliente { get; set; }
        public string RUC { get; set; }
        public string Estado  { get; set; }
        public string Moneda { get; set; }
        public string Plataforma { get; set; }
        public string Orden_de_compra { get; set; }
        public string Forma_de_pago { get; set; }
        public string Total_Exonerado { get; set; }
        public string TotalInafecto  { get; set; }
        public string Total_Gratuito  { get; set; }
        public string Total_Gravado { get; set; }
        public string Descuento_total { get; set; }
        public string Total_IGV { get; set; }
        public string Total { get; set; }
        //TABLA ST_CONS_ORDENES
        public string CANAL { get; set; }
        public string NRO_OC { get; set; }
        public string FECHA_CREACION { get; set; }
        public string SKU { get; set; }
        public string EAN_UPC { get; set; }
        public string MODELO { get; set; }
        public string MINI_CODIGO { get; set; }
        public string PARTNUMBER { get; set; }
        public string PRODUCTO_ORIGINAL { get; set; }
        public string CANT_ORIGINAL { get; set; }
        public string CANT_REAL { get; set; }
        public string PRODUCTO_CAMBIADO { get; set; }
        public string COSTO_S_IGV { get; set; }
        public string COSTO_C_IGV { get; set; }
        public string NUM_DOC { get; set; }
        public string NOM_CLI { get; set; }
        public string DIRECCION_CLI { get; set; }
        public string FECHA_DESPACHO { get; set; }
        public string ESTADO_ORDEN { get; set; }
        public string ESTADO_DESP { get; set; }
        public string SERIE_CMP { get; set; }
        public string NRO_CMP { get; set; }
        public string OBSERVACIONEs { get; set; }
        public string FECHA_PROCESO { get; set; }
        public string NRO_PEDIDO { get; set; }
    }
}
