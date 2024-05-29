using Newtonsoft.Json;
using ST_Entidades;
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

namespace ST_FORMS.View.Empleado
{
    /// <summary>
    /// Lógica de interacción para FacturacionView.xaml
    /// </summary>
    public partial class FacturacionView : UserControl
    {
        private readonly MainViewModel _mainViewModel;
        n_Facturacion factura_obj = new n_Facturacion();
        public FacturacionView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            fill_ComboBox();
            listar_pendientes();
            RazonS.SelectionChanged += RazonS_SelectionChanged;
        }

        private Dictionary<string, (string Ruc, string Direccion)> RazonData = new Dictionary<string, (string, string)>();
        public void fill_ComboBox()
        {

            // Llenando el diccionario con datos
            RazonData.Add("CONECTA RETAIL S.A.", ("20141189850", "AV. LUIS GONZALES NRO. 1315 URB. CERCADO DE CHICLAYO , CHICLAYO , CHICLAYO - LAMBAYEQUE"));
            RazonData.Add("CONECTA RETAIL SELVA S.A.C.", ("20494007488", "JR. PROSPERO NRO. 342 , IQUITOS , MAYNAS - LORETO"));

            // Añadir los RUCs al ComboBox NumRuc
            foreach (var ruc in RazonData.Keys)
            {
                RazonS.Items.Add(ruc);
            }


            cmb_canal.Items.Add("SAGA");
            cmb_canal.Items.Add("LINIO");
            cmb_canal.Items.Add("RIPLEY");
            cmb_canal.Items.Add("REAL PLAZA");
            cmb_canal.Items.Add("OFICINA");
            cmb_canal.Items.Add("KINGSTON");
            cmb_canal.Items.Add("MERCADO LIBRE");
            cmb_canal.Items.Add("JUNTOZ");
            cmb_canal.Items.Add("CATPHONE");
            cmb_canal.Items.Add("COOLBOX");
            cmb_canal.Items.Add("ARTOS");
            cmb_canal.Items.Add("FALABELLA");
            //Agregando conecta
            cmb_canal.Items.Add("CONECTA");
            cmb_canal.SelectedIndex = 0;
        }

