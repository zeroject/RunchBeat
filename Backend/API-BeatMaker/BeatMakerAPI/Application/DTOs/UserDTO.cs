namespace Application.DTOs
{
    public class UserDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool Is2FA { get; set; }
        public string? Email { get; set; }
    }

    public class UserLoginDTO
    {
        public string? Username_Email { get; set; }
        public string? Password { get; set; }
    }
}
