
using FontAwesome.Sharp;
using ST_Datos.Repositories;
using ST_Entidades.Rol;
using ST_FORMS.ViewModel.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ST_FORMS.ViewModel.Empleado
{
    public class InicioViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        public ICommand ShowIncidenciasViewCommand { get; }

        public InicioViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            ShowIncidenciasViewCommand = new ViewModelCommand(ExecuteShowIncidenciasViewCommand);

        }

        private void ExecuteShowIncidenciasViewCommand(object obj)
        {
            CurrentChildView = new IncidenciasViewModel();
            Caption = "Incidencias";
            Icon = IconChar.MountainCity;
        }
    }
}
