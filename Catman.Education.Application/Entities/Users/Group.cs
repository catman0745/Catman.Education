namespace Catman.Education.Application.Entities.Users
{
    using System;

    public class Group
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public int Grade { get; set; }
    }
}
