<%@ Page Title="Administrar Maestros" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AdminView.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminViews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="StylesAdminView.css" type="text/css" />
    <div class="parent">
        <div class="div1">
            <asp:PlaceHolder ID="placeHolderAdminButtons" runat="server"></asp:PlaceHolder>
        </div>
        <div class="div2">
            <asp:PlaceHolder ID="placeHolderAdminView" runat="server" Visible="false"></asp:PlaceHolder>
        </div>
    </div>

</asp:Content>