using System;
using System.Collections.Generic;
using System.Text;
using ST_Entidades;
using ST_Datos;

namespace ST_Negocio
{
    public class n_Nvo_Prod
    {
        d_Nuevo_prod nvo_prodDAOB;
        public n_Nvo_Prod ()
        {
            nvo_prodDAOB = new d_Nuevo_prod();
        }

        public List<e_Nuevo_prod>Listar_nuevos_prd()
        {
            return nvo_prodDAOB.Lista_nuevos_prod();
        }
        public string Ingresar_nuevos_prod(string Fecha_registro,string UPC,string EAN,string Mandatorio,string Modelo,
            string Minicod,string Partnumb,string Marca,string Tipo,string Titulo, string Fecha_proceso,string color, string peso,
            string empaque_alto, string empaque_largo, string empaque_ancho, string producto_alto, string producto_largo, string producto_ancho)
        {
            e_Nuevo_prod nuevo_prod = new e_Nuevo_prod()
            {
                Fecha_registro = Fecha_registro,
                UPC=UPC,
                EAN = EAN,
                Mandatorio = Mandatorio,
                Modelo = Modelo,
                Minicod = Minicod,
                Partnumb = Partnumb,
                Marca = Marca,
                Tipo = Tipo,
                Titulo = Titulo,
                Color = color,
                Peso = peso,
                empaque_alto=empaque_alto,
                empaque_largo=empaque_largo,
                empaque_ancho=empaque_ancho,
                producto_alto=producto_alto,
                producto_ancho=producto_ancho,
                producto_largo=producto_largo,
            };
            return nvo_prodDAOB.Ingresar_nuevos_prod(nuevo_prod);

        }
        public string Ingresar_a_cons()
        {
            return nvo_prodDAOB.Ingresar_Cons();
        }
        public List<e_Marcas> Listar_marcas(string marca)
        {
            e_Marcas marcas = new e_Marcas()
            {
                Marca = marca
            };
            return nvo_prodDAOB.Lista_marcas(marcas);
        }
        public List<e_Tipo>Listar_tipos(string tipo)
        {
            e_Tipo tipos = new e_Tipo()
            {
                Tipo = tipo
            };
            return nvo_prodDAOB.Lista_tipos(tipos);
        }

        public string Actualizar_prod(string UPC, string EAN, string Modelo, string Minicod, string Partnumb, string Marca, string Tipo, string Titulo, int Id_nvop, string color, string peso,
            string empaque_alto, string empaque_largo, string empaque_ancho, string producto_alto, string producto_largo, string producto_ancho)
        {
     
              e_Nuevo_prod prod = new e_Nuevo_prod()
            {
               Id_nvop = Id_nvop,
               UPC = UPC,
               EAN = EAN,
               Modelo  = Modelo,
               Minicod = Minicod,
     
               Partnumb = Partnumb,
               Marca = Marca,
               Tipo =Tipo,
               Titulo = Titulo,

              Color = color,
              Peso = peso,
              empaque_alto = empaque_alto,
              empaque_largo = empaque_largo,
              empaque_ancho = empaque_ancho,
              producto_alto = producto_alto,
              producto_ancho = producto_ancho,
              producto_largo = producto_largo

              };
            return nvo_prodDAOB.Modificar_nvo_prod(prod);
        }

    }
}
