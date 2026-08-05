<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ButtonsAdminCourses.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.ButtonsAdminCourses" %>
<div class="action-list">
    <asp:LinkButton ID="btnAgregarCurso" runat="server" CssClass="action-link"
        OnClick="btnAgregarCurso_Click" CausesValidation="false">
        <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z"/><path d="M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z"/></svg>
        <span>Agregar Curso</span>
    </asp:LinkButton>
    <asp:LinkButton ID="btnAgregarAlumno" runat="server" CssClass="action-link"
        OnClick="btnAgregarAlumno_Click" CausesValidation="false">
        <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M10 13a5 5 0 0 0 7.54.54l3-3a5 5 0 0 0-7.07-7.07l-1.72 1.71"/><path d="M14 11a5 5 0 0 0-7.54-.54l-3 3a5 5 0 0 0 7.07 7.07l1.71-1.71"/></svg>
        <span>Agregar Alumnos a Curso</span>
    </asp:LinkButton>
    <asp:LinkButton ID="btnBuscarCurso" runat="server" CssClass="action-link"
        OnClick="btnBuscarCurso_Click" CausesValidation="false">
        <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><circle cx="11" cy="11" r="7"/><path d="M21 21l-4.35-4.35"/></svg>
        <span>Buscar Curso</span>
    </asp:LinkButton>
</div>
