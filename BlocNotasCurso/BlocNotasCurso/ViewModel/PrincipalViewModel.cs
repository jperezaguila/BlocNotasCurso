using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Service;

namespace BlocNotasCurso.ViewModel
{
    class PrincipalViewModel : GeneralViewModel
    {
        public PrincipalViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
        }
    }
}
