namespace SistemsProyect.Model.Classes
{
    public class SubjectStudent
    {
        public int? StudentId { get; set; }
        public string? StudentName { get; set; }
        public decimal? AssigementPercent { get; set; }
        public decimal? AttendancePercentage { get; set; }
        public int? FinalGrade { get; set; }

        public decimal? AverageGrade
        {
            get
            {
                if (AssigementPercent.HasValue && AttendancePercentage.HasValue)
                    return (AssigementPercent.Value + AttendancePercentage.Value) / 2;
                return null;
            }
        }
    }
}