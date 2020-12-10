namespace Catman.Education.Application.Entities
{
    using System;
    using System.Collections.Generic;

    public class Discipline
    {
        public Guid Id { get;set; }
        
        public string Title { get; set; }
        
        public ICollection<Test> Tests { get; set; }
    }
}