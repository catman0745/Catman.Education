namespace Catman.Education.Application.Entities
{
    using System;

    public class Student : User
    {
        public string FullName { get; set; }
        
        public Guid GroupId { get; set; }
        
        public Group Group { get; set; }
    }
}
