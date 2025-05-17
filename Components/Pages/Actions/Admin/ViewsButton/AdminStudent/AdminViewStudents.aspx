<%@ Page Title="Administracion Alumnos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="AdminViewStudents.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.AdminViewStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="StylesStudentView.css" type="text/css" />
    <div class="parent">
        <div class="div1">
            <asp:PlaceHolder ID="placeHolderStudentButtons" runat="server" />
        </div>
        <div class="div2">
            <asp:PlaceHolder ID="placeHolderStudentView" runat="server" Visible="false" />
        </div>
    </div>

</asp:Content>