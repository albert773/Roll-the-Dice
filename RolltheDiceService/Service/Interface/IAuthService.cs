using RolltheDiceService.Models;

namespace RolltheDiceService.Service.Interface
{
    public interface IAuthService
    {
        bool Login(LoginRequest login);
        Usuario Register(RegisterRequest register);
    }
}
