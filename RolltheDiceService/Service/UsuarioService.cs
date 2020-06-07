using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Collections.Generic;
using System.Linq;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
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

        public IEnumerable<Usuario> GetUsuariosBySalaId(int id)
        {
            return uow.RepositoryClient<Usuario>().GetWithInclude(q => q.Personaje.Any(x => x.Sala1.salaId == id));
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