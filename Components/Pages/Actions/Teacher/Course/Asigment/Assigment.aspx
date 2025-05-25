<%@ Page Title="Trabajos" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Assigment.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Assigment" %>
<%@ Register tagName="AddAsigment" tagPrefix="uc" src="~/Components/Pages/Actions/Teacher/Course/Asigment/Views/AddAsigment.ascx" %>
<%@ Register tagName="GradeAsigment" tagPrefix="uc" src="~/Components/Pages/Actions/Teacher/Course/Asigment/Views/GradeAsigment.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" ID="content1" runat="server">
    <link rel="stylesheet" href="Styles.css" type="text/css" />

    <div class="container py-4">
        <div class="d-flex flex-wrap gap-3 mb-4">
            <asp:Button 
                ID="ButtonAddAsigment" 
                runat="server" 
                Text="Agregar asignación" 
                CssClass="btn btn-primary rounded-pill shadow-sm px-4"
                OnClick="ButtonAddAsigment_Click" />

            <asp:Button 
                ID="buttonAddGrade" 
                runat="server" 
                Text="Calificar asignaciones" 
                CssClass="btn btn-success rounded-pill shadow-sm px-4"
                OnClick="ButtonAddGrade_click" />
        </div>

        <div class="mt-3">
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