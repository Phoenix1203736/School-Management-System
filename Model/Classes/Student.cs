using System;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Model.Classes
{
    public class Student
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateEntry { get; set; }
        public StudentStatus? Status { get; set; }
    }
    //he didnt let's homework
}