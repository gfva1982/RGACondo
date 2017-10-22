using System;
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
        #endregion

        public MainViewModel()
        {
            Login = new LoginViewModel();
        }
    }
}
