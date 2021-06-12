namespace Catman.Education.Application.Models.Auth
{
    using System;

    public class UserInfo
    {
        public Guid Id { get; set; }
        
        public string Username { get; set; }
        
        public string FullName { get; set; }
        
        public string Token { get; set; }
        
        public string Role { get; set; }
    }
}
