using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ST_Datos;
using ST_Negocio;
using ST_Entidades;

namespace ST_FORMS
{
    /// <summary>
    /// Interaction logic for frm_Pedidos.xaml
    /// </summary>
    public partial class frm_Pedidos : Window
    {
        n_Pedido pedidoOBJ = new n_Pedido();
        private n_Buscaminis obj_minis = new n_Buscaminis();
        private n_Buscaminis obj_minis2 = new n_Buscaminis();

        e_Buscaminis mini = null;
        e_Buscaminis mini2 = null;

        e_Pedido ped;
        e_Pedido ped_2;
        int ultimo_ped;
        int ultimo_item;
        int id_ped;
        int n_ped;
        public frm_Pedidos()
        {
            InitializeComponent();
            Listar_Pedidos();
            Fill_Combox();
            Lista_ultimo_pedido();
            Obtener_ult_pedido();
            Mostrar_cambio();
            dtPedido.SelectedDate = DateTime.Now;
            dtDespacho.SelectedDate = DateTime.Now;
            checkBox.IsChecked = true;

        }
        //Funcion para mostrar el cambio de dolares del dia
        private void Mostrar_cambio()
        {
            n_TipoCambio n_TipoCambio = new n_TipoCambio();
            txtCambio.Text = n_TipoCambio.MostrarCambio(DateTime.Now.ToString("yyyy-MM-dd"));

        }
        private void Listar_prod()
        {
            dtgProductos.ItemsSource = obj_minis.ListaMinis(txtMinicod.Text);
        }
        private void Fill_Combox()
        {
            cmbCanal.Items.Add("OFICINA FACEBOOK");
            cmbCanal.Items.Add("OFICINA HONORIO");
            cmbCanal.Items.Add("OFICINA WEB");
            cmbCanal.Items.Add("OFICINA WHATSAPP");
            cmbCanal.Items.Add("DINNERS");
            cmbCanal.Items.Add("COOLBOX");

            cmbTipoDoc.Items.Add("DNI");
            cmbTipoDoc.Items.Add("RUC");
            cmbTipoDoc.Items.Add("CARNET");

            cmbMoneda.Items.Add("PEN");
            cmbMoneda.Items.Add("USD");

            cmbcriterio.Items.Add("FECHA PEDIDO");
            cmbcriterio.Items.Add("NRO PEDIDO");
            cmbcriterio.Items.Add("CLIENTE");
            cmbcriterio.Items.Add("NRO DOCUMENTO");

            cmbTipoCosto.Items.Add("PEN");
            cmbTipoCosto.Items.Add("USD");
        }
        private void Lista_ultimo_pedido()
        {
            dtgUltPD.ItemsSource = pedidoOBJ.Lista_Ultimo_pedido();
        }
        private void Listar_Pedidos()
        {
            dtgPedidos.ItemsSource= pedidoOBJ.ListarPedidos();
        }


        private void button_Click_1(object sender, RoutedEventArgs e)
        {

            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (txtlast.Text != "" && txtMinicod.Text != "" && txtCantidad.Text != "" && cmbCanal.Text != "" && txtPrecio.Text != "")
            {
                MessageBox.Show(pedidoOBJ.ModificarCons(cmbCanal.Text,txtMinicod.Text,txtProducto.Text,Convert.ToInt32(txtCantidad.Text),
                   cmbMoneda.Text,txtPrecio.Text,txtCliente.Text,txtDireccion.Text,cmbTipoDoc.Text,txtNDoc.Text,id_ped,Convert.ToDouble(txtCostoEnv.Text)));
                Listar_Pedidos();
              
            }
        }

        private void btn_Limp_Click(object sender, RoutedEventArgs e)
        {
            txtCantidad.Text = "";
            //txtCliente.Text = "";
            //txtDireccion.Text = "";
            //txtlast.Text = "";
            txtMinicod.Text = "";
            //txtNDoc.Text = "";
            txtPrecio.Text = "";
            txtProducto.Text = "";
            //cmbCanal.Text = "";
            //cmbMoneda.Text = "";
            //cmbTipoDoc.Text = "";
            //dtDespacho.Text = "";
            //dtPedido.Text = "";
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if(txtlast.Text != "" && txtMinicod.Text != "" && txtCantidad.Text != "" && cmbCanal.Text != "" && txtPrecio.Text != "")
            {
                n_ped++;
                MessageBox.Show(pedidoOBJ.RegistrarPedido(Convert.ToInt32(txtlast.Text), dtPedido.Text, cmbCanal.Text, txtMinicod.Text,
                    txtProducto.Text, Convert.ToInt32(txtCantidad.Text), cmbMoneda.Text, Convert.ToString(Convert.ToDouble(txtPrecio.Text)/1.18), txtCliente.Text, txtDireccion.Text,
                    cmbTipoDoc.Text, txtNDoc.Text, dtDespacho.Text, "0", Convert.ToInt32(textBox.Text),Convert.ToDouble(txtCostoEnv.Text)));
                pedidoOBJ.IngresarCons();
                Listar_Pedidos();
                pedidoOBJ.Ingresar_cons_ocs();
                txtProducto.Text = "";
                txtMinicod.Text = "";
                txtPrecio.Text = "";
                txtCantidad.Text = "";
            }
            if (txtlast.Text != "")
            {
                dtg_item.ItemsSource = pedidoOBJ.get_last_n_item(Convert.ToInt32(txtlast.Text));
                dtg_item.SelectAllCells();
            }

        }

