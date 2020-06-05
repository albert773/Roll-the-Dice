using RolltheDiceService.Models;
using RolltheDiceService.Service.Interface;
using RolltheDiceService.Utils;
using System.Linq;
using static RolltheDiceService.IoC.InjectableAttribute;

namespace RolltheDiceService.Service
{
    [InjectableAttributeTransient]
    public class AuthService : IService, IAuthService
    {
        private IUnitOfWork uow;

        public AuthService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public bool Login(LoginRequest login)
        {
            Usuario u = uow.RepositoryClient<Usuario>().getDbSet().FirstOrDefault(q => q.email == login.Email);
            if (u != null) return u.password == login.Password;
            return false;
        }

        public void Register(RegisterRequest register)
        {
            Usuario u = new Usuario();
            u.email = register.Email;
            u.nickname = register.Nickname;
            u.password = register.Password;

            uow.RepositoryClient<Usuario>().Insert(u);
            uow.SaveChanges();
        }
    }
}