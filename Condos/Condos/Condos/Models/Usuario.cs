using System;
using System.Collections.Generic;
using System.Windows.Input;
using Condos.ViewModels;
using Condos.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Condos.Models
{
    public class Usuario
    {
        #region Properties
        public int UsuarioID { get; set; }

        public int InmuebleID { get; set; }

        public string NombreUsuario { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto { get; set; }

        public string TelefonoEmergencia { get; set; }

        public string Identificacion { get; set; }

        public string DetalleInmueble { get; set; }

        public int IdCondo { get; set; }

        public string DescripcionCondo { get; set; }

        public List<InvitadoFrecuente> ListaInvitadosFrecuentes { get; set; }
        #endregion


    }
}
