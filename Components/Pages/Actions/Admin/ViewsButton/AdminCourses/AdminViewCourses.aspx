<%@ Page Title="Administración de Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AdminViewCourses.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminViewCourses" %>
<%@Register tagPrefix="uc" tagName="AddCourse" src="~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/AdminCourses/AddCourses.ascx"%>
<%@ Register tagName="AddCourseStudent" tagPrefix="uc" src="~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/AdminCourses/AddCourseStudent.ascx"%>
<%@Register tagName="SearchCource" tagPrefix="uc" src="~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/AdminCourses/SearchCourse.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="workspace">
        <aside class="workspace-sidebar">
            <div class="card">
                <div class="card-header">
                    <h4 class="mb-0">Gestión de Cursos</h4>
                </div>
                <div class="card-body p-2">
                    <asp:PlaceHolder ID="placeHolderAdminButtons" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </aside>
        <div class="workspace-content">
            <uc:AddCourse ID="AddCourses" Visible="False" ViewStateMode="Enabled" runat="server"/>
            <uc:AddCourseStudent runat="server" ID="AddStudentCourseV" Visible="false" ViewStateMode="Enabled"/>
            <uc:SearchCource runat="server" ID="SearchCourse" Visible="false" ViewStateMode="Enabled"/>
        </div>
    </div>
</asp:Content>
