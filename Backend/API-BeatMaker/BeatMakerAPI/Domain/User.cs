﻿namespace Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Is2FA { get; set; }
        public string Salt { get; set; }
    }
}