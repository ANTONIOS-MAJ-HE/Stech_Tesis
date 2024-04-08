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
using ST_Datos;

namespace ST_FORMS
{
    /// <summary>
    /// Lógica de interacción para frm_clientes.xaml
    /// </summary>
    public partial class frm_clientes : Window
    {
        n_Cliente clientes_obj = new n_Cliente();
        int id_cliente=0;
        public frm_clientes()
        {
            InitializeComponent();
            lst_clientes();
            lst_ubigeos();
            addcmb();
            lst_contactos();
        }
        public void addcmb()
        {
            cmbTipodoc.Items.Add("DNI");
            cmbTipodoc.Items.Add("RUC");
            cmbTipodoc.SelectedIndex = 1;
        }
        public void lst_contactos()
        {
            dtgContactos.ItemsSource=clientes_obj.listar_contactos();
        }
        public void lst_clientes()
        {
            dtg_Clientes.ItemsSource = clientes_obj.Listar_Clientes();
        }
        public void lst_ubigeos()
        {
            dtUbigeo.ItemsSource=clientes_obj.listar_Ubigeos();
        }
        public void clean_cliente()
        {
            txtNomCliente.Text = "";
            txtdoc.Text = "";
            txtUbigeo.Text = "";
            txtDirEntCliente.Text = "";
            txtCodUbigeo.Text = "";
            txtDirFisCliente.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtCodUbigeo.Text = "";
        }
        public void clean_contacto()
        {
            txt_ContNom.Text = "";
            txt_ContIdCl.Text = "";
            txt_ContCorr.Text = "";
            txt_ContObv.Text = "";
            txt_ContTelf.Text = "";
            txt_ContNro.Text = "1";
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            //Boton para volver al Index
            frm_Inicio frm = new frm_Inicio();
            this.Close();
            frm.ShowDialog();
        }

        private void btn_Insertar_Click(object sender, RoutedEventArgs e)
        {

            if (txtNomCliente.Text=="" || txtdoc.Text=="" || cmbTipodoc.Text=="" || txtUbigeo.Text=="" || txtDirEntCliente.Text=="" || txtCodUbigeo.Text=="")
            {
                //Crea mensaje de los campos faltantes
                string faltantes = "";
                faltantes += txtNomCliente.Text == "" ? "El nombre del cliente":"";
                faltantes += txtdoc.Text == "" ? ", El documento del cliente " : "";
                faltantes += cmbTipodoc.Text == "" ? ", El Tipo de documento del cliente " : "";
                faltantes += txtUbigeo.Text == "" ? ", El ubigeo del cliente " : "";
                faltantes += txtDirEntCliente.Text == "" ? ", la Direccion de entrega del cliente " : "";
                faltantes += txtCodUbigeo.Text == "" ? ", El codigo ubigeo del cliente" : "";
                MessageBox.Show("por favor rellene los campos: " + faltantes);
            }
            else
            {
                //añade un cliente y muestra el mensaje
                MessageBox.Show(clientes_obj.Añadir_Cliente(txtNomCliente.Text, txtDirFisCliente.Text, txtDirEntCliente.Text, cmbTipodoc.Text, txtdoc.Text, txtTelefono.Text
                , txtUbigeo.Text, txtCorreo.Text,txtCodUbigeo.Text));
            }
            lst_clientes();
            clean_cliente();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dtg_Clientes.ItemsSource = clientes_obj.Filtrar_Cliente(txtNomCliente.Text, txtDirFisCliente.Text, txtDirEntCliente.Text, cmbTipodoc.Text, txtdoc.Text, txtTelefono.Text
                , txtUbigeo.Text, txtCorreo.Text,txtCodUbigeo.Text);
        }

        private void dtUbigeo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e_Ubigeo ubigeo = dtUbigeo.SelectedItem as e_Ubigeo; 

            if (ubigeo != null)
            {
                //Combina el ubigeo para el textBox
                txtCodUbigeo.Text = ubigeo.UBIGEO;
                txtUbigeo.Text = ubigeo.DEPARTAMENTO + "/" + ubigeo.PROVINCIA + "/" + ubigeo.DISTRITO;
            }
        }

