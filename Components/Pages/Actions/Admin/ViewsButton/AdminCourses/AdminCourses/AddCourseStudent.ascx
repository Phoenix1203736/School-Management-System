<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/AdminCourses/AddCourseStudent.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses.AddCourseStudent" %>
<div class="card p-3 mb-3">
    <h5>Agregar Alumno a Curso</h5>
    <div class="mb-2">
        <label class="form-label">ID del curso</label>
        <asp:TextBox ID="txtCurso" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-2">
        <label class="form-label">ID del estudiante</label>
        <asp:TextBox ID="txtAlumno" runat="server" CssClass="form-control" />
    </div>
    <asp:Button ID="btnVincular" runat="server" Text="Agregar" CssClass="btn btn-success"
        OnClick="btnVincular_Click" />
</div>