namespace Catman.Education.Application.Entities
{
    using System;
    
    public class User
    {
        public Guid Id { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
    }
}
