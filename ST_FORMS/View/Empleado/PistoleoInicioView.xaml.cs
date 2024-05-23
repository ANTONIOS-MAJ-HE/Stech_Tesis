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
    /// Lógica de interacción para PistoleoInicioView.xaml
    /// </summary>
    public partial class PistoleoInicioView : UserControl
    {
        n_Pistoleo obj_pistoleo = new n_Pistoleo();
        public PistoleoInicioView()
        {
            InitializeComponent();
            Cargar_desp_nuevo();
            Listar_pendientes();
        }
        public void Cargar_desp_nuevo()
        {
            obj_pistoleo.Cargar_desp_nuevo();
        }
        public void Listar_pendientes()
        {
            dtg_Pendientes_.ItemsSource = obj_pistoleo.Lista_pendiente_dsp(txtCanal.Text, txtProducto.Text, txtNroOc.Text, txtMinicod.Text, TXTFECHA.Text);
            dtg_cantidad.ItemsSource = obj_pistoleo.Cuenta_pendiente_dsp();

        }
        //private void button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    frm_Inicio frm = new frm_Inicio();
        //    this.Close();
        //    frm.ShowDialog();
        //}

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Listar_pendientes();
        }

        private void dtg_Pendientes__SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    frm_Pistoleo_Cantidad frm = new frm_Pistoleo_Cantidad();
        //    this.Close();
        //    frm.ShowDialog();
        //}

        //private void button_Copy2_Click(object sender, RoutedEventArgs e)
        //{
        //    frm_Pistoleo_rapido frm = new frm_Pistoleo_rapido();
        //    this.Close();
        //    frm.ShowDialog();
        //}
    }
}
