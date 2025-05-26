using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Actions.Teacher.Grades
{
    public partial class FinalGrades : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSubjects();
            }
        }

        private void LoadSubjects()
        {
            ddlSubjects.Items.Clear();
            var subjects = SubjectOperations.GetSubjectTeacher();
            ddlSubjects.DataSource = subjects;
            ddlSubjects.DataTextField = "Name";
            ddlSubjects.DataValueField = "Id";
            ddlSubjects.DataBind();

            ddlSubjects.Items.Insert(0, new ListItem("-- Selecciona una materia --", ""));
        }

        protected void ddlSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(ddlSubjects.SelectedValue, out int subjectId))
            {
                var grades = StudentSubjectOperations.GetFinalGradesBySubject(subjectId);
                gvFinalGrades.DataSource = grades;
                gvFinalGrades.DataBind();
            }
        }

        protected void btnSaveFinalGrades_Click(object sender, EventArgs e)
        {
            int subjectId = int.Parse(ddlSubjects.SelectedValue);
            int updated = 0;
            try
            {
                foreach (GridViewRow row in gvFinalGrades.Rows)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    int studentId = Convert.ToInt32(gvFinalGrades.DataKeys[row.RowIndex].Value);
                    var txtFinalGrade = row.FindControl("txtFinalGrade") as TextBox;

                    if (txtFinalGrade != null && int.TryParse(txtFinalGrade.Text, out int grade))
                    {
                        if (StudentSubjectOperations.UpdateFinalGrade(subjectId, studentId, grade))
                            updated++;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }

            lblMessage.Text = $"Se guardaron {updated} notas finales.";
        }
    }
}