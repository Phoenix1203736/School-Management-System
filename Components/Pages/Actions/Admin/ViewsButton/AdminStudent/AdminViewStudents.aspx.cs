using System;
using System.Diagnostics;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent
{
    public partial class AdminViewStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadButtons();
            ReloadActiveControl();
        }

        private void LoadButtons()
        {
            placeHolderStudentButtons.Controls.Clear();
            var control = LoadControl("~/Components/Pages/Actions/Admin/ViewsButton/AdminStudent/StudentButtons.ascx");
            placeHolderStudentButtons.Controls.Add(control);
        }

        private void ReloadActiveControl()
        {
            HideAllStudentViews();

            if (ViewState["ActiveControl"] == null)
                return;

            switch (ViewState["ActiveControl"].ToString())
            {
                case "AddStudent":
                    AddStudentView();
                    break;
                case "SearchStudent":
                    SearchStudentView();
                    break;
                case "ChangeStatusStudent":
                    ChangeStatusStudent();
                    break;
                default:
                    ViewState["ActiveControl"] = null;
                    break;
            }
        }

        private void HideAllStudentViews()
        {
            addStudentControl.Visible = false;
            SearchStudentControl.Visible = false;
            ChangeStatusControl.Visible = false;
        }

        public void AddStudentView()
        {
            try
            {
                HideAllStudentViews();
                ViewState["ActiveControl"] = "AddStudent";
                addStudentControl.Visible = true;
                Debug.WriteLine("Control AddStudent visible");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error al activar AddStudent: " + e.Message);
            }
        }

        public void ChangeStatusStudent()
        {
            try
            {
                HideAllStudentViews();
                ViewState["ActiveControl"] = "ChangeStatusStudent";
                ChangeStatusControl.Visible = true;
                Debug.WriteLine("Control ChangeStatusStudent visible");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
        }

        public void SearchStudentView()
        {
            try
            {
                HideAllStudentViews();
                ViewState["ActiveControl"] = "SearchStudent";
                SearchStudentControl.Visible = true;
                Debug.WriteLine("Control SearchStudent visible");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
        }

        public void CancelButton()
        {
            HideAllStudentViews();
            ViewState["ActiveControl"] = null;
        }
    }
}
