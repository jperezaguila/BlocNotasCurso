using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.View;
using BlocNotasCurso.ViewModel;
using Xamarin.Forms;

namespace BlocNotasCurso.Modulo
{
    public class StartUp:AutoFacBootStrapper
    {
        private readonly App _application;

        public StartUp(App application)
        {
            _application = application;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<BlocDeNotasModulo>();
        }
        

        protected override void RegisterView(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel, Login>();
            viewFactory.Register<RegistroViewModel, Registro>();
            viewFactory.Register<PrincipalViewModel, Principal>();

        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>();
            var np=new NavigationPage(main);
            _application.MainPage = np;
        }
    }
}
