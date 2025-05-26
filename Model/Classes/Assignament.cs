namespace SistemsProyect.Model.Classes
{
    public class Assignament
    {
        public int? Id { get; set; }
        public int? SubjectId { get; set; } // id_subject
        public int? StudentId { get; set; } // id_student
        public string? Description { get; set; } // description (no nullable, según BD)
        public int? Grade { get; set; } // grade
    }
}