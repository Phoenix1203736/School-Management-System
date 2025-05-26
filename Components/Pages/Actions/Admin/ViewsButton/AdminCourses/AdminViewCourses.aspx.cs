using System;
using System.Web.UI;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses
{
    public partial class AdminViewCourses : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadButtons();
        }

        private void LoadButtons()
        {
            var control =
                Page.LoadControl("~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/ButtonsAdminCourses.ascx");
            placeHolderAdminButtons.Controls.Add(control);
        }

        /*private void ReloadActiveControl()
        {
            if (ViewState["ActiveControl"] == null)
                return;

            string active = ViewState["ActiveControl"].ToString();

            switch (active)
            {
                case "AddCourse":
                    AddCourseView();
                    break;
                /*case "DeleteCourse":

                    break;#1#
                case "AddCourseStudent":
                    AddStudentsCourse() ;
                    break;
                case "SearchCourse":
                    SearchCourseView();
                    break;
                default:
                    ViewState["ActiveControl"] = null;
                   HideAllViews();
                    break;
            }
        }*/

        public void CancelButton()
        {
            ViewState["ActiveControl"] = null;
            HideAllViews();
        }

        private void HideAllViews()
        {
            AddCourses.Visible = false;
            AddStudentCourseV.Visible = false;
            SearchCourse.Visible = false;
        }

        public void AddCourseView()
        {
            HideAllViews();
            ViewState["ActiveControl"] = "AddCourse";
            AddCourses.Visible = true;
        }


        public void AddStudentsCourse()
        {
            HideAllViews();
            ViewState["ActiveControl"] = "AddCourseStudent";
            AddStudentCourseV.Visible = true;
        }

        public void SearchCourseView()
        {
            HideAllViews();
            ViewState["ActiveControl"] = "SearchCourse";
            SearchCourse.Visible = true;
        }
    }
}