namespace Catman.Education.Application.Entities
{
    using System;
    using System.Collections.Generic;

    public static class Roles
    {
        public const string Student = "stud";

        public const string Admin = "admin";

        public static IEnumerable<string> ValidRoles =>
            new[] {Student, Admin};
    }

    public class User
    {
        public Guid Id { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string Role { get; set; }
    }
}
