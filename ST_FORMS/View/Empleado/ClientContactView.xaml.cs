using ST_FORMS.ViewModel.Comunes;
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
    /// Lógica de interacción para ClientContactView.xaml
    /// </summary>
    public partial class ClientContactView : UserControl
    {
        private readonly MainViewModel _mainViewModel;
        public ClientContactView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
        }
    }
}
