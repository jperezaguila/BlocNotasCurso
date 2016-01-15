using System;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        public ICommand cmdLogin { get; set; }
        public ICommand cmdAlta { get; set; }


        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            cmdLogin=new Command (IniciarSesion);
            cmdAlta=new Command (NuevoUsuario);
        }

        protected string TituloIniciar  { get { return "Iniciar Sesión"; } }
        protected string TituloRegistro { get { return "Nuevo Usuario"; } }
        protected string TituloLogin    { get { return "Nombre de Usuario"; } }
        protected string TituloPassword { get { return "Contraseña"; } }

        private Usuario _usuario=new Usuario();

        private Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }


        }


        private async void IniciarSesion()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_usuario);
                if (us!=null)
                {
                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        Titulo = "Pantalla Principal Pepe";
                        

                    });
                }

                else
                {
                    var xxx = "";

                }
                //Aqui navegaríamos a la pantalla principal o daríamos error
            }
            finally
            {
                //propiedad que de momento no hara nada, hasta que la implementemos.
                IsBusy = false;
            }
        }

        private async void NuevoUsuario() {
            //await _navigator.PopToRootAsync();
            //await _navigator.Pushsync<RegistroViewModel>(viewModel =>
            await _navigator.PushModalAsync<RegistroViewModel>(viewModel =>
            {
                Titulo = "Nuevo Usuario";


            });
        }



    }

}