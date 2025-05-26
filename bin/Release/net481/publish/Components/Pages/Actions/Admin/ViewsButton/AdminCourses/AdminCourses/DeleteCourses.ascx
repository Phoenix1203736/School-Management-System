<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeleteCourses.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses.DeleteCourses" %>

<div class="card p-3 mb-3">
    <h5>Eliminar Curso</h5>
    <div class="mb-2">
        <label class="form-label">ID del curso</label>
        <asp:TextBox ID="txtIdCurso" runat="server" CssClass="form-control" />
    </div>
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger"
        OnClick="btnEliminar_Click" />
</div>