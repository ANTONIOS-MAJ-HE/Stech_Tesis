using ST_Entidades;
using ST_Entidades.Rol;
using ST_FORMS.ViewModel.Comunes;
using ST_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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
using static ST_FORMS.View.Admin.UserView;

namespace ST_FORMS.View.Empleado
{
    /// <summary>
    /// Lógica de interacción para SagaGuiasView.xaml
    /// </summary>
    public partial class SagaGuiasView : UserControl
    {
        private readonly MainViewModel _mainViewModel;
        n_Guias guias_obj = new n_Guias();
        string NRO_OC = "";
        public SagaGuiasView(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            InitializeComponent();
            actualizarGuias();
            mostrarGuias();
        }
        public void mostrarGuias()
        {
            dtgGuias.ItemsSource = guias_obj.ListarGuias();
            contarGuias();

        }
        public void actualizarGuias()
        {
            guias_obj.añadirGuias();
        }
        private void contarGuias()
        {
            List<e_Guias> guiasTotal = dtgGuias.ItemsSource as List<e_Guias>;
            HashSet<string> GuiasNorepetidas = new HashSet<string>();
            foreach (e_Guias guia in guiasTotal)
            {
                GuiasNorepetidas.Add(guia.NRO_OC);
            }
            List<string> guiasPendientes = GuiasNorepetidas.ToList();
            lblCantidad.Content = "Cantidad de pedidos: " + Convert.ToString(guiasPendientes.Count);
        }
        private void dtgGuias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e_Guias guia = dtgGuias.SelectedItem as e_Guias;
            if (guia != null)
            {
                txtObsv.Text = guia.OBSERVACION.ToString();
                txtMTC.Text = guia.NUMERO_MTC.ToString();
                txtDirLle.Text = guia.DIRECCION_LLEGADA.ToString();
                txtNombreTrans.Text = guia.NOMBRE_TRANSPORTISTA.ToString();
                if (txtNroOcs.Text == "")
                {
                    txtNroOcs.Text = guia.NRO_OC.ToString();
                }
                else
                {
                    txtNroOcs.Text += "," + guia.NRO_OC.ToString();
                }
                NRO_OC = guia.NRO_OC.ToString();
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(guias_obj.actualizarEU(txtEOT.Text, txtNroOcs.Text));
            mostrarGuias();
        }     

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_NROOC.Text != "")
            {
                dtgGuias.ItemsSource = guias_obj.buscarOC(txt_NROOC.Text);
                contarGuias();
            }
            else
            {
                DateTime fechaF = Convert.ToDateTime(dtFecha.SelectedDate);
                dtgGuias.ItemsSource = guias_obj.buscarGuias(fechaF.ToString("yyyy-MM-dd 00:00:00.000"));
                contarGuias();
            }
        }

        private void btn_enviar_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Convert.ToString(guias_obj.Enviar_Guia(NRO_OC)), "RESPUESTA DE LA API");
            e_RespuestaJsonGuias resp = guias_obj.Enviar_Guia(NRO_OC);
            if (resp.success == true)
            {
                MessageBox.Show("Guia NRO: " + NRO_OC + " a sido emitida", "Facturado correctamente");
                guias_obj.GuardarNumero(resp.data.number, NRO_OC);
            }
            else
            {
                MessageBox.Show("Guia NRO: " + NRO_OC + " NO a sido emitida", "Facturado Incorrectamente", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //MessageBox.Show(Convert.ToString(resp), "RESPUESTA DE LA API");
            mostrarGuias();
        }

        private void btn_enviarTodo_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Emitir todas las guias?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("No se emitio ninguna guia");
            }
            else
            {
                List<e_Guias> emisionTotal = dtgGuias.ItemsSource as List<e_Guias>;
                HashSet<string> GuiasNorepetidas = new HashSet<string>();
                foreach (e_Guias guias in emisionTotal)
                {
                    GuiasNorepetidas.Add(guias.NRO_OC);
                }
                List<string> facturasPendientes = GuiasNorepetidas.ToList();
                foreach (string guia in facturasPendientes)
                {
                    e_RespuestaJsonGuias resp = guias_obj.Enviar_Guia(guia);
                    //MessageBox.Show(Convert.ToString(JsonConvert.SerializeObject(resp)), "RESPUESTA DE LA API");
                    if (resp.success == true)
                    {
                        MessageBox.Show("Guia NRO: " + guia + " a sido emitida", "Facturado correctamente");
                        guias_obj.GuardarNumero(resp.data.number, guia);
                    }
                    else
                    {
                        MessageBox.Show("Guia NRO: " + guia + " NO a sido emitida", "Facturado Incorrectamente", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                    mostrarGuias();
                }
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> emisionTotal = txtNroOcs.Text.Split(',').ToList();
            HashSet<string> GuiasNorepetidas = new HashSet<string>();
            foreach (string guias in emisionTotal)
            {
                GuiasNorepetidas.Add(guias);
            }
            List<string> facturasPendientes = GuiasNorepetidas.ToList();
            foreach (string guia in facturasPendientes)
            {
                e_RespuestaJsonGuias resp = guias_obj.Enviar_Guia(guia);
                guias_obj.GuardarNumero(resp.data.number, guia);
                if (resp.success == true)
                {
                    MessageBox.Show("Guia NRO: " + guia + " a sido emitida", "Facturado correctamente");
                }
                else
                {
                    MessageBox.Show("Guia NRO: " + guia + " NO a sido emitida", "Facturado Incorrectamente", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                //MessageBox.Show(Convert.ToString(JsonConvert.SerializeObject(resp)), "RESPUESTA DE LA API");
                mostrarGuias();
            }
        }
    }
}
