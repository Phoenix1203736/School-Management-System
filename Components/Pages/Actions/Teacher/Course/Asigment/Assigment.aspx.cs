using System;
using System.Web.UI;
using SistemsProyect.Components;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment
{
    public partial class Assigment : BasePage
    {
        protected override UserRole[] AllowedRoles { get; } = { UserRole.Standard, UserRole.Administrator };
        protected void Page_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("Hola");
        }


        public void HiddeAll()
        {
            GradeAsigmentControl.Visible = false;
            AddAsigmentControl.Visible = false;
        }

        protected void ButtonAddAsigment_Click(object sender, EventArgs e)
        {
            GradeAsigmentControl.Visible = false;
            AddAsigmentControl.Visible = true;
        }

        protected void ButtonAddGrade_click(object sender, EventArgs e)
        {
            AddAsigmentControl.Visible = false;
            GradeAsigmentControl.Visible = true;
        }
    }
}