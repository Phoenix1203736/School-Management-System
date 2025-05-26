using System;
using System.Web;
using System.Web.UI;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect
{
    public partial class SiteMaster : MasterPage
    {
        private Control? _navControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckStatusUser();
            // if (Session["User"] == null)
            // {
            //     // Usuario no autenticado
            //     //admin
            //_navControl = Page.LoadControl("~/Components/NavBar/Admin/NavBarAdmin.ascx");
            //     //guest
            //_navControl = Page.LoadControl("~/Components/NavBar/Guest/NavBarGuest.ascx");
            //     // var navbar = Page.LoadControl(("~/Components/Navbars/Teacher/NavBarTeacher.ascx"));
            // }
            // else
            // {
            //
            // }
            //PlaceHolderNavbar.Controls.Add(_navControl);
        }

        private void CheckStatusUser()
        {
            try
            {
                if (HttpContext.Current.Session["user"] == null)
                {
                    // Usuario no autenticado
                    _navControl = LoadControl("~/Components/NavBar/Guest/NavBarGuest.ascx");
                }
                else
                {
                    var user = (User)HttpContext.Current.Session["user"];
                    if (user.Role.ToString() == UserRole.Guest.ToString())
                        _navControl = LoadControl("~/Components/NavBar/Guest/NavBarGuest.ascx");
                    if (user.Role.ToString() == nameof(UserRole.Administrator))
                        // Usuario Administrator
                        _navControl = LoadControl("~/Components/NavBar/Admin/NavBarAdmin.ascx");
                    else if (user.Role.ToString() == nameof(UserRole.Standard))
                        // Usuario teacher
                        _navControl = LoadControl("~/Components/NavBar/Teacher/NavBarTeacher.ascx");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (_navControl != null)
                {
                    PlaceHolderNavbar.Controls.Clear(); // Limpiar el PlaceHolder antes de agregar el nuevo control

                    PlaceHolderNavbar.Controls.Add(_navControl);
                }
                else
                {
                    Console.WriteLine("Failed to load navigation control.");
                }
            }
        }
    }
}