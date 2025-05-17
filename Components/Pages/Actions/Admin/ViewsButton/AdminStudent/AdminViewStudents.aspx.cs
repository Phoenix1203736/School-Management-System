using System;
using System.Diagnostics;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent
{
    public partial class AdminViewStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadStudentButtons();
        }

        private void LoadStudentButtons()
        {
            var control = Page.LoadControl("~/Components/Pages/Admin/AdminStudent/StudentButtons.ascx");
            placeHolderStudentButtons.Controls.Add(control);
        }

        public void CancelButton()
        {
            placeHolderStudentView.Controls.Clear();
            placeHolderStudentView.Visible = false;
        }

        public void AddStudentView()
        {
            try
            {
                var control = Page.LoadControl("~/Components/Pages/Admin/AdminStudent/Views/AddStudent.ascx");
                placeHolderStudentView.Controls.Add(control);
                placeHolderStudentView.Visible = true;
                Debug.WriteLine("Control AddStudent loaded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                placeHolderStudentView.Visible = false;
            }
        }

        public void SearchStudentView()
        {
            try
            {
                var control = Page.LoadControl("~/Components/Pages/Admin/AdminStudent/Views/SearchStudent.ascx");
                placeHolderStudentView.Controls.Add(control);
                placeHolderStudentView.Visible = true;
                Debug.WriteLine("Control SearchStudent loaded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                placeHolderStudentView.Visible = false;
            }
        }

        public void ChangeStatusStudent()
        {
            try
            {
                var control = Page.LoadControl("~/Components/Pages/Admin/AdminStudent/Views/ChangeStatusStudent.ascx");
                placeHolderStudentView.Controls.Add(control);
                placeHolderStudentView.Visible = true;
                Debug.WriteLine("Control ChangeStatusStudent loaded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                placeHolderStudentView.Visible = false;
            }
        }
    }
}