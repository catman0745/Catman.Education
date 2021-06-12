namespace Catman.Education.Application.Entities.Users
{
    using System;

    public class Student : User
    {
        public Guid GroupId { get; set; }
        
        public Group Group { get; set; }

        public override string Role => nameof(Student);
    }
}
