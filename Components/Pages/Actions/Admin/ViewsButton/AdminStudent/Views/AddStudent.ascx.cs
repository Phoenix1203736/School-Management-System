using System;

// ReSharper disable UnusedMember.Local

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views
{
    public partial class AddStudent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer valores por defecto
                txtEntryDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ddlStatus.SelectedValue = "active";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedValue == "Select")
            {
                lblError.Text = "Debe seleccionar un estado válido para el alumno";
                lblError.Visible = true;
            }
        }

        private void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEntryDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ddlStatus.SelectedValue = "active";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var page=(AdminViewStudents)Page;
            page.CancelButton();
        }
    }
}