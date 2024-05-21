using ST_Datos;
using ST_Entidades;
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
    /// Lógica de interacción para InicioView.xaml
    /// </summary>
    public partial class InicioView : UserControl
    {
        private n_TipoCambio tipoCambio;

        public InicioView()
        {
            InitializeComponent();
            tipoCambio = new n_TipoCambio();
            tipocambio();
            Listar_cambios();
        }

        public void tipocambio()
        {
            d_Api api_Cambio = new d_Api();
            dynamic respuesta = api_Cambio.Get("https://api.apis.net.pe/v1/tipo-cambio-sunat");
            e_Tipo_cambio tipo_Cambio = new e_Tipo_cambio
            {
                FECHA = Convert.ToString(respuesta.fecha),
                DIA_ORIGEN = DateTime.Now.Day,
                VENTA_ORIGEN = Convert.ToDouble(respuesta.venta),
                COMPRA_ORIGEN = Convert.ToDouble(respuesta.compra)
            };

            try
            {
                tipoCambio.newCambio(tipo_Cambio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Listar_cambios()
        {
            List<e_Tipo_cambio> listaCambio = tipoCambio.listaCambios();
            foreach (e_Tipo_cambio item in listaCambio)
            {
                dgvData.Items.Add(new e_Tipo_cambio
                {
                    FECHA = item.FECHA,
                    DIA_ORIGEN = item.DIA_ORIGEN,
                    VENTA_ORIGEN = item.VENTA_ORIGEN,
                    COMPRA_ORIGEN = item.COMPRA_ORIGEN
                });
            }

        }

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            d_Api api_Cambio = new d_Api();
            dynamic respuesta = api_Cambio.Get("https://api.apis.net.pe/v1/tipo-cambio-sunat");
            e_Tipo_cambio tipo_Cambio = new e_Tipo_cambio
            {
                FECHA = Convert.ToString(respuesta.fecha),
                DIA_ORIGEN = DateTime.Now.Day,
                VENTA_ORIGEN = Convert.ToDouble(respuesta.venta),
                COMPRA_ORIGEN = Convert.ToDouble(respuesta.compra)
            };

            try
            {
                tipoCambio.newCambio(tipo_Cambio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Listar_cambios();
        }

        private void btn_Agregar_filtro_Click(object sender, RoutedEventArgs e)
        {
            string fecha = "?fecha=" + cl_fecha.SelectedDate.Value.ToString("yyyy-MM-dd");
            d_Api api_Cambio = new d_Api();
            dynamic respuesta = api_Cambio.Get("https://api.apis.net.pe/v1/tipo-cambio-sunat", fecha);
            e_Tipo_cambio tipo_Cambio = new e_Tipo_cambio
            {
                FECHA = Convert.ToString(respuesta.fecha),
                DIA_ORIGEN = DateTime.Now.Day,
                VENTA_ORIGEN = Convert.ToDouble(respuesta.venta),
                COMPRA_ORIGEN = Convert.ToDouble(respuesta.compra)
            };

            try
            {
                tipoCambio.newCambio(tipo_Cambio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Listar_cambios();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fecha = cl_fecha.SelectedDate.Value.ToString("yyyy-MM-dd");
                dgvData.ItemsSource = tipoCambio.listaCambios(fecha);
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
                dgvData.ItemsSource = tipoCambio.listaCambiosM(fecha);
            }
            catch
            {
                Listar_cambios();
            }
        }
    }
}
