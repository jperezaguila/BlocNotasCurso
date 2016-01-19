using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
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
                    await _navigator.PushModalAsync<PrincipalViewModel>();

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
        
        public RegistroViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            cmdAlta = new Command(GuardarUsuario);
        }
    }
}
