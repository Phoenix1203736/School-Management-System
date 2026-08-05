using System;
using System.Web.UI;
using SistemsProyect.Model.Classes;
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
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowError("Usuario o contraseña incorrectos");
                return;
            }

            if (LoginAttemptTracker.IsLockedOut(email))
            {
                ShowError("Demasiados intentos fallidos. Intente nuevamente en 15 minutos.");
                return;
            }

            if (UserOperations.GetUser(email, password))
            {
                LoginAttemptTracker.RegisterSuccess(email);
                // Descartar cualquier dato de sesión heredado de la visita anónima
                // y conservar únicamente al usuario autenticado.
                var user = (User)Session["user"];
                Session.Clear();
                Session["user"] = user;
                Response.Redirect(ResolveUrl("~/Default.aspx"));
            }
            else
            {
                LoginAttemptTracker.RegisterFailure(email);
                ShowError("Usuario o contraseña incorrectos");
            }
        }

        private void ShowError(string message)
        {
            lblMensaje.Text = message;
            lblMensaje.Visible = true;
        }
    }
}