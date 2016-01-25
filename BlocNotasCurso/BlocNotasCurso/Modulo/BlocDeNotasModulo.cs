using System;
using Autofac;
using BlocNotasCurso.Service;
using BlocNotasCurso.Util;
using BlocNotasCurso.View;
using BlocNotasCurso.ViewModel;
using Xamarin.Forms;

namespace BlocNotasCurso.Modulo
{
    public class BlocDeNotasModulo:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServicioDatosImpl>().As<IServicioDatos>().SingleInstance();

            builder.RegisterType<Session>().SingleInstance();

            builder.RegisterType<Login>();
            builder.RegisterType<Principal>();
            builder.RegisterType<Registro>();
            //25-01
            builder.RegisterType<NuevoBlocView>();

            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<PrincipalViewModel>();
            builder.RegisterType<RegistroViewModel>();
            //25-01
            builder.RegisterType<NuevoBlocViewModel>();
            
   
            

            builder.RegisterInstance < Func < Page >> (() =>
            {
                var masterP = App.Current.MainPage as MasterDetailPage;
                var page = masterP != null ? masterP.Detail : App.Current.MainPage;
                var navigation = page as IPageContainer<Page>;
                return navigation != null ? navigation.CurrentPage : page;

            });
        }
    }
}
