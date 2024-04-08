using System;
using System.Collections.Generic;
using System.Text;
using ST_Entidades;
using ST_Datos;

namespace ST_Negocio
{
    public class n_Pedido
    {
        d_Pedido PedidoDAOB;

        public n_Pedido()
        {
            PedidoDAOB = new d_Pedido();
        }

        public string Ingresar_cons_ocs()
        {
            return PedidoDAOB.Ingresar_Cons_oc();
        }
        public List<e_Pedido> ListarPedidos()
        {
            return PedidoDAOB.ListaPedidos();
        }
        public List<e_Pedido> ListarPedidos_x_nropedido(int nro_pedido)
        {
            e_Pedido pedido = new e_Pedido()
            {
                Nro_Pedido = nro_pedido
            };
            return PedidoDAOB.ListaPedidos_x_nro_pedido(pedido);
        }
        public List<e_Pedido> ListarPedidos_x_cliente(string cliente)
        {
            e_Pedido pedido = new e_Pedido()
            {
                Cliente = cliente
            };
            return PedidoDAOB.ListaPedidos_x_cliente(pedido);
        }

        public List<e_Pedido> ListarPedidos_x_fechaped(string fecha)
        {
            e_Pedido pedido = new e_Pedido()
            {
                Fecha_pedido = fecha
            };
            return PedidoDAOB.ListaPedidos_x_fecha(pedido);
        }
        public List<e_Pedido> ListarPedidos_x_nrodoc(string nro_doc)
        {
            e_Pedido pedido = new e_Pedido()
            {
                Nro_Doc = nro_doc
            };
            return PedidoDAOB.ListaPedidos_x_nrodoc(pedido);
        }
        public List<e_Pedido> Lista_Ultimo_pedido()
        {
            return PedidoDAOB.Get_last_pedido();
        }
        public string RegistrarPedido(int Nro_Pedido, string Fecha_pedido, string Canal, string MiniCod, string Producto,
            int Cantidad, string Moneda, string Precio_Unit_S_IGV, string Cliente, string Direccion, string Tipo_Doc,
            string Nro_Doc, string Fecha_Despacho, string Subtotal_S_IGV, int n_item,double Costo_Envio)
        {
            e_Pedido pedido = new e_Pedido()
            {
                Nro_Pedido = Nro_Pedido,
                Fecha_pedido = Fecha_pedido,
                Canal = Canal,
                MiniCod = MiniCod,
                Producto = Producto,
                Cantidad = Cantidad,
                Moneda = Moneda,
                Precio_Unit_S_IGV = Precio_Unit_S_IGV,
                Cliente = Cliente,
                Direccion = Direccion,
                Tipo_Doc = Tipo_Doc,
                Nro_Doc = Nro_Doc,
                Fecha_Despacho = Fecha_Despacho,
                Subtotal_S_IGV = Subtotal_S_IGV,
                N_Item = n_item,
                Costo_envio = Costo_Envio
            };
            return PedidoDAOB.IngresarPedido(pedido);

        }

        public string IngresarCons()
        {
            return PedidoDAOB.Ingresar_Cons();
        }

        public string ModificarCons(string Canal, string MiniCod, string Producto, int Cantidad, string Moneda, string Precio_Unit_S_IGV,
                    string Cliente, string Direccion, string Tipo_Doc, string Nro_Doc, int Id_Pedido,double Costo_Envio)
        {
            e_Pedido pedido = new e_Pedido()
            {
                Canal = Canal,
                MiniCod = MiniCod,
                Producto = Producto,
                Cantidad = Cantidad,
                Moneda = Moneda,
                Precio_Unit_S_IGV = Precio_Unit_S_IGV,
                Cliente = Cliente,
                Direccion = Direccion,
                Tipo_Doc = Tipo_Doc,
                Nro_Doc = Nro_Doc,
                Id_Pedido = Id_Pedido,
                //N_Item = n_item
                Costo_envio = Costo_Envio
            };
            return PedidoDAOB.Modificar_Cons(pedido);
        }

        public List<e_Pedido> get_last_n_item(int n_pedido)
        {
            e_Pedido pedido = new e_Pedido()
            {
                Nro_Pedido = n_pedido
            };
            return PedidoDAOB.Get_last_nitem(pedido);
        }
        public List<e_ProductosxPedido> ProductosxPedido(string nro)
        {
            return PedidoDAOB.Productos_x_nro_pedido(nro);
        }
    }
}
