using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using BlocNotasCurso.Util;
using Xamarin.Forms;

//25-01
namespace BlocNotasCurso.ViewModel
{
    public class NuevoBlocViewModel:GeneralViewModel
    {
        
        public ObservableCollection<Bloc> Blocs{get; set;}

        private Bloc _bloc;

        public ICommand CmdGuardar { get; set; }

        public Bloc Bloc
        {
            get { return _bloc; }
            set { SetProperty(ref _bloc, value); }
        }

        public NuevoBlocViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            _bloc=new Bloc();  
            
            CmdGuardar=new Command(Guardar);
        }

        private async void Guardar()
        {
            Bloc.Fecha = DateTime.Now;
            Bloc.IdUsuario = (Session["usuario"] as Usuario).Id;
            Bloc.Icono = "";

            await _servicio.AddBloc(Bloc);//Añade en Azure
            Blocs.Add(Bloc);//Añade en local
        }

    }
}