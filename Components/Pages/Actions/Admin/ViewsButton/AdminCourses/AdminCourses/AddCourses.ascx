<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddCourses.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses.AddCourses" %>
<div class="card p-3 mb-3">
    <h5>Agregar Curso</h5>
    <div class="mb-2">
        <label class="form-label">Nombre del curso</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-2">
        <label class="form-label">Término</label>
        <asp:TextBox ID="txtTermino" TextMode="Date" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-2">
        <label class="form-label">ID Profesor</label>
        <asp:TextBox ID="txtIdProfesor" runat="server" CssClass="form-control" />
    </div>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary"
        OnClick="btnAgregar_Click" />
</div>