using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ST_Datos;
using ST_Entidades;
namespace ST_Negocio
{
    public class n_Facturacion
    {
        d_Api Api;
        d_Salida salidaDAOB = new d_Salida();
        d_Facturacion facturacionDAOB = new d_Facturacion();
        public n_Facturacion()
        {
            Api = new d_Api();
        }
        public dynamic Facturacion_ARTOS(string NroOc, string codigoCondicion, string canal)
        {
            e_Factura factura = new e_Factura();
            e_ClienteFactura clienteFactura = new e_ClienteFactura();
            e_TotalesFactura totalesFactura = new e_TotalesFactura();
            e_CuotasFactura cuotaFactura = new e_CuotasFactura();
            string tipoDoc = "";
            //Items
            List<e_ItemsFactura> Items = new List<e_ItemsFactura>();
            switch (canal)
            {
                case ("FALABELLA"):
                    Items = facturacionDAOB.Lista_Items_Falabella_datos(NroOc);
                    //Datos del cliente
                    clienteFactura = facturacionDAOB.Lista_Cliente_Falabella_datos(NroOc);
                    if (clienteFactura.codigo_tipo_documento_identidad == "6")
                    {
                        dynamic respuesta = Api.Get("https://api.apis.net.pe/v1/ruc?numero=", clienteFactura.numero_documento);
                        clienteFactura.apellidos_y_nombres_o_razon_social = respuesta.nombre;
                        if (Convert.ToString(respuesta.direccion + respuesta.departamento + respuesta.provincia + respuesta.distrito) != "-")
                        {
                            clienteFactura.direccion = respuesta.direccion + " " + respuesta.departamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                        }
                    }
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
            }
            //Totales
            double total_gravadas = 0, total_impuestos = 0, total_venta = 0;
            foreach (e_ItemsFactura items in Items)
            {
                total_gravadas += items.valor_unitario * items.cantidad;
                total_impuestos += items.valor_unitario * items.cantidad * 0.18;
                total_venta += items.valor_unitario * items.cantidad + (items.valor_unitario * items.cantidad * 0.18);
            }
            totalesFactura.total_descuentos = 0.0;
            totalesFactura.total_exportacion = "0.00";
            totalesFactura.total_operaciones_gravadas = Math.Round(total_gravadas, 2);
            totalesFactura.total_operaciones_inafectas = "0.00";
            totalesFactura.total_operaciones_exoneradas = "0.00";
            totalesFactura.total_operaciones_gratuitas = "0.00";
            totalesFactura.total_igv = Math.Round(total_impuestos, 2);
            totalesFactura.total_impuestos = Math.Round(total_impuestos, 2);
            totalesFactura.total_valor = Math.Round(total_gravadas, 2);
            totalesFactura.total_venta = Math.Round(total_venta, 2);
            //Cuotas
            List<e_CuotasFactura> cuotasFacturas = new List<e_CuotasFactura>();
            cuotaFactura.codigo_metodo_de_pago = "05";
            cuotaFactura.fecha = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            cuotaFactura.codigo_tipo_moneda = "PEN";
            cuotaFactura.monto = total_venta;
            cuotasFacturas.Add(cuotaFactura);

            //Datos generales
            factura.serie_documento = tipoDoc == "1" ? "B001" : "F001";
            factura.numero_documento = "#";
            factura.fecha_de_emision = DateTime.Now.ToString("yyyy-MM-dd");
            factura.hora_de_emision = DateTime.Now.ToString("HH:mm:ss");
            factura.codigo_tipo_operacion = "0101";
            factura.codigo_tipo_documento = tipoDoc == "1" ? "03" : "01";
            factura.codigo_tipo_moneda = "PEN";
            factura.fecha_de_vencimiento = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            factura.numero_orden_de_compra = NroOc;
            factura.datos_del_cliente_o_receptor = clienteFactura;
            factura.codigo_condicion_de_pago = codigoCondicion;
            factura.cuotas = cuotasFacturas;
            factura.totales = totalesFactura;
            factura.items = Items;
            //Se crea el Json
            string Json = JsonConvert.SerializeObject(factura);
            //Guarda la factura
            Guardar_fact(NroOc, codigoCondicion, "PEN", clienteFactura.apellidos_y_nombres_o_razon_social, clienteFactura.codigo_tipo_documento_identidad,
                clienteFactura.numero_documento, clienteFactura.direccion, Items[Items.Count - 1].descripcion == "COSTO DE ENVIO" ? Items[Items.Count - 1].precio_unitario : 0, total_impuestos,
                total_gravadas, total_venta, DateTime.Now);
            //Guarda items de la factura
            foreach (e_ItemsFactura items in Items)
            {
                Guardar_Items_Fact(NroOc, items.descripcion, items.codigo_interno, items.cantidad, items.precio_unitario, items.total_igv);
            }
            //Envio de la factura
            return Api.Post_fact("https://artoselectronic.pro2.facturalibre.org/api/documents", Json, "Bearer xC3WkrufPRcoWt08yFtrGNLBbBxYAo4TXTuTTOMGqW4FACPVH1");

        }
        public dynamic Facturacion(string NroOc,string codigoCondicion,string canal)
        {
            e_Factura factura= new e_Factura();
            e_ClienteFactura clienteFactura = new e_ClienteFactura();
            e_TotalesFactura totalesFactura= new e_TotalesFactura();
            e_CuotasFactura cuotaFactura = new e_CuotasFactura();
            string tipoDoc = "";
            //Items
            List<e_ItemsFactura> Items = new List<e_ItemsFactura>(); 
            switch (canal)
            {
                case ("SAGA"):
                    Items = facturacionDAOB.Lista_Items_Saga_datos(NroOc);
                    tipoDoc = "6";
                    //Datos del cliente
                    clienteFactura.codigo_tipo_documento_identidad = "6";
                    clienteFactura.apellidos_y_nombres_o_razon_social = "SAGA FALABELLA S A";
                    clienteFactura.numero_documento = "20100128056";
                    clienteFactura.codigo_pais = "PE";
                    clienteFactura.ubigeo = "";
                    clienteFactura.direccion = "AV. PASEO DE LA REPUBLICA NRO. 3220 URB. JARDIN LIMA - LIMA - SAN ISIDRO ";
                    clienteFactura.correo_electronico = "remercasf@falabella.com.pe";
                    clienteFactura.telefono = "6161000";
                    break;
                case ("ARTOS"):
                    Items = facturacionDAOB.Lista_Items_Artos_datos(NroOc);
                    tipoDoc = "6";
                    //Datos del cliente
                    clienteFactura.codigo_tipo_documento_identidad = "6";
                    clienteFactura.apellidos_y_nombres_o_razon_social = "ARTOS ELECTRONIC E.I.R.L.";
                    clienteFactura.numero_documento = "20611125888";
                    clienteFactura.codigo_pais = "PE";
                    clienteFactura.ubigeo = "";
                    clienteFactura.direccion = "AV. HONORIO DELGADO NRO. 224 URB. INGENIERIA LIMA - LIMA - SAN MARTIN DE PORRES ";
                    clienteFactura.correo_electronico = "catphonepe@gmail.com";
                    clienteFactura.telefono = "965 744 589";
                    break;
                case ("LINIO"):
                    Items = facturacionDAOB.Lista_Items_Linio_datos(NroOc);
                    //Datos del cliente
                    clienteFactura = facturacionDAOB.Lista_Cliente_Linio_datos(NroOc);
                    if (clienteFactura.codigo_tipo_documento_identidad == "6")
                    {
                        dynamic respuesta = Api.Get("https://api.apis.net.pe/v1/ruc?numero=", clienteFactura.numero_documento);
                        clienteFactura.apellidos_y_nombres_o_razon_social = respuesta.nombre;
                        if(Convert.ToString(respuesta.direccion + respuesta.departamento + respuesta.provincia + respuesta.distrito) != "-")
                        {
                            clienteFactura.direccion = respuesta.direccion + " " + respuesta.departamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                        }
                    }
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
                case ("RIPLEY"):
                    Items = facturacionDAOB.Lista_Items_Ripley_datos(NroOc);
                    clienteFactura = facturacionDAOB.Lista_Cliente_Ripley_datos(NroOc);
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
                case ("REAL PLAZA"):
                    Items = facturacionDAOB.Lista_Items_RealPlaza_datos(NroOc);
                    clienteFactura = facturacionDAOB.Lista_Cliente_RealPlaza_datos(NroOc);
                    if (clienteFactura.codigo_tipo_documento_identidad == "6")
                    {
                        dynamic respuesta = Api.Get("https://api.apis.net.pe/v1/ruc?numero=", clienteFactura.numero_documento);
                        clienteFactura.apellidos_y_nombres_o_razon_social = respuesta.nombre;
                        if (Convert.ToString(respuesta.direccion + respuesta.departamento + respuesta.provincia + respuesta.distrito) != "-")
                        {
                            clienteFactura.direccion = respuesta.direccion + " " + respuesta.departamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                        }
                    }
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
                case ("OFICINA"):
                    Items = facturacionDAOB.Lista_Items_Oficina_datos(NroOc);
                    clienteFactura = facturacionDAOB.Lista_Cliente_Oficina_datos(NroOc);
                    List<e_Salida> NewNroOc = salidaDAOB.Get_last_orden();
                    NroOc = NewNroOc[0].NRO_ORDEN;
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
                case ("KINGSTON"):
                    Items = facturacionDAOB.Lista_Items_Kingston_datos(NroOc);
                    clienteFactura = facturacionDAOB.Lista_Cliente_Kingston_datos(NroOc);
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
                case ("MERCADO LIBRE"):
                    Items = facturacionDAOB.Lista_Items_MercadoLibre_datos(NroOc);
                    clienteFactura = facturacionDAOB.Lista_Cliente_MercadoLibre_datos(NroOc);
                    if (clienteFactura.codigo_tipo_documento_identidad == "6")
                    {
                        dynamic respuesta = Api.Get("https://api.apis.net.pe/v1/ruc?numero=", clienteFactura.numero_documento);
                        clienteFactura.apellidos_y_nombres_o_razon_social = respuesta.nombre;
                        if (Convert.ToString(respuesta.direccion + respuesta.departamento + respuesta.provincia + respuesta.distrito) != "-")
                        {
                            clienteFactura.direccion = respuesta.direccion + " " + respuesta.departamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                        }
                    }
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
                case ("JUNTOZ"):
                    Items= facturacionDAOB.Lista_Items_Juntoz_datos(NroOc);
                    clienteFactura=facturacionDAOB.Lista_Cliente_Juntoz_datos(NroOc);
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
                case ("CATPHONE"):
                    Items=facturacionDAOB.Lista_Items_CatPhone_datos(NroOc);
                    clienteFactura = facturacionDAOB.Lista_Cliente_CatPhone_datos(NroOc);
                    if (clienteFactura.codigo_tipo_documento_identidad == "6")
                    {
                        dynamic respuesta = Api.Get("https://api.apis.net.pe/v1/ruc?numero=", clienteFactura.numero_documento);
                        clienteFactura.apellidos_y_nombres_o_razon_social = respuesta.nombre;
                        if (Convert.ToString(respuesta.direccion + respuesta.departamento + respuesta.provincia + respuesta.distrito) != "-")
                        {
                            clienteFactura.direccion = respuesta.direccion + " " + respuesta.departamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                        }
                    }
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
                case ("COOLBOX"):
                    Items = facturacionDAOB.Lista_Items_Coolbox_datos(NroOc);
                    clienteFactura = facturacionDAOB.Lista_Cliente_Coolbox_datos(NroOc);
                    if (clienteFactura.codigo_tipo_documento_identidad == "6")
                    {
                        dynamic respuesta = Api.Get("https://api.apis.net.pe/v1/ruc?numero=", clienteFactura.numero_documento);
                        clienteFactura.apellidos_y_nombres_o_razon_social = respuesta.nombre;
                        if (Convert.ToString(respuesta.direccion + respuesta.departamento + respuesta.provincia + respuesta.distrito) != "-")
                        {
                            clienteFactura.direccion = respuesta.direccion + " " + respuesta.departamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                        }
                    }
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
                //agregando Conecta
                case ("CONECTA"):
                    Items = facturacionDAOB.Lista_Items_Conecta_datos(NroOc);
                    //SE CARGA LOS DATOS DEL CANAL DE CONECTA
                    clienteFactura = facturacionDAOB.Lista_Cliente_Conecta_datos(NroOc);
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    //Datos del cliente
                    //clienteFactura.codigo_tipo_documento_identidad = "6";
                    //clienteFactura.apellidos_y_nombres_o_razon_social = "CONECTA RETAIL S.A.";
                    //clienteFactura.numero_documento = "20141189850";
                    //clienteFactura.codigo_pais = "PE";
                    //clienteFactura.ubigeo = "";
                    //clienteFactura.direccion = " AV. LUIS GONZALES NRO 1315 URB. CERCADO DE CHICLAYO , CHICLAYO , CHICLAYO - LAMBAYEQUE ";
                    //clienteFactura.correo_electronico = "remercasf@conecta.com.pe";
                    //clienteFactura.telefono = "6161000";
                    break;
            }
            //Totales
            double total_gravadas = 0, total_impuestos = 0, total_venta = 0;
            foreach (e_ItemsFactura items in Items)
            {
                total_gravadas += items.valor_unitario*items.cantidad;
                total_impuestos += items.valor_unitario * items.cantidad * 0.18;
                total_venta += items.valor_unitario * items.cantidad + (items.valor_unitario * items.cantidad * 0.18);
            }
            totalesFactura.total_descuentos = 0.0;
            totalesFactura.total_exportacion = "0.00";
            totalesFactura.total_operaciones_gravadas = Math.Round(total_gravadas,2);
            totalesFactura.total_operaciones_inafectas = "0.00";
            totalesFactura.total_operaciones_exoneradas = "0.00";
            totalesFactura.total_operaciones_gratuitas = "0.00";
            totalesFactura.total_igv = Math.Round(total_impuestos,2);
            totalesFactura.total_impuestos=Math.Round(total_impuestos, 2);
            totalesFactura.total_valor = Math.Round(total_gravadas, 2);
            totalesFactura.total_venta= Math.Round(total_venta, 2);
            //Cuotas
            List<e_CuotasFactura> cuotasFacturas = new List<e_CuotasFactura>();
            cuotaFactura.codigo_metodo_de_pago = "05";
            cuotaFactura.fecha = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            cuotaFactura.codigo_tipo_moneda = "PEN";
            cuotaFactura.monto = total_venta;
            cuotasFacturas.Add(cuotaFactura);

            //Datos generales
            factura.serie_documento = tipoDoc=="1"? "B001":"F001";
            factura.numero_documento = "#";
            factura.fecha_de_emision = DateTime.Now.ToString("yyyy-MM-dd");
            factura.hora_de_emision = DateTime.Now.ToString("HH:mm:ss");
            factura.codigo_tipo_operacion = "0101";
            factura.codigo_tipo_documento = tipoDoc=="1"? "03":"01";
            factura.codigo_tipo_moneda = "PEN";
            factura.fecha_de_vencimiento = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            factura.numero_orden_de_compra = NroOc;
            factura.datos_del_cliente_o_receptor = clienteFactura;
            factura.codigo_condicion_de_pago =codigoCondicion;
            factura.cuotas = cuotasFacturas;
            factura.totales = totalesFactura;
            factura.items = Items;
            //Se crea el Json
            string Json = JsonConvert.SerializeObject(factura);
            //Guarda la factura
            Guardar_fact(NroOc, codigoCondicion, "PEN", clienteFactura.apellidos_y_nombres_o_razon_social, clienteFactura.codigo_tipo_documento_identidad,
                clienteFactura.numero_documento, clienteFactura.direccion, Items[Items.Count - 1].descripcion == "COSTO DE ENVIO" ? Items[Items.Count - 1].precio_unitario : 0, total_impuestos,
                total_gravadas, total_venta, DateTime.Now);
            //Guarda items de la factura
            foreach (e_ItemsFactura items in Items)
            {
                Guardar_Items_Fact(NroOc, items.descripcion, items.codigo_interno, items.cantidad, items.precio_unitario, items.total_igv);
            }
            //Envio de la factura
            return Api.Post_fact("https://stechperu.pro.facturalibre.org/api/documents", Json);
            //return Api.Post_fact("https://demo1.pro.facturalibre.org/api/documents", Json);
            //return Json;
        }
        public dynamic Facturacion_Contado(string NroOc, string codigoCondicion, string canal)
        {
            e_FacturaContado factura = new e_FacturaContado();
            e_ClienteFactura clienteFactura = new e_ClienteFactura();
            e_TotalesFactura totalesFactura = new e_TotalesFactura();
            string tipoDoc = "";
            //Items
            List<e_ItemsFactura> Items = new List<e_ItemsFactura>();
            switch (canal)
            {
                case ("OFICINA"):
                    Items = facturacionDAOB.Lista_Items_Oficina_datos(NroOc);
                    clienteFactura = facturacionDAOB.Lista_Cliente_Oficina_datos(NroOc);
                    List<e_Salida> NewNroOc = salidaDAOB.Get_last_orden();
                    NroOc = NewNroOc[0].NRO_ORDEN;
                    tipoDoc = clienteFactura.codigo_tipo_documento_identidad;
                    break;
            }
            //Totales
            double total_gravadas = 0, total_impuestos = 0, total_venta = 0;
            foreach (e_ItemsFactura items in Items)
            {
                total_gravadas += items.valor_unitario * items.cantidad;
                total_impuestos += items.valor_unitario * items.cantidad * 0.18;
                total_venta += items.valor_unitario * items.cantidad + (items.valor_unitario * items.cantidad * 0.18);
            }
            totalesFactura.total_descuentos = 0.0;
            totalesFactura.total_exportacion = "0.00";
            totalesFactura.total_operaciones_gravadas = Math.Round(total_gravadas, 2);
            totalesFactura.total_operaciones_inafectas = "0.00";
            totalesFactura.total_operaciones_exoneradas = "0.00";
            totalesFactura.total_operaciones_gratuitas = "0.00";
            totalesFactura.total_igv = Math.Round(total_impuestos, 2);
            totalesFactura.total_impuestos = Math.Round(total_impuestos, 2);
            totalesFactura.total_valor = Math.Round(total_gravadas, 2);
            totalesFactura.total_venta = Math.Round(total_venta, 2);

            //Datos generales
            factura.serie_documento = tipoDoc == "1" ? "B001" : "F001";
            factura.numero_documento = "#";
            factura.fecha_de_emision = DateTime.Now.ToString("yyyy-MM-dd");
            factura.hora_de_emision = DateTime.Now.ToString("HH:mm:ss");
            factura.codigo_tipo_operacion = "0101";
            factura.codigo_tipo_documento = tipoDoc == "1" ? "03" : "01";
            factura.codigo_tipo_moneda = "PEN";
            factura.fecha_de_vencimiento = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            factura.numero_orden_de_compra = NroOc;
            factura.datos_del_cliente_o_receptor = clienteFactura;
            factura.codigo_condicion_de_pago = "01";
            factura.totales = totalesFactura;
            factura.items = Items;
            //Se crea el Json
            string Json = JsonConvert.SerializeObject(factura);
            //Guarda la factura
            Guardar_fact(NroOc, codigoCondicion, "PEN", clienteFactura.apellidos_y_nombres_o_razon_social, clienteFactura.codigo_tipo_documento_identidad,
                clienteFactura.numero_documento, clienteFactura.direccion, Items[Items.Count - 1].descripcion == "COSTO DE ENVIO" ? Items[Items.Count - 1].precio_unitario : 0, total_impuestos,
                total_gravadas, total_venta, DateTime.Now);
            //Guarda items de la factura
            foreach (e_ItemsFactura items in Items)
            {
                Guardar_Items_Fact(NroOc, items.descripcion, items.codigo_interno, items.cantidad, items.precio_unitario, items.total_igv);
            }
            //Envio de la factura
            return Api.Post_fact("https://stechperu.pro.facturalibre.org/api/documents", Json);
            //return Json;
        }
        public string Guardar_fact(string NRO_OC, string CODIGO_OP, string TIPO_MONEDA, string CLIENTE, string codigo_DOC, string doc, string direccion,
        double precio_env, double impuestos, double valor, double venta, DateTime fecha)
        {
            e_FacturaEnviada factura = new e_FacturaEnviada();
            factura.NRO_OC = NRO_OC;
            factura.CODIGO_TIPO_OPERACION = CODIGO_OP;
            factura.TIPO_MONEDA = TIPO_MONEDA;
            factura.CLIENTE = CLIENTE;
            factura.CODIGO_TIPO_DOCUMENTO = codigo_DOC;
            factura.NUMERO_DOCUMENTO = doc;
            factura.DIRECCION = direccion;
            factura.PRECIO_ENVIO = precio_env;
            factura.TOTAL_IMPUESTOS = impuestos;
            factura.TOTAL_VALOR = valor;
            factura.TOTAL_VENTA = venta;
            factura.FECHA_EMISION = fecha;
            return facturacionDAOB.Guardar_Fact(factura);
        }
        public string Guardar_Items_Fact(string NRO_OC, string Producto, string codigo, int cantidad, double precio, double igv)
        {
            e_FacturaEnviada factura = new e_FacturaEnviada();
            factura.NRO_OC = NRO_OC;
            factura.PRODUCTO = Producto;
            factura.CODIGO_INTERNO = codigo;
            factura.CANTIDAD = cantidad;
            factura.PRECIO_UNITARIO = precio;
            factura.IGV_PRODUCTO = igv;
            return facturacionDAOB.Guardar_Items_Fact(factura);
        }
        //cambiar a switch a futuro
        public List<e_FacturasPendientes> listarFacturasSaga() => facturacionDAOB.Lista_Items_Saga();
        public List<e_FacturasPendientes> listarFacturasSaga(string NRO) => facturacionDAOB.Lista_Items_Saga(NRO);
        public List<e_FacturasPendientes> FechalistarFacturasSaga(string FECHA) => facturacionDAOB.Lista_Items_Saga_Filtro(FECHA);
        public List<e_FacturasPendientes> listarFacturasLinio() => facturacionDAOB.Lista_Items_Linio();
        public List<e_FacturasPendientes> listarFacturasLinio(string NRO) => facturacionDAOB.Lista_Items_Linio(NRO);
        public List<e_FacturasPendientes> listarFacturasRipley() => facturacionDAOB.Lista_Items_Ripley();
        public List<e_FacturasPendientes> listarFacturasRipley(string NRO) => facturacionDAOB.Lista_Items_Ripley(NRO);
        public List<e_FacturasPendientes> listarFacturasRealPlaza()=> facturacionDAOB.Lista_Items_RealPlaza();
        public List<e_FacturasPendientes> listarFacturasRealPlaza(string NRO) => facturacionDAOB.Lista_Items_RealPlaza(NRO);
        public List<e_FacturasPendientes> listarFacturasOficina() => facturacionDAOB.Lista_Items_Oficina();
        public List<e_FacturasPendientes> listarFacturasOficina(string NRO) => facturacionDAOB.Lista_Items_Oficina(NRO);
        public List<e_FacturasPendientes> listarFacturasKingston() => facturacionDAOB.Lista_Items_Kingston();
        public List<e_FacturasPendientes> listarFacturasKingston(string NRO) => facturacionDAOB.Lista_Items_Kingston(NRO);
        public List<e_FacturasPendientes> listarFacturasMercadoLibre() => facturacionDAOB.Lista_Items_MercadoLibre();
        public List<e_FacturasPendientes> listarFacturasMercadoLibre(string NRO) => facturacionDAOB.Lista_Items_MercadoLibre(NRO);
        public List<e_FacturasPendientes> listarFacturasJuntoz() => facturacionDAOB.Lista_Items_Juntoz();
        public List<e_FacturasPendientes> listarFacturasJuntoz(string NRO) => facturacionDAOB.Lista_Items_Juntoz(NRO);
        public List<e_FacturasPendientes> listarFacturasCatPhone() => facturacionDAOB.Lista_Items_Catphone();
        public List<e_FacturasPendientes> listarFacturasCatPhone(string NRO) => facturacionDAOB.Lista_Items_Catphone(NRO);
        public List<e_FacturasPendientes> listarFacturasCoolbox() => facturacionDAOB.Lista_Items_COOLBOX();
        public List<e_FacturasPendientes> listarFacturasCoolbox(string NRO) => facturacionDAOB.Lista_Items_COOLBOX(NRO);
        public List<e_FacturasPendientes> listarFacturasArtos() => facturacionDAOB.Lista_Items_Artos();
        public List<e_FacturasPendientes> listarFacturasArtos(string NRO) => facturacionDAOB.Lista_Items_Artos(NRO);
        public List<e_FacturasPendientes> listarFacturasFalabella() => facturacionDAOB.Lista_Items_Falabella();
        public List<e_FacturasPendientes> listarFacturasFalabella(string NRO) => facturacionDAOB.Lista_Items_Falabella(NRO);
        //agregando Conecta
        public List<e_FacturasPendientes> listarFacturasConecta() => facturacionDAOB.Lista_Items_Conecta();
        public List<e_FacturasPendientes> listarFacturasConecta(string NRO) => facturacionDAOB.Lista_Items_Conecta(NRO);

