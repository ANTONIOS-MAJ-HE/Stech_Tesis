using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Entidades
{
    public class Chofer
    {
        public string codigo_tipo_documento_identidad { get; set; }
        public string numero_documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string numero_licencia { get; set; }
    }
    public class Vehiculo
    {
        public string numero_de_placa { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
    }
    public class e_GuiaEnviarPriv
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
        public Chofer chofer { get; set; }
        public string numero_de_placa { get; set; }
        public List<Item> items { get; set; }
        public DocumentoAfectado documento_afectado { get; set; }
    }

    public class e_GuiaEnviarConecta
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
        public bool traslado_categoria_m1l { get; set; }
        public string numero_de_placa { get; set; }
        public DireccionPartida direccion_partida { get; set; }
        public DireccionLlegada direccion_llegada { get; set; }
        //agregando para el transporte privado, chofer
        public Chofer chofer { get; set; }
        //agregando vehiculo
        public Vehiculo vehiculo { get; set; }
        //public Transportista transportista { get; set; }
        public List<Item> items { get; set; }
        public DocumentoAfectado documento_afectado { get; set; }
    }

}
