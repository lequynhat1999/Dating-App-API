﻿namespace DatingApp.Entites
{
    public class AppUser
    {
        public int ID { get; set; }
        public string? UserName { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }
}
