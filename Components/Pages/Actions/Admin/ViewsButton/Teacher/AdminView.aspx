<%@ Page Title="Administrar Maestros" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AdminView.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminViews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="workspace">
        <aside class="workspace-sidebar">
            <div class="card">
                <div class="card-header">
                    <h4 class="mb-0">Administración de Maestros</h4>
                </div>
                <div class="card-body p-2">
                    <asp:PlaceHolder ID="placeHolderAdminButtons" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </aside>
        <div class="workspace-content">
            <asp:PlaceHolder ID="placeHolderAdminView" runat="server" Visible="false"></asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
