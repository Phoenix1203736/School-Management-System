using System;
using System.Diagnostics;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses
{
    public partial class AdminViewCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadButtons();
        }

        private void LoadButtons()
        {
            var control = Page.LoadControl("~/Components/Pages/Admin/AdminCourses/ButtonsAdminCourses.ascx");
            placeHolderAdminButtons.Controls.Add(control);
        }

        public void CancelButton()
        {
            placeHolderAdminView.Controls.Clear();
            placeHolderAdminView.Visible = false;
        }

        public void AddCourseView()
        {
            try
            {
                var control = Page.LoadControl("~/Components/Pages/Admin/AdminCourses/AdminCourses/AddCourses.ascx");
                placeHolderAdminView.Controls.Add(control);
                placeHolderAdminView.Visible = true;
                Debug.WriteLine("Control AddCourses loaded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                placeHolderAdminView.Visible = false;
            }
        }

        public void DeleteCourseView()
        {
            try
            {
                var control = Page.LoadControl("~/Components/Pages/Admin/AdminCourses/AdminCourses/DeleteCourses.ascx");
                placeHolderAdminView.Controls.Add(control);
                placeHolderAdminView.Visible = true;
                Debug.WriteLine("Control DeleteCourses loaded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                placeHolderAdminView.Visible = false;
            }
        }

        public void AddStudentsCourse()
        {
            try
            {
                var control =
                    Page.LoadControl("~/Components/Pages/Admin/AdminCourses/AdminCourses/AddStudentsCourse.ascx");
                placeHolderAdminView.Controls.Add(control);
                placeHolderAdminView.Visible = true;
                Debug.WriteLine("Control UpdateCourses loaded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                placeHolderAdminView.Visible = false;
            }
        }

        public void SearchCourseView()
        {
            try
            {
                var control = Page.LoadControl("~/Components/Pages/Admin/AdminCourses/AdminCourses/SearchCourses.ascx");
                placeHolderAdminView.Controls.Add(control);
                placeHolderAdminView.Visible = true;
                Debug.WriteLine("Control SearchCourses loaded");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                placeHolderAdminView.Visible = false;
            }
        }
    }
}