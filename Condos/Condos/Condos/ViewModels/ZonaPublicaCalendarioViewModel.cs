using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Condos.Models;
using Condos.Services;
using GalaSoft.MvvmLight.Command;

namespace Condos.ViewModels
{
    public class ZonaPublicaCalendarioViewModel : INotifyPropertyChanged
    {
        private Inmueble inmueble;

        #region Properties

        public int ZonaId
        {
            get;
            set;
  
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Comentario)));
                }
            }
        }

        public string Title
        {
            get
            {
                return _titulo;
            }
            set
            {
                if (_titulo != value)
                {
                    _titulo = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
                }
            }
        }

          
        

        public string ImageFullPath
        {
            get
            {
                return _imageFullPath;
            }
            set
            {
                if (_imageFullPath != value)
                {
                    _imageFullPath = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageFullPath)));
                }
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
                }
            }
        }

        public ObservableCollection<Calendario> Calendario
        {
            get
            {
                return _calendario;
            }
            set
            {
                if (_calendario != value)
                {
                    _calendario = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calendario)));
                }
            }
        }


        #endregion

        #region Attributes
        bool isRefreshing;
        ObservableCollection<Calendario> _calendario;
        string _imageFullPath;
        string _titulo;
        string _comentario;


        #endregion

        #region Service
        //DialogService dialogService;
        //ApiService apiService;
        NavigationService navigationService;
        #endregion

        #region Constructor
        public ZonaPublicaCalendarioViewModel()
        {
        }

        public ZonaPublicaCalendarioViewModel(Inmueble inmueble)
        {
            this.inmueble = inmueble;
            ZonaId = inmueble.InmuebleID;
            ImageFullPath = inmueble.ImageFullPath;
            Title = inmueble.Descripcion;
            Comentario = inmueble.Comentario;
            Calendario = new ObservableCollection<Calendario>(inmueble.Calendario.OrderBy(p => p.Fecha));
            navigationService = new NavigationService();

            instance = this;
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        public ICommand ReservarZonaPublicaCommand
        {
            get
            {
                return new RelayCommand(GoReservarZonaPublica);
            }
        }

        async void GoReservarZonaPublica()
        {
            var mainViewModel = MainViewModel.GetInstance();

            mainViewModel.ZonaPublicaReservacion = new ZonaPublicaReservacionViewModel(ZonaId);
            await navigationService.Navigate("ZonaPublicaReservacionView");

        }
        #endregion


        #region Singleton
        static ZonaPublicaCalendarioViewModel instance;

        public static ZonaPublicaCalendarioViewModel GetInstance()
        {
            if (instance == null)
            {
                return new ZonaPublicaCalendarioViewModel();
            }

            return instance;
        }
        #endregion
    }
}
