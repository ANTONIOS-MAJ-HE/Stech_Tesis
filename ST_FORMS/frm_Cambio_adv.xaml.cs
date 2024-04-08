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
    /// Interaction logic for frm_Cambio_adv.xaml
    /// </summary>
    public partial class frm_Cambio_adv : Window
    {
        private n_Cambio_adv OBJ_CAMBIO = new n_Cambio_adv();
        private n_Buscaminis obj_minis = new n_Buscaminis();
        private n_OrdenesCons obj_occons = new n_OrdenesCons();
        private n_Incidencia obj_incid = new n_Incidencia();


        e_Buscaminis mini = null;
        public frm_Cambio_adv()
        {
            InitializeComponent();
            Fill_combobox();
            Lista_cambios();

        }
        private void Cargar_cons()
        {
            OBJ_CAMBIO.Cargar_Cons();
        }
        private void Lista_cambios()
        {
            dtg_Cambios_recientes.ItemsSource = OBJ_CAMBIO.Listar_cambios();
        }
        private void Mostrar_Ordenes()
        {
            dtg_Detalle_OC.ItemsSource = obj_occons.Lista_Ods_Cons(txtN_Orden.Text);
        }
        private void Mostrar_Parts()
        {
            if (txt_Prod_Cambio.Text == "")
            {
                dtg_Producto.ItemsSource = obj_minis.ListaMinis(txtProd_Original.Text);
            }
            else
            {
                dtg_Producto.ItemsSource = obj_minis.ListaMinis(txt_Prod_Cambio.Text);
            }
        }
        private void Fill_combobox()
        {
            cmb_Responsable.Items.Add("L.MEJIAS");
            cmb_Responsable.Items.Add("A.MIRANDA");
            cmb_Responsable.Items.Add("Y.LEAL");
            cmb_Responsable.Items.Add("F.PEDROZA");

            cmbCanal.Items.Add("RIPLEY");
            cmbCanal.Items.Add("SAGA FALABELLA");
            cmbCanal.Items.Add("LINIO");
            cmbCanal.Items.Add("REAL PLAZA GO");
            cmbCanal.Items.Add("JUNTOZ");
            cmbCanal.Items.Add("LUMINGO");
            cmbCanal.Items.Add("MERCADO LIBRE");
            cmbCanal.Items.Add("OFICINA");

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            frm_Incidencias frm = new frm_Incidencias();
            this.Close();
            frm.ShowDialog();
        }

        private void Limpiar_campos()
        {
            txtN_Orden.Text = "";
            txtCant_Prod_cambio.Text = "";
            txtCant_Prod_Original.Text = "";
            txtProd_Original.Text = "";
            txt_Prod_Cambio.Text = ""; 
            cmbCanal.Text = ""; 
            cmb_Responsable.Text = "";
            dtRegistro.Text = "";
            txt_Obs.Text = "";
        }
        private void Ingresar_Cons()
        {
            obj_incid.Ingresar_a_cons();
        }
        private void Ingresar_Ripley ()
        {
            OBJ_CAMBIO.Dupl_Ripley(txt_Obs.Text, txtCant_Prod_cambio.Text, txt_Prod_Cambio.Text, txtN_Orden.Text, txtProd_Original.Text);
            OBJ_CAMBIO.Act_Dupl_Ripley(txtCant_Prod_Original.Text, txtN_Orden.Text, txtProd_Original.Text);
        }

    
        private void Ingresar_Saga()
        {
            
            OBJ_CAMBIO.Dupl_Saga(txtCant_Prod_cambio.Text, txt_Prod_Cambio.Text, txt_Obs.Text, txtN_Orden.Text, txtProd_Original.Text);
            OBJ_CAMBIO.Act_Dupl_Saga(txtCant_Prod_Original.Text, txtN_Orden.Text, txtProd_Original.Text);
        }

       
        private void Ingresar_Linio()
        {
            OBJ_CAMBIO.Dupl_Linio(txt_Obs.Text, txtCant_Prod_cambio.Text, txt_Prod_Cambio.Text, txtN_Orden.Text, txtProd_Original.Text);
        }

        private void Act_Linio()
        {
            OBJ_CAMBIO.Act_Dupl_Linio(txtCant_Prod_Original.Text, txtN_Orden.Text, txtProd_Original.Text);
        }

        private void Ingresar_RealPlaza()
        {
            OBJ_CAMBIO.Dupl_RealPlaza(txt_Obs.Text, txtCant_Prod_cambio.Text, txt_Prod_Cambio.Text, txtN_Orden.Text, txtProd_Original.Text);
        }

        private void Act_RealPlaza()
        {
            OBJ_CAMBIO.Act_Dupl_RealPlaza(txtCant_Prod_Original.Text, txtN_Orden.Text, txtProd_Original.Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (txtN_Orden.Text != "" && txtCant_Prod_cambio.Text != "" && txtCant_Prod_Original.Text != "" && txtProd_Original.Text != "" &&
                txt_Prod_Cambio.Text !="" &&cmbCanal.Text != "" && cmb_Responsable.Text != "" && dtRegistro.Text != "")
            {
                MessageBox.Show(OBJ_CAMBIO.Ingresa_cambio_adv(cmbCanal.Text, dtRegistro.Text, txtN_Orden.Text, txtProd_Original.Text,
               txtCant_Prod_Original.Text, txt_Prod_Cambio.Text, txtCant_Prod_cambio.Text, txt_Obs.Text, cmb_Responsable.Text));
                Cargar_cons();
                MessageBox.Show(obj_incid.Registrar_incidencia("CAMBIO AVANZADO", cmbCanal.Text, "", txtN_Orden.Text,
                 "", "", "", "", txt_Obs.Text, dtRegistro.Text, "", ""));
                obj_incid.Ingresar_a_cons();
                Lista_cambios();
               
                Ingresar_Cons();
                switch (cmbCanal.SelectedIndex)
                {
                    case 0: Ingresar_Ripley();
                        break;
                    case 1: Ingresar_Saga();
                        break;
                    case 2: Ingresar_Linio();
                        break;
                    case 3: Ingresar_RealPlaza();
                        break;
                }
                
                //Limpiar_campos();

            }
            else
            {
                MessageBox.Show("Por favor completar los campos faltantes");
            }
           

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Limpiar_campos();
        }

        private void dtg_Producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mini = dtg_Producto.SelectedItem as e_Buscaminis;
            if (mini != null && txt_Prod_Cambio.Text == "")
            {
                txtProd_Original.Text = mini.Partnumber;
            }
            else if (mini != null)                    
            {
                txt_Prod_Cambio.Text = mini.Partnumber;
            }
        }


        private void txtProd_Original_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Mostrar_Parts();
        }

        private void txt_Prod_Cambio_TextChanged(object sender, TextChangedEventArgs e)
        {
            Mostrar_Parts();
        }

        private void dtg_Cambios_recientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtN_Orden_TextChanged(object sender, TextChangedEventArgs e)
        {
            Mostrar_Ordenes();
        }
    }
}
