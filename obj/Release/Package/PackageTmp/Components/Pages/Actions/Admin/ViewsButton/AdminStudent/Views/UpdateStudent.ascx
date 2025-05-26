<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateStudent.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views.UpdateStudent" %>
<div class="user-query-container">
    <h3>Consulta de Usuario</h3>

    <div class="form-group">
        <asp:Label ID="lblUserId" runat="server" Text="ID de Usuario:" AssociatedControlID="txtUserId"></asp:Label>
        <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUserId" runat="server"
            ControlToValidate="txtUserId" ErrorMessage="El ID es requerido"
            Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revUserId" runat="server"
            ControlToValidate="txtUserId" ErrorMessage="Debe ser un número válido"
            ValidationExpression="^\d+$" Display="Dynamic" CssClass="text-danger"></asp:RegularExpressionValidator>
    </div>

    <div class="form-group">
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar Usuario"
            CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
    </div>

    <asp:Panel ID="pnlResultados" runat="server" Visible="false" CssClass="user-details">
        <div class="form-group">
            <asp:Label ID="lblFirstName" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblLastName" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblBirthDate" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPhone" runat="server" Text="Teléfono:"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblDateEntry" runat="server" Text="Fecha de Ingreso:"></asp:Label>
            <asp:TextBox ID="txtDateEntry" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblStatus" runat="server" Text="Estado:"></asp:Label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" Enabled="false">
                <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                <asp:ListItem Text="Graduado" Value="Graduado"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </asp:Panel>

    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
</div>