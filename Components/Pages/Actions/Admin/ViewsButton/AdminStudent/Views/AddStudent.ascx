<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminStudent.Views.AddStudent" %>
<div class="card">
    <div class="card-header bg-primary text-white">
        <h5>Agregar Nuevo Alumno</h5>
    </div>
    <div class="card-body">
        <div class="form-group row">
            <label class="col-sm-3 col-form-label">Nombres:</label>
            <div class="col-sm-9">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                    ErrorMessage="Campo obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label">Apellidos:</label>
            <div class="col-sm-9">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" MaxLength="180"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                    ErrorMessage="Campo obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label">Fecha Nacimiento:</label>
            <div class="col-sm-9">
                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label">Email:</label>
            <div class="col-sm-9">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"
                       MaxLength="255"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Campo obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ErrorMessage="Formato de email inválido" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label">Teléfono:</label>
            <div class="col-sm-9">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label">Fecha Ingreso:</label>
            <div class="col-sm-9">
                <asp:TextBox ID="txtEntryDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
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
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-9 offset-sm-3">
                <asp:Button ID="btnSave" runat="server" Text="Guardar Alumno" CssClass="btn btn-primary"
                    OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-secondary ml-2"
                    CausesValidation="false" OnClick="btnCancel_Click" />
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-9 offset-sm-3">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</div>