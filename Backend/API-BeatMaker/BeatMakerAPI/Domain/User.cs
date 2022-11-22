namespace Domain
{
    public class User
    {
        public User(int id_, string username_, string password_, string email_, bool is2FA_)
        {
            Id = id_;
            Username = username_;
            Password = password_;
            Email = email_;
            Is2FA = is2FA_;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Is2FA { get; set; }
    }
}