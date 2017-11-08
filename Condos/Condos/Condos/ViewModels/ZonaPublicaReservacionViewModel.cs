using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Condos.Models;
using Condos.Services;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Condos.ViewModels
{
    public class ZonaPublicaReservacionViewModel : INotifyPropertyChanged
    {
        #region Properties
        public int ZonaID
        {
            get;
            set;
        }

        public TimeSpan HoraInicio
        {
            get
            {
                return _fechaInicio;
            }
            set
            {
                if (_fechaInicio != value)
                {
                    _fechaInicio = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(HoraInicio)));

                }
            }
        }


        public TimeSpan HoraFinal
        {
            get
            {
                return _fechaFinal;
            }
            set
            {
                if (_fechaFinal != value)
                {
                    _fechaFinal = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(HoraFinal)));

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

        public string Comentario
        {
            get
            {
                return _comentario;
            }
            set
            {
                if (_comentario != value)
                {
                    _comentario = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(Comentario)));

                }
            }
        }
        #endregion

        #region Attributes
        bool _isEnabled;
        bool _isRunning;
        DateTime _fecha;
        TimeSpan _fechaInicio;
        TimeSpan _fechaFinal;
        string _comentario;
        #endregion

        #region Constructors
        public ZonaPublicaReservacionViewModel()
        {
        }

        public ZonaPublicaReservacionViewModel(int pIdRancho)
        {
            dialogService = new DialogService();
            apiService = new ApiService();
            IsEnabled = true;
            Fecha = DateTime.Now;
            if (pIdRancho != 0)
            {
                ZonaID = pIdRancho;
            }
        }
        #endregion

        #region Service
        DialogService dialogService;
        ApiService apiService;
       // NavigationService navigationService;


        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands

        public ICommand ReservarZonaCommand
        {
            get
            {
                return new RelayCommand(ReservarZona);
            }
        }

       
        async void ReservarZona()
        {
            IsRunning = true;
            IsEnabled = false;
            var zonaPublicaViewModel = ZonaPublicaCalendarioViewModel.GetInstance();



            if (Fecha <=  DateTime.Today)
            {
                IsRunning = false;
                IsEnabled = true;

                await dialogService.ShowMessage("Error", "La fecha no puede ser menor o igual a la actual");
                return;
            }

            if (HoraInicio >= HoraFinal)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", "La Hora de inicio no puede ser mayor a la hora final");
                return;
            }
            var _horaI = Fecha.Add(HoraInicio);
            var _horaF = Fecha.Add(HoraFinal);

            var _lista = zonaPublicaViewModel.Calendario.ToList();
            if (_lista.Where(p => p.Fecha == Fecha).Count() ==2)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", "Para esta fecha ya están cubiertas las reservaciones permitidas diarias");
                return;
            }
            var _existe = _lista.Where(p => p.Fecha == Fecha).SingleOrDefault();
            if (_existe != null && _horaI < _existe.HoraFinal)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", "Ya existe una reservación que está en ese rango de horas");
                return;
            }



            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }






            var mainViewModel = MainViewModel.GetInstance();

           
            var response = await apiService.Post<Calendario>("http://condoscrwebapi.azurewebsites.net/", "api", "/CalendarioZonasPublicas",
                                                             new Calendario{
                                                                 InmuebleID = ZonaID,
                                                                 Comentarios = Comentario,
                                                                  Fecha = Fecha,
                                                                 HoraFinal = _horaF,
                                                                HoraInicio = _horaI,
                                                                 UsuarioID = mainViewModel.InfoUsuario.UsuarioID,
                                                                 Estado = 1
                                                                            });

            if (!response.IsSuccess)
            {
                await dialogService.ShowMessage("Error", "No se pudo agregar al invitado");
                IsRunning = false;
                IsEnabled = true;

                return;
            }



            await dialogService.ShowMessage("", "El registro se agregó exitosamente");


           



           

            _lista.Add((Calendario)response.Result);

            zonaPublicaViewModel.Calendario = new System.Collections.ObjectModel.ObservableCollection<Calendario>(_lista.OrderBy(p => p.Fecha));

            await Application.Current.MainPage.Navigation.PopAsync();
            IsRunning = false;
            IsEnabled = true;

        }

        #endregion
    }
}
