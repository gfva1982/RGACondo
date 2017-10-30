﻿using System;
using Condos.Models;

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
    }
}
