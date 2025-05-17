using System;
using System.Diagnostics;
using System.Web.UI;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher
{
    public partial class AdminViews : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAdminButtons();
            ReloadActiveControl();
        }

        private void ReloadActiveControl()
        {
            if (ViewState["ActiveControl"] == null)
                return;

            string active = ViewState["ActiveControl"].ToString();

            switch (active)
            {
                case "UpdateTeacher":
                    LoadUpdateTeacherView();
                    break;
                case "SearchTeacher":
                    LoadSearchTeacherView();
                    break;
                case "ChangeStatusTeacher":
                    ChangeStatusTeacher();
                    break;
                case "AddTeacher":
                    LoadTeacherAddView();
                    break;
                default:
                    ViewState["ActiveControl"] = null;
                    return;
            }
        }


        private void LoadAdminButtons()
        {
            var control = LoadControl("~/Components/Pages/Actions/Admin/ViewsButton/Teacher/Buttonsteacher.ascx");
            placeHolderAdminButtons.Controls.Add(control);
            /*
            try
            {
                if (Session["Teacher"] != null && Session["Student"] == null)
                {
                    var control = LoadControl("~/Components/Pages/Admin/AdminTeacher/AdminActionsTeacher/Buttonsteacher.ascx");
                    placeHolderAdminButtons.Controls.Add(control);
                }
                else if (Session["Student"] != null || Session["Teacher"] == null)
                {
                    var control = LoadControl("~/Components/Pages/Admin/AdminTeacher/AdminActionsTeacher/ButtonsStudent.ascx");
                    placeHolderAdminButtons.Controls.Add(control);
                }
                else if (Session["Student"] == null && Session["Teacher"] == null)
                {
                    Response.Redirect(ResolveUrl("~/Components/Pages/404_NotFound/NotFound.aspx"));
                }
                else
                {
                    Response.Redirect("~/Components/Pages/404_NotFound/NotFound.aspx");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
            }
            */
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