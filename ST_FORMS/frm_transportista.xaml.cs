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
using System.Windows.Shapes;

namespace ST_FORMS
{
    /// <summary>
    /// Lógica de interacción para frm_transportista.xaml
    /// </summary>
    public partial class frm_transportista : Window
    {
        n_transportista transportista_obj = new n_transportista();
        public frm_transportista()
        {
            InitializeComponent();
            lista_transportista();
            lista_choferes();
            Fill_Combox();
        }
        public void lista_transportista()
        {
            dtg_TRANSportista.ItemsSource= transportista_obj.ListarTransportistas();
        }
        public void lista_choferes()
        {
            dtgChoferes.ItemsSource = transportista_obj.ListarChoferes();
        }
        private void Fill_Combox()
        {
            cmb_tipodoc.Items.Add("RUC");
            cmb_tipodoc.Items.Add("DNI");

            cmb_privTipodoc.Items.Add("RUC");
            cmb_privTipodoc.Items.Add("DNI");
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(transportista_obj.añadirTransportista(txt_nombre.Text,cmb_tipodoc.Text,txt_documento.Text,txt_Numeromtc.Text,txt_Direccionfisacal.Text));
            lista_transportista();
        }

        private void btn_privAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(transportista_obj.añadirChofer(txt_privNombre.Text, cmb_privTipodoc.Text, txt_privDoc.Text, txt_privTelefono.Text, txt_privLicencia.Text,
                txt_privPlaca.Text, txt_privModelo.Text, txt_privMarca.Text));
            lista_choferes();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            dtg_TRANSportista.ItemsSource = transportista_obj.ListarTransportistas_filtro(txt_nombre.Text, cmb_tipodoc.Text, txt_documento.Text, txt_Numeromtc.Text, 
                txt_Direccionfisacal.Text);
        }

        private void btn_privFind_Click(object sender, RoutedEventArgs e)
        {
            dtgChoferes.ItemsSource = transportista_obj.ListarChoferes_Filtro(txt_privNombre.Text, cmb_privTipodoc.Text, txt_privDoc.Text, txt_privTelefono.Text, txt_privLicencia.Text,
                txt_privPlaca.Text, txt_privModelo.Text, txt_privMarca.Text);
        }
    }
}
