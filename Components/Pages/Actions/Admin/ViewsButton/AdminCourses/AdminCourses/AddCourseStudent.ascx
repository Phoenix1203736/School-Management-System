<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/AdminCourses/AddCourseStudent.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses.AddCourseStudent" %>
<div class="card">
    <div class="card-header">
        <h4 class="mb-0">Agregar Alumno a Curso</h4>
    </div>
    <div class="card-body">
        <div class="mb-3">
            <label class="form-label" for="<%= dropdownSubjectActive.ClientID %>">Curso (Activo)</label>
            <asp:DropDownList runat="server" ID="dropdownSubjectActive" CssClass="form-select" />
        </div>

        <div class="mb-3">
            <label class="form-label" for="<%= txtAlumno.ClientID %>">ID del Estudiante</label>
            <asp:TextBox ID="txtAlumno" runat="server" CssClass="form-control" />
        </div>

        <asp:Button ID="btnVincular" runat="server" Text="Agregar" CssClass="btn btn-primary"
                    OnClick="btnVincular_Click" />

        <asp:Label ID="lblResultado" runat="server" CssClass="form-text d-block mt-2" />
    </div>
</div>
