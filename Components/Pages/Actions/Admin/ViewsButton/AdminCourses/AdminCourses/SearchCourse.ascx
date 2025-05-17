<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchCourse.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses.SearchCourse" %>
<div class="card p-3 mb-3">
    <h5>Buscar Curso</h5>
    <div class="mb-2">
        <label class="form-label">Nombre del curso</label>
        <asp:TextBox ID="txtBuscar" runat="server" Text="Buscar por id" CssClass="form-control" />
    </div>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" />
    <asp:GridView ID="gvResultados" runat="server" CssClass="table table-bordered table-sm mt-3"
        Visible="false" EmptyDataText="No ahi ningun curso" />
</div>