        private void txtUbigeo_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtUbigeo.ItemsSource = clientes_obj.listar_Ubigeos(txtUbigeo.Text);
        }

        private void txtNomCliente_KeyDown(object sender, KeyEventArgs e)
        {
            //Filtra con Enter
            switch (Convert.ToInt32((char)e.Key))
            {
                case 13:
                    dtg_Clientes.ItemsSource = clientes_obj.Filtrar_Cliente(txtNomCliente.Text, txtDirFisCliente.Text, txtDirEntCliente.Text, cmbTipodoc.Text, txtdoc.Text, txtTelefono.Text
                , txtUbigeo.Text, txtCorreo.Text, txtCodUbigeo.Text);
                    break;
                default:
                    break;
            }
        }

        private void dtg_Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e_Cliente cliente= dtg_Clientes.SelectedItem as e_Cliente; 
            if (cliente != null)
            {
                txt_ContIdCl.Text = Convert.ToString(cliente.ID_CLIENTE);
                txt_ContNro.Text = clientes_obj.ultimo_contacto(txt_ContIdCl.Text);
                    if (cbx_editar.IsChecked==true)
                    {
                        txtNomCliente.Text = cliente.NOMBRE_RAZON_SOCIAL.ToString();
                        txtdoc.Text=cliente.NRO_DOCUMENTO.ToString();
                        cmbTipodoc.SelectedIndex = cliente.TIPO_DOCUMENTO == "RUC" ? 0 : 1;
                        txtCorreo.Text = cliente.CORREO.ToString();
                        txtDirEntCliente.Text = cliente.DIRECCION_ENTREGA.ToString();
                        txtDirFisCliente.Text = cliente.DIRECCION_FISCAL.ToString();
                        txtTelefono.Text= cliente.TELEFONO.ToString();
                        txtUbigeo.Text = cliente.UBIGEO.ToString();
                        txtCodUbigeo.Text=cliente.COD_UBIGEO.ToString();
                        id_cliente = Convert.ToInt32(cliente.ID_CLIENTE)==0? 1: Convert.ToInt32(cliente.ID_CLIENTE);
                    }
            }
        }

        private void btnContAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txt_ContNom.Text == ""  || txt_ContIdCl.Text == "" || txt_ContTelf.Text=="")
            {
                string faltantes = "";
                faltantes += txt_ContNom.Text == "" ? "El nombre del contacto" : "";
                faltantes += txt_ContTelf.Text == "" ? "El numero de telefono del contacto" : "";
                faltantes += txt_ContIdCl.Text == "" ? ", La id del cliente " : "";
                MessageBox.Show("por favor rellene los campos: " + faltantes);
            }
            else
            {
                MessageBox.Show(clientes_obj.añadir_contacto(txt_ContNom.Text,txtContDoc.Text,txt_ContObv.Text,txt_ContTelf.Text,txt_ContCorr.Text,
                    Convert.ToInt32(txt_ContNro.Text),Convert.ToInt32(txt_ContIdCl.Text)));
            }
            lst_contactos();
            clean_contacto();
        }

        private void btnContFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dtgContactos.ItemsSource = clientes_obj.listar_contactos_Filtro(txt_ContNom.Text, txtContDoc.Text, txt_ContObv.Text, txt_ContTelf.Text, txt_ContCorr.Text,
                     txt_ContIdCl.Text==""? 0:Convert.ToInt32(txt_ContIdCl.Text));
                txt_ContNro.Text = (Convert.ToInt32(txt_ContNro.Text) + 1).ToString();
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }  
        }

        private void btn_Modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbx_editar.IsChecked==true)
                {
                    MessageBox.Show(clientes_obj.Actualizar_Cliente(txtNomCliente.Text, txtDirFisCliente.Text, txtDirEntCliente.Text, cmbTipodoc.Text, txtdoc.Text, txtTelefono.Text
                , txtUbigeo.Text, txtCorreo.Text, txtCodUbigeo.Text,id_cliente));
                }
            }catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                lst_clientes();
            }
        }

        private void txt_ContIdCl_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_ContNro.Text = clientes_obj.ultimo_contacto(txt_ContIdCl.Text);
        }

        private void btn_Limpiar_cl_Click(object sender, RoutedEventArgs e)
        {
            clean_cliente();
        }

        private void btn_Limpiar_cn_Click(object sender, RoutedEventArgs e)
        {
            clean_contacto();
        }

        private void txt_ContNom_KeyDown(object sender, KeyEventArgs e)
        {
            //Filtra con Enter
            switch (Convert.ToInt32((char)e.Key))
            {
                case 13:
                    dtgContactos.ItemsSource = clientes_obj.listar_contactos_Filtro(txt_ContNom.Text, txtContDoc.Text, txt_ContObv.Text, txt_ContTelf.Text, txt_ContCorr.Text,
                     txt_ContIdCl.Text == "" ? 0 : Convert.ToInt32(txt_ContIdCl.Text));
                    break;
                default:
                    break;
            }
        }

        private void dtgContactos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbx_editar_cont.IsChecked==true)
            {
                e_Contacto contacto = dtgContactos.SelectedItem as e_Contacto;
                if (contacto != null)
                {
                    txt_ContNom.Text = contacto.NOMBRE;
                    txtContDoc.Text = contacto.DOCUMENTO;
                    txt_ContTelf.Text = contacto.TELEFONO;
                    txt_ContObv.Text = contacto.OBSERVACION;
                    txt_ContCorr.Text = contacto.CORREO;
                }
            }
        }

        private void btnContUpdt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_BusCliente_Click(object sender, RoutedEventArgs e)
        {
            //Consulta el RUC por la API sunat 
            d_Api consulta = new d_Api();
            if (cmbTipodoc.SelectedIndex==1 && txtdoc.Text.Length==11)
            {
                dynamic respuesta = consulta.Get("https://api.apis.net.pe/v1/ruc?numero=", txtdoc.Text);
                if (respuesta != null)
                {
                    txtNomCliente.Text = respuesta.nombre;
                    txtDirFisCliente.Text = respuesta.direccion + " " + respuesta.despartamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                    txtCodUbigeo.Text = respuesta.ubigeo;
                    txtUbigeo.Text = respuesta.departamento + "/" + respuesta.provincia + "/" + respuesta.distrito;
                }
            }
            else if(cmbTipodoc.SelectedIndex==0 && txtdoc.Text.Length==8)
            {
                dynamic respuesta = consulta.Get("https://api.apis.net.pe/v1/dni?numero=", txtdoc.Text);
                if (respuesta != null)
                {
                    txtNomCliente.Text = respuesta.nombre;
                    txtDirFisCliente.Text = respuesta.direccion + " " + respuesta.despartamento + "-" + respuesta.provincia + "-" + respuesta.distrito;
                    txtCodUbigeo.Text = respuesta.ubigeo;
                    txtUbigeo.Text = respuesta.departamento + "/" + respuesta.provincia + "/" + respuesta.distrito;
                }
            }
            else
            {
                MessageBox.Show("NUMERO INGRESADO NO VALIDO", "ERROR DE USUARIO", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cbx_editar_Click(object sender, RoutedEventArgs e)
        {
            if (cbx_editar.IsChecked==true) {
                MessageBox.Show("Modo de edicion activado");
            }
            else
            {
                MessageBox.Show("Modo de edicion desactivado");
            }
        }
    }
}
