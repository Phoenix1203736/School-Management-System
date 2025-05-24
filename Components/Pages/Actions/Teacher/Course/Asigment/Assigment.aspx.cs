using System;
using System.Diagnostics;
using System.Web.UI;

namespace SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment
{
    public partial class Assigment : Page
    {
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