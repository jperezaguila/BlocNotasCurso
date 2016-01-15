using Xamarin.Forms;

namespace BlocNotasCurso.Factorias
{
    public interface IPage
    {
         //INavigation es un iterface de xamarin que se encarga de controlar la navegacion.
         INavigation Navigation { get; }
    }
}