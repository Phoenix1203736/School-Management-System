<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentButtons.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.StudentButtons" %>
<div class="button-container">
    <div class="d-flex flex-wrap gap-3 p-3 justify-content-center">
        <!-- Botón Agregar Estudiante -->
        <asp:Button runat="server" ID="AddStudentButton"
            CssClass="btn btn-primary flex-grow-1"
            Text="Agregar Estudiante"
            OnClick="AddStudentButton_Click" CausesValidation="False" />
        <!-- Botón Buscar Estudiante -->
        <asp:Button runat="server" ID="SearchStudent"
            CssClass="btn btn-info flex-grow-1"
            Text="Buscar Estudiante"
            OnClick="SearchStudent_Click" CausesValidation="False" />
        <!-- Botón Cambiar estado Estudiante -->
        <asp:Button runat="server" ID="ChangeStatusStudent"
            CssClass="btn btn-danger flex-grow-1"
            Text="Cambiar estado del  Estudiante"
            OnClick="ChangeStatusStudent_Click" CausesValidation="False" />
        <!-- Botón Actualizar Estudiante -->
        <%--<asp:Button runat="server" ID="UpdateStudent" CssClass="btn btn-warning"
            Text="Actualizar Estudiante"
            OnClick="UpdateStudent_Click" CausesValidation="False" />--%>
    </div>
</div>