using System;
using System.Web.UI;

namespace SistemsProyect.Components.NavBar.Teacher
{
    public partial class NavBarTeacher : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void buttonSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(ResolveUrl("~/Default.aspx"));
        }
    }
}