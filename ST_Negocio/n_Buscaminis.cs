using System;
using System.Collections.Generic;
using System.Text;
using ST_Entidades;
using ST_Datos;

namespace ST_Negocio
{
    public class n_Buscaminis
    {
        d_Buscaminis minisDAOB;

        public n_Buscaminis()
        {
            minisDAOB = new d_Buscaminis();
        }
        
        public List<e_Buscaminis> ListaMinis(string minicod)
        {
            e_Buscaminis mini = new e_Buscaminis
            {
                Mini_Codigo = minicod
            };
            return minisDAOB.Lista_minicods(mini);
        }

        public List<e_Buscaminis> ListaParts(string partnumb)
        {
            e_Buscaminis partnumber = new e_Buscaminis
            {
                Partnumber = partnumb
            };
            return minisDAOB.Lista_minicods(partnumber);
        }

        public List<e_Buscaminis> ListaTitulos(string partnumb)
        {
            e_Buscaminis partnumber = new e_Buscaminis
            {
                Partnumber = partnumb
            };
            return minisDAOB.Lista_titulos(partnumber);
        }

        public List<e_Buscaminis> Lista_minicods(string titulo)
        {
            string[] filtros = titulo.Split(' ');
            switch (filtros.Length)
            {
                case 0:
                    return minisDAOB.Lista_minicods(titulo);
                    break;
                case 1:
                    return minisDAOB.Lista_minicods(titulo);
                    break;
                case 2:
                    return minisDAOB.Lista_minicods(filtros[0], filtros[1]);
                    break;
                case 3:
                    return minisDAOB.Lista_minicods(filtros[0], filtros[1], filtros[2]);
                    break;
                case 4:
                    return minisDAOB.Lista_minicods(filtros[0], filtros[1], filtros[2], filtros[3]);
                    break;
                default:
                    return minisDAOB.Lista_minicods(titulo);
                    break;
            }
        }

        public string Mostrar_Precio(string filtro)
        {
            return minisDAOB.MostrarPrecio(filtro);
        }

        public string Mostrar_Partnumb(string filtro)
        {
            return minisDAOB.MostrarPartnumber(filtro);
        }
    }
}
