<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Buttonsteacher.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.Buttonsteacher" %>

<!-- Menú de acciones para profesores -->
<div class="action-list">
    <!-- Agregar Maestro -->
    <asp:LinkButton CausesValidation="False" CssClass="action-link" ID="AddTeacherButton" OnClick="AddTeacherButton_Click" runat="server">
        <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M19 8v6M22 11h-6"/></svg>
        <span>Agregar Maestro</span>
    </asp:LinkButton>

    <!-- Buscar Maestro -->
    <asp:LinkButton runat="server" ID="SearchTeacher"
        CssClass="action-link"
        OnClick="SearchTeacher_Click" CausesValidation="False">
        <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><circle cx="11" cy="11" r="7"/><path d="M21 21l-4.35-4.35"/></svg>
        <span>Buscar Maestro</span>
    </asp:LinkButton>

    <!-- Cambiar el estado del Maestro -->
    <asp:LinkButton runat="server" ID="ChangeStatusTeacher"
        CssClass="action-link"
        OnClick="ChangeStatusTeacher_Click" CausesValidation="False">
        <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M16 11l2 2 4-4"/></svg>
        <span>Cambiar el estado del Maestro</span>
    </asp:LinkButton>
</div>
