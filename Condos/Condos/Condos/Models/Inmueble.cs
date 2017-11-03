using System;
using System.Collections.Generic;
using System.Windows.Input;
using Condos.Services;
using Condos.ViewModels;
using GalaSoft.MvvmLight.Command;

namespace Condos.Models
{
    public class Inmueble
    {
        #region Properties

        public int InmuebleID { get; set; }

        public int CondoID { get; set; }

        public string Descripcion { get; set; }

        public string Image { get; set; }

        public bool EsPublico { get; set; }

        public bool Estado { get; set; }

        public string Comentario { get; set; }

        public string ImageFullPath
        {
            get
            {
                return string.Format("http://condoscrwebadmin.azurewebsites.net/{0}", Image.Substring(1));
            }

        }

        public List<Calendario> Calendario
        {
            get;
            set;
        }

        #endregion

        #region Attributes

        #endregion

        #region Service
        NavigationService navigationService;
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Constructor
        public Inmueble()
        {
            apiService = new ApiService();
            navigationService = new NavigationService();
            dialogService = new DialogService();
        }
        #endregion

        #region Command
        public ICommand RevisarCalendarioCommand
        {
            get
            {
                return new RelayCommand(RevisarCalendario);
            }
        }

        async void RevisarCalendario()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {

                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ZonaPublicaCalendario = new ZonaPublicaCalendarioViewModel(this);

            await navigationService.Navigate("ZonaPublicaCalendarioView");
        }
        #endregion

    }
}
