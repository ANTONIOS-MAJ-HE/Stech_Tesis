﻿
using FontAwesome.Sharp;
using ST_Datos.Repositories;
using ST_Datos.Repository;
using ST_Datos.Rol;
using ST_Entidades.Rol;
using ST_FORMS.View.Admin;
using ST_FORMS.View.Empleado;
using ST_Negocio.Model;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;

namespace ST_FORMS.ViewModel.Comunes
{
    public class MainViewModel : ViewModelBase
    {
        // Campos privados para almacenar datos y estados
        private UserAccountModel _currentUserAccount; // Información de la cuenta de usuario actual
        private Usuario _usuarioActual;
        private UserControl _currentChildView;
        /*private ViewModelBase _currentChildView; */// Vista secundaria actual
        private string _caption; // Título de la vista actual
        private IconChar _icon; // Ícono asociado a la vista actual

        private IUserRepository userRepository; // Repositorio de usuarios para cargar datos de usuario
        private IFacturaRepository facturaRepository;

        private string _dashboardVisible;
        private string _homeVisible;
        private string _customerVisible;
        private string _userVisible;
        //private readonly object _usuarioActual;

        // Propiedades públicas para vincularse con la interfaz de usuario
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount)); // Notificar cambios a la interfaz de usuario
            }
        }

        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set
            {
                _usuarioActual = value;
                OnPropertyChanged(nameof(UsuarioActual)); // Notificar cambios a la interfaz de usuario
            }
        }

        //public ViewModelBase CurrentChildView
        //{
        //    get { return _currentChildView; }
        //    set
        //    {
        //        _currentChildView = value;
        //        OnPropertyChanged(nameof(CurrentChildView)); // Notificar cambios a la interfaz de usuario
        //    }
        //}

        public UserControl CurrentChildView
        {
            get { return _currentChildView; }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView)); // Notificar cambios a la interfaz de usuario
            }
        }

        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption)); // Notificar cambios a la interfaz de usuario
            }
        }

        public IconChar Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon)); // Notificar cambios a la interfaz de usuario
            }
        }

        public string DashboardVisible
        {
            get { return _dashboardVisible; }
            set
            {
                _dashboardVisible = value;
                OnPropertyChanged(nameof(DashboardVisible));
            }
        }

        public string HomeVisible
        {
            get { return _homeVisible; }
            set
            {
                _homeVisible = value;
                OnPropertyChanged(nameof(HomeVisible));
            }
        }

        public string CustomerVisible
        {
            get { return _customerVisible; }
            set
            {
                _customerVisible = value;
                OnPropertyChanged(nameof(CustomerVisible));
            }
        }

        public string UserVisible
        {
            get { return _userVisible; }
            set
            {
                _userVisible = value;
                OnPropertyChanged(nameof(UserVisible));
            }
        }

        // Comandos para manejar acciones del usuario en la interfaz
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowInicioViewCommand { get; }

        //Comando para abrir de incidencia 

        public ICommand ShowIncidenciaViewComamand { get; }

        public ICommand ShowUserViewCommand { get; }

        public ICommand ShowCreateProductViewCommand { get; }
        public ICommand ShowEntradaViewCommand { get; }


        public ICommand ShowActKardexViewCommand { get; }
        public ICommand ShowClientContactViewCommand { get; }
        public ICommand ShowEditProductViewCommand { get; }
        public ICommand ShowGuiasOficinaViewCommand { get; }
        public ICommand ShowPedidosViewCommand { get; }
        public ICommand ShowPlantaStechViewCommand { get; }
        public ICommand ShowRegistroSalidasViewCommand { get; }

        //Antonio

        public ICommand ShowSagaGuiasViewCommand { get; }
        public ICommand ShowFacturaViewCommand { get; }
        public ICommand ShowGuiasConectaViewCommand { get; }
        //Pistoleo
        public ICommand ShowPistoleoInicioViewCommand { get; }
        public ICommand ShowPistoleoRapidoViewCommand { get; }
        public ICommand ShowPistoleoSeguroViewCommand { get; }

        public ICommand ShowAlertaStockViewCommand { get; }
        public ICommand ShowConsolidadosViewCommand { get; }
        public ICommand ShowTransportistaViewCommand { get; }
        public ICommand ShowRatiosViewCommand { get; }

        // Constructor para inicializar el ViewModel
        public MainViewModel()
        {
            // Inicializar el repositorio de usuarios y la cuenta de usuario actual
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            facturaRepository = new FacturaRepository();

            // Inicializar los comandos
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            //ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowInicioViewCommand = new ViewModelCommand(ExecuteShowInicioViewCommand);

            //Inicializando el comando de incidencia
            ShowIncidenciaViewComamand = new ViewModelCommand(ExecuteShowIncidenciaViewCommand);
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);

            ShowCreateProductViewCommand = new ViewModelCommand(ExecuteShowCreateProductViewCommand);
            ShowEntradaViewCommand = new ViewModelCommand(ExecuteShowEntradaViewCommand);

            //agregando mas vistas
            ShowActKardexViewCommand = new ViewModelCommand(ExecuteShowActKardexCommand);
            ShowClientContactViewCommand = new ViewModelCommand(ExecuteShowClientContactViewCommand);
            ShowEditProductViewCommand = new ViewModelCommand(ExecuteShowEditProductViewCommand);
            ShowGuiasOficinaViewCommand = new ViewModelCommand(ExecuteShowGuiasOficinaViewCommand);
            ShowPedidosViewCommand = new ViewModelCommand(ExecuteShowPedidosViewCommand);
            ShowPlantaStechViewCommand = new ViewModelCommand(ExecuteShowPlantaStechViewCommand);
            ShowRegistroSalidasViewCommand = new ViewModelCommand(ExecuteShowRegistroSalidasViewCommand);

            //Antonio

            ShowSagaGuiasViewCommand = new ViewModelCommand(ExecuteShowSagaGuiasViewCommand);
            ShowFacturaViewCommand = new ViewModelCommand(ExecuteShowFacturaViewCommand);
            ShowGuiasConectaViewCommand = new ViewModelCommand(ExecuteShowGuiasConectaViewCommand);

            ShowPistoleoInicioViewCommand = new ViewModelCommand(ExecuteShowPistoleoInicioViewCommand);
            ShowPistoleoRapidoViewCommand = new ViewModelCommand(ExecuteShowPistoleoRapidoViewCommand);
            ShowPistoleoSeguroViewCommand = new ViewModelCommand(ExecuteShowPistoleoSeguroViewCommand);

            ShowAlertaStockViewCommand = new ViewModelCommand(ExecuteShowAlertaStockViewCommand);
            ShowConsolidadosViewCommand = new ViewModelCommand(ExecuteShowConsolidadosViewCommand);
            ShowTransportistaViewCommand = new ViewModelCommand(ExecuteShowTransportistaViewCommand);
            ShowRatiosViewCommand = new ViewModelCommand(ExecuteShowRatiosViewCommand);

            // Mostrar la vista de inicio por defecto al inicio de la aplicación
            ExecuteShowHomeViewCommand(null);

            // Cargar los datos del usuario actual
            LoadCurrentUserData();

            //Cargar los permisos del usuario actual
            LoadPermissions();
        }

        // Método para mostrar la vista de inicio
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeView(this); // Crear una nueva instancia de la vista de inicio
            Caption = "Dashboard"; // Establecer el título de la vista
            Icon = IconChar.Home; // Establecer el ícono asociado a la vista
        }

        // Método para mostrar la vista de clientes
        //private void ExecuteShowCustomerViewCommand(object obj)
        //{
        //    CurrentChildView = new CustomerViewModel(facturaRepository); // Crear una nueva instancia de la vista de clientes
        //    Caption = "Customers"; // Establecer el título de la vista
        //    Icon = IconChar.UserGroup; // Establecer el ícono asociado a la vista
        //}

        // Método para mostrar la vista de inicio de la aplicación (Order)
        private void ExecuteShowInicioViewCommand(object obj)
        {
            CurrentChildView = new InicioView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Order"; // Establecer el título de la vista
            Icon = IconChar.Truck; // Establecer el ícono asociado a la vista
        }

        //metodo para mostrar la vista de incidencia

        private void ExecuteShowIncidenciaViewCommand(object obj)
        {
            CurrentChildView = new Incidencias(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Incidencia"; // Establecer el título de la vista
            Icon = IconChar.Truck; // Establecer el ícono asociado a la vista
        }

        private void ExecuteShowUserViewCommand(object obj)
        {
            CurrentChildView = new UserView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Usuarios"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }



      
        private void ExecuteShowCreateProductViewCommand(object obj)
        {
            CurrentChildView = new CreateProductView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Create Product"; // Establecer el título de la vista
            Icon = IconChar.Truck; // Establecer el ícono asociado a la vista
        }

        private void ExecuteShowEntradaViewCommand(object obj)
        {
            CurrentChildView = new EntradaView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Entradas"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }
        //agregando mas vistas
        private void ExecuteShowActKardexCommand(object obj)
        {
            CurrentChildView = new ActKardexView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Entradas"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }
        private void ExecuteShowClientContactViewCommand(object obj)
        {
            CurrentChildView = new ClientContactView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Entradas"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }
        private void ExecuteShowEditProductViewCommand(object obj)
        {
            CurrentChildView = new EditProductView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Entradas"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }
        private void ExecuteShowGuiasOficinaViewCommand(object obj)
        {
            CurrentChildView = new GuiasOficinaView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Entradas"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }
        private void ExecuteShowPedidosViewCommand(object obj)
        {
            CurrentChildView = new PedidosView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Entradas"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }
        private void ExecuteShowPlantaStechViewCommand(object obj)
        {
            CurrentChildView = new PlantaStechView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Entradas"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }
        private void ExecuteShowRegistroSalidasViewCommand(object obj)
        {
            CurrentChildView = new RegistroSalidasView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Entradas"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }

        //Antonio
        private void ExecuteShowSagaGuiasViewCommand(object obj)
        {
            CurrentChildView = new SagaGuiasView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Saga Guias"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }

        private void ExecuteShowFacturaViewCommand(object obj)
        {
            CurrentChildView = new FacturacionView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Factura"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }

        private void ExecuteShowGuiasConectaViewCommand(object obj)
        {
            CurrentChildView = new GuiasConectaView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Guias Conecta"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }
        private void ExecuteShowPistoleoInicioViewCommand(object obj)
        {
            CurrentChildView = new PistoleoInicioView(this);
            Caption = "Pistoleo Home";
            Icon = IconChar.User;
        }

        private void ExecuteShowPistoleoRapidoViewCommand(object obj)
        {
            CurrentChildView = new PistoleoRapidoView(this);
            Caption = "Pistoleo Rapido";
            Icon = IconChar.User;
        }

        private void ExecuteShowPistoleoSeguroViewCommand(object obj)
        {
            CurrentChildView = new PistoleoSeguroView(this);
            Caption = "Pistoleo Seguro";
            Icon = IconChar.User;
        }

        private void ExecuteShowAlertaStockViewCommand(object obj)
        {
            CurrentChildView = new AlertaStockView(this); // Crear una nueva instancia de la vista de inicio de la aplicación
            Caption = "Alerta Stock"; // Establecer el título de la vista
            Icon = IconChar.User; // Establecer el ícono asociado a la vista
        }
        private void ExecuteShowConsolidadosViewCommand(object obj)
        {
            CurrentChildView = new ConsolidadosView(this);
            Caption = "Consolidados";
            Icon = IconChar.User;
        }

        private void ExecuteShowTransportistaViewCommand(object obj)
        {
            CurrentChildView = new TransportistaView(this);
            Caption = "Transportista";
            Icon = IconChar.User;
        }

        private void ExecuteShowRatiosViewCommand(object obj)
        {
            CurrentChildView = new RatiosView(this);
            Caption = "Comparacion de Ventas ";
            Icon = IconChar.User;
        }


        // Método para cargar los datos del usuario actual desde el repositorio
        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                UsuarioActual = new Usuario { IdUsuario = user.IdUsuario };
                // Si se encontró un usuario, cargar sus datos en la cuenta de usuario actual
                CurrentUserAccount.Username = user.NombreCompleto;
                CurrentUserAccount.DisplayName = $"Welcome {user.NombreCompleto}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                // Si no se encontró un usuario, mostrar un mensaje de usuario inválido
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                // Además, podrías ocultar las vistas secundarias aquí si fuera necesario
            }
        }

        public void LoadPermissions()
        {
            var permisoRepository = new CD_Permiso();
            var permisoService = new CN_Permiso(permisoRepository);
            try
            {
                var listaPermisos = permisoService.Listar(UsuarioActual.IdUsuario);
                DashboardVisible = listaPermisos.Any(p => p.NombreMenu == "menureportes") ? "Visible" : "Collapsed";
                HomeVisible = listaPermisos.Any(p => p.NombreMenu == "menucompras") ? "Visible" : "Collapsed";
                CustomerVisible = listaPermisos.Any(p => p.NombreMenu == "menuclientes") ? "Visible" : "Collapsed";
                UserVisible = listaPermisos.Any(p => p.NombreMenu == "menuusuarios") ? "Visible" : "Collapsed";
            }
            catch (Exception ex)
            {
                // Log the error and handle it appropriately
                Debug.WriteLine($"Error loading permissions: {ex.Message}");
            }
        }
    }
}
