using System;

// using test_proyect_sistems.Model.Enums;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher
{
    public partial class ChangeStatusTeacher : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Filldropdown();
        }

        private void Filldropdown()
        {
            // Simulate data source
            ddlStatus.Items.Clear();
            // ddlStatus.DataSource = Enum.GetValues(typeof(TeacherStatus)).Cast<TeacherStatus>().Select(e => new ListItem(e.ToString(), ((int)e).ToString()))
                                     
            ddlStatus.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
        }
    }
}