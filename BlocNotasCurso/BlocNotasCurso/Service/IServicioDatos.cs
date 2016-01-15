using System;
using System.Threading.Tasks;
using BlocNotasCurso.Model;

namespace BlocNotasCurso.Service
{
    #region Usuario


    
    public interface IServicioDatos
    {
        Task<Usuario> ValidarUsuario(Usuario us);
        Task<Usuario> AddUsuario(Usuario us);
        Task<Usuario> UpdateUsuario(Usuario us, String id);
        Task DeleteUsuario(String id);

    }

    #endregion
}
