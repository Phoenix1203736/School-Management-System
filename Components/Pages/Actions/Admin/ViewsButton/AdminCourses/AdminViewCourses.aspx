<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AdminViewCourses.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminViewCourses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="StylesCoursesView.css" type="text/css" />
    <div class="parent">
        <div class="div1">
            <asp:PlaceHolder ID="placeHolderAdminButtons" runat="server"></asp:PlaceHolder>
        </div>
        <div class="div2">
            <asp:PlaceHolder ID="placeHolderAdminView" runat="server" Visible="false"></asp:PlaceHolder>
        </div>
    </div>
</asp:Content>