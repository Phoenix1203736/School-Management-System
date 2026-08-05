<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateStudent.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views.UpdateStudent" %>
<div class="card">
    <div class="card-header">
        <h4 class="mb-0">Consulta de Usuario</h4>
    </div>
    <div class="card-body">
        <div class="mb-3">
            <asp:Label ID="lblUserId" runat="server" Text="ID de Usuario:" AssociatedControlID="txtUserId" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserId" runat="server"
                ControlToValidate="txtUserId" ErrorMessage="El ID es requerido"
                Display="Dynamic" CssClass="text-danger small"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revUserId" runat="server"
                ControlToValidate="txtUserId" ErrorMessage="Debe ser un número válido"
                ValidationExpression="^\d+$" Display="Dynamic" CssClass="text-danger small"></asp:RegularExpressionValidator>
        </div>

        <asp:Button ID="btnBuscar" runat="server" Text="Buscar Usuario"
            CssClass="btn btn-primary" OnClick="btnBuscar_Click" />

        <asp:Panel ID="pnlResultados" runat="server" Visible="false" CssClass="mt-4">
            <div class="mb-3">
                <asp:Label ID="lblFirstName" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblLastName" runat="server" Text="Apellido:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblBirthDate" runat="server" Text="Fecha de Nacimiento:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblPhone" runat="server" Text="Teléfono:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblDateEntry" runat="server" Text="Fecha de Ingreso:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtDateEntry" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblStatus" runat="server" Text="Estado:" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select" Enabled="false">
                    <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                    <asp:ListItem Text="Graduado" Value="Graduado"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </asp:Panel>

        <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-danger d-block" Visible="false"></asp:Label>
    </div>
</div>
