using System;
using System.Web.UI;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Views
{
    public partial class AddAsigment : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadSubjects();
        }

        private void LoadSubjects()
        {
            // Solo cargar materias que da este profesor (usa tu lógica de sesión)
            var subjects = SubjectOperations.GetSubjectTeacher(); 
            ddlSubjects.DataSource = subjects;
            ddlSubjects.DataTextField = "Name";
            ddlSubjects.DataValueField = "Id";
            ddlSubjects.DataBind();
        }

        protected void btnAddAssignment_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(ddlSubjects.SelectedValue, out int subjectId) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                lblMessage.Text = "Por favor selecciona una materia y escribe una descripción.";
                return;
            }

            var description = txtDescription.Text.Trim();
            var students = StudentOperations.GetStudentsBySubject(subjectId); // Todos los alumnos inscritos

            int success = 0;
            foreach (var student in students)
            {
                var inserted = AssigmentOperations.InsertAssignment(subjectId, student.Id, description);
                if (inserted) success++;
            }

            lblMessage.Text = $"{success} asignaciones agregadas.";
        }

        

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            var page = (Assigment)this.Page;
            page.HiddeAll();
        }
    }
}
