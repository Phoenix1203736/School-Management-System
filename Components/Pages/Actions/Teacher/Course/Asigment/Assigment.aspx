<%@ Page Title="Trabajos" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Assigment.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Assigment" %>
<%@ Register tagName="AddAsigment" tagPrefix="uc" src="~/Components/Pages/Actions/Teacher/Course/Asigment/Views/AddAsigment.ascx" %>
<%@ Register tagName="GradeAsigment" tagPrefix="uc" src="~/Components/Pages/Actions/Teacher/Course/Asigment/Views/GradeAsigment.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="content1" runat="server">
    <div class="workspace">
        <aside class="workspace-sidebar">
            <div class="card">
                <div class="card-header">
                    <h4 class="mb-0">Tareas de cursos</h4>
                </div>
                <div class="card-body p-2">
                    <div class="action-list">
                        <asp:LinkButton
                            ID="ButtonAddAsigment"
                            runat="server"
                            CssClass="action-link"
                            OnClick="ButtonAddAsigment_Click" CausesValidation="false">
                            <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M12 5v14M5 12h14"/></svg>
                            <span>Agregar asignación</span>
                        </asp:LinkButton>

                        <asp:LinkButton
                            ID="buttonAddGrade"
                            runat="server"
                            CssClass="action-link"
                            OnClick="ButtonAddGrade_click" CausesValidation="false">
                            <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"/><rect x="8" y="2" width="8" height="4" rx="1"/></svg>
                            <span>Calificar asignaciones</span>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </aside>
        <div class="workspace-content">
            <uc:AddAsigment
                runat="server"
                ID="AddAsigmentControl"
                Visible="false"
                ViewStateMode="Enabled" />

            <uc:GradeAsigment
                runat="server"
                ID="GradeAsigmentControl"
                Visible="false"
                ViewStateMode="Enabled" />
        </div>
    </div>
</asp:Content>
