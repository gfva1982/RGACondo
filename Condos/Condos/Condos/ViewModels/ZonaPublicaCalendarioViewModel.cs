using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Condos.Models;
using Condos.Services;

namespace Condos.ViewModels
{
    public class ZonaPublicaCalendarioViewModel : INotifyPropertyChanged
    {
        private Inmueble inmueble;

        #region Properties

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
        //NavigationService navigationService;
        #endregion



        #region Constructor
        public ZonaPublicaCalendarioViewModel()
        {
        }

        public ZonaPublicaCalendarioViewModel(Inmueble inmueble)
        {
            this.inmueble = inmueble;

            ImageFullPath = inmueble.ImageFullPath;
            Title = inmueble.Descripcion;
            Comentario = inmueble.Comentario;
            Calendario = new ObservableCollection<Models.Calendario>(inmueble.Calendario);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
