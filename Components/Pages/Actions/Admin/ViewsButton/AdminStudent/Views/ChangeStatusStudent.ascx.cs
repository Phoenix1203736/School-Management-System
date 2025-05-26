using System;
using System.Web.UI;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views
{
    public partial class ChangeStatusStudent : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var page = (AdminViewStudents)Page;
            page.CancelButton();
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            //check id first if the id is null doesnt continue to update the status
            var helper = txtStudentId.Text;
            try
            {
                var id = Convert.ToInt32(helper);
                var status = ddlStatus.SelectedValue;
                var result = StudentOperations.ChangeStatus(id, status.ToLower());

                if (result > 0)
                {
                    lblMessage.Text = "Actualizado correctamente";
                    lblMessage.CssClass = "text-success";
                }
                else
                {
                    lblMessage.Text = "Error: Studiante no actualizado correctamente";
                }
            }
            catch (Exception eq)
            {
                lblMessage.Text = "Error: " + "Recuerde que el id es un numero";
                lblMessage.CssClass = "text-danger";
            }
        }
    }
}