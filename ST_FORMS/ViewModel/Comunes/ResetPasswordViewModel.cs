
using ST_Datos.Repositories;
using ST_Entidades.Rol;
using ST_FORMS.View.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ST_FORMS.ViewModel.Comunes
{
    internal class ResetPasswordViewModel : ViewModelBase
    {
        //Fields
        private string _usernameOrEmail;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        //Properties

        public string UsernameOrEmail
        {
            get
            {
                return _usernameOrEmail;
            }

            set
            {
                _usernameOrEmail = value;
                OnPropertyChanged(nameof(UsernameOrEmail));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //-> Commands
        public ICommand SendUserCommand { get; }
        public ICommand ReturnLoginCommand { get; }

        //Constructor
        public ResetPasswordViewModel()
        {
            userRepository = new UserRepository();
            SendUserCommand = new ViewModelCommand(ExecuteResetPasswordCommand, CanExecuteResetPasswordCommand);
            ReturnLoginCommand = new ViewModelCommand(ExecuteReturnLoginCommand);
        }

        private bool CanExecuteResetPasswordCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(UsernameOrEmail) || UsernameOrEmail.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteResetPasswordCommand(object obj)
        {
            string isValidUser = userRepository.recoverPassword(UsernameOrEmail);
            if (isValidUser.StartsWith("Hi,"))
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(UsernameOrEmail), null);
                IsViewVisible = false;
                ErrorMessage = isValidUser.ToString();
            }
            else
            {
                ErrorMessage = isValidUser;
            }
        }

        private void ExecuteReturnLoginCommand(object obj)
        {
            // Aquí podrías abrir una nueva vista para restablecer la contraseña
            // Por ejemplo, podrías hacer visible otra vista o ventana
            LoginView resetView = new LoginView();

            resetView.Show();
            IsViewVisible = false;  // Opcional: Ocultar la vista de inicio de sesión
        }
    }
}
