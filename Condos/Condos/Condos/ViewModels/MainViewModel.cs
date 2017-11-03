using System;
using System.Windows.Input;
using Condos.Models;
using Condos.Services;
using GalaSoft.MvvmLight.Command;

namespace Condos.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public LoginViewModel Login
        {
            get;
            set;
        }

        public PrincipalViewModel Principal
        {
            get;
            set;
        }

        public RegistrarInvitadosViewModel RegistrarInvitados
        {
            get;
            set;
        }

        public InvitadosFrecuentesViewModel InvitadosFrecuentes
        {
            get;
            set;
        }

        public ZonasPublicasViewModel ZonasPublicas
        {
            get;
            set;
        }

        public ZonaPublicaCalendarioViewModel ZonaPublicaCalendario
        {
            get;
            set;
        }

        public ZonaPublicaReservacionViewModel ZonaPublicaReservacion
        {
            get;
            set;
        }

        public TokenResponse Token

        {
            get;
            set;
        }

        public Usuario InfoUsuario
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();

            navigationService = new NavigationService();

        }

        #endregion

        #region Singleton
        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Services
        NavigationService navigationService;
        #endregion

        #region Commnads
        public ICommand ReservarZonaPublicaCommand
        {
            get
            {
                return new RelayCommand(GoReservarZonaPublica);
            }
        }

        async void GoReservarZonaPublica()
        {
            ZonaPublicaReservacion = new ZonaPublicaReservacionViewModel();
            await navigationService.Navigate("ZonaPublicaReservacionView");
        }
        #endregion
    }
}
