using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System.Collections.Generic;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
{
    [InjectableAttributeTransient]
    public class UsuarioService : IService, IUsuarioService
    {
        private IUnitOfWork uow;

        public UsuarioService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return uow.RepositoryClient<Usuario>().GetAll();
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            return uow.RepositoryClient<Usuario>().GetSingle(q => q.email == email);
        }

        public Usuario GetUsuarioById(int id)
        {
            return uow.RepositoryClient<Usuario>().GetByID(id);
        }

        public Usuario PostUsuario(Usuario usuario)
        {
            uow.RepositoryClient<Usuario>().Insert(usuario);
            uow.SaveChanges();
            return GetUsuarioById(usuario.usuarioId);
        }

        public Usuario PutUsuario(int id, Usuario usuario)
        {
            uow.RepositoryClient<Usuario>().Update(usuario);
            uow.SaveChanges();
            return GetUsuarioById(id);
        }

        public void DeleteUsuario(int id)
        {
            uow.RepositoryClient<Usuario>().Delete(id);
            uow.SaveChanges();
        }
    }
}