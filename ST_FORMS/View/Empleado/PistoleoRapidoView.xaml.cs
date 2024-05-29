﻿using ST_Entidades;
using ST_FORMS.ViewModel.Comunes;
using ST_FORMS.ViewModel.Empleado;
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
    /// Lógica de interacción para PistoleoRapidoView.xaml
    /// </summary>
    public partial class PistoleoRapidoView : UserControl
    {
        private readonly MainViewModel _mainViewModel;
        n_Pistoleo PistoOBJ = new n_Pistoleo();
        e_BuscaPisto pistobusca = null;

        public PistoleoRapidoView()
        {
            InitializeComponent();
        }
        public PistoleoRapidoView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            button_Copy1.Click += NavigateToPistoleoInicio;
            button.Click += NavigateToPistoleoSeguro;
            Lista_ocs();
            Cargar_cmb();
        }

        private void NavigateToPistoleoInicio(object sender, RoutedEventArgs e)
        {
            _mainViewModel.CurrentChildView = new PistoleoInicioView(_mainViewModel);
        }

        private void NavigateToPistoleoSeguro(object sender, RoutedEventArgs e)
        {
            _mainViewModel.CurrentChildView = new PistoleoSeguroView(_mainViewModel);
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

            cmbResponsable.Items.Add("L.MEJIAS");
            cmbResponsable.Items.Add("A.MIRANDA");
            cmbResponsable.Items.Add("Y.LEAL");
            cmbResponsable.Items.Add("F.PEDROZA");

        }
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //PistoleoInicioView frm = new PistoleoInicioView();
            //this.Close();
            //frm.ShowDialog();

        }
        private void Lista_ocs()
        {
            dtg_oc_pendiente.ItemsSource = PistoOBJ.Lista_pistoleo_rapido();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // PanelDespacho1.Visibility = Visibility.Visible;
        }

        private void btnCANCELAR_Click(object sender, RoutedEventArgs e)
        {
            // PanelDespacho1.Visibility = Visibility.Hidden;
        }

        private void btnINGRESAR_Click(object sender, RoutedEventArgs e)
        {
            if (cmbResponsable.Text != "" && cmbCanal.Text != "")
            {
                MessageBox.Show(PistoOBJ.Ingresar_pistoleo_rapido(txtBarras.Text, txtProducto.Text, cmbCanal.Text, txtModelo.Text, txtPartnumber.Text, cmbResponsable.Text));
                //PistoOBJ.Actualiza_ocs();
                PistoOBJ.Actualizar_pisto_rapido();
                Lista_ocs();
                //txtProducto.Text = "";              
                txtBarras.Focus();
            }
            else
            {
                MessageBox.Show("Indicar Responsable");
            }
            //lbl_cuenta_pend.Content = "ORDENES POR DESPACHAR: " + Convert.ToString(dtg_oc_pend.Items.Count - 1);
            dtg_oc_pendiente.ItemsSource = PistoOBJ.Lista_pistoleo_rapido();
        }

        private void txtBarras_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtgProd.ItemsSource = PistoOBJ.Lista_prod_barras(txtBarras.Text);
            dtgProd.SelectAllCells();
            btnINGRESAR.Focus();
        }

        private void dtgProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pistobusca = dtgProd.SelectedItem as e_BuscaPisto;
            if (pistobusca != null)
            {
                txtModelo.Text = pistobusca.MODELO;
                txtPartnumber.Text = pistobusca.PARTNUMBER;
                txtProducto.Text = pistobusca.PRODUCTO;
            }
        }
    }
}
