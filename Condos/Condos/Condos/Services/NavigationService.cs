using System;
using System.Threading.Tasks;
using Condos.Views;
using Xamarin.Forms;

namespace Condos.Services
{
    public class NavigationService
    {
       public async Task Navigate(string pageName)
        {
            switch (pageName)
            {
                case "PrincipalView":
                    await Application.Current.MainPage.Navigation.PushAsync(new PrincipalView());
                    break;

                case "RegistrarInvitadosView":
                    await Application.Current.MainPage.Navigation.PushAsync(new RegistrarInvitadosView());
                    break;

                case "InvitadosFrecuentesView":
                    await Application.Current.MainPage.Navigation.PushAsync(new InvitadosFrecuentesView());
                    break;

                case "ZonasPublicasView":
                    await Application.Current.MainPage.Navigation.PushAsync(new ZonasPublicasView());
                    break;

                case "ZonaPublicaCalendarioView":
                    await Application.Current.MainPage.Navigation.PushAsync(new ZonaPublicaCalendarioView());
                    break;

                case "ZonaPublicaReservacionView":
                    await Application.Current.MainPage.Navigation.PushAsync(new ZonaPublicaReservacionView());
                    break;

                case "ContactenosView":
                    await Application.Current.MainPage.Navigation.PushAsync(new ContactenosView());
                    break;


            }


        }

        public async Task Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
