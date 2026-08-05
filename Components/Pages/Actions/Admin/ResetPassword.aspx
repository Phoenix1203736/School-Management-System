<%@ Page Title="Restablecer Contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ResetPassword.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="p-4 bg-white shadow rounded">
                    <h2 class="text-center mb-4">Restablecer Contraseña</h2>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="form-label">Email del usuario</asp:Label>
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" MaxLength="50"/>
                    </div>

                    <div class="form-group mt-3">
                        <asp:Label runat="server" AssociatedControlID="txtNewPassword" CssClass="form-label">Nueva contraseña</asp:Label>
                        <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control" TextMode="Password" MaxLength="50"/>
                    </div>

                    <div class="form-group mt-3">
                        <asp:Label runat="server" AssociatedControlID="txtConfirmPassword" CssClass="form-label">Confirmar contraseña</asp:Label>
                        <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control" TextMode="Password" MaxLength="50"/>
                        <asp:CompareValidator runat="server" ControlToCompare="txtNewPassword"
                            ControlToValidate="txtConfirmPassword" CssClass="text-danger"
                            ErrorMessage="Las contraseñas no coinciden" Display="Dynamic"/>
                    </div>

                    <div class="form-group mt-4">
                        <asp:Button runat="server" ID="btnReset" Text="Restablecer"
                            CssClass="btn btn-primary w-100" OnClick="btnReset_Click"/>
                    </div>

                    <div class="mt-3">
                        <asp:Label runat="server" ID="lblMessage" CssClass="text-danger" Visible="false"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>