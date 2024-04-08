using Newtonsoft.Json;
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
using System.Windows.Shapes;

namespace ST_FORMS
{
    /// <summary>
    /// Lógica de interacción para frm_GuiasOficina.xaml
    /// </summary>
    public partial class frm_GuiasOficina : Window
    {
        n_Cliente cliente_OBJ = new n_Cliente();
        n_transportista transportista_OBJ = new n_transportista();
        n_Pedido pedido_OBJ = new n_Pedido();
        n_GuiaOficina guias_OBJ = new n_GuiaOficina();
        string NRO_OC = "";
        public frm_GuiasOficina()
        {
            InitializeComponent();
            fill_ComboBox();
        }
        public void Lista_Guia(string nro = "0")
        {
            dtgGuias.ItemsSource = guias_OBJ.MostrarGuias(nro);
        }
        public void Lista_Guia_Priv(string nro = "0")
        {
            dtgGuias.ItemsSource = guias_OBJ.MostrarGuiasPriv(nro);
        }
        public void limpiar()
        {
            txt_NroPedido.Text = "";
            txt_DocTransportista.Text = "";
            txt_DescripcionMotivo.Text = "";
            txt_CodigoUbigeo.Text = "";
            txt_CorreoReceptor.Text = "";
            txt_DireccionLlegada.Text = "";
            txt_DirReceptor.Text = "";
            txt_DocReceptor.Text = "";
            txt_Licencia.Text = "";
            txt_NumeroMTC.Text = "";
            txt_Peso.Text = "";
            txt_Placa.Text = "";
            txt_TelefonoReceptor.Text = "";
        }
        public void fill_ComboBox()
        {
            cmb_TipoDoc.Items.Add("RUC");
            cmb_TipoDoc.Items.Add("DNI");
            cmb_TipoDoc.SelectedIndex = 0;

            cmb_DocTransportista.Items.Add("RUC");
            cmb_DocTransportista.Items.Add("DNI");
            cmb_DocTransportista.SelectedIndex = 0;

            cmb_TipoTransportista.Items.Add("PUBLICO");
            cmb_TipoTransportista.Items.Add("PRIVADO");
            cmb_TipoTransportista.SelectedIndex = 0;
        }

        private void btn_BuscarReceptor_Click(object sender, RoutedEventArgs e)
        {
            dp_Clientes.Visibility = Visibility.Visible;
            dtg_Clientes.ItemsSource = cliente_OBJ.Listar_Clientes();
        }

        private void dtg_Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e_Cliente cliente = dtg_Clientes.SelectedItem as e_Cliente;

            if (cliente != null)
            {
                txt_NombreReceptor.Text = cliente.NOMBRE_RAZON_SOCIAL.ToString();
                txt_DocReceptor.Text = cliente.NRO_DOCUMENTO.ToString();
                cmb_TipoDoc.SelectedIndex = cliente.TIPO_DOCUMENTO == "RUC" ? 0 : 1;
                txt_CorreoReceptor.Text = cliente.CORREO.ToString();
                txt_DireccionLlegada.Text = cliente.DIRECCION_ENTREGA.ToString();
                txt_DirReceptor.Text = cliente.DIRECCION_FISCAL.ToString();
                txt_TelefonoReceptor.Text = cliente.TELEFONO.ToString();
                txt_CodigoUbigeo.Text = cliente.COD_UBIGEO.ToString();
                dp_Clientes.Visibility = Visibility.Hidden;
            }
        }

