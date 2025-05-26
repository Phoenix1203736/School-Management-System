using System;
using System.Diagnostics;
using System.Web.UI;
using SistemsProyect.Model.DataBase.Controllers;

// using test_proyect_sistems.Model.Enums;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher
{
    public partial class ChangeStatusTeacher : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Filldropdown();
        }

        private void Filldropdown()
        {
            // Simulate data source
            ddlStatus.Items.Clear();
            // ddlStatus.DataSource = Enum.GetValues(typeof(TeacherStatus)).Cast<TeacherStatus>().Select(e => new ListItem(e.ToString(), ((int)e).ToString()))

            ddlStatus.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var page = (AdminViews)Page;
            page.CancelButtons();
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            // ReSharper disable once InconsistentNaming
            var Helper = txtTeacherId.Text;
            try
            {
                var id = Convert.ToInt32(Helper);
                var status = ddlStatus.SelectedValue;
                var result = TeacherOperations.ChangeStatus(id, status.ToLower());
                if (result > 0)
                {
                    lblMessage.Text = "Actualizado correctamente";
                    lblMessage.CssClass = "text-success";
                }
                else
                {
                    lblMessage.Text = "Error: Estudiante no actualizado correctamente";
                }
            }
            catch (Exception eq)
            {
                lblMessage.Text = "Error: " + "Recuerde que el id es un numero";
                lblMessage.CssClass = "text-danger";
                Debug.WriteLine(eq.Message);
            }
        }
    }
}