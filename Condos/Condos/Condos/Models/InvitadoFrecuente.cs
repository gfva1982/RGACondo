using System;
using System.Windows.Input;
using Condos.Services;
using Condos.ViewModels;
using Condos.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Condos.Models
{
    public class InvitadoFrecuente
    {

        #region Properties
        public int UsuarioID { get; set; }

        public int InvitadoFrecuenteID
        {
            get;
            set;
        }


        public string NombreInvitado { get; set; }


        public string Identificacion { get; set; }


        public string PlacaVehiculo { get; set; }
        #endregion

        #region Service
        NavigationService navigationService;
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Constructor
        public InvitadoFrecuente()
        {
            apiService = new ApiService();
            navigationService = new NavigationService();
            dialogService = new DialogService();
        }
        #endregion
        #region Command
        public ICommand EliminarCommand
        {
            get
            {
                return new RelayCommand(EliminarFrecuente);  
            }
        }

        async void EliminarFrecuente()
        {
            var _confirmacion = await dialogService.ShowConfirm("Alert", "Desea eliminar el registro");
            if (_confirmacion)
            {
                var _result = await apiService.Delete
                            (
                                "http://condoscrwebapi.azurewebsites.net/",
                                                                      "api",
                                             "/InvitadosFrecuentesCustom",
                                                                      "",
                                                                      "",
                                                                      InvitadoFrecuenteID
                               );

                if (!_result.IsSuccess)
                {
                    await dialogService.ShowMessage("Error", _result.Message);
                    return;
                }
            }



        }

        public ICommand InvitadoSeleccionadoCommand
        {
            get
            {
                return new RelayCommand(InvitadoSeleccionado);
            }
        }

         async void InvitadoSeleccionado()
        {
            var _seleccion = new InvitadoFrecuente {
             Identificacion = Identificacion,
                 NombreInvitado = NombreInvitado,
                 PlacaVehiculo = PlacaVehiculo,
                 
            };

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.RegistrarInvitados = new RegistrarInvitadosViewModel(_seleccion);

            await navigationService.Navigate("RegistrarInvitadosView");
        }


        #endregion



    }
}
