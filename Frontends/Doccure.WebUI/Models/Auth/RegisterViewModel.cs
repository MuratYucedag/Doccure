namespace Doccure.WebUI.Models.Auth
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string? City { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
    }
}
