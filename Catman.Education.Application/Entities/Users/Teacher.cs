namespace Catman.Education.Application.Entities.Users
{
    using System.Collections.Generic;
    using Catman.Education.Application.Entities.Testing;

    public class Teacher : User
    {
        public override string Role => nameof(Teacher);
        
        public ICollection<Discipline> TaughtDisciplines { get; set; }
    }
}