        private void RazonS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RazonS.SelectedItem != null)
            {
                string selectedRUC = RazonS.SelectedItem.ToString();
                if (RazonData.TryGetValue(selectedRUC, out var data))
                {
                    NumRuc.Text = data.Ruc;
                    DirecC.Text = data.Direccion;
                }
            }
        }

        private void dtgFacturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgFacturas.SelectedItem is e_FacturasPendientes facturacionTotal)
            {
                RazonS.Text = facturacionTotal.Razon_Social;
                txtNroOC.Text = facturacionTotal.NRO_OC;

                if (RazonS.SelectedItem != null)
                {
                    string selectedRazonSocial = RazonS.SelectedItem.ToString();
                    if (RazonData.TryGetValue(selectedRazonSocial, out var data))
                    {
                        NumRuc.Text = data.Ruc;
                        DirecC.Text = data.Direccion;
                    }
                }
            }
        }
        //capturando los valores para editarlo las guias
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var resultado = factura_obj.actualizarGuia(txtNroOC.Text, NumRuc.Text, RazonS.Text, DirecC.Text);
                MessageBox.Show(resultado);
                listar_pendientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}");
            }
        }


        public void listar_pendientes()
        {
            //cambiarlo por switch cuando tenga ganas
            switch (cmb_canal.SelectedIndex)
            {
                case (0):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasSaga();
                    break;
                case (1):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasLinio();
                    break;
                case (2):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasRipley();
                    break;
                case (3):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasRealPlaza();
                    break;
                case (4):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasOficina();
                    break;
                case (5):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasKingston();
                    break;
                case (6):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasMercadoLibre();
                    break;
                case (7):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasJuntoz();
                    break;
                case (8):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasCatPhone();
                    break;
                case (9):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasCoolbox();
                    break;
                case (10):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasArtos();
                    break;
                case (11):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasFalabella();
                    break;
                //agregando conecta
                case (12):
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasConecta();
                    break;
            }

            contarPedidos();
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_canal.SelectedIndex == 0)
            {
                if (dt_fecha.Text != "")
                {
                    DateTime filtro = Convert.ToDateTime(dt_fecha.Text);
                    dtgFacturas.ItemsSource = factura_obj.FechalistarFacturasSaga(filtro.ToString("yyyy-MM-dd"));
                }
                else
                {
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasSaga(txtNroOC.Text);
                }
            }
            else if (cmb_canal.SelectedIndex == 1)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasLinio(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 2)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasRipley(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 3)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasRealPlaza(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 4)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasOficina(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 5)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasKingston(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 6)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasMercadoLibre(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 7)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasJuntoz(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 8)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasCatPhone(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 9)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasCoolbox(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 10)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasArtos(txtNroOC.Text);
            }
            else if (cmb_canal.SelectedIndex == 11)
            {
                dtgFacturas.ItemsSource = factura_obj.listarFacturasFalabella(txtNroOC.Text);
            }
            //agregando conecta
            else if (cmb_canal.SelectedIndex == 12)
            {
                if (dt_fecha.Text != "")
                {
                    DateTime filtro = Convert.ToDateTime(dt_fecha.Text);
                    dtgFacturas.ItemsSource = factura_obj.FechalistarFacturasConecta(filtro.ToString("yyyy-MM-dd 00:00:00.000"));
                }
                else
                {
                    dtgFacturas.ItemsSource = factura_obj.listarFacturasConecta(txtNroOC.Text);
                }
            }
            contarPedidos();
        }
        private void facturarCredito(string NRO_OC)
        {
            e_RespuestaJson response = factura_obj.Facturacion(NRO_OC, "02", cmb_canal.Text);
            txtJson.Text = Convert.ToString(JsonConvert.SerializeObject(response));
            if (response.success == true)
            {
                if (cmb_canal.SelectedIndex == 0)
                {
                    factura_obj.actualizaNroFactSaga(response.data.number, NRO_OC);
                }
                else if (cmb_canal.SelectedIndex == 1)
                {
                    factura_obj.actualizaNroFactLinio(response.data.number, NRO_OC);
                }
                else if (cmb_canal.SelectedIndex == 2)
                {
                    factura_obj.actualizaNroFactRipley(response.data.number, NRO_OC);
                }
                else if (cmb_canal.SelectedIndex == 3)
                {
                    factura_obj.actualizaNroFactRealPlaza(response.data.number, NRO_OC);
                }
                else if (cmb_canal.SelectedIndex == 5)
                {
                    factura_obj.actualizaNroFactRealPlaza(response.data.number, NRO_OC);
                }
                else if (cmb_canal.SelectedIndex == 6)
                {
                    factura_obj.actualizaNroMercado(response.data.number, NRO_OC);
                }
                else if (cmb_canal.SelectedIndex == 7)
                {
                    factura_obj.actualizaNroJuntoz(response.data.number, NRO_OC);
                }
                else if (cmb_canal.SelectedIndex == 9)
                {
                    factura_obj.actualizaNroCoolbox(response.data.number, NRO_OC);
                }
                //agregando conecta
                else if (cmb_canal.SelectedIndex == 12)
                {
                    factura_obj.actualizaNroFactConecta(response.data.number, NRO_OC);
                }
                MessageBox.Show("Factura NRO: " + NRO_OC + " a sido emitida", "Facturado correctamente", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Factura NRO: " + NRO_OC + " NO a sido emitida", "Facturado INcorrectamente", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //txtJson.Text = factura_obj.Facturacion(pendientes.NRO_OC, "02", cmb_canal.Text);
        }
        private void facturarCreditoArtos(string NRO_OC)
        {
            e_RespuestaJson response = factura_obj.Facturacion_ARTOS(NRO_OC, "02", cmb_canal.Text);
            txtJson.Text = Convert.ToString(JsonConvert.SerializeObject(response));
            if (response.success == true)
            {
                if (cmb_canal.SelectedIndex == 11)
                {
                    //factura_obj.actualizaNroFactSaga(response.data.number, NRO_OC);
                }
                //factura_obj.GuardarNroFact(response.data.number, NRO_OC);
                MessageBox.Show("Factura NRO: " + NRO_OC + " a sido emitida", "Facturado correctamente");
            }
            else
            {
                MessageBox.Show("Factura NRO: " + NRO_OC + " NO a sido emitida", "Facturado INcorrectamente", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //txtJson.Text = factura_obj.Facturacion(pendientes.NRO_OC, "02", cmb_canal.Text);
        }
        private void facturarContado(string NRO_OC)
        {
            e_RespuestaJson response = factura_obj.Facturacion_Contado(NRO_OC, "02", cmb_canal.Text);
            if (response.success == true)
            {
                txtJson.Text = Convert.ToString(JsonConvert.SerializeObject(response));
                factura_obj.GuardarNroFact(response.data.number, NRO_OC);
                MessageBox.Show("Factura NRO: " + NRO_OC + " a sido emitida", "Facturado correctamente");
            }
            else
            {
                MessageBox.Show("Factura NRO: " + NRO_OC + " NO a sido emitida", "Facturado INcorrectamente", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btn_facturar_Click(object sender, RoutedEventArgs e)
        {
            //Recoleccion de datos
            e_FacturasPendientes pendientes = dtgFacturas.SelectedItem as e_FacturasPendientes;
            if (cmb_canal.SelectedIndex == 4)
            {
                facturarContado(pendientes.NRO_OC);
            }
            else if (cmb_canal.SelectedIndex == 11)
            {
                facturarCreditoArtos(pendientes.NRO_OC);
            }
            else
            {
                facturarCredito(pendientes.NRO_OC);
            }
            listar_pendientes();
        }

        private void cmb_canal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listar_pendientes();
        }
      
        private void contarPedidos()
        {
            List<e_FacturasPendientes> facturacionTotal = dtgFacturas.ItemsSource as List<e_FacturasPendientes>;
            HashSet<string> FacturasNorepetidas = new HashSet<string>();
            foreach (e_FacturasPendientes factura in facturacionTotal)
            {
                FacturasNorepetidas.Add(factura.NRO_OC);
            }
            List<string> facturasPendientes = FacturasNorepetidas.ToList();
            lblCantidad.Content = "Cantidad de pedidos: " + Convert.ToString(facturasPendientes.Count);
        }
        private void btn_facturarTodo_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Facturar todos los pedidos?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("No se facturo");
            }
            else
            {
                List<e_FacturasPendientes> facturacionTotal = dtgFacturas.ItemsSource as List<e_FacturasPendientes>;
                HashSet<string> FacturasNorepetidas = new HashSet<string>();
                foreach (e_FacturasPendientes factura in facturacionTotal)
                {
                    FacturasNorepetidas.Add(factura.NRO_OC);
                }
                List<string> facturasPendientes = FacturasNorepetidas.ToList();
                foreach (string factura in facturasPendientes)
                {
                    if (cmb_canal.SelectedIndex == 4)
                    {
                        facturarContado(factura);
                    }
                    else if (cmb_canal.SelectedIndex == 11)
                    {
                        facturarCreditoArtos(factura);
                    }
                    else
                    {
                        facturarCredito(factura);
                    }
                }
            }
            listar_pendientes();
        }
    }
}