        private void buttonnvo_Click(object sender, RoutedEventArgs e)
        {
            n_ped = 0;
            Lista_ultimo_pedido();
            dtgUltPD.SelectAllCells();

            txtCantidad.Text = "";
            txtCliente.Text = "";
            txtDireccion.Text = "";
            //txtlast.Text = "";
            txtMinicod.Text = "";
            txtNDoc.Text = "";
            txtPrecio.Text = "";
            txtProducto.Text = "";
            cmbCanal.Text = "";
            cmbMoneda.Text = "";
            cmbTipoDoc.Text = "";
            dtDespacho.Text = "";
            dtPedido.Text = "";
        }
        private void Obtener_ult_pedido()
        {
            

        }
        private void dtgUltPD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            ped = dtgUltPD.SelectedItem as e_Pedido;
            if (ped != null)
            {
                ultimo_ped = ped.Nro_Pedido + 1;
                txtlast.Text = Convert.ToString(ultimo_ped);
            }
            
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtlast.Text != "")
            {
                dtg_item.ItemsSource = pedidoOBJ.get_last_n_item(Convert.ToInt32(txtlast.Text));
                dtg_item.SelectAllCells();
            }
         
        }

        private void dtgPedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbl_mode.Opacity == 0.99)
            {
                ped = dtgPedidos.SelectedItem as e_Pedido;
                if (ped != null)
                {
                    id_ped = ped.Id_Pedido;
                    txtCantidad.Text = Convert.ToString(ped.Cantidad);
                    txtCliente.Text = ped.Cliente;
                    txtDireccion.Text = ped.Direccion;
                    txtlast.Text = Convert.ToString(ped.Nro_Pedido);
                    txtMinicod.Text = ped.MiniCod;
                    txtNDoc.Text = ped.Nro_Doc;
                    txtPrecio.Text = ped.Precio_Unit_S_IGV;
                    txtProducto.Text = ped.Producto;
                    cmbCanal.Text = ped.Canal;
                    cmbMoneda.Text = ped.Moneda;
                    cmbTipoDoc.Text = ped.Tipo_Doc;
                    dtDespacho.Text = ped.Fecha_Despacho;
                    dtPedido.Text = ped.Fecha_pedido;
                }
            } else
            {
                //Rellena los datos para agregar otro producto a un pedido antiguo
                ped = dtgPedidos.SelectedItem as e_Pedido;
                if (ped != null)
                {
                    id_ped = ped.Id_Pedido;
                    txtCliente.Text = ped.Cliente;
                    txtDireccion.Text = ped.Direccion;
                    txtlast.Text = Convert.ToString(ped.Nro_Pedido);
                    txtNDoc.Text = ped.Nro_Doc;
                    cmbCanal.Text = ped.Canal;
                    cmbTipoDoc.Text = ped.Tipo_Doc;
                    dtDespacho.Text = ped.Fecha_Despacho;
                    dtPedido.Text = ped.Fecha_pedido; 
                    if (Convert.ToString(ped.Tipo_Doc) =="DNI") {
                        cmbTipoDoc.SelectedIndex = 0;
                    }
                    else if (Convert.ToString(ped.Tipo_Doc) == "RUC") {
                        cmbTipoDoc.SelectedIndex = 1;
                    }else
                    {
                        cmbTipoDoc.SelectedIndex = 2;
                    }
                }
            }
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            if (lbl_mode.Opacity == 0.99)
            {
                lbl_mode.Content = "Modo Edición : OFF";
                lbl_mode.Opacity = 1.0;
                lbl_mode.Background = Brushes.OrangeRed;
                btn_Ingresar.IsEnabled = true;
                btn_Mod.IsEnabled = false;

            }
            else
            {
                lbl_mode.Content = "Modo Edición : ON";
                lbl_mode.Opacity = 0.99;
                lbl_mode.Background = Brushes.GreenYellow;
                btn_Ingresar.IsEnabled = false;
                btn_Mod.IsEnabled = true;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Listar_Pedidos();
        }

        private void txtMinicod_TextChanged(object sender, TextChangedEventArgs e)
        {
            Listar_prod();
        }

        private void dtgProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mini = dtgProductos.SelectedItem as e_Buscaminis;
            e_Buscaminis busca = dtgProductos.SelectedItem as e_Buscaminis;
            if (mini != null)
            {
                try
                {
                    txtProducto.Text = mini.Producto;
                    //Dvide la respuesta en arrays
                    string precioSinP = obj_minis.Mostrar_Precio(busca.Mini_Codigo);
                    string[] preciosConS = precioSinP.Split('|');
                    string[] SolesSinS = preciosConS[0].Split(":");
                    string[] DolaresSinS = preciosConS[1].Split(":");
                    //recoge los precios
                    double precioD = Convert.ToDouble(DolaresSinS[1]);
                    double precioS = Convert.ToDouble(SolesSinS[1]);

                    int tip = Convert.ToInt32(cmbTipoCosto.SelectedIndex);
                    //verifica el tipo de moneda para mostrarla
                    if (tip == 0)
                    {
                        txt_precio.Text = SolesSinS[1];
                    }
                    else
                    {
                        txt_precio.Text = DolaresSinS[1];
                    }

                    //añade 3 decimales al tipo de cambio
                    double cambio = Convert.ToDouble(txtCambio.Text) + 0.03;
                    List<e_precios> precios = new List<e_precios>();

                    //Crea las filas de la tabla calculo
                    for (int i = 0; i <= 4; i++)
                    {
                        e_precios precio = new e_precios();
                        if (i == 0)
                        {
                            precio.porcentaje = "COSTOS S IGV";
                            precio.Soles = Convert.ToString(Math.Round(precioS, 2));
                            precio.Dolar_A_Sol = Convert.ToString(Math.Round(precioD * cambio, 2));
                            precio.Dolar = Convert.ToString(Math.Round(precioD, 2));
                        }
                        else if (i == 1)
                        {
                            precio.porcentaje = "10%";
                            precio.Soles = Convert.ToString(Math.Round(precioS * 1.18 * 1.10, 2));
                            precio.Dolar_A_Sol = Convert.ToString(Math.Round(precioD * cambio * 1.18 * 1.10, 2));
                            precio.Dolar = Convert.ToString(Math.Round(precioD * 1.18 * 1.10, 2));
                        }
                        else if (i == 2)
                        {
                            precio.porcentaje = "20%";
                            precio.Soles = Convert.ToString(Math.Round(precioS * 1.18 * 1.20, 2));
                            precio.Dolar_A_Sol = Convert.ToString(Math.Round(precioD * cambio * 1.18 * 1.20, 2));
                            precio.Dolar = Convert.ToString(Math.Round(precioD * 1.18 * 1.20, 2));
                        }
                        else if (i == 3)
                        {
                            precio.porcentaje = "30%";
                            precio.Soles = Convert.ToString(Math.Round(precioS * 1.18 * 1.30, 2));
                            precio.Dolar_A_Sol = Convert.ToString(Math.Round(precioD * cambio * 1.18 * 1.30, 2));
                            precio.Dolar = Convert.ToString(Math.Round(precioD * 1.18 * 1.30, 2));
                        }
                        else if (i == 4)
                        {
                            precio.porcentaje = "40%";
                            precio.Soles = Convert.ToString(Math.Round(precioS * 1.18 * 1.40, 2));
                            precio.Dolar_A_Sol = Convert.ToString(Math.Round(precioD * cambio * 1.18 * 1.40, 2));
                            precio.Dolar = Convert.ToString(Math.Round(precioD * 1.18 * 1.40, 2));
                        }
                        precios.Add(precio);
                    }
                    dtgCalculos.ItemsSource = precios;

                }
                catch
                {
                    txtPrecio.Text = "Problema con el precio";
                }
                if (busca.Stock<=0)
                {
                    MessageBox.Show("El stock del producto es 0!!!", "Advertencia!", MessageBoxButton.OK,MessageBoxImage.Exclamation);
                }
            }




        }

        private void cmbCanal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            dtgUltPD.SelectAllCells();

            if (textBox.Text == "")
            {
                textBox.Text = "1";
            }
        }

        private void txtProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            mini = dtgProductos.SelectedItem as e_Buscaminis;
            if (mini != null)
                txtMinicod.Text = mini.Mini_Codigo;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (cmbcriterio.SelectedIndex == 0)
            {
                dtgPedidos.ItemsSource = pedidoOBJ.ListarPedidos_x_fechaped(dtBusqueda.Text);
            }
            else if (cmbcriterio.SelectedIndex == 1)
            {
                dtgPedidos.ItemsSource= pedidoOBJ.ListarPedidos_x_nropedido(Convert.ToInt32(txtbusqueda.Text));
            }
            else if (cmbcriterio.SelectedIndex ==2)
            {
                dtgPedidos.ItemsSource = pedidoOBJ.ListarPedidos_x_cliente(txtbusqueda.Text);
            }
            else if (cmbcriterio.SelectedIndex ==3)
            {
                dtgPedidos.ItemsSource = pedidoOBJ.ListarPedidos_x_nrodoc(txtbusqueda.Text);
            }
        }

        private void txtbusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbcriterio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbcriterio.SelectedIndex == 0)
            {
                txtbusqueda.Visibility = Visibility.Hidden;
                dtBusqueda.Visibility = Visibility.Visible;

            }
            else
            {
                txtbusqueda.Visibility = Visibility.Visible;
                dtBusqueda.Visibility = Visibility.Hidden;
            }
        }

        private void dtg_item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ped_2 = dtg_item.SelectedItem as e_Pedido;
            if (ped_2 != null)
            {
                ultimo_item = ped_2.N_Item + 1;
                textBox.Text = Convert.ToString(ultimo_item);
            }
        }

        private void btn_Nuevo_Copy_Click(object sender, RoutedEventArgs e)
        {
            frm_Salidas frm = new frm_Salidas();
            this.Close();
            frm.ShowDialog();
        }

        private void txtPorcentaje_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //recoge los datos y convierte en decimal el porcentaje
                double number = Convert.ToDouble(txtPorcentaje.Text);
                double number2 = Convert.ToDouble(txt_precio.Text);
                number = number / 100;

                //realiza el calculo dependiendo de la moneda
                if (cmbTipoCosto.SelectedIndex == 0)
                {
                    double resultado = number2 * 1.18;
                    resultado = resultado + (resultado * number);
                    txtPrecio.Text = Convert.ToString(Math.Round(resultado, 2));
                }
                else
                {
                    double resultado = number2 * (Convert.ToDouble(txtCambio.Text) + 0.03);
                    resultado = resultado * 1.18;
                    resultado = resultado + (resultado * number);
                    txtPrecio.Text = Convert.ToString(Math.Round(resultado, 2));

                }

            }
            catch
            {
                txtPrecio.Text = "0";
            }
        }

        private void cmbTipoCosto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cambia el costo del producto por el seleccionado
            if (txt_precio.Text != "")
            {
                int index = cmbTipoCosto.SelectedIndex;
                e_precios precios = dtgCalculos.Items[0] as e_precios;
                if (index == 0)
                {
                    txt_precio.Text = precios.Soles.ToString();
                }
                else if (index == 1)
                {
                    txt_precio.Text = precios.Dolar.ToString();
                }
                else
                {
                    txt_precio.Text = "Index Fuera de alcanze";
                }
            }
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            //realiza el filtro
            string texto = txtProducto.Text;

            dtgProductos.ItemsSource = obj_minis.Lista_minicods(texto);
        }

        private void txtPorcentaje_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_BuscarDoc_Click(object sender, RoutedEventArgs e)
        {
            d_Api consulta = new d_Api();
            if (cmbTipoDoc.SelectedIndex == 1 && txtNDoc.Text.Length == 11)
            {
                dynamic respuesta = consulta.Get("https://api.apis.net.pe/v1/ruc?numero=", txtNDoc.Text);
                if (respuesta != null)
                {
                    txtCliente.Text = respuesta.nombre;
                    txtDireccion.Text = respuesta.direccion + " " + respuesta.despartamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                }
            }
            else if (cmbTipoDoc.SelectedIndex == 0 && txtNDoc.Text.Length == 8)
            {
                dynamic respuesta = consulta.Get("https://api.apis.net.pe/v1/dni?numero=", txtNDoc.Text);
                if (respuesta != null)
                {
                    txtCliente.Text = respuesta.nombre;
                    txtDireccion.Text = respuesta.direccion + " " + respuesta.despartamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                }
            }
            else
            {
                MessageBox.Show("NUMERO INGRESADO NO VALIDO", "ERROR DE USUARIO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    }

