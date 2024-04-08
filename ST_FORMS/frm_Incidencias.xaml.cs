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

namespace ST_FORMS
{
    /// <summary>
    /// Interaction logic for frm_Incidencias.xaml
    /// </summary>
    ///          PRODUCCION
    public partial class frm_Incidencias : Window
    {
        private n_Incidencia obj_incid = new n_Incidencia();
        private n_OrdenesCons obj_occons = new n_OrdenesCons();
        private n_Buscaminis obj_minis = new n_Buscaminis();

        e_Buscaminis mini = null;
        e_Incidencia incidencia = null;
        int id_incidencia;
        string partnumb;
        string partnumb2;
        public frm_Incidencias()
        {
            InitializeComponent();
            Mostrar_Incidencias();
            //Mostrar_Ordenes();
            //Mostrar_Minicods();
            dtRegistro.SelectedDate = DateTime.Now; // muestra la fecha de hoy por defecto
            List_Items();
            lbl_mode.Background = Brushes.OrangeRed;
            //btn_Mod.IsEnabled = false;
        }
        private void Actualiza_Cons()
        {
            obj_occons.Actualiza_CONS();
        }
        private void Actualiza_Incidencias()
        {
            obj_incid.Actualiza_Catphone();
            obj_incid.Actualiza_Linio();
            obj_incid.Actualiza_Lumingo();
            obj_incid.Actualiza_Mercado_Libre();
            obj_incid.Actualiza_Oficina();
            obj_incid.Actualiza_Real_Plaza();
            obj_incid.Actualiza_Ripley();
            obj_incid.Actualiza_Saga();
            obj_incid.Actualiza_Juntoz();
            obj_incid.Actualiza_Kingston();
            //agregando falabela
            obj_incid.Actualiza_Falabella();
            //agregando Conecta
            obj_incid.Actualiza_Conecta();
        }
        private void Mostrar_Minicods()
        {                      
            if (txtMinicod2.Text == "")
            {
                dtg_Producto.ItemsSource = obj_minis.ListaMinis(txtMinicod1.Text);
            }
            else
            {
                dtg_Producto.ItemsSource = obj_minis.ListaMinis(txtMinicod2.Text);
            }
        }
        private void Ingresar_Cons()
        {
            obj_incid.Ingresar_a_cons();
        }
        private void Mostrar_Incidencias()
        {
            dtg_Incidencias.ItemsSource = obj_incid.Listar_incidencias();
            lblcant_incid.Content = Convert.ToString(dtg_Incidencias.Items.Count - 1);
        }
        private void Mostrar_Ordenes()
        {
            dtg_Noc.ItemsSource= obj_occons.Lista_Ods_Cons(txtNorden.Text);
        }
        private void List_Items()
        {
            cmbCanal.Items.Add("SAGA FALABELLA");
            cmbCanal.Items.Add("LINIO");
            cmbCanal.Items.Add("RIPLEY");
            cmbCanal.Items.Add("REAL PLAZA");
            cmbCanal.Items.Add("MERCADO LIBRE");
            cmbCanal.Items.Add("CATPHONE");
            cmbCanal.Items.Add("LUMINGO");
            cmbCanal.Items.Add("JUNTOZ");
            cmbCanal.Items.Add("KINGSTON");
            cmbCanal.Items.Add("OFICINA");
            cmbCanal.Items.Add("COOLBOX");
            //agregando falabella
            cmbCanal.Items.Add("FALABELLA");
            //agregando conecta
            cmbCanal.Items.Add("CONECTA");

            cmbTipo.Items.Add("ANULACION");
            cmbTipo.Items.Add("CAMBIO");
            cmbTipo.Items.Add("DEVOLUCION");
            cmbTipo.Items.Add("REPROGRAMACION");
            cmbTipo.Items.Add("RE CANTIDAD");
            cmbTipo.Items.Add("SERV TECNICO");
            cmbTipo.Items.Add("CAMBIO AVANZADO");

            cmbEstado.Items.Add("DEVOLUCION RECHAZADA");
            cmbEstado.Items.Add("DEVOLUCION ESTADO OK");
            cmbEstado.Items.Add("SERV TECNICO");
            cmbEstado.Items.Add("ARREPENTIMIENTO DE COMPRA");
            cmbEstado.Items.Add("FRAUDE DETECTADO");
            cmbEstado.Items.Add("FALLO DE ENTREGA");

        } //Carga los items de los COMBOBOX
        private void dtg_Producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mini = dtg_Producto.SelectedItem as e_Buscaminis;
            if (mini != null && txtMinicod2.Text == "")
            {
                txtMinicod1.Text = mini.Mini_Codigo;
            }
            else if (mini != null )
            {
                txtMinicod2.Text = mini.Mini_Codigo;
            }            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (dtRegistro.Text != "" && txtNorden.Text != "")
            {
                MessageBox.Show(obj_incid.Registrar_incidencia(cmbTipo.Text, cmbCanal.Text, dtRegistro.Text, txtNorden.Text,
                   dtRegistro.Text, txtMinicod1.Text, txtMinicod2.Text, cmbEstado.Text, txtObs.Text, dtRegistro.Text,dtg_Reprog.Text,txtCant.Text));
                Ingresar_Cons();
                Mostrar_Incidencias();
                Actualiza_Incidencias();
                Actualiza_Cons();
                obj_incid.Actualiza_Catphone();
                obj_incid.Actualiza_Linio();
                obj_incid.Actualiza_Lumingo();
                obj_incid.Actualiza_Mercado_Libre();
                obj_incid.Actualiza_Oficina();
                obj_incid.Actualiza_Real_Plaza();
                obj_incid.Actualiza_Ripley();
                obj_incid.Actualiza_Saga();
                obj_incid.Actualiza_Juntoz();
                obj_incid.Actualiza_Kingston();
                obj_incid.Actualiza_Coolbox();
                //agregado falabela
                obj_incid.Actualiza_Falabella();
                //agregado falabela
                obj_incid.Actualiza_Conecta();
                    if (cmbTipo.SelectedIndex == 2)
                {
                    obj_incid.Actualiza_Salidas_Kardex(txtNorden.Text, cmbTipo.Text, 0);
                }
                else if (cmbTipo.SelectedIndex == 0)
                {
                    obj_incid.Actualiza_Salidas_Kardex(txtNorden.Text, cmbTipo.Text,0);
                }
                else if (cmbTipo.SelectedIndex == 1)
                {
                    obj_incid.Actualiza_Salida_Kardex(txtNorden.Text, txtMinicod2.Text, cmbTipo.Text);
                }
                else if (cmbTipo.SelectedIndex == 4)
                {
                    obj_incid.Actualiza_MSalidas_Kardex(txtNorden.Text, cmbTipo.Text, Convert.ToInt32(txtCant.Text));
                }
                else if (cmbTipo.SelectedIndex == 5)
                {
                    obj_incid.Actualiza_Salidas_Kardex(txtNorden.Text, cmbTipo.Text);
                }
                cmbCanal.SelectedIndex = -1;
                cmbEstado.SelectedIndex = -1;
                cmbTipo.SelectedIndex = -1;
                txtMinicod1.Text = "";
                txtMinicod2.Text = "";
                txtNorden.Text = "";
                txtObs.Text = "";
                dtg_Reprog.Text = "";
                txtCant.Text = "";
            }
            else MessageBox.Show("Rellene los campos faltantes");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dtg_Noc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }

