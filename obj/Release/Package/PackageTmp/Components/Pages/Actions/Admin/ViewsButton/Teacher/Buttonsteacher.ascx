<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Buttonsteacher.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.Buttonsteacher" %>

<!-- Versión mejorada con disposición horizontal y responsive -->
<div class="button-container">
    <div class="d-flex flex-wrap gap-3 p-3 justify-content-center">
        <!-- Botón Agregar Maestro -->
        <asp:Button CausesValidation="False" CssClass="btn btn-primary flex-grow-1" ID="AddTeacherButton" OnClick="AddTeacherButton_Click" runat="server" Text="Agregar Maestro" />

        <!-- Botón Buscar Maestro -->
        <asp:Button runat="server" ID="SearchTeacher"
            CssClass="btn btn-info flex-grow-1"
            Text="Buscar Maestro"
            OnClick="SearchTeacher_Click" CausesValidation="False" />

        <!-- Botón Cambiar el estado del Maestro -->
        <asp:Button runat="server" ID="ChangeStatusTeacher"
            CssClass="btn btn-danger flex-grow-1"
            Text="Cambiar el estado Maestro"
            OnClick="ChangeStatusTeacher_Click" CausesValidation="False" />

        <!-- Button update Teacher -->
        <%--<asp:Button runat="server" ID="UpdateTeacher" CssClass="btn btn-warning"
            Text="Actualizar Maestro"
            OnClick="UpdateTeacher_Click" CausesValidation="False" />--%>

    </div>
</div>

<style>
    /* Estilos personalizados */
    .button-container {
        max-width: 800px; /* Ancho máximo para pantallas grandes */
        margin: 0 auto; /* Centrado horizontal */
    }

    @media (max-width: 768px) {
        .button-container .btn {
            min-width: 100%; /* Botones a ancho completo en móviles */
        }
    }
</style>