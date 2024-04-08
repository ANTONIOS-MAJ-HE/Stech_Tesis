using ST_Entidades;
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
using System.Windows.Shapes;

namespace ST_FORMS
{
    /// <summary>
    /// Lógica de interacción para frm_Reporte.xaml
    /// </summary>
    public partial class frm_Reporte : Window
    {
        n_Consolidados ConsolidadosOBJ = new n_Consolidados();
        public frm_Reporte()
        {
            InitializeComponent();
            ListarCanal();
            ListarCanal2();
            ListarCanal3();
            ListarCanal4();
        }

        public void ListarCanal()
        {
            Boolean filtro = txtCanal.Text.Length == 0 && txtST_DESP.Text.Length == 0 && dtFechaProceso.Text == "";
                //filtro 1
               // && txtCanal_2.Text.Length == 0 && txtST_DESP_2.Text.Length == 0 && dtFechaProceso_Inicio.Text == "" && dtFechaProceso_Fin.Text == "";
            if (filtro)
            {
                dtgReporte3.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Mes();

                dtgReporte2.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Producto();

                dtgReporte1.ItemsSource = ConsolidadosOBJ.Lista_r_canal();
                contarProductos1();
                contarProductos2();
            }
            else
            {
                dtgReporte1.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Canal_F(txtCanal.Text, dtFechaProceso.Text, txtST_DESP.Text); //buscar 1

                //dtgReporte1.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Canal_F2(txtCanal_2.Text, dtFechaProceso_Inicio.Text, dtFechaProceso_Fin.Text, txtST_DESP_2.Text); //buscar 2
                contarProductos1();

            }
        }

        public void ListarCanal2()
        {
            Boolean filtro = txtCanal_2.Text.Length == 0 && txtST_DESP_2.Text.Length == 0 && dtFechaProceso_Inicio.Text == "" && dtFechaProceso_Fin.Text == "";
            if (filtro)
            {
                dtgReporte2.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Producto();

                dtgReporte1.ItemsSource = ConsolidadosOBJ.Lista_r_canal();
                contarProductos1();
                contarProductos2();

            }
            else
            {
                dtgReporte1.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Canal_F2(txtCanal_2.Text, dtFechaProceso_Inicio.Text, dtFechaProceso_Fin.Text, txtST_DESP_2.Text); //buscar 2
                contarProductos1();
            }
        }

        //producto

        public void ListarCanal3()
        {
            Boolean filtro = txtCanal_Producto.Text.Length == 0 && txtST_DESP_Producto.Text.Length == 0 && dtFechaProceso_Producto.Text == "" ;
            if (filtro)
            {
                dtgReporte2.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Producto();

                dtgReporte1.ItemsSource = ConsolidadosOBJ.Lista_r_canal();
                contarProductos1();
                contarProductos2();

            }
            else
            {
                dtgReporte2.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Producto_F1(txtCanal_Producto.Text, dtFechaProceso_Producto.Text, txtST_DESP_Producto.Text); //buscar 2
                contarProductos2();
            }
        }

        public void ListarCanal4()
        {
            Boolean filtro = txtCanal_Producto2.Text.Length == 0 && txtST_DESP_Producto2.Text.Length == 0 && dtFechaProceso_Inicio2.Text == "" && dtFechaProceso_Fin2.Text == "";
            if (filtro)
            {
                dtgReporte2.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Producto();

                dtgReporte1.ItemsSource = ConsolidadosOBJ.Lista_r_canal();

                contarProductos1();
                contarProductos2();

            }
            else
            {
                dtgReporte2.ItemsSource = ConsolidadosOBJ.Lista_Ventas_Producto_F2(txtCanal_Producto2.Text, dtFechaProceso_Inicio2.Text, dtFechaProceso_Fin2.Text, txtST_DESP_Producto2.Text); //buscar 2
                contarProductos2();
            }
        }

        private void cmbCanal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListarCanal();
            contarProductos1();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            frm_Consolidados frm = new frm_Consolidados();
            this.Close();
            frm.ShowDialog();
        }

        private void btnBuscar_1_Click(object sender, RoutedEventArgs e)
        {
            ListarCanal();
        }

        private void btnBuscar_2_Click(object sender, RoutedEventArgs e)
        {
            ListarCanal2();
        }

        //producto

        private void btnBuscar_Producto1_Click(object sender, RoutedEventArgs e)
        {
            ListarCanal3();
        }

        private void btnBuscar_Producto2_Click(object sender, RoutedEventArgs e)
        {
            ListarCanal4();
        }

        private void contarProductos1()
        {
            List<e_Reporte> productosTotal = dtgReporte1.ItemsSource as List<e_Reporte>;
            int totalCantidades = 0;

            foreach (e_Reporte producto in productosTotal)
            {
                totalCantidades += producto.cantidad_productos;
            }

            lblCantidad_P1.Content = "Cant. Productos: " + totalCantidades.ToString();
        }

        private void contarProductos2()
        {
            List<e_Ventas_Producto> productosTotal = dtgReporte2.ItemsSource as List<e_Ventas_Producto>;
            int totalCantidades = 0;

            foreach (e_Ventas_Producto producto in productosTotal)
            {
                totalCantidades += producto.cantidad;
            }

            lblCantidad_P2.Content = "Cant. Productos: " + totalCantidades.ToString();
        }



        private void txtST_DESP_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key.ToString())
            {
                case "Return":
                    ListarCanal();
                    break;
                case "Enter":
                    ListarCanal();
                    break;
            }
        }
    }


}
