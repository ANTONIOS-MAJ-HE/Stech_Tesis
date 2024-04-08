using ST_Entidades;
using ST_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Lógica de interacción para P_comparativa.xaml
    /// </summary>
    public partial class P_comparativa : Window
    {
        n_Comparativa comparativaOBJ = new n_Comparativa();
        n_TipoCambio tipoCambio = new n_TipoCambio();
        double TC = 3.9;
        public P_comparativa()
        {
            InitializeComponent();
            comparativaOBJ.Carga();
            dtg_Comparativa.ItemsSource = comparativaOBJ.listaComparacion();
            TC = Convert.ToDouble(tipoCambio.MostrarCambio(DateTime.Now.ToString("yyyy-MM-dd")));
        }
        private void Filtratabla()
        {
            dtg_Comparativa.ItemsSource = comparativaOBJ.listaComparacionFiltro(txt_Partnumb.Text);
        }

        private void btn_busqueda_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Partnumb.Text!="")
            {
                Filtratabla();
                e_Ratios ratios = comparativaOBJ.CalculaRatio(txt_Partnumb.Text, 3.90);
                List<e_Ratios> lista = new List<e_Ratios> { ratios };
                dtg_Ratios.ItemsSource = lista;
            }
            else
            {
                dtg_Comparativa.ItemsSource=comparativaOBJ.ListaBusqueda(txt_producto.Text);
            }
        }

        private void btn_carga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(comparativaOBJ.CargaManual());
            dtg_Comparativa.ItemsSource = comparativaOBJ.listaComparacion();
        }

        private void txt_producto_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtg_Comparativa.ItemsSource = comparativaOBJ.ListaBusqueda(txt_producto.Text);
        }

        private void dtg_Comparativa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e_Comparativa comp = dtg_Comparativa.SelectedItem as e_Comparativa;
            if (comp != null)
            {
                e_Ratios ratios = comparativaOBJ.CalculaRatio(comp.PARTNUMBER, TC);
                List<e_Ratios> lista = new List<e_Ratios> { ratios };
                dtg_Ratios.ItemsSource = lista;
            }
        }

        private void btn_Goback_Click(object sender, RoutedEventArgs e)
        {
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_AllRatios_Click(object sender, RoutedEventArgs e)
        {
            //kys bozo
            dtg_Ratios.ItemsSource = comparativaOBJ.ListaRatios(TC);
        }
    }
}
