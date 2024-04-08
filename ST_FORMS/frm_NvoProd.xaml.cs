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
using System.Data.SqlClient;
using ST_Negocio;
using ST_Datos;
using ST_Entidades;

namespace ST_FORMS
{
    /// <summary>
    /// Interaction logic for frm_NvoProd.xaml
    /// </summary>
    public partial class frm_NvoProd : Window
    {
        e_Buscaminis prod = null;
        e_Marcas marca = null;
        e_Tipo tipo = null;
        e_Nuevo_prod producto = null;
        n_Nvo_Prod obj_nvo_prod = new n_Nvo_Prod();
        n_Buscaminis obj_minis = new n_Buscaminis();
        int id_prod ;
        public frm_NvoProd()
        {
            InitializeComponent();
            Lista_nuevos_prd();
        }
        private void Ingresar_a_cons()
        {
            obj_nvo_prod.Ingresar_a_cons();
        }
        private void Lista_nuevos_prd ()
        {
           dtg_NvoPrd.ItemsSource= obj_nvo_prod.Listar_nuevos_prd();
        }
        private void txtNorden_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dtg_NvoPrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbl_mode.Opacity == 0.99)
            {
                producto = dtg_NvoPrd.SelectedItem as e_Nuevo_prod;
                if (producto != null)
                {
                    id_prod = producto.Id_nvop;
                    txtMinicod.Text = producto.Minicod;
                    txtEAN.Text = producto.EAN;
                    txtUPC.Text = producto.UPC;
                    txtTipo.Text = producto.Tipo;
                    txtPartnumb.Text = producto.Partnumb;
                    txtTitulo.Text = producto.Titulo;
                    txtModelo.Text = producto.Modelo;
                    txtMarca.Text = producto.Marca;
                    datePicker.Text = producto.Fecha_registro;
               
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.Text != "" && txtTitulo.Text != "")
            {
                MessageBox.Show(obj_nvo_prod.Ingresar_nuevos_prod(datePicker.Text, txtUPC.Text, txtEAN.Text, "", txtModelo.Text,
            txtMinicod.Text, txtPartnumb.Text, txtMarca.Text, txtTipo.Text, txtTitulo.Text, datePicker.Text,txtColor.Text,txtPeso.Text,txt_Cj_alto.Text,
            txt_Cj_largo.Text,txt_Cj_ancho.Text,txt_Pr_alto.Text,txt_Pr_largo.Text,txt_Pr_ancho.Text));
                Ingresar_a_cons();
                Lista_nuevos_prd();
                txtTipo.Text = "";
                txtMinicod.Text = "";
                txtMarca.Text = "";
                txtPartnumb.Text = "";
                txtTitulo.Text = "";
                txtUPC.Text = "";
                txtEAN.Text = "";
                txtModelo.Text = "";

            }
            else MessageBox.Show("Rellene los campos faltantes");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.Text != "" && txtTitulo.Text != "" && txtPartnumb.Text != "")
            {
                MessageBox.Show(obj_nvo_prod.Actualizar_prod(txtUPC.Text, txtEAN.Text,txtModelo.Text, txtMinicod.Text, txtPartnumb.Text,
                    txtMarca.Text, txtTipo.Text, txtTitulo.Text, id_prod, txtColor.Text, txtPeso.Text, txt_Cj_alto.Text,
                    txt_Cj_largo.Text, txt_Cj_ancho.Text, txt_Pr_alto.Text, txt_Pr_largo.Text, txt_Pr_ancho.Text));
                Lista_nuevos_prd();
            }
            else MessageBox.Show("Rellene los campos faltantes");
        }


        private void button4_Click(object sender, RoutedEventArgs e)
        {
            txtTipo.Text = "";
            txtMinicod.Text = "";
            txtMarca.Text = "";
            txtPartnumb.Text = "";
            txtTitulo.Text = "";
            txtUPC.Text = "";
            txtEAN.Text = "";
            txtModelo.Text = "";
        }

        private void cmbMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtg_vista.ItemsSource = obj_nvo_prod.Listar_marcas(txtMarca.Text);     
        }

        private void txtTipo_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtg_vista.ItemsSource = obj_nvo_prod.Listar_tipos(txtTipo.Text);
        }

        private void dtg_Similares_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           prod = dtg_Similares.SelectedItem as e_Buscaminis ;
            if (prod != null)
            {
                txtTitulo.Text = prod.Producto;
            }

        }

        private void txtPartnumb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtg_Similares.ItemsSource = obj_minis.ListaTitulos(txtPartnumb.Text);
        }

        private void dtg_vista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            marca = dtg_vista.SelectedItem as e_Marcas;
            tipo = dtg_vista.SelectedItem as e_Tipo;

            if (marca != null )
            {                
                txtMarca.Text = marca.Marca;
            }
            else if (tipo != null)
            {                
                txtTipo.Text = tipo.Tipo;
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
          
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Lista_nuevos_prd();
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
    }
}
