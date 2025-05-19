using System;

namespace SistemsProyect.Model.Classes
{
    public class Subject
    {
        public int? Id { get; set; }
        public int? ID_Teacher { get; set; }
        public string? Name { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public bool? Active { get; set; }
        public string? Description { get; set; }

        public Subject()
        {
        }
    }
}