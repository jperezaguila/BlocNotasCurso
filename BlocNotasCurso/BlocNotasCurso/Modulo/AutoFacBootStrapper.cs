using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BlocNotasCurso.Factorias;
using Xamarin.Forms;

namespace BlocNotasCurso.Modulo
{
    public abstract class AutoFacBootStrapper
    {
        public void Run()
        {

            var builder=new ContainerBuilder();
            ConfigureContainer(builder);
            var cont = builder.Build();
            var viewFactory = cont.Resolve<IViewFactory>();
            RegisterView(viewFactory);
            ConfigureApplication(cont);
        }

        public virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoFacMoludo>();
        }
        //recibe el ViewEFactory
        protected abstract void RegisterView(IViewFactory viewFactory);
        //recibe el IContainer
        protected abstract void ConfigureApplication(IContainer container);

    }

}
