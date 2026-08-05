using System;
using System.Diagnostics;
using System.Web.UI;
using SistemsProyect.Components;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher
{
    public partial class AdminViews : BasePage
    {
        protected override UserRole[] AllowedRoles { get; } = { UserRole.Administrator };
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAdminButtons();
            ReloadActiveControl();
        }

        /// <summary>
        /// Reloads the active control based on the current ViewState.
        /// This method checks the ViewState for an active control and loads the corresponding view.
        /// </summary>
        private void ReloadActiveControl()
        {
            // Check if ActiveControl is set in ViewState
            if (ViewState["ActiveControl"] == null)
                return;

            // Retrieve the active control identifier
            string active = ViewState["ActiveControl"].ToString();

            // Determine which view to load based on the active control
            switch (active)
            {
                case "UpdateTeacher":
                    LoadUpdateTeacherView(); // Load the view for updating a teacher
                    break;
                case "SearchTeacher":
                    LoadSearchTeacherView(); // Load the view for searching a teacher
                    break;
                case "ChangeStatusTeacher": 
                    ChangeStatusTeacher(); // Load the view for changing teacher status
                    break;
                case "AddTeacher":
                    LoadTeacherAddView(); // Load the view for adding a teacher
                    break;
                default:
                    ViewState["ActiveControl"] = null; // Reset ViewState if no valid control is found
                    return;
            }
        }


        private void LoadAdminButtons()
        {
            var control = LoadControl("~/Components/Pages/Actions/Admin/ViewsButton/Teacher/Buttonsteacher.ascx");
            placeHolderAdminButtons.Controls.Add(control);
        }

        public void CancelButtons()
        {
            placeHolderAdminView.Controls.Clear();
            
            placeHolderAdminView.Visible = false;
            ViewState["ActiveControl"] = "";
        }

        public void LoadTeacherAddView()
        {
            try
            {
                // Elimina esta línea (está borrando los botones)
                // placeHolderAdminButtons.Controls.Clear();
                // Limpia solo el placeholder del formulario
                placeHolderAdminView.Controls.Clear();
                ViewState["ActiveControl"] = "AddTeacher";
                // Carga el control del formulario
                var control =
                    LoadControl("~/Components/Pages/Actions/Admin/ViewsButton/Teacher/AdminTeacher/AddTeacher.ascx");
                placeHolderAdminView.Controls.Add(control);
                placeHolderAdminView.Visible = true;

                Debug.WriteLine("Control AddTeacher cargado");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                placeHolderAdminView.Visible = false;
            }
        }


        public void LoadSearchTeacherView()
        {
            try
            {
                placeHolderAdminView.Controls.Clear();
                ViewState["ActiveControl"] = "SearchTeacher";
                var control =
                    Page.LoadControl(
                        "~/Components/Pages/Actions/Admin/ViewsButton/Teacher/AdminTeacher/SearchTeacher.ascx");
                placeHolderAdminView.Controls.Add(control);
                placeHolderAdminView.Visible = true;
                Debug.WriteLine("Control SearchTeacher cargado");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                placeHolderAdminView.Visible = false;
            }
        }

        public void LoadUpdateTeacherView()
        {
            try
            {
                ViewState["ActiveControl"] = "UpdateTeacher";
                placeHolderAdminView.Controls.Clear();
                var control =
                    Page.LoadControl(
                        "~/Components/Pages/Actions/Admin/ViewsButton/Teacher/AdminTeacher/UpdateTeacher.ascx");
                placeHolderAdminView.Controls.Add(control);
                placeHolderAdminView.Visible = true;
                Debug.WriteLine("Control UpdateTeacher cargado");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                placeHolderAdminView.Visible = false;
                throw;
            }
        }

        public void ChangeStatusTeacher()
        {
            try
            {
                ViewState["ActiveControl"] = "ChangeStatusTeacher";
                placeHolderAdminView.Controls.Clear();
                var control =
                    Page.LoadControl(
                        "~/Components/Pages/Actions/Admin/ViewsButton/Teacher/AdminTeacher/ChangeStatusTeacher.ascx");
                placeHolderAdminView.Controls.Add(control);
                placeHolderAdminView.Visible = true;
                Debug.WriteLine("Control ChangeStatusTeacher cargado");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error {ex.Message}");
                placeHolderAdminView.Visible = false;
            }
        }
    }
}