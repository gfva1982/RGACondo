using System;
using System.ComponentModel;
using System.Windows.Input;
using Condos.Helpers;
using Condos.Models;
using Condos.Services;
using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace Condos.ViewModels
{
    public class ContactenosViewModel : INotifyPropertyChanged
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

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(this,
                                            new PropertyChangedEventArgs(nameof(IsRunning)));

                }
            }
        }
        public ImageSource ImageSource
        {
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;

                    PropertyChanged?.Invoke(
                        this, 
                        new PropertyChangedEventArgs(nameof(ImageSource)));
                }
            }
            get
            {
                return _imageSource;
            }
        }

        public string Comentario
        {
            set
            {
                if (_comentario != value)
                {
                    _comentario = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Comentario));
                }
            }
            get
            {
                return _comentario;
            }
        }

       
        #endregion

        #region Attributes
        string _comentario;
        MediaFile _file;
        ImageSource _imageSource;

        bool _isRunning;
        bool _isEnabled;
       
        #endregion

        #region Servicios
        DialogService dialogService;
        ApiService apiService;
        #endregion

        #region Constructor
        public ContactenosViewModel()
        {
            IsEnabled = true;
            IsRunning = false;
            dialogService = new DialogService();
            apiService = new ApiService();
            ImageSource = "noimagen";
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands

        public ICommand EnviarComentariosCommand
        {
            get
            {
                return new RelayCommand(EnviarComentarios);
            }
        }

        async void EnviarComentarios()
        {
            IsRunning = true;
            IsEnabled = false;

            if (string.IsNullOrEmpty(Comentario))
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error","Debe de agregar un Comentario");
                return;
            }

            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            byte[] imageArray = null;
            if (_file != null)
            {
                imageArray = FilesHelper.ReadFully(_file.GetStream());
                _file.Dispose();
            }


           
            var response = await apiService.Post<Comentario>("http://condoscrwebapi.azurewebsites.net", 
                                                             "api", 
                                                             "/CondoComentarios", 
                                                             new Comentario{
                                                                 Detalle = Comentario,
                                                                 ImageArray = imageArray,
                                                                 CorreoElectronico = mainViewModel.Token.UserName,
                                                                 Inquilino = mainViewModel.InfoUsuario.NombreCompleto + " " + mainViewModel.InfoUsuario.PrimerApellido
                                                                });


            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }

            IsRunning = false;
            IsEnabled = true;
            await dialogService.ShowMessage("", "El comentario fue enviado exitosamente");
            return;

        }

        public ICommand ChangeImageCommand
        {
            get
            {
                return new RelayCommand(ChangeImage);
            }
        }

        async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                var source = await dialogService.ShowImageOptions();

                if (source == "Cancelar")
                {
                    _file = null;
                    return;
                }

                if (source == "Cámara")
                {
                    _file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "Test.jpg",
                        PhotoSize = PhotoSize.Small
                    });
                }
                else
                {
                    _file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                    {
                        PhotoSize = PhotoSize.Small,
                        MaxWidthHeight = 200000
                    });  
                }
             }
            else
            {
                _file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (_file != null)
            {
                ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = _file.GetStream();
                    return stream;
                });
            }
        }
        #endregion
    }
}
