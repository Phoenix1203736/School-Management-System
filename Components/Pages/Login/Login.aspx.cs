using System;
using System.Web.UI;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Login
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnlogin_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
            else
            {
                UserOperations.GetUser(txtEmail.Text, txtPassword.Text);
                if (Session["user"] != null)
                    // Usuario autenticado
                    Response.Redirect(ResolveUrl("~/Default.aspx"));
                else
                    // Usuario no autenticado
                    lblMensaje.Text = "Usuario o contraseña incorrectos";
            }
        }
    }
}