using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.DataBase.Controllers;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Components.Pages.Actions.Teacher.Course.Assistance
{
    public partial class AssistantView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSubjects();
            }
        }

        private void LoadSubjects()
        {
            // Aquí obtienes materias activas del profesor (suponiendo que tienes método)
            var subjects = SubjectOperations.GetSubjectTeacher() ?? new List<Subject>();

            ddlSubjects.DataSource = subjects;
            ddlSubjects.DataTextField = "Name";
            ddlSubjects.DataValueField = "Id";
            ddlSubjects.DataBind();

            ddlSubjects.Items.Insert(0, new ListItem("-- Seleccione una materia --", "0"));
        }

        protected void ddlSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(ddlSubjects.SelectedValue, out int subjectId) && subjectId > 0)
            {
                LoadAttendance(subjectId, DateTime.Today);
            }
            else
            {
                gvAttendance.DataSource = null;
                gvAttendance.DataBind();
            }
        }

        private void LoadAttendance(int subjectId, DateTime attendanceDate)
        {
            var students = StudentOperations.GetStudentsBySubject(subjectId);

            var attendanceList = new List<Attendance>();

            var enumerable = students.ToList();
            foreach (var student in enumerable)
            {
                var att = AttendanceOperations.GetAttendanceByStudentAndDate(subjectId, student.Id ?? 0, attendanceDate)
                          ?? new Attendance
                          {
                              IdStudent = student.Id,
                              IdSubject = subjectId,
                              Date = attendanceDate,
                              Attenndace = AttendanceStatus.Absent
                          };

                attendanceList.Add(att);
            }

            var dataSource = attendanceList.Select(a => new
            {
                StudentId = a.IdStudent,
                StudentName = enumerable.First(s => s.Id == a.IdStudent).FullName,
                AttendanceStatus = a.Attenndace?.ToString() ?? "Absent",
                AttendanceStatusText = GetAttendanceStatusText(a.Attenndace ?? AttendanceStatus.Absent),
                // ReSharper disable once RedundantAnonymousTypePropertyName
                Date = a.Date
            }).ToList();

            gvAttendance.DataSource = dataSource;
            gvAttendance.DataBind();
        }


        protected void gvAttendance_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int studentId = (int)(gvAttendance.DataKeys[e.RowIndex]?.Value ?? throw new InvalidOperationException());
            int subjectId = int.Parse(ddlSubjects.SelectedValue);

            GridViewRow row = gvAttendance.Rows[e.RowIndex];
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

            if (Enum.TryParse(ddlStatus.SelectedValue, out AttendanceStatus status))
            {
                var attendance = new Attendance
                {
                    IdStudent = studentId,
                    IdSubject = subjectId,
                    Date = DateTime.Today,
                    Attenndace = status
                };

                AttendanceOperations.UpsertAttendance(attendance);
            }

            gvAttendance.EditIndex = -1;
            LoadAttendance(subjectId, DateTime.Today);
        }

        protected string GetAttendanceStatusText(AttendanceStatus status)
        {
            return status switch
            {
                AttendanceStatus.Came => "Vino",
                AttendanceStatus.Absent => "Falta",
                AttendanceStatus.Justified => "Justificado",
                _ => "Desconocido"
            };
        }

        protected void gvAttendance_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAttendance.EditIndex = e.NewEditIndex;
            if (int.TryParse(ddlSubjects.SelectedValue, out int subjectId))
                LoadAttendance(subjectId, DateTime.Today);
        }

        protected void gvAttendance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAttendance.EditIndex = -1;
            if (int.TryParse(ddlSubjects.SelectedValue, out int subjectId))
                LoadAttendance(subjectId, DateTime.Today);
        }

        protected void btnLoadAttendance_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ddlSubjects.SelectedValue, out int subjectId) && subjectId > 0)
            {
                if (DateTime.TryParse(txtAttendanceDate.Text, out DateTime selectedDate))
                {
                    LoadAttendance(subjectId, selectedDate);
                }
                else
                {
                    LoadAttendance(subjectId, DateTime.Today);
                }
            }
            else
            {
                gvAttendance.DataSource = null;
                gvAttendance.DataBind();
            }

            //throw new NotImplementedException();
        }
    }
}