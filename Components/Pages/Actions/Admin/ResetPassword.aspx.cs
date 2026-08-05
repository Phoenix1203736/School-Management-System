using System;
using System.Web.UI.WebControls;
using SistemsProyect.Components;
using SistemsProyect.Model.DataBase.Controllers;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Components.Pages.Actions.Admin
{
    public partial class ResetPassword : BasePage
    {
        protected override UserRole[] AllowedRoles { get; } = { UserRole.Administrator };

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var newPassword = txtNewPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword))
            {
                ShowMessage("Ingrese el email y la nueva contraseña.", "text-danger");
                return;
            }

            if (!UserOperations.ResetPassword(email, newPassword))
            {
                ShowMessage("No se encontró ningún usuario con ese email.", "text-danger");
                return;
            }

            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            ShowMessage("Contraseña restablecida correctamente.", "text-success");
        }

        private void ShowMessage(string message, string cssClass)
        {
            lblMessage.Text = message;
            lblMessage.CssClass = cssClass;
            lblMessage.Visible = true;
        }
    }
}