using System;
using System.Web.UI;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent
{
    public partial class StudentButtons : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var page = (AdminViewStudents)Page;
            page.CancelButton();
            // page.CancelButton();
        }

        protected void UpdateStudent_Click(object sender, EventArgs e)
        {
            // var page = (AdminViewStudents)this.Page;
            // page.UpdateStudentView();
        }

        protected void SearchStudent_Click(object sender, EventArgs e)
        {
            var page = (AdminViewStudents)Page;
            page.SearchStudentView();
        }

        protected void AddStudentButton_Click(object sender, EventArgs e)
        {
            var page = (AdminViewStudents)Page;
            page.AddStudentView();
        }

        protected void ChangeStatusStudent_Click(object sender, EventArgs e)
        {
            var page = (AdminViewStudents)Page;
            page.ChangeStatusStudent();
        }
    }
}