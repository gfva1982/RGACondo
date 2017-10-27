using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Condos.Models;
using Condos.Services;
namespace Condos.ViewModels
{
    public class InvitadosFrecuentesViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Properties
        public ObservableCollection<InvitadoFrecuente> Invitados
        {
            get
            {
                return _invitadosFrecuentes;
                }
            set{
                if (_invitadosFrecuentes != value)
                {
                    _invitadosFrecuentes = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Invitados)));
                }
            }
        }
        #endregion

        #region Attributes
        ObservableCollection<InvitadoFrecuente> _invitadosFrecuentes;

        #endregion


        #region Services
        ApiService apiService;
        DialogService dialogService;
        #endregion


        #region Methods
         void CargarListaInvitados()
        {
            var mainViewModel = MainViewModel.GetInstance();
            List<InvitadoFrecuente> invitados = mainViewModel.InfoUsuario.ListaInvitadosFrecuentes;


            Invitados = new ObservableCollection<InvitadoFrecuente>(invitados.OrderBy(px => px.NombreInvitado));
        }
        #endregion


        #region Constructor
        public InvitadosFrecuentesViewModel()
        {
            dialogService = new DialogService();
            apiService = new ApiService();
            CargarListaInvitados();
        }


        #endregion
    }
}
