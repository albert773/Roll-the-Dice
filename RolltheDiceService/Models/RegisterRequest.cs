namespace RolltheDiceService.Models
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}