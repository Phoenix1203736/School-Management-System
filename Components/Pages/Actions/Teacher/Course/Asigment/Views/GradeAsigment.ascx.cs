using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Views
{
    public partial class GradeAsigment : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           LoadAssignments();
        }

        private void LoadAssignments()
        {
            ddlAssignments.Items.Clear();
            var assignments = AssigmentOperations.GetAssignmentsByProfessor();
            ddlAssignments.DataSource = assignments;
            ddlAssignments.DataTextField = "Description";
            ddlAssignments.DataValueField = "Id";
            ddlAssignments.DataBind();
        }

        protected void ddlAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(ddlAssignments.SelectedValue, out int assignmentId))
            {
                var grades =AssigmentOperations.GetStudentsForAssignment(assignmentId);
                gvGrades.DataSource = grades;
                gvGrades.DataBind();
            }
        }

        protected void btnSaveGrades_Click(object sender, EventArgs e)
        {
            int updated = 0;
            foreach (GridViewRow row in gvGrades.Rows)
            {
                // ReSharper disable once PossibleNullReferenceException
                int assignmentId = Convert.ToInt32(gvGrades.DataKeys[row.RowIndex].Value);
                var txtGrade = row.FindControl("txtGrade") as TextBox;
                if (txtGrade != null && int.TryParse(txtGrade.Text, out int grade))
                {
                    if (AssigmentOperations.UpdateGrade(assignmentId, grade))
                        updated++;
                }
            }

            lblMessage.Text = $"Se actualizaron {updated} calificaciones.";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var page = (Assigment)this.Page;
            page.HiddeAll();
        }
    }
}