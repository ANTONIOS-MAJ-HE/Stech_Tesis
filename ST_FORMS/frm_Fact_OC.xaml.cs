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
    /// Interaction logic for frm_Fact_OC.xaml
    /// </summary>
    public partial class frm_Fact_OC : Window
    {
        public frm_Fact_OC()
        {
            InitializeComponent();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            frm_Inicio form = new frm_Inicio();
   
            this.Close();
            form.ShowDialog();
        }
    }
}
