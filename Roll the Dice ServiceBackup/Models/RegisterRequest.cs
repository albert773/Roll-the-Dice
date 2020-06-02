namespace Roll_the_Dice_Service.Models
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}