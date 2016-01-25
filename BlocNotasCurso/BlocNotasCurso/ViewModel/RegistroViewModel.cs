using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using BlocNotasCurso.Util;
using BlocNotasCurso.View;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    class RegistroViewModel:GeneralViewModel
    {
        public ICommand cmdAlta { get; set; }

        private Usuario _usuario=new Usuario();

        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        private async void GuardarUsuario()
        {
            try
            {
                IsBusy = true;
                var r = await _servicio.AddUsuario(_usuario);
                if (r!=null)
                {
                    //25-01
                    //Debemos guardar el usuario en Session: 
                    Session["usuario"] = r;
                    await _navigator.PushModalAsync<PrincipalViewModel>(viewModel =>
                    {
                        Titulo = "Principal";
                        viewModel.Blocs=new ObservableCollection<Bloc>();
                    });
                }
                else
                {
                    var a = "";
                }
            }
           finally
            {

                IsBusy = false;
            }
        }
        //25-01 - Modificacion del Contructor:
        public RegistroViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            cmdAlta = new Command(GuardarUsuario);
        }
    }
}
