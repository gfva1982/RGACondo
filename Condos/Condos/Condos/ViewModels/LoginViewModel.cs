using System;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Condos.Services;
using Xamarin.Forms;
using Condos.Views;

namespace Condos.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Properties

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(IsRunning)));

                }
            }
        }


        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(IsEnabled)));

                }
            }
        }

        public bool IsToggled
        {
            get
            {
                return _isToggled;
            }
            set
            {
                if (_isToggled != value)
                {
                    _isToggled = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(IsToggled)));

                }
            }
        }


        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(Password)));

                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(Email)));

                }
            }
        }




        #endregion

        #region Attributes
        string _email;

        string _password;

        bool _isToggled;
        bool _isEnabled;
        bool _isRunning;

        #endregion

        #region Services
        DialogService dialogService;
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await dialogService.ShowMessage("Error", "Debe de ingresar un email valido");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await dialogService.ShowMessage("Error", "Debe de ingresar un password");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            //var connection = await apiService.CheckConnection();
           // if (connection.IsSuccess)
           // {
            //    IsRunning = false;
            //     IsEnabled = true;
            //     await dialogService.ShowMessage("Error", connection.Message);
            // }

            // var response = await apiService.GetToken("http", Email, Password);

            // if (response ==null)
            // {
            //     IsRunning = false;
            //      IsEnabled = true;
            //     await dialogService.ShowMessage("Error", "Ocurrió un error inesperado. Invente más tarde");
            //  }


            await Application.Current.MainPage.Navigation.PushAsync(new PrincipalView());

        }


        #endregion

        #region Contructors
        public LoginViewModel()
        {
            IsEnabled = true;
            IsToggled = true;
            dialogService = new DialogService();
        }
        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
