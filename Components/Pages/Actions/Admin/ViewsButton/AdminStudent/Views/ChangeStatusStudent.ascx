<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangeStatusStudent.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views.ChangeStatusStudent" %>
<div class="container mt-4">
    <h4>Cambiar estado del Alumno</h4>
    <div class="form-group">
        <label>ID del Alumno</label>
        <asp:TextBox ID="txtStudentId" CssClass="form-control" runat="server" />
    </div>

    <label class="col-sm-3 col-form-label">Estado:</label>
    <div class="col-sm-9">
        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
            <asp:ListItem Value="Select" Text="Selecione el estado" Selected="True"></asp:ListItem>
            <asp:ListItem Value="active" Text="Activo"></asp:ListItem>
            <asp:ListItem Value="inactive" Text="Inactivo"></asp:ListItem>
            <asp:ListItem Value="graduate" Text="Graduado"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvStatus" runat="server"
            ControlToValidate="ddlStatus"
            InitialValue="Select"
            ErrorMessage="Debe seleccionar un estado válido"
            CssClass="text-danger"
            Display="Dynamic">
        </asp:RequiredFieldValidator>

        <asp:Button ID="btnUpdateStatus" runat="server" Text="Actualizar Estado"
            CssClass="btn btn-primary mt-3"
            OnClick="btnUpdateStatus_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancelar"
            CssClass="btn btn-secondary mt-3 ms-2"
            OnClick="btnCancel_Click" CausesValidation="false" />
        <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 d-block text-success" />
    </div>
</div>