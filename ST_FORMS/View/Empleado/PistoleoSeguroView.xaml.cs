using ST_Entidades;
using ST_FORMS.ViewModel.Comunes;
using ST_FORMS.ViewModel.Empleado;
using ST_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para PistoleoSeguroView.xaml
    /// </summary>
    public partial class PistoleoSeguroView : UserControl
    {
        private readonly MainViewModel _mainViewModel;
        n_Pistoleo pistoOBJ = new n_Pistoleo();
        e_Ordenes_pistoleo pisto = null;
        e_BuscaPisto pistobusca = null;
        e_Prod_listo prod_listo = null;
        int n_item;
        string nro_oc;

        public PistoleoSeguroView()
        {
            InitializeComponent();
        }

        public PistoleoSeguroView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            // Example button event to navigate to PistoleoRapidoView
            button_Copy1.Click += NavigateToPistoleoInicio;
            Cargar_cmb();
            cmbCanal.SelectedIndex = 2;
            txtProducto.Focus();
            Listar_ocs();
            Limpiar_prod_lista();
            btn_mode.Background = Brushes.Coral;
            btn_mode.Content = "Modo edición OFF";
            pistoOBJ.Actualizar_folio();

        }

        private void NavigateToPistoleoInicio(object sender, RoutedEventArgs e)
        {
            _mainViewModel.CurrentChildView = new PistoleoInicioView(_mainViewModel);
        }

        public void Limpiar_prod_lista()
        {
            pistoOBJ.Limpiar_prod_listo_temp();
        }

        public void Cargar_cmb()
        {
            cmbCanal.Items.Add("LINIO");
            cmbCanal.Items.Add("RIPLEY");
            cmbCanal.Items.Add("SAGA");
            cmbCanal.Items.Add("REAL PLAZA");
            cmbCanal.Items.Add("LUMINGO");
            cmbCanal.Items.Add("MERCADO LIBRE");
            cmbCanal.Items.Add("CATPHONE");
            cmbCanal.Items.Add("OFICINA");
            cmbCanal.Items.Add("COOLBOX");
            cmbCanal.Items.Add("FALABELLA");
            //se agrega, por que ...
            cmbCanal.Items.Add("KINGSTON");
            //agregando conecta
            cmbCanal.Items.Add("CONECTA");
            //agregando juntoz
            cmbCanal.Items.Add("JUNTOZ");

            cmbResponsable.Items.Add("L.MEJIAS");
            cmbResponsable.Items.Add("A.MIRANDA");
            cmbResponsable.Items.Add("Y.LEAL");
            cmbResponsable.Items.Add("F.PEDROZA");
            cmbResponsable.Items.Add("USER 1");
            cmbResponsable.Items.Add("USER 2");
            cmbResponsable.Items.Add("USER 3");
            cmbResponsable.Items.Add("USER 4");
        }
        public void Listar_ocs()
        {
            dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc(cmbCanal.Text, txtProducto.Text);
            dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente(cmbCanal.Text);

            List<e_Ordenes_pistoleo> OrdenesTotal = dtg_ocs.ItemsSource as List<e_Ordenes_pistoleo>;
            HashSet<string> OrdenesNorepetidas = new HashSet<string>();
            foreach (e_Ordenes_pistoleo factura in OrdenesTotal)
            {
                OrdenesNorepetidas.Add(factura.NRO_OC);
            }
            List<string> facturasPendientes = OrdenesNorepetidas.ToList();
            lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(facturasPendientes.Count);

            //lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
        }

        private void cmbCanal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbCanal.SelectedIndex)
            {
                case 0:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("LINIO", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("LINIO");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 1:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("RIPLEY", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("RIPLEY");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 2:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("SAGA", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("SAGA");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 3:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("REAL PLAZA", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("REAL PLAZA");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 4:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("LUMINGO", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("LUMINGO");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 5:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("MERCADO LIBRE", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("MERCADO LIBRE");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 6:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("CATPHONE", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("CATPHONE");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 7:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("OFICINA", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("OFICINA");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 8:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("COOLBOX", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("COOLBOX");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 9:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("FALABELLA", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("FALABELLA");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                case 10:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("KINGSTON", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("KINGSTON");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                //Agregando conecta
                case 11:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("CONECTA", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("CONECTA");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
                //Agregando juntoz
                case 12:
                    dtg_ocs.ItemsSource = pistoOBJ.Lista_pistoleo_oc("JUNTOZ", txtProducto.Text);
                    dtg_oc_pend.ItemsSource = pistoOBJ.Lista_cant_pendiente("JUNTOZ");
                    lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_ocs.Items.Count - 1);
                    break;
            }


        }

        private void txtProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            Listar_ocs();

            txt_lect_barras.Text = txtProducto.Text;

            //  txt_lect_barras.Text = " " + txt_lect_barras.Text;
            dtg_ocs.SelectAllCells();

        }

        private void btn_buscaa_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCanal.Text != "")
            {
                Listar_ocs();
            }
        }

        private void dtg_ocs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            pisto = dtg_ocs.SelectedItem as e_Ordenes_pistoleo;
            if (pisto != null && btn_mode.Background == Brushes.Coral)
            {
                nro_oc = pisto.NRO_OC;
                txtCanal.Text = pisto.CANAL;
                txtEstado.Text = pisto.ESTADO;
                txtNroOrden.Text = pisto.NRO_OC;
                dtFecha.Text = pisto.FECHA_DESPACHO;
                btnELIMINAR.IsEnabled = true;
                btn_INGRESAR.IsEnabled = true;
                btnGuardar.IsEnabled = true;
            }
            else if (pisto != null && btn_mode.Background == Brushes.MediumSpringGreen)
            {
                nro_oc = pisto.NRO_OC;
                txtCanal.Text = pisto.CANAL;
                txtEstado.Text = pisto.ESTADO;
                txtNroOrden.Text = pisto.NRO_OC;
                dtFecha.Text = pisto.FECHA_DESPACHO;
                txtNroGuia.Text = pisto.NRO_GUIA;
                txtFolio.Text = pisto.FOLIO;
                txtNROserie.Text = pisto.FOLIO;
                btnELIMINAR.IsEnabled = false;
                btn_INGRESAR.IsEnabled = false;
                btnGuardar.IsEnabled = false;
            }
        }

        private void txtNroOrden_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtgProductos.ItemsSource = pistoOBJ.Lista_productosXorden(txtCanal.Text, txtNroOrden.Text);
        }

        private void textBox4_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string x = " ";
            //if (txtNroGuia.Text.Length >= 20)
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        x += x;
            //        txt_nro_invi.Text = txtNroGuia.Text+ x;


            //    }
            //}
        }

        private void txt_lect_barras_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_lect_barras.Text.Length >= 12)
            {
                dtg_invi.ItemsSource = pistoOBJ.Lista_prod_barras(txt_lect_barras.Text);
                dtg_invi.SelectAllCells();
                btn_INGRESAR.Focus();
            }

        }

        private void dtg_invi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pistobusca = dtg_invi.SelectedItem as e_BuscaPisto;
            if (pistobusca != null)
            {
                txt_lect_modelo.Text = pistobusca.MODELO;
                txt_lect_partnumb.Text = pistobusca.PARTNUMBER;
                txt_lect_prod.Text = pistobusca.PRODUCTO;
            }
        }

        private void txt_lect_partnumb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_INGRESAR_Click(object sender, RoutedEventArgs e)
        {
            if (txt_lect_prod.Text != "" && txt_lect_partnumb.Text != "" && cmbResponsable.Text != "")
            {
                pistoOBJ.Ingresar_prod_temp(txt_lect_barras.Text, txt_lect_prod.Text, txtCanal.Text, txtNroOrden.Text, txt_lect_modelo.Text, txt_lect_partnumb.Text);
                dtgLECTPROD.ItemsSource = pistoOBJ.Listar_prod_temp();
                txt_lect_barras.Text = "";
                txt_lect_prod.Text = "";
                txt_lect_partnumb.Text = "";
                txt_lect_modelo.Text = "";
                txt_lect_barras.Focus();

                dtg_rev.ItemsSource = pistoOBJ.Lista_errores_pisto(txtCanal.Text, txtNroOrden.Text);
                if (dtg_rev.Items.Count == 1)
                {
                    dtg_rev.Visibility = Visibility.Hidden;
                    lblconfirm.Foreground = Brushes.Green;
                    lblconfirm.Content = "PRODUCTOS LISTOS PARA DESPACHO";

                }
                else
                {
                    dtg_rev.Visibility = Visibility.Visible;
                    lblconfirm.Foreground = Brushes.Red;
                    lblconfirm.Content = "POR FAVOR REVISAR LOS SIGUIENTES PRODUCTOS";
                }
            }
            else
            {
                MessageBox.Show("REVISAR CAMPOS VACIOS (RESPONSABLE, PRODUCTO)");
            }
            if (lblconfirm.Foreground == Brushes.Green)
            {
                dtg_rev.ItemsSource = pistoOBJ.Lista_errores_pisto(txtCanal.Text, txtNroOrden.Text);
                if (dtg_rev.Items.Count == 1)
                {
                    dtg_rev.Visibility = Visibility.Hidden;
                    lblconfirm.Foreground = Brushes.Green;
                    lblconfirm.Content = "PRODUCTOS LISTOS PARA DESPACHO";

                }
                else
                {
                    dtg_rev.Visibility = Visibility.Visible;
                    lblconfirm.Foreground = Brushes.Red;
                    lblconfirm.Content = "POR FAVOR REVISAR LOS SIGUIENTES PRODUCTOS";
                }
                txtNroGuia.Focus();
            }


        }

        private void btn_Confirmar_Click(object sender, RoutedEventArgs e)
        {
            dtg_rev.ItemsSource = pistoOBJ.Lista_errores_pisto(txtCanal.Text, txtNroOrden.Text);

            if (dtg_rev.Items.Count == 1)
            {
                dtg_rev.Visibility = Visibility.Hidden;
                lblconfirm.Foreground = Brushes.Green;
                lblconfirm.Content = "PRODUCTOS LISTOS PARA DESPACHO";

            }
            else
            {
                dtg_rev.Visibility = Visibility.Visible;
                lblconfirm.Foreground = Brushes.Red;
                lblconfirm.Content = "POR FAVOR REVISAR LOS SIGUIENTES PRODUCTOS";
            }
        }

        private void dtg_rev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dtgLECTPROD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prod_listo = dtgLECTPROD.SelectedItem as e_Prod_listo;
            if (prod_listo != null)
            {
                n_item = prod_listo.N_ITEM;
            }

        }

        private void btnELIMINAR_Click(object sender, RoutedEventArgs e)
        {
            if (prod_listo != null)
            {
                pistoOBJ.Eliminar_prod_pisto(n_item);
                dtgLECTPROD.ItemsSource = pistoOBJ.Listar_prod_temp();


                dtg_rev.ItemsSource = pistoOBJ.Lista_errores_pisto(txtCanal.Text, txtNroOrden.Text);
                if (dtg_rev.Items.Count == 1)
                {
                    dtg_rev.Visibility = Visibility.Hidden;
                    lblconfirm.Foreground = Brushes.Green;
                    lblconfirm.Content = "PRODUCTOS LISTOS PARA DESPACHO";

                }
                else
                {
                    dtg_rev.Visibility = Visibility.Visible;
                    lblconfirm.Foreground = Brushes.Red;
                    lblconfirm.Content = "POR FAVOR REVISAR LOS SIGUIENTES PRODUCTOS";
                }
            }
            else
            {
                dtg_rev.ItemsSource = pistoOBJ.Lista_errores_pisto(txtCanal.Text, txtNroOrden.Text);
                if (dtg_rev.Items.Count == 1)
                {
                    dtg_rev.Visibility = Visibility.Hidden;
                    lblconfirm.Foreground = Brushes.Green;
                    lblconfirm.Content = "PRODUCTOS LISTOS PARA DESPACHO";

                }
                else
                {
                    dtg_rev.Visibility = Visibility.Visible;
                    lblconfirm.Foreground = Brushes.Red;
                    lblconfirm.Content = "POR FAVOR REVISAR LOS SIGUIENTES PRODUCTOS";
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbResponsable.Text != "")
            {
                MessageBox.Show(pistoOBJ.Ingresar_pistoleo(txtNroGuia.Text, txtNROserie.Text, cmbResponsable.Text, txtFolio.Text));
                pistoOBJ.Actualiza_ocs();
                Listar_ocs();
                txtProducto.Text = "";
                txtNroGuia.Text = "";
                txtNROserie.Text = "";
                txtFolio.Text = "";
                txtProducto.Focus();
                dtg_ocs.UnselectAllCells();

            }
            else
            {
                MessageBox.Show("Indicar Responsable");
            }
            lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_oc_pend.Items.Count - 1);
            dtgLECTPROD.ItemsSource = pistoOBJ.Listar_prod_temp();
        }

        private void txtEstado_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtEstado.Text == "LISTO PARA RECOJO")
            {
                lblconfirm.Foreground = Brushes.Red;
                lblconfirm.Content = "ORDEN PREVIAMENTE REGISTRADA";
                btnGuardar.IsEnabled = false;
                btn_INGRESAR.IsEnabled = false;
                btnELIMINAR.IsEnabled = false;

            }
            else
            {
                lblconfirm.Content = "";
                btnGuardar.IsEnabled = true;
                btn_INGRESAR.IsEnabled = true;
                btnELIMINAR.IsEnabled = true;

            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //frm_Pistoleo frm = new frm_Pistoleo();
            //this.Close();
            //frm.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (btn_mode.Background == Brushes.Coral)
            {
                btn_mode.Content = "Modo Actualizar ON ";
                btn_mode.Background = Brushes.MediumSpringGreen;

                btnELIMINAR.IsEnabled = false;
                btn_INGRESAR.IsEnabled = false;
                btnGuardar.IsEnabled = false;

            }
            else
            {
                btn_mode.Content = "Modo Actualizar OFF ";
                btn_mode.Background = Brushes.Coral;
                btnELIMINAR.IsEnabled = true;
                btn_INGRESAR.IsEnabled = true;
                btnGuardar.IsEnabled = true;
            }

        }

        private void btnGuardar_Copy_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(pistoOBJ.Actualizar_prod_listo(txtNroGuia.Text, txtNROserie.Text, txtFolio.Text, txtNroOrden.Text));

            Listar_ocs();

        }

        private void dtgProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            //frm_Actualizar_prod frm = new frm_Actualizar_prod();
            //this.Close();
            //frm.ShowDialog();
        }
    }
}
