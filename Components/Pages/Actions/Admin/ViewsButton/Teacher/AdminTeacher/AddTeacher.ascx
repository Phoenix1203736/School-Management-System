<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddTeacher.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher.AddTeacher" %>

<div class="container mt-4">
    <div class="card-header bg-primary text-white">
        <h4 class="mb-0">Registro de maestro</h4>
    </div>
    <div class="card-body">
        <!-- First name-->
        <div class="mb-3">
            <label class="form-label">Nombre(s)</label>
            <asp:TextBox ID="textBoxFirstName" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="validatorFirstName" runat="server" ControlToValidate="textBoxFirstName"
                ErrorMessage="Campo obligatorio" CssClass="text-danger" Display="Dynamic" />
            <!--Last Name -->
            <div class="mb-3">
                <label class="form-label">Apellidos</label>
                <asp:TextBox ID="textBoxLastName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="requiredTextBoxLastName" ControlToValidate="textBoxLastName"
                    Display="Dynamic" CssClass="text-danger" runat="server" ErrorMessage="Campo obligatorio" />
            </div>
            <!-- Email -->
            <div class="mb-3">
                <label class="form-label">Email:</label>
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="requieredFieldEmail" ErrorMessage="Campo Obligatorio"
                    runat="server" ControlToValidate="TextBoxEmail" CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="RegularExpresionEmail" runat="server" ControlToValidate="TextBoxEmail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email Invalido"
                    CssClass="text-danger" Display="Dynamic" />
            </div>

            <!-- pasword -->
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" 
                    ReadOnly="true" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="TextBoxPassword" ErrorMessage="Campo obligatorio"
                    CssClass="text-danger" Display="Dynamic" />

                <!-- Phone -->
                <div class="mb-3">
                    <label class="form-label">Phone</label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server"
                        ControlToValidate="txtPhone" ErrorMessage="Phone is required."
                        CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revPhone" runat="server"
                        ControlToValidate="txtPhone"
                        ValidationExpression="^\d{10}$"
                        ErrorMessage="Phone must be 10 digits." CssClass="text-danger" Display="Dynamic" />
                </div>

                <!-- Hire Date -->
                <div class="mb-3">
                    <label class="form-label">Hire Date</label>
                    <asp:TextBox ID="txtHireDate" runat="server" CssClass="form-control" />
                    <ajaxToolkit:CalendarExtender ID="ceHireDate" runat="server"
                        TargetControlID="txtHireDate" Format="yyyy-MM-dd" />
                    <asp:RequiredFieldValidator ID="rfvHireDate" runat="server"
                        ControlToValidate="txtHireDate" ErrorMessage="Hire date is required."
                        CssClass="text-danger" Display="Dynamic" />
                    <asp:CompareValidator ID="cvDate" runat="server"
                        ControlToValidate="txtHireDate" Operator="DataTypeCheck" Type="Date"
                        ErrorMessage="Invalid date." CssClass="text-danger" Display="Dynamic" />
                </div>

                <!-- Specialization -->
                <div class="mb-3">
                    <label class="form-label">Specialization</label>
                    <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvSpecialization" runat="server"
                        ControlToValidate="txtSpecialization" ErrorMessage="Specialization is required."
                        CssClass="text-danger" Display="Dynamic" />
                </div>

                <!-- Status -->
                <div class="mb-3">
                    <label class="form-label">Status</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                        <asp:ListItem Text="-- Select --" Value="" />
                        <asp:ListItem Text="Active" Value="Active" />
                        <asp:ListItem Text="Retired" Value="Retired" />
                        <asp:ListItem Text="Inactive" Value="Inactive" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvStatus" runat="server"
                        ControlToValidate="ddlStatus" InitialValue=""
                        ErrorMessage="Please select a status." CssClass="text-danger" Display="Dynamic" />
                </div>
                <div class="d-flex justify-content-start mt-3">
                    <asp:Button ID="SumitButton" runat="server" Text="Register"
                        CssClass="btn btn-primary" OnClick="SumitButton_Click" />

                    <asp:Button ID="CancleButton" runat="server" Text="Cancel"
                        CssClass="btn btn-secondary ms-2"
                        CausesValidation="false"
                        OnClick="CancleButton_Click" />
                </div>
                <!-- Validation Summary -->
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    CssClass="text-danger mt-3" HeaderText="Favor de completar los siguientes problemas:" />
            </div>
        </div>
    </div>
</div>