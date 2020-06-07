using RolltheDiceService.Models;
using System.Collections.Generic;

namespace RolltheDiceService.Service.Interface
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuarioById(int id);
        Usuario GetUsuarioByEmail(string email);
        IEnumerable<Usuario> GetUsuariosBySalaId(int id);
        Usuario PostUsuario(Usuario usuario);
        Usuario PutUsuario(int id, Usuario usuario);
        void DeleteUsuario(int id);
    }
}
