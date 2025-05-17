using System;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views
{
    public partial class ChangeStatusStudent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var page = (AdminViewStudents)Page;
            page.CancelButton();
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            //check id first if the id is null doesnt continue to update the status
        }
    }
}