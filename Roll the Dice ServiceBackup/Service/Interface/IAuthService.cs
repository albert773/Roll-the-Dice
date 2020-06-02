using Roll_the_Dice_Service.Models;

namespace Roll_the_Dice_Service.Service.Interface
{
    public interface IAuthService
    {
        bool Login(LoginRequest login);
        Usuario Register(RegisterRequest register);
    }
}
