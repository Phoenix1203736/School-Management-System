using System;
using System.Web.UI;

namespace SistemsProyect.Components.NavBar.Admin
{
    public partial class NavBarAdmin : UserControl
    {
        protected void buttonSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(ResolveUrl("~/Default.aspx"));
        }
    }
}
