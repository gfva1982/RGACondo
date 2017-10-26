using System;
using System.ComponentModel;
using System.Windows.Input;
using Condos.Services;
using Condos.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

using Condos.Models;

namespace Condos.ViewModels
{
    public class RegistrarInvitadosViewModel : INotifyPropertyChanged
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


        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(Nombre)));

                }
            }
        }

        public string Identificacion
        {
            get
            {
                return _identificacion;
            }
            set
            {
                if (_identificacion != value)
                {
                    _identificacion = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(Identificacion)));

                }
            }
        }

        public string Placa
        {
            get
            {
                return _placa;
            }
            set
            {
                if (_placa != value)
                {
                    _placa = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(Placa)));

                }
            }
        }


        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                if (_fecha != value)
                {
                    _fecha = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(Fecha)));

                }
            }
        }



        #endregion

        #region Attributes
        string _nombre;
        string _placa;
        string _identificacion;
        DateTime _fecha;

        bool _isToggled;
        bool _isEnabled;
        bool _isRunning;

       



        #endregion

        #region Constructors
        public RegistrarInvitadosViewModel()
        {
            IsEnabled = true;
            IsToggled = true;
            Fecha = DateTime.Now;

            apiService = new ApiService();
            dialogService = new DialogService();

        }

        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        DialogService dialogService;
        ApiService apiService;
        #endregion

        #region Commands
        public ICommand AgregarInvitadoCommand
        {
            get
            {
                return new RelayCommand(AgregarInvitado);
            }
        }

        private async void AgregarInvitado()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                await dialogService.ShowMessage("Error", "Debe de ingresar un nombre");
                return;
            }

            if (string.IsNullOrEmpty(Identificacion))
            {
                await dialogService.ShowMessage("Error", "Debe de ingresar una identificacion");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }
            var mainViewModel = MainViewModel.GetInstance();

            var response = await apiService.Post<RegistroDeAcceso>("http://condoscrwebapi.azurewebsites.net","api","/RegistroDeAccesoes",new RegistroDeAcceso{
                CondoID = 1,
                 FechaAcceso = Fecha,
                 Identificacion = Identificacion,
                 NombreInvitado = Nombre,
                 NombreAutoriza = mainViewModel.Token.UserName,
                 PlacaVehiculo = Placa
            });

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", response.Message);
            }


            await dialogService.ShowMessage("", "El registro se agregó exitosamente");

            Nombre = string.Empty;
            Identificacion = string.Empty;
            Placa = string.Empty;
            Fecha = DateTime.Now;
            IsRunning = false;
            IsEnabled = true;


        }


        #endregion

    }
}
