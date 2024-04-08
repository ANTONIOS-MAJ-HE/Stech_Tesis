using System;
using System.Collections.Generic;
using System.Text;
using ST_Datos;
using ST_Entidades;

namespace ST_Negocio
{
    public class n_Pistoleo
    {
        d_Pistoleo pistoleo_DAOB;

        public n_Pistoleo()
        {
            pistoleo_DAOB = new d_Pistoleo();
        }

        public string Actualizar_folio ()
        {
            return pistoleo_DAOB.Actualizar_Folio();
        }
        public string Actualizar_prod_listo(string NRO_GUIA, string NRO_SERIE, string FOLIO, string NRO_OC)
        {
            e_Ordenes_pistoleo oc = new e_Ordenes_pistoleo()
            {
                NRO_GUIA = NRO_GUIA,
                NRO_SERIE = NRO_SERIE,
                FOLIO = FOLIO,
                NRO_OC = NRO_OC
            };
            return pistoleo_DAOB.Actualizar_prod_listo(oc);
        }
        public string Limpiar_prod_listo_temp()
        {
            return pistoleo_DAOB.Limpiar_prod_listo_temp();
        }

        public string Cargar_desp_nuevo()
        {
            return pistoleo_DAOB.Cargar_desp_nuevo();
        }
        public string Actualizar_pisto_rapido()
        {
            return pistoleo_DAOB.Actualizar_pisto_rapido();
        }
        public string Ingresar_pistoleo_rapido(string EAN_UPC, string PRODUCTO, string CANAL, string MODELO, string PARTNUMBER, string RESPONSABLE)
        {
            e_Prod_listo prod = new e_Prod_listo()
            {
                EAN_UPC = EAN_UPC,
                PRODUCTO = PRODUCTO,
                CANAL = CANAL,
                MODELO = MODELO,
                PARTNUMBER = PARTNUMBER,
                RESPONSABLE = RESPONSABLE
            };
            return pistoleo_DAOB.Ingresar_pistoleo_rapido(prod);
        }
        public List<e_Ordenes_pistoleo> Lista_pistoleo_rapido()
        {
            return pistoleo_DAOB.Lista_pistoleo_rapido();
        }

        public List<e_Ordenes_pistoleo> Lista_cant_pendiente(string CANAL)
        {
            e_Ordenes_pistoleo prd = new e_Ordenes_pistoleo()
            {
                CANAL = CANAL
            };
            return pistoleo_DAOB.Lista_cant_pendiente(prd);
        }
        public string Actualiza_ocs()
        {
            return pistoleo_DAOB.Actualizar_lista_ocs();
        }
        public string Ingresar_pistoleo( string MODELO, string PARTNUMBER, string RESPONSABLE,string EAN_UPC)
        {
            e_Prod_listo prod = new e_Prod_listo()
            {
           
                MODELO = MODELO,
                PARTNUMBER = PARTNUMBER,
                RESPONSABLE = RESPONSABLE,
                EAN_UPC= EAN_UPC
            };
            return pistoleo_DAOB.Ingresar_pistoleo(prod);
        }
        public string Eliminar_prod_pisto(int N_ITEM)
        {
            e_Prod_listo prod = new e_Prod_listo()
            {
                N_ITEM = N_ITEM
            };
            return pistoleo_DAOB.Eliminar_prod_lista_pisto_Temp(prod);
        }

        public List<e_Pisto_Error>Lista_errores_pisto(string CANAL,string N_OC)
            {

            e_Ordenes_pistoleo ord = new e_Ordenes_pistoleo()
            {
                CANAL = CANAL,
                NRO_OC = N_OC
            };
            return pistoleo_DAOB.Lista_errores_pisto(ord);
            }
        public List<e_Prod_listo>Listar_prod_temp()
        {
            return pistoleo_DAOB.Lista_prod_listos();
        }
        public string Ingresar_prod_temp(string EAN_UPC, string PRODUCTO, string CANAL, string NRO_OC, string MODELO, string PARTNUMBER)
        {
            e_Prod_listo prod = new e_Prod_listo()
            {
                EAN_UPC = EAN_UPC,
                PRODUCTO = PRODUCTO,
                CANAL = CANAL,
                NRO_OC = NRO_OC,
                MODELO = MODELO,
                PARTNUMBER = PARTNUMBER
            };
            return pistoleo_DAOB.Ingresar_prod_temp(prod);
        }
        public List<e_BuscaPisto> Lista_prod_part(string EAN_UPC)
        {
            e_BuscaPisto pisto = new e_BuscaPisto()
            {
                EAN_UPC = EAN_UPC
            };

            return pistoleo_DAOB.Lista_Prod_Listos_part(pisto);
        }
        public List<e_BuscaPisto>Lista_prod_barras(string EAN_UPC)
        {
            e_BuscaPisto pisto = new e_BuscaPisto()
            {
                EAN_UPC = EAN_UPC
            };

            return pistoleo_DAOB.Lista_Prod_Listos_barras(pisto);
        }
        public List<e_Pendiente_despacho> Lista_pendiente_dsp(string CANAL, string PRODUCTO, string NRO_OC, string MINI_CODIGO, string FECHA_DESPACHO)
        {
            e_Pendiente_despacho pend = new e_Pendiente_despacho()
            {
                CANAL = CANAL,
                PRODUCTO = PRODUCTO,
                NRO_OC = NRO_OC,
                MINI_CODIGO = MINI_CODIGO,
                FECHA_DESPACHO = FECHA_DESPACHO
            };
            return pistoleo_DAOB.Lista_Pendiente_dsp(pend);
        }
        public List<e_cant_pendientes> Cuenta_pendiente_dsp()
        {
            return pistoleo_DAOB.Lista_cant_canal();
        }
        public List<e_Ordenes_pistoleo> Lista_pistoleo_oc(string CANAL,string EAN_UPC)
        {
            e_Ordenes_pistoleo pend = new e_Ordenes_pistoleo()
            {
                CANAL = CANAL,
                EAN_UPC = EAN_UPC
            };
            return pistoleo_DAOB.Lista_pistoleo_oc(pend);
        }
        public List<e_Prod_OC> Lista_productosXorden(string CANAL, string NRO_OC )
        {
            e_Ordenes_pistoleo pend = new e_Ordenes_pistoleo()
            {
                CANAL = CANAL,
                NRO_OC = NRO_OC
            };

            return pistoleo_DAOB.Lista_productosXorden(pend);
        }
    }
}