        //FILTRO POR FECHA
        public List<e_FacturasPendientes> FechalistarFacturasConecta(string FECHA) => facturacionDAOB.Lista_Items_Conecta_Filtro(FECHA);

        //actualizano guia para la facura

        public string actualizarGuia(string NRO_OC, string RUC, string CLIENTE, string DILL)
        {
            try
            {
                facturacionDAOB.Update_Guias(NRO_OC, RUC, CLIENTE, DILL);
                return "Se actualizaron los EU";
            }
            catch (Exception err)
            {
                return $"Error al actualizar: {err.Message}";
            }
        }

        public string actualizaNroFactSaga(string nro, string NROOC) 
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Actualizar_NroFact_SAGA(strings[0], strings[1], NROOC);
        }
        public string actualizaNroFactLinio(string nro, string NROOC)
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Actualizar_NroFact_LINIO(strings[0], strings[1], NROOC);
        }
        public string actualizaNroFactRipley(string nro, string NROOC)
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Actualizar_NroFact_Ripley(strings[0], strings[1], NROOC);
        }
        public string actualizaNroFactRealPlaza(string nro, string NROOC)
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Actualizar_NroFact_RealPlaza(strings[0], strings[1], NROOC);
        }
        public string actualizaNroKingston(string nro, string NROOC)
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Actualizar_NroFact_Kingston(strings[0], strings[1], NROOC);
        }
        public string actualizaNroMercado(string nro, string NROOC)
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Actualizar_NroFact_MercadoLibre(strings[0], strings[1], NROOC);
        }
        public string actualizaNroJuntoz(string nro, string NROOC)
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Actualizar_NroFact_Juntoz(strings[0], strings[1], NROOC);
        }
        public string actualizaNroCoolbox(string nro, string NROOC)
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Actualizar_NroFact_Coolbox(strings[0], strings[1], NROOC);
        }
        //AGREGANDO CONECTA **
        public string actualizaNroFactConecta(string nro, string NROOC)
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Actualizar_NroFact_Conecta(strings[0], strings[1], NROOC);
        }
        public string GuardarNroFact(string nro, string NROOC)
        {
            //divide el nro de factura para guardarlo
            string[] strings = nro.Split('-');
            return facturacionDAOB.Guardar_serie(strings[0], strings[1], NROOC);
        }
    }
}
