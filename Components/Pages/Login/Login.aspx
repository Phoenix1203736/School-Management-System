<%@ Page Title="Inicia Sesion en Edu Soft" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemsProyect.Components.Pages.Login.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <style>
        .login-container {
            margin-top: 100px;
            max-width: 400px;
            padding: 20px;
        }
    </style>
<body class="bg-light">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 login-container bg-white shadow rounded">
                    <h2 class="text-center mb-4">Inicio de Sesión</h2>
                    
                    <!-- Email -->
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="form-label">Email</asp:Label>
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email"  MaxLength="50"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                            CssClass="text-danger" ErrorMessage="El email es requerido" Display="Dynamic"/>
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            CssClass="text-danger" ErrorMessage="Formato de email inválido" Display="Dynamic"/>
                    </div>

                    <!-- Contraseña -->
                    <div class="form-group mt-3">
                        <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="form-label">Contraseña</asp:Label>
                        <asp:TextBox runat="server" ID="txtPassword"  TextMode="Password" CssClass="form-control" MaxLength="50" AutoComplete="off" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                            CssClass="text-danger" ErrorMessage="La contraseña es requerida" Display="Dynamic"/>
                    </div>

                    <!-- Botón de Login -->
                    <div class="form-group mt-4">
                        <asp:Button runat="server" ID="btnLogin" Text="Iniciar Sesión" 
                            CssClass="btn btn-primary w-100" OnClick="btnlogin_click"/>
                    </div>

                    <!-- Mensaje de error -->
                    <div class="mt-3">
                        <asp:Label runat="server" ID="lblMensaje" CssClass="text-danger" Visible="false"/>
                    </div>

                    <!-- Enlace de recuperación 
                    <div class="text-center mt-3">
                        <a href="RecuperarPassword.aspx">¿Olvidaste tu contraseña?</a>
                    </div>-->
                </div>
            </div>
        </div>
</body>
</asp:Content>