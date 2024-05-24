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
    /// Interaction logic for frm_Actualizar_prod.xaml
    /// </summary>
    public partial class frm_Actualizar_prod : Window
    {
        n_Planta planta_obj = new n_Planta();
        e_Planta planta = null;
        string pn = null;
        public frm_Actualizar_prod()
        {
            InitializeComponent();
            Lista_prod();
            Combofill();
            cmbSearch.SelectedIndex = 0;
        }

        private void Combofill()
        {
            cmbSearch.Items.Add("TITULO");
            cmbSearch.Items.Add("EAN / UPC");
            cmbSearch.Items.Add("MODELO / MINICOD / PN");

        }

        private void Lista_prod()
        {
            dt_planta.ItemsSource = planta_obj.Lista_planta();
            txt_prd_cant.Content = Convert.ToString(dt_planta.Items.Count - 1);
        }

        private void txtN_Orden_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Limpiar()
        {
            txt_UPC.Text = "";
            txt_EAN.Text = "";
            txt_Modelo.Text = "";
            txt_Mini_codigo.Text = "";
            txt_Partnumber.Text = "";      
            txt_Marca.Text = "";
            txt_Tipo.Text = "";
            txt_Titulo.Text = "";
            txt_Descont.Text = "";
            txt_SKU_SAGA.Text = "";
            txt_SKU_LINIO.Text = "";
            txt_SKU_RIPLEY.Text = "";
            txt_SKU_RPG.Text = "";
            txt_SKU_JUNTOZ.Text = "";
            txt_SKU_LUMINGO.Text = "";
            txt_SKU_SODIMAC.Text = "";
            txt_SKU_TOTTUS.Text = "";
            txt_SKU_KINGSTON.Text = "";
            txt_C_U_S_IGV_PEN.Text = "";
            txt_C_U_S_IGV_USD.Text = "";
            txt_SKU_CATPHONE.Text = "";
            txt_SKU_MLIBRE.Text = "";
            //AGREGANDO CONECTA
            txt_SKU_CONECTA.Text = "";
            pn = null;
        }
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            {
                planta = dt_planta.SelectedItem as e_Planta;
                if (planta != null)
                {
                    txt_UPC.Text = planta.UPC;
                    txt_EAN.Text = planta.EAN;
                    txt_Modelo.Text = planta.MODELO;
                    txt_Mini_codigo.Text = planta.MINI_CODIGO;
                    txt_Partnumber.Text = planta.PARTNUMBER;
                    pn = planta.PARTNUMBER;
                    txt_Marca.Text = planta.MARCA;
                    txt_Tipo.Text = planta.TIPO;
                    txt_Titulo.Text = planta.TITULO;
                    txt_Descont.Text = planta.DESCONTINUADO;
                    txt_SKU_SAGA.Text = planta.SKU_SAGA;
                    txt_SKU_LINIO.Text = planta.SKU_LINIO;
                    txt_SKU_RIPLEY.Text = planta.SKU_RIPLEY;
                    txt_SKU_RPG.Text = planta.SKU_REALPLAZA;
                    txt_SKU_JUNTOZ.Text = planta.SKU_JUNTOZ;
                    txt_SKU_LUMINGO.Text = planta.SKU_LUMINGO;
                    txt_SKU_SODIMAC.Text = planta.SKU_SODIMAC;
                    txt_SKU_TOTTUS.Text = planta.SKU_TOTTUS;
                    txt_SKU_KINGSTON.Text = planta.SKU_KINGSTON;
                    txt_C_U_S_IGV_PEN.Text = planta.COSTO_U_S_IGV_SOLES;
                    txt_C_U_S_IGV_USD.Text = planta.COSTO_U_S_IGV_DOLARES;
                    txt_SKU_CATPHONE.Text = planta.SKU_CATPHONE;
                    txt_SKU_MLIBRE.Text = planta.SKU_MLIBRE;
                    txt_SKU_COOLBOX.Text = planta.SKU_COOLBOX;
                    //AGREGANDO CONECTA
                    txt_SKU_CONECTA.Text = planta.SKU_CONECTA;
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_Search.Text = "";
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
          
            switch (cmbSearch.SelectedIndex)
            {
                case 0: dt_planta.ItemsSource= planta_obj.Lista_planta_titulo(txt_Search.Text);
                    break;
                case 1: dt_planta.ItemsSource = planta_obj.Lista_planta_barras(txt_Search.Text);
                    break;
                case 2: dt_planta.ItemsSource = planta_obj.Lista_planta_codigo(txt_Search.Text);
                    break;
            }
            txt_prd_cant.Content = Convert.ToString( dt_planta.Items.Count-1);

        }

        private void btn_Limp_Copy1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if(pn != null)
            {
                MessageBox.Show(planta_obj.Actualizar_planta(txt_UPC.Text, txt_EAN.Text, txt_Modelo.Text, txt_Mini_codigo.Text, txt_Partnumber.Text, txt_Marca.Text,
                    txt_Tipo.Text, txt_Titulo.Text, txt_Descont.Text, txt_SKU_SAGA.Text, txt_SKU_LINIO.Text, txt_SKU_RIPLEY.Text, txt_SKU_RPG.Text,
                    txt_SKU_JUNTOZ.Text, txt_SKU_LUMINGO.Text, txt_SKU_SODIMAC.Text, txt_SKU_TOTTUS.Text, txt_SKU_KINGSTON.Text, txt_C_U_S_IGV_USD.Text,
                    txt_C_U_S_IGV_PEN.Text, pn, txt_SKU_CATPHONE.Text, txt_SKU_MLIBRE.Text,txt_SKU_COOLBOX.Text,txt_SKU_FALABELLA.Text, txt_SKU_CONECTA.Text));//AGREGANDO CONECTA
                Limpiar();
            }

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }
    }
}
