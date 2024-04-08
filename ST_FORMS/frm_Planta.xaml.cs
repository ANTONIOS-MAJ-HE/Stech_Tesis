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
using System.IO;
using System.Diagnostics;
using ST_Negocio;

namespace ST_FORMS
{
    /// <summary>
    /// Interaction logic for frm_Planta.xaml
    /// </summary>
    public partial class frm_Planta : Window
    {
        n_Planta plantaOBJ = new n_Planta();
        public frm_Planta()
        {
            InitializeComponent();
            Listar_prods();
            LoadCombobox();
        }
        private void LoadCombobox()
        {
            cmbSKU.Items.Add("SODIMAC");
            cmbSKU.Items.Add("SAGA");
            cmbSKU.Items.Add("TOTTUS");
            cmbSKU.Items.Add("LINIO");
            cmbSKU.Items.Add("RIPLEY");
            cmbSKU.Items.Add("JUNTOZ");
            cmbSKU.Items.Add("REALPLAZA");
            cmbSKU.Items.Add("LUMINGO");
            cmbSKU.Items.Add("MLIBRE");
            cmbSKU.Items.Add("CATPHONE");
            cmbSKU.Items.Add("KINGSTON");
        }
        private void Listar_prods()
        {
            plantaOBJ.Cargar_stock();
            dtg_prod.ItemsSource = plantaOBJ.Listar_Productos(Convert.ToDouble(txtcambio.Text));
            lblcant.Content = Convert.ToString(dtg_prod.Items.Count - 1);  
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonnvo_Click(object sender, RoutedEventArgs e)
        {
            plantaOBJ.Cargar_stock();
            dtg_prod.ItemsSource = plantaOBJ.Listar_Filtro(txtMinicod.Text,txtProducto.Text,txtMarca.Text,txtBarras.Text,txtTipo.Text,txtModelo.Text,txtPartnumb.Text, txtSKU.Text,Convert.ToDouble(txtcambio.Text));
            lblcant.Content = Convert.ToString(dtg_prod.Items.Count-1);
        }

        private void btn_Nuevo_Copy_Click(object sender, RoutedEventArgs e)
        {
            plantaOBJ.Cargar_stock();
            txtBarras.Text = "";
            txtMarca.Text = "";
            txtMinicod.Text = "";
            txtModelo.Text = "";
            txtPartnumb.Text = "";
            txtProducto.Text = "";
            txtSKU.Text = "";
            txtTipo.Text = "";
            Listar_prods();
            lblcant.Content = Convert.ToString(dtg_prod.Items.Count - 1);
        }

        private void btn_Nuevo_Copy1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Nuevo_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Listar_prods();
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.Key.ToString())
            //{
            //    case "Return":
            //        plantaOBJ.Cargar_stock();
            //        dtg_prod.ItemsSource = plantaOBJ.Listar_Filtro(txtMinicod.Text, txtProducto.Text, txtMarca.Text, txtBarras.Text, txtTipo.Text, txtModelo.Text, txtPartnumb.Text, txtSKU.Text, Convert.ToDouble(txtcambio.Text));
            //        lblcant.Content = Convert.ToString(dtg_prod.Items.Count - 1);
            //        break;
            //    case "Enter":
            //        plantaOBJ.Cargar_stock();
            //        dtg_prod.ItemsSource = plantaOBJ.Listar_Filtro(txtMinicod.Text, txtProducto.Text, txtMarca.Text, txtBarras.Text, txtTipo.Text, txtModelo.Text, txtPartnumb.Text, txtSKU.Text, Convert.ToDouble(txtcambio.Text));
            //        lblcant.Content = Convert.ToString(dtg_prod.Items.Count - 1);
            //        break;
            //}
        }

        private void txtSKU_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtg_prod.ItemsSource = plantaOBJ.Listar_FiltroSKU(txtSKU.Text, cmbSKU.SelectedIndex, txtcambio.Text);
        }

        private void txtProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            //realiza el filtro
            string texto = txtProducto.Text;

            dtg_prod.ItemsSource = plantaOBJ.FiltraPalabras(texto,txtcambio.Text);

            lblcant.Content = Convert.ToString(dtg_prod.Items.Count - 1);
        }

        private void txtMinicod_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key.ToString())
            {
                case "Return":
                    plantaOBJ.Cargar_stock();
                    dtg_prod.ItemsSource = plantaOBJ.Listar_Filtro(txtMinicod.Text, txtProducto.Text, txtMarca.Text, txtBarras.Text, txtTipo.Text, txtModelo.Text, txtPartnumb.Text, txtSKU.Text, Convert.ToDouble(txtcambio.Text));
                    lblcant.Content = Convert.ToString(dtg_prod.Items.Count - 1);
                    break;
                case "Enter":
                    plantaOBJ.Cargar_stock();
                    dtg_prod.ItemsSource = plantaOBJ.Listar_Filtro(txtMinicod.Text, txtProducto.Text, txtMarca.Text, txtBarras.Text, txtTipo.Text, txtModelo.Text, txtPartnumb.Text, txtSKU.Text, Convert.ToDouble(txtcambio.Text));
                    lblcant.Content = Convert.ToString(dtg_prod.Items.Count - 1);
                    break;
            }
        }
    }
}
