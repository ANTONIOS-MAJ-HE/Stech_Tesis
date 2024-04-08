using Newtonsoft.Json;
using ST_Datos;
using ST_Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ST_Negocio
{
    public class n_GuiasConecta
    {
        d_GuiasConecta guias_DAOB;
        d_Api api = new d_Api();

        public n_GuiasConecta()
        {
            guias_DAOB = new d_GuiasConecta();
        }

        public List<e_Guias> ListarGuias() => guias_DAOB.Listar_guias();

        //produccion

        public string actualizarGuia(string OCS, string FECHA, string RUC, string CLIENTE, string DILL, string OBS)
        {

            try
            {
                DateTime.TryParseExact(FECHA, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaParsed);
                string fechaFormatted = fechaParsed.ToString("yyyy-MM-dd HH:mm:ss.fff");
                guias_DAOB.Update_Guias(OBS, OCS, fechaFormatted, RUC, CLIENTE, DILL);

                return "Se actualizaron los EU";
            }
            catch (Exception err)
            {
                return $"Error al actualizar: {err.Message}";
            }
        }
        public string añadirGuias() => guias_DAOB.Guias_a_entregar();
        public List<e_Guias> buscarOC(string filtro) => guias_DAOB.Listar_guias_NROOC(filtro);
        public List<e_Guias> buscarGuias(string filtro) => guias_DAOB.Listar_guias_F(filtro);
        public dynamic Enviar_Guia(string Nro_OC)
        {
            try
            {
                List<e_Guias> guias = guias_DAOB.Listar_guias_Filtro(Nro_OC);
                DatosDelEmisor emisor = new DatosDelEmisor();
                DatosDelClienteOReceptor cliente1 = new DatosDelClienteOReceptor();
                DireccionLlegada llegada = new DireccionLlegada();
                DireccionPartida partida = new DireccionPartida();
                Chofer chofer = new Chofer();
                Vehiculo vehiculo = new Vehiculo();
                //Transportista transportista = new Transportista();
                DocumentoAfectado documentoAfectado = new DocumentoAfectado();
                //Crea el Json
                e_GuiaEnviarConecta Guia = new e_GuiaEnviarConecta();
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
                cliente1.codigo_tipo_documento_identidad = guias[0].TIPO_DOCUMENTO_CLIENTE;
                cliente1.numero_documento = guias[0].NUMERO_DOCUMENTO;
                cliente1.apellidos_y_nombres_o_razon_social = guias[0].NOMBRE_CLIENTE;
                cliente1.codigo_pais = "PE";
                cliente1.ubigeo = "";
                cliente1.direccion = guias[0].DIRECCION_CLIENTE;
                cliente1.correo_electronico = guias[0].CORREO;
                cliente1.nombre_comercial = "";
                cliente1.telefono = guias[0].TELEFONO;
                Guia.datos_del_cliente_o_receptor = cliente1;
                //Datos generales
                Guia.observaciones = guias[0].OBSERVACION;
                Guia.orden_pedido_externo = Nro_OC;
                Guia.codigo_modo_transporte = "02";
                Guia.codigo_motivo_traslado = "05";
                Guia.descripcion_motivo_traslado = guias[0].DESCRIPCION_MOTIVO;
                Guia.fecha_de_traslado = guias[0].FECHA_TRASLADO;
                Guia.codigo_de_puerto = "";
                Guia.indicador_de_transbordo = false;
                Guia.unidad_peso_total = "KGM";
                Guia.peso_total = Convert.ToDouble(guias[0].PESO);
                Guia.numero_de_bultos = 1;
                Guia.numero_de_contenedor = "";
                //agregando la parte para parte de transporte privado: se modifica la parte de la entidad enviar guia, para esos dos campos
                Guia.traslado_categoria_m1l = false;
                Guia.numero_de_placa = "AAA111";//a011254
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

                //chofer.cuando es privado
                chofer.codigo_tipo_documento_identidad = "1";//falta editar esta parte para la guia
                chofer.numero_documento = "77777777";
                chofer.nombres = "Generico";
                chofer.apellidos = "Generico";
                chofer.numero_licencia = "Q77777777";
                Guia.chofer = chofer;
                //vehiculo
                vehiculo.numero_de_placa = "AAA111";
                vehiculo.modelo = "S/M";
                vehiculo.marca = "S/M";
                Guia.vehiculo = vehiculo;
                //Transportista
                //transportista.codigo_tipo_documento_identidad = guias[0].TIPO_DOCUMENTO_TRANSPORTISTA;
                //transportista.numero_documento = guias[0].DOCUMENTO_TRANSPORTISTA;
                //transportista.apellidos_y_nombres_o_razon_social = guias[0].NOMBRE_TRANSPORTISTA;
                //transportista.numero_mtc = guias[0].NUMERO_MTC;
                //Guia.transportista = transportista;
                //Items
                List<Item> items = guias_DAOB.Listar_Saga_Items(Nro_OC);
                Guia.items = items;
                //Documento afectado
                documentoAfectado.serie_documento = "";
                documentoAfectado.numero_documento = "";
                documentoAfectado.codigo_tipo_documento = "";
                Guia.documento_afectado = documentoAfectado;
                //Convierte el Json
                string Json = JsonConvert.SerializeObject(Guia);
                //Envio de la factura
                //json de prueba
                //return api.Post_guide("https://demo1.pro.facturalibre.org/api/dispatches", Json);
                //return Json; api de producción
                return api.Post_guide("https://stechperu.pro.facturalibre.org/api/dispatches", Json);
            }
            catch (Exception error)
            {
                return "error en el envio: " + error.Message;
            }
        }

        public string GuardarNumero(string nro, string Orden)
        {
            return guias_DAOB.GuardarGuia(nro, Orden);
        }
    }
}
