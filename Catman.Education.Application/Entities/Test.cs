namespace Catman.Education.Application.Entities
{
    using System;

    public class Test
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid DisciplineId { get; set; }

        public Discipline Discipline { get; set; }
    }
}
