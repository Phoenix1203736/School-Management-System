<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentButtons.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.StudentButtons" %>
<div class="action-list">
    <!-- Agregar Estudiante -->
    <asp:LinkButton runat="server" ID="AddStudentButton"
        CssClass="action-link"
        OnClick="AddStudentButton_Click" CausesValidation="False">
        <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M12 5v14M5 12h14"/></svg>
        <span>Agregar Estudiante</span>
    </asp:LinkButton>
    <!-- Buscar Estudiante -->
    <asp:LinkButton runat="server" ID="SearchStudent"
        CssClass="action-link"
        OnClick="SearchStudent_Click" CausesValidation="False">
        <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><circle cx="11" cy="11" r="7"/><path d="M21 21l-4.35-4.35"/></svg>
        <span>Buscar Estudiante</span>
    </asp:LinkButton>
    <!-- Cambiar estado Estudiante -->
    <asp:LinkButton runat="server" ID="ChangeStatusStudent"
        CssClass="action-link"
        OnClick="ChangeStatusStudent_Click" CausesValidation="False">
        <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M16 11l2 2 4-4"/></svg>
        <span>Cambiar estado del Estudiante</span>
    </asp:LinkButton>
</div>
