using Roll_the_Dice_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Roll_the_Dice_Service.Service.Interface
{
    public interface IAuthService
    {
        bool Login(LoginRequest login);
        Usuario Register(RegisterRequest register);
    }
}
