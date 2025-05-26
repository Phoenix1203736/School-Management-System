using System;
using System.ComponentModel.DataAnnotations;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.Classes
{
    public class Attendance
    {
        [Key] public int? Id { get; set; }

        [Required]
        [Display(Description = "id del la materia")]
        public int? IdSubject { get; set; }

        [Required]
        [Display(Description = "id del estudiante")]
        public int? IdStudent { get; set; }


        [Display(Description = "Asistencia")] public AttendanceStatus? Attenndace { get; set; }

        [Display(Description = "Fecha de asistencia")]
        public DateTime? Date { get; set; }
    }
}