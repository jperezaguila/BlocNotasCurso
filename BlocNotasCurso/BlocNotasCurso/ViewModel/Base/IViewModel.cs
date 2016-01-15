using System;
using System.ComponentModel;

namespace BlocNotasCurso.ViewModel.Base
{

    public interface IViewModel:INotifyPropertyChanged

    {
        string Titulo { get; set; }
        //Metodo que fuerza para cambiar el estado de ViewModel
        void SetState<T>(Action<T> action) where T : class, IViewModel;

    }
}