using ST_Datos;
using ST_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Negocio
{
    public class n_transportista
    {
        d_transportista transportista_DAOB;

        public n_transportista()
        {
            transportista_DAOB = new d_transportista();
        }
        public List<e_transportista> ListarTransportistas()
        {
            return transportista_DAOB.Lista_transportistas();
        }
        public string añadirTransportista(string nombre, string tipoD, string doc, string numeromtc, string direccion )
        {
            e_transportista transportista= new e_transportista();
            transportista.NOMBRE = nombre;
            transportista.TIPO_DOCUMENTO = tipoD;
            transportista.DOCUMENTO= doc;
            transportista.NUMERO_MTC= numeromtc;
            transportista.DIRECCION_FISCAL= direccion;
            return transportista_DAOB.Add_transportista(transportista);
        }
        public List<e_transportista> ListarTransportistas_filtro(string nombre, string tipoD, string doc, string numeromtc, string direccion)
        {
            e_transportista transportista = new e_transportista();
            transportista.NOMBRE = nombre;
            transportista.TIPO_DOCUMENTO = tipoD;
            transportista.DOCUMENTO = doc;
            transportista.NUMERO_MTC = numeromtc;
            transportista.DIRECCION_FISCAL = direccion;
            return transportista_DAOB.Lista_transportistas_filtro(transportista);
        }
        public List<e_choferes> ListarChoferes()
        {
            return transportista_DAOB.Lista_choferes();
        }
        public string añadirChofer(string nombre, string tipoDoc, string doc, string telefono, string licencia, string NRO_placa, string modelo, string marca)
        {
            e_choferes choferes = new e_choferes();
            choferes.NOMBRE = nombre;
            choferes.TIPO_DOCUMENTO = tipoDoc;
            choferes.DOCUMENTO = doc;
            choferes.TELEFONO = telefono;
            choferes.LICENCIA = licencia;
            choferes.NRO_PLACA = NRO_placa;
            choferes.MODELO = modelo;
            choferes.MARCA = marca;
            return transportista_DAOB.Add_Chofer(choferes);
        }
        public List<e_choferes> ListarChoferes_Filtro(string nombre, string tipoDoc, string doc, string telefono, string licencia, string NRO_placa, string modelo, string marca)
        {
            e_choferes choferes = new e_choferes();
            choferes.NOMBRE = nombre;
            choferes.TIPO_DOCUMENTO = tipoDoc;
            choferes.DOCUMENTO = doc;
            choferes.TELEFONO = telefono;
            choferes.LICENCIA = licencia;
            choferes.NRO_PLACA = NRO_placa;
            choferes.MODELO = modelo;
            choferes.MARCA = marca;
            return transportista_DAOB.Lista_choferes_filtro(choferes);
        }
    }
}
