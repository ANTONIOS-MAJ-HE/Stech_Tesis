using Newtonsoft.Json;
using ST_Entidades;
using ST_Negocio;
using ST_FORMS;
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
using System.Windows.Shapes;

namespace ST_FORMS
{
    /// <summary>
    /// Lógica de interacción para frm_SagaGuias.xaml
    /// </summary>
    /// 

    ///                      produccion             produccion
    ///                      produccion 

    public partial class frm_GuiasConecta : Window
    {
        n_GuiasConecta guias_obj = new n_GuiasConecta();
        string NRO_OC = "";
        public frm_GuiasConecta()
        {
            InitializeComponent();
            actualizarGuias();
            mostrarGuias();
            fill_ComboBox();
            RazonS.SelectionChanged += RazonS_SelectionChanged;
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

            RazonS.SelectedIndex = 0; // Selecciona el primer elemento por defecto
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

        private void dtgGuias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgGuias.SelectedItem is e_Guias guia)
            {
                txt_NroOC.Text = guia.NRO_OC;
                txtFechaT.Text = guia.FECHA_TRASLADO;
                NumRuc.Text = guia.NUMERO_DOCUMENTO;
                RazonS.Text = guia.NOMBRE_CLIENTE;
                DirecC.Text = guia.DIRECCION_CLIENTE;
                txtObsv.Text = guia.OBSERVACION;
                NRO_OC = guia.NRO_OC.ToString();
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var resultado = guias_obj.actualizarGuia(txt_NroOC.Text, txtFechaT.Text, NumRuc.Text, RazonS.Text, DirecC.Text, txtObsv.Text);
                MessageBox.Show(resultado);
                mostrarGuias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Boton para volver al Index
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_NroOC.Text != "")
            {
                dtgGuias.ItemsSource = guias_obj.buscarOC(txt_NroOC.Text);
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
            //MessageBox.Show(Convert.ToString(guias_obj.Enviar_Guia(NRO_OC)), "RESPUESTA DE LA API");   //SI DESCOMENTAS ESTA CODIGO HAY DUPLICADO DE GUIAS
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
