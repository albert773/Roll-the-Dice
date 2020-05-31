using Roll_the_Dice_Service.Models;
using Roll_the_Dice_Service.Service.Interface;
using Roll_the_Dice_Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static Roll_the_Dice_Service.IoC.InjectableAttribute;

namespace Roll_the_Dice_Service.Service
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
            Usuario u = uow.RepositoryClient<Usuario>().GetSingle(q => q.email == login.Email);
            if (u != null) return u.password == login.Password;
            return false;
        }

        public Usuario Register(RegisterRequest register)
        {
            Usuario u = new Usuario();
            u.email = register.Email;
            u.nickname = register.Nickname;
            u.password = register.Password;
            uow.RepositoryClient<Usuario>().Insert(u);
            uow.SaveChanges();
            return uow.RepositoryClient<Usuario>().GetSingle(q => q.email == register.Email);
        }
    }
}