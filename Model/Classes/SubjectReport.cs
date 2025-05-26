namespace SistemsProyect.Model.Classes
{
    namespace SistemsProyect.Model.Classes
    {
        public class SubjectReport
        {
            public int SubjectId { get; set; }
            public string SubjectName { get; set; }

            public int ProfessorId { get; set; }
            public string ProfessorFullName { get; set; }

            public int StudentId { get; set; }
            public string StudentFullName { get; set; }

            public decimal AssignmentAverage { get; set; }
            public decimal AttendanceAverage { get; set; }
            public int FinalGrade { get; set; }

            public decimal CombinedAverage => (AssignmentAverage + AttendanceAverage) / 2;
        }
    }
}