<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ButtonsAdminCourses.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.ButtonsAdminCourses" %>
<div class="card p-3 mb-3">
    <h4 class="mb-3">Gestión de Cursos</h4>
    <div class="d-grid gap-2">
        <asp:Button ID="btnAgregarCurso" runat="server" CssClass="btn btn-primary" Text="Agregar Curso"
            OnClick="btnAgregarCurso_Click" CausesValidation="false" />
        <asp:Button ID="btnEliminarCurso" runat="server" CssClass="btn btn-danger" Text="Eliminar Curso"
            OnClick="btnEliminarCurso_Click" CausesValidation="false" />
        <asp:Button ID="btnBuscarCurso" runat="server" CssClass="btn btn-info" Text="Buscar Curso"
            OnClick="btnBuscarCurso_Click" CausesValidation="false" />
        <asp:Button ID="btnAgregarAlumno" runat="server" CssClass="btn btn-success" Text="Agregar Alumno a Curso"
            OnClick="btnAgregarAlumno_Click" CausesValidation="false" />
    </div>
</div>