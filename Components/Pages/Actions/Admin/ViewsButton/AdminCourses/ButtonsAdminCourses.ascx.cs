using System;
using System.Web.UI;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses
{
    public partial class ButtonsAdminCourses : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBuscarCurso_Click(object sender, EventArgs e)
        {
            var page = (AdminViewCourses)this.Page;
            page.SearchCourseView();
        }

        protected void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            var page = (AdminViewCourses)this.Page;
            page.DeleteCourseView();
        }

        protected void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            var page = (AdminViewCourses)this.Page;
            page.AddCourseView();
        }

        protected void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            var page = (AdminViewCourses)this.Page;
            page.AddStudentsCourse();
        }
    }
}