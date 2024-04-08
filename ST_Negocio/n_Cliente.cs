using ST_Datos;
using ST_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST_Negocio
{
    public class n_Cliente
    {
        d_Clientes clientes_DAOB;

        public n_Cliente()
        {
            clientes_DAOB = new d_Clientes();
        }
        public List<e_Cliente> Listar_Clientes()
        {
            return clientes_DAOB.Lista_Clientes();
        }
        public string Añadir_Cliente(string nombre,string direccionF, string direccionE,string tipodoc,string nrodoc,string telefono,string ubigeo,string correo,string codubigeo)
        {
            e_Cliente obj = new e_Cliente();
            obj.NOMBRE_RAZON_SOCIAL= nombre;
            obj.DIRECCION_FISCAL= direccionF;
            obj.DIRECCION_ENTREGA= direccionE;
            obj.TIPO_DOCUMENTO= tipodoc;
            obj.NRO_DOCUMENTO = nrodoc;
            obj.TELEFONO=telefono;
            obj.UBIGEO= ubigeo;
            obj.CORREO= correo;
            obj.COD_UBIGEO=codubigeo;
            return clientes_DAOB.Add_Cliente(obj);
        }
        public string Actualizar_Cliente(string nombre, string direccionF, string direccionE, string tipodoc, string nrodoc, string telefono, string ubigeo, string correo, 
            string codubigeo,int id)
        {
            e_Cliente obj = new e_Cliente();
            obj.NOMBRE_RAZON_SOCIAL = nombre;
            obj.DIRECCION_FISCAL = direccionF;
            obj.DIRECCION_ENTREGA = direccionE;
            obj.TIPO_DOCUMENTO = tipodoc;
            obj.NRO_DOCUMENTO = nrodoc;
            obj.TELEFONO = telefono;
            obj.UBIGEO = ubigeo;
            obj.CORREO = correo;
            obj.COD_UBIGEO = codubigeo;
            obj.ID_CLIENTE = id;
            return clientes_DAOB.Actualizar_cliente(obj);
        }
        public List<e_Cliente> Filtrar_Cliente(string nombre, string direccionF, string direccionE, string tipodoc, string nrodoc, string telefono, string ubigeo, string correo,string codubigeo)
        {
            e_Cliente obj = new e_Cliente();
            obj.NOMBRE_RAZON_SOCIAL = nombre;
            obj.DIRECCION_FISCAL = direccionF;
            obj.DIRECCION_ENTREGA = direccionE;
            obj.TIPO_DOCUMENTO = tipodoc;
            obj.NRO_DOCUMENTO = nrodoc;
            obj.TELEFONO = telefono;
            obj.UBIGEO = ubigeo;
            obj.CORREO = correo;
            obj.COD_UBIGEO = codubigeo;
            return clientes_DAOB.Lista_Clientes_Filtro(obj);
        }
        public List<e_Ubigeo> listar_Ubigeos()
        {
            return clientes_DAOB.lista_ubigeos();
        }
        public List<e_Ubigeo> listar_Ubigeos(string filtro)
        {
            string[] filtros = filtro.Split('/');
            e_Ubigeo ubigeo = new e_Ubigeo();

            switch (filtros.Length)
            {
                case 0:
                    ubigeo.DEPARTAMENTO = filtro;
                    break;
                case 1:
                    ubigeo.DEPARTAMENTO= filtros[0];
                    break;
                case 2:
                    ubigeo.DEPARTAMENTO = filtros[0];
                    ubigeo.PROVINCIA= filtros[1];
                    break;
                case 3:
                    ubigeo.DEPARTAMENTO = filtros[0];
                    ubigeo.PROVINCIA = filtros[1];
                    ubigeo.DISTRITO = filtros[2];
                    break;
                default:
                    ubigeo.DEPARTAMENTO = filtros[0];
                    ubigeo.PROVINCIA = filtros[1];
                    ubigeo.DISTRITO = filtros[2];
                    break;
            }
            return clientes_DAOB.lista_ubigeos_Filtro(ubigeo);
        }
        public List<e_Contacto> listar_contactos()
        {
            return clientes_DAOB.lst_Contactos();
        }
        public string añadir_contacto(string nombre, string documento, string observacion, string telefono, string correo, int Nro_contacto, int Id_cliente)
        {
            e_Contacto contacto= new e_Contacto();  
            contacto.NOMBRE= nombre;
            contacto.DOCUMENTO= documento;
            contacto.OBSERVACION= observacion;
            contacto.TELEFONO= telefono;
            contacto.CORREO= correo;
            contacto.NRO_CONTACTO= Nro_contacto;
            contacto.ID_CLIENTE= Id_cliente;
            return clientes_DAOB.Add_Ccntacto(contacto);
        }
        public List<e_Contacto> listar_contactos_Filtro(string nombre, string documento, string observacion, string telefono, string correo, int Id_cliente)
        {
            e_Contacto contacto = new e_Contacto();
            contacto.NOMBRE = nombre;
            contacto.DOCUMENTO = documento;
            contacto.OBSERVACION = observacion;
            contacto.TELEFONO = telefono;
            contacto.CORREO = correo;
            contacto.ID_CLIENTE = Id_cliente;
            return clientes_DAOB.lst_Contactos_filtro(contacto);
        }

        public string ultimo_contacto(string id)
        {
            return clientes_DAOB.last_contacto(id);
        }
    }
}
