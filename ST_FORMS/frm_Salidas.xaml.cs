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
using ST_Negocio;
using ST_Entidades;

namespace ST_FORMS
{
    /// <summary>
    /// Interaction logic for frm_Salidas.xaml
    /// </summary>
    public partial class frm_Salidas : Window
    {
        n_Salida SalidaOBJ = new n_Salida();
        n_Buscaminis MinisOBJ = new n_Buscaminis();
        n_Pedido PedidoOBJ = new n_Pedido();
        e_Buscaminis mini = null;
        e_Salida last = null;
        e_Pedido ped = null;
        private n_TipoCambio obj_TipoCambio = new n_TipoCambio();
        e_Salida salida = null;
        int id_salida;

        public frm_Salidas()
        {
            InitializeComponent();
            Listar_salidas();
            Fill_combobox();
            Get_last_orden();
        }
        public void Fill_productos()
        {
            dtgProductos.ItemsSource = MinisOBJ.ListaMinis(txtMinicod.Text);
        }
        public void Get_last_orden()
        {
            dtgLast.ItemsSource= SalidaOBJ.Listaultorden();
        }
        public void Fill_combobox()
        {
            cmbBanco.Items.Add("BBVA");
            cmbBanco.Items.Add("BCP");
            cmbBanco.Items.Add("INTERBANK");
            cmbBanco.Items.Add("SCOTIABANK");

            cmbTipo.Items.Add("VENTA");
            cmbTipo.Items.Add("VENTA C/NRO DE PEDIDO");
            cmbTipo.Items.Add("DATOS MERCADO_LIBRE");
            cmbTipo.Items.Add("DATOS CATPHONE");
            cmbTipo.Items.Add("TRASLADO");
            cmbTipo.Items.Add("GARANTIA");
            cmbTipo.Items.Add("USO PERSONAL");
            cmbTipo.Items.Add("USO OFICINAS");

            cmbResponsable.Items.Add("L.MEJIAS");
            cmbResponsable.Items.Add("A.MIRANDA");
            cmbResponsable.Items.Add("Y.LEAL");
            cmbResponsable.Items.Add("F.PEDROZA");
            cmbResponsable.Items.Add("USER 1");
            cmbResponsable.Items.Add("USER 2");
            cmbResponsable.Items.Add("USER 3");
            cmbResponsable.Items.Add("USER 4");

            cmbCanal.Items.Add("RIPLEY");
            cmbCanal.Items.Add("SAGA FALABELLA");
            cmbCanal.Items.Add("LINIO");
            cmbCanal.Items.Add("REAL PLAZA GO");
            cmbCanal.Items.Add("JUNTOZ");
            cmbCanal.Items.Add("LUMINGO");
            cmbCanal.Items.Add("MERCADO LIBRE");
            cmbCanal.Items.Add("OFICINA");

            cmbMoneda.Items.Add("USD");
            cmbMoneda.Items.Add("PEN");

            cmbCourier.Items.Add("FRANK DELIVERY");
            cmbCourier.Items.Add("PEDROZA DELIVERY");

            cmbOrigen.Items.Add("ALMACEN HONORIO");

            cmbPago.Items.Add("EFECTIVO");
            cmbPago.Items.Add("AL CONTADO");
            cmbPago.Items.Add("TRANSFERENCIA");
            cmbPago.Items.Add("YAPE");
            cmbPago.Items.Add("MERCADO PAGO");
            cmbPago.Items.Add("IZIPAY");

            cmbTipoDoc.Items.Add("DNI");
            cmbTipoDoc.Items.Add("RUC");
            cmbTipoDoc.Items.Add("CARNET");

        }
        public void Listar_salidas()
        {
            dtgSalidas.ItemsSource = SalidaOBJ.ListaSalidas();
            lbl_cant_salidas.Content = Convert.ToString(dtgSalidas.Items.Count - 1);
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox14_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime fechafact = Convert.ToDateTime(DateTime.Now);
                string tc = obj_TipoCambio.MostrarCambio(fechafact.ToString("yyyy-MM-dd"));

                if (cmbTipo.Text != "" && cmbResponsable.Text != "" && txtDestino.Text != "" && dtSalida.Text != "" && chkIGV.IsChecked == true && txtMinicod.Text != "" && txtMinicod.Text != "" && txtPrecio.Text != "")
                {
                    if (cmbTipo.SelectedIndex == 1)
                    {
                        MessageBox.Show(SalidaOBJ.Registrar_salida(cmbTipo.Text, txtNOrden.Text, dtSalida.Text, cmbResponsable.Text, null, null, null, cmbCanal.Text,
                       txtMinicod.Text, cmbPago.Text, cmbBanco.Text, txtNOperacion.Text, txtCantidad.Text, cmbMoneda.Text, Convert.ToString(Convert.ToDouble(txtPrecio.Text) / 1.18),
                       cmbOrigen.Text, txtDestino.Text,
                       txtObservaciones.Text, txtCliente.Text, txtNDoc.Text, txtTelefono.Text, cmbCourier.Text, txtDistancia.Text, txtSTECH.Text, txtMoto.Text,
                       txtOlva.Text, txtOnline.Text, txtTransferencia.Text, txtEfectivo.Text, txtNroPedido.Text));
                        SalidaOBJ.Ingresar_cons();
                        MessageBox.Show(SalidaOBJ.Actualiza_Kardex(lblPartnumb.Content.ToString(), Convert.ToDateTime(dtSalida.Text), Convert.ToDouble(tc), cmbMoneda.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text),
                        txtNOrden.Text, cmbTipo.Text));
                        Listar_salidas();
                        Get_last_orden();
                        dtgLast.UnselectAllCells();

                        txtMinicod.Text = "";
                        txtPrecio.Text = "";
                        txtProducto.Text = "";
                        txtCantidad.Text = "";
                        txtNroPedido.Text = "";

                    }
                    else
                    {

                        MessageBox.Show(SalidaOBJ.Registrar_salida(cmbTipo.Text, txtNOrden.Text, dtSalida.Text, cmbResponsable.Text, null, null, null, cmbCanal.Text,
                      txtMinicod.Text, cmbPago.Text, cmbBanco.Text, txtNOperacion.Text, txtCantidad.Text, cmbMoneda.Text, Convert.ToString(Convert.ToDouble(txtPrecio.Text) / 1.18),
                      cmbOrigen.Text, txtDestino.Text,
                      txtObservaciones.Text, txtCliente.Text, txtNDoc.Text, txtTelefono.Text, cmbCourier.Text, txtDistancia.Text, txtSTECH.Text, txtMoto.Text,
                      txtOlva.Text, txtOnline.Text, txtTransferencia.Text, txtEfectivo.Text, txtNroPedido.Text));
                        SalidaOBJ.Ingresar_cons();
                        if (cmbTipo.SelectedIndex == 5)
                        {
                            MessageBox.Show(SalidaOBJ.Actualiza_Kardex(lblPartnumb.Content.ToString(), Convert.ToDateTime(dtSalida.Text), Convert.ToDouble(tc), cmbMoneda.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text),
                            txtNOrden.Text, cmbTipo.Text, 0));
                        }
                        else
                        {
                            MessageBox.Show(SalidaOBJ.Actualiza_Kardex(lblPartnumb.Content.ToString(), Convert.ToDateTime(dtSalida.Text), Convert.ToDouble(tc), cmbMoneda.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text),
                            txtNOrden.Text, cmbTipo.Text));
                        }
                        
