using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices.WindowsRuntime;


//25-01

namespace BlocNotasCurso.Util
{
    public class Session
    {
        private static Dictionary<String, Object> _session = new Dictionary<string, object >() ;

        public Object this[String index]
        {
            get { return _session[index]; }
            set { _session[index] = value; }
        }
            
    }
    

}
