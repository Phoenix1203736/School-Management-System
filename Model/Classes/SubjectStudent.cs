namespace SistemsProyect.Model.Classes
{
    public class SubjectStudent
    {
        public int? StudentId { get; set; }
        public string? StudentName { get; set; }
        public decimal? AssignmentPercent { get; set; }
        public decimal? AttendancePercentage { get; set; }
        public decimal? FinalGrade { get; set; }

        public decimal? AverageGrade
        {
            get
            {
                if (AssignmentPercent.HasValue && AttendancePercentage.HasValue)
                    return (AssignmentPercent.Value + AttendancePercentage.Value) / 2;
                return null;
            }
        }
    }
}