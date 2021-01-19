namespace Catman.Education.Application.Entities.Testing
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Entities.Testing.Questioning;

    public class Test
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid DisciplineId { get; set; }

        public Discipline Discipline { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
