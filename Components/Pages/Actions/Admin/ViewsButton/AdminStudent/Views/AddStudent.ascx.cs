using SistemsProyect.Model.Classes;
using SistemsProyect.Model.DataBase.Controllers;
using SistemsProyect.Model.Enums;
using System;
using System.Diagnostics;

// ReSharper disable UnusedMember.Local

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views {
    public partial class AddStudent : System.Web.UI.UserControl {
        protected void Page_Load (object sender, EventArgs e)
        {
        }

      
        private void ClearForm () {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEntryDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ddlStatus.SelectedValue = "active";
        }

        protected void btnCancel_Click (object sender, EventArgs e) {
            var page = (AdminViewStudents)Page;
            page.CancelButton();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            Debug.WriteLine("btnSave_Click triggered");
            // Verificar primero la validación del estado
            if(ddlStatus.SelectedValue == "Select")
            {
                lblError.Text = "Debe seleccionar un estado válido para el alumno";
                lblError.CssClass = "text-danger";
                lblError.Visible = true;
                return; // Salir del método si la validación falla
            }

            try
            {
                Student student = new Student();
                student.FirstName = txtFirstName.Text.Trim();
                student.LastName = txtLastName.Text.Trim();
                student.BirthDate = DateTime.Parse(txtBirthDate.Text);
                student.Email = txtEmail.Text.Trim();
                student.Phone = txtPhone.Text.Trim();
                student.DateEntry = DateTime.Parse(txtEntryDate.Text);
                student.Status = (StudentStatus)Enum.Parse(typeof(StudentStatus), ddlStatus.SelectedValue);
        
               int? result = StudentOperations.AddStudentToStudents(student);

                if(result > 0)
                {
                    lblError.Text = "Alumno guardado exitosamente";
                    lblError.CssClass = "text-success";
                    ClearForm();
                }
                else
                {
                    lblError.Text = "Error al guardar.Recuerda que el email y teléfono sean únicos.";
                    lblError.CssClass = "text-danger";
                }
                lblError.Visible = true;
            }
            catch(Exception ex)
            {
                lblError.Text = $"Error: {ex.Message}";
                lblError.CssClass = "text-danger";
                lblError.Visible = true;
                Debug.WriteLine($"Error en btnSave_Click: {ex}");
            }
        }
    }
}