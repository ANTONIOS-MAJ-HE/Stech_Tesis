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
using ST_Entidades;
using ST_Datos;
using ST_Negocio;


namespace ST_FORMS
{
    /// <summary>
    /// Interaction logic for frm_Inicio.xaml
    /// </summary>
    public partial class frm_Inicio : Window
    {
        public frm_Inicio()
        {
            InitializeComponent();
            tipocambio();
        }

        public void tipocambio()
        {
            //Consulta la API por el tipo de cambio
            d_Api api_Cambio = new d_Api();
            dynamic respuesta = api_Cambio.Get("https://api.apis.net.pe/v1/tipo-cambio-sunat");
            //Crea la entidad Tipo_cambio
            e_Tipo_cambio tipo_Cambio = new e_Tipo_cambio();
            tipo_Cambio.FECHA = Convert.ToString(respuesta.fecha);
            tipo_Cambio.DIA_ORIGEN = Convert.ToDouble(DateTime.Now.Day);
            tipo_Cambio.VENTA_ORIGEN = Convert.ToDouble(respuesta.venta);
            tipo_Cambio.COMPRA_ORIGEN = Convert.ToDouble(respuesta.compra);
            //Crea la entidad de planta
            n_TipoCambio d_TipoCambio = new n_TipoCambio();
            //Verifica si ya se añadio el tipo de cambio de hoy
            try
            {
                d_TipoCambio.newCambio(tipo_Cambio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           frm_Incidencias form = new frm_Incidencias();
            //Application.Current.MainWindow = new frm_Incidencias();

            //Application.Current.MainWindow.Show();
            //Application.Current.MainWindow.Focus();
            this.Close();
            form.ShowDialog();
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            frm_NvoProd frm = new frm_NvoProd();
            this.Close();
            frm.ShowDialog();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            frm_Entradas frm = new frm_Entradas();
            this.Close();
            frm.ShowDialog();
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            frm_Pedidos frm = new frm_Pedidos();
            this.Close();
            frm.ShowDialog();
        }

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {
            frm_Salidas frm = new frm_Salidas();
            this.Close();
            frm.ShowDialog();
        }

        private void button_Copy4_Click(object sender, RoutedEventArgs e)
        {
            frm_Planta frm = new frm_Planta();
            this.Close();
            frm.ShowDialog();
        }

        private void button_Copy5_Click(object sender, RoutedEventArgs e)
        {
            frm_Pistoleo frm = new frm_Pistoleo();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_Alertas_Stock_Click(object sender, RoutedEventArgs e)
        {
            frm_Alerta_Stock frm = new frm_Alerta_Stock();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_Alertas_Stock_Copy_Click(object sender, RoutedEventArgs e)
        {
            frm_Fact_OC frm = new frm_Fact_OC();
            this.Close();
            frm.ShowDialog();
        }

        private void button_Copy6_Click(object sender, RoutedEventArgs e)
        {
            frm_Actualizar_prod frm = new frm_Actualizar_prod();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_tipoCambio_Click(object sender, RoutedEventArgs e)
        {
            frm_TipoCambio frm = new frm_TipoCambio();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_Consolidados_Click(object sender, RoutedEventArgs e)
        {
            frm_Consolidados frm = new frm_Consolidados();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_Clientes_Click(object sender, RoutedEventArgs e)
        {
            frm_clientes frm = new frm_clientes();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_Guias_Click(object sender, RoutedEventArgs e)
        {
            frm_SagaGuias frm = new frm_SagaGuias();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_transportista_Click(object sender, RoutedEventArgs e)
        {
            frm_transportista frm = new frm_transportista();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_GuiasOficina_Click(object sender, RoutedEventArgs e)
        {
            frm_GuiasOficina frm = new frm_GuiasOficina();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_facturacion_Click(object sender, RoutedEventArgs e)
        {
            frm_facturacion frm = new frm_facturacion();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_ratio_Click(object sender, RoutedEventArgs e)
        {
            P_comparativa frm = new P_comparativa();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_Kardex_Click(object sender, RoutedEventArgs e)
        {
            Form_Kardex frm = new Form_Kardex();
            this.Close();
            frm.ShowDialog();
        }
        //agregando Conecta
        private void btn_GuiasC_Click(object sender, RoutedEventArgs e)
        {
            frm_GuiasConecta frm = new frm_GuiasConecta();
            this.Close();
            frm.ShowDialog();
        }
    }
}
