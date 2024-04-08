using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class e_Salida
    {
        public string TIPO { get; set; }
        public string NRO_ORDEN { get; set; }
        public string FECHA_SALIDA { get; set; }
        public string RESPONSABLE { get; set; }
        public string TIPO_COMPROBANTE { get; set; }
        public string SERIE_COMPROBANTE { get; set; }
        public string NRO_COMPROBANTE { get; set; }
        public string CANAL { get; set; }
        public string MINICODIGO { get; set; }
        public string TIPO_PAGO { get; set; }
        public string BANCO { get; set; }
        public string NRO_OPERACION { get; set; }
        public string CANTIDAD { get; set; }
        public string MONEDA { get; set; }
        public string PRECIO_UNIT_S_IGV { get; set; }
        public string ORIGEN { get; set; }
        public string DIR_DESTINO { get; set; }
        public string OBSERVACIONES { get; set; }
        public string NOM_CLI { get; set; }
        public string DNI_CLI { get; set; }
        public string TEL_CLI { get; set; }
        public string NOM_DELIV { get; set; }
        public string KM { get; set; }
        public string TARIFA_ST { get; set; }
        public string TARIFA_DELIV { get; set; }
        public string TARIFA_OLVA { get; set; }
        public string PAGO_ONLINE { get; set; }
        public string TRANSFERENCIA { get; set; }
        public string EFECTIVO { get; set; }
        public string FECHA_PROCESO { get; set; }
        public string NRO_PEDIDO { get; set; }
        public int ID_SALIDA { get; set; }
    }
}
