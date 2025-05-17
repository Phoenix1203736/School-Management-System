<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBarAdmin.ascx.cs"
    Inherits="SistemsProyect.Components.NavBar.Admin.NavBarAdmin" %>
<div class="container-fluid">
    <a class="navbar-brand" href="<%= ResolveUrl("~/Default.aspx") %>">Edu soft</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown"
        aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNavDropdown">
       <ul class="navbar-nav">
            <li class="nav-item dropdown"></li>
            <asp:DropDownList ID="dropdownManageOptions" runat="server" CssClass="nav-link dropdown-toggle"
                OnSelectedIndexChanged="dropdownManageOptions_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <li class="nav-item ">
                <a class="nav-link">
                    <asp:Button CssClass="btn-outline-info" runat="server" ID="buttonSignOut" OnClick="buttonSignOut_Click"
                                Text="Cerrar Sesión" />
                </a>
            </li>
        </ul>
        <!--<a class="nav-link dropdown-toggle" role="button" data-bs-toggle="dropdown" aria-expanded="">dropdown</a>
                <ul class="dropdown-menu">
                    <li><a class="dropdown-item">action</a></li>-->
        <!--      </ul>
            </li>
        </ul>-->
    </div>
</div>
<script>
    document.addEventListener("DOMContentLoaded", function () {
        var ddl = document.getElementById('<%= dropdownManageOptions.ClientID %>');
        if (ddl) {
            // Saltamos el primer elemento (placeholder)
            if (ddl.options.length > 1) {
                ddl.options[1].style.color = "Black";  // Administrar Alumnos
                ddl.options[2].style.color = "black"; // Administrar Profesores
                ddl.options[3].style.color = "Black";
                ddl.options[4].style.color = "Black";

            }
        }
    });
</script>