using System;

namespace SistemsProyect.Model.Classes
{
    public class Subject
    {
        public int? Id { get; set; }
        public int? IdTeacher { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Active { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}