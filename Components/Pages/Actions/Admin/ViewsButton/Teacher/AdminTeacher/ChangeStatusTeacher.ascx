<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangeStatusTeacher.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher.ChangeStatusTeacher" %>
<div class="container mt-4">
    <h4>Cambiar estado del maestro</h4>
    <div class="form-group">
        <label>ID del Maestro</label>
        <asp:TextBox ID="txtTeacherId" CssClass="form-control" runat="server" />
    </div>

    <div class="form-group mt-3">
        <label>Nuevo Estado</label>
        <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server" />
    </div>

    <asp:Button ID="btnUpdateStatus" runat="server" Text="Actualizar Estado"
        CssClass="btn btn-primary mt-3"
        OnClick="btnUpdateStatus_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar"
        CssClass="btn btn-secondary mt-3 ms-2"
        OnClick="btnCancel_Click" CausesValidation="false" />
    <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 d-block text-success" />
</div>