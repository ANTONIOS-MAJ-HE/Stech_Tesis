using Newtonsoft.Json;
using ST_Datos;
using ST_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ST_Negocio
{
    public class n_GuiaOficina
    {
        d_GuiasOficina guias_DAOB;
        d_Api api = new d_Api();
        public n_GuiaOficina()
        {
            guias_DAOB = new d_GuiasOficina();
        }
        public List<e_Guias> MostrarGuias(string nro) => guias_DAOB.Lista_Guias(nro);
        public string añadirGuiaOficina(string NRO_OC,string tipoDocCliente,string DocCliente,string NomCliente, string direccion, string correo,string 
            telefono, string observaciones,string descripcionMotivo, string fechaTraslado, string peso, string ubigeoLlegada,string direccionLlegada,
            string codigoDomicilio,string TipoDocTransport,string docTransportista,string nomTransportista,string numeroMTC,List<e_ProductosxPedido> productos)
        {
            try
            {
                DateTime fecha_Trans = Convert.ToDateTime(fechaTraslado);
                string mensaje = "";
                e_Guias guia = new e_Guias();
                foreach (e_ProductosxPedido products in productos)
                {
                    guia.NRO_OC = NRO_OC;
                    guia.TIPO_DOCUMENTO_CLIENTE = tipoDocCliente;
                    guia.NUMERO_DOCUMENTO = DocCliente;
                    guia.NOMBRE_CLIENTE = NomCliente;
                    guia.DIRECCION_CLIENTE = direccion;
                    guia.CORREO = correo;
                    guia.TELEFONO = telefono;
                    guia.OBSERVACION = observaciones;
                    guia.DESCRIPCION_MOTIVO = descripcionMotivo;
                    guia.FECHA_TRASLADO = fecha_Trans.ToString("yyyy-MM-dd") ;
                    guia.PESO = peso;
                    guia.UBIGEO_LLEGADA = ubigeoLlegada;
                    guia.DIRECCION_LLEGADA = direccionLlegada;
                    guia.CODIGO_DOMICILIO = codigoDomicilio;
                    guia.TIPO_DOCUMENTO_TRANSPORTISTA = TipoDocTransport;
                    guia.DOCUMENTO_TRANSPORTISTA = docTransportista;
                    guia.NOMBRE_TRANSPORTISTA = nomTransportista;
                    guia.NUMERO_MTC = numeroMTC;
                    guia.CODIGO_ITEM_SKU = products.MINI_CODIGO;
                    guia.CANTIDAD = Convert.ToString(products.CANTIDAD);
                   
                }
                return guias_DAOB.IngresarGuia(guia);
            }
            catch(Exception err)
            {
                return "No se puedo crear la guia. ERROR: "+err.Message;
            }
        }
        //Guias privadas
        public List<e_GuiasPriv> MostrarGuiasPriv(string nro) => guias_DAOB.Lista_Guias_Priv(nro);
        public string añadirGuiaOficinaPriv(string NRO_OC, string tipoDocCliente, string DocCliente, string NomCliente, string direccion, string correo, string
        telefono, string observaciones, string descripcionMotivo, string fechaTraslado, string peso, string ubigeoLlegada, string direccionLlegada,
        string codigoDomicilio, string TipoDocTransport, string docTransportista, string nomTransportista, string licencia, string placa,
        List<e_ProductosxPedido> productos)
        {
            try
            {
                DateTime fecha_Trans = Convert.ToDateTime(fechaTraslado);
                string mensaje = "";
                e_GuiasPriv guia = new e_GuiasPriv();
                foreach (e_ProductosxPedido products in productos)
                {
                    guia.NRO_OC = NRO_OC;
                    guia.TIPO_DOCUMENTO_CLIENTE = tipoDocCliente;
                    guia.NUMERO_DOCUMENTO = DocCliente;
                    guia.NOMBRE_CLIENTE = NomCliente;
                    guia.DIRECCION_CLIENTE = direccion;
                    guia.CORREO = correo;
                    guia.TELEFONO = telefono;
                    guia.OBSERVACION = observaciones;
                    guia.DESCRIPCION_MOTIVO = descripcionMotivo;
                    guia.FECHA_TRASLADO = fecha_Trans.ToString("yyyy-MM-dd");
                    guia.PESO = peso;
                    guia.UBIGEO_LLEGADA = ubigeoLlegada;
                    guia.DIRECCION_LLEGADA = direccionLlegada;
                    guia.CODIGO_DOMICILIO = codigoDomicilio;
                    guia.TIPO_DOCUMENTO_CHOFER = TipoDocTransport;
                    guia.DOCUMENTO_CHOFER = docTransportista;
                    guia.NOMBRE_CHOFER = nomTransportista;
                    guia.LICENCIA = licencia;
                    guia.PLACA = placa;
                    guia.CODIGO_ITEM_SKU = products.MINI_CODIGO;
                    guia.CANTIDAD = Convert.ToString(products.CANTIDAD);
                }
                return guias_DAOB.IngresarGuia_Priv(guia);
            }
            catch (Exception err)
            {
                return "No se puedo crear la guia. ERROR: " + err.Message;
            }
        }
        public dynamic Enviar_Guia(string Nro_OC)
        {
            try
            {
                List<e_Guias> guias= guias_DAOB.Lista_Guias(Nro_OC);
                DatosDelEmisor emisor = new DatosDelEmisor();
                DatosDelClienteOReceptor cliente = new DatosDelClienteOReceptor();
                DireccionLlegada llegada= new DireccionLlegada();
                DireccionPartida partida = new DireccionPartida();
                Transportista transportista = new Transportista();
                DocumentoAfectado documentoAfectado= new DocumentoAfectado();
                //Crea el Json
                e_GuiaEnviar Guia = new e_GuiaEnviar();
                Guia.serie_documento = "T001";
                Guia.numero_documento = "#";
                Guia.fecha_de_emision= DateTime.Now.ToString("yyyy-MM-dd");
                Guia.hora_de_emision = DateTime.Now.ToString("HH:mm:ss");
                Guia.codigo_tipo_documento = "09";
                //Crea al emisor
                emisor.codigo_pais = "PE";
                emisor.ubigeo = "150135";
                emisor.direccion = "Av. Honorio Delgado 224 Urb. Ingeniería San Martín de Porres";
                emisor.correo_electronico = "informes@s-tech.com.pe";
                emisor.telefono = "6161000";
                emisor.codigo_del_domicilio_fiscal = "0000";
                Guia.datos_del_emisor = emisor;
                //Crea el cliente
                cliente.codigo_tipo_documento_identidad = guias[0].TIPO_DOCUMENTO_CLIENTE;
                cliente.numero_documento = guias[0].NUMERO_DOCUMENTO;
                cliente.apellidos_y_nombres_o_razon_social = guias[0].NOMBRE_CLIENTE;
                cliente.codigo_pais = "PE";
                cliente.ubigeo ="";
                cliente.direccion = guias[0].DIRECCION_CLIENTE;
                cliente.correo_electronico = guias[0].CORREO;
                cliente.nombre_comercial = "";
                cliente.telefono = guias[0].TELEFONO;
                Guia.datos_del_cliente_o_receptor = cliente;
                //Datos generales
                Guia.observaciones = guias[0].OBSERVACION;
                Guia.orden_pedido_externo = guias_DAOB.ObtenerOC(Nro_OC);
                Guia.codigo_modo_transporte = "01";
                Guia.codigo_motivo_traslado="01";
                Guia.descripcion_motivo_traslado = guias[0].DESCRIPCION_MOTIVO;
                Guia.fecha_de_traslado = guias[0].FECHA_TRASLADO;
                Guia.codigo_de_puerto = "";
                Guia.indicador_de_transbordo = false;
                Guia.unidad_peso_total = "KGM";
                Guia.peso_total = Convert.ToDouble(guias[0].PESO);
                Guia.numero_de_bultos = 1;
                Guia.numero_de_contenedor = "";
                //Direccion de partida
                partida.ubigeo = "150135";
                partida.direccion = "Av. Honorio Delgado 224 Urb. Ingeniería San Martín de Porres";
                partida.codigo_del_domicilio_fiscal = "0000";
                Guia.direccion_partida= partida;
                //Direccion de llegada
                llegada.ubigeo = guias[0].UBIGEO_LLEGADA;
                llegada.direccion = guias[0].DIRECCION_LLEGADA;
                llegada.codigo_del_domicilio_fiscal = "0000";
                Guia.direccion_llegada= llegada;
                //Transportista
                transportista.codigo_tipo_documento_identidad = guias[0].TIPO_DOCUMENTO_TRANSPORTISTA;
                transportista.numero_documento = guias[0].DOCUMENTO_TRANSPORTISTA;
                transportista.apellidos_y_nombres_o_razon_social = guias[0].NOMBRE_TRANSPORTISTA;
                transportista.numero_mtc = guias[0].NUMERO_MTC;
                Guia.transportista= transportista;
                //Items
                List<Item> items = guias_DAOB.Lista_Item_Guias(Nro_OC);
                Guia.items = items;
                //Documento afectado
                documentoAfectado.serie_documento = "";
                documentoAfectado.numero_documento = "";
                documentoAfectado.codigo_tipo_documento = "";
                Guia.documento_afectado = documentoAfectado;
                //Convierte el Json
                string Json = JsonConvert.SerializeObject(Guia);
                //Envio de la factura
                //return Json;
                return api.Post_guide("https://stechperu.pro.facturalibre.org/api/dispatches", Json);
            }
            catch (Exception error)
            {
                return "error en el envio: " + error.Message;
            }
        }
        public dynamic Enviar_Guia_Priv(string Nro_OC)
        {
            try
            {
                List<e_GuiasPriv> guias = guias_DAOB.Lista_Guias_Priv(Nro_OC);
                DatosDelEmisor emisor = new DatosDelEmisor();
                DatosDelClienteOReceptor cliente = new DatosDelClienteOReceptor();
                DireccionLlegada llegada = new DireccionLlegada();
                DireccionPartida partida = new DireccionPartida();
                Chofer chofer = new Chofer();
                DocumentoAfectado documentoAfectado = new DocumentoAfectado();
                //Crea el Json
                e_GuiaEnviarPriv Guia = new e_GuiaEnviarPriv();
                Guia.serie_documento = "T001";
                Guia.numero_documento = "#";
                Guia.fecha_de_emision = DateTime.Now.ToString("yyyy-MM-dd");
                Guia.hora_de_emision = DateTime.Now.ToString("HH:mm:ss");
                Guia.codigo_tipo_documento = "09";
                //Crea al emisor
                emisor.codigo_pais = "PE";
                emisor.ubigeo = "150135";
                emisor.direccion = "Av. Honorio Delgado 224 Urb. Ingeniería San Martín de Porres";
                emisor.correo_electronico = "informes@s-tech.com.pe";
                emisor.telefono = "6161000";
                emisor.codigo_del_domicilio_fiscal = "0000";
                Guia.datos_del_emisor = emisor;
                //Crea el cliente
                cliente.codigo_tipo_documento_identidad = guias[0].TIPO_DOCUMENTO_CLIENTE;
                cliente.numero_documento = guias[0].NUMERO_DOCUMENTO;
                cliente.apellidos_y_nombres_o_razon_social = guias[0].NOMBRE_CLIENTE;
                cliente.codigo_pais = "PE";
                cliente.ubigeo = "";
                cliente.direccion = guias[0].DIRECCION_CLIENTE;
                cliente.correo_electronico = guias[0].CORREO;
                cliente.nombre_comercial = "";
                cliente.telefono = guias[0].TELEFONO;
                Guia.datos_del_cliente_o_receptor = cliente;
                //Datos generales
                Guia.observaciones = guias[0].OBSERVACION;
                Guia.orden_pedido_externo = Nro_OC;
                Guia.codigo_modo_transporte = "01";
                Guia.codigo_motivo_traslado = "01";
                Guia.descripcion_motivo_traslado = guias[0].DESCRIPCION_MOTIVO;
                Guia.fecha_de_traslado = guias[0].FECHA_TRASLADO;
                Guia.codigo_de_puerto = "";
                Guia.indicador_de_transbordo = false;
                Guia.unidad_peso_total = "KGM";
                Guia.peso_total = Convert.ToDouble(guias[0].PESO);
                Guia.numero_de_bultos = 1;
                Guia.numero_de_contenedor = "";
                //Direccion de partida
                partida.ubigeo = "150135";
                partida.direccion = "Av. Honorio Delgado 224 Urb. Ingeniería San Martín de Porres";
                partida.codigo_del_domicilio_fiscal = "0000";
                Guia.direccion_partida = partida;
                //Direccion de llegada
                llegada.ubigeo = guias[0].UBIGEO_LLEGADA;
                llegada.direccion = guias[0].DIRECCION_LLEGADA;
                llegada.codigo_del_domicilio_fiscal = "0000";
                Guia.direccion_llegada = llegada;
                //Transportista
                chofer.codigo_tipo_documento_identidad = guias[0].TIPO_DOCUMENTO_CHOFER;
                chofer.numero_documento = guias[0].DOCUMENTO_CHOFER;
                chofer.nombres = guias[0].NOMBRE_CHOFER;
                chofer.apellidos = "";
                chofer.numero_licencia = guias[0].LICENCIA;
                Guia.chofer = chofer;
                Guia.numero_de_placa = guias[0].PLACA;
                //Items
                List<Item> items = guias_DAOB.Lista_Item_Guias_PRIV(Nro_OC);
                Guia.items = items;
                //Documento afectado
                documentoAfectado.serie_documento = "";
                documentoAfectado.numero_documento = "";
                documentoAfectado.codigo_tipo_documento = "";
                Guia.documento_afectado = documentoAfectado;
                //Convierte el Json
                string Json = JsonConvert.SerializeObject(Guia);
                //Envio de la factura
                //return Json;
                return api.Post_guide("https://stechperu.pro.facturalibre.org/api/dispatches", Json);
            }
            catch (Exception error)
            {
                return "error en el envio: " + error.Message;
            }
        }
    }
}
