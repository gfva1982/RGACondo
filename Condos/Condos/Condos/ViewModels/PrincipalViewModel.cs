using System;
using System.ComponentModel;
using System.Windows.Input;
using Condos.Services;
using Condos.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Condos.ViewModels
{
    public class PrincipalViewModel : INotifyPropertyChanged
    {
        #region Properties
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
        #endregion

        #region Attributes
        bool _isEnabled;
        #endregion

        #region Services
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public PrincipalViewModel()
        {
            IsEnabled = true;
            dialogService = new DialogService();
            navigationService = new NavigationService();

        }

        #endregion  



        public ICommand RegistrarVisitanteCommand
        {
            get 
            {
                return new RelayCommand(RegistrarVisitante);
            }
        }

         async void RegistrarVisitante()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.RegistrarInvitados = new RegistrarInvitadosViewModel();

            await navigationService.Navigate("RegistrarInvitadosView");
        }

        public ICommand InvitadosAutorizadosCommand
        {
            get
            {
                return new RelayCommand(InvitadosAutorizados);
            }
        }

         async void InvitadosAutorizados()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.InvitadosFrecuentes = new InvitadosFrecuentesViewModel();
            await navigationService.Navigate("InvitadosFrecuentesView");

        }

       
    }
}