                        Listar_salidas();
                        Get_last_orden();
                    }

                }
                else if (cmbTipo.Text != "" && cmbResponsable.Text != "" && txtDestino.Text != "" && dtSalida.Text != "" && chkIGV.IsChecked == false && txtMinicod.Text != "")
                {
                    if (cmbTipo.SelectedIndex == 1)
                    {
                        MessageBox.Show(SalidaOBJ.Registrar_salida(cmbTipo.Text, txtNOrden.Text, dtSalida.Text, cmbResponsable.Text, null, null, null, cmbCanal.Text,
                       txtMinicod.Text, cmbPago.Text, cmbBanco.Text, txtNOperacion.Text, txtCantidad.Text, cmbMoneda.Text, txtPrecio.Text,
                       cmbOrigen.Text, txtDestino.Text,
                       txtObservaciones.Text, txtCliente.Text, txtNDoc.Text, txtTelefono.Text, cmbCourier.Text, txtDistancia.Text, txtSTECH.Text, txtMoto.Text,
                       txtOlva.Text, txtOnline.Text, txtTransferencia.Text, txtEfectivo.Text, txtNroPedido.Text));
                        SalidaOBJ.Ingresar_cons();
                        MessageBox.Show(SalidaOBJ.Actualiza_Kardex(lblPartnumb.Content.ToString(), Convert.ToDateTime(dtSalida.Text), Convert.ToDouble(tc), cmbMoneda.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text),
                        txtNOrden.Text, cmbTipo.Text));
                        Listar_salidas();
                        Get_last_orden();
                        dtgLast.UnselectAllCells();

                        txtMinicod.Text = "";
                        txtPrecio.Text = "";
                        txtProducto.Text = "";
                        txtCantidad.Text = "";
                        txtNroPedido.Text = "";

                    }
                    else
                    {
                        MessageBox.Show(SalidaOBJ.Registrar_salida(cmbTipo.Text, txtNOrden.Text, dtSalida.Text, cmbResponsable.Text, null, null, null, cmbCanal.Text,
                      txtMinicod.Text, cmbPago.Text, cmbBanco.Text, txtNOperacion.Text, txtCantidad.Text, cmbMoneda.Text, txtPrecio.Text,
                      cmbOrigen.Text, txtDestino.Text,
                      txtObservaciones.Text, txtCliente.Text, txtNDoc.Text, txtTelefono.Text, cmbCourier.Text, txtDistancia.Text, txtSTECH.Text, txtMoto.Text,
                      txtOlva.Text, txtOnline.Text, txtTransferencia.Text, txtEfectivo.Text, txtNroPedido.Text));
                        SalidaOBJ.Ingresar_cons();
                        Listar_salidas();
                        Get_last_orden();
                        if (cmbTipo.SelectedIndex == 5)
                        {
                            MessageBox.Show(SalidaOBJ.Actualiza_Kardex(lblPartnumb.Content.ToString(), Convert.ToDateTime(dtSalida.Text), Convert.ToDouble(tc), cmbMoneda.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text),
                                txtNOrden.Text, cmbTipo.Text, 0));
                        }
                        else
                        {
                            MessageBox.Show(SalidaOBJ.Actualiza_Kardex(lblPartnumb.Content.ToString(), Convert.ToDateTime(dtSalida.Text), Convert.ToDouble(tc), cmbMoneda.Text, Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPrecio.Text),
                                txtNOrden.Text, cmbTipo.Text));
                        }
                        txtMinicod.Text = "";
                        txtPrecio.Text = "";
                        txtProducto.Text = "";
                        txtCantidad.Text = "";
                        txtObservaciones.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Por favor completar los campos restantes");
                }
            }
            catch(Exception er)
            {
                MessageBox.Show("Error en el formulario: "+er.Message+" en: "+er.Source+ " Detalles: "+er.StackTrace);
            }
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTipo.Text != "" && cmbResponsable.Text != "" && txtDestino.Text != "" )
            {
                MessageBox.Show(SalidaOBJ.Modificar_salida(cmbTipo.Text, txtNOrden.Text, cmbResponsable.Text, null, null, null, cmbCanal.Text,
                  txtMinicod.Text, cmbPago.Text, cmbBanco.Text, txtNOperacion.Text, txtCantidad.Text, cmbMoneda.Text, txtPrecio.Text,
                  cmbOrigen.Text, txtDestino.Text,
                  txtObservaciones.Text, txtCliente.Text, txtNDoc.Text, txtTelefono.Text, cmbCourier.Text, txtDistancia.Text, txtSTECH.Text, txtMoto.Text,
                  txtOlva.Text, txtOnline.Text, txtTransferencia.Text, txtEfectivo.Text, txtNroPedido.Text,id_salida));
                //SalidaOBJ.Ingresar_cons();
                Listar_salidas();
                //Get_last_orden();

            }
            
            else
            {
                MessageBox.Show("Por favor completar los campos restantes");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            txtMinicod.Text = "";
            txtPrecio.Text = "";
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtObservaciones.Text = "";
        }

        private void buttonnvo_Click(object sender, RoutedEventArgs e)
        {
            txtCantidad.Text = "";
            txtCliente.Text = "";
            txtDestino.Text = "";
            txtDistancia.Text = "";
            txtEfectivo.Text = "";
            txtMinicod.Text = "";
            txtMoto.Text = "";
            txtNDoc.Text = "";
            txtNOperacion.Text = "";
            txtNOrden.Text = "";
            txtNroPedido.Text = "";
            txtObservaciones.Text = "";
            txtOlva.Text = "";
            txtOnline.Text = "";
            txtPrecio.Text = "";
            txtProducto.Text = "";
            txtSTECH.Text = "";
            txtTelefono.Text = "";
            txtTransferencia.Text = "";
            cmbBanco.Text = "";
            cmbCanal.Text = "";
            cmbCourier.Text = "";
            cmbMoneda.Text = "";
            cmbOrigen.Text = "";
            cmbPago.Text = "";
            cmbResponsable.Text = "";
            cmbTipo.Text = "";
            cmbTipoDoc.Text = "";
           
        }

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipo.SelectedIndex == 1)
            {
                txtNOrden.IsEnabled = false;
                dtgLast.SelectAllCells();
            }
            else if (cmbTipo.SelectedIndex == 4)
            {
                txtNOrden.IsEnabled = true;
                dtgLast.UnselectAllCells();
                txtNOrden.Text = SalidaOBJ.Ultima_Salida();
            }
            else
            { 
                txtNOrden.IsEnabled = true;
                dtgLast.UnselectAllCells();
                txtNOrden.Text = "";
            }
        }

        private void dtgLast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            last = dtgLast.SelectedItem as e_Salida;

            if (last != null)
            {
                txtNOrden.Text =  last.NRO_ORDEN;
             
            }
        }

        private void txtNroPedido_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbTipo.SelectedIndex == 1)
            { 
                dtgLast.SelectAllCells();
            }
        }

        private void dtgProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mini = dtgProductos.SelectedItem as e_Buscaminis;
            if(mini != null)
            {
                //txtMinicod.Text = mini.Mini_Codigo;
                txtProducto.Text = mini.Producto;
                //
            }
        }

        private void txtMinicod_TextChanged(object sender, TextChangedEventArgs e)
        {
            Fill_productos();
        }

        private void txtProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (mini != null)
            {
                lblPartnumb.Content = mini.Partnumber;
                txtMinicod.Text = mini.Mini_Codigo;
            }
        }

        private void chkCostoEnvio_Checked(object sender, RoutedEventArgs e)
        {
            if (chkCostoEnvio.IsChecked==true)
            {
                txtProducto.Text = "Costo de envio";
                txtMinicod.Text = "AACSTOENVC#20211023";
            }
            else
            {
                txtProducto.Text = "";
                txtMinicod.Text = "";
            }
        
        }

        private void btnPedido_Click(object sender, RoutedEventArgs e)
        {
            Panelpedidos.Visibility = Visibility.Visible;
            dtg_pedidos.ItemsSource = PedidoOBJ.ListarPedidos();
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            Panelpedidos.Visibility = Visibility.Hidden;
        }

        private void dtg_pedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ped = dtg_pedidos.SelectedItem as e_Pedido;

            if(ped!= null)
            {
                txtNroPedido.Text = Convert.ToString(ped.Nro_Pedido);
                string moneda = Convert.ToString(ped.Moneda);
                if (moneda == "USD")
                {
                    cmbMoneda.SelectedIndex = 0;
                }
                else
                {
                    cmbMoneda.SelectedIndex = 1;
                }
                txtCliente.Text = Convert.ToString(ped.Cliente);
                txtNDoc.Text = Convert.ToString(ped.Nro_Doc);
                string Tdoc = Convert.ToString(ped.Tipo_Doc);
                if (Tdoc == "DNI")
                {
                    cmbTipoDoc.SelectedIndex = 0;
                }
                else if (Tdoc == "RUC")
                {
                    cmbTipoDoc.SelectedIndex = 1;
                }
                else
                {
                    cmbTipoDoc.SelectedIndex = 2;
                }
                txtMinicod.Text = Convert.ToString(ped.MiniCod);
                txtProducto.Text = Convert.ToString(ped.Producto);
                txtCantidad.Text = Convert.ToString(ped.Cantidad);
                txtPrecio.Text = Convert.ToString(ped.Precio_Unit_S_IGV);
                txtDestino.Text = Convert.ToString(ped.Direccion);
                lblPartnumb.Content = MinisOBJ.Mostrar_Partnumb( Convert.ToString(ped.MiniCod));
                Panelpedidos.Visibility = Visibility.Hidden;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Listar_salidas();

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

        private void btn_Limp_Copy_Click(object sender, RoutedEventArgs e)
        {
            dtgSalidas.ItemsSource = SalidaOBJ.ListaSalidasxFILTRO(txt_search_tipo.Text, txt_search_oc.Text, txt_search_canal.Text, txt_search_mini.Text, dt_search_fecha.Text, txtsearch_pedido.Text);
            lbl_cant_salidas.Content = Convert.ToString(dtgSalidas.Items.Count-1);
        }

        private void btn_Limp_Copy1_Click(object sender, RoutedEventArgs e)
        {

            txt_search_tipo.Text = "";  
            txt_search_oc.Text= "";
            txt_search_canal.Text= ""; 
            txt_search_mini.Text= ""; 
            dt_search_fecha.Text= "";
            txtsearch_pedido.Text = "";
            lbl_cant_salidas.Content = Convert.ToString(dtgSalidas.Items.Count - 1);
        }

        private void dtgSalidas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbl_mode.Opacity == 0.99)
            {
                salida = dtgSalidas.SelectedItem as e_Salida;
                if (salida != null)
                {
                    id_salida = salida.ID_SALIDA;
                    txtCantidad.Text = salida.CANTIDAD;
                    txtCliente.Text = salida.NOM_CLI;
                    txtDestino.Text = salida.DIR_DESTINO;
                    txtDistancia.Text = salida.KM;
                    txtEfectivo.Text = salida.EFECTIVO;
                    txtMinicod.Text = salida.MINICODIGO;
                    txtMoto.Text = salida.TARIFA_DELIV;
                    txtNDoc.Text = salida.DNI_CLI;
                    txtNOperacion.Text = salida.NRO_OPERACION;
                    txtNOrden.Text = salida.NRO_ORDEN;
                    txtNroPedido.Text = salida.NRO_PEDIDO;
                    txtObservaciones.Text = salida.OBSERVACIONES;
                    txtOlva.Text = salida.TARIFA_OLVA;
                    txtOnline.Text = salida.PAGO_ONLINE;
                    txtPrecio.Text = salida.PRECIO_UNIT_S_IGV;
                    txtSTECH.Text = salida.TARIFA_ST;
                    txtTelefono.Text = salida.TEL_CLI;
                    txtTransferencia.Text = salida.TRANSFERENCIA;
                    cmbBanco.Text = salida.BANCO;
                    cmbCanal.Text = salida.CANAL;
                    cmbCourier.Text = salida.NOM_DELIV;
                    cmbMoneda.Text = salida.MONEDA;
                    cmbOrigen.Text = salida.ORIGEN;
                    cmbPago.Text = salida.TIPO_PAGO;
                    cmbResponsable.Text = salida.RESPONSABLE;
                    cmbTipo.Text = salida.TIPO;
                    cmbTipoDoc.Text = salida.TIPO_COMPROBANTE;

                }
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cmbResponsable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            //Filtra productos con palabras
            string texto = txtProducto.Text;

            dtgProductos.ItemsSource = MinisOBJ.Lista_minicods(texto);
        }
    }
}
