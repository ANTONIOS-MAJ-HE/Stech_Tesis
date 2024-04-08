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
using ST_Negocio;
using ST_Datos;

namespace ST_FORMS
{
    /// <summary>
    /// Interaction logic for frm_TipoCambio.xaml
    /// </summary>
    public partial class frm_TipoCambio : Window
    {
        n_TipoCambio tipoCambio = new n_TipoCambio();
        public frm_TipoCambio()
        {
            InitializeComponent();
            Listar_cambios();
        }

        private void Listar_cambios()
        {
            dtg_tipoCambio.ItemsSource = tipoCambio.listaCambios();
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
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
            //Crea la entidad de cambio
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
            Listar_cambios();
        }

        private void btn_Agregar_filtro_Click(object sender, RoutedEventArgs e)
        {
            //Recoge la fecha del calendario
            string fecha = "?fecha=" + cl_fecha.SelectedDate.Value.ToString("yyyy-MM-dd");
            //Consulta la API por el tipo de cambio
            d_Api api_Cambio = new d_Api();
            dynamic respuesta = api_Cambio.Get("https://api.apis.net.pe/v1/tipo-cambio-sunat", fecha);
            //Crea la entidad Tipo_cambio
            e_Tipo_cambio tipo_Cambio = new e_Tipo_cambio();
            tipo_Cambio.FECHA = Convert.ToString(respuesta.fecha);
            DateTime dt = Convert.ToDateTime(respuesta.fecha);
            tipo_Cambio.DIA_ORIGEN = Convert.ToDouble(dt.Day);
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
            Listar_cambios();
        }

        private void btn_Buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fecha = cl_fecha.SelectedDate.Value.ToString("yyyy-MM-dd");
                dtg_tipoCambio.ItemsSource = tipoCambio.listaCambios(fecha);
            }
            catch
            {
                Listar_cambios();
            }

        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            Listar_cambios();
        }

        private void btn_Buscar_mes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fecha = cl_fecha.SelectedDate.Value.ToString("yyyy-MM");
                dtg_tipoCambio.ItemsSource = tipoCambio.listaCambiosM(fecha);
            }
            catch
            {
                Listar_cambios();
            }
        }
    }
}
