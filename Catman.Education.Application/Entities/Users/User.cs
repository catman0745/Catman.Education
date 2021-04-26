namespace Catman.Education.Application.Entities.Users
{
    using System;

    public abstract class User
    {
        public Guid Id { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public abstract string Role { get; }
    }
}
