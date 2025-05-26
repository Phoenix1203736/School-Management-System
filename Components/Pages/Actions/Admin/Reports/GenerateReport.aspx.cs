using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SistemsProyect.Model.DataBase.Controllers;

namespace SistemsProyect.Components.Pages.Actions.Admin.Reports
{
    public partial class GenerateReport : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadSubjects();
        }

        private void LoadSubjects()
        {
            var subjects = SubjectOperations.GetAllSubjects(); // Para el admin, devuelve todas
            ddlSubjects.DataSource = subjects;
            ddlSubjects.DataTextField = "Name";
            ddlSubjects.DataValueField = "Id";
            ddlSubjects.DataBind();
            ddlSubjects.Items.Insert(0, "Seleccione una materia ");
            // ddlSubjects.Items.Insert(0, new ListItem("-- Selecciona una materia --", new Font()));
        }


        protected void ddlSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(ddlSubjects.SelectedValue, out var subjectId))
            {
                var reportData = ReportOperations.GetSubjectReport(subjectId);
                gvReport.DataSource = reportData;
                gvReport.DataBind();
            }
        }

        protected void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(ddlSubjects.SelectedValue, out var subjectId)) return;

            var reportData = ReportOperations.GetSubjectReport(subjectId);
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (reportData == null || !reportData.Any()) return;

            var first = reportData.First();

            using (var ms = new MemoryStream())
            {
                var doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                doc.Add(new Paragraph("Reporte Final de Materia", titleFont));
                doc.Add(new Paragraph($"Profesor: {first.ProfessorFullName}", bodyFont));
                doc.Add(new Paragraph($"Materia: {first.SubjectName}", bodyFont));
                doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}", bodyFont));
                doc.Add(new Paragraph(" "));

                var table = new PdfPTable(4) { WidthPercentage = 100 };
                table.SetWidths(new float[] { 4, 2, 2, 2 });

                table.AddCell("Estudiante");
                table.AddCell("Prom. Trabajos");
                table.AddCell("Prom. Asistencias");
                table.AddCell("Nota Final");

                foreach (var student in reportData)
                {
                    table.AddCell(student.StudentFullName);
                    table.AddCell($"{student.AssignmentAverage:0.00}");
                    table.AddCell($"{student.AttendanceAverage:0.00}");
                    table.AddCell($"{student.FinalGrade:0.00}");
                }

                doc.Add(table);
                doc.Close();

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=ReporteMateria.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
        }
    }
}