        private void txtNorden_TextChanged(object sender, TextChangedEventArgs e)
        {
      
          
        }

        private void txtMinicod1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Mostrar_Minicods();
            
        }

        private void txtMinicod2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            Mostrar_Minicods();
        }

        private void dtg_Incidencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbl_mode.Opacity == 0.99)
            {
                incidencia = dtg_Incidencias.SelectedItem as e_Incidencia;
                if (incidencia != null)
                {
                    id_incidencia = incidencia.Id_Incidencia;
                    cmbTipo.SelectedItem = incidencia.Tipo;
                    cmbCanal.SelectedItem = incidencia.Canal;
                    cmbEstado.SelectedItem = incidencia.Estado_Dev;
                    txtMinicod1.Text = incidencia.Minicod_1;
                    txtMinicod2.Text = incidencia.Minicod_2;
                    txtNorden.Text = incidencia.Nro_OC;
                    dtg_Reprog.Text = incidencia.Fecha_Reprogramado;

                }
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_search_Click_1(object sender, RoutedEventArgs e)
        {
            Mostrar_Ordenes();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Mostrar_Incidencias();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            frm_Inicio form = new frm_Inicio();
            //Application.Current.MainWindow = new frm_Incidencias();

            //Application.Current.MainWindow.Show();
            //Application.Current.MainWindow.Focus();
            this.Close();
            form.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (lbl_mode.Opacity == 0.99)
            {
                if (dtRegistro.Text != "" && txtNorden.Text != "")
                {
                    MessageBox.Show(obj_incid.Modificar_incidencia(cmbTipo.Text, cmbCanal.Text, txtNorden.Text,
                                       txtMinicod1.Text, txtMinicod2.Text, cmbEstado.Text,txtObs.Text,dtg_Reprog.Text, id_incidencia));
                    Mostrar_Incidencias();
                    Actualiza_Incidencias();
                    Actualiza_Cons();
                    cmbCanal.SelectedIndex = -1;
                    cmbEstado.SelectedIndex = -1;
                    cmbTipo.SelectedIndex = -1;
                    txtMinicod1.Text = "";
                    txtMinicod2.Text = "";
                    txtNorden.Text = "";
                    txtObs.Text = "";
                    dtg_Reprog.Text = "";
                }
                else MessageBox.Show("Rellene los campos faltantes");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

            if (lbl_mode.Opacity == 0.99)
            {
                lbl_mode.Content = "Modo Edición : OFF";
                lbl_mode.Opacity = 1.0;
                lbl_mode.Background = Brushes.OrangeRed;
                btn_Ingresar.IsEnabled = true;
                btn_Mod.IsEnabled = false;

            }
            else
            {
                lbl_mode.Content = "Modo Edición : ON";
                lbl_mode.Opacity = 0.99;
                lbl_mode.Background = Brushes.GreenYellow;
                btn_Ingresar.IsEnabled = false;
                btn_Mod.IsEnabled = true;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            cmbCanal.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            txtMinicod1.Text = "";
            txtMinicod2.Text = "";
            txtNorden.Text = "";
            txtObs.Text = "";
            dtg_Reprog.Text = "";
        }

        private void btn_Limp_Copy_Click(object sender, RoutedEventArgs e)
        {
            dtg_Incidencias.ItemsSource = obj_incid.Listar_incidencias_filtro(txt_search_tipo.Text, txt_search_canal.Text, txt_search_oc.Text, dt_search_fecha.Text);
            lblcant_incid.Content = Convert.ToString(dtg_Incidencias.Items.Count - 1);
        }

        private void btn_Limp_Copy1_Click(object sender, RoutedEventArgs e)
        {
            txt_search_tipo.Text = "";
            txt_search_canal.Text="";
            txt_search_oc.Text="";
            dt_search_fecha.Text="";
            Mostrar_Incidencias();
        }

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cmbTipo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipo.SelectedIndex == 6)
            {
                frm_Cambio_adv frm = new frm_Cambio_adv();
                this.Close();
                frm.ShowDialog();
            }
        }

        private void dtg_Producto_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtNorden_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key.ToString())
            {
                case "Return":
                    Mostrar_Ordenes();
                    break;
                case "Enter":
                    Mostrar_Ordenes();
                    break;
            }
        }
    }
    }

