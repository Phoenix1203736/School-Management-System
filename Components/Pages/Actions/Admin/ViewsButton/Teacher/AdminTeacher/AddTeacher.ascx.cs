using System;
using System.Web.UI;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.DataBase.Controllers;

// using test_proyect_sistems.Model.Classes;
// using test_proyect_sistems.Model.Enums;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher
{
    public partial class AddTeacher : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordGenerated();
        }

        /// <summary>
        ///     cancels the action and redirects to the main view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancleButton_Click(object sender, EventArgs e)
        {
            var page = (AdminViews)Page;
            page.CancelButtons();
        }

        /// <summary>
        ///     logic to send info to the  database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SumitButton_Click(object sender, EventArgs e)
        {
            int? r = 0;
            int? r1 = null;
            try
            {
                var teacher = new Model.Classes.Teacher();
                teacher.FirstName = textBoxFirstName.Text;
                teacher.LastName = textBoxLastName.Text;
                teacher.Email = TextBoxEmail.Text;
                teacher.Password = TextBoxPassword.Text;
                teacher.Phone = txtPhone.Text;
                teacher.HireDate = Convert.ToDateTime(txtHireDate.Text);
                teacher.Specialization = txtSpecialization.Text;
                teacher.Status = ddlStatus.SelectedValue;
                r = TeacherOperations.AddTeacherToProfessor(teacher);
                r1 = TeacherOperations.AddTeacherToUsers(teacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (r > 0 && r1 > 0)
            {
                MessageAuth.Text = "Teacher added successfully";
                MessageAuth.CssClass = "text-sucess";
                MessageAuth.Visible = true;
            }
            else
            {
                MessageAuth.Text =
                    "Error agregando al profesor recuerda que el correo y el numero de telefono son unicos";
                MessageAuth.CssClass = "text-danger";
                MessageAuth.Visible = true;
            }
        }

        protected void PasswordGenerated()
        {
            try
            {
                //Generate a random Password
                var passwordRandomized = PasswordGenerator.GeneratePassword(10);
                // Set the password to the TextBox
                TextBoxPassword.Text = passwordRandomized;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}