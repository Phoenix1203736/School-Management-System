<%@ Page Title="Administracion Alumnos" Language="C#" MasterPageFile="~/Site.Master"
AutoEventWireup="true" CodeBehind="AdminViewStudents.aspx.cs" 
Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.AdminViewStudents" %>
<%@ Register TagPrefix="uc" TagName="AddStudent" 
Src="~/Components/Pages/Actions/Admin/ViewsButton/AdminStudent/Views/AddStudent.ascx" %>
<%@ Register tagPrefix="uc" tagName="SearchStudent" src="~/Components/Pages/Actions/Admin/ViewsButton/AdminStudent/Views/SearchStudent.ascx"%>
<%@Register tagPrefix="uc" tagName="ChangeStatus" src="~/Components/Pages/Actions/Admin/ViewsButton/AdminStudent/Views/ChangeStatusStudent.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="workspace">
        <aside class="workspace-sidebar">
            <div class="card">
                <div class="card-header">
                    <h4 class="mb-0">Administración de Alumnos</h4>
                </div>
                <div class="card-body p-2">
                    <asp:PlaceHolder ID="placeHolderStudentButtons" runat="server" />
                </div>
            </div>
        </aside>
        <div class="workspace-content">
            <uc:AddStudent runat="server" ID="addStudentControl" Visible="false" ViewStateMode="Enabled" />
            <uc:SearchStudent runat="server" ID="SearchStudentControl" Visible="false" ViewStateMode="Enabled" />
            <uc:ChangeStatus runat="server" ID="ChangeStatusControl" Visible="false" ViewStateMode="Enabled"/>
        </div>
    </div>
</asp:Content>
