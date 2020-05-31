using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll_the_Dice_Service.Service
{
    public class UsuarioService : IService, IUsuarioService
    {
        private IUnitOfWork uow;

        public UsuarioService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario PostUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario PutUsuario(int id, Usuario usuario)
        {
            throw new NotImplementedException();
        }
        public void DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}