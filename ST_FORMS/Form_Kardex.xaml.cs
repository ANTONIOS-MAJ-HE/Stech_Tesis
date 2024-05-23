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
    /// Interaction logic for Form_Kardex.xaml
    /// </summary>
    public partial class Form_Kardex : UserControl
    {
        n_Kardex n_Kardex = new n_Kardex();
        public Form_Kardex()
        {
            InitializeComponent();
        }

        private void btn_Buscar_Click(object sender, RoutedEventArgs e)
        {
            dtgKardex.ItemsSource= n_Kardex.Lista_kardex_codigo(txtBuscar.Text);
        }

        private void btn_Act_Click(object sender, RoutedEventArgs e)
        {
            n_Kardex.Actualizar_kardex(txt_act.Text);
        }
    }
}
