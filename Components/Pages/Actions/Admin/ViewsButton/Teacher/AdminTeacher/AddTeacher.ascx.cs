using System;
using System.Web.UI;

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
            Response.Redirect(ResolveUrl("~/Default.aspx"));
        }

        /// <summary>
        ///     logic to send info to the  database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SumitButton_Click(object sender, EventArgs e)
        {
            try
            {
                // var NewTeacher = new Teacher().WithName(textBoxFirstName.Text, textBoxLastName.Text)
                //     .WithCredentials(TextBoxEmail.Text, TextBoxPassword.Text).WithSpecialization(txtSpecialization.Text)
                //     .WithContactInfo(txtPhone.Text).WithEmploymentDetails(DateTime.Parse(txtHireDate.Text),
                //         (TeacherStatus)Enum.Parse(typeof(TeacherStatus), ddlStatus.SelectedValue));
                // //missing logic to add teacher to the database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void PasswordGenerated()
        {
            try
            {
                // //Generate a random Password
                // //string password = GenerateRandomPassword();
                // var passwordRandomized = PasswordGenerator.GeneratePassword(10);
                // // Set the password to the TextBox
                // TextBoxPassword.Text = passwordRandomized;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}