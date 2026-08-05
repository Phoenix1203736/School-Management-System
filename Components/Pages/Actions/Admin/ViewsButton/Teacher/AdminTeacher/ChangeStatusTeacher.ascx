<%@ Control Language="C#"  CodeBehind="ChangeStatusTeacher.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher.ChangeStatusTeacher" %>
<div class="card">
    <div class="card-header">
        <h4 class="mb-0">Cambiar estado del maestro</h4>
    </div>
    <div class="card-body">
        <div class="mb-3">
            <label class="form-label" for="<%= txtTeacherId.ClientID %>">ID del Maestro</label>
            <asp:TextBox ID="txtTeacherId" CssClass="form-control" runat="server" />
        </div>

        <div class="mb-3">
            <label class="form-label" for="<%= ddlStatus.ClientID %>">Nuevo Estado</label>
            <asp:DropDownList ID="ddlStatus" CssClass="form-select" runat="server" />
        </div>

        <div class="d-flex justify-content-end gap-2">
            <asp:Button ID="btnUpdateStatus" runat="server" Text="Actualizar Estado"
                CssClass="btn btn-primary"
                OnClick="btnUpdateStatus_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar"
                CssClass="btn btn-secondary"
                OnClick="btnCancel_Click" CausesValidation="false" />
        </div>
        <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 d-block text-success" />
    </div>
</div>
