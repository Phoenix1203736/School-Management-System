using System;
using System.Web;
using System.Web.UI;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher
{
    public partial class SearchTeacher : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rbSearchByPhone.Checked = true;
                pnlEditTeacher.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearchTerm.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    ShowMessage("Ingrese un término de búsqueda", "text-danger");
                    pnlEditTeacher.Visible = false;
                    return;
                }

                Model.Classes.Teacher? teacher = null;

                if (rbSearchByPhone.Checked)
                {
                    teacher = TeacherOperations.GetProfessorByPhone(searchTerm);
                }
                else if (rbSearchByEmail.Checked)
                {
                    teacher = TeacherOperations.GetProfessorByEmail(searchTerm);
                }

                if (teacher != null)
                {
                    HttpContext.Current.Session["teacher"] = teacher; // Guardar en sesión si quieres usarlo después
                    DisplayTeacherData(teacher);
                    // message.Text = "Profesor encontrado";
                    // message.CssClass = "text-success";
                    ShowMessage("Profesor encontrado", "text-success");
                    pnlEditTeacher.Visible = true;
                }
                else
                {
                    pnlEditTeacher.Visible = false;
                    ClearTeacherData();
                    // message.Text = "No se encontró ningún profesor";
                    // message.CssClass = "text-danger";
                    ShowMessage("No se encontró ningún profesor", "text-danger");
                }
            }
            catch (Exception ex)
            {
                ClearTeacherData();
                ShowMessage("Error al buscar el profesor. Intente nuevamente.", "text-danger");
                System.Diagnostics.Debug.WriteLine($"Error al buscar: {ex}");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateTeacherData())
                {
                    ShowMessage("Complete todos los campos requeridos", "text-danger");
                    return;
                }

                // Supongamos que tienes guardado el email antiguo antes de la edición


                var teacher = new Model.Classes.Teacher
                {
                    Id = int.Parse(txtID.Text),
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    HireDate = DateTime.Parse(txtHireDate.Text),
                    Specialization = txtSpecialization.Text.Trim(),
                    Status = ddlStatus.SelectedValue
                };

                // Actualizar en tabla professor
                int? result1 = TeacherOperations.UpdateTeacher(teacher);
                string oldEmail = teacher.Email;
                // Actualizar en tabla users
                int? result2 = TeacherOperations.UpdateTeacherInUsers(teacher, oldEmail);

                if (result1 > 0 && result2 > 0)
                {
                    ShowMessage("Profesor actualizado correctamente", "text-success");
                }
                else
                {
                    ShowMessage("Error al actualizar el profesor", "text-danger");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error al actualizar el profesor. Verifique los datos.", "text-danger");
                System.Diagnostics.Debug.WriteLine($"Error al guardar: {ex}");
            }
        }

        private void DisplayTeacherData(Model.Classes.Teacher? teacher)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            txtID.Text = teacher.Id.ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            txtFirstName.Text = teacher.FirstName ?? "";
            txtLastName.Text = teacher.LastName ?? "";
            txtEmail.Text = teacher.Email ?? "";
            txtPhone.Text = teacher.Phone ?? "";
            txtHireDate.Text = teacher.HireDate.ToString("yyyy-MM-dd");
            txtSpecialization.Text = teacher.Specialization ?? "";
            // ReSharper disable once AssignNullToNotNullAttribute
            if (!string.IsNullOrEmpty(teacher.Status) && ddlStatus.Items.FindByValue(teacher.Status) != null)
            {
                ddlStatus.SelectedValue = teacher.Status;
            }
            else
            {
                ddlStatus.SelectedIndex = 0;
            }
        }

        private void ClearTeacherData()
        {
            txtID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtHireDate.Text = "";
            txtSpecialization.Text = "";
            ddlStatus.SelectedIndex = 0;
        }

        private bool ValidateTeacherData()
        {
            return !string.IsNullOrEmpty(txtFirstName.Text) &&
                   !string.IsNullOrEmpty(txtLastName.Text) &&
                   !string.IsNullOrEmpty(txtEmail.Text) &&
                   !string.IsNullOrEmpty(txtPhone.Text) &&
                   !string.IsNullOrEmpty(txtHireDate.Text) &&
                   !string.IsNullOrEmpty(txtSpecialization.Text) &&
                   ddlStatus.SelectedIndex > 0;
        }

        private void ShowMessage(string message, string cssClass)
        {
            // Implementa aquí el mecanismo para mostrar mensajes al usuario.
            // Ejemplo con un Label llamado lblMessage:
            lblmessage.Text = message;
            lblmessage.CssClass = cssClass;
            lblmessage.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var page = (AdminViews)this.Page;
            page.CancelButtons();
        }
    }
}