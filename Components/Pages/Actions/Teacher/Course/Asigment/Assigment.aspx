<%@ Page Title="Trabajos" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Assigment.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Assigment" %>
<%@ Register tagName="AddAsigment" tagPrefix="uc" src="~/Components/Pages/Actions/Teacher/Course/Asigment/Views/AddAsigment.ascx" %>
<%@ Register tagName="GradeAsigment" tagPrefix="uc" src="~/Components/Pages/Actions/Teacher/Course/Asigment/Views/GradeAsigment.ascx" %>
<asp:Content ContentPlaceHolderID="MainContent" ID="content1" runat="server">
    <link rel="stylesheet" href="Styles.css" type="text/css"/>
    <div class="parent">
        <div class="div1">
            <div class="justify-content-center align-items-center">
                <asp:Button ID="ButtonAddAsigment" Text="Agregar asignación" OnClick="ButtonAddAsigment_Click" runat="server" CssClass="btn btn-primary"/>
            </div>
        <div class="div2">
            <asp:Button runat="server" ID="buttonAddGrade" Text="Calificar asignaciónes" OnClick="ButtonAddGrade_click"/>
            </div>
        <div class="div3">
            <uc:AddAsigment runat="server" ID="AddAsigmentControl" Visible="false" ViewStateMode="Enabled"/>
            <uc:GradeAsigment runat="server" ID="GradeAsigmentControl" Visible="false" ViewStateMode="Enabled"/>
        </div>
    </div>
    </div>
</asp:Content>