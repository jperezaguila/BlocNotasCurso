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
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    internal class PrincipalViewModel : GeneralViewModel
    {
        //25-01
        public ICommand CmdNuevo { get; set; }
        private ObservableCollection<Bloc> _blocs;

        public PrincipalViewModel(INavigator navigator, IServicioDatos servicio, Session session)
            : base(navigator, servicio, session)
        {
            
            CmdNuevo =new Command(NuevoBloc);
        }

        public ObservableCollection<Bloc> Blocs
        {
            get { return _blocs; }
            set { SetProperty(ref _blocs, value); }
        }

        //y despues añadimos esto:
        private async void NuevoBloc()
        {
            await _navigator.PushAsync<NuevoBlocViewModel>(viewModel =>
            {
                Titulo = "Nuevo Bloc";
                viewModel.Blocs = Blocs;
            });

        }
    }
}
