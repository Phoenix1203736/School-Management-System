using System.ComponentModel.DataAnnotations;

namespace SistemsProyect.Model.Enums
{
    public enum TeacherStatus
    {
        [Display(Name = "Ninguna")] None = 0,

        [Display(Name = "Activo")] Active = 1,

        [Display(Name = "Inactivo")] Inactive = 2,

        [Display(Name = "Retirado")] Retired = 3
    }
}