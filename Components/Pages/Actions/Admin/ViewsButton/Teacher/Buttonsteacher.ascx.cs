using System;
using System.Web.UI;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher
{
    public partial class Buttonsteacher : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AddTeacherButton_Click(object sender, EventArgs e)
        {
            var page = (AdminViews)Page;
            page.LoadTeacherAddView();
        }

        protected void SearchTeacher_Click(object sender, EventArgs e)
        {
            var page = (AdminViews)Page;
            page.LoadSearchTeacherView();
        }

        protected void UpdateTeacher_Click(object sender, EventArgs e)
        {
            var page = (AdminViews)Page;
            page.LoadUpdateTeacherView();
        }

        protected void ChangeStatusTeacher_Click(object sender, EventArgs e)
        {
            var page = (AdminViews)Page;
            page.ChangeStatusTeacher();
        }
    }
}