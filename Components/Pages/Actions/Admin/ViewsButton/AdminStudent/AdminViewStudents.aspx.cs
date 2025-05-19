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
            var control = LoadControl("~/Components/Pages/Actions/Admin/ViewsButton/AdminStudent/StudentButtons.ascx");
            placeHolderStudentButtons.Controls.Add(control);
        }

        private void ReloadActiveControl()
        {
            if (ViewState["ActiveControl"] == null)
            {
                return;
            }

            string active = ViewState["ActiveControl"].ToString();
            switch (active)
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

        public void AddStudentView()
        {
            try
            {
                placeHolderStudentView.Controls.Clear(); // en TODOS los métodos
                ViewState["ActiveControl"] = "AddStudent";
                var control =
                    LoadControl("~/Components/Pages/Actions/Admin/ViewsButton/AdminStudent/Views/AddStudent.ascx");
                placeHolderStudentView.Controls.Add(control);
                placeHolderStudentView.Visible = true;
                Debug.WriteLine("Control AddStudent loaded");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error al cargar AddStudent: " + e.Message);
                placeHolderStudentView.Visible = false;
            }
        }


        public void ChangeStatusStudent()
        {
            try
            {
                placeHolderStudentView.Controls.Clear(); // en TODOS los métodos

                ViewState["ActiveControl"] = "ChangeStatusStudent";
                var control =
                    LoadControl(
                        "~/Components/Pages/Actions/Admin/ViewsButton/AdminStudent/Views/ChangeStatusStudent.ascx");
                placeHolderStudentView.Controls.Add(control);
                placeHolderStudentView.Visible = true;
                Debug.WriteLine("Control ChangeStatusStudent loaded");
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
                placeHolderStudentView.Controls.Clear(); // en TODOS los métodos

                ViewState["ActiveControl"] = "SearchStudent";
                var control =
                    LoadControl(
                        "~/Components/Pages/Actions/Admin/ViewsButton/AdminStudent/Views/SearchStudent.ascx");
                placeHolderStudentView.Controls.Add(control);
                placeHolderStudentView.Visible = true;
                Debug.WriteLine("Control SearchStudent loaded");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
            }
        }

        public void CancelButton()
        {
            
                placeHolderStudentView.Controls.Clear(); // en TODOS los métodos
                ViewState["ActiveControl"] = null;
                placeHolderStudentView.Visible = false;

        }
    }
}