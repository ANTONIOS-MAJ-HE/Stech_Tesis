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
    /// Interaction logic for frm_Consolidados.xaml
    /// </summary>
    public partial class frm_Consolidados : Window
    {
        n_Consolidados ConsolidadosOBJ = new n_Consolidados();
        public frm_Consolidados()
        {
            InitializeComponent();
            //Fill_combobox();
            Cargar_desp_nuevo();
            ListarCanal();
        }

        //public void Fill_combobox()
        //{
        //    cmbCanal.Items.Add("SAGA");
        //    cmbCanal.Items.Add("LINIO");
        //    cmbCanal.Items.Add("RIPLEY");
        //    cmbCanal.Items.Add("REAL PLAZA");
        //    cmbCanal.Items.Add("KINGSTON");
        //}

        public void Cargar_desp_nuevo()
        {
            ConsolidadosOBJ.Cargar_desp_nuevo();
        }

        public void ListarCanal()
        {
            Boolean filtro = txtCanal.Text.Length == 0 && txtCliente.Text.Length == 0 && txtNRO_OC.Text.Length == 0 && txtPrtnumber.Text.Length == 0 && dtFechaProceso.Text=="" && txtProducto.Text.Length == 0;
            if (filtro)
            {
                //if (cmbCanal.SelectedIndex == -1)
                //{
                    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas();
                //}
                //else if (cmbCanal.SelectedIndex == 0)
                //{
                //    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_S();
                //}
                //else if (cmbCanal.SelectedIndex == 1)
                //{
                //    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_L();
                //}
                //else if (cmbCanal.SelectedIndex == 2)
                //{
                //    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_R();
                //}
                //else if (cmbCanal.SelectedIndex == 3)
                //{
                //    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_RP();
                //}
                //else if (cmbCanal.SelectedIndex == 4)
                //{
                //    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_KG();
                //}
            }
            else
            {
                //if (cmbCanal.SelectedIndex == -1)
                //{
            //        dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_S();
            //}
            //    else if (cmbCanal.SelectedIndex == 0)
            //{
                dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_F(txtCanal.Text, txtPrtnumber.Text, txtCliente.Text, txtNRO_OC.Text, dtFechaProceso.Text, txtProducto.Text);
            //}
            //else if (cmbCanal.SelectedIndex == 1)
            //{
            //    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_L_F(txtPrtnumber.Text, txtCliente.Text, txtNRO_OC.Text, dtFechaProceso.Text, txtProducto.Text);
            //}
            //else if (cmbCanal.SelectedIndex == 2)
            //{
            //    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_R_F(txtPrtnumber.Text, txtCliente.Text, txtNRO_OC.Text, dtFechaProceso.Text, txtProducto.Text);
            //}
            //else if (cmbCanal.SelectedIndex == 3)
            //{
            //    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_RP_F(txtPrtnumber.Text, txtCliente.Text, txtNRO_OC.Text, dtFechaProceso.Text, txtProducto.Text);
            //}
            //else if (cmbCanal.SelectedIndex == 4)
            //{
            //    dtgConsolidados.ItemsSource = ConsolidadosOBJ.Lista_entradas_KG_F(txtPrtnumber.Text, txtCliente.Text, txtNRO_OC.Text, dtFechaProceso.Text, txtProducto.Text);
            //}
        }

        }

        private void cmbCanal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListarCanal();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void btnReporte_Click(object sender, RoutedEventArgs e)
        {
            frm_Reporte frm = new frm_Reporte();
            this.Close();
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ListarCanal();
        }

        private void txtNRO_OC_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key.ToString())
            {
                case "Return":
                    ListarCanal();
                    break;
                case "Enter":
                    ListarCanal();
                    break;
            }
        }
    }
}
