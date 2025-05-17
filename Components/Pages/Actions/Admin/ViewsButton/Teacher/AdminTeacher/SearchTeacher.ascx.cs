using System;
using System.Web.UI;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher
{
    public partial class SearchTeacher : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GridViewResults.Visible = true;
            // Simulate search results
            GridViewResults.DataSource = new[]
            {
                new { TeacherID = 1, Name = "John Doe", Subject = "Math" },
                new { TeacherID = 2, Name = "Jane Smith", Subject = "Science" }
            };
        }
    }
}