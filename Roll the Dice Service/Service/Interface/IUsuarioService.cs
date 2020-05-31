using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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
