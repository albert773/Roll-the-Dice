using Roll_the_Dice_Service.Models;
using System.Collections.Generic;

namespace Roll_the_Dice_Service.Service.Interface
{
    interface IUsuarioService
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuarioById(int id);
        Usuario GetUsuarioByEmail(string email);
        Usuario PostUsuario(Usuario usuario);
        Usuario PutUsuario(int id, Usuario usuario);
        void DeleteUsuario(int id);
    }
}
