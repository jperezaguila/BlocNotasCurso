using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using BlocNotasCurso.Util;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        public ICommand cmdLogin { get; set; }
        public ICommand cmdAlta { get; set; }


        //25-01
        public LoginViewModel(INavigator navigator, IServicioDatos servicio , Session session) : base(navigator, servicio, session)
        //25-01
        {
            cmdLogin=new Command (IniciarSesion);
            cmdAlta=new Command (NuevoUsuario);
        }

        public string TituloIniciar  { get { return "Iniciar Sesión"; } }
        public string TituloRegistro { get { return "Nuevo Usuario"; } }
        public string TituloLogin    { get { return "Nombre de Usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }

        private Usuario _usuario=new Usuario();

        public Usuario Usuario
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
                    //25-01-2015
                    Session["usuario"] = us;
                    var blocs = await _servicio.GetBlocs(us.Id);
                    //25-01-2015

                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        viewModel.Titulo = "Pantalla Principal Pepe";
                        //25-01
                        
                        viewModel.Blocs=new ObservableCollection<Bloc>(blocs);
                        //25-01



                    });
                }

                else
                {
                    var xxx = "Usuario no esta dado de Alta.";

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