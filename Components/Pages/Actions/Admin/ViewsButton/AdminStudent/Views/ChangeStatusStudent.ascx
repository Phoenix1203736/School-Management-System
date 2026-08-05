<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangeStatusStudent.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views.ChangeStatusStudent" %>
<div class="card">
    <div class="card-header">
        <h4 class="mb-0">Cambiar estado del Alumno</h4>
    </div>
    <div class="card-body">
        <div class="mb-3">
            <label class="form-label" for="<%= txtStudentId.ClientID %>">ID del Alumno</label>
            <asp:TextBox ID="txtStudentId" CssClass="form-control" runat="server" />
        </div>

        <div class="mb-3">
            <label class="form-label" for="<%= ddlStatus.ClientID %>">Estado:</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                <asp:ListItem Value="Select" Text="Selecione el estado" Selected="True"></asp:ListItem>
                <asp:ListItem Value="active" Text="Activo"></asp:ListItem>
                <asp:ListItem Value="inactive" Text="Inactivo"></asp:ListItem>
                <asp:ListItem Value="graduate" Text="Graduado"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvStatus" runat="server"
                ControlToValidate="ddlStatus"
                InitialValue="Select"
                ErrorMessage="Debe seleccionar un estado válido"
                CssClass="text-danger small"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
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
