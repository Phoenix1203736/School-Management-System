<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.ascx.cs" 
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views.AddStudent" %>

<div class="container mt-4">
    <div class="card-header bg-primary text-white">
        <h4 class="mb-0">Registro de alumno</h4>
    </div>
    <div class="card-body">
        <!-- First name-->
        <div class="mb-3">
            <label class="form-label">Nombre(s)</label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="validatorFirstName" runat="server" 
                ControlToValidate="txtFirstName"
                ErrorMessage="Campo obligatorio" 
                CssClass="text-danger" 
                Display="Dynamic" />
        </div>

        <!-- Last Name -->
        <div class="mb-3">
            <label class="form-label">Apellidos</label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="requiredTxtLastName" 
                ControlToValidate="txtLastName"
                Display="Dynamic" 
                CssClass="text-danger" 
                runat="server" 
                ErrorMessage="Campo obligatorio" />
        </div>

        <!-- Birth Date -->
        <div class="mb-3">
            <label class="form-label">Fecha Nacimiento:</label>
            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" TextMode="Date" />
            <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server"
                ControlToValidate="txtBirthDate"
                ErrorMessage="Campo obligatorio"
                CssClass="text-danger"
                Display="Dynamic" />
        </div>

        <!-- Email -->
        <div class="mb-3">
            <label class="form-label">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            <asp:RequiredFieldValidator ID="rfvEmail" 
                ErrorMessage="Campo Obligatorio"
                runat="server" 
                ControlToValidate="txtEmail" 
                CssClass="text-danger" 
                Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revEmail" 
                runat="server" 
                ControlToValidate="txtEmail"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ErrorMessage="Email inválido"
                CssClass="text-danger" 
                Display="Dynamic" />
        </div>

        <!-- Phone -->
        <div class="mb-3">
            <label class="form-label">Teléfono:</label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
            <asp:RegularExpressionValidator ID="revPhone" runat="server"
                ControlToValidate="txtPhone"
                ValidationExpression="^\d{10}$"
                ErrorMessage="El teléfono debe tener 10 dígitos." 
                CssClass="text-danger" 
                Display="Dynamic" />
        </div>

        <!-- Entry Date -->
        <div class="mb-3">
            <label class="form-label">Fecha Ingreso:</label>
            <asp:TextBox ID="txtEntryDate" runat="server" CssClass="form-control" TextMode="Date" />
            <asp:RequiredFieldValidator ID="rfvEntryDate" runat="server"
                ControlToValidate="txtEntryDate"
                ErrorMessage="Campo obligatorio"
                CssClass="text-danger"
                Display="Dynamic" />
        </div>

        <!-- Status -->
        <div class="mb-3">
            <label class="form-label">Estado:</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                <asp:ListItem Text="-- Seleccione --" Value="" />
                <asp:ListItem Text="Activo" Value="Active" />
                <asp:ListItem Text="Inactivo" Value="Inactive" />
                <asp:ListItem Text="Graduado" Value="Graduate" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvStatus" runat="server"
                ControlToValidate="ddlStatus" 
                InitialValue=""
                ErrorMessage="Debe seleccionar un estado." 
                CssClass="text-danger" 
                Display="Dynamic" />
        </div>
        
        <!-- Buttons -->
        <div class="d-flex justify-content-start mt-3">
            <asp:Button CssClass="btn btn-primary" ID="btnSave" 
                OnClick="btnSave_Click" 
                runat="server" 
                Text="Guardar" />
            
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar"
                CssClass="btn btn-secondary ms-2"
                CausesValidation="false"
                OnClick="btnCancel_Click" />
        </div>

        <!-- Messages -->
        <div class="mt-3">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
        </div>

        <!-- Validation Summary -->
        <asp:ValidationSummary ID="valSummary" runat="server"
            CssClass="text-danger mt-3" 
            HeaderText="Por favor corrija los siguientes errores:" />
    </div>
</div>