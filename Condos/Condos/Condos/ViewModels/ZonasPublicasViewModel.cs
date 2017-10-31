using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Condos.Models;
using Condos.Services;

namespace Condos.ViewModels
{
    public class ZonasPublicasViewModel : INotifyPropertyChanged
    {

        #region Properties
       
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

        public ObservableCollection<Inmueble> Inmuebles
        {
            get
            {
                return _inmuebles;
            }
            set
            {
                if (_inmuebles != value)
                {
                    _inmuebles = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Inmuebles)));
                }
            }
        }


        #endregion

        #region Attributes
        bool isRefreshing;
        ObservableCollection<Inmueble> _inmuebles;
        #endregion

        #region Service
        DialogService dialogService;
        ApiService apiService;
        NavigationService navigationService;
        #endregion

        #region Constructor
        public ZonasPublicasViewModel()
        {
            dialogService = new DialogService();
            apiService = new ApiService();
            navigationService = new NavigationService();
            CargarZonas();
        }


        #endregion

        #region Methods
        async void CargarZonas()
        {
            IsRefreshing = true;
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {

                IsRefreshing = false;

                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var response = await apiService.Get<Inmueble>("http://condoscrwebapi.azurewebsites.net/",
                                                "api",
                                                "/ObtenerInmueblesPublicos",
                                                "",
                                                "");

            if (response == null)
            {
                IsRefreshing = false;
                await dialogService.ShowMessage("Error", "Ocurrió un error inesperado. Invente más tarde");
               
                return;
            }

            if (!response.IsSuccess)
            {
                IsRefreshing = false;
                await dialogService.ShowMessage("Error", response.Message);

                return;
            }

            var _lista = (List<Inmueble>)response.Result;

            Inmuebles = new ObservableCollection<Inmueble>(_lista);
            IsRefreshing = false;
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
