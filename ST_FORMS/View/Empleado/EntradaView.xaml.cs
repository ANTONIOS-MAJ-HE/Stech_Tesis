using ST_Entidades;
using ST_FORMS.ViewModel.Comunes;
using ST_Negocio;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST_FORMS.View.Empleado
{
    /// <summary>
    /// Lógica de interacción para EntradaView.xaml
    /// </summary>
    public partial class EntradaView : UserControl
    {
        private readonly MainViewModel _mainViewModel;

        private n_Entradas obj_entradas = new n_Entradas();
        private n_Buscaminis obj_minis = new n_Buscaminis();
        private n_TipoCambio obj_TipoCambio = new n_TipoCambio();

        e_Buscaminis mini = null;
        e_Entradas entrada = null;
        e_Proveedor prov = null;
        e_TotalFact fact = null;
        //string comprobante;
        public int unidades = 0;
        public double total;
        public double costo;

        int id_entrada;
        public EntradaView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            Muestra_entradas();
            Carga_cmb();
        }

        private void Listar_prod()
        {
            dtg_infoprod.ItemsSource = obj_minis.ListaMinis(txtMinicod.Text);
        }
        private void Carga_cmb()
        {
            cmbMoneda.Items.Add("PEN");
            cmbMoneda.Items.Add("USD");
            cmbResponsable.Items.Add("L.MEJIAS");
            cmbResponsable.Items.Add("Y.LEAL");
            cmbResponsable.Items.Add("A.MIRANDA");
            cmbResponsable.Items.Add("USER 1");
            cmbResponsable.Items.Add("USER 2");
            cmbResponsable.Items.Add("USER 3");
            cmbResponsable.Items.Add("USER 4");
            cmbTipo.Items.Add("DEVOLUCION");
            cmbTipo.Items.Add("COMPRA");
            cmbTipo.Items.Add("TRASLADO");
            cmbTipo.Items.Add("GARANTIA");
        }
        private void Limpia_todo()
        {
            txtCantidad.Text = "";
            txtMinicod.Text = "";
            txtNrofct.Text = "";
            txtObservaciones.Text = "";
            txtOrigen.Text = "";
            txtPreciounit.Text = "";
            txtProveedor.Text = "";
            txtRUC.Text = "";
            txtserie.Text = "";
            cmbMoneda.Text = "";
            cmbResponsable.Text = "";
            cmbTipo.Text = "";
            dtFact.Text = "";
            dtGuia.Text = "";
            dt_entrada.Text = "";
        }
        private void Nuevo_entr()
        {
            txtCantidad.Text = "";
            txtMinicod.Text = "";
            txtObservaciones.Text = "";
            txtPreciounit.Text = "";
        }
        private void Ingresa_Cons()
        {
            obj_entradas.Ingresa_Cons();
        }
        private void Muestra_entradas()
        {
            dtgEntradas.ItemsSource = obj_entradas.Lista_entradas();
            lblcant_entradas.Content = Convert.ToString(dtgEntradas.Items.Count - 1);
        }
        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            Listar_prod();
        }

        private void buttonnvo_Click(object sender, RoutedEventArgs e)
        {
            Limpia_todo();
            total = 0;
            unidades = 0;
            costo = 0;
            lblCmp.Content = "";
            lblCosto.Content = "";
            lblUnit.Content = "";

        }

        //private void button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    frm_Inicio frm = new frm_Inicio();
        //    this.Close();
        //    frm.ShowDialog();

        //}

        private void btn_Limp_Click(object sender, RoutedEventArgs e)
        {
            Nuevo_entr();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dt_entrada.Text != "" && txtMinicod.Text != "" && txtCantidad.Text != "")
                {
                    if (cbxIGV.IsChecked == true && cmbTipo.Text == "COMPRA" && txtPreciounit.Text != "" && cmbMoneda.Text != "" && dtFact.Text != "")
                    {
                        // costo = Convert.ToDouble(txtPreciounit.Text);
                        //costo = costo / 1.18;
                        //unidades = unidades + Convert.ToInt32(txtCantidad.Text);
                        //total = total + costo*unidades;
                        //total = Math.Truncate(total * 100) / 100;


                        MessageBox.Show(obj_entradas.Registra_Entradas(cmbTipo.Text, dt_entrada.Text, txtserie.Text, txtNrofct.Text, txtMinicod.Text,
                            Convert.ToInt32(txtCantidad.Text), cmbMoneda.Text, Convert.ToDecimal(Convert.ToDouble(txtPreciounit.Text) / 1.18), txtRUC.Text, txtProveedor.Text, txtOrigen.Text,
                            cmbResponsable.Text, txtObservaciones.Text, dtFact.Text, dtGuia.Text));
                        Ingresa_Cons();
                        DateTime fechafact = Convert.ToDateTime(dtFact.Text);
                        string tc = obj_TipoCambio.MostrarCambio(fechafact.ToString("yyyy-MM-dd"));
                        MessageBox.Show(obj_entradas.Actualiza_Kardex(lblPartnumb.Content.ToString(), Convert.ToDateTime(dtFact.Text), Convert.ToDouble(tc), cmbMoneda.Text,
                        Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPreciounit.Text) / 1.18, txtserie.Text, cmbTipo.Text, cmbTipo.SelectedIndex));
                        lblCmp.Content = txtserie.Text + " - " + txtNrofct.Text;
                        //lblCmp.Content = txtserie.Text + " - " + txtNrofct.Text;
                        //lblUnit.Content = Convert.ToString(unidades);
                        //lblCosto.Content = Convert.ToString(total) + " " +cmbMoneda.Text;
                    }
                    else if (cbxIGV.IsChecked != true && cmbTipo.Text == "COMPRA" && txtPreciounit.Text != "" && cmbMoneda.Text != "" && dtFact.Text != "")
                    {
                        //costo = Convert.ToDouble(txtPreciounit.Text);
                        //unidades = unidades + Convert.ToInt32(txtCantidad.Text);
                        //total = total + costo*unidades;
                        //total = Math.Truncate(total * 100) / 100;


                        MessageBox.Show(obj_entradas.Registra_Entradas(cmbTipo.Text, dt_entrada.Text, txtserie.Text, txtNrofct.Text, txtMinicod.Text,
                            Convert.ToInt32(txtCantidad.Text), cmbMoneda.Text, Convert.ToDecimal(txtPreciounit.Text), txtRUC.Text, txtProveedor.Text, txtOrigen.Text,
                            cmbResponsable.Text, txtObservaciones.Text, dtFact.Text, dtGuia.Text));
                        Ingresa_Cons();
                        DateTime fechafact = Convert.ToDateTime(dtFact.Text);
                        string tc = obj_TipoCambio.MostrarCambio(fechafact.ToString("yyyy-MM-dd"));
                        MessageBox.Show(obj_entradas.Actualiza_Kardex(lblPartnumb.Content.ToString(), Convert.ToDateTime(dtFact.Text), Convert.ToDouble(tc), cmbMoneda.Text,
                        Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPreciounit.Text), txtserie.Text, cmbTipo.Text, cmbTipo.SelectedIndex));
                        lblCmp.Content = txtserie.Text + " - " + txtNrofct.Text;
                        //lblCmp.Content = txtserie.Text + " - " + txtNrofct.Text;
                        //lblUnit.Content = Convert.ToString(unidades);
                        //lblCosto.Content= Convert.ToString(total) + " " +cmbMoneda.Text;;
                    }

                    else if (cbxIGV.IsChecked != true && cmbTipo.Text == "TRASLADO" && txtPreciounit.Text != "")
                    {
                        //costo = Convert.ToDouble(txtPreciounit.Text);
                        //unidades = unidades + Convert.ToInt32(txtCantidad.Text);
                        //total = total + costo * unidades;
                        //total = Math.Truncate(total * 100) / 100;


                        MessageBox.Show(obj_entradas.Registra_Entradas(cmbTipo.Text, dt_entrada.Text, txtserie.Text, txtNrofct.Text, txtMinicod.Text,
                            Convert.ToInt32(txtCantidad.Text), cmbMoneda.Text, Convert.ToDecimal(txtPreciounit.Text), txtRUC.Text, txtProveedor.Text, txtOrigen.Text,
                            cmbResponsable.Text, txtObservaciones.Text, dtFact.Text, dtGuia.Text));
                        Ingresa_Cons();
                        DateTime fechafact = Convert.ToDateTime(dtFact.Text);
                        string tc = obj_TipoCambio.MostrarCambio(fechafact.ToString("yyyy-MM-dd"));
                        MessageBox.Show(obj_entradas.Actualiza_Kardex(lblPartnumb.Content.ToString(), Convert.ToDateTime(dtFact.Text), Convert.ToDouble(tc), cmbMoneda.Text,
                        Convert.ToInt32(txtCantidad.Text), Convert.ToDouble(txtPreciounit.Text), txtserie.Text, cmbTipo.Text, cmbTipo.SelectedIndex));
                        //lblCmp.Content = txtserie.Text + " - " + txtNrofct.Text;
                        //lblUnit.Content = Convert.ToString(unidades);
                        //lblCosto.Content = Convert.ToString(total) + " " + cmbMoneda.Text; ;
                    }
                    else
                    {
                        MessageBox.Show("Por favor revisar COSTO / MONEDA");
                    }
                    dtgFact.ItemsSource = obj_entradas.Lista_total(txtserie.Text + "-" + txtNrofct.Text);
                    dtgFact.SelectAllCells();
                }
                else MessageBox.Show("Por favor revisar los campos restantes");
                Nuevo_entr();
                Muestra_entradas();
                obj_entradas.Actualizar_precios();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (dt_entrada.Text != "" && txtMinicod.Text != "" && txtCantidad.Text != "")
            {
                if (cbxIGV.IsChecked == true && cmbTipo.Text == "COMPRA" && txtPreciounit.Text != "" && cmbMoneda.Text != "")
                {
                    //costo = Convert.ToDouble(txtPreciounit.Text);
                    //costo = costo / 1.18;
                    //unidades = unidades + Convert.ToInt32(txtCantidad.Text);
                    //total = total + costo;
                    //total = Math.Truncate(total * 100) / 100;


                    MessageBox.Show(obj_entradas.Modifica_Cons(cmbTipo.Text, txtserie.Text, txtNrofct.Text, txtMinicod.Text,
                        Convert.ToInt32(txtCantidad.Text), cmbMoneda.Text, Convert.ToDecimal(Convert.ToDouble(txtPreciounit.Text) / 1.18), txtRUC.Text, txtProveedor.Text, txtOrigen.Text,
                        txtObservaciones.Text, id_entrada));
                    Nuevo_entr();
                    Muestra_entradas();

                    //lblCmp.Content = txtserie.Text + " - " + txtNrofct.Text;
                    //lblUnit.Content = Convert.ToString(unidades);
                    //lblCosto.Content = Convert.ToString(total) + " " + cmbMoneda.Text;
                }
                else if (cbxIGV.IsChecked != true && txtPreciounit.Text != "" && cmbMoneda.Text != "")
                {
                    //costo = Convert.ToDouble(txtPreciounit.Text);
                    //unidades = unidades + Convert.ToInt32(txtCantidad.Text);
                    //total = total + costo;
                    //total = Math.Truncate(total * 100) / 100;



                    MessageBox.Show(obj_entradas.Modifica_Cons(cmbTipo.Text, txtserie.Text, txtNrofct.Text, txtMinicod.Text,
                        Convert.ToInt32(txtCantidad.Text), cmbMoneda.Text, Convert.ToDecimal(txtPreciounit.Text), txtRUC.Text, txtProveedor.Text, txtOrigen.Text,
                        txtObservaciones.Text, id_entrada));
                    Nuevo_entr();
                    Muestra_entradas();
                    //lblCmp.Content = txtserie.Text + " - " + txtNrofct.Text;
                    //lblUnit.Content = Convert.ToString(unidades);
                    //lblCosto.Content = Convert.ToString(total) + " " + cmbMoneda.Text;
                }
                else
                {
                    MessageBox.Show("Por favor revisar COSTO / MONEDA");
                }
                dtgFact.ItemsSource = obj_entradas.Lista_total(txtserie.Text + "-" + txtNrofct.Text);
                dtgFact.SelectAllCells();
            }
            else MessageBox.Show("Por favor revisar los campos restantes");
            obj_entradas.Actualizar_precios();

        }

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipo.SelectedIndex == 2)
            {
                txtPreciounit.Text = "0.00";
                txtPreciounit.IsEnabled = false;
                txtNrofct.Text = obj_entradas.Ultima_Entrada();
            }
            else
            {
                txtPreciounit.Text = "";
                txtPreciounit.IsEnabled = true;
            }
        }

        private void dtg_infoprod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mini = dtg_infoprod.SelectedItem as e_Buscaminis;
            if (mini != null)
            {
                lblPartnumb.Content = mini.Partnumber;
                txtMinicod.Text = mini.Mini_Codigo;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Muestra_entradas();
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
                txtMinicod.IsEnabled = false;

            }
            else
            {
                lbl_mode.Content = "Modo Edición : ON";
                lbl_mode.Opacity = 0.99;
                lbl_mode.Background = Brushes.GreenYellow;
                btn_Ingresar.IsEnabled = false;
                btn_Mod.IsEnabled = true;
                txtMinicod.IsEnabled = true;
            }
        }

        private void dtgEntradas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbl_mode.Opacity == 0.99)
            {
                entrada = dtgEntradas.SelectedItem as e_Entradas;

                if (entrada != null)
                {
                    id_entrada = entrada.Id_Entrada;
                    txtCantidad.Text = Convert.ToString(entrada.Cantidad);
                    txtMinicod.Text = entrada.MiniCodigo;
                    txtNrofct.Text = entrada.Nro_Fact;
                    txtObservaciones.Text = entrada.Observaciones;
                    txtOrigen.Text = entrada.Origen;
                    txtPreciounit.Text = Convert.ToString(entrada.Precio_Unitario);
                    txtProveedor.Text = entrada.Proveedor;
                    txtRUC.Text = entrada.RUC_Proveedor;
                    txtserie.Text = entrada.Serie_Fact;
                    cmbMoneda.Text = entrada.Moneda;
                    cmbResponsable.Text = entrada.Responsable;
                    cmbTipo.Text = entrada.Tipo;
                    cbxIGV.IsChecked = false;
                    dtFact.Text = entrada.Fecha_factura;
                    dtGuia.Text = entrada.Fecha_guia;
                    dt_entrada.Text = entrada.Fecha_Entrada;
                    dtgFact.ItemsSource = obj_entradas.Lista_total(txtserie.Text + "-" + txtNrofct.Text);
                }
            }
            dtgFact.SelectAllCells();
        }

        private void btn_Limp_Copy_Click(object sender, RoutedEventArgs e)
        {
            dtgEntradas.ItemsSource = obj_entradas.Lista_entradas_filtro(txt_searchfactura.Text, txt_searchrucproveedor.Text, txt_searchproveedor.Text, txt_searchproducto.Text, txt_searchmarca.Text);
            lblcant_entradas.Content = Convert.ToString(dtgEntradas.Items.Count - 1);
        }

        private void btn_Limp_Copy1_Click(object sender, RoutedEventArgs e)
        {

            txt_searchfactura.Text = "";
            txt_searchrucproveedor.Text = "";
            txt_searchproveedor.Text = "";
            txt_searchproducto.Text = "";
            txt_searchmarca.Text = "";
            Muestra_entradas();
            lblcant_entradas.Content = Convert.ToString(dtgEntradas.Items.Count - 1);
        }

        private void btn_proveedores_Click(object sender, RoutedEventArgs e)
        {
            dtg_prov.ItemsSource = obj_entradas.Lista_proveedores(txtsearch_prov.Text);
            Panelpedidos.Visibility = Visibility.Visible;
        }


        private void txtsearch_prov_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            Panelpedidos.Visibility = Visibility.Hidden;
        }

        private void dtg_pedidos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prov = dtg_prov.SelectedItem as e_Proveedor;
            if (prov != null)
            {
                txtRUC.Text = prov.RUC_Prov;
                txtProveedor.Text = prov.Proveedor;
                txtOrigen.Text = prov.Proveedor;
                Panelpedidos.Visibility = Visibility.Hidden;
            }
        }

        private void txtsearch_prov_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            dtg_prov.ItemsSource = obj_entradas.Lista_proveedores(txtsearch_prov.Text);
        }

        private void txtProveedor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNrofct_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtgFact.ItemsSource = obj_entradas.Lista_total(txtserie.Text + "-" + txtNrofct.Text);
            dtgFact.SelectAllCells();
        }

        private void dtgFact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fact = dtgFact.SelectedItem as e_TotalFact;
            if (fact != null)
            {
                lblCmp.Content = fact.Factura;
                lblCosto.Content = fact.Total;
                lblUnit.Content = fact.Cantidad;
            }
        }

        //private void button1_Copy_Click(object sender, RoutedEventArgs e)
        //{
        //    frm_Inicio form = new frm_Inicio();
        //    this.Close();
        //    form.ShowDialog();
        //}

        private void cmbResponsable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = txtProducto.Text;

            dtg_infoprod.ItemsSource = obj_minis.Lista_minicods(texto);
        }

        private void txt_searchfactura_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_searchfactura.Text == "Factura")
            {
                txt_searchfactura.Text = "";
                txt_searchfactura.Foreground = new SolidColorBrush(Colors.White); // Cambia el color del texto si es necesario
            }
        }

        private void txt_searchfactura_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchfactura.Text))
            {
                txt_searchfactura.Text = "Factura";
                txt_searchfactura.Foreground = new SolidColorBrush(Colors.Gray); // Cambia el color del texto si es necesario
            }
        }

    }
}
