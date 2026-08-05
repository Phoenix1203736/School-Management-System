<%@ Page Title="Inicia Sesion en Edu Soft" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemsProyect.Components.Pages.Login.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-start py-5">
        <div class="card auth-card">
            <div class="card-header text-center">
                <h3 class="mb-0">Inicio de Sesión</h3>
            </div>
            <div class="card-body p-4">
                <!-- Email -->
                <div class="mb-3">
                    <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="form-label">Email</asp:Label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" MaxLength="50"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                        CssClass="text-danger small" ErrorMessage="El email es requerido" Display="Dynamic"/>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        CssClass="text-danger small" ErrorMessage="Formato de email inválido" Display="Dynamic"/>
                </div>

                <!-- Contraseña -->
                <div class="mb-3">
                    <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="form-label">Contraseña</asp:Label>
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" MaxLength="50" AutoComplete="off" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                        CssClass="text-danger small" ErrorMessage="La contraseña es requerida" Display="Dynamic"/>
                </div>

                <!-- Botón de Login -->
                <div class="mt-4">
                    <asp:Button runat="server" ID="btnLogin" Text="Iniciar Sesión"
                        CssClass="btn btn-primary w-100" OnClick="btnlogin_click"/>
                </div>

                <!-- Mensaje de error -->
                <div class="mt-3">
                    <asp:Label runat="server" ID="lblMensaje" CssClass="text-danger d-block" Visible="false"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
