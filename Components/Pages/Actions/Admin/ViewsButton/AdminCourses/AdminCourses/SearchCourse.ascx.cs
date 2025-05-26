using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses
{
    public partial class SearchCourse : UserControl
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProfesores();
                CargarMateriasActivas();
            }
        }

        private void CargarProfesores()
        {
            ddlTeachers.Items.Clear();
            var profesores = TeacherOperations.GetAll();
            foreach (Model.Classes.Teacher profe in profesores)
            {
                ddlTeachers.Items.Add(new ListItem(profe.FirstName, profe.Id.ToString()));
            }
        }

        private void CargarMaterias(bool activas)
        {
            ddlSubjects.Items.Clear();
            var materias = SubjectOperations.GetAll().Where(m => m.Active == activas).ToList();
            foreach (var materia in materias)
            {
                ddlSubjects.Items.Add(new ListItem(materia.Name, materia.Id.ToString()));
            }
        }

        private void CargarMateriasActivas() => CargarMaterias(true);
        private void CargarMateriasInactivas() => CargarMaterias(false);

        protected void btnFiltrarActivas_Click(object sender, EventArgs e)
        {
            CargarMateriasActivas();
        }

        protected void btnFiltrarInactivas_Click(object sender, EventArgs e)
        {
            CargarMateriasInactivas();
        }

        protected void btnCargarMateria_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ddlSubjects.SelectedValue, out int id))
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Subject materia = SubjectOperations.GetById(id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (materia != null)
                {
                    txtId.Text = materia.Id.ToString();
                    txtName.Text = materia.Name;
                    ddlTeachers.SelectedValue = materia.IdTeacher?.ToString() ?? "";
                    calStartDate.SelectedDate = materia.StartDate ?? DateTime.Today;
                    calEndDate.SelectedDate = materia.EndDate ?? DateTime.Today;
                    chkActive.Checked = materia.Active ?? false;
                    txtDescription.Text = materia.Description;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int? id = int.TryParse(txtId.Text, out int parsedId) ? parsedId : (int?)null;
            int? idTeacher = int.TryParse(ddlTeachers.SelectedValue, out int parsedTeacher) ? parsedTeacher : (int?)null;

            // ReSharper disable once UnusedVariable
            var materia = new Subject
            {
                Id = id,
                Name = txtName.Text,
                IdTeacher = idTeacher,
                StartDate = calStartDate.SelectedDate,
                EndDate = calEndDate.SelectedDate,
                Active = chkActive.Checked,
                Description = txtDescription.Text
            };

            //SubjectOperations.Save(materia);
            //CargarMateriasActivas(); // actualiza lista tras guardar
        }
    }
}