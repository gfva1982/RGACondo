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
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public PrincipalViewModel()
        {
            IsEnabled = true;
            dialogService = new DialogService();

        }

        #endregion  



        public ICommand RegistrarVisitanteCommand
        {
            get 
            {
                return new RelayCommand(RegistrarVisitante);
            }
        }

        private async void RegistrarVisitante()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.RegistrarInvitados = new RegistrarInvitadosViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new RegistrarInvitadosView());
        }

       
    }
}
