using System;
using System.Web.UI.WebControls;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses
{
    public partial class AddCourseStudent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarMateriasActivas();
        }

        private void CargarMateriasActivas()
        {
            dropdownSubjectActive.Items.Clear();
            var materias = SubjectOperations.ListActiveSubjects(1); // trae solo activas
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var materia in materias)
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            {
                dropdownSubjectActive.Items.Add(new ListItem(materia.Name, materia.Id.ToString()));
            }
        }

        protected void btnVincular_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dropdownSubjectActive.SelectedValue, out int subjectId))
            {
                lblResultado.Text = "Seleccione una materia válida.";
                lblResultado.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!int.TryParse(txtAlumno.Text.Trim(), out int studentId))
            {
                lblResultado.Text = "Ingrese un ID de estudiante válido.";
                lblResultado.ForeColor = System.Drawing.Color.Red;
                return;
            }

            bool resultado = SubjectOperations.AddStudentToSubject(subjectId, studentId);
            lblResultado.Text = resultado ? "Alumno agregado correctamente." : "Error al agregar al alumno.";
            lblResultado.ForeColor = resultado ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }
    }
}