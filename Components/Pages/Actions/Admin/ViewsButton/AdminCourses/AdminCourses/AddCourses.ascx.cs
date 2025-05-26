using System;
using System.Diagnostics;
using System.Web.UI.WebControls;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses
{
    public partial class AddCourses : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckDropDown();
        }

        private void CheckDropDown()
        {
            if (ddlProfessors.Items.Count > 1)
            {
                // ReSharper disable once RedundantJumpStatement
                return;
            }
            else
            {
                LoadActiveProfessors();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int? idTeacher = int.TryParse(ddlProfessors.SelectedValue, out int profId) ? profId : (int?)null;
                DateTime? startDate =
                    DateTime.TryParse(txtStartDate.Text, out DateTime start) ? start : (DateTime?)null;
                DateTime? endDate = DateTime.TryParse(txtEndDate.Text, out DateTime end) ? end : (DateTime?)null;

                Subject subject = new Subject()
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    IdTeacher = idTeacher,
                    StartDate = startDate,
                    EndDate = endDate,
                    Active = true // Esto lo puede evaluar InsertSubject también
                };

                int? result = SubjectOperations.InsertSubject(subject);
                if (result > 0)
                {
                    lblMessage.CssClass = "text-success";
                    lblMessage.Text = "Materia guardada exitosamente.";
                }
                else
                {
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = "Error al guardar la materia.";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en btnSave_Click: " + ex.Message);
                lblMessage.Text = "Error inesperado.";
            }
        }


        private void LoadActiveProfessors()
        {
            var teacherActive = TeacherOperations.GetActiveProfessors();

            ddlProfessors.Items.Clear();
            ddlProfessors.Items.Add(new ListItem("Seleccione un profesor", ""));

            foreach (var prof in teacherActive)
            {
                ddlProfessors.Items.Add(new ListItem(prof.FirstName + "  " + prof.LastName, prof.Id.ToString()));
            }
        }
    }
}