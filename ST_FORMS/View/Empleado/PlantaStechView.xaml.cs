﻿using ST_FORMS.ViewModel.Comunes;
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
    /// Lógica de interacción para PlantaStechView.xaml
    /// </summary>
    public partial class PlantaStechView : UserControl
    {
        private readonly MainViewModel _mainViewModel;
        public PlantaStechView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
        }
    }
}
