using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlocNotasCurso.ViewModel.Base
{
    //Este ViewModelBase se puede utilizar como dll para otros proyectos

       


    public class ViewModelBase:IViewModel
    {
        public ViewModelBase()
        {
            Opacity = 1;
            Enable = true;
        }

        private bool _isBusy;
        private double _opacity;
        private bool _enable;
   

        public event PropertyChangedEventHandler PropertyChanged;
        public string Titulo { get; set; }

        public double Opacity
        {
            get { return _opacity; }
            set { _opacity = value; }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value)
                    Opacity = 0.5;
                else
                    Opacity = 1;

                Enable = !value;
                SetProperty( ref _isBusy, value);
            }
        }

        public bool Enable
        {
            get { return _enable; }
            set { SetProperty( ref _enable, value); }
        }

        protected virtual bool SetProperty<T>(ref T variable, T valor, [CallerMemberName] string nombre = null)
        {
            if (object.Equals(variable, valor))
                return false;
            variable = valor;
            OnPropertyChanged(nombre);
            return true;

        }

        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(nombre));
            }

        }


        public void SetState<T>(Action<T> action) where T : class, IViewModel
        {
            //action(this as T);
            //action?.Invoke(T);
            if (action != null)
            {
                action(this as T);
            }

        }
    }
}
