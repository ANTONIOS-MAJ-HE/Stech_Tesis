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

namespace ST_FORMS
{
    /// <summary>
    /// Interaction logic for frm_Alerta_Stock.xaml
    /// </summary>
    public partial class frm_Alerta_Stock : Window
    {
        n_Alerta_Stock alerta_OBJ = new n_Alerta_Stock();
        public frm_Alerta_Stock()
        {
            InitializeComponent();
            Lista_alertas();
        }
        public void Lista_alertas()
        {
            dtg_Vista.ItemsSource = alerta_OBJ.Lista_alerta_total();
            lblcant_prod.Content = Convert.ToString(dtg_Vista.Items.Count - 1);
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void dtg_Vista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblcant_prod.Content = Convert.ToString(dtg_Vista.Items.Count-1);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            dtg_Vista.ItemsSource = alerta_OBJ.Lista_alerta(txtCantidad.Text);
            lblcant_prod.Content = Convert.ToString(dtg_Vista.Items.Count - 1);
        }

        private void btn_Limp_Copy1_Click(object sender, RoutedEventArgs e)
        {
            txtCantidad.Text = "";
            Lista_alertas();
        }
    }
}
