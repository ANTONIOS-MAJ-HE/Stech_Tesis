using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatosDelClienteOReceptor
    {
        public string codigo_tipo_documento_identidad { get; set; }
        public string numero_documento { get; set; }
        public string apellidos_y_nombres_o_razon_social { get; set; }
        public string nombre_comercial { get; set; }
        public string codigo_pais { get; set; }
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string correo_electronico { get; set; }
        public string telefono { get; set; }
    }

    public class DatosDelEmisor
    {
        public string codigo_pais { get; set; }
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string correo_electronico { get; set; }
        public string telefono { get; set; }
        public string codigo_del_domicilio_fiscal { get; set; }
    }

    public class DireccionLlegada
    {
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string codigo_del_domicilio_fiscal { get; set; }
    }

    public class DireccionPartida
    {
        public string ubigeo { get; set; }
        public string direccion { get; set; }
        public string codigo_del_domicilio_fiscal { get; set; }
    }

    public class DocumentoAfectado
    {
        public string serie_documento { get; set; }
        public string numero_documento { get; set; }
        public string codigo_tipo_documento { get; set; }
    }

    public class Item
    {
        public string codigo_interno { get; set; }
        public int cantidad { get; set; }
    }
    public class Transportista
    {
        public string codigo_tipo_documento_identidad { get; set; }
        public string numero_documento { get; set; }
        public string apellidos_y_nombres_o_razon_social { get; set; }
        public string numero_mtc { get; set; }
    }


    public class e_GuiaEnviar
    {
        public string serie_documento { get; set; }
        public string numero_documento { get; set; }
        public string fecha_de_emision { get; set; }
        public string hora_de_emision { get; set; }
        public string codigo_tipo_documento { get; set; }
        public DatosDelEmisor datos_del_emisor { get; set; }
        public DatosDelClienteOReceptor datos_del_cliente_o_receptor { get; set; }
        public string observaciones { get; set; }
        public string orden_pedido_externo { get; set; }
        public string codigo_modo_transporte { get; set; }
        public string codigo_motivo_traslado { get; set; }
        public string descripcion_motivo_traslado { get; set; }
        public string fecha_de_traslado { get; set; }
        public string codigo_de_puerto { get; set; }
        public bool indicador_de_transbordo { get; set; }
        public string unidad_peso_total { get; set; }
        public double peso_total { get; set; }
        public int numero_de_bultos { get; set; }
        public string numero_de_contenedor { get; set; }
        public DireccionPartida direccion_partida { get; set; }
        public DireccionLlegada direccion_llegada { get; set; }
        public Transportista transportista { get; set; }
        public List<Item> items { get; set; }
        public DocumentoAfectado documento_afectado { get; set; }
    }
}