        private void btn_BuscarTransportista_Click(object sender, RoutedEventArgs e)
        {
            dp_Transportista.Visibility = Visibility.Visible;
            if (cmb_TipoTransportista.SelectedIndex == 0)
            {
                dtg_Transportista.ItemsSource = transportista_OBJ.ListarTransportistas();
            }
            else if (cmb_TipoTransportista.SelectedIndex == 1)
            {
                dtg_Transportista.ItemsSource = transportista_OBJ.ListarChoferes();
            }
        }
        private void dtg_Transportista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_TipoTransportista.SelectedIndex == 0)
            {
                e_transportista transportista = dtg_Transportista.SelectedItem as e_transportista;
                if (transportista != null)
                {
                    txt_NombreTransportista.Text = transportista.NOMBRE.ToString();
                    cmb_DocTransportista.SelectedIndex = transportista.TIPO_DOCUMENTO == "RUC" ? 0 : 1;
                    txt_DocTransportista.Text = transportista.DOCUMENTO.ToString();
                    txt_NumeroMTC.Text = transportista.NUMERO_MTC.ToString();
                    dp_Transportista.Visibility = Visibility.Hidden;
                }
            }
            else if (cmb_TipoTransportista.SelectedIndex == 1)
            {
                e_choferes choferes = dtg_Transportista.SelectedItem as e_choferes;
                if (choferes != null)
                {
                    txt_NombreTransportista.Text = choferes.NOMBRE.ToString();
                    cmb_DocTransportista.SelectedIndex = choferes.TIPO_DOCUMENTO == "RUC" ? 0 : 1;
                    txt_DocTransportista.Text = choferes.DOCUMENTO.ToString();
                    txt_Placa.Text = choferes.NRO_PLACA.ToString();
                    txt_Licencia.Text = choferes.LICENCIA.ToString();
                    dp_Transportista.Visibility = Visibility.Hidden;
                }

            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void dtg_ubigeos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e_Ubigeo ubigeo = dtg_Ubigeos.SelectedItem as e_Ubigeo;
            if (ubigeo != null)
            {
                txt_CodigoUbigeo.Text = ubigeo.UBIGEO.ToString();
                dp_Ubigeos.Visibility = Visibility.Hidden;
            }
        }

        private void btn_BuscarUbigeo_Click(object sender, RoutedEventArgs e)
        {
            dp_Ubigeos.Visibility = Visibility.Visible;
            dtg_Ubigeos.ItemsSource = cliente_OBJ.listar_Ubigeos();
        }

        private void btn_BuscarPedido_Click(object sender, RoutedEventArgs e)
        {
            if (txt_NroPedido.Text == "")
            {
                MessageBox.Show("INGRESE EL NÚMERO DE PEDIDO");
            }
            else
            {
                List<e_ProductosxPedido> productos = pedido_OBJ.ProductosxPedido(txt_NroPedido.Text);
                if (productos != null)
                {
                    dtg_productos.ItemsSource = productos;
                    double suma = 0;
                    foreach (e_ProductosxPedido row in productos)
                    {
                        suma += (double)row.PESO*(int)row.CANTIDAD;
                    }
                    txt_Peso.Text = suma.ToString();
                }
                else
                {
                    MessageBox.Show("EL NRO de pedido no existe");
                }
            }
        }

        private void btn_Crear_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_TipoTransportista.SelectedIndex == 0)
            {
                if (txt_NroPedido.Text != "" && dt_FechaTraslado.Text != "")
                {
                    //crea una lista de los productos para la guia
                    List<e_ProductosxPedido> productos = dtg_productos.ItemsSource as List<e_ProductosxPedido>;
                    //añada la guia a la tabla
                    MessageBox.Show(guias_OBJ.añadirGuiaOficina(txt_NroPedido.Text, cmb_TipoDoc.SelectedIndex == 0 ? "6" : "1", txt_DocReceptor.Text, txt_NombreReceptor.Text,
                        txt_DirReceptor.Text, txt_CorreoReceptor.Text, txt_TelefonoReceptor.Text, txt_observacion.Text, txt_DescripcionMotivo.Text,
                        dt_FechaTraslado.Text, txt_Peso.Text, txt_CodigoUbigeo.Text, txt_DireccionLlegada.Text, "0", cmb_DocTransportista.SelectedIndex == 0 ? "6" : "1",
                        txt_DocTransportista.Text, txt_NombreTransportista.Text, txt_NumeroMTC.Text, productos));
                }
                else //Mensaje de error
                {
                    MessageBox.Show("Rellene todos los campos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                Lista_Guia(txt_NroPedido.Text);
                limpiar();
            }
            else if (cmb_TipoTransportista.SelectedIndex == 1)
            {
                if (txt_NroPedido.Text != "" && dt_FechaTraslado.Text != "")
                {
                    //crea una lista de los productos para la guia
                    List<e_ProductosxPedido> productos = dtg_productos.ItemsSource as List<e_ProductosxPedido>;
                    //añada la guia a la tabla
                    MessageBox.Show(guias_OBJ.añadirGuiaOficinaPriv(txt_NroPedido.Text, cmb_TipoDoc.SelectedIndex == 0 ? "6" : "1", txt_DocReceptor.Text, txt_NombreReceptor.Text,
                        txt_DirReceptor.Text, txt_CorreoReceptor.Text, txt_TelefonoReceptor.Text, txt_observacion.Text, txt_DescripcionMotivo.Text,
                        dt_FechaTraslado.Text, txt_Peso.Text, txt_CodigoUbigeo.Text, txt_DireccionLlegada.Text, "0", cmb_DocTransportista.SelectedIndex == 0 ? "6" : "1",
                        txt_DocTransportista.Text, txt_NombreTransportista.Text, txt_Licencia.Text, txt_Placa.Text, productos));
                }
                else
                {
                    MessageBox.Show("Rellene todos los campos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                Lista_Guia_Priv(txt_NroPedido.Text);
                limpiar();
            }
            else
            {
                MessageBox.Show("NO SE PUDO IDENTIFICAR EL TIPO DE GUIA A EMITIR", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            if (NRO_OC!="")
            {
                if (cmb_TipoTransportista.SelectedIndex==0)
                {
                    //txtJson.Text = guias_OBJ.Enviar_Guia(NRO_OC);
                    e_RespuestaJsonGuias response = guias_OBJ.Enviar_Guia(NRO_OC);
                    MessageBox.Show(Convert.ToString(JsonConvert.SerializeObject(response)));
                }
                else
                {
                    //txtJson.Text = guias_OBJ.Enviar_Guia_Priv(NRO_OC);
                    e_RespuestaJsonGuias response = guias_OBJ.Enviar_Guia_Priv(NRO_OC);
                    MessageBox.Show(Convert.ToString(JsonConvert.SerializeObject(response)));
                }
            }
            else
            {
                MessageBox.Show("Seleecione la guia a emitir", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void dtgGuias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_TipoTransportista.SelectedIndex==0)
            {
                e_Guias guia = dtgGuias.SelectedItem as e_Guias;
                if (guia != null)
                {
                    NRO_OC = guia.NRO_OC;
                }
            }
            else
            {
                e_GuiasPriv guia = dtgGuias.SelectedItem as e_GuiasPriv;
                if (guia != null)
                {
                    NRO_OC = guia.NRO_OC;
                }
            }
        }

        private void btn_Find_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_TipoTransportista.SelectedIndex == 0)
            {
                Lista_Guia(txt_NROOC.Text);;
            }
            else if (cmb_TipoTransportista.SelectedIndex == 1)
            {
                Lista_Guia_Priv(txt_NROOC.Text);
            }
        }
    }
